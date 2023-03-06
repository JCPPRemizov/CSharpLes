using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Pleer
{
    public static class LoadMusic
    {
        private static List<String> musicFiles = new List<string>();
        private static List<String> musicFilesName = new List<string>();
        public static void Load()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Title = "Select Music";
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                musicFiles = Directory.GetFiles(dialog.FileName, "*.mp3").ToList();
                musicFilesName = musicFiles.Select(p => Path.GetFileName(p)).ToList();
            }
        }
  
        public static List<String> getMusicFiles
        {
            get { return musicFiles; }
        }
        public static List<String> getMusicFilesName
        {
            get { return musicFilesName; }
        }
    }
}
