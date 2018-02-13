using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Win32;
using WpfExcelInteraction.Models;

namespace WpfExcelInteraction.ViewModels
{
    /// <summary>
    /// This is the ViewModel connecting the UI and the data, in this case the MainWindow and ExcelData.
    /// It handles data binding and relays the commands for saving and loading a file.
    /// </summary>
    public class ExcelDataViewModel : BaseViewModel
    {
        #region Private Members

        private ExcelData _excelData;

        private ObservableCollection<GameReview> _gameCollection;

        #endregion

        #region Public Members

        public ObservableCollection<GameReview> GameCollection
        {
            get => _gameCollection;
            set => _gameCollection = value;
        }

        #endregion

        #region Constructor

        public ExcelDataViewModel()
        {
            _excelData = new ExcelData();
            _gameCollection = new ObservableCollection<GameReview>();
        }

        #endregion

        /// <summary>
        /// This connects to the Button in the UI. It calls the RelayCommand class with the appropriate function loaded.
        /// </summary>
        public ICommand LoadCommand => new RelayCommand(LoadFile, true);

        /// <summary>
        /// This connects to the Button in the UI. It calls the RelayCommand class with the appropriate function loaded.
        /// </summary>
        public ICommand SaveCommand => new RelayCommand(SaveFile, true);

        /// <summary>
        /// Creates a OpenFileDialog to properly open a file windows style.
        /// </summary>
        private void LoadFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                _excelData.LoadFromDisk(openFileDialog.FileName, openFileDialog.SafeFileName);
                GameCollection = ExcelData.ConvertToCollection(_excelData.GameDictionary);
            }
        }

        /// <summary>
        /// Creates a SaveFileDialog to properly save a file windows style.
        /// </summary>
        private void SaveFile()
        {
            _excelData.GameDictionary = ExcelData.ConvertToDictionary(GameCollection);
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                _excelData.SaveToDisk(saveFileDialog.FileName);
            }
        }
    }
}
