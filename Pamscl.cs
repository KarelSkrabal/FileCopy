using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileCopy
{
    //class Pamscl:IDataContext
    /// <summary>
    /// Finding pamscl.dat file's path
    /// </summary>
    static class Pamscl
    {
        private const string PAMSCL_NAME = "pamscl.dat";
        private const string VERO_PATH = "\\Temp\\Vero Software\\";

        /// <summary>
        /// Searchs all vero folders containing pamscl.dat files
        /// </summary>
        /// <returns>Returns last pamscl.dat edited file</returns>
        public static string GetPamsclPath()
        {
            String lastEditedPamsclFile = String.Empty;

            

            string pamsclFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + VERO_PATH;
            DirectoryInfo ecFolders = new DirectoryInfo(pamsclFile);

            IOrderedEnumerable<FileInfo> pamsclFiles = from f in ecFolders.EnumerateFiles(PAMSCL_NAME, SearchOption.AllDirectories)
                                                       orderby f.LastWriteTime descending
                                                       select f;

            if (pamsclFiles.Any())
            {
                FileInfo lastPamscl = pamsclFiles.First();
                return lastPamscl.FullName;
            }
            return string.Empty;
        }        
    }
}
