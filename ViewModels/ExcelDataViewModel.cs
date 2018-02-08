using System.Windows.Input;
using WpfFileDialog.ViewModels;
using WpfTreeView;

namespace WpfExcelInteraction.ViewModels
{
    public class ExcelDataViewModel : BaseViewModel
    {
        #region Private Members
        
        private ICommand _clickCommand;

        private bool _canSave;

        #endregion

        /// <summary>
        /// This connects to the Button in the UI. It calls the RelayCommand class with the appropriate function loaded.
        /// </summary>
        public ICommand LoadCommand
        {
            get
            {
                if (_clickCommand == null)
                {
                    _clickCommand = new RelayCommand(LoadFile, true);
                }
                return _clickCommand;
            }
        }

        /// <summary>
        /// This connects to the Button in the UI. It calls the RelayCommand class with the appropriate function loaded.
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                if (_clickCommand == null)
                {
                    _clickCommand = new RelayCommand(SaveFile, _canSave);
                }
                return _clickCommand;
            }
        }

        private void LoadFile()
        {

        }

        private void SaveFile()
        {

        }
    }
}
