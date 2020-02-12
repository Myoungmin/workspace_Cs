using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Save_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //CFileWriter writer = new CFileWriter();

        private void button1_Click(object sender, EventArgs e)
        {
            //writer.SaveText("전진클릭");
            CFileWriter.SaveText("전진클릭");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //writer.SaveText("후진클릭");
            CFileWriter.SaveText("후진클릭");
        }
    }
}
