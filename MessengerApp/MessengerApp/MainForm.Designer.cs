namespace MessengerApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Основные контейнеры
        private SplitContainer splitContainer1;
        private Panel leftPanel;
        private Panel rightPanel;

        // Левая панель - чат
        private Panel topPanel;
        private Label titleLabel;
        private Label userNameLabel;
        private Button changeNameButton;
        private Panel chatContainer;
        private RichTextBox chatTextBox;
        private Panel messageInputPanel;
        private Panel inputContainer;
        private TextBox messageTextBox;
        private Button sendButton;
        private Button emojiButton;
        private Button imageButton;

        // Правая панель - управление
        private Panel serverContainer;
        private Label serverTitleLabel;
        private Button startServerButton;
        private Button stopServerButton;
        private Label serverInfoLabel;

        private Panel connectionContainer;
        private Label connectionTitleLabel;
        private Label ipLabel;
        private TextBox ipTextBox;
        private Button connectButton;
        private Button disconnectButton;
        private Label statusLabel;

        private Panel userListContainer;
        private Label usersTitleLabel;
        private Label onlineCountLabel;
        private ListBox userListBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            leftPanel = new Panel();
            chatContainer = new Panel();
            chatTextBox = new RichTextBox();
            messageInputPanel = new Panel();
            inputContainer = new Panel();
            messageTextBox = new TextBox();
            emojiButton = new Button();
            imageButton = new Button();
            sendButton = new Button();
            topPanel = new Panel();
            titleLabel = new Label();
            userNameLabel = new Label();
            changeNameButton = new Button();
            rightPanel = new Panel();
            userListContainer = new Panel();
            usersTitleLabel = new Label();
            onlineCountLabel = new Label();
            userListBox = new ListBox();
            connectionContainer = new Panel();
            connectionTitleLabel = new Label();
            ipLabel = new Label();
            ipTextBox = new TextBox();
            connectButton = new Button();
            disconnectButton = new Button();
            statusLabel = new Label();
            serverContainer = new Panel();
            serverTitleLabel = new Label();
            startServerButton = new Button();
            stopServerButton = new Button();
            serverInfoLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            leftPanel.SuspendLayout();
            chatContainer.SuspendLayout();
            messageInputPanel.SuspendLayout();
            inputContainer.SuspendLayout();
            topPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            userListContainer.SuspendLayout();
            connectionContainer.SuspendLayout();
            serverContainer.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(242, 242, 247);
            splitContainer1.Panel1.Controls.Add(leftPanel);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(242, 242, 247);
            splitContainer1.Panel2.Controls.Add(rightPanel);
            splitContainer1.Panel2.Padding = new Padding(10);
            splitContainer1.Size = new Size(1100, 700);
            splitContainer1.SplitterDistance = 739;
            splitContainer1.SplitterWidth = 1;
            splitContainer1.TabIndex = 0;
            // 
            // leftPanel
            // 
            leftPanel.BackColor = Color.Transparent;
            leftPanel.Controls.Add(chatContainer);
            leftPanel.Controls.Add(messageInputPanel);
            leftPanel.Controls.Add(topPanel);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Margin = new Padding(0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(739, 700);
            leftPanel.TabIndex = 0;
            // 
            // chatContainer
            // 
            chatContainer.BackColor = Color.White;
            chatContainer.Controls.Add(chatTextBox);
            chatContainer.Dock = DockStyle.Fill;
            chatContainer.Location = new Point(0, 70);
            chatContainer.Margin = new Padding(0);
            chatContainer.Name = "chatContainer";
            chatContainer.Padding = new Padding(15);
            chatContainer.Size = new Size(739, 550);
            chatContainer.TabIndex = 1;
            // 
            // chatTextBox
            // 
            chatTextBox.BackColor = Color.White;
            chatTextBox.BorderStyle = BorderStyle.None;
            chatTextBox.Dock = DockStyle.Fill;
            chatTextBox.Font = new Font("Segoe UI", 11F);
            chatTextBox.ForeColor = Color.FromArgb(28, 28, 30);
            chatTextBox.Location = new Point(15, 15);
            chatTextBox.Margin = new Padding(0);
            chatTextBox.Name = "chatTextBox";
            chatTextBox.ReadOnly = true;
            chatTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            chatTextBox.Size = new Size(709, 520);
            chatTextBox.TabIndex = 0;
            chatTextBox.Text = "";
            // 
            // messageInputPanel
            // 
            messageInputPanel.BackColor = Color.White;
            messageInputPanel.Controls.Add(inputContainer);
            messageInputPanel.Dock = DockStyle.Bottom;
            messageInputPanel.Location = new Point(0, 620);
            messageInputPanel.Margin = new Padding(0);
            messageInputPanel.Name = "messageInputPanel";
            messageInputPanel.Padding = new Padding(15);
            messageInputPanel.Size = new Size(739, 80);
            messageInputPanel.TabIndex = 2;
            // 
            // inputContainer
            // 
            inputContainer.BackColor = Color.FromArgb(242, 242, 247);
            inputContainer.Controls.Add(messageTextBox);
            inputContainer.Controls.Add(emojiButton);
            inputContainer.Controls.Add(imageButton);
            inputContainer.Controls.Add(sendButton);
            inputContainer.Dock = DockStyle.Fill;
            inputContainer.Location = new Point(15, 15);
            inputContainer.Margin = new Padding(0);
            inputContainer.Name = "inputContainer";
            inputContainer.Padding = new Padding(10);
            inputContainer.Size = new Size(709, 50);
            inputContainer.TabIndex = 0;
            // 
            // messageTextBox
            // 
            messageTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            messageTextBox.BackColor = Color.White;
            messageTextBox.BorderStyle = BorderStyle.None;
            messageTextBox.Font = new Font("Segoe UI", 11F);
            messageTextBox.ForeColor = Color.FromArgb(28, 28, 30);
            messageTextBox.Location = new Point(10, 10);
            messageTextBox.Margin = new Padding(0);
            messageTextBox.Multiline = true;
            messageTextBox.Name = "messageTextBox";
            messageTextBox.PlaceholderText = "Напишите сообщение...";
            messageTextBox.Size = new Size(456, 30);
            messageTextBox.TabIndex = 0;
            messageTextBox.KeyPress += messageTextBox_KeyPress;
            // 
            // emojiButton
            // 
            emojiButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            emojiButton.BackColor = Color.FromArgb(0, 122, 255);
            emojiButton.FlatAppearance.BorderSize = 0;
            emojiButton.FlatStyle = FlatStyle.Flat;
            emojiButton.Font = new Font("Segoe UI Emoji", 12F);
            emojiButton.ForeColor = Color.White;
            emojiButton.Location = new Point(476, 10);
            emojiButton.Margin = new Padding(10, 0, 5, 0);
            emojiButton.Name = "emojiButton";
            emojiButton.Size = new Size(40, 30);
            emojiButton.TabIndex = 1;
            emojiButton.Text = "😊";
            emojiButton.UseVisualStyleBackColor = false;
            emojiButton.Click += emojiButton_Click;
            // 
            // imageButton
            // 
            imageButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            imageButton.BackColor = Color.FromArgb(0, 122, 255);
            imageButton.FlatAppearance.BorderSize = 0;
            imageButton.FlatStyle = FlatStyle.Flat;
            imageButton.Font = new Font("Segoe UI", 12F);
            imageButton.ForeColor = Color.White;
            imageButton.Location = new Point(526, 10);
            imageButton.Margin = new Padding(5, 0, 5, 0);
            imageButton.Name = "imageButton";
            imageButton.Size = new Size(40, 30);
            imageButton.TabIndex = 2;
            imageButton.Text = "📷";
            imageButton.UseVisualStyleBackColor = false;
            imageButton.Click += imageButton_Click;
            // 
            // sendButton
            // 
            sendButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sendButton.BackColor = Color.FromArgb(0, 122, 255);
            sendButton.FlatAppearance.BorderSize = 0;
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            sendButton.ForeColor = Color.White;
            sendButton.Location = new Point(576, 10);
            sendButton.Margin = new Padding(5, 0, 0, 0);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(120, 30);
            sendButton.TabIndex = 3;
            sendButton.Text = "Отправить";
            sendButton.UseVisualStyleBackColor = false;
            sendButton.Click += sendButton_Click;
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.White;
            topPanel.Controls.Add(titleLabel);
            topPanel.Controls.Add(userNameLabel);
            topPanel.Controls.Add(changeNameButton);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(0);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(15, 10, 15, 10);
            topPanel.Size = new Size(739, 70);
            topPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Left;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(0, 122, 255);
            titleLabel.Location = new Point(215, 10);
            titleLabel.Margin = new Padding(0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(81, 50);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "💬 МАКС";
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // userNameLabel
            // 
            userNameLabel.Dock = DockStyle.Left;
            userNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            userNameLabel.ForeColor = Color.FromArgb(28, 28, 30);
            userNameLabel.Location = new Point(15, 10);
            userNameLabel.Margin = new Padding(0);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(200, 50);
            userNameLabel.TabIndex = 1;
            userNameLabel.Text = "User_1234";
            userNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // changeNameButton
            // 
            changeNameButton.BackColor = Color.FromArgb(0, 122, 255);
            changeNameButton.Dock = DockStyle.Right;
            changeNameButton.FlatAppearance.BorderSize = 0;
            changeNameButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 102, 214);
            changeNameButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 102, 214);
            changeNameButton.FlatStyle = FlatStyle.Flat;
            changeNameButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            changeNameButton.ForeColor = Color.White;
            changeNameButton.Location = new Point(554, 10);
            changeNameButton.Margin = new Padding(0);
            changeNameButton.Name = "changeNameButton";
            changeNameButton.Size = new Size(170, 50);
            changeNameButton.TabIndex = 2;
            changeNameButton.Text = "✏️ Сменить имя";
            changeNameButton.UseVisualStyleBackColor = false;
            changeNameButton.Click += changeNameButton_Click;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.Transparent;
            rightPanel.Controls.Add(userListContainer);
            rightPanel.Controls.Add(connectionContainer);
            rightPanel.Controls.Add(serverContainer);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(10, 10);
            rightPanel.Margin = new Padding(0);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(340, 680);
            rightPanel.TabIndex = 0;
            // 
            // userListContainer
            // 
            userListContainer.BackColor = Color.White;
            userListContainer.Controls.Add(usersTitleLabel);
            userListContainer.Controls.Add(onlineCountLabel);
            userListContainer.Controls.Add(userListBox);
            userListContainer.Dock = DockStyle.Fill;
            userListContainer.Location = new Point(0, 320);
            userListContainer.Margin = new Padding(0);
            userListContainer.Name = "userListContainer";
            userListContainer.Padding = new Padding(15);
            userListContainer.Size = new Size(340, 360);
            userListContainer.TabIndex = 2;
            // 
            // usersTitleLabel
            // 
            usersTitleLabel.Dock = DockStyle.Top;
            usersTitleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            usersTitleLabel.ForeColor = Color.FromArgb(28, 28, 30);
            usersTitleLabel.Location = new Point(15, 35);
            usersTitleLabel.Margin = new Padding(0);
            usersTitleLabel.Name = "usersTitleLabel";
            usersTitleLabel.Size = new Size(310, 25);
            usersTitleLabel.TabIndex = 0;
            usersTitleLabel.Text = "👥 Пользователи";
            usersTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // onlineCountLabel
            // 
            onlineCountLabel.Dock = DockStyle.Top;
            onlineCountLabel.Font = new Font("Segoe UI", 9F);
            onlineCountLabel.ForeColor = Color.FromArgb(142, 142, 147);
            onlineCountLabel.Location = new Point(15, 15);
            onlineCountLabel.Margin = new Padding(0);
            onlineCountLabel.Name = "onlineCountLabel";
            onlineCountLabel.Size = new Size(310, 20);
            onlineCountLabel.TabIndex = 2;
            onlineCountLabel.Text = "Онлайн: 1";
            onlineCountLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // userListBox
            // 
            userListBox.BackColor = Color.White;
            userListBox.BorderStyle = BorderStyle.None;
            userListBox.Dock = DockStyle.Fill;
            userListBox.Font = new Font("Segoe UI", 11F);
            userListBox.ForeColor = Color.FromArgb(28, 28, 30);
            userListBox.ItemHeight = 25;
            userListBox.Location = new Point(15, 15);
            userListBox.Margin = new Padding(0);
            userListBox.Name = "userListBox";
            userListBox.Size = new Size(310, 330);
            userListBox.TabIndex = 1;
            // 
            // connectionContainer
            // 
            connectionContainer.BackColor = Color.White;
            connectionContainer.Controls.Add(connectionTitleLabel);
            connectionContainer.Controls.Add(ipLabel);
            connectionContainer.Controls.Add(ipTextBox);
            connectionContainer.Controls.Add(connectButton);
            connectionContainer.Controls.Add(disconnectButton);
            connectionContainer.Controls.Add(statusLabel);
            connectionContainer.Dock = DockStyle.Top;
            connectionContainer.Location = new Point(0, 160);
            connectionContainer.Margin = new Padding(0);
            connectionContainer.Name = "connectionContainer";
            connectionContainer.Padding = new Padding(15);
            connectionContainer.Size = new Size(340, 160);
            connectionContainer.TabIndex = 1;
            // 
            // connectionTitleLabel
            // 
            connectionTitleLabel.Dock = DockStyle.Top;
            connectionTitleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            connectionTitleLabel.ForeColor = Color.FromArgb(28, 28, 30);
            connectionTitleLabel.Location = new Point(15, 15);
            connectionTitleLabel.Margin = new Padding(0);
            connectionTitleLabel.Name = "connectionTitleLabel";
            connectionTitleLabel.Size = new Size(310, 25);
            connectionTitleLabel.TabIndex = 0;
            connectionTitleLabel.Text = "🔌 Подключение";
            connectionTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ipLabel
            // 
            ipLabel.Font = new Font("Segoe UI", 9F);
            ipLabel.ForeColor = Color.FromArgb(142, 142, 147);
            ipLabel.Location = new Point(15, 50);
            ipLabel.Margin = new Padding(0);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new Size(316, 25);
            ipLabel.TabIndex = 1;
            ipLabel.Text = "IP сервера:";
            ipLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ipTextBox
            // 
            ipTextBox.BackColor = Color.FromArgb(242, 242, 247);
            ipTextBox.BorderStyle = BorderStyle.None;
            ipTextBox.Font = new Font("Segoe UI", 11F);
            ipTextBox.ForeColor = Color.FromArgb(28, 28, 30);
            ipTextBox.Location = new Point(15, 80);
            ipTextBox.Margin = new Padding(0);
            ipTextBox.Name = "ipTextBox";
            ipTextBox.Size = new Size(316, 25);
            ipTextBox.TabIndex = 2;
            ipTextBox.Text = "127.0.0.1";
            // 
            // connectButton
            // 
            connectButton.BackColor = Color.FromArgb(52, 199, 89);
            connectButton.FlatAppearance.BorderSize = 0;
            connectButton.FlatStyle = FlatStyle.Flat;
            connectButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            connectButton.ForeColor = Color.White;
            connectButton.Location = new Point(15, 115);
            connectButton.Margin = new Padding(0);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(159, 35);
            connectButton.TabIndex = 3;
            connectButton.Text = "Подключиться";
            connectButton.UseVisualStyleBackColor = false;
            connectButton.Click += connectButton_Click;
            // 
            // disconnectButton
            // 
            disconnectButton.BackColor = Color.FromArgb(255, 59, 48);
            disconnectButton.Enabled = false;
            disconnectButton.FlatAppearance.BorderSize = 0;
            disconnectButton.FlatStyle = FlatStyle.Flat;
            disconnectButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            disconnectButton.ForeColor = Color.White;
            disconnectButton.Location = new Point(175, 115);
            disconnectButton.Margin = new Padding(0);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new Size(150, 35);
            disconnectButton.TabIndex = 4;
            disconnectButton.Text = "Отключиться";
            disconnectButton.UseVisualStyleBackColor = false;
            disconnectButton.Click += disconnectButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            statusLabel.ForeColor = Color.FromArgb(255, 59, 48);
            statusLabel.Location = new Point(15, 155);
            statusLabel.Margin = new Padding(0);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(316, 20);
            statusLabel.TabIndex = 5;
            statusLabel.Text = "Не подключено";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // serverContainer
            // 
            serverContainer.BackColor = Color.White;
            serverContainer.Controls.Add(serverTitleLabel);
            serverContainer.Controls.Add(startServerButton);
            serverContainer.Controls.Add(stopServerButton);
            serverContainer.Controls.Add(serverInfoLabel);
            serverContainer.Dock = DockStyle.Top;
            serverContainer.Location = new Point(0, 0);
            serverContainer.Margin = new Padding(0);
            serverContainer.Name = "serverContainer";
            serverContainer.Padding = new Padding(15);
            serverContainer.Size = new Size(340, 160);
            serverContainer.TabIndex = 0;
            // 
            // serverTitleLabel
            // 
            serverTitleLabel.Dock = DockStyle.Top;
            serverTitleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            serverTitleLabel.ForeColor = Color.FromArgb(28, 28, 30);
            serverTitleLabel.Location = new Point(15, 15);
            serverTitleLabel.Margin = new Padding(0);
            serverTitleLabel.Name = "serverTitleLabel";
            serverTitleLabel.Size = new Size(310, 25);
            serverTitleLabel.TabIndex = 0;
            serverTitleLabel.Text = "🖥️ Сервер";
            serverTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // startServerButton
            // 
            startServerButton.BackColor = Color.FromArgb(0, 122, 255);
            startServerButton.FlatAppearance.BorderSize = 0;
            startServerButton.FlatStyle = FlatStyle.Flat;
            startServerButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            startServerButton.ForeColor = Color.White;
            startServerButton.Location = new Point(15, 50);
            startServerButton.Margin = new Padding(0);
            startServerButton.Name = "startServerButton";
            startServerButton.Size = new Size(150, 35);
            startServerButton.TabIndex = 1;
            startServerButton.Text = "Запустить";
            startServerButton.UseVisualStyleBackColor = false;
            startServerButton.Click += startServerButton_Click;
            // 
            // stopServerButton
            // 
            stopServerButton.BackColor = Color.FromArgb(142, 142, 147);
            stopServerButton.Enabled = false;
            stopServerButton.FlatAppearance.BorderSize = 0;
            stopServerButton.FlatStyle = FlatStyle.Flat;
            stopServerButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            stopServerButton.ForeColor = Color.White;
            stopServerButton.Location = new Point(170, 50);
            stopServerButton.Margin = new Padding(0);
            stopServerButton.Name = "stopServerButton";
            stopServerButton.Size = new Size(150, 35);
            stopServerButton.TabIndex = 2;
            stopServerButton.Text = "Остановить";
            stopServerButton.UseVisualStyleBackColor = false;
            stopServerButton.Click += stopServerButton_Click;
            // 
            // serverInfoLabel
            // 
            serverInfoLabel.Font = new Font("Segoe UI", 9F);
            serverInfoLabel.ForeColor = Color.FromArgb(142, 142, 147);
            serverInfoLabel.Location = new Point(15, 95);
            serverInfoLabel.Margin = new Padding(0);
            serverInfoLabel.Name = "serverInfoLabel";
            serverInfoLabel.Size = new Size(316, 50);
            serverInfoLabel.TabIndex = 3;
            serverInfoLabel.Text = "🌐 Ваш IP: загрузка...";
            // 
            // MainForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1100, 700);
            Controls.Add(splitContainer1);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(900, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "МАКС - Мессенджер";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            chatContainer.ResumeLayout(false);
            messageInputPanel.ResumeLayout(false);
            inputContainer.ResumeLayout(false);
            inputContainer.PerformLayout();
            topPanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            userListContainer.ResumeLayout(false);
            connectionContainer.ResumeLayout(false);
            connectionContainer.PerformLayout();
            serverContainer.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}