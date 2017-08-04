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
using System.Xml;
using System.Globalization;

namespace Device_Management
{
    public partial class login : Skin_Metro
    {
        public login()
        {
            InitializeComponent();
             
        }

        public delegate void MyDelegate(object sender, MyEventArgs e);
        public event MyDelegate MyEvent;
        private void login_check()
        {
            DataTable dt = helper.ExecuteDataTable("select * from user_sheet where user_id=@id", new SqlParameter("id", user_id.Text));
            DataRow dr = dt.Rows[0];
            string user_name = dr["name"].ToString();
            string id = dr["user_id"].ToString();
            string status = dr["status"].ToString();
            int errortimes = Convert.ToInt32(dr["error_time"]);
            int user_type = Convert.ToInt32(dr["privilege"]);
            string dbPassword = Convert.ToString(dr["pwd"]);
            if (dbPassword == user_password.Text)
            {
                string temp = DateTime.Now.ToString();
                MyEventArgs userdata = new MyEventArgs();
                userdata.name = user_name;
                userdata.id = id;
                userdata.privilege = user_type;
                main obj = new main();
                this.MyEvent += new MyDelegate(obj.userdata);
                MyEvent(this, userdata);
                MessageBox.Show("欢迎" + user_id.Text + "登录！");
                this.Hide();
                obj.Show();
                helper.ExecuteNonQuery("Update user_sheet Set error_time=0 where user_id=@id", new SqlParameter("id", user_id.Text));
                helper.ExecuteNonQuery("Update user_sheet Set status=@st where user_id=@id", new SqlParameter("st", "normal"), new SqlParameter("id", user_id.Text));
            }
            else
            {
                helper.ExecuteNonQuery("Update user_sheet Set error_time=error_time+1 where user_id=@id", new SqlParameter("id", user_id.Text));
                MessageBox.Show("密码错误！");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = helper.ExecuteDataTable("select * from user_sheet where user_id=@id", new SqlParameter("id", user_id.Text));
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("用户名不存在");
                return;
            }
            else
            {
                DataRow dr = dt.Rows[0];
                string user_name = dr["name"].ToString();
                string id = dr["user_id"].ToString();
                string status = dr["status"].ToString();//读取账号当前状态
                int errortimes = Convert.ToInt32(dr["error_time"]);
                int user_type = Convert.ToInt32(dr["privilege"]);
                if (status == "normal")
                {
                    if (errortimes >= 3)
                    {
                        DateTime CurrTime = DateTime.Now;
                        DateTime ErrDiffTime = CurrTime.Add(new TimeSpan(0, 5, 0)); //用于记录锁定账号解锁的时间
                        string temp = ErrDiffTime.ToString();
                        helper.ExecuteNonQuery("Update user_sheet Set errtime=@et where user_id=@id", new SqlParameter("et", temp), new SqlParameter("id", user_id.Text));//更新最近登录时间
                        helper.ExecuteNonQuery("Update user_sheet Set status=@st where user_id=@id", new SqlParameter("st", "lock"), new SqlParameter("id", user_id.Text));//锁定账号
                        MessageBox.Show("登录错误次数太多,账号暂时冻结5分钟！");
                        return;
                    }
                    login_check();//登录验证
                }
                else
                {
                    string et = dr["errtime"].ToString();
                    string dbPassword = Convert.ToString(dr["pwd"]);
                    DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                    dtFormat.ShortDatePattern = "yyyy/MM/dd";
                    DateTime errtime = Convert.ToDateTime(et, dtFormat);
                    DateTime tem = DateTime.Now;
                    if (errtime > tem)//判断锁定账号是否达到解锁时间
                    {
                        MessageBox.Show("登录错误次数太多,账号暂时冻结5分钟！");
                    }
                    else
                    {
                        login_check();
                    } 
                   }               
               }              
         }



        #region 窗体移动

        private bool formMove = false;//窗体是否移动

        private Point formPoint;//记录窗体的位置
        private void Form1_MouseDown(object sender, MouseEventArgs e)

        {

            formPoint = new Point();

            int xOffset;

            int yOffset;

            if (e.Button == MouseButtons.Left)

            {

                xOffset = -e.X;// -SystemInformation.FrameBorderSize.Width;

                yOffset = -e.Y;// -SystemInformation.FrameBorderSize.Height; ;

                formPoint = new Point(xOffset, yOffset);

                formMove = true;//开始移动

            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)

        {

            if (formMove == true)

            {

                Point mousePos = Control.MousePosition;

                mousePos.Offset(formPoint.X, formPoint.Y);

                Location = mousePos;

            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)

        {

            if (e.Button == MouseButtons.Left)//按下的是鼠标左键

            {

                formMove = false;//停止移动

            }

        }

        #endregion

        private void btn_register_Click(object sender, EventArgs e)
        {
            this.Hide();
            register obj = new register();
            obj.Show();
        }

        private void btn_forget_Click(object sender, EventArgs e)
        {
            this.Hide();
            forget obj = new forget();
            obj.Show();
        }

        private void login_Load(object sender, EventArgs e)
        {
           
        }
    }
}
