using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileCopy
{
    static public class FileReader
    {
        private static char[] sep = { ',' };

        static public string[] GetContent(string path)
        {
            StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
            string[] matches = (sr.ReadLine()).Split(sep, StringSplitOptions.None);

            return matches;
        }
    }
}
