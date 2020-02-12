using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traffic_Dead_Static
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 컬럼명과 컬럼헤더를 사용해 컬럼을 정의한다
            dataGridView1.Columns.Add("시도", "시도");
            dataGridView1.Columns.Add("시군구", "시군구");
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
            listBox1.Items.Add("데이터를 로드해주세요.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 데이타를 읽는 StreamReader
                StreamReader rd = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding("euc-kr"));

                // 마지막이 될 때까지 루프
                while (!rd.EndOfStream)
                {
                    // 한 라인을 읽는다
                    string line = rd.ReadLine();

                    // 라인을 콤마로 분리하여 컬럼을 만든다
                    string[] cols = line.Split(',');

                    // 한 라인에 각 컬럼의 데이타를 순서대로 넣는다
                    
                    dataGridView1.Rows.Add(cols[0], cols[1], cols[2], cols[3], cols[4], cols[5],
                        cols[6], cols[7], cols[8], cols[9], cols[10], cols[11], cols[12]);
                }

                // StreamReader는 사용 후 반드시 닫는다
                rd.Close();

                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                listBox1.Items.Add("데이터를 로드했습니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            result result = new result();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[1].Value != null)
                {
                    string search1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string search2 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    if ((search1 == textBox1.Text) && (search2 == textBox2.Text))
                    {
                        List<string> data = new List<string>();

                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            data.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        result.SetData(data);
                        break;
                    }
                    else if ((search1 == textBox1.Text) && string.IsNullOrEmpty(textBox2.Text)) //텍스트 박스 비어있는거 어떻게 하는지 찾는데 오래걸림
                    {
                        List<string> data = new List<string>();

                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            data.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        result.SetData(data);
                    }
                    else if (string.IsNullOrEmpty(textBox1.Text) && (search2 == textBox2.Text))
                    {
                        List<string> data = new List<string>();

                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            data.Add(dataGridView1.Rows[i].Cells[j].Value.ToString());
                        result.SetData(data);
                    }
                }
            }
            result.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, int[]> data = new Dictionary<string, int[]>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string key = dataGridView1.Rows[i].Cells[0].Value.ToString();
                if (!data.ContainsKey(key))
                {
                    int[] tmp = new int[11];
                    data.Add(key, tmp);
                }

                for (int j = 2; j < 13; j++)
                {
                    int tmpValue = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    data[key][j - 2] += tmpValue;
                }
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV file|*.csv";
            saveFileDialog1.Title = "Save a CSV File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName == "")
                return;

            CFileWriter writer = new CFileWriter(saveFileDialog1.FileName);

            foreach (string key in data.Keys)
            {
                string savingdata = key + ",";
                writer.SaveText(savingdata + string.Join(",", data[key]));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            report report = new report();

            Dictionary<string, int[]> data = new Dictionary<string, int[]>();

            //그리드뷰에 저장된 데이터를 딕셔너리 형식으로 저장한다
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string key = dataGridView1.Rows[i].Cells[0].Value.ToString();
                if (!data.ContainsKey(key))
                {
                    int[] tmp = new int[11];
                    data.Add(key, tmp);
                }
                for (int j = 2; j < 13; j++)
                {
                    int tmpValue = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    data[key][j - 2] += tmpValue;
                }

            }
            report.SetData(data);
            //저장된 딕셔너리 형식 데이터를 리포트클래스 퍼블릭 멤버함수로 전달

            report.Show();
        }
    }
}
