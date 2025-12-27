namespace pruebaLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.icoVer = new FontAwesome.Sharp.IconButton();
            this.icoUsuario = new FontAwesome.Sharp.IconButton();
            this.icoPass = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new pruebaLoading.moonTextBox();
            this.txtUsuario = new pruebaLoading.moonTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(84)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 389);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(41, 148);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.label1.Size = new System.Drawing.Size(231, 135);
            this.label1.TabIndex = 19;
            this.label1.Text = "Carwash Montevideo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(232)))), ((int)(((byte)(225)))));
            this.panel2.Controls.Add(this.iconButton5);
            this.panel2.Controls.Add(this.iconButton3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(231, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 42);
            this.panel2.TabIndex = 19;
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // iconButton5
            // 
            this.iconButton5.AutoSize = true;
            this.iconButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton5.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.ForeColor = System.Drawing.Color.Transparent;
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconButton5.IconColor = System.Drawing.Color.Black;
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton5.IconSize = 40;
            this.iconButton5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconButton5.Location = new System.Drawing.Point(291, 0);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.iconButton5.Size = new System.Drawing.Size(46, 42);
            this.iconButton5.TabIndex = 7;
            this.iconButton5.UseVisualStyleBackColor = true;
            this.iconButton5.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.AutoSize = true;
            this.iconButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton3.Dock = System.Windows.Forms.DockStyle.Right;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.ForeColor = System.Drawing.Color.Transparent;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.TimesSquare;
            this.iconButton3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton3.IconSize = 40;
            this.iconButton3.Location = new System.Drawing.Point(337, 0);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.iconButton3.Size = new System.Drawing.Size(46, 42);
            this.iconButton3.TabIndex = 6;
            this.iconButton3.UseVisualStyleBackColor = true;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(235, 46);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(68, 6, 0, 0);
            this.label3.Size = new System.Drawing.Size(333, 44);
            this.label3.TabIndex = 11;
            this.label3.Text = "Iniciar Sesión";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(84)))));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(346, 332);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(182, 35);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // icoVer
            // 
            this.icoVer.AutoSize = true;
            this.icoVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.icoVer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.icoVer.FlatAppearance.BorderSize = 0;
            this.icoVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icoVer.ForeColor = System.Drawing.Color.Transparent;
            this.icoVer.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            this.icoVer.IconColor = System.Drawing.Color.Black;
            this.icoVer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoVer.IconSize = 35;
            this.icoVer.Location = new System.Drawing.Point(508, 215);
            this.icoVer.Name = "icoVer";
            this.icoVer.Size = new System.Drawing.Size(41, 44);
            this.icoVer.TabIndex = 4;
            this.icoVer.UseCompatibleTextRendering = true;
            this.icoVer.UseVisualStyleBackColor = false;
            this.icoVer.Visible = false;
            this.icoVer.Click += new System.EventHandler(this.icoVer_Click);
            // 
            // icoUsuario
            // 
            this.icoUsuario.FlatAppearance.BorderSize = 0;
            this.icoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icoUsuario.ForeColor = System.Drawing.Color.Transparent;
            this.icoUsuario.IconChar = FontAwesome.Sharp.IconChar.UserLarge;
            this.icoUsuario.IconColor = System.Drawing.Color.Black;
            this.icoUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoUsuario.Location = new System.Drawing.Point(288, 124);
            this.icoUsuario.Name = "icoUsuario";
            this.icoUsuario.Size = new System.Drawing.Size(51, 49);
            this.icoUsuario.TabIndex = 17;
            this.icoUsuario.TabStop = false;
            this.icoUsuario.UseVisualStyleBackColor = true;
            // 
            // icoPass
            // 
            this.icoPass.FlatAppearance.BorderSize = 0;
            this.icoPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icoPass.ForeColor = System.Drawing.Color.Transparent;
            this.icoPass.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.icoPass.IconColor = System.Drawing.Color.Black;
            this.icoPass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icoPass.Location = new System.Drawing.Point(288, 215);
            this.icoPass.Name = "icoPass";
            this.icoPass.Size = new System.Drawing.Size(51, 49);
            this.icoPass.TabIndex = 16;
            this.icoPass.TabStop = false;
            this.icoPass.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(342, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "Este campo esta vacio";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(342, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 24);
            this.label5.TabIndex = 23;
            this.label5.Text = "Este campo esta vacio";
            this.label5.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(181)))), ((int)(((byte)(172)))));
            this.txtPassword.BordeColor = System.Drawing.Color.Black;
            this.txtPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(84)))));
            this.txtPassword.BorderSize = 4;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtPassword.Location = new System.Drawing.Point(346, 229);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtPassword.PasswordChar = false;
            this.txtPassword.ReadOnly = false;
            this.txtPassword.Size = new System.Drawing.Size(203, 33);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Texts = "Contraseña";
            this.txtPassword.UnderlinedStyle = true;
            this.txtPassword._TextChanged += new System.EventHandler(this.txtPassword__TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(181)))), ((int)(((byte)(172)))));
            this.txtUsuario.BordeColor = System.Drawing.Color.Black;
            this.txtUsuario.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(49)))), ((int)(((byte)(84)))));
            this.txtUsuario.BorderSize = 4;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtUsuario.Location = new System.Drawing.Point(346, 138);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.Multiline = false;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtUsuario.PasswordChar = false;
            this.txtUsuario.ReadOnly = false;
            this.txtUsuario.Size = new System.Drawing.Size(203, 33);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.Texts = "Usuario";
            this.txtUsuario.UnderlinedStyle = true;
            this.txtUsuario._TextChanged += new System.EventHandler(this.txtUsuario__TextChanged);
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(181)))), ((int)(((byte)(172)))));
            this.ClientSize = new System.Drawing.Size(614, 389);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.icoVer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.icoUsuario);
            this.Controls.Add(this.icoPass);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carwash Montevideo - Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private moonTextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private moonTextBox txtUsuario;
        private FontAwesome.Sharp.IconButton icoUsuario;
        private FontAwesome.Sharp.IconButton icoPass;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton icoVer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}