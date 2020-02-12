using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<CStudent> studentList  = new List<CStudent>();

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int age = 0;
            try
            {
                age = Convert.ToInt32(textBox2.Text);
                CStudent student = new CStudent();
                student.name = name;
                student.age = age;
                studentList.Add(student);
            }
            catch
            {
                MessageBox.Show("숫자만 입력해 주세요");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Dictionary<int, string> testDictionary = new Dictionary<int, string>();
            //testDictionary.Add(123, "강병준");
            //testDictionary.Add(124, "고명민");


            //List<int> keys = testDictionary.Keys.ToList();  //딕셔너리 키를 모두 리스트로 만들기

            //for (int i = 0; i < testDictionary.Count; i++)
            //{
            //    string name = testDictionary[keys[i]];  //리스트로 만든 키로 value로 접근
            //    MessageBox.Show(name);
            //}

            //foreach(int key in testDictionary.Keys)     //foreach로 key 접근
            //{
            //    string name = testDictionary[key];
            //    MessageBox.Show(name);
            //}

            //foreach (var item in testDictionary)     //foreach로 딕셔너리 요소(키 벨류 묶음)에 접근
            //{
            //    string name = item.Value;
            //    int key = item.Key;
            //    MessageBox.Show(key.ToString() + " " + name);   //키를 문자열로 만들고 value랑 합쳐서 출력
            //}

            /*********************************************************************************************************************************/


            Dictionary<int, CStudent> studentData = new Dictionary<int, CStudent>();
            CStudent student = new CStudent();
            student.name = "강병준";
            student.age = 34;
            studentData.Add(1234, student);

            student = new CStudent();
            student.name = "고명민";
            student.age = 31;
            studentData.Add(1235, student);

            foreach(int key in studentData.Keys)
            {
                string name = studentData[key].name;
                string age = " " + studentData[key].age.ToString();
                MessageBox.Show(name+age);
            }
        }
    }
}
