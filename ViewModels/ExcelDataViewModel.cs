using System.Windows.Input;
using Microsoft.Win32;
using WpfExcelInteraction.Models;

namespace WpfExcelInteraction.ViewModels
{
    public class ExcelDataViewModel : BaseViewModel
    {
        #region Private Members

        private ExcelData excelData;

        #endregion

        public ExcelDataViewModel()
        {
            excelData = new ExcelData();
        }

        public ExcelData ExcelData { get; set; }

        /// <summary>
        /// This connects to the Button in the UI. It calls the RelayCommand class with the appropriate function loaded.
        /// </summary>
        public ICommand LoadCommand => new RelayCommand(LoadFile, true);

        /// <summary>
        /// This connects to the Button in the UI. It calls the RelayCommand class with the appropriate function loaded.
        /// </summary>
        public ICommand SaveCommand => new RelayCommand(SaveFile, true);

        private void LoadFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                excelData.LoadFromDisk(openFileDialog.FileName, openFileDialog.SafeFileName);
            }
        }

        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                excelData.WriteToDisk(saveFileDialog.FileName);
            }
        }
    }
}
