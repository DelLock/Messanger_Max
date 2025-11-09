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
            splitContainer1.Panel1.Controls.Add(chatPanel);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(rightPanel);
            splitContainer1.Size = new Size(984, 661);
            splitContainer1.SplitterDistance = 954;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // chatPanel
            // 
            chatPanel.Controls.Add(chatTextBox);
            chatPanel.Controls.Add(bottomPanel);
            chatPanel.Dock = DockStyle.Fill;
            chatPanel.Location = new Point(0, 0);
            chatPanel.Name = "chatPanel";
            chatPanel.Size = new Size(954, 661);
            chatPanel.TabIndex = 0;
            // 
            // chatTextBox
            // 
            chatTextBox.BorderStyle = BorderStyle.FixedSingle;
            chatTextBox.Dock = DockStyle.Fill;
            chatTextBox.Font = new Font("Segoe UI", 10F);
            chatTextBox.Location = new Point(0, 0);
            chatTextBox.Name = "chatTextBox";
            chatTextBox.ReadOnly = true;
            chatTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            chatTextBox.Size = new Size(954, 611);
            chatTextBox.TabIndex = 0;
            chatTextBox.Text = "";
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(bottomTableLayout);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 611);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(5);
            bottomPanel.Size = new Size(954, 50);
            bottomPanel.TabIndex = 1;
            // 
            // bottomTableLayout
            // 
            bottomTableLayout.ColumnCount = 6;
            bottomTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bottomTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            bottomTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            bottomTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            bottomTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            bottomTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            bottomTableLayout.Controls.Add(messageTextBox, 0, 0);
            bottomTableLayout.Controls.Add(emojiButton, 1, 0);
            bottomTableLayout.Controls.Add(imageButton, 2, 0);
            bottomTableLayout.Controls.Add(sendButton, 3, 0);
            bottomTableLayout.Dock = DockStyle.Fill;
            bottomTableLayout.Location = new Point(5, 5);
            bottomTableLayout.Name = "bottomTableLayout";
            bottomTableLayout.RowCount = 1;
            bottomTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            bottomTableLayout.Size = new Size(944, 40);
            bottomTableLayout.TabIndex = 0;
            // 
            // messageTextBox
            // 
            messageTextBox.AcceptsReturn = true;
            messageTextBox.Dock = DockStyle.Fill;
            messageTextBox.Font = new Font("Segoe UI", 10F);
            messageTextBox.Location = new Point(3, 3);
            messageTextBox.Multiline = true;
            messageTextBox.Name = "messageTextBox";
            messageTextBox.Size = new Size(738, 34);
            messageTextBox.TabIndex = 0;
            messageTextBox.KeyPress += messageTextBox_KeyPress;
            // 
            // emojiButton
            // 
            emojiButton.Dock = DockStyle.Fill;
            emojiButton.Font = new Font("Segoe UI", 12F);
            emojiButton.Location = new Point(746, 2);
            emojiButton.Margin = new Padding(2);
            emojiButton.Name = "emojiButton";
            emojiButton.Size = new Size(36, 36);
            emojiButton.TabIndex = 1;
            emojiButton.Text = "😊";
            emojiButton.Click += emojiButton_Click;
            // 
            // imageButton
            // 
            imageButton.Dock = DockStyle.Fill;
            imageButton.Font = new Font("Segoe UI", 12F);
            imageButton.Location = new Point(786, 2);
            imageButton.Margin = new Padding(2);
            imageButton.Name = "imageButton";
            imageButton.Size = new Size(36, 36);
            imageButton.TabIndex = 2;
            imageButton.Text = "📷";
            imageButton.Click += imageButton_Click;
            // 
            // sendButton
            // 
            sendButton.Dock = DockStyle.Fill;
            sendButton.Font = new Font("Segoe UI", 9F);
            sendButton.Location = new Point(826, 2);
            sendButton.Margin = new Padding(2);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(76, 36);
            sendButton.TabIndex = 3;
            sendButton.Text = "Отправить";
            sendButton.Click += sendButton_Click;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(userListPanel);
            rightPanel.Controls.Add(clientPanel);
            rightPanel.Controls.Add(serverPanel);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(0, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(5);
            rightPanel.Size = new Size(25, 661);
            rightPanel.TabIndex = 0;
            // 
            // userListPanel
            // 
            userListPanel.BorderStyle = BorderStyle.FixedSingle;
            userListPanel.Controls.Add(userListBox);
            userListPanel.Controls.Add(usersLabel);
            userListPanel.Dock = DockStyle.Fill;
            userListPanel.Location = new Point(5, 245);
            userListPanel.Name = "userListPanel";
            userListPanel.Padding = new Padding(5);
            userListPanel.Size = new Size(15, 411);
            userListPanel.TabIndex = 0;
            // 
            // userListBox
            // 
            userListBox.BorderStyle = BorderStyle.None;
            userListBox.Dock = DockStyle.Fill;
            userListBox.Font = new Font("Segoe UI", 9F);
            userListBox.ItemHeight = 15;
            userListBox.Location = new Point(5, 25);
            userListBox.Name = "userListBox";
            userListBox.Size = new Size(3, 379);
            userListBox.TabIndex = 0;
            // 
            // usersLabel
            // 
            usersLabel.Dock = DockStyle.Top;
            usersLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            usersLabel.Location = new Point(5, 5);
            usersLabel.Name = "usersLabel";
            usersLabel.Size = new Size(3, 20);
            usersLabel.TabIndex = 1;
            usersLabel.Text = "Пользователи онлайн:";
            // 
            // clientPanel
            // 
            clientPanel.BorderStyle = BorderStyle.FixedSingle;
            clientPanel.Controls.Add(clientLabel);
            clientPanel.Controls.Add(ipLabel);
            clientPanel.Controls.Add(ipTextBox);
            clientPanel.Controls.Add(connectButton);
            clientPanel.Controls.Add(disconnectButton);
            clientPanel.Controls.Add(statusLabel);
            clientPanel.Dock = DockStyle.Top;
            clientPanel.Location = new Point(5, 125);
            clientPanel.Name = "clientPanel";
            clientPanel.Padding = new Padding(5);
            clientPanel.Size = new Size(15, 120);
            clientPanel.TabIndex = 1;
            // 
            // clientLabel
            // 
            clientLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            clientLabel.Location = new Point(5, 5);
            clientLabel.Name = "clientLabel";
            clientLabel.Size = new Size(150, 20);
            clientLabel.TabIndex = 0;
            clientLabel.Text = "Подключение к серверу:";
            // 
            // ipLabel
            // 
            ipLabel.Font = new Font("Segoe UI", 8F);
            ipLabel.Location = new Point(5, 30);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new Size(70, 20);
            ipLabel.TabIndex = 1;
            ipLabel.Text = "IP сервера:";
            // 
            // ipTextBox
            // 
            ipTextBox.Font = new Font("Segoe UI", 8F);
            ipTextBox.Location = new Point(80, 28);
            ipTextBox.Name = "ipTextBox";
            ipTextBox.Size = new Size(100, 22);
            ipTextBox.TabIndex = 2;
            ipTextBox.Text = "127.0.0.1";
            // 
            // connectButton
            // 
            connectButton.Font = new Font("Segoe UI", 8F);
            connectButton.Location = new Point(185, 27);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(80, 25);
            connectButton.TabIndex = 3;
            connectButton.Text = "Подключиться";
            connectButton.Click += connectButton_Click;
            // 
            // disconnectButton
            // 
            disconnectButton.Enabled = false;
            disconnectButton.Font = new Font("Segoe UI", 8F);
            disconnectButton.Location = new Point(270, 27);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new Size(80, 25);
            disconnectButton.TabIndex = 4;
            disconnectButton.Text = "Отключиться";
            disconnectButton.Click += disconnectButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            statusLabel.ForeColor = Color.Red;
            statusLabel.Location = new Point(5, 60);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(200, 20);
            statusLabel.TabIndex = 5;
            statusLabel.Text = "Не подключено";
            // 
            // serverPanel
            // 
            serverPanel.BorderStyle = BorderStyle.FixedSingle;
            serverPanel.Controls.Add(serverLabel);
            serverPanel.Controls.Add(startServerButton);
            serverPanel.Controls.Add(stopServerButton);
            serverPanel.Controls.Add(serverInfoLabel);
            serverPanel.Dock = DockStyle.Top;
            serverPanel.Location = new Point(5, 5);
            serverPanel.Name = "serverPanel";
            serverPanel.Padding = new Padding(5);
            serverPanel.Size = new Size(15, 120);
            serverPanel.TabIndex = 2;
            // 
            // serverLabel
            // 
            serverLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            serverLabel.Location = new Point(5, 5);
            serverLabel.Name = "serverLabel";
            serverLabel.Size = new Size(150, 20);
            serverLabel.TabIndex = 0;
            serverLabel.Text = "Управление сервером:";
            // 
            // startServerButton
            // 
            startServerButton.Font = new Font("Segoe UI", 8F);
            startServerButton.Location = new Point(5, 30);
            startServerButton.Name = "startServerButton";
            startServerButton.Size = new Size(120, 30);
            startServerButton.TabIndex = 1;
            startServerButton.Text = "Запустить сервер";
            startServerButton.Click += startServerButton_Click;
            // 
            // stopServerButton
            // 
            stopServerButton.Enabled = false;
            stopServerButton.Font = new Font("Segoe UI", 8F);
            stopServerButton.Location = new Point(130, 30);
            stopServerButton.Name = "stopServerButton";
            stopServerButton.Size = new Size(120, 30);
            stopServerButton.TabIndex = 2;
            stopServerButton.Text = "Остановить сервер";
            stopServerButton.Click += stopServerButton_Click;
            // 
            // serverInfoLabel
            // 
            serverInfoLabel.Font = new Font("Segoe UI", 8F);
            serverInfoLabel.Location = new Point(5, 70);
            serverInfoLabel.Name = "serverInfoLabel";
            serverInfoLabel.Size = new Size(250, 40);
            serverInfoLabel.TabIndex = 3;
            serverInfoLabel.Text = "Ваш IP: загрузка...";
            // 
            // MainForm
            // 
            ClientSize = new Size(984, 661);
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