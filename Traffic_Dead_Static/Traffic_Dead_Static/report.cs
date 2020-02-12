using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traffic_Dead_Static
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
            // 컬럼명과 컬럼헤더를 사용해 컬럼을 정의한다
            dataGridView1.Columns.Add("시도", "시도");
            dataGridView1.Columns.Add("횡단보도상", "횡단보도상");
            dataGridView1.Columns.Add("횡단보도부근", "횡단보도부근");
            dataGridView1.Columns.Add("터널안", "터널안");
            dataGridView1.Columns.Add("교량위", "교량위");
            dataGridView1.Columns.Add("기타단일로", "기타단일로");
            dataGridView1.Columns.Add("교차로내", "교차로내");
            dataGridView1.Columns.Add("교차로부근", "교차로부근");
            dataGridView1.Columns.Add("건널목", "건널목");
            dataGridView1.Columns.Add("기타/불명", "기타/불명");
            dataGridView1.Columns.Add("고가도로위", "고가도로위");
            dataGridView1.Columns.Add("지하도로내", "지하도로내");
        }
        public void SetData(Dictionary<string, int[]> data)
        {
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            foreach (var key in data.Keys)
            {
                int accident = 0;
                //dataGridView1.Rows.Add(key, data[key][0], data[key][1], data[key][2], data[key][3],
                //    data[key][4], data[key][5], data[key][6], data[key][7], data[key][8], data[key][9],
                //    data[key][10]);

                List<string> list = new List<string>(); //stirng 형식의 List생성 (dataGridView에 출력하기 위해)

                list.Add(key);  //list에 key에 해당하는 문자열을 넣는다

                for (int j = 0; j < 10; j++)
                {   
                    list.Add(data[key][j].ToString());  
                    //value 배열을 list에 넣는다.
                    //주의할 점 list에 넣을때는 Add함수 사용! 딕셔너리 형식인 data를 요소마다 꺼내서 ToString으로 형변환 한 후 넣어야
                    //나중에 dataGridView에서 출력할 수 있다!
                }

                dataGridView1.Rows.Add(list.ToArray());

                for (int j = 0; j < 10; j++)
                {
                    accident += data[key][j];
                }
                chart1.Series[0].Points.AddXY(key, accident);
            }
            
        }
        
    }
}
