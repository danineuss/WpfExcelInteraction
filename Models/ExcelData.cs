using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExcelInteraction.Models
{
    public class ExcelData
    {
        /// <summary>
        /// This class requires a file name and a dictionary containing the data that should be saved/loaded
        /// at the location.
        /// </summary>
        #region Private Members

        private string _fileName;

        private Dictionary<string, string> _dataDictionary;

        #endregion

        #region Public Properties

        public String FileName
        {
            get => _fileName;
            set => _fileName = value;
        }

        public Dictionary<string, string> DataDictionary
        {
            get => _dataDictionary;
            set => _dataDictionary = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor creates an empty gameDictionary.
        /// </summary>
        /// <param name="fileName">The name of the file on the drive.</param>
        public ExcelData(string fileName = null)
        {
            if (fileName == null)
            {
                fileName = DefaultFilePath();
            }

            _fileName = fileName;
            _dataDictionary = new Dictionary<string, string>();
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Saves the current gameDictionary as .csv File with the name being the fileName.
        /// </summary>
        /// <param name="fullPath">The full file path of the .csv file.</param>
        public void WriteToDisk(string fullPath = null)
        {
            string csv = String.Join(
                Environment.NewLine, DataDictionary.Select(datum => datum.Key + ";" + datum.Value + ";"));
            if (fullPath != null)
            {
                File.WriteAllText(fullPath, csv);
            }
            else
            {
                File.WriteAllText(_fileName, csv);
            }
            
        }

        /// <summary>
        /// Loads a .csv file and creates a new gameDictionary from it.
        /// </summary>
        /// <param name="fullPath">The full file path of the .csv file.</param>
        /// <param name="fileName">The name of the loaded file.</param>
        public void LoadFromDisk(string fullPath, string fileName = "")
        {
            FileName = fileName;

            DataDictionary = File.ReadLines(fullPath).Select(
                line => line.Split(';')).ToDictionary(data => data[0], data => data[1]);
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Creates a default file name within the current project repository.
        /// </summary>
        /// <returns></returns>
        private string DefaultFilePath()
        {
            string projectBinPath = Environment.CurrentDirectory;
            DirectoryInfo partentDir = Directory.GetParent(projectBinPath);

            string folderPath = partentDir.Parent.Parent.FullName + "\\";
            string nameStub = "DefaultName";
            int iterator = 1;
            while (File.Exists(folderPath + nameStub + " " + iterator))
            {
                iterator++;
            }

            return folderPath + nameStub + " " + iterator + ".csv";
        }

        #endregion
    }
}
