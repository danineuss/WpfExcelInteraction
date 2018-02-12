using System.Windows.Input;
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
            excelData.WriteToDisk();
        }

        private void SaveFile()
        {
            excelData.WriteToDisk();
        }
    }
}
