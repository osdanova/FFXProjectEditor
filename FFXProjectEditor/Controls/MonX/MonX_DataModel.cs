using FFXProjectEditor.Files;
using System.Collections.ObjectModel;

namespace FFXProjectEditor.Controls.MonX
{
    internal class MonX_DataModel
    {
        /******************************************
         * Data
         ******************************************/
        internal ObservableCollection<MonX_File.Entry> LoadedEntries { get; set; }

        //public MonX_DataModel()
        //{
        //    LoadedEntries = new ObservableCollection<MonX_File.Entry>();
        //    LoadFromFile();
        //}
        public MonX_DataModel(MonX_File file)
        {
            LoadedEntries = new ObservableCollection<MonX_File.Entry>();
            LoadData(file);
        }

        public void LoadFromFile()
        {
            //if (!ProjectService.Instance.MixDataExists)
            //{
            //    return;
            //}
            //
            //LoadData(FileMixData_Service.Instance.LeveFile);
        }

        public void LoadData(MonX_File khFile)
        {
            LoadedEntries.Clear();
            foreach (MonX_File.Entry entry in khFile.Entries)
            {
                LoadedEntries.Add(entry);
            }
        }

        //public void SaveFile()
        //{
        //    FileMixData_Service.Instance.LeveFile.Entries.Clear();
        //    foreach (MixDataLevels_Wrapper wrapper in LoadedEntries)
        //    {
        //        FileMixData_Service.Instance.LeveFile.Entries.Add(wrapper.ToEntry());
        //    }
        //
        //    FileMixData_Service.Instance.SaveBarFile("leve");
        //    FileMixData_Service.Instance.SaveMixDataFile();
        //    FileMixData_Service.Instance.LoadFromProject();
        //}
    }
}
