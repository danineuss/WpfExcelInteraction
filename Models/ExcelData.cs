using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExcelInteraction.Models
{
    /// <summary>
    /// This is the main data model class containing a dictionary with the data. It can then save or load data
    /// in csv files.
    /// </summary>
    public class ExcelData
    {
        #region Private Properties

        private string _fileName;

        private Dictionary<string, string> _gameDictionary;

        #endregion

        #region Public Properties

        public String FileName { get; set; }

        public Dictionary<string, string> GameDictionary
        {
            get => _gameDictionary;
            set => _gameDictionary = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor creates an empty gameDictionary.
        /// </summary>
        /// <param name="fileName">The name of the file on the drive.</param>
        public ExcelData(string fileName = null)
        {
            FileName = fileName;
            GameDictionary = new Dictionary<string, string>();
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Saves the GameCollection in a .csv file.
        /// </summary>
        /// <param name="fullPath">The entire file path.</param>
        public void SaveToDisk(string fullPath)
        {
            if (fullPath != null)
            {
                _fileName = fullPath;
            }
            string csv = String.Join(
                Environment.NewLine, GameDictionary.Select(datum => datum.Key + ";" + datum.Value + ";"));

            File.WriteAllText(_fileName, csv);
        }

        /// <summary>
        /// Loads a .csv file and creates a new gameDictionary from it.
        /// </summary>
        /// <param name="fullPath">The full file path of the .csv file.</param>
        /// <param name="fileName">The name of the loaded file.</param>
        public void LoadFromDisk(string fullPath, string fileName)
        {
            FileName = fileName;

            GameDictionary = File.ReadLines(fullPath).Select(
                line => line.Split(';')).ToDictionary(data => data[0], data => data[1]);
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Converts a ObservableCollection with types GameReview into a Dictionary of two strings. This
        /// is used to then save to a .csv file.
        /// </summary>
        /// <param name="collection">The observable collection with the game reviews.</param>
        /// <returns></returns>
        public static Dictionary<string, string> ConvertToDictionary(ObservableCollection<GameReview> collection)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (var gameReview in collection)
            {
                dictionary.Add(gameReview.Title, gameReview.Review);
            }

            return dictionary;
        }

        /// <summary>
        /// Converts a dictionary of types (string, string) into a custom ObservableCollection of types GameReview.
        /// </summary>
        /// <param name="dictionary">The dictionary with (string, string)</param>
        /// <returns></returns>
        public static ObservableCollection<GameReview> ConvertToCollection(Dictionary<string, string> dictionary)
        {
            ObservableCollection<GameReview> collection = new ObservableCollection<GameReview>();

            foreach (var element in dictionary)
            {
                collection.Add(new GameReview(element.Key, element.Value));
            }

            return collection;
        }

        #endregion
    }
}
