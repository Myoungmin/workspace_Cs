using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gridview_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("colname", "이름");
            dataGridView1.Columns.Add("coljob", "직업");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("강병준", "일용직");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string search = textBox1.Text;

            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value.ToString() == search)
                    {
                        MessageBox.Show("찾았다!");
                        break;
                    }
                }
            }
        }
    }
}
