using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!serialPort1.IsOpen)
                serialPort1.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                //
                string tmp = serialPort1.ReadLine();    //시리얼을 닫았는데 이미 들어와서 이 읽는 작동을 해서 에러가 발생한다, Timeout

                string[] temp_array = tmp.Split(',');   
                if (temp_array.Length == 5) //5개확인해서 통신 오류방지
                {
                    Console.WriteLine(tmp);

                    //textBox1.Text = tmp;    
                    //이렇게 하면 에러
                    //크로스 스레드 작업이 잘못되었습니다. 'textBox1' 컨트롤이 자신이 만들어진 스레드가 아닌 스레드에서 액세스되었습니다.
                    //이걸 피하려면 Invoke함수 사용해야한다!!!

                    textBox1.Invoke(new MethodInvoker(delegate ()
                    {
                        textBox1.Text = tmp;
                    }));

                    textBox2.Invoke(new MethodInvoker(delegate ()
                    {
                        textBox2.Text = temp_array[0];  //MCU에서 시리얼로 받은 문자열에서 , 으로 구분된것 첫번째 텍스트박스 2로 따로 추출
                }));

                    chart1.Invoke(new MethodInvoker(delegate ()
                    {
                        if (chart1.Series[0].Points.Count > 80) chart1.Series[0].Points.RemoveAt(0);
                    //x축이 100이상이되면 첫번째 부분이 삭제되서 흘러가는 모습 실시간 그래프모양 만들어줌

                    try //제대로된 값이 시리얼로 안와서 textBox 데어터가 변환이 안될때를 대비
                    {
                            chart1.Series[0].Points.AddXY(DateTime.Now.ToString(), Convert.ToDouble(textBox2.Text) % 100);
                        //가로축은 시간, 세로축은 텍스트박스를 100으로 나눈 나머지
                    }
                        catch { }

                        chart1.ChartAreas[0].RecalculateAxesScale();
                    //그래프 영역을 비율대로 맞춰준다. 축 범위가 변경 되 면 해당 축에 레이블을 다시 계산해준다
                }));
                }
            }
            catch{ }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("LED,ON\n");
                pictureBox1.Invoke(new MethodInvoker(delegate ()
                {
                    pictureBox1.ImageLocation = "./led_green.png";
                }));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("LED,OFF\n");
                pictureBox1.Invoke(new MethodInvoker(delegate ()
                {
                    pictureBox1.ImageLocation = "./led_gray.png";
                }));
            }
        }
        
    }
}
