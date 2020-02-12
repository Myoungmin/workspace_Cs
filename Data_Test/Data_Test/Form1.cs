using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<string> stringList = new List<string>();
            //stringList.Add("1");
            //stringList.Add("2");
            //stringList.Add("3");
            //stringList.Add("4");
            //stringList.Add("5");
            //stringList.Add("2");
            //stringList.Add("2");
            //stringList.Add("2");

            //stringList.Sort();

            //stringList.Reverse();

            //stringList.RemoveAt(3); //삭제시 배열의 순서를 자동으로 채워준다.

            //stringList.Remove("2");


            //MessageBox.Show(String.Join("", stringList.ToArray()));   
            //리스트에 있는 것을 배열로 바꾸고 모두 합쳐서 하나의 string으로 만들어 출력


            //MessageBox.Show(stringList[3]); //배열처럼 접근 가능하다.





            /************************************************************************************/




            //List<int[]> intList = new List<int[]>();    //2차원 배열이 된다


            //for (int i = 0; i < 10; i++)
            //{
            //    //int[] array = new int[10];
            //    intList.Add(new int [10]);  //이렇게 배열 이름 선언 안하고 리스트에 추가 가능
            //}

            //intList[1][3] = 1;

            /****************************************/

            //List<int[]> intList = new List<int[]>();

            //intList.Add(array);

            //array[2] = 1;   //이렇게 수정해도 list안에 array도 수정된다. call by reference 형태처럼






            /************************************************************************************/






            List<CStudent> studentList = new List<CStudent>();

            CStudent student = new CStudent();
            student.name = "강병준";
            student.age = 34;

            student.subjects = new string[10];
            //이렇게 미리 메모리 공간을 확보해야만 NullReferenceException 에러가 발생하지 않음
            student.subjects[0] = "C#";
            student.subjects[1] = "AVR";

            //student.subjectList = new List<string>(); 
            //이렇게 여기서 미리 공간을 확보하거나 Class 만들때 메모리공간을 확보하면 된다. 배열과 다르게 List는 추가 가능하므로 Class에 선언하면 편리
            student.subjectList.Add("C#");
            student.subjectList.Add("AVR");

           


        }
    }
}
