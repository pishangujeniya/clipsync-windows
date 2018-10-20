namespace ClipSync {
	partial class LoginSignUpForm {
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
			this.Login_Button = new System.Windows.Forms.Button();
			this.Sign_Up_Button = new System.Windows.Forms.Button();
			this.username_text_box = new System.Windows.Forms.TextBox();
			this.username_label = new System.Windows.Forms.Label();
			this.password_label = new System.Windows.Forms.Label();
			this.Password_text_box = new System.Windows.Forms.TextBox();
			this.forgot_password_link_label = new System.Windows.Forms.LinkLabel();
			this.LoginSignUpProgressBar = new System.Windows.Forms.ProgressBar();
			this.LoginSingUpBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.connectClipSyncButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Login_Button
			// 
			this.Login_Button.Location = new System.Drawing.Point(180, 244);
			this.Login_Button.Name = "Login_Button";
			this.Login_Button.Size = new System.Drawing.Size(75, 23);
			this.Login_Button.TabIndex = 3;
			this.Login_Button.Text = "Login";
			this.Login_Button.UseVisualStyleBackColor = true;
			this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
			// 
			// Sign_Up_Button
			// 
			this.Sign_Up_Button.Location = new System.Drawing.Point(301, 244);
			this.Sign_Up_Button.Name = "Sign_Up_Button";
			this.Sign_Up_Button.Size = new System.Drawing.Size(75, 23);
			this.Sign_Up_Button.TabIndex = 4;
			this.Sign_Up_Button.Text = "Sign Up";
			this.Sign_Up_Button.UseVisualStyleBackColor = true;
			this.Sign_Up_Button.Click += new System.EventHandler(this.Sign_Up_Button_Click);
			// 
			// username_text_box
			// 
			this.username_text_box.Location = new System.Drawing.Point(180, 142);
			this.username_text_box.Name = "username_text_box";
			this.username_text_box.Size = new System.Drawing.Size(196, 20);
			this.username_text_box.TabIndex = 1;
			// 
			// username_label
			// 
			this.username_label.AutoSize = true;
			this.username_label.Location = new System.Drawing.Point(177, 126);
			this.username_label.Name = "username_label";
			this.username_label.Size = new System.Drawing.Size(55, 13);
			this.username_label.TabIndex = 2;
			this.username_label.Text = "Username";
			// 
			// password_label
			// 
			this.password_label.AutoSize = true;
			this.password_label.Location = new System.Drawing.Point(177, 165);
			this.password_label.Name = "password_label";
			this.password_label.Size = new System.Drawing.Size(53, 13);
			this.password_label.TabIndex = 2;
			this.password_label.Text = "Password";
			// 
			// Password_text_box
			// 
			this.Password_text_box.Location = new System.Drawing.Point(180, 181);
			this.Password_text_box.Name = "Password_text_box";
			this.Password_text_box.Size = new System.Drawing.Size(196, 20);
			this.Password_text_box.TabIndex = 2;
			// 
			// forgot_password_link_label
			// 
			this.forgot_password_link_label.AutoSize = true;
			this.forgot_password_link_label.Location = new System.Drawing.Point(180, 208);
			this.forgot_password_link_label.Name = "forgot_password_link_label";
			this.forgot_password_link_label.Size = new System.Drawing.Size(86, 13);
			this.forgot_password_link_label.TabIndex = 3;
			this.forgot_password_link_label.TabStop = true;
			this.forgot_password_link_label.Text = "Forgot Password";
			// 
			// LoginSignUpProgressBar
			// 
			this.LoginSignUpProgressBar.Location = new System.Drawing.Point(180, 290);
			this.LoginSignUpProgressBar.Name = "LoginSignUpProgressBar";
			this.LoginSignUpProgressBar.Size = new System.Drawing.Size(196, 23);
			this.LoginSignUpProgressBar.TabIndex = 4;
			// 
			// LoginSingUpBackgroundWorker
			// 
			this.LoginSingUpBackgroundWorker.WorkerReportsProgress = true;
			this.LoginSingUpBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoginSingUpBackgroundWorker_DoWork);
			this.LoginSingUpBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.LoginSingUpBackgroundWorker_ProgressChanged);
			this.LoginSingUpBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoginSingUpBackgroundWorker_RunWorkerCompleted);
			// 
			// connectClipSyncButton
			// 
			this.connectClipSyncButton.Location = new System.Drawing.Point(509, 139);
			this.connectClipSyncButton.Name = "connectClipSyncButton";
			this.connectClipSyncButton.Size = new System.Drawing.Size(122, 23);
			this.connectClipSyncButton.TabIndex = 5;
			this.connectClipSyncButton.Text = "Connect ClipSync";
			this.connectClipSyncButton.UseVisualStyleBackColor = true;
			this.connectClipSyncButton.Click += new System.EventHandler(this.connectClipSyncButtonClick);
			// 
			// LoginSignUpForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.connectClipSyncButton);
			this.Controls.Add(this.LoginSignUpProgressBar);
			this.Controls.Add(this.forgot_password_link_label);
			this.Controls.Add(this.password_label);
			this.Controls.Add(this.username_label);
			this.Controls.Add(this.Password_text_box);
			this.Controls.Add(this.username_text_box);
			this.Controls.Add(this.Sign_Up_Button);
			this.Controls.Add(this.Login_Button);
			this.Name = "LoginSignUpForm";
			this.Text = "LoginSignUpForm";
			this.Load += new System.EventHandler(this.LoginSignUpForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Login_Button;
		private System.Windows.Forms.Button Sign_Up_Button;
		private System.Windows.Forms.TextBox username_text_box;
		private System.Windows.Forms.Label username_label;
		private System.Windows.Forms.Label password_label;
		private System.Windows.Forms.TextBox Password_text_box;
		private System.Windows.Forms.LinkLabel forgot_password_link_label;
		private System.Windows.Forms.ProgressBar LoginSignUpProgressBar;
		private System.ComponentModel.BackgroundWorker LoginSingUpBackgroundWorker;
		private System.Windows.Forms.Button connectClipSyncButton;
	}
}