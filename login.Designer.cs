namespace Device_Management
{
    partial class login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.user_password = new CCWin.SkinControl.SkinTextBox();
            this.user_id = new CCWin.SkinControl.SkinTextBox();
            this.btn_lgn = new CCWin.SkinControl.SkinButton();
            this.btn_register = new CCWin.SkinControl.SkinButton();
            this.btn_forget = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // user_password
            // 
            this.user_password.BackColor = System.Drawing.Color.Transparent;
            this.user_password.DownBack = null;
            this.user_password.Icon = null;
            this.user_password.IconIsButton = true;
            this.user_password.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.user_password.IsPasswordChat = '●';
            this.user_password.IsSystemPasswordChar = false;
            this.user_password.Lines = new string[0];
            this.user_password.Location = new System.Drawing.Point(116, 142);
            this.user_password.Margin = new System.Windows.Forms.Padding(0);
            this.user_password.MaxLength = 32767;
            this.user_password.MinimumSize = new System.Drawing.Size(0, 28);
            this.user_password.MouseBack = null;
            this.user_password.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.user_password.Multiline = false;
            this.user_password.Name = "user_password";
            this.user_password.NormlBack = null;
            this.user_password.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.user_password.ReadOnly = false;
            this.user_password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.user_password.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.user_password.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.user_password.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_password.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.user_password.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.user_password.SkinTxt.Name = "BaseText";
            this.user_password.SkinTxt.PasswordChar = '●';
            this.user_password.SkinTxt.Size = new System.Drawing.Size(152, 18);
            this.user_password.SkinTxt.TabIndex = 0;
            this.user_password.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.user_password.SkinTxt.WaterText = "密码";
            this.user_password.TabIndex = 38;
            this.user_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.user_password.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.user_password.WaterText = "密码";
            this.user_password.WordWrap = true;
            // 
            // user_id
            // 
            this.user_id.BackColor = System.Drawing.Color.Transparent;
            this.user_id.DownBack = null;
            this.user_id.Icon = null;
            this.user_id.IconIsButton = false;
            this.user_id.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.user_id.IsPasswordChat = '\0';
            this.user_id.IsSystemPasswordChar = false;
            this.user_id.Lines = new string[0];
            this.user_id.Location = new System.Drawing.Point(116, 107);
            this.user_id.Margin = new System.Windows.Forms.Padding(0);
            this.user_id.MaxLength = 32767;
            this.user_id.MinimumSize = new System.Drawing.Size(28, 28);
            this.user_id.MouseBack = null;
            this.user_id.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.user_id.Multiline = false;
            this.user_id.Name = "user_id";
            this.user_id.NormlBack = null;
            this.user_id.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.user_id.ReadOnly = false;
            this.user_id.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.user_id.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.user_id.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.user_id.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_id.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.user_id.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.user_id.SkinTxt.Name = "BaseText";
            this.user_id.SkinTxt.Size = new System.Drawing.Size(152, 18);
            this.user_id.SkinTxt.TabIndex = 0;
            this.user_id.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.user_id.SkinTxt.WaterText = "账号（工号）";
            this.user_id.TabIndex = 37;
            this.user_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.user_id.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.user_id.WaterText = "账号（工号）";
            this.user_id.WordWrap = true;
            // 
            // btn_lgn
            // 
            this.btn_lgn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_lgn.BackColor = System.Drawing.Color.Transparent;
            this.btn_lgn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_lgn.BackRectangle = new System.Drawing.Rectangle(50, 23, 50, 23);
            this.btn_lgn.BaseColor = System.Drawing.Color.Black;
            this.btn_lgn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_lgn.DownBack = ((System.Drawing.Image)(resources.GetObject("btn_lgn.DownBack")));
            this.btn_lgn.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_lgn.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_lgn.ForeColor = System.Drawing.Color.Black;
            this.btn_lgn.Location = new System.Drawing.Point(127, 193);
            this.btn_lgn.Margin = new System.Windows.Forms.Padding(0);
            this.btn_lgn.MouseBack = ((System.Drawing.Image)(resources.GetObject("btn_lgn.MouseBack")));
            this.btn_lgn.Name = "btn_lgn";
            this.btn_lgn.NormlBack = ((System.Drawing.Image)(resources.GetObject("btn_lgn.NormlBack")));
            this.btn_lgn.Palace = true;
            this.btn_lgn.Size = new System.Drawing.Size(162, 38);
            this.btn_lgn.TabIndex = 40;
            this.btn_lgn.Text = "登        录";
            this.btn_lgn.UseVisualStyleBackColor = false;
            this.btn_lgn.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_register
            // 
            this.btn_register.BackColor = System.Drawing.Color.Transparent;
            this.btn_register.BaseColor = System.Drawing.Color.Transparent;
            this.btn_register.BorderColor = System.Drawing.Color.Transparent;
            this.btn_register.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_register.DownBack = null;
            this.btn_register.ForeColor = System.Drawing.Color.GhostWhite;
            this.btn_register.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btn_register.Location = new System.Drawing.Point(304, 107);
            this.btn_register.MouseBack = null;
            this.btn_register.Name = "btn_register";
            this.btn_register.NormlBack = null;
            this.btn_register.Size = new System.Drawing.Size(75, 28);
            this.btn_register.TabIndex = 41;
            this.btn_register.Text = "注册账号\r\n";
            this.btn_register.UseVisualStyleBackColor = false;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // btn_forget
            // 
            this.btn_forget.BackColor = System.Drawing.Color.Transparent;
            this.btn_forget.BaseColor = System.Drawing.Color.Transparent;
            this.btn_forget.BorderColor = System.Drawing.Color.Transparent;
            this.btn_forget.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_forget.DownBack = null;
            this.btn_forget.ForeColor = System.Drawing.Color.GhostWhite;
            this.btn_forget.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btn_forget.Location = new System.Drawing.Point(304, 142);
            this.btn_forget.MouseBack = null;
            this.btn_forget.Name = "btn_forget";
            this.btn_forget.NormlBack = null;
            this.btn_forget.Size = new System.Drawing.Size(75, 28);
            this.btn_forget.TabIndex = 41;
            this.btn_forget.Text = "忘记密码?";
            this.btn_forget.UseVisualStyleBackColor = false;
            this.btn_forget.Click += new System.EventHandler(this.btn_forget_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = ((System.Drawing.Image)(resources.GetObject("$this.Back")));
            this.BackPalace = ((System.Drawing.Image)(resources.GetObject("$this.BackPalace")));
            this.ClientSize = new System.Drawing.Size(407, 311);
            this.CloseDownBack = null;
            this.CloseMouseBack = null;
            this.CloseNormlBack = null;
            this.Controls.Add(this.btn_forget);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.btn_lgn);
            this.Controls.Add(this.user_password);
            this.Controls.Add(this.user_id);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.Text = "";
            this.Load += new System.EventHandler(this.login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinTextBox user_password;
        private CCWin.SkinControl.SkinTextBox user_id;
        private CCWin.SkinControl.SkinButton btn_lgn;
        private CCWin.SkinControl.SkinButton btn_register;
        private CCWin.SkinControl.SkinButton btn_forget;
    }
}

