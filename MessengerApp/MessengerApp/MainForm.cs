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
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace MessengerApp
{
    public partial class MainForm : Form
    {
        private TcpListener server;
        private Thread serverThread;
        private bool isServerRunning = false;
        private List<TcpClient> connectedClients = new List<TcpClient>();

        private TcpClient client;
        private NetworkStream clientStream;
        private Thread clientThread;

        private int port = 8080;
        private string currentUser;
        private bool isFormReady = false;

        private Dictionary<TcpClient, string> clientUsernames = new Dictionary<TcpClient, string>();

        // Цвета для нового дизайна
        private readonly Color primaryColor = Color.FromArgb(0, 122, 255); // Синий iOS
        private readonly Color secondaryColor = Color.FromArgb(52, 199, 89); // Зеленый iOS
        private readonly Color accentColor = Color.FromArgb(255, 149, 0); // Оранжевый iOS
        private readonly Color dangerColor = Color.FromArgb(255, 59, 48); // Красный iOS
        private readonly Color darkTextColor = Color.FromArgb(28, 28, 30);
        private readonly Color lightTextColor = Color.FromArgb(142, 142, 147);
        private readonly Color backgroundColor = Color.FromArgb(242, 242, 247);
        private readonly Color cardBackground = Color.White;

        public MainForm()
        {
            InitializeComponent();
            SetupCustomStyles();

            // Сначала показываем диалог имени
            ShowUsernameDialog();

            this.Load += (s, e) => {
                isFormReady = true;
                UpdateTitle(); // Обновляем заголовок после загрузки
                UpdateStatus("Не подключено");
                serverInfoLabel.Text = "Ваш IP: " + GetLocalIPAddress();

                ApplyRoundedCorners();
                LoadEmojiFont();

                AdjustLayout();
            };

            this.Resize += (s, e) => {
                AdjustLayout();
                ApplyRoundedCorners();
            };
        }

        private void SetupCustomStyles()
        {
            this.BackColor = backgroundColor;

            // Стилизация чата
            chatTextBox.BackColor = cardBackground;
            chatTextBox.BorderStyle = BorderStyle.None;

            // Стилизация списка пользователей
            userListBox.BackColor = cardBackground;
            userListBox.BorderStyle = BorderStyle.None;
            userListBox.DrawMode = DrawMode.OwnerDrawVariable;
            userListBox.DrawItem += UserListBox_DrawItem;

            // Стилизация полей ввода
            messageTextBox.BackColor = Color.FromArgb(242, 242, 247);
            ipTextBox.BackColor = Color.FromArgb(242, 242, 247);

            // Настройка шрифтов
            userNameLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void UserListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            bool isCurrentUser = false;
            if (e.Index == 0 && userListBox.Items.Count > 0)
            {
                var itemText = userListBox.Items[e.Index].ToString();
                isCurrentUser = itemText.Contains("(Вы)");
            }

            // Выбор цвета
            Color textColor = isCurrentUser ? primaryColor : darkTextColor;
            Color bgColor = e.State.HasFlag(DrawItemState.Selected) ?
                Color.FromArgb(230, 230, 230) : cardBackground;

            using (Brush brush = new SolidBrush(bgColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            // Рисуем аватар
            int avatarSize = 32;
            Rectangle avatarRect = new Rectangle(
                e.Bounds.Left + 10,
                e.Bounds.Top + (e.Bounds.Height - avatarSize) / 2,
                avatarSize,
                avatarSize
            );

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(avatarRect);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = isCurrentUser ? primaryColor : Color.FromArgb(200, 200, 205);
                    brush.SurroundColors = new[] { isCurrentUser ?
                        Color.FromArgb(100, 0, 122, 255) :
                        Color.FromArgb(100, 200, 200, 205) };
                    e.Graphics.FillEllipse(brush, avatarRect);
                }
            }

            // Инициалы пользователя
            string username = userListBox.Items[e.Index].ToString()
                .Replace(" (Вы)", "")
                .Replace("(Вы)", "");
            string initials = username.Length > 0 ? username[0].ToString().ToUpper() : "?";

            using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.White))
            {
                SizeF textSize = e.Graphics.MeasureString(initials, font);
                PointF textPos = new PointF(
                    avatarRect.Left + (avatarSize - textSize.Width) / 2,
                    avatarRect.Top + (avatarSize - textSize.Height) / 2
                );
                e.Graphics.DrawString(initials, font, textBrush, textPos);
            }

            // Имя пользователя
            Rectangle textRect = new Rectangle(
                avatarRect.Right + 12,
                e.Bounds.Top,
                e.Bounds.Width - avatarRect.Right - 20,
                e.Bounds.Height
            );

            using (Brush textBrush = new SolidBrush(textColor))
            using (Font font = new Font("Segoe UI", isCurrentUser ? 11 : 10,
                isCurrentUser ? FontStyle.Bold : FontStyle.Regular))
            {
                e.Graphics.DrawString(userListBox.Items[e.Index].ToString(),
                    font, textBrush, textRect,
                    new StringFormat { LineAlignment = StringAlignment.Center });
            }

            // Индикатор онлайн (только для других пользователей)
            if (!isCurrentUser)
            {
                int indicatorSize = 8;
                Rectangle indicatorRect = new Rectangle(
                    avatarRect.Right + 5,
                    avatarRect.Bottom - indicatorSize,
                    indicatorSize,
                    indicatorSize
                );

                using (Brush brush = new SolidBrush(secondaryColor))
                {
                    e.Graphics.FillEllipse(brush, indicatorRect);
                }
            }

            e.DrawFocusRectangle();
        }

        private void LoadEmojiFont()
        {
            try
            {
                emojiButton.Font = new Font("Segoe UI Emoji", 12);
            }
            catch
            {
                emojiButton.Font = new Font("Arial", 12);
            }
        }

        private void ApplyRoundedCorners()
        {
            if (!isFormReady) return;

            SetControlRoundRegion(sendButton, 8);
            SetControlRoundRegion(connectButton, 8);
            SetControlRoundRegion(disconnectButton, 8);
            SetControlRoundRegion(startServerButton, 8);
            SetControlRoundRegion(stopServerButton, 8);
            SetControlRoundRegion(changeNameButton, 8);
            SetControlRoundRegion(emojiButton, 6);
            SetControlRoundRegion(imageButton, 6);
            SetControlRoundRegion(messageInputPanel, 10);
            SetControlRoundRegion(inputContainer, 8);
        }

        private void SetControlRoundRegion(Control control, int radius)
        {
            if (control == null || control.Width == 0 || control.Height == 0) return;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }

        private void ShowUsernameDialog()
        {
            string tempUsername = "User_" + new Random().Next(1000, 9999);

            using (var dialog = new Form())
            {
                dialog.Text = "Добро пожаловать в МАКС";
                dialog.Width = 400;
                dialog.Height = 220;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.StartPosition = FormStartPosition.CenterScreen;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;
                dialog.BackColor = Color.White;
                dialog.Padding = new Padding(25);
                dialog.Font = new Font("Segoe UI", 10);

                var titleLabel = new Label()
                {
                    Text = "💬 Введите ваш никнейм",
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = primaryColor,
                    Dock = DockStyle.Top,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                var textBox = new TextBox()
                {
                    Dock = DockStyle.Top,
                    Height = 40,
                    Font = new Font("Segoe UI", 12),
                    Text = tempUsername,
                    Margin = new Padding(0, 20, 0, 20)
                };

                var buttonPanel = new Panel()
                {
                    Dock = DockStyle.Bottom,
                    Height = 50,
                    BackColor = Color.Transparent
                };

                var button = new Button()
                {
                    Text = "Продолжить",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = primaryColor,
                    ForeColor = Color.White,
                    Size = new Size(120, 40),
                    Anchor = AnchorStyles.None,
                    FlatStyle = FlatStyle.Flat,
                    DialogResult = DialogResult.OK
                };

                button.Click += (sender, e) => { dialog.Close(); };
                button.FlatAppearance.BorderSize = 0;

                buttonPanel.Controls.Add(button);
                button.Left = (buttonPanel.Width - button.Width) / 2;

                dialog.Controls.Add(titleLabel);
                dialog.Controls.Add(textBox);
                dialog.Controls.Add(buttonPanel);
                dialog.AcceptButton = button;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentUser = string.IsNullOrWhiteSpace(textBox.Text) ?
                        tempUsername : textBox.Text.Trim();
                }
                else
                {
                    currentUser = tempUsername;
                }
            }
        }

        private void UpdateTitle()
        {
            this.Text = $"МАКС - {currentUser}";
            userNameLabel.Text = currentUser;
        }

        private void ChangeUsername(string newUsername)
        {
            if (string.IsNullOrWhiteSpace(newUsername))
            {
                MessageBox.Show("Никнейм не может быть пустым!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newUsername.Length > 20)
            {
                MessageBox.Show("Никнейм не может быть длиннее 20 символов!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldUsername = currentUser;
            currentUser = newUsername.Trim();
            UpdateTitle();

            UpdateUserList();

            var renameMessage = new ChatMessage
            {
                Sender = oldUsername,
                Type = MessageType.UserRename,
                OldUsername = oldUsername,
                NewUsername = currentUser,
                Text = $"{oldUsername} сменил имя на {currentUser}"
            };

            SendMessageToAll(renameMessage);
            AddSystemMessage($"Вы сменили имя на {currentUser}");
        }

        private void changeNameButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new Form())
            {
                dialog.Text = "Сменить никнейм";
                dialog.Width = 400;
                dialog.Height = 200;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;
                dialog.BackColor = Color.White;
                dialog.Padding = new Padding(25);
                dialog.Font = new Font("Segoe UI", 10);

                var label = new Label()
                {
                    Text = "✏️ Новый никнейм:",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = primaryColor,
                    Dock = DockStyle.Top,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                var textBox = new TextBox()
                {
                    Dock = DockStyle.Top,
                    Height = 40,
                    Font = new Font("Segoe UI", 11),
                    Text = currentUser,
                    Margin = new Padding(0, 10, 0, 20)
                };

                var buttonPanel = new Panel()
                {
                    Dock = DockStyle.Bottom,
                    Height = 50,
                    BackColor = Color.Transparent
                };

                var okButton = new Button()
                {
                    Text = "Сменить",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = primaryColor,
                    ForeColor = Color.White,
                    Size = new Size(120, 40),
                    DialogResult = DialogResult.OK,
                    FlatStyle = FlatStyle.Flat
                };

                var cancelButton = new Button()
                {
                    Text = "Отмена",
                    Font = new Font("Segoe UI", 10),
                    BackColor = Color.FromArgb(200, 200, 205),
                    ForeColor = Color.White,
                    Size = new Size(120, 40),
                    DialogResult = DialogResult.Cancel,
                    FlatStyle = FlatStyle.Flat
                };

                okButton.FlatAppearance.BorderSize = 0;
                cancelButton.FlatAppearance.BorderSize = 0;

                okButton.Click += (s, ev) => { dialog.Close(); };
                cancelButton.Click += (s, ev) => { dialog.Close(); };

                buttonPanel.Controls.Add(cancelButton);
                buttonPanel.Controls.Add(okButton);
                cancelButton.Location = new Point(140, 5);
                okButton.Location = new Point(270, 5);

                dialog.Controls.Add(label);
                dialog.Controls.Add(textBox);
                dialog.Controls.Add(buttonPanel);
                dialog.AcceptButton = okButton;
                dialog.CancelButton = cancelButton;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ChangeUsername(textBox.Text);
                }
            }
        }

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

        private void AddMessage(string sender, string text, Color color, bool isSystem = false)
        {
            if (!isFormReady) return;

            SafeInvoke(() =>
            {
                string timestamp = DateTime.Now.ToString("HH:mm");
                string formattedMessage;

                if (isSystem)
                {
                    formattedMessage = $"[{timestamp}] {text}";
                }
                else
                {
                    formattedMessage = $"[{timestamp}] {sender}: {text}";
                }

                chatTextBox.SelectionStart = chatTextBox.TextLength;
                chatTextBox.SelectionColor = isSystem ? lightTextColor : color;
                chatTextBox.AppendText(formattedMessage + Environment.NewLine);
                chatTextBox.ScrollToCaret();
            });
        }

        private void AddSystemMessage(string text)
        {
            AddMessage("", text, Color.Gray, true);
        }

        private void UpdateStatus(string status)
        {
            SafeInvoke(() =>
            {
                if (statusLabel != null && !statusLabel.IsDisposed)
                {
                    statusLabel.Text = status;

                    if (status.Contains("Не подключено") || status.Contains("Отключено") || status.Contains("Ошибка"))
                    {
                        statusLabel.ForeColor = dangerColor;
                    }
                    else if (status.Contains("Подключено"))
                    {
                        statusLabel.ForeColor = secondaryColor;
                    }
                    else if (status.Contains("Сервер"))
                    {
                        statusLabel.ForeColor = primaryColor;
                    }
                    else
                    {
                        statusLabel.ForeColor = lightTextColor;
                    }
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

                    userListBox.Invalidate(); // Перерисовываем с новыми стилями
                    onlineCountLabel.Text = $"Онлайн: {userListBox.Items.Count}";
                }
            });
        }

        private string GetNetworkInfo()
        {
            string result = "Доступные IP-адреса:\n\n";

            try
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface ni in interfaces)
                {
                    if (ni.OperationalStatus == OperationalStatus.Up &&
                        (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                         ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet))
                    {
                        IPInterfaceProperties ipProps = ni.GetIPProperties();
                        foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                result += $"• {ip.Address}\n";
                            }
                        }
                    }
                }

                result += $"\nДля подключения используйте любой из этих IP-адресов\nи порт: {port}";
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
            }
            return "127.0.0.1";
        }

        private void StartServer()
        {
            try
            {
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                isServerRunning = true;
                serverThread = new Thread(new ThreadStart(ListenForClients));
                serverThread.IsBackground = true;
                serverThread.Start();

                string networkInfo = GetNetworkInfo();

                UpdateStatus($"Сервер запущен на порту {port}");
                AddSystemMessage($"✅ Сервер успешно запущен!\n{networkInfo}");

                SafeInvoke(() => {
                    startServerButton.Enabled = false;
                    stopServerButton.Enabled = true;
                    startServerButton.BackColor = Color.FromArgb(200, 200, 205);
                    stopServerButton.BackColor = dangerColor;
                    ApplyRoundedCorners();
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

            lock (connectedClients)
            {
                foreach (var client in connectedClients.ToList())
                {
                    try { client.Close(); } catch { }
                }
                connectedClients.Clear();
                clientUsernames.Clear();
            }

            try { server?.Stop(); } catch { }

            SafeInvoke(() => {
                startServerButton.Enabled = true;
                stopServerButton.Enabled = false;
                startServerButton.BackColor = primaryColor;
                stopServerButton.BackColor = Color.FromArgb(200, 200, 205);
                ApplyRoundedCorners();
            });

            UpdateStatus("Сервер остановлен");
            AddSystemMessage("⏹️ Сервер остановлен");
            UpdateUserList(); // Очищаем список пользователей
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
                        AddSystemMessage($"⚠️ Ошибка принятия подключения: {ex.Message}");
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

                byte[] buffer = new byte[4096];
                int bytesRead = clientStream.Read(buffer, 0, buffer.Length);
                string userInfo = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                var userMessage = JsonSerializer.Deserialize<ChatMessage>(userInfo);
                clientUser = userMessage.Sender;

                lock (clientUsernames)
                {
                    clientUsernames[tcpClient] = clientUser;
                }

                AddSystemMessage($"✅ {clientUser} подключился");

                SendUserList(tcpClient);
                BroadcastUserJoin(clientUser);

                while (tcpClient.Connected && isServerRunning)
                {
                    bytesRead = clientStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string message = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    ProcessReceivedMessage(message, tcpClient);
                }
            }
            catch (Exception ex)
            {
                AddSystemMessage($"⚠️ Ошибка обработки клиента {clientUser}: {ex.Message}");
            }
            finally
            {
                lock (connectedClients)
                {
                    connectedClients.Remove(tcpClient);
                }
                lock (clientUsernames)
                {
                    clientUsernames.Remove(tcpClient);
                }
                try { tcpClient.Close(); } catch { }

                if (!string.IsNullOrEmpty(clientUser))
                {
                    AddSystemMessage($"❌ {clientUser} отключился");
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
                    userList.AddRange(GetConnectedUsernames());
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
                AddSystemMessage($"⚠️ Ошибка отправки списка пользователей: {ex.Message}");
            }
        }

        private List<string> GetConnectedUsernames()
        {
            var usernames = new List<string>();
            lock (clientUsernames)
            {
                usernames.AddRange(clientUsernames.Values);
            }
            return usernames;
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
            }
        }

        private void ConnectToServer(string ipAddress)
        {
            try
            {
                client = new TcpClient();
                client.Connect(ipAddress, port);
                clientStream = client.GetStream();

                var connectMessage = new ChatMessage
                {
                    Sender = currentUser,
                    Type = MessageType.UserConnect
                };
                SendMessageToClient(connectMessage, client);

                clientThread = new Thread(new ThreadStart(ListenToServer));
                clientThread.IsBackground = true;
                clientThread.Start();

                UpdateStatus($"Подключено к {ipAddress}");
                AddSystemMessage($"✅ Успешно подключено к серверу {ipAddress}");

                SafeInvoke(() => {
                    connectButton.Enabled = false;
                    disconnectButton.Enabled = true;
                    ipTextBox.Enabled = false;
                    connectButton.BackColor = Color.FromArgb(200, 200, 205);
                    disconnectButton.BackColor = dangerColor;
                    ApplyRoundedCorners();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            AddSystemMessage("❌ Отключено от сервера");

            SafeInvoke(() => {
                connectButton.Enabled = true;
                disconnectButton.Enabled = false;
                ipTextBox.Enabled = true;
                connectButton.BackColor = secondaryColor;
                disconnectButton.BackColor = Color.FromArgb(200, 200, 205);
                ApplyRoundedCorners();
            });

            UpdateUserList(); // Очищаем список пользователей
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
                        AddSystemMessage($"⚠️ Ошибка получения сообщения: {ex.Message}");
                    }
                    break;
                }
            }

            DisconnectFromServer();
        }

        private void ProcessReceivedMessage(string message, TcpClient sourceClient = null)
        {
            try
            {
                var chatMessage = JsonSerializer.Deserialize<ChatMessage>(message);

                switch (chatMessage.Type)
                {
                    case MessageType.Text:
                        AddMessage(chatMessage.Sender, chatMessage.Text, darkTextColor);
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
                        AddSystemMessage($"✅ {chatMessage.Sender} подключился к чату");
                        break;
                    case MessageType.UserRename:
                        if (sourceClient != null)
                        {
                            lock (clientUsernames)
                            {
                                if (clientUsernames.ContainsKey(sourceClient))
                                {
                                    clientUsernames[sourceClient] = chatMessage.NewUsername;
                                }
                            }
                            BroadcastUserList();
                        }
                        AddSystemMessage($"✏️ {chatMessage.OldUsername} сменил имя на {chatMessage.NewUsername}");
                        break;
                }
            }
            catch (Exception ex)
            {
                AddSystemMessage($"⚠️ Ошибка обработки сообщения: {ex.Message}");
            }
        }

        private void BroadcastUserList()
        {
            var userList = new List<string> { currentUser };
            userList.AddRange(GetConnectedUsernames());

            var userListMessage = new ChatMessage
            {
                Type = MessageType.UserList,
                UserList = userList
            };

            BroadcastMessage(userListMessage);
        }

        private void AddImageMessage(string sender, byte[] imageData)
        {
            SafeInvoke(() =>
            {
                string timestamp = DateTime.Now.ToString("HH:mm");
                string infoMessage = $"[{timestamp}] {sender} отправил изображение:";

                chatTextBox.SelectionStart = chatTextBox.TextLength;
                chatTextBox.SelectionColor = primaryColor;
                chatTextBox.AppendText(infoMessage + Environment.NewLine);
                chatTextBox.AppendText($"[🖼️ Изображение, размер: {imageData?.Length ?? 0} байт]" + Environment.NewLine);
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
            AddMessage(currentUser, text, primaryColor);

            SafeInvoke(() => {
                messageTextBox.Clear();
                messageTextBox.Focus();
            });
        }

        private void SendMessageToAll(ChatMessage chatMessage)
        {
            if (isServerRunning)
            {
                BroadcastMessage(chatMessage);
            }
            else if (client != null && client.Connected)
            {
                SendMessageToClient(chatMessage, client);
            }
            else
            {
                AddSystemMessage("❌ Нет подключения к серверу");
            }
        }

        private void AdjustLayout()
        {
            if (!isFormReady) return;

            SafeInvoke(() =>
            {
                // Адаптивная ширина правой панели
                int rightPanelWidth = Math.Min(350, Math.Max(280, this.Width / 4));
                splitContainer1.SplitterDistance = this.Width - rightPanelWidth - splitContainer1.SplitterWidth;

                // Адаптивные отступы для левой панели
                int leftPadding = Math.Max(10, this.Width / 100);
                chatContainer.Padding = new Padding(leftPadding);
                messageInputPanel.Padding = new Padding(leftPadding);

                // Адаптивные отступы для правой панели
                int rightPadding = Math.Max(10, rightPanelWidth / 20);
                userListContainer.Padding = new Padding(rightPadding);
                connectionContainer.Padding = new Padding(rightPadding);
                serverContainer.Padding = new Padding(rightPadding);

                // Убедимся, что элементы управления имеют правильные размеры
                int containerWidth = rightPanelWidth - 2 * rightPadding;

                // Настройка ширины текстового поля IP
                if (ipTextBox != null && connectionContainer != null)
                {
                    ipTextBox.Width = containerWidth - 40;
                }

                // Настройка ширины кнопок подключения
                if (connectButton != null && disconnectButton != null)
                {
                    int buttonWidth = (containerWidth - 50) / 2;
                    connectButton.Width = buttonWidth;
                    disconnectButton.Width = buttonWidth;
                    disconnectButton.Left = connectButton.Right + 10;
                }

                // Настройка ширины кнопок сервера
                if (startServerButton != null && stopServerButton != null)
                {
                    int serverButtonWidth = (containerWidth - 50) / 2;
                    startServerButton.Width = serverButtonWidth;
                    stopServerButton.Width = serverButtonWidth;
                    stopServerButton.Left = startServerButton.Right + 10;
                }

                // Настройка ширины поля ввода сообщения
                if (messageTextBox != null && sendButton != null)
                {
                    messageTextBox.Width = inputContainer.Width - sendButton.Width - emojiButton.Width - imageButton.Width - 40;
                }
            });
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void messageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
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
                openFileDialog.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Все файлы|*.*";
                openFileDialog.Title = "Выберите изображение";
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
                        MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void emojiButton_Click(object sender, EventArgs e)
        {
            ContextMenuStrip emojiMenu = new ContextMenuStrip();
            emojiMenu.BackColor = cardBackground;
            emojiMenu.ForeColor = darkTextColor;
            emojiMenu.Font = new Font("Segoe UI Emoji", 12);

            string[] emojis = { "😊", "😂", "🤔", "👍", "❤️", "🔥", "🎉", "🙏", "😍", "🥳", "😎", "🤯", "👌", "😢", "🤦", "🎯", "💡", "🚀" };

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
            isFormReady = false;
            StopServer();
            DisconnectFromServer();
            base.OnFormClosing(e);
        }
    }
}