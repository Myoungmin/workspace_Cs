using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            productBindingSource.Add(new Product() { Name = "감자", Price = 500 });
            productBindingSource.Add(new Product() { Name = "사과", Price = 700 });
            productBindingSource.Add(new Product() { Name = "고구마", Price = 400 });
            productBindingSource.Add(new Product() { Name = "배추", Price = 600 });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product product = (Product)comboBox1.SelectedItem;
            MessageBox.Show(product.Name + ", " + (float)product.Price * 1.1 + "원");
        }
    }
}
