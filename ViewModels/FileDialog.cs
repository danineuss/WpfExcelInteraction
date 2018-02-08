using System.IO;
using Microsoft.Win32;

namespace WpfFileDialog.ViewModels
{
    public class FileDialog
    {
        private string name;

        public string FetchName()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                name = openFileDialog.SafeFileName;
            }

            return name;
        }
}
}
