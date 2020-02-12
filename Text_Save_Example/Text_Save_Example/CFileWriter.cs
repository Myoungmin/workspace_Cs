using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Save_Example
{
    class CFileWriter
    {
        public CFileWriter() { }
        ~CFileWriter() { }

        static public void SaveText(string state)
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            string data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + state;
            using (StreamWriter sw = new StreamWriter(today + ".txt", true))
            {
                sw.WriteLine(data);
            }
        }
    }
}
