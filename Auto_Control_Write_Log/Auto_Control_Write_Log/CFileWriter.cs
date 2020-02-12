using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Control_Write_Log
{
    class CFileWriter
    {
        string filename = "";

        public CFileWriter(string _filename)
        {
            filename = _filename;
        }

        public void SaveText(string state)
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
