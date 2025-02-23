using FFXProjectEditor.FfxLib.Common;
using System.Collections.Generic;
using System.IO;

namespace FFXProjectEditor.FfxLib.Arm
{
    public class Arms_Rate
    {
        public static List<int> ReadList(byte[] byteFile)
        {
            EntryListFile listFile = EntryListFile.Unpack(byteFile);

            List<int> rateList = new();
            using (MemoryStream stream = new MemoryStream(listFile.FirstFile))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                for (int i = 0; i < listFile.Header.RealEntryCount; i++)
                {
                    rateList.Add(reader.ReadInt32());
                }
            }

            return rateList;
        }
    }
}
