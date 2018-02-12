using System.Windows.Input;
using Microsoft.Win32;
using WpfExcelInteraction.Models;
using WpfFileDialog.ViewModels;
using WpfTreeView;

namespace WpfExcelInteraction.ViewModels
{
    public class ExcelDataViewModel : BaseViewModel
    {
        #region Private Members
        
        private ICommand _clickCommand;

        private bool _canSave;

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
        public ICommand SaveCommand => new RelayCommand(SaveFile, _canSave);

        private void LoadFile()
        {
            string fileName = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                fileName = openFileDialog.FileName;
            }

            excelData.LoadFromDisk(fileName);
        }

        private void SaveFile()
        {
            excelData.WriteToDisk();
        }
    }
}
