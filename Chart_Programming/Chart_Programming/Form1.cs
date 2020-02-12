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
using System.IO;

namespace Chart_Programming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ActEasyIF PLC;
        private void button1_Click(object sender, EventArgs e)
        {
            PLC = new ActEasyIF();
            PLC.ActLogicalStationNumber = 1;
            PLC.Open();

            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            short outData = 0x02;
            PLC.WriteDeviceBlock2("YO", 1, ref outData);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            short outData = 0x04;
            PLC.WriteDeviceBlock2("YO", 1, ref outData);
        }

        DateTime t_start;
        DateTime t_end;
        int turn = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            short data = 0;
            int x2 = 0;
            int x3 = 0;
            

            PLC.ReadDeviceBlock2("X0", 1, out data);
            x2 = data & 0x0004;
            x3 = data & 0x0008;

            if(x2 == 4 && turn == 1)
            {
                t_end = DateTime.Now;
                TimeSpan t = t_end - t_start;
                textBox1.Text = t.TotalMilliseconds.ToString();
                turn = 2;
            }
            if(x3 == 8 && turn == 2)
            {
                t_end = DateTime.Now;
                TimeSpan t = t_end - t_start;
                textBox2.Text = t.TotalMilliseconds.ToString();
                turn = 1;
            }

            if(x2 > 0)
            {
               
                chart1.Invoke(new MethodInvoker(delegate ()
                {
                    if (chart1.Series[0].Points.Count > 50) chart1.Series[0].Points.RemoveAt(0);

                    chart1.Series[0].Points.AddXY(DateTime.Now.ToString(), 1);
                    chart1.ChartAreas[0].RecalculateAxesScale();
                }));
            }
            else
            {
                t_start = DateTime.Now;
                
                chart1.Invoke(new MethodInvoker(delegate ()
                {
                    if (chart1.Series[0].Points.Count > 50) chart1.Series[0].Points.RemoveAt(0);

                    chart1.Series[0].Points.AddXY(DateTime.Now.ToString(), 0);
                    chart1.ChartAreas[0].RecalculateAxesScale();
                }));
            }
            if (x3 > 0)
            {

                chart1.Invoke(new MethodInvoker(delegate ()
                {
                    if (chart1.Series[1].Points.Count > 50) chart1.Series[1].Points.RemoveAt(0);

                    chart1.Series[1].Points.AddXY(DateTime.Now.ToString(), 1);
                    chart1.ChartAreas[0].RecalculateAxesScale();
                }));
            }
            else
            {
                t_start = DateTime.Now;
                chart1.Invoke(new MethodInvoker(delegate ()
                {
                    if (chart1.Series[1].Points.Count > 50) chart1.Series[1].Points.RemoveAt(0);

                    chart1.Series[1].Points.AddXY(DateTime.Now.ToString(), 0);
                    chart1.ChartAreas[0].RecalculateAxesScale();
                }));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            if(openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader file = new StreamReader(openFile.FileName);
                string line;
                string old_line = "";
                chart1.Series[0].Points.Clear();
                while((line = file.ReadLine()) != null)
                {
                    string[] splitData = line.Split(',');

                    if(splitData[1] != "전진센서")
                    {
                        continue;
                    }
                    if(old_line != "")
                    {
                        string[] old_splitData = old_line.Split(',');
                        int data = old_splitData[2] == "1" ? 1 : 0;
                        DateTime old_Time = Convert.ToDateTime(old_splitData[0]);
                        DateTime now_Time = Convert.ToDateTime(splitData[0]);

                        TimeSpan time = now_Time - old_Time;

                        for(int i = 0; i < (time.TotalMilliseconds / 100); i++)
                        {
                            DateTime t = old_Time.AddMilliseconds(i * 100);

                            chart1.Series[0].Points.AddXY(t.ToString(), data);
                            chart1.ChartAreas[0].RecalculateAxesScale();
                        }
                    }
                    old_line = line;
                }
                file.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CLogData logdata = new CLogData("Log");
            logdata.SaveText("전진센서,1");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CLogData logdata = new CLogData("Log");
            logdata.SaveText("전진센서,0");
        }
    }
}
