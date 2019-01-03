using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;

using Edgecam;
using EdgecamPluginFramework;


namespace FileCopy
{
    public class Class1 : EdgecamPlugin
    {

        private string SETTING_FILE_NAME = "ECSetting.json";
        private string destinationPath { get; set; }

        public override string Name
        {
            get { return "FileCopy"; }
        }

        public override bool Start()
        {
            // set ANSI C style decimal separator without altering the thread's codepage
            CultureInfo current = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            current.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = current;

            IPCI pci = new Edgecam.PCI();

            string ECUserPath = pci.GetPCIVariable("&EDGEUSER");
            string pamsclFilePath = string.Empty;

            try
            {
                var ret = JsonConvert.DeserializeObject<PostRoot>(File.ReadAllText(Path.Combine(ECUserPath + @"\cam\Plugins\") + SETTING_FILE_NAME));

                destinationPath = ret.Posts["export"].Path;
                pamsclFilePath = ret.Posts["pamscl"].Path;
            }
            catch (Exception ex)
            {
                throw;
            }

            ECInfo ecInfo = new ECInfo(FileReader.GetContent(pamsclFilePath));

            string target = ecInfo.NCfileFolder + ecInfo.dataExportFile;
            string destination = this.destinationPath + ecInfo.post.Substring(0, ecInfo.post.IndexOf('_')) + @"\" + ecInfo.dataExportFile;

            FileMover.MoveFileAndDelete(target, destination);

            //zmenovy pozadavek
            //SourceFileEDITACE editace = new SourceFileEDITACE(ecInfo.dataExportFile);
            //FileMover.MoveFileAndDelete(ecInfo.NCfileFolder + editace.GetFileName(), destinationPath + editace.GetFileName());

            return true;
        }
    }
}
