namespace HomeExamClientServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.NewUserNameLbl = new System.Windows.Forms.Label();
            this.newUserPwdLbl = new System.Windows.Forms.Label();
            this.NewUserTxt = new System.Windows.Forms.TextBox();
            this.NewUserPwdTxt = new System.Windows.Forms.TextBox();
            this.NewUserPathLbl = new System.Windows.Forms.Label();
            this.NewUserPathTxt = new System.Windows.Forms.TextBox();
            this.AddNewUser = new System.Windows.Forms.Button();
            this.DeleteUserBtn = new System.Windows.Forms.Button();
            this.UpdatePwdBtn = new System.Windows.Forms.Button();
            this.SendToClientBtn = new System.Windows.Forms.Button();
            this.SendToServerTxt = new System.Windows.Forms.TextBox();
            this.StopServerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(47, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "StartServer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(104, 21);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(200, 23);
            this.txtUserName.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(104, 74);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.TabIndex = 2;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(18, 29);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(62, 15);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "UserName";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(18, 74);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 15);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.AutoEllipsis = true;
            this.btnLogin.Location = new System.Drawing.Point(47, 116);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(223, 66);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // NewUserNameLbl
            // 
            this.NewUserNameLbl.AutoSize = true;
            this.NewUserNameLbl.Location = new System.Drawing.Point(436, 20);
            this.NewUserNameLbl.Name = "NewUserNameLbl";
            this.NewUserNameLbl.Size = new System.Drawing.Size(62, 15);
            this.NewUserNameLbl.TabIndex = 8;
            this.NewUserNameLbl.Text = "UserName";
            this.NewUserNameLbl.Visible = false;
            // 
            // newUserPwdLbl
            // 
            this.newUserPwdLbl.AutoSize = true;
            this.newUserPwdLbl.Location = new System.Drawing.Point(436, 65);
            this.newUserPwdLbl.Name = "newUserPwdLbl";
            this.newUserPwdLbl.Size = new System.Drawing.Size(57, 15);
            this.newUserPwdLbl.TabIndex = 9;
            this.newUserPwdLbl.Text = "Password";
            this.newUserPwdLbl.Visible = false;
            // 
            // NewUserTxt
            // 
            this.NewUserTxt.Location = new System.Drawing.Point(515, 21);
            this.NewUserTxt.Name = "NewUserTxt";
            this.NewUserTxt.Size = new System.Drawing.Size(100, 23);
            this.NewUserTxt.TabIndex = 10;
            this.NewUserTxt.Visible = false;
            // 
            // NewUserPwdTxt
            // 
            this.NewUserPwdTxt.Location = new System.Drawing.Point(515, 65);
            this.NewUserPwdTxt.Name = "NewUserPwdTxt";
            this.NewUserPwdTxt.Size = new System.Drawing.Size(100, 23);
            this.NewUserPwdTxt.TabIndex = 11;
            this.NewUserPwdTxt.Visible = false;
            // 
            // NewUserPathLbl
            // 
            this.NewUserPathLbl.AutoSize = true;
            this.NewUserPathLbl.Location = new System.Drawing.Point(436, 116);
            this.NewUserPathLbl.Name = "NewUserPathLbl";
            this.NewUserPathLbl.Size = new System.Drawing.Size(81, 15);
            this.NewUserPathLbl.TabIndex = 12;
            this.NewUserPathLbl.Text = "New UserPath";
            this.NewUserPathLbl.Visible = false;
            // 
            // NewUserPathTxt
            // 
            this.NewUserPathTxt.Location = new System.Drawing.Point(523, 113);
            this.NewUserPathTxt.Name = "NewUserPathTxt";
            this.NewUserPathTxt.Size = new System.Drawing.Size(100, 23);
            this.NewUserPathTxt.TabIndex = 13;
            this.NewUserPathTxt.Visible = false;
            // 
            // AddNewUser
            // 
            this.AddNewUser.Location = new System.Drawing.Point(436, 159);
            this.AddNewUser.Name = "AddNewUser";
            this.AddNewUser.Size = new System.Drawing.Size(139, 23);
            this.AddNewUser.TabIndex = 14;
            this.AddNewUser.Text = "AddNewUserBtn";
            this.AddNewUser.UseVisualStyleBackColor = true;
            this.AddNewUser.Visible = false;
            this.AddNewUser.Click += new System.EventHandler(this.AddNewUser_Click);
            // 
            // DeleteUserBtn
            // 
            this.DeleteUserBtn.Location = new System.Drawing.Point(582, 159);
            this.DeleteUserBtn.Name = "DeleteUserBtn";
            this.DeleteUserBtn.Size = new System.Drawing.Size(145, 23);
            this.DeleteUserBtn.TabIndex = 15;
            this.DeleteUserBtn.Text = "DeleteUser";
            this.DeleteUserBtn.UseVisualStyleBackColor = true;
            this.DeleteUserBtn.Visible = false;
            this.DeleteUserBtn.Click += new System.EventHandler(this.DeleteUserBtn_Click);
            // 
            // UpdatePwdBtn
            // 
            this.UpdatePwdBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdatePwdBtn.Location = new System.Drawing.Point(632, 65);
            this.UpdatePwdBtn.Name = "UpdatePwdBtn";
            this.UpdatePwdBtn.Size = new System.Drawing.Size(132, 23);
            this.UpdatePwdBtn.TabIndex = 16;
            this.UpdatePwdBtn.Text = "updatePwd";
            this.UpdatePwdBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.UpdatePwdBtn.UseVisualStyleBackColor = true;
            this.UpdatePwdBtn.Visible = false;
            this.UpdatePwdBtn.Click += new System.EventHandler(this.UpdatePwdBtn_Click);
            // 
            // SendToClientBtn
            // 
            this.SendToClientBtn.Location = new System.Drawing.Point(287, 399);
            this.SendToClientBtn.Name = "SendToClientBtn";
            this.SendToClientBtn.Size = new System.Drawing.Size(206, 23);
            this.SendToClientBtn.TabIndex = 17;
            this.SendToClientBtn.Text = "SendToClient";
            this.SendToClientBtn.UseVisualStyleBackColor = true;
            this.SendToClientBtn.Visible = false;
            this.SendToClientBtn.Click += new System.EventHandler(this.SendToClientBtn_Click);
            // 
            // SendToServerTxt
            // 
            this.SendToServerTxt.Location = new System.Drawing.Point(523, 399);
            this.SendToServerTxt.Name = "SendToServerTxt";
            this.SendToServerTxt.Size = new System.Drawing.Size(209, 23);
            this.SendToServerTxt.TabIndex = 18;
            this.SendToServerTxt.Visible = false;
            // 
            // StopServerBtn
            // 
            this.StopServerBtn.Location = new System.Drawing.Point(47, 399);
            this.StopServerBtn.Name = "StopServerBtn";
            this.StopServerBtn.Size = new System.Drawing.Size(206, 23);
            this.StopServerBtn.TabIndex = 19;
            this.StopServerBtn.Text = "StopServer";
            this.StopServerBtn.UseVisualStyleBackColor = true;
            this.StopServerBtn.Click += new System.EventHandler(this.StopServerBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StopServerBtn);
            this.Controls.Add(this.SendToServerTxt);
            this.Controls.Add(this.SendToClientBtn);
            this.Controls.Add(this.UpdatePwdBtn);
            this.Controls.Add(this.DeleteUserBtn);
            this.Controls.Add(this.AddNewUser);
            this.Controls.Add(this.NewUserPathTxt);
            this.Controls.Add(this.NewUserPathLbl);
            this.Controls.Add(this.NewUserPwdTxt);
            this.Controls.Add(this.NewUserTxt);
            this.Controls.Add(this.newUserPwdLbl);
            this.Controls.Add(this.NewUserNameLbl);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label NewUserNameLbl;
        private System.Windows.Forms.Label newUserPwdLbl;
        private System.Windows.Forms.TextBox NewUserPwdTxt;
        private System.Windows.Forms.Label NewUserPathLbl;
        private System.Windows.Forms.TextBox NewUserPathTxt;
        private System.Windows.Forms.Button AddNewUser;
        public System.Windows.Forms.TextBox NewUserTxt;
        private System.Windows.Forms.Button DeleteUserBtn;
        private System.Windows.Forms.Button UpdatePwdBtn;
        private System.Windows.Forms.Button SendToClientBtn;
        private System.Windows.Forms.TextBox SendToServerTxt;
        private System.Windows.Forms.Button StopServerBtn;
    }
}

