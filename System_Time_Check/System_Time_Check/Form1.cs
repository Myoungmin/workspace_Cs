using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Time_Check
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime CurrentTime = DateTime.Now;
            label1.Text = CurrentTime.ToString("yyyy.MM.dd HH:mm:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            //타이머 끌때 그림 바꾸기
            pictureBox1.ImageLocation = "./led_gray.png";
            state = 0;
        }

        int state = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //메인 쓰레드에서 계속 UI를 계속 그려주고 있는데 그것을 다른 쓰레드에서 수정한다고
            //알려주는 invoke함수
            //무명함수(lamda같은것)이 세부내용으로 쓰였다.
            //여기서는 사용하지 않아도 무방하지만 보통 이렇게 하지않으면 오류가 발생
            label1.Invoke(new MethodInvoker(delegate ()
            {
                DateTime CurrentTime = DateTime.Now;
                label1.Text = CurrentTime.ToString("yyyy.MM.dd HH:mm:ss");
            }
            )
            );

            if(state == 0)
            {
                pictureBox1.Invoke(new MethodInvoker(delegate ()
                {
                    pictureBox1.ImageLocation = "./led_green.png";
                    state = 1;
                })
                );
            }
            else
            {

                pictureBox1.Invoke(new MethodInvoker(delegate ()
                {
                    pictureBox1.ImageLocation = "./led_gray.png";
                    state = 0;
                })
                );
            }
        }
    }
}
