using Avalonia;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FFXProjectEditor.Utils
{
    public class AvaloniaDialog_Util
    {
        /*
         * Opens a folder picker and returns the path of the selected folders.
         * If no folder is selected the returned list will be empty.
         */
        public static async ValueTask<List<string>> OpenFolderDialog(Visual callingVisual, string title = "Open Folder", bool allowMultiple = false)
        {
            // Get top level from the current control. Alternatively, you can use Window reference instead.
            var topLevel = TopLevel.GetTopLevel(callingVisual);

            // Start async operation to open the dialog.
            var files = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                Title = title,
                AllowMultiple = allowMultiple
            });

            List<string> filePaths = new List<string>();
            foreach (var file in files)
            {
                filePaths.Add(Uri.UnescapeDataString(file.Path.AbsolutePath));
            }
            return filePaths;
        }

        /*
         * Opens a file picker and returns the path of the selected files.
         * If no file is selected the returned list will be empty.
         */
        public static async ValueTask<List<string>> OpenFileDialog(Visual callingVisual, string title = "Open File", bool allowMultiple = false, string suggestedFileName = null, List<FilePickerFileType> fileTypeFilter = null)
        {
            // Get top level from the current control. Alternatively, you can use Window reference instead.
            var topLevel = TopLevel.GetTopLevel(callingVisual);

            // Start async operation to open the dialog.
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = title,
                AllowMultiple = allowMultiple,
                SuggestedFileName = suggestedFileName,
                FileTypeFilter = fileTypeFilter
            });

            List<string> filePaths = new List<string>();
            foreach (var file in files)
            {
                filePaths.Add(Uri.UnescapeDataString(file.Path.AbsolutePath));
            }
            return filePaths;
        }

        /*
         * Opens a save file picker and returns the selected path.
         */
        public static async ValueTask<string> SaveFileDialog(Visual callingVisual, string title = "Save File", string suggestedFileName = null, string defaultExtension = null, List<FilePickerFileType> fileTypeChoices = null)
        {
            // Get top level from the current control. Alternatively, you can use Window reference instead.
            var topLevel = TopLevel.GetTopLevel(callingVisual);

            // Start async operation to open the dialog.
            var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
            {
                Title = title,
                SuggestedFileName = suggestedFileName,
                DefaultExtension = defaultExtension,
                FileTypeChoices = fileTypeChoices,
                ShowOverwritePrompt = true
            });

            if (file is not null)
            {
                return Uri.UnescapeDataString(file.Path.AbsolutePath);
            }
            else
            {
                return null;
            }
        }

        /*
         * Opens a save file picker and saves the given file.
         */
        public static async void SaveFile(Visual callingVisual, byte[] byteFile, string title = "Save File", string suggestedFileName = null, string defaultExtension = null, List<FilePickerFileType> fileTypeChoices = null)
        {
            // Get top level from the current control. Alternatively, you can use Window reference instead.
            var topLevel = TopLevel.GetTopLevel(callingVisual);

            // Start async operation to open the dialog.
            var file = await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
            {
                Title = title,
                SuggestedFileName = suggestedFileName,
                DefaultExtension = defaultExtension,
                FileTypeChoices = fileTypeChoices,
                ShowOverwritePrompt = true
            });

            if (file is not null)
            {
                File.WriteAllBytes(Uri.UnescapeDataString(file.Path.AbsolutePath), byteFile);
            }
            else
            {
                return;
            }
        }
    }
}
