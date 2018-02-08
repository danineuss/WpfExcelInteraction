using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExcelInteraction.Models
{
    public class ExcelData
    {
        #region Private Members

        private string _fileName;

        private Dictionary<string, string> _gameDictionary;

        #endregion

        #region Public Properties

        public String FileName
        {
            get => _fileName;
            set => _fileName = value;
        }

        public Dictionary<string, string> GameDictionary
        {
            get { return _gameDictionary; }
            set { _gameDictionary = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor creates an empty gameDictionary.
        /// </summary>
        /// <param name="fileName">The name of the file on the drive.</param>
        public ExcelData(string fileName)
        {
            _fileName = fileName;
            _gameDictionary = new Dictionary<string, string>();
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Saves the current gameDictionary as .csv File with the name being the fileName.
        /// </summary>
        /// <param name="fullPath">The full file path of the .csv file.</param>
        public void WriteToDisk(string fullPath)
        {

        }

        /// <summary>
        /// Loads a .csv file and creates a new gameDictionary from it.
        /// </summary>
        /// <param name="fullPath">The full file path of the .csv file.</param>
        public void LoadFromDisk(string fullPath)
        {

        }

        #endregion
    }
}
