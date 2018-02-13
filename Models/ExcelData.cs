using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExcelInteraction.Models
{
    public class ExcelData
    {
        #region Private Properties

        private string fileName;

        private ObservableCollection<GameReview> gameCollection;

        #endregion

        #region Public Properties

        public String FileName { get; set; }

        public Dictionary<string, string> DataDictionary { get; set; }

        public ObservableCollection<GameReview> GameCollection { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor creates an empty gameDictionary.
        /// </summary>
        /// <param name="fileName">The name of the file on the drive.</param>
        public ExcelData(string fileName = null)
        {
            FileName = fileName;
            DataDictionary = new Dictionary<string, string>();
            GameCollection = new ObservableCollection<GameReview>();
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
                File.WriteAllText(FileName, csv);
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
    }
}
