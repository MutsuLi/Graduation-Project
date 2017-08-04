namespace Device_Management
{
    partial class forget
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(forget));
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.btn_return = new CCWin.SkinControl.SkinButton();
            this.fp_id = new CCWin.SkinControl.SkinWaterTextBox();
            this.fp_pwd = new CCWin.SkinControl.SkinWaterTextBox();
            this.fp_cas = new CCWin.SkinControl.SkinWaterTextBox();
            this.fp_em = new CCWin.SkinControl.SkinWaterTextBox();
            this.fp_rcpwd = new CCWin.SkinControl.SkinWaterTextBox();
            this.skinLabel147 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel146 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel145 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel143 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel142 = new CCWin.SkinControl.SkinLabel();
            this.btn_send = new CCWin.SkinControl.SkinButton();
            this.btn_submit = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.skinLabel1.Location = new System.Drawing.Point(11, 4);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(74, 21);
            this.skinLabel1.TabIndex = 55;
            this.skinLabel1.Text = "找回密码";
            // 
            // btn_return
            // 
            this.btn_return.BackColor = System.Drawing.Color.Transparent;
            this.btn_return.BaseColor = System.Drawing.Color.Transparent;
            this.btn_return.BorderColor = System.Drawing.Color.Transparent;
            this.btn_return.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_return.DownBack = null;
            this.btn_return.ForeColor = System.Drawing.Color.GhostWhite;
            this.btn_return.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btn_return.Location = new System.Drawing.Point(251, 4);
            this.btn_return.MouseBack = null;
            this.btn_return.Name = "btn_return";
            this.btn_return.NormlBack = null;
            this.btn_return.Size = new System.Drawing.Size(75, 23);
            this.btn_return.TabIndex = 57;
            this.btn_return.Text = "返回";
            this.btn_return.UseVisualStyleBackColor = false;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // fp_id
            // 
            this.fp_id.Location = new System.Drawing.Point(107, 87);
            this.fp_id.Name = "fp_id";
            this.fp_id.Size = new System.Drawing.Size(155, 21);
            this.fp_id.TabIndex = 63;
            this.fp_id.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.fp_id.WaterText = "请输入你的工号";
            // 
            // fp_pwd
            // 
            this.fp_pwd.Location = new System.Drawing.Point(107, 199);
            this.fp_pwd.Name = "fp_pwd";
            this.fp_pwd.PasswordChar = '●';
            this.fp_pwd.Size = new System.Drawing.Size(155, 21);
            this.fp_pwd.TabIndex = 64;
            this.fp_pwd.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.fp_pwd.WaterText = "请输入密码";
            // 
            // fp_cas
            // 
            this.fp_cas.Location = new System.Drawing.Point(107, 164);
            this.fp_cas.Name = "fp_cas";
            this.fp_cas.Size = new System.Drawing.Size(155, 21);
            this.fp_cas.TabIndex = 65;
            this.fp_cas.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.fp_cas.WaterText = "输入发送到邮箱的信息";
            // 
            // fp_em
            // 
            this.fp_em.Location = new System.Drawing.Point(107, 126);
            this.fp_em.Name = "fp_em";
            this.fp_em.Size = new System.Drawing.Size(155, 21);
            this.fp_em.TabIndex = 66;
            this.fp_em.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.fp_em.WaterText = "正确输入你的邮箱";
            // 
            // fp_rcpwd
            // 
            this.fp_rcpwd.Location = new System.Drawing.Point(107, 233);
            this.fp_rcpwd.Name = "fp_rcpwd";
            this.fp_rcpwd.PasswordChar = '●';
            this.fp_rcpwd.Size = new System.Drawing.Size(155, 21);
            this.fp_rcpwd.TabIndex = 67;
            this.fp_rcpwd.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.fp_rcpwd.WaterText = "请再次输入密码";
            // 
            // skinLabel147
            // 
            this.skinLabel147.AutoSize = true;
            this.skinLabel147.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel147.BorderColor = System.Drawing.Color.White;
            this.skinLabel147.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel147.ForeColor = System.Drawing.Color.Black;
            this.skinLabel147.Location = new System.Drawing.Point(47, 165);
            this.skinLabel147.Name = "skinLabel147";
            this.skinLabel147.Size = new System.Drawing.Size(54, 20);
            this.skinLabel147.TabIndex = 61;
            this.skinLabel147.Text = "验证码:";
            // 
            // skinLabel146
            // 
            this.skinLabel146.AutoSize = true;
            this.skinLabel146.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel146.BorderColor = System.Drawing.Color.White;
            this.skinLabel146.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel146.ForeColor = System.Drawing.Color.Black;
            this.skinLabel146.Location = new System.Drawing.Point(61, 127);
            this.skinLabel146.Name = "skinLabel146";
            this.skinLabel146.Size = new System.Drawing.Size(40, 20);
            this.skinLabel146.TabIndex = 62;
            this.skinLabel146.Text = "邮箱:";
            // 
            // skinLabel145
            // 
            this.skinLabel145.AutoSize = true;
            this.skinLabel145.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel145.BorderColor = System.Drawing.Color.White;
            this.skinLabel145.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel145.ForeColor = System.Drawing.Color.Black;
            this.skinLabel145.Location = new System.Drawing.Point(33, 234);
            this.skinLabel145.Name = "skinLabel145";
            this.skinLabel145.Size = new System.Drawing.Size(68, 20);
            this.skinLabel145.TabIndex = 58;
            this.skinLabel145.Text = "确认密码:";
            // 
            // skinLabel143
            // 
            this.skinLabel143.AutoSize = true;
            this.skinLabel143.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel143.BorderColor = System.Drawing.Color.White;
            this.skinLabel143.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel143.ForeColor = System.Drawing.Color.Black;
            this.skinLabel143.Location = new System.Drawing.Point(47, 199);
            this.skinLabel143.Name = "skinLabel143";
            this.skinLabel143.Size = new System.Drawing.Size(54, 20);
            this.skinLabel143.TabIndex = 59;
            this.skinLabel143.Text = "新密码:";
            // 
            // skinLabel142
            // 
            this.skinLabel142.AutoSize = true;
            this.skinLabel142.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel142.BorderColor = System.Drawing.Color.White;
            this.skinLabel142.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel142.ForeColor = System.Drawing.Color.Black;
            this.skinLabel142.Location = new System.Drawing.Point(54, 88);
            this.skinLabel142.Name = "skinLabel142";
            this.skinLabel142.Size = new System.Drawing.Size(51, 20);
            this.skinLabel142.TabIndex = 60;
            this.skinLabel142.Text = "账号：";
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.Transparent;
            this.btn_send.BaseColor = System.Drawing.Color.Transparent;
            this.btn_send.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_send.DownBack = null;
            this.btn_send.Location = new System.Drawing.Point(267, 124);
            this.btn_send.MouseBack = null;
            this.btn_send.Name = "btn_send";
            this.btn_send.NormlBack = null;
            this.btn_send.Size = new System.Drawing.Size(49, 23);
            this.btn_send.TabIndex = 68;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_submit
            // 
            this.btn_submit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_submit.BackColor = System.Drawing.Color.Transparent;
            this.btn_submit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_submit.BackRectangle = new System.Drawing.Rectangle(50, 23, 50, 23);
            this.btn_submit.BaseColor = System.Drawing.Color.Black;
            this.btn_submit.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_submit.DownBack = ((System.Drawing.Image)(resources.GetObject("btn_submit.DownBack")));
            this.btn_submit.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btn_submit.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_submit.ForeColor = System.Drawing.Color.Black;
            this.btn_submit.Location = new System.Drawing.Point(194, 279);
            this.btn_submit.Margin = new System.Windows.Forms.Padding(0);
            this.btn_submit.MouseBack = ((System.Drawing.Image)(resources.GetObject("btn_submit.MouseBack")));
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.NormlBack = ((System.Drawing.Image)(resources.GetObject("btn_submit.NormlBack")));
            this.btn_submit.Palace = true;
            this.btn_submit.Size = new System.Drawing.Size(68, 26);
            this.btn_submit.TabIndex = 69;
            this.btn_submit.Text = "提交";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // forget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 352);
            this.ControlBox = false;
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.fp_id);
            this.Controls.Add(this.fp_pwd);
            this.Controls.Add(this.fp_cas);
            this.Controls.Add(this.fp_em);
            this.Controls.Add(this.fp_rcpwd);
            this.Controls.Add(this.skinLabel147);
            this.Controls.Add(this.skinLabel146);
            this.Controls.Add(this.skinLabel145);
            this.Controls.Add(this.skinLabel143);
            this.Controls.Add(this.skinLabel142);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.skinLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "forget";
            this.ShowDrawIcon = false;
            this.Text = "";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinButton btn_return;
        private CCWin.SkinControl.SkinWaterTextBox fp_id;
        private CCWin.SkinControl.SkinWaterTextBox fp_pwd;
        private CCWin.SkinControl.SkinWaterTextBox fp_cas;
        private CCWin.SkinControl.SkinWaterTextBox fp_em;
        private CCWin.SkinControl.SkinWaterTextBox fp_rcpwd;
        private CCWin.SkinControl.SkinLabel skinLabel147;
        private CCWin.SkinControl.SkinLabel skinLabel146;
        private CCWin.SkinControl.SkinLabel skinLabel145;
        private CCWin.SkinControl.SkinLabel skinLabel143;
        private CCWin.SkinControl.SkinLabel skinLabel142;
        private CCWin.SkinControl.SkinButton btn_send;
        private CCWin.SkinControl.SkinButton btn_submit;
    }
}