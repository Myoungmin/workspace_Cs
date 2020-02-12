using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atmega128_Timer_Calculator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private string Form2_value;

        public string Passvalue
        {
            get { return this.Form2_value; }
            set { this.Form2_value = value; }  // 다른폼(Form1)에서 전달받은 값을 쓰기
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            textBox4.Text = Passvalue; // 다른폼(Form1)에서 전달받은 값을 변수에 저장
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();    //다시 새로 그리기 위해
            double[] clk2 = new double[] { 1, 8, 64, 256, 1024 };
            try
            {
                if(Convert.ToDouble(textBox4.Text) <= 0) MessageBox.Show("PWM Period에 양수를 입력해 주세요");
                else if(string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox1.Text = (Convert.ToDouble(textBox4.Text) * Convert.ToDouble(textBox2.Text) / 100).ToString();
                }
                else if(Convert.ToDouble(textBox1.Text) < 0 || Convert.ToDouble(textBox1.Text) > Convert.ToDouble(textBox4.Text))
                {
                    MessageBox.Show("Duty Cycle에는 PWM Period보다 작거나 같은 양수 숫자");
                }
                else
                {
                    textBox2.Text = ((double)100 * Convert.ToDouble(textBox1.Text) / Convert.ToDouble(textBox4.Text)).ToString();
                    //chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#.##";

                    

                    //chart1.ChartAreas[0].AxisX.Interval = 1;
                    //for (int i = 0; i < 3; i++)
                    //{
                    //    chart1.Series[0].Points.AddXY(Convert.ToDouble(textBox4.Text) * i + Convert.ToDouble(textBox1.Text), 0);
                    //    chart1.Series[0].Points.AddXY(Convert.ToDouble(textBox4.Text) * (i + 1), 1);
                    //}

                    for (double j = 0; j < 3; j++)
                    {
                        for (double i = 0; i < Convert.ToDouble(textBox4.Text); i = i + (Convert.ToDouble(textBox4.Text) / 20.0))
                        {
                            if (i < Convert.ToDouble(textBox1.Text)) chart1.Series[0].Points.AddXY(Convert.ToDouble(textBox4.Text) * j + i, 1);
                            else chart1.Series[0].Points.AddXY(Convert.ToDouble(textBox4.Text) * j + i, 0);
                        }
                    }


                    chart1.ChartAreas[0].AxisX.IsMarginVisible = false; //이걸 넣어야 x축이 딱 붙어서 출력된다!!

                    //chart1.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(textBox4.Text) * 3.0;   //이렇게 맥시멈이 값으로 넣어야할 줄 알았는데
                    chart1.ChartAreas[0].AxisX.Maximum = chart1.Series[0].Points.Count; //최고값 개수를 넣어야 된다!!!!

                    chart1.ChartAreas[0].AxisY.Maximum = 1.0;

                    //chart1.ChartAreas[0].AxisX.Interval = Convert.ToDouble(textBox4.Text) / 20.0; //간격도 이렇게 값으로 들어가야 할줄 알았는데
                    chart1.ChartAreas[0].AxisX.Interval = 1;    //칸 개수가 들어가야 한다!!!


                    
                    if (!string.IsNullOrEmpty(comboBox2.Text))
                    {
                        try
                        {
                            double ICR = Convert.ToDouble(textBox4.Text) / (0.0000000625 * clk2[comboBox2.SelectedIndex]);
                            double OCR = Convert.ToDouble(textBox1.Text) / (0.0000000625 * clk2[comboBox2.SelectedIndex]);

                            if (ICR > 65535)
                            {
                                textBox3.Text = "16비트를 벗어남";
                                textBox5.Text = null;
                            }
                            else
                            {
                                textBox3.Text = ICR.ToString();
                                textBox5.Text = OCR.ToString();
                            }
                        }
                        catch { }
                    }
                    
                }
            }
            catch
            {
                MessageBox.Show("숫자를 입력해주세요.");
            }
        }
    }
}
