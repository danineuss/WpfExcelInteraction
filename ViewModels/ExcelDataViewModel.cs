﻿using System.Collections.Generic;
using System.Windows.Controls;
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

        #region Public Members

        public Dictionary<string, string> DataDictionary { get; set; }

        #endregion

        #region Constructor

        public ExcelDataViewModel()
        {
            excelData = new ExcelData();
            DataDictionary = new Dictionary<string, string>();
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
                excelData.LoadFromDisk(openFileDialog.FileName, openFileDialog.SafeFileName);
                DataDictionary = excelData.DataDictionary;
            }
        }

        /// <summary>
        /// Creates a SaveFileDialog to properly save a file windows style.
        /// </summary>
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
