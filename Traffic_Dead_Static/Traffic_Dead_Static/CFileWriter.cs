using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Dead_Static
{
    class CFileWriter
    {
        string filename = "";

        public CFileWriter(string _filename)
        {
            filename = _filename;
        }

        public void SaveText(string data)
        {
            using (StreamWriter sw = new StreamWriter(filename, true, Encoding.Default))
            {
                sw.WriteLine(data);
            }
        }
    }
}
