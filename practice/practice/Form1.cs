using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            do
            {
                result = MessageBox.Show("치명적인 오류", "너 큰일남", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) MessageBox.Show("Yes를 클릭했습니다", "클릭함");
                else if (result == DialogResult.No) MessageBox.Show("No를 클릭했습니다", "클릭함");
            } while (result == DialogResult.Cancel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddForm child = new practice.AddForm();
            child.ShowDialog();
        }

        private void 속았지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm child = new practice.AddForm();
            child.Show();
        }

        private void 없음ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("정말로 끌거야?", "진짜로?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) Close();
            else MessageBox.Show("바보");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tool.Text = "클릭했습니다";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://naver.com");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            foreach (var item in Controls)
            {
                if (item is CheckBox)
                {
                    CheckBox check = (CheckBox)item;
                    if (check.Checked)
                    {
                        list.Add(check.Text);
                    }
                }
            }
            MessageBox.Show(string.Join(",", list));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            foreach (var outerItem in Controls)
            {
                if (outerItem is GroupBox)
                {
                    foreach (var inneritem in ((GroupBox)outerItem).Controls)
                    {
                        RadioButton radioButton = inneritem as RadioButton;
                        if (radioButton != null && radioButton.Checked)
                        {
                            MessageBox.Show(radioButton.Text);
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            productBindingSource.Add(new Product() { Name = "감자", Price = 500 });
            productBindingSource.Add(new Product() { Name = "사과", Price = 700 });
            productBindingSource.Add(new Product() { Name = "고구마", Price = 400 });
            productBindingSource.Add(new Product() { Name = "배추", Price = 600 });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product product = (Product)comboBox1.SelectedItem;
            if(product != null)
                MessageBox.Show("객체로부터 : " + product.Name + ", " + product.Price + "원");
            if (product != null)
                MessageBox.Show("디스플레이로부터 : " + comboBox1.SelectedValue + "원");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Product product = (Product)comboBox1.SelectedItem;
            MessageBox.Show(product.Name + ", " + (float)product.Price * 1.1 + "원");
        }
    }
}
