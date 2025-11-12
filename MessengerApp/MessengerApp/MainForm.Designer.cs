namespace MessengerApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private RichTextBox chatTextBox;
        private TextBox messageTextBox;
        private Button sendButton;
        private Button imageButton;
        private Button emojiButton;
        private ListBox userListBox;
        private TextBox ipTextBox;
        private Button connectButton;
        private Button startServerButton;
        private Button stopServerButton;
        private Button disconnectButton;
        private Label statusLabel;
        private Label ipLabel;
        public Label serverInfoLabel;
        private SplitContainer splitContainer1;
        private Panel bottomPanel;
        private Panel serverPanel;
        private Panel clientPanel;
        private TableLayoutPanel bottomTableLayout;

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
            chatPanel = new Panel();
            chatTextBox = new RichTextBox();
            bottomPanel = new Panel();
            bottomTableLayout = new TableLayoutPanel();
            messageTextBox = new TextBox();
            emojiButton = new Button();
            imageButton = new Button();
            sendButton = new Button();
            rightPanel = new Panel();
            userListPanel = new Panel();
            userListBox = new ListBox();
            usersLabel = new Label();
            clientPanel = new Panel();
            clientLabel = new Label();
            ipLabel = new Label();
            ipTextBox = new TextBox();
            connectButton = new Button();
            disconnectButton = new Button();
            statusLabel = new Label();
            serverPanel = new Panel();
            serverLabel = new Label();
            startServerButton = new Button();
            stopServerButton = new Button();
            serverInfoLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            chatPanel.SuspendLayout();
            bottomPanel.SuspendLayout();
            bottomTableLayout.SuspendLayout();
            rightPanel.SuspendLayout();
            userListPanel.SuspendLayout();
            clientPanel.SuspendLayout();
            serverPanel.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.Controls.Add(chatPanel);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(240, 242, 245);
            splitContainer1.Panel2.Controls.Add(rightPanel);
            splitContainer1.Size = new Size(1000, 700);
            splitContainer1.SplitterDistance = 750;
            splitContainer1.SplitterWidth = 1;
            splitContainer1.TabIndex = 0;
            // 
            // chatPanel
            // 
            chatPanel.BackColor = Color.White;
            chatPanel.Controls.Add(chatTextBox);
            chatPanel.Controls.Add(bottomPanel);
            chatPanel.Dock = DockStyle.Fill;
            chatPanel.Location = new Point(0, 0);
            chatPanel.Name = "chatPanel";
            chatPanel.Size = new Size(750, 700);
            chatPanel.TabIndex = 0;
            // 
            // chatTextBox
            // 
            chatTextBox.BackColor = Color.White;
            chatTextBox.BorderStyle = BorderStyle.None;
            chatTextBox.Dock = DockStyle.Fill;
            chatTextBox.Font = new Font("Segoe UI", 10F);
            chatTextBox.ForeColor = Color.FromArgb(32, 32, 32);
            chatTextBox.Location = new Point(0, 0);
            chatTextBox.Name = "chatTextBox";
            chatTextBox.ReadOnly = true;
            chatTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            chatTextBox.Size = new Size(750, 650);
            chatTextBox.TabIndex = 0;
            chatTextBox.Text = "";
            // 
            // bottomPanel
            // 
            bottomPanel.BackColor = Color.FromArgb(240, 242, 245);
            bottomPanel.Controls.Add(bottomTableLayout);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 650);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(10);
            bottomPanel.Size = new Size(750, 50);
            bottomPanel.TabIndex = 1;
            // 
            // bottomTableLayout
            // 
            bottomTableLayout.ColumnCount = 4;
            bottomTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bottomTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45F));
            bottomTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45F));
            bottomTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            bottomTableLayout.Controls.Add(messageTextBox, 0, 0);
            bottomTableLayout.Controls.Add(emojiButton, 1, 0);
            bottomTableLayout.Controls.Add(imageButton, 2, 0);
            bottomTableLayout.Controls.Add(sendButton, 3, 0);
            bottomTableLayout.Dock = DockStyle.Fill;
            bottomTableLayout.Location = new Point(10, 10);
            bottomTableLayout.Name = "bottomTableLayout";
            bottomTableLayout.RowCount = 1;
            bottomTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bottomTableLayout.Size = new Size(730, 30);
            bottomTableLayout.TabIndex = 0;
            // 
            // messageTextBox
            // 
            messageTextBox.AcceptsReturn = true;
            messageTextBox.BackColor = Color.White;
            messageTextBox.BorderStyle = BorderStyle.FixedSingle;
            messageTextBox.Dock = DockStyle.Fill;
            messageTextBox.Font = new Font("Segoe UI", 10F);
            messageTextBox.Location = new Point(3, 3);
            messageTextBox.Multiline = true;
            messageTextBox.Name = "messageTextBox";
            messageTextBox.PlaceholderText = "Введите сообщение...";
            messageTextBox.Size = new Size(479, 24);
            messageTextBox.TabIndex = 0;
            messageTextBox.KeyPress += messageTextBox_KeyPress;
            // 
            // emojiButton
            // 
            emojiButton.BackColor = Color.FromArgb(0, 123, 255);
            emojiButton.Dock = DockStyle.Fill;
            emojiButton.FlatAppearance.BorderSize = 0;
            emojiButton.FlatStyle = FlatStyle.Flat;
            emojiButton.Font = new Font("Segoe UI Emoji", 10F);
            emojiButton.ForeColor = Color.White;
            emojiButton.Location = new Point(485, 2);
            emojiButton.Margin = new Padding(0, 2, 5, 2);
            emojiButton.Name = "emojiButton";
            emojiButton.Size = new Size(40, 26);
            emojiButton.TabIndex = 1;
            emojiButton.Text = "😊";
            emojiButton.UseVisualStyleBackColor = false;
            emojiButton.Click += emojiButton_Click;
            // 
            // imageButton
            // 
            imageButton.BackColor = Color.FromArgb(0, 123, 255);
            imageButton.Dock = DockStyle.Fill;
            imageButton.FlatAppearance.BorderSize = 0;
            imageButton.FlatStyle = FlatStyle.Flat;
            imageButton.Font = new Font("Segoe UI", 10F);
            imageButton.ForeColor = Color.White;
            imageButton.Location = new Point(530, 2);
            imageButton.Margin = new Padding(0, 2, 5, 2);
            imageButton.Name = "imageButton";
            imageButton.Size = new Size(40, 26);
            imageButton.TabIndex = 2;
            imageButton.Text = "📷";
            imageButton.UseVisualStyleBackColor = false;
            imageButton.Click += imageButton_Click;
            // 
            // sendButton
            // 
            sendButton.BackColor = Color.FromArgb(0, 123, 255);
            sendButton.Dock = DockStyle.Fill;
            sendButton.FlatAppearance.BorderSize = 0;
            sendButton.FlatStyle = FlatStyle.Flat;
            sendButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            sendButton.ForeColor = Color.White;
            sendButton.Location = new Point(575, 2);
            sendButton.Margin = new Padding(0, 2, 0, 2);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(100, 26);
            sendButton.TabIndex = 3;
            sendButton.Text = "Отправить";
            sendButton.UseVisualStyleBackColor = false;
            sendButton.Click += sendButton_Click;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.FromArgb(240, 242, 245);
            rightPanel.Controls.Add(userListPanel);
            rightPanel.Controls.Add(clientPanel);
            rightPanel.Controls.Add(serverPanel);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(0, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(10);
            rightPanel.Size = new Size(249, 700);
            rightPanel.TabIndex = 0;
            // 
            // userListPanel
            // 
            userListPanel.BackColor = Color.White;
            userListPanel.BorderStyle = BorderStyle.FixedSingle;
            userListPanel.Controls.Add(userListBox);
            userListPanel.Controls.Add(usersLabel);
            userListPanel.Dock = DockStyle.Fill;
            userListPanel.Location = new Point(10, 260);
            userListPanel.Name = "userListPanel";
            userListPanel.Padding = new Padding(8);
            userListPanel.Size = new Size(229, 430);
            userListPanel.TabIndex = 0;
            // 
            // userListBox
            // 
            userListBox.BackColor = Color.White;
            userListBox.BorderStyle = BorderStyle.None;
            userListBox.Dock = DockStyle.Fill;
            userListBox.Font = new Font("Segoe UI", 9F);
            userListBox.ForeColor = Color.FromArgb(32, 32, 32);
            userListBox.ItemHeight = 15;
            userListBox.Location = new Point(8, 30);
            userListBox.Name = "userListBox";
            userListBox.Size = new Size(211, 390);
            userListBox.TabIndex = 0;
            // 
            // usersLabel
            // 
            usersLabel.Dock = DockStyle.Top;
            usersLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            usersLabel.ForeColor = Color.FromArgb(32, 32, 32);
            usersLabel.Location = new Point(8, 8);
            usersLabel.Name = "usersLabel";
            usersLabel.Size = new Size(211, 22);
            usersLabel.TabIndex = 1;
            usersLabel.Text = "Пользователи онлайн:";
            // 
            // clientPanel
            // 
            clientPanel.BackColor = Color.White;
            clientPanel.BorderStyle = BorderStyle.FixedSingle;
            clientPanel.Controls.Add(clientLabel);
            clientPanel.Controls.Add(ipLabel);
            clientPanel.Controls.Add(ipTextBox);
            clientPanel.Controls.Add(connectButton);
            clientPanel.Controls.Add(disconnectButton);
            clientPanel.Controls.Add(statusLabel);
            clientPanel.Dock = DockStyle.Top;
            clientPanel.Location = new Point(10, 130);
            clientPanel.Name = "clientPanel";
            clientPanel.Padding = new Padding(8);
            clientPanel.Size = new Size(229, 130);
            clientPanel.TabIndex = 1;
            // 
            // clientLabel
            // 
            clientLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            clientLabel.ForeColor = Color.FromArgb(32, 32, 32);
            clientLabel.Location = new Point(8, 8);
            clientLabel.Name = "clientLabel";
            clientLabel.Size = new Size(200, 20);
            clientLabel.TabIndex = 0;
            clientLabel.Text = "Подключение к серверу:";
            // 
            // ipLabel
            // 
            ipLabel.Font = new Font("Segoe UI", 9F);
            ipLabel.ForeColor = Color.FromArgb(64, 64, 64);
            ipLabel.Location = new Point(8, 35);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new Size(70, 20);
            ipLabel.TabIndex = 1;
            ipLabel.Text = "IP сервера:";
            // 
            // ipTextBox
            // 
            ipTextBox.BackColor = Color.White;
            ipTextBox.BorderStyle = BorderStyle.FixedSingle;
            ipTextBox.Font = new Font("Segoe UI", 9F);
            ipTextBox.ForeColor = Color.FromArgb(32, 32, 32);
            ipTextBox.Location = new Point(80, 33);
            ipTextBox.Name = "ipTextBox";
            ipTextBox.Size = new Size(135, 23);
            ipTextBox.TabIndex = 2;
            ipTextBox.Text = "127.0.0.1";
            // 
            // connectButton
            // 
            connectButton.BackColor = Color.FromArgb(76, 175, 80);
            connectButton.FlatAppearance.BorderSize = 0;
            connectButton.FlatStyle = FlatStyle.Flat;
            connectButton.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            connectButton.ForeColor = Color.White;
            connectButton.Location = new Point(8, 65);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(100, 25);
            connectButton.TabIndex = 3;
            connectButton.Text = "Подключиться";
            connectButton.UseVisualStyleBackColor = false;
            connectButton.Click += connectButton_Click;
            // 
            // disconnectButton
            // 
            disconnectButton.BackColor = Color.FromArgb(244, 67, 54);
            disconnectButton.Enabled = false;
            disconnectButton.FlatAppearance.BorderSize = 0;
            disconnectButton.FlatStyle = FlatStyle.Flat;
            disconnectButton.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            disconnectButton.ForeColor = Color.White;
            disconnectButton.Location = new Point(115, 65);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new Size(100, 25);
            disconnectButton.TabIndex = 4;
            disconnectButton.Text = "Отключиться";
            disconnectButton.UseVisualStyleBackColor = false;
            disconnectButton.Click += disconnectButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            statusLabel.ForeColor = Color.Red;
            statusLabel.Location = new Point(8, 100);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(200, 20);
            statusLabel.TabIndex = 5;
            statusLabel.Text = "Не подключено";
            // 
            // serverPanel
            // 
            serverPanel.BackColor = Color.White;
            serverPanel.BorderStyle = BorderStyle.FixedSingle;
            serverPanel.Controls.Add(serverLabel);
            serverPanel.Controls.Add(startServerButton);
            serverPanel.Controls.Add(stopServerButton);
            serverPanel.Controls.Add(serverInfoLabel);
            serverPanel.Dock = DockStyle.Top;
            serverPanel.Location = new Point(10, 10);
            serverPanel.Name = "serverPanel";
            serverPanel.Padding = new Padding(8);
            serverPanel.Size = new Size(229, 120);
            serverPanel.TabIndex = 2;
            // 
            // serverLabel
            // 
            serverLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            serverLabel.ForeColor = Color.FromArgb(32, 32, 32);
            serverLabel.Location = new Point(8, 8);
            serverLabel.Name = "serverLabel";
            serverLabel.Size = new Size(150, 20);
            serverLabel.TabIndex = 0;
            serverLabel.Text = "Управление сервером:";
            // 
            // startServerButton
            // 
            startServerButton.BackColor = Color.FromArgb(0, 123, 255);
            startServerButton.FlatAppearance.BorderSize = 0;
            startServerButton.FlatStyle = FlatStyle.Flat;
            startServerButton.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            startServerButton.ForeColor = Color.White;
            startServerButton.Location = new Point(8, 35);
            startServerButton.Name = "startServerButton";
            startServerButton.Size = new Size(100, 30);
            startServerButton.TabIndex = 1;
            startServerButton.Text = "Запустить сервер";
            startServerButton.UseVisualStyleBackColor = false;
            startServerButton.Click += startServerButton_Click;
            // 
            // stopServerButton
            // 
            stopServerButton.BackColor = Color.FromArgb(108, 117, 125);
            stopServerButton.Enabled = false;
            stopServerButton.FlatAppearance.BorderSize = 0;
            stopServerButton.FlatStyle = FlatStyle.Flat;
            stopServerButton.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            stopServerButton.ForeColor = Color.White;
            stopServerButton.Location = new Point(115, 35);
            stopServerButton.Name = "stopServerButton";
            stopServerButton.Size = new Size(100, 30);
            stopServerButton.TabIndex = 2;
            stopServerButton.Text = "Остановить сервер";
            stopServerButton.UseVisualStyleBackColor = false;
            stopServerButton.Click += stopServerButton_Click;
            // 
            // serverInfoLabel
            // 
            serverInfoLabel.Font = new Font("Segoe UI", 8F);
            serverInfoLabel.ForeColor = Color.FromArgb(64, 64, 64);
            serverInfoLabel.Location = new Point(8, 75);
            serverInfoLabel.Name = "serverInfoLabel";
            serverInfoLabel.Size = new Size(210, 35);
            serverInfoLabel.TabIndex = 3;
            serverInfoLabel.Text = "Ваш IP: загрузка...";
            // 
            // MainForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1000, 700);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(800, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Messenger App";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            chatPanel.ResumeLayout(false);
            bottomPanel.ResumeLayout(false);
            bottomTableLayout.ResumeLayout(false);
            bottomTableLayout.PerformLayout();
            rightPanel.ResumeLayout(false);
            userListPanel.ResumeLayout(false);
            clientPanel.ResumeLayout(false);
            clientPanel.PerformLayout();
            serverPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Panel chatPanel;
        private Panel rightPanel;
        private Panel userListPanel;
        private Label usersLabel;
        private Label clientLabel;
        private Label serverLabel;
    }
}