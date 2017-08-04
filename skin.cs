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
using System.IO;

namespace Device_Management
{
    public delegate void changeImg(Image img);
    public delegate void changeiro(Color iro);
    public partial class skin : Skin_Metro
    {
        
        public event changeImg Eventimg;
        public event changeiro Eventiro;
        public skin()
        {
            InitializeComponent();
        }

        private void skin_Load(object sender, EventArgs e)
        {

        }

        private void skinPictureBox1_Click(object sender, EventArgs e)
        {
            Image img = Properties.Resources.blue;
            Eventimg(img);
        }

        private void skinPictureBox5_Click(object sender, EventArgs e)
        {
            Color iro = Color.Indigo;
            Eventiro(iro);
        }

        private void skinPictureBox4_Click(object sender, EventArgs e)
        {
            Color iro = Color.Teal;
            Eventiro(iro);
        }

        private void skinPictureBox2_Click(object sender, EventArgs e)
        {
            Color iro = Color.Gray;
            Eventiro(iro);
        }

        private void skinPictureBox6_Click(object sender, EventArgs e)
        {
            Color iro = Color.Crimson;
            Eventiro(iro);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog obj = new OpenFileDialog();
            obj.Filter = "图像文件(*.jpg;*.gif;*.bmp)|*.jpg;*.gif;*.bmp";
            obj.ShowDialog();
            if (obj.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(obj.FileName);
                Eventimg(img);
            }
        }

        private void skinPictureBox3_Click(object sender, EventArgs e)
        {
            Color iro = Color.Cyan;
            Eventiro(iro);
        }
    }
}
