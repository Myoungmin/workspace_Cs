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
    public partial class result : Form
    {
        public result()
        {
            InitializeComponent();
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
        }

        public void SetData(List<string> row)
        {
            dataGridView1.Rows.Add(row.ToArray());
        }
    }
}
