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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "타이머 0 (8 bit)")
            {
                comboBox2.Enabled = true;
                comboBox2.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                comboBox2.Items.Clear();
                comboBox2.Items.Add("clk / 1");
                comboBox2.Items.Add("clk / 8");
                comboBox2.Items.Add("clk / 32");
                comboBox2.Items.Add("clk / 64");
                comboBox2.Items.Add("clk / 128");
                comboBox2.Items.Add("clk / 256");
                comboBox2.Items.Add("clk / 1024");
                label13.Text = "Normal Mode \r\n(오버플로우 인터럽트)\r\n256 - (TCNT)";
            }
            else if(comboBox1.Text == "타이머 1, 3 (16 bit)")
            {
                comboBox2.Enabled = true;
                comboBox2.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                comboBox2.Items.Clear();
                comboBox2.Items.Add("clk / 1");
                comboBox2.Items.Add("clk / 8");
                comboBox2.Items.Add("clk / 64");
                comboBox2.Items.Add("clk / 256");
                comboBox2.Items.Add("clk / 1024");
                label13.Text = "Normal Mode \r\n(오버플로우 인터럽트)\r\n65536 - (TCNT)";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double result_time;
            double result_frequency;
            double[] timer = new double[] { 256, 65536 };
            double[] clk1 = new double[] { 1, 8, 32, 64, 128, 256, 1024 };
            double[] clk2 = new double[] { 1, 8, 64, 256, 1024 };
            try
            {
                if(comboBox1.SelectedIndex == 0) result_time = clk1[comboBox2.SelectedIndex] * Convert.ToDouble(textBox2.Text) / Convert.ToDouble(textBox1.Text);
                else result_time = clk2[comboBox2.SelectedIndex] * Convert.ToDouble(textBox2.Text) / Convert.ToDouble(textBox1.Text);

                result_frequency = 1 / result_time;

                if (Convert.ToDouble(textBox2.Text) > timer[comboBox1.SelectedIndex] || Convert.ToDouble(textBox2.Text) <= 0)
                {
                    MessageBox.Show("0보다 크커나 TOP 보다 작은 값을 입력하세요.");
                }
                else
                {
                    label13.Text = "Normal Mode \r\n(오버플로우 인터럽트)\r\nTOP - " + (timer[comboBox1.SelectedIndex] - Convert.ToDouble(textBox2.Text)).ToString() + "(TCNT)";

                    textBox3.Text = result_time.ToString();
                    textBox4.Text = result_frequency.ToString();
                }
            }
            catch { MessageBox.Show("타이머, 분주비를 선택하거나\n숫자를 입력해주세요."); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double result_TCNT;
            double result_frequency;
            double[] timer = new double[] { 256, 65536 };
            double[] clk1 = new double[] { 1, 8, 32, 64, 128, 256, 1024 };
            double[] clk2 = new double[] { 1, 8, 64, 256, 1024 };
            try
            {
                if(Convert.ToDouble(textBox3.Text) > 4.194304) MessageBox.Show("16 비트 최대 타이머 주기를 초과합니다.");
                else if(Convert.ToDouble(textBox3.Text) < 1 / Convert.ToDouble(textBox1.Text)) MessageBox.Show("시스템 클럭보다도 주기가 짧습니다.");

                if (comboBox1.SelectedIndex == 0) result_TCNT = Convert.ToDouble(textBox3.Text) * Convert.ToDouble(textBox1.Text) / clk1[comboBox2.SelectedIndex];
                else result_TCNT = Convert.ToDouble(textBox3.Text) * Convert.ToDouble(textBox1.Text) / clk2[comboBox2.SelectedIndex];

                result_frequency = 1 / Convert.ToDouble(textBox3.Text);

                if (result_TCNT > timer[comboBox1.SelectedIndex])
                {
                    label8.ForeColor = Color.Red;
                    label8.Text = "높은 분주비를 사용하세요.";
                }
                else if (result_TCNT < 1)
                {
                    label8.ForeColor = Color.Red;
                    label8.Text = "낮은 분주비를 사용하세요.";
                }
                else
                {
                    label8.ForeColor = Color.LimeGreen;
                    label8.Text = "사용하셔도 됩니다.";

                    label13.Text = "Normal Mode \r\n(오버플로우 인터럽트)\r\nTOP - " + (timer[comboBox1.SelectedIndex] - result_TCNT).ToString() + "(TCNT)";

                    textBox2.Text = result_TCNT.ToString();
                    textBox4.Text = result_frequency.ToString();
                }
            }
            catch { MessageBox.Show("타이머, 분주비를 선택하거나\n숫자를 입력해주세요."); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double result_TCNT;
            double result_time;
            double[] timer = new double[] { 256, 65536 };
            double[] clk1 = new double[] { 1, 8, 32, 64, 128, 256, 1024 };
            double[] clk2 = new double[] { 1, 8, 64, 256, 1024 };
            try
            {
                if (Convert.ToDouble(textBox4.Text) > 16000000) MessageBox.Show("시스템 클럭보다도 진동수가 큽니다.");
                else if (Convert.ToDouble(textBox4.Text) < 0.238418579101563 / Convert.ToDouble(textBox1.Text)) MessageBox.Show("16 비트 최소 진동수보다 작습니다.");

                result_time = 1 / Convert.ToDouble(textBox4.Text);

                if (comboBox1.SelectedIndex == 0) result_TCNT = result_time * Convert.ToDouble(textBox1.Text) / clk1[comboBox2.SelectedIndex];
                else result_TCNT = result_time * Convert.ToDouble(textBox1.Text) / clk2[comboBox2.SelectedIndex];

                if (result_TCNT > timer[comboBox1.SelectedIndex])
                {
                    label8.ForeColor = Color.Red;
                    label8.Text = "높은 분주비를 사용하세요.";
                }
                else if (result_TCNT < 1)
                {
                    label8.ForeColor = Color.Red;
                    label8.Text = "낮은 분주비를 사용하세요.";
                } 
                else
                {
                    label8.ForeColor = Color.LimeGreen;
                    label8.Text = "사용하셔도 됩니다.";
                    label13.Text = "Normal Mode \r\n(오버플로우 인터럽트)\r\nTOP - " + (timer[comboBox1.SelectedIndex] - result_TCNT).ToString() + "(TCNT)";

                    textBox2.Text = result_TCNT.ToString();
                    textBox3.Text = result_time.ToString();
                }
            }
            catch { MessageBox.Show("타이머, 분주비를 선택하거나\n숫자를 입력해주세요."); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            if (!string.IsNullOrEmpty(textBox3.Text)) form.Passvalue = textBox3.Text; // 전달자(Passvalue)를 통해서 Form2 로 전달

            form.ShowDialog();
        }
    }
}
