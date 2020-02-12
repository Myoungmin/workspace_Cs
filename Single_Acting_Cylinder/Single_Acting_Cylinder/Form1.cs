using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACTMULTILIB_K;

namespace Single_Acting_Cylinder
{
    public partial class Form1 : Form
    {
        ActEasyIF PLC;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //연결 버튼
            PLC = new ActEasyIF();
            PLC.ActLogicalStationNumber = 1;
            PLC.Open();
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //전진 버튼
            short data = 0x02;
            PLC.WriteDeviceBlock2("YO", 1, ref data);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //후진 버튼
            short data = 0x04;
            PLC.WriteDeviceBlock2("YO", 1, ref data);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            short data = 0;
            int x2 = 0;
            int x3 = 0;
            PLC.ReadDeviceBlock2("XO", 1, out data);

            x2 = data & 0x0004;
            x3 = data & 0x0008;

            if (x2 != 0)
                label2.Text = "전진";
            else if (x3 != 0)
                label2.Text = "후진";
            else
                label2.Text = "이동중";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            short data = 0;
            short input_data = 0;
            int x2 = 0;
            int x3 = 0;
            PLC.ReadDeviceBlock2("XO", 1, out data);

            x2 = data & 0x0004;
            x3 = data & 0x0008;

            if (x2 != 0)
            {
                label4.Text = "전진";
                input_data = 0x04;
                PLC.WriteDeviceBlock2("YO", 1, ref input_data);
            }
                
            else if (x3 != 0)
            {
                label4.Text = "후진";
                input_data = 0x02;
                PLC.WriteDeviceBlock2("YO", 1, ref input_data);
            }
                
            else
                label4.Text = "이동중";
        }
    }
}
