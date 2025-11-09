using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace MessengerApp
{
    public partial class MainForm : Form
    {
        // Серверные компоненты
        private TcpListener server;
        private Thread serverThread;
        private bool isServerRunning = false;
        private List<TcpClient> connectedClients = new List<TcpClient>();

        // Клиентские компоненты  
        private TcpClient client;
        private NetworkStream clientStream;
        private Thread clientThread;

        private int port = 8080;
        private string currentUser;
        private bool isFormReady = false;

        public MainForm()
        {
            InitializeComponent();
            currentUser = "User_" + new Random().Next(1000, 9999);
            Text = $"Messenger - {currentUser}";

            // Ждем полной загрузки формы перед вызовами Invoke
            this.Load += (s, e) => {
                isFormReady = true;
                UpdateStatus("Не подключено");
                serverInfoLabel.Text = "Ваш IP: " + GetLocalIPAddress();

                // Автоматически подстраиваем размеры после загрузки
                AdjustLayout();
            };

            // Также обрабатываем изменение размера окна
            this.Resize += (s, e) => AdjustLayout();
        }

        // === БЕЗОПАСНЫЕ ВЫЗОВЫ ДЛЯ UI ===
        private void SafeInvoke(Action action)
        {
            if (IsDisposed || !isFormReady) return;

            if (InvokeRequired)
            {
                try
                {
                    if (IsHandleCreated && !IsDisposed)
                    {
                        BeginInvoke(action);
                    }
                }
                catch (ObjectDisposedException) { }
                catch (InvalidOperationException) { }
            }
            else
            {
                action();
            }
        }

        private void AddMessage(string sender, string text, Color color)
        {
            if (!isFormReady) return;

            SafeInvoke(() =>
            {
                string timestamp = DateTime.Now.ToString("HH:mm:ss");
                string formattedMessage = $"[{timestamp}] {sender}: {text}";

                chatTextBox.SelectionStart = chatTextBox.TextLength;
                chatTextBox.SelectionColor = color;
                chatTextBox.AppendText(formattedMessage + Environment.NewLine);
                chatTextBox.ScrollToCaret();
            });
        }

        private void AddSystemMessage(string text)
        {
            AddMessage("Система", text, Color.Gray);
        }

        private void UpdateStatus(string status)
        {
            SafeInvoke(() =>
            {
                if (statusLabel != null && !statusLabel.IsDisposed)
                {
                    statusLabel.Text = status;
                    statusLabel.ForeColor = status.Contains("Ошибка") ? Color.Red :
                                          status.Contains("Подключено") ? Color.Green : Color.Black;
                }
            });
        }

        private void UpdateUserList(List<string> users = null)
        {
            SafeInvoke(() =>
            {
                if (userListBox != null && !userListBox.IsDisposed)
                {
                    userListBox.Items.Clear();
                    userListBox.Items.Add(currentUser + " (Вы)");

                    if (users != null && users.Count > 0)
                    {
                        foreach (string user in users)
                        {
                            if (user != currentUser)
                                userListBox.Items.Add(user);
                        }
                    }
                }
            });
        }

        // === СЕТЕВАЯ ИНФОРМАЦИЯ ===
        private string GetNetworkInfo()
        {
            string result = "Сетевые интерфейсы:\n";

            try
            {
                // Получаем все сетевые интерфейсы
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface ni in interfaces)
                {
                    // Показываем только активные Ethernet/Wi-Fi интерфейсы
                    if (ni.OperationalStatus == OperationalStatus.Up &&
                        (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                         ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet))
                    {
                        IPInterfaceProperties ipProps = ni.GetIPProperties();
                        foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                result += $"{ni.Name}: {ip.Address}\n";
                            }
                        }
                    }
                }

                result += $"\nДля подключения используйте любой из этих IP-адресов и порт: {port}";
            }
            catch (Exception ex)
            {
                result += $"Ошибка получения сетевой информации: {ex.Message}";
            }

            return result;
        }

        private string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
            }
            catch (Exception)
            {
                // Игнорируем ошибки получения IP
            }
            return "127.0.0.1";
        }

        // === СЕРВЕРНАЯ ЧАСТЬ ===
        private void StartServer()
        {
            try
            {
                // Важно: используем IPAddress.Any для прослушивания всех интерфейсов
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                isServerRunning = true;
                serverThread = new Thread(new ThreadStart(ListenForClients));
                serverThread.IsBackground = true;
                serverThread.Start();

                string networkInfo = GetNetworkInfo();

                UpdateStatus($"Сервер запущен на порту {port}");
                AddSystemMessage($"Сервер запущен!\n{networkInfo}");

                SafeInvoke(() => {
                    if (startServerButton != null) startServerButton.Enabled = false;
                    if (stopServerButton != null) stopServerButton.Enabled = true;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка запуска сервера: {ex.Message}\n\nВозможно, порт {port} уже занят.",
                                "Ошибка сервера",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void StopServer()
        {
            isServerRunning = false;

            // Закрываем всех подключенных клиентов
            lock (connectedClients)
            {
                foreach (var client in connectedClients.ToList())
                {
                    try { client.Close(); } catch { }
                }
                connectedClients.Clear();
            }

            try { server?.Stop(); } catch { }

            SafeInvoke(() => {
                if (startServerButton != null) startServerButton.Enabled = true;
                if (stopServerButton != null) stopServerButton.Enabled = false;
            });

            UpdateStatus("Сервер остановлен");
            AddSystemMessage("Сервер остановлен");
        }

        private void ListenForClients()
        {
            while (isServerRunning)
            {
                try
                {
                    TcpClient newClient = server.AcceptTcpClient();
                    lock (connectedClients)
                    {
                        connectedClients.Add(newClient);
                    }

                    Thread clientHandlerThread = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientHandlerThread.IsBackground = true;
                    clientHandlerThread.Start(newClient);
                }
                catch (Exception ex)
                {
                    if (isServerRunning)
                        AddSystemMessage($"Ошибка принятия подключения: {ex.Message}");
                    break;
                }
            }
        }

        private void HandleClient(object clientObj)
        {
            TcpClient tcpClient = (TcpClient)clientObj;
            string clientUser = "";

            try
            {
                NetworkStream clientStream = tcpClient.GetStream();

                // Получаем информацию о пользователе
                byte[] buffer = new byte[4096];
                int bytesRead = clientStream.Read(buffer, 0, buffer.Length);
                string userInfo = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                var userMessage = JsonSerializer.Deserialize<ChatMessage>(userInfo);
                clientUser = userMessage.Sender;

                AddSystemMessage($"{clientUser} подключился");

                // Отправляем текущему спискок пользователей
                SendUserList(tcpClient);

                // Уведомляем всех о новом пользователе
                BroadcastUserJoin(clientUser);

                // Слушаем сообщения от этого клиента
                while (tcpClient.Connected && isServerRunning)
                {
                    bytesRead = clientStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    ProcessReceivedMessage(message);
                }
            }
            catch (Exception ex)
            {
                AddSystemMessage($"Ошибка обработки клиента {clientUser}: {ex.Message}");
            }
            finally
            {
                lock (connectedClients)
                {
                    connectedClients.Remove(tcpClient);
                }
                try { tcpClient.Close(); } catch { }

                if (!string.IsNullOrEmpty(clientUser))
                {
                    AddSystemMessage($"{clientUser} отключился");
                    BroadcastUserLeave(clientUser);
                }
            }
        }

        private void SendUserList(TcpClient targetClient)
        {
            try
            {
                var userList = new List<string> { currentUser };
                lock (connectedClients)
                {
                    userList.AddRange(connectedClients.Count > 0 ?
                        new List<string> { "Другой пользователь" } : new List<string>());
                }

                var userListMessage = new ChatMessage
                {
                    Type = MessageType.UserList,
                    UserList = userList
                };

                SendMessageToClient(userListMessage, targetClient);
            }
            catch (Exception ex)
            {
                AddSystemMessage($"Ошибка отправки списка пользователей: {ex.Message}");
            }
        }

        private void BroadcastUserJoin(string username)
        {
            var message = new ChatMessage
            {
                Sender = username,
                Text = "присоединился к чату",
                Type = MessageType.System
            };
            BroadcastMessage(message);
        }

        private void BroadcastUserLeave(string username)
        {
            var message = new ChatMessage
            {
                Sender = username,
                Text = "покинул чат",
                Type = MessageType.System
            };
            BroadcastMessage(message);
        }

        private void BroadcastMessage(ChatMessage message)
        {
            lock (connectedClients)
            {
                foreach (var client in connectedClients.ToList())
                {
                    if (client.Connected)
                    {
                        SendMessageToClient(message, client);
                    }
                }
            }
        }

        private void SendMessageToClient(ChatMessage message, TcpClient targetClient)
        {
            try
            {
                string jsonMessage = JsonSerializer.Serialize(message);
                byte[] data = System.Text.Encoding.UTF8.GetBytes(jsonMessage);
                NetworkStream stream = targetClient.GetStream();
                stream.Write(data, 0, data.Length);
                stream.Flush();
            }
            catch (Exception)
            {
                // Игнорируем ошибки отправки - клиент может быть отключен
            }
        }

        // === КЛИЕНТСКАЯ ЧАСТЬ ===
        private void ConnectToServer(string ipAddress)
        {
            try
            {
                client = new TcpClient();
                client.Connect(ipAddress, port);
                clientStream = client.GetStream();

                // Отправляем информацию о себе
                var connectMessage = new ChatMessage
                {
                    Sender = currentUser,
                    Type = MessageType.UserConnect
                };
                SendMessageToClient(connectMessage, client);

                // Запускаем поток для прослушивания сообщений
                clientThread = new Thread(new ThreadStart(ListenToServer));
                clientThread.IsBackground = true;
                clientThread.Start();

                UpdateStatus($"Подключено к {ipAddress}");
                AddSystemMessage($"Успешно подключено к серверу {ipAddress}");

                SafeInvoke(() => {
                    if (connectButton != null) connectButton.Enabled = false;
                    if (disconnectButton != null) disconnectButton.Enabled = true;
                    if (ipTextBox != null) ipTextBox.Enabled = false;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}");
                UpdateStatus("Ошибка подключения");
            }
        }

        private void DisconnectFromServer()
        {
            try
            {
                client?.Close();
            }
            catch { }

            UpdateStatus("Отключено");
            AddSystemMessage("Отключено от сервера");

            SafeInvoke(() => {
                if (connectButton != null) connectButton.Enabled = true;
                if (disconnectButton != null) disconnectButton.Enabled = false;
                if (ipTextBox != null) ipTextBox.Enabled = true;
            });
        }

        private void ListenToServer()
        {
            byte[] buffer = new byte[4096];

            while (client != null && client.Connected)
            {
                try
                {
                    int bytesRead = clientStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    ProcessReceivedMessage(message);
                }
                catch (Exception ex)
                {
                    if (client != null && client.Connected)
                    {
                        AddSystemMessage($"Ошибка получения сообщения: {ex.Message}");
                    }
                    break;
                }
            }

            DisconnectFromServer();
        }

        private void ProcessReceivedMessage(string message)
        {
            try
            {
                var chatMessage = JsonSerializer.Deserialize<ChatMessage>(message);

                switch (chatMessage.Type)
                {
                    case MessageType.Text:
                        AddMessage(chatMessage.Sender, chatMessage.Text, Color.Black);
                        break;
                    case MessageType.Image:
                        AddImageMessage(chatMessage.Sender, chatMessage.ImageData);
                        break;
                    case MessageType.UserList:
                        UpdateUserList(chatMessage.UserList);
                        break;
                    case MessageType.System:
                        AddSystemMessage($"{chatMessage.Sender} {chatMessage.Text}");
                        break;
                    case MessageType.UserConnect:
                        AddSystemMessage($"{chatMessage.Sender} подключился к чату");
                        break;
                }
            }
            catch (Exception ex)
            {
                AddSystemMessage($"Ошибка обработки сообщения: {ex.Message}");
            }
        }

        private void AddImageMessage(string sender, byte[] imageData)
        {
            SafeInvoke(() =>
            {
                string timestamp = DateTime.Now.ToString("HH:mm:ss");
                string infoMessage = $"[{timestamp}] {sender} отправил изображение:";

                chatTextBox.SelectionStart = chatTextBox.TextLength;
                chatTextBox.SelectionColor = Color.Blue;
                chatTextBox.AppendText(infoMessage + Environment.NewLine);
                chatTextBox.AppendText($"[Изображение, размер: {imageData?.Length ?? 0} байт]" + Environment.NewLine);
            });
        }

        private void SendMessage()
        {
            if (string.IsNullOrWhiteSpace(messageTextBox.Text))
                return;

            string text = messageTextBox.Text.Trim();
            if (string.IsNullOrEmpty(text)) return;

            var chatMessage = new ChatMessage
            {
                Sender = currentUser,
                Text = text,
                Type = MessageType.Text,
                Timestamp = DateTime.Now
            };

            SendMessageToAll(chatMessage);
            AddMessage(currentUser, text, Color.DarkGreen);

            SafeInvoke(() => {
                if (messageTextBox != null)
                {
                    messageTextBox.Clear();
                    messageTextBox.Focus();
                }
            });
        }

        private void SendMessageToAll(ChatMessage chatMessage)
        {
            if (isServerRunning)
            {
                // Мы сервер - рассылаем всем клиентам
                BroadcastMessage(chatMessage);
            }
            else if (client != null && client.Connected)
            {
                // Мы клиент - отправляем только серверу
                SendMessageToClient(chatMessage, client);
            }
            else
            {
                AddSystemMessage("Нет подключения к серверу");
            }
        }

        private void AdjustLayout()
        {
            if (!isFormReady) return;

            SafeInvoke(() =>
            {
                // Подстраиваем ширину правой панели
                int rightPanelWidth = Math.Max(250, this.Width / 4);
                splitContainer1.SplitterDistance = this.Width - rightPanelWidth - splitContainer1.SplitterWidth;
            });
        }

        // === ОБРАБОТЧИКИ СОБЫТИЙ ===
        private void sendButton_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void messageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Проверяем нажатие Shift через Control.ModifierKeys
                if ((Control.ModifierKeys & Keys.Shift) != Keys.Shift)
                {
                    SendMessage();
                    e.Handled = true;
                }
            }
        }

        private void startServerButton_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void stopServerButton_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            string ipAddress = ipTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(ipAddress))
            {
                ConnectToServer(ipAddress);
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            DisconnectFromServer();
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);
                        var imageMessage = new ChatMessage
                        {
                            Sender = currentUser,
                            Type = MessageType.Image,
                            ImageData = imageData,
                            Timestamp = DateTime.Now
                        };

                        SendMessageToAll(imageMessage);
                        AddImageMessage(currentUser, imageData);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
                    }
                }
            }
        }

        private void emojiButton_Click(object sender, EventArgs e)
        {
            ContextMenuStrip emojiMenu = new ContextMenuStrip();
            string[] emojis = { "😊", "😂", "🤔", "👍", "❤️", "🔥", "🎉", "🙏" };

            foreach (string emoji in emojis)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(emoji);
                item.Click += (s, args) => {
                    messageTextBox.Text += emoji;
                    messageTextBox.Focus();
                };
                emojiMenu.Items.Add(item);
            }

            emojiMenu.Show(emojiButton, new Point(0, emojiButton.Height));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            isFormReady = false; // Предотвращаем дальнейшие вызовы Invoke
            StopServer();
            DisconnectFromServer();
            base.OnFormClosing(e);
        }
    }
}