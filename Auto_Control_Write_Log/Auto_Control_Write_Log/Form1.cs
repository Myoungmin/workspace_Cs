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

namespace Auto_Control_Write_Log
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ActEasyIF PLC;
        CFileWriter writer = new CFileWriter("Sensors");
        private void Form1_Load(object sender, EventArgs e)
        {
            PLC = new ActEasyIF();
            PLC.ActLogicalStationNumber = 1;
            PLC.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            short outData = 0x02;
            PLC.WriteDeviceBlock2("YO", 1, ref outData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            short outData = 0x04;
            PLC.WriteDeviceBlock2("YO", 1, ref outData);
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void EndBTN_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        bool old_Lift;
        bool old_Forward;
        bool old_Backward;
        bool cylinder;
        bool old_Cylinder;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PLC != null)
            {
                short sensor = 0;
                PLC.ReadDeviceBlock2("XO", 1, out sensor);
                bool forward = (sensor & 0x04) != 0 ? true : false;
                bool backward = (sensor & 0x08) != 0 ? true : false;
                bool lift = (sensor & 0x400) != 0 ? true : false;

                if (lift == true && backward == true)   //계속 같은값 입력되는것 방지
                {
                    cylinder = true;
                }
                else if (lift == false && forward == true)
                {
                    cylinder = false;
                }

                if(old_Cylinder != cylinder)
                {
                    if(cylinder)
                    {
                        short outData = 0x02;
                        PLC.WriteDeviceBlock2("YO", 1, ref outData);
                    }
                    else
                    {
                        short outData = 0x04;
                        PLC.WriteDeviceBlock2("YO", 1, ref outData);
                    }
                    old_Cylinder = cylinder;
                }


                if (old_Lift != lift)
                {
                    if (lift) writer.SaveText("리프트센서 ON");
                    else writer.SaveText("리프트센서 OFF");
                    old_Lift = lift;
                }
                if (old_Forward != forward)
                {
                    if (forward) writer.SaveText(" 전진센서 ON");
                    else writer.SaveText("전진센서 OFF");
                    old_Forward = forward;
                }
                if (old_Backward != backward)
                {
                    if (backward) writer.SaveText(" 후진센서 ON");
                    else writer.SaveText("후진센서 OFF");
                    old_Backward = backward;
                }
            }
        }
    }
}
