using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileCopy
{
    public static class FileMover
    {
        private static void MoveFile(string target, string destination)
        {
            try
            {
                File.Copy(Path.Combine(target), Path.Combine(destination),true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public static void MoveFileAndDelete(string target, string destination)
        {
            MoveFile(target, destination);
            try
            {
                if (File.Exists(target))
                    File.Delete(target);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }

    interface IFile
    {
        string suffix { get; }

        string GetFileName();
    }

    public abstract class SourceFile : IFile
    {
        public string suffix { get; set; }


        protected string SourceFileName { get; set; }

        protected SourceFile(string name)
        {
            suffix = "_";
            SourceFileName = name;
        }

        public virtual string GetFileName()
        {
            return suffix + SourceFileName;
        }
    }




    enum SourceFileType
    {
        EDITACE,
        CAS,
        NASTROJE
    }

    public class SourceFileEDITACE : SourceFile
    {
        public SourceFileEDITACE(string name):base(name)
        {
            suffix = "_EDITACE";
        }

        public override string GetFileName()
        {
            return SourceFileName.Insert(SourceFileName.LastIndexOf('_'), suffix);
        }
    }
}
