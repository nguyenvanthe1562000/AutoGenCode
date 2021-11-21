namespace WindowsFormsApp1
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.cbx_server = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_authentication = new System.Windows.Forms.ComboBox();
            this.ckb_RememberPass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "server name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "username";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(120, 96);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(192, 20);
            this.txt_username.TabIndex = 2;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(252, 152);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "đăng nhập";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "password";
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(120, 125);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(192, 20);
            this.txt_pass.TabIndex = 5;
            // 
            // cbx_server
            // 
            this.cbx_server.FormattingEnabled = true;
            this.cbx_server.Location = new System.Drawing.Point(122, 33);
            this.cbx_server.Name = "cbx_server";
            this.cbx_server.Size = new System.Drawing.Size(190, 21);
            this.cbx_server.TabIndex = 7;
            this.cbx_server.SelectedIndexChanged += new System.EventHandler(this.cbx_server_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Authentication";
            // 
            // cbx_authentication
            // 
            this.cbx_authentication.FormattingEnabled = true;
            this.cbx_authentication.Location = new System.Drawing.Point(122, 69);
            this.cbx_authentication.Name = "cbx_authentication";
            this.cbx_authentication.Size = new System.Drawing.Size(190, 21);
            this.cbx_authentication.TabIndex = 10;
            this.cbx_authentication.SelectedIndexChanged += new System.EventHandler(this.cbx_authentication_SelectedIndexChanged);
            // 
            // ckb_RememberPass
            // 
            this.ckb_RememberPass.AutoSize = true;
            this.ckb_RememberPass.Location = new System.Drawing.Point(120, 152);
            this.ckb_RememberPass.Name = "ckb_RememberPass";
            this.ckb_RememberPass.Size = new System.Drawing.Size(126, 17);
            this.ckb_RememberPass.TabIndex = 11;
            this.ckb_RememberPass.Text = "Remember Password";
            this.ckb_RememberPass.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 194);
            this.Controls.Add(this.ckb_RememberPass);
            this.Controls.Add(this.cbx_authentication);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbx_server);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.label1);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.ComboBox cbx_server;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_authentication;
        private System.Windows.Forms.CheckBox ckb_RememberPass;
        public System.Windows.Forms.Button btn_login;
    }
}