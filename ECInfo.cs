using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileCopy
{
    class ECInfo
    {
        #region attribute_definition

        private enum pamsclItems { POST = 0, NC_FILE = 3, PPF_FILE = 4 };
        //private string pathToPlantSubdirectory = string.Empty;

        /// <summary>
        /// Posledni editovany pamscl.dat soubor
        /// </summary>
        private string _pamsclFile;
        public string pamsclFile
        {
            get { return _pamsclFile; }
            set { _pamsclFile = value; }
        }

        /// <summary>
        /// Posledni pouzity postprocesor
        /// </summary>
        private string _post;
        public string post
        {
            get { return _post; }
            set { _post = value; }
        }

        /// <summary>
        /// Koncovka Postprocesoru
        /// </summary>
        private string _postExtension;
        public string postExtension
        {
            get { return _postExtension; }
            set { _postExtension = value; }
        }

        /// <summary>
        /// Nazev NC souboru bez koncovky
        /// </summary>
        private string _NCFileWithoutExtension;
        public string NCFileWithoutExtension
        {
            get { return _NCFileWithoutExtension; }
            set { _NCFileWithoutExtension = value; }
        }

        /// <summary>
        /// Posledni vytvoreny NC soubor
        /// </summary>
        private string _NCfile;
        public string NCfile
        {
            get { return _NCfile; }
            set { _NCfile = value; }
        }

        /// <summary>
        /// Slozka ve ktere je umisteny NC soubor
        /// </summary>
        private string _NCfileFolder;
        public string NCfileFolder
        {
            get { return _NCfileFolder; }
            set { _NCfileFolder = value; }
        }

        /// <summary>
        /// Koncovka NC souboru
        /// </summary>
        private string _NCfileExtension;
        public string NCfileExtension
        {
            get { return _NCfileExtension; }
            set { _NCfileExtension = value; }
        }

        /// <summary>
        /// Obrabeci postup ze ktereho byl naposledy vygenerovany NC soubor
        /// </summary>
        private string _ppffile;
        public string ppffile
        {
            get { return _ppffile; }
            set { _ppffile = value; }
        }

        /// <summary>
        /// Typ technologie (soustruzeni,frezovani,dratorez)
        /// </summary>
        private string _technology;
        public string technology
        {
            get { return _technology; }
            set { _technology = value; }
        }

        private string _dataExportFile;
        public string dataExportFile
        {
            get { return _dataExportFile; }
            set { _dataExportFile = value; }
        }

        #endregion

        /// <summary>
        /// Konstruktor tridy pro nalezeni informaci nactenych z naposledy editovaneho souboru pamscl.dat
        /// parameter "folder" -> Slozka ve ktere se nachazi pamscl.dat, platne slozky jsou "Planit" nebo "Vero Software"
        /// </summary>
        /// <param name="folder">Slozka ve ktere se nachazi pamscl.dat, platne slozky jsou "Planit" nebo "Vero Software"</param>
        public ECInfo(string[] content)
        {
            GetDetails(content);
        }

        /// <summary>
        /// Metoda pro ziskani informaci o postprocesoru, NC souboru, ppf souboru, zalohy NC souboru
        /// </summary>
        private void GetDetails(string[] content)
        {
            this._post = content[(int)pamsclItems.POST];
            this._postExtension = this.post.Substring(this.post.LastIndexOf(".", StringComparison.CurrentCulture) + 1);
            this._NCfile = content[(int)pamsclItems.NC_FILE];
            this._NCfileExtension = (new FileInfo(content[(int)pamsclItems.NC_FILE])).Extension;
            this._NCFileWithoutExtension = ((new FileInfo(content[3])).Name).Replace(this.NCfileExtension, "");
            this.NCfileFolder = Path.GetDirectoryName(content[(int)pamsclItems.NC_FILE]) + System.IO.Path.DirectorySeparatorChar;
            this._ppffile = content[(int)pamsclItems.PPF_FILE];
            this._dataExportFile = this._NCFileWithoutExtension + "_" + this._post.Substring(0, this._post.IndexOf('_')) + ".txt"; ;

            switch (this._postExtension)
            {
                case "tcp":
                    _technology = "TURN";
                    break;
                case "mcp":
                    _technology = "MILL";
                    break;
                case "wcp":
                    _technology = "WIRE";
                    break;
            }
        }
    }
}
