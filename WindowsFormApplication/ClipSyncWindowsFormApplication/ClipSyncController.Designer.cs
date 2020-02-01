namespace ClipSync {
	partial class ClipSyncControlForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClipSyncControlForm));
            this.Login_Button = new System.Windows.Forms.Button();
            this.consoleTextBox = new System.Windows.Forms.RichTextBox();
            this.clientGroupBox = new System.Windows.Forms.GroupBox();
            this.connectServerPortTextBox = new System.Windows.Forms.TextBox();
            this.connectUidTextBox = new System.Windows.Forms.TextBox();
            this.uidLabel = new System.Windows.Forms.Label();
            this.connectPortLabel = new System.Windows.Forms.Label();
            this.connectServerAddressTextBox = new System.Windows.Forms.TextBox();
            this.connectServerAddressLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.serverGroupBox = new System.Windows.Forms.GroupBox();
            this.serverAddressTextBox = new System.Windows.Forms.TextBox();
            this.startServerButton = new System.Windows.Forms.Button();
            this.serverPortTextBox = new System.Windows.Forms.TextBox();
            this.serverPort = new System.Windows.Forms.Label();
            this.serverAddress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clientGroupBox.SuspendLayout();
            this.serverGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login_Button
            // 
            this.Login_Button.Location = new System.Drawing.Point(53, 210);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(75, 23);
            this.Login_Button.TabIndex = 3;
            this.Login_Button.Text = "Login";
            this.Login_Button.UseVisualStyleBackColor = true;
            this.Login_Button.Click += new System.EventHandler(this.LoginButtonClick);
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Location = new System.Drawing.Point(55, 288);
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.Size = new System.Drawing.Size(678, 272);
            this.consoleTextBox.TabIndex = 6;
            this.consoleTextBox.Text = "Logs Here";
            // 
            // clientGroupBox
            // 
            this.clientGroupBox.Controls.Add(this.connectServerPortTextBox);
            this.clientGroupBox.Controls.Add(this.connectUidTextBox);
            this.clientGroupBox.Controls.Add(this.uidLabel);
            this.clientGroupBox.Controls.Add(this.connectPortLabel);
            this.clientGroupBox.Controls.Add(this.connectServerAddressTextBox);
            this.clientGroupBox.Controls.Add(this.connectServerAddressLabel);
            this.clientGroupBox.Controls.Add(this.Login_Button);
            this.clientGroupBox.Location = new System.Drawing.Point(432, 12);
            this.clientGroupBox.Name = "clientGroupBox";
            this.clientGroupBox.Size = new System.Drawing.Size(301, 253);
            this.clientGroupBox.TabIndex = 7;
            this.clientGroupBox.TabStop = false;
            this.clientGroupBox.Text = "Connect";
            // 
            // connectServerPortTextBox
            // 
            this.connectServerPortTextBox.Location = new System.Drawing.Point(53, 71);
            this.connectServerPortTextBox.Name = "connectServerPortTextBox";
            this.connectServerPortTextBox.Size = new System.Drawing.Size(76, 20);
            this.connectServerPortTextBox.TabIndex = 10;
            // 
            // connectUidTextBox
            // 
            this.connectUidTextBox.Location = new System.Drawing.Point(136, 71);
            this.connectUidTextBox.Name = "connectUidTextBox";
            this.connectUidTextBox.Size = new System.Drawing.Size(107, 20);
            this.connectUidTextBox.TabIndex = 6;
            // 
            // uidLabel
            // 
            this.uidLabel.AutoSize = true;
            this.uidLabel.Location = new System.Drawing.Point(133, 55);
            this.uidLabel.Name = "uidLabel";
            this.uidLabel.Size = new System.Drawing.Size(26, 13);
            this.uidLabel.TabIndex = 5;
            this.uidLabel.Text = "UID";
            // 
            // connectPortLabel
            // 
            this.connectPortLabel.AutoSize = true;
            this.connectPortLabel.Location = new System.Drawing.Point(50, 55);
            this.connectPortLabel.Name = "connectPortLabel";
            this.connectPortLabel.Size = new System.Drawing.Size(60, 13);
            this.connectPortLabel.TabIndex = 9;
            this.connectPortLabel.Text = "Server Port";
            // 
            // connectServerAddressTextBox
            // 
            this.connectServerAddressTextBox.Location = new System.Drawing.Point(54, 32);
            this.connectServerAddressTextBox.Name = "connectServerAddressTextBox";
            this.connectServerAddressTextBox.Size = new System.Drawing.Size(189, 20);
            this.connectServerAddressTextBox.TabIndex = 8;
            // 
            // connectServerAddressLabel
            // 
            this.connectServerAddressLabel.AutoSize = true;
            this.connectServerAddressLabel.Location = new System.Drawing.Point(51, 16);
            this.connectServerAddressLabel.Name = "connectServerAddressLabel";
            this.connectServerAddressLabel.Size = new System.Drawing.Size(79, 13);
            this.connectServerAddressLabel.TabIndex = 7;
            this.connectServerAddressLabel.Text = "Server Address";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 20);
            this.textBox1.TabIndex = 10;
            // 
            // serverGroupBox
            // 
            this.serverGroupBox.Controls.Add(this.serverAddressTextBox);
            this.serverGroupBox.Controls.Add(this.startServerButton);
            this.serverGroupBox.Controls.Add(this.serverPortTextBox);
            this.serverGroupBox.Controls.Add(this.serverPort);
            this.serverGroupBox.Controls.Add(this.serverAddress);
            this.serverGroupBox.Location = new System.Drawing.Point(55, 12);
            this.serverGroupBox.Name = "serverGroupBox";
            this.serverGroupBox.Size = new System.Drawing.Size(301, 183);
            this.serverGroupBox.TabIndex = 7;
            this.serverGroupBox.TabStop = false;
            this.serverGroupBox.Text = "Server";
            // 
            // serverAddressTextBox
            // 
            this.serverAddressTextBox.Location = new System.Drawing.Point(48, 32);
            this.serverAddressTextBox.Name = "serverAddressTextBox";
            this.serverAddressTextBox.Size = new System.Drawing.Size(196, 20);
            this.serverAddressTextBox.TabIndex = 1;
            // 
            // startServerButton
            // 
            this.startServerButton.Location = new System.Drawing.Point(107, 115);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(75, 23);
            this.startServerButton.TabIndex = 3;
            this.startServerButton.Text = "Start Server";
            this.startServerButton.UseVisualStyleBackColor = true;
            this.startServerButton.Click += new System.EventHandler(this.StartServerButton_Click);
            // 
            // serverPortTextBox
            // 
            this.serverPortTextBox.Location = new System.Drawing.Point(48, 71);
            this.serverPortTextBox.Name = "serverPortTextBox";
            this.serverPortTextBox.Size = new System.Drawing.Size(196, 20);
            this.serverPortTextBox.TabIndex = 2;
            this.serverPortTextBox.Text = "6262";
            // 
            // serverPort
            // 
            this.serverPort.AutoSize = true;
            this.serverPort.Location = new System.Drawing.Point(45, 55);
            this.serverPort.Name = "serverPort";
            this.serverPort.Size = new System.Drawing.Size(60, 13);
            this.serverPort.TabIndex = 2;
            this.serverPort.Text = "Server Port";
            // 
            // serverAddress
            // 
            this.serverAddress.AutoSize = true;
            this.serverAddress.Location = new System.Drawing.Point(45, 16);
            this.serverAddress.Name = "serverAddress";
            this.serverAddress.Size = new System.Drawing.Size(79, 13);
            this.serverAddress.TabIndex = 2;
            this.serverAddress.Text = "Server Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "UID";
            // 
            // ClipSyncControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 572);
            this.Controls.Add(this.serverGroupBox);
            this.Controls.Add(this.clientGroupBox);
            this.Controls.Add(this.consoleTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClipSyncControlForm";
            this.Text = "ClipSync";
            this.Load += new System.EventHandler(this.LoginSignUpForm_Load);
            this.clientGroupBox.ResumeLayout(false);
            this.clientGroupBox.PerformLayout();
            this.serverGroupBox.ResumeLayout(false);
            this.serverGroupBox.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button Login_Button;
        private System.Windows.Forms.GroupBox clientGroupBox;
        private System.Windows.Forms.GroupBox serverGroupBox;
        private System.Windows.Forms.TextBox serverAddressTextBox;
        private System.Windows.Forms.Button startServerButton;
        private System.Windows.Forms.TextBox serverPortTextBox;
        private System.Windows.Forms.Label serverPort;
        private System.Windows.Forms.Label serverAddress;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label connectPortLabel;
        private System.Windows.Forms.TextBox connectServerAddressTextBox;
        private System.Windows.Forms.Label connectServerAddressLabel;
        private System.Windows.Forms.TextBox connectUidTextBox;
        private System.Windows.Forms.Label uidLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox connectServerPortTextBox;
        private System.Windows.Forms.RichTextBox consoleTextBox;
    }
}