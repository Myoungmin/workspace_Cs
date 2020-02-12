using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Serial_Test2
{
    class CSerialControl
    {
        SerialPort port = null;
        Thread thread = null;
        bool isStart = false;
        TextBox textBox1;
        Chart chart1;

        public CSerialControl(SerialPort _port)
        {
            port = _port; 
        }

        public void SetTextBox(TextBox textbox)
        {
            textBox1 = textbox;
        }

        public void SetChart(Chart chart)
        {
            chart1 = chart;
        }

        public void Start()
        {
            if (thread != null) return;
            thread = new Thread(new ThreadStart(Run));
            isStart = true;
            port.Open();
            thread.Start();
        }

        public void Stop()
        {
            if (thread == null) return;
            isStart = false;
            port.Close();
            thread = null;
        }

        private void Run()
        {
            while (isStart)
            {
                try
                {
                    string tmp = port.ReadLine();
                    Console.WriteLine(tmp);
                    string[] temp_array = tmp.Split(',');
                    textBox1.Invoke(new MethodInvoker(delegate ()
                    {
                        textBox1.Text = temp_array[0];
                    }));

                    chart1.Invoke(new MethodInvoker(delegate ()
                    {
                        if (chart1.Series[0].Points.Count > 80) chart1.Series[0].Points.RemoveAt(0);
                        //x축이 100이상이되면 첫번째 부분이 삭제되서 흘러가는 모습 실시간 그래프모양 만들어줌

                        try //제대로된 값이 시리얼로 안와서 textBox 데어터가 변환이 안될때를 대비
                        {
                            chart1.Series[0].Points.AddXY(DateTime.Now.ToString(), Convert.ToDouble(textBox1.Text) % 100);
                            //가로축은 시간, 세로축은 텍스트박스를 100으로 나눈 나머지
                        }
                        catch { }

                        chart1.ChartAreas[0].RecalculateAxesScale();
                        //그래프 영역을 비율대로 맞춰준다. 축 범위가 변경 되 면 해당 축에 레이블을 다시 계산해준다
                    }));
                }
                catch { }
            }
        }
    }
}
