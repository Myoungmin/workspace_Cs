using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


//시리얼 포트에서 DataReceived를 사용할시 문제가 생겨서 대부분 개발하는데 사용하는 방법!!
//주석처리한 처음 방법은 폼에서 직접 타이핑해서
//현재상태는 시리얼 제어하는 클래스를 만들어서 제어

namespace Serial_Test2
{
    public partial class Form1 : Form
    {
        //bool isStart;

        public Form1()
        {
            InitializeComponent();
        }

        //public void SerialListening()   //DataReceived가 문제가 생겨서 만들어주는 함수
        //{
        //    if (serialPort1.IsOpen)
        //        return;
        //    serialPort1.Open();
        //}


        //Thread thread = null;
        CSerialControl serial = null;   //시리얼 컨트롤하는 객체 선언

        private void button1_Click(object sender, EventArgs e)
        {
            //if (thread != null) return;

            //thread = new Thread(new ThreadStart(SerialListening));
            //isStart = true;
            //thread.Start();

            if (serial != null) return;
            serial = new CSerialControl(serialPort1);

            //시리얼 객체와 텍스트박스 차트 연결
            serial.SetTextBox(textBox1);     
            serial.SetChart(chart1);

            //시리얼 객체 시작
            serial.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if(thread != null)
            //{
            //    isStart = false;
            //    //Thread.Sleep(1000);
            //    //thread.Abort();
            //    serialPort1.Close();
            //    thread = null;
            //}

            if (serial == null) return;
            serial.Stop();
            serial = null;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serial == null) return;
            serial.Stop();
            //serial = null;  //프로그램이 꺼지니까 굳이 할필요 없는듯?
        }
    } 
}
