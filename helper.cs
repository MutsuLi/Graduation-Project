using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace Device_Management
{
    public class MyEventArgs : EventArgs
    {
        public string id;
        public string name;
        public int privilege;
    }

    public class Captchahelper
    {
        public class Captcha
        {
            public Bitmap bmp;//用于控件获取的图片
            public string check;//用于记录随机生成的验证码
        }
       
        public static Captcha captcha(CCWin.SkinControl.SkinPictureBox pb)
        {

            Random r = new Random();
            Captcha captcha = new Captcha();
            string[] fontString = new string[] { "黑体", "幼圆", "楷体", "华文仿宋" };
            Color[] colorArray = new Color[] { Color.Blue, Color.Black, Color.Red, Color.Purple };

            string strNumbers = "";

            Bitmap bmp = new Bitmap(pb.Width, pb.Height);
            Graphics g = Graphics.FromImage(bmp);

            //生成4个数字、点、字体、颜色，画出来  
            for (int i = 0; i < 4; i++)
            {
                strNumbers += r.Next(0, 9);

                Point pt = new Point(i * 20, 0);
                g.DrawString(strNumbers[i].ToString(), new Font(fontString[i], 20),
                 new SolidBrush(colorArray[r.Next(3)]), pt);
            }

            //随机画几条直线  
            for (int i = 0; i < 10; i++)
            {
                Point p1 = new Point(r.Next(bmp.Width), r.Next(bmp.Height));
                Point p2 = new Point(r.Next(bmp.Width), r.Next(bmp.Height));
                g.DrawLine(new Pen(colorArray[i % 4]), p1, p2);
            }

            //随机画一些点  
            for (int i = 0; i < 200; i++)
            {
                bmp.SetPixel(r.Next(bmp.Width), r.Next(bmp.Height), colorArray[i % 4]);
            }
            captcha.bmp = bmp;
            captcha.check = strNumbers;
            return captcha; //返回验证码类Captcha的一个对象
        }

    }

    class helper
    {
        public static int ExecuteNonQuery(string sql, params SqlParameter[] paramters)
            //主要运用在数据更新，插入等改变数据的情况下
        {
            String connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //ConStr 数据库连接字符串存储在App.config
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    foreach (SqlParameter parameter in paramters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    return cmd.ExecuteNonQuery();
                }

            }
        }
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
            //主要运用于查询数据，可与显示数据组件结合使用
        {
            String connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    foreach (SqlParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    DataSet ds = new DataSet();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                    return ds.Tables[0]; //返回查询到的表数据
                }
            }
        }
        public static object ExecuteScalar(string sql, params SqlParameter[] paramters)
        {
            String connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    foreach (SqlParameter parameter in paramters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

    }
}
    

