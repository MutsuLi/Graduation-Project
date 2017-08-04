using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;


namespace Device_Management
{
    public partial class forget :  Skin_Metro
    {
        string temp;
        public forget()
        {            
            InitializeComponent();
        }

        private void forget_Load(object sender, EventArgs e)
        {

        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            temp = "";
            for (int i = 0; i < 4; i++)
            {
                temp += r.Next(0, 9);
            }
            MailMessage message = new MailMessage();
            MailAddress fromAddr = new MailAddress("alucard_invidia@hotmail.com");
            message.From = fromAddr;
            message.To.Add(fp_em.Text.Trim());
            message.Subject ="测试";
            message.Body = temp;
            message.IsBodyHtml = true;
            message.Priority = MailPriority.Normal;
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
            client.Credentials = new NetworkCredential("alucard_invidia@hotmail.com", "ricardo0211");
            client.EnableSsl = true;
            client.Send(message);
            MessageBox.Show("邮件已发送，请耐心等待", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            DataTable dt = helper.ExecuteDataTable("select * from doctor_sheet where staff_id=@id", new SqlParameter("id", fp_id.Text));
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("工号不存在，请输入正确的工号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (fp_rcpwd.Text == fp_pwd.Text)
                {
                    if (fp_cas.Text != temp | fp_cas.Text == "")
                    {
                        MessageBox.Show("请根据发送到验证邮箱中的邮件，输入正确的验证码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        helper.ExecuteNonQuery("update user_sheet set pwd=@pwd where user_id=@id", new SqlParameter("pwd", fp_pwd.Text), new SqlParameter("id", fp_id.Text));
                        MessageBox.Show("密码修改成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        login obj = new login();
                        obj.Show();
                    }
                }
                else
                {
                    MessageBox.Show("两次输入密码不一致!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fp_pwd.Text = "";
                    fp_rcpwd.Text = "";
                }
            }
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Close();
            login obj = new login();
            obj.Show();
        }
    }
}
