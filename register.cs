using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CCWin;
namespace Device_Management
{
    public partial class register : Skin_Metro
    {
        Captchahelper.Captcha temp;
        public register()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            temp = Captchahelper.captcha(p_checkb);
            p_checkb.Image = temp.bmp;
        }

        private void p_checkb_Click(object sender, EventArgs e)
        {
            temp = Captchahelper.captcha(p_checkb);
            p_checkb.Image = temp.bmp;
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Close();
            login obj = new login();
            obj.Show();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            DataTable dt = helper.ExecuteDataTable("select * from doctor_sheet where staff_id=@id", new SqlParameter("id", md_id.Text));
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("工号不存在，请输入正确的工号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (md_rcpwd.Text == md_pwd.Text)
                {
                    if (md_check.Text == temp.check)
                    {
                        string date= DateTime.Now.ToString("yyyy/MM/dd"); 
                        helper.ExecuteNonQuery("insert into user_sheet values(@uid,@pwd,@et,@privilege,@rt,@cd,@gender,@name,@errt,@status) ", new SqlParameter("uid", md_id.Text), new SqlParameter("pwd", md_pwd.Text), new SqlParameter("et", '0'), new SqlParameter("privilege", '0'), new SqlParameter("rt", date), new SqlParameter("cd", md_cd.Text), new SqlParameter("gender","" ), new SqlParameter("name", ""), new SqlParameter("errt", ""), new SqlParameter("status", "normal"));
                        MessageBox.Show("注册成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        login obj = new login();
                        obj.Show();
                    }
                    else
                    {
                        MessageBox.Show("验证码错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        temp = Captchahelper.captcha(p_checkb);
                        p_checkb.Image = temp.bmp;
                    }
                }
                else
                {
                    MessageBox.Show("两次输入密码不一致!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    temp = Captchahelper.captcha(p_checkb);
                    p_checkb.Image = temp.bmp;
                    md_pwd.Text = "";
                    md_rcpwd.Text = "";
                }
            }
        }
               
    }
}
