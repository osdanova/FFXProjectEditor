using FFXProjectEditor.Converters;
using FFXProjectEditor.FfxLib.Arm;
using FFXProjectEditor.FfxLib.Common;
using FFXProjectEditor.FfxLib.Dictionaries;
using FFXProjectEditor.FfxLib.Memory;
using FFXProjectEditor.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Xe.BinaryMapper;

namespace FFXProjectEditor.Modules.InventoryTracker
{
    internal class InventoryTracker_DataModel
    {
        public Process_Service ProcService { get => Process_Service.Instance; }

        public List<int> PriceRates { get; set; } = new();
        public ObservableCollection<GameIndex_Wrapper> InventoryIds { get; set; } = new();
        public ObservableCollection<byte> InventoryCounts { get; set; } = new();
        public ObservableCollection<Equipment_Wrapper> EquipmentList { get; set; } = new();
        public KeyItems_Wrapper KeyItems { get; set; } = new();

        public List<string> CharacterOptions => new Character_Converter().Options.Values.ToList();
        public List<string> TypeOptions => new EquipmentType_Converter().Options.Values.ToList();
        public List<string> DamageFormulaOptions => new DamageFormula_Converter().Options.Values.ToList();
        public List<string> GameCategoryOptions => new GameCategory_Converter().Options.Values.ToList();
        public List<string> AssetCategoryOptions => new AssetCategory_Converter().Options.Values.ToList();


        public InventoryTracker_DataModel()
        {
            LoadPriceRates();
            LoadData();
        }

        public void LoadPriceRates()
        {
            if (Project_Service.Instance.IsProjectLoaded)
            {
                byte[] byteFile = File.ReadAllBytes(Project_Service.Instance.Path_KernelArmsRate);
                PriceRates = Arms_Rate.ReadList(byteFile);
            }
            else
            {
                PriceRates = AutoAbilityPrice_Dictionary.Instance.Values.ToList();
            }
        }

        public void SellSelected(List<Equipment_Wrapper> selectedEquipment)
        {
            if (!Process_Service.Instance.IsAlive)
                return;

            int gil = MemSharp_Service.Instance.Read<int>(MemoryMap.ADDR_SAVE_GIL);
            foreach (Equipment_Wrapper equipment in selectedEquipment)
            {
                if (!equipment.exists ||
                    equipment.FlagIsBrotherhood || equipment.flagIsCelestial || equipment.flagIsSummon || equipment.flagIsHidden || 
                    equipment.characterEquipped != Character_Enum.None)
                    continue;

                equipment.Exists = false;
                gil += equipment.sellPrice;
            }
            WriteEquipment();
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_SAVE_GIL, gil);
        }

        public void LoadData()
        {
            if (!ProcService.IsAlive)
                return;

            ReadItemIdData();
            ReadItemCountData();
            ReadKeyItems();

            // EQUIPMENT
            EquipmentList.Clear();

            byte[] equipmentBytes = ReadEquipmentData();
            using (MemoryStream stream = new MemoryStream(equipmentBytes))
            {
                EquipmentHelper equipment = BinaryMapping.ReadObject<EquipmentHelper>(stream);

                foreach(EquipmentStruct equip in equipment.EquipmentList)
                {
                    Equipment_Wrapper wrapper = Equipment_Wrapper.Wrap(equip);
                    wrapper.SellPrice = EquipmentPrice_Util.GetEquipmentPrice(equip);
                    EquipmentList.Add(wrapper);
                }
            }
        }

        public byte[] ReadSaveData()
        {
            return MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_SAVEDATA, MemoryMap.SIZE_SAVEDATA);
        }
        public void ReadItemIdData()
        {
            InventoryIds.Clear();
            foreach (ushort itemId in MemSharp_Service.Instance.Read<ushort>(MemoryMap.ADDR_SAVE_ITEM_IDS, MemoryMap.COUNT_SAVE_ITEM))
            {
                InventoryIds.Add(GameIndex_Wrapper.Wrap(itemId));
            }
        }
        public void ReadItemCountData()
        {
            InventoryCounts.Clear();
            foreach (byte itemCount in MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_SAVE_ITEM_COUNTS, MemoryMap.COUNT_SAVE_ITEM))
            {
                InventoryCounts.Add(itemCount);
            }
        }
        public void WriteSaveData()
        {
            List<ushort> inventoryIds = new();
            foreach (var inventoryId in InventoryIds)
                inventoryIds.Add(inventoryId.Unwrap());

            MemSharp_Service.Instance.Write(MemoryMap.ADDR_SAVE_ITEM_IDS, inventoryIds.ToArray());
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_SAVE_ITEM_COUNTS, InventoryCounts.ToArray());
        }


        // For some reason BinaryMapping can't read a loop of 178 items, it reads the first one 178 times...
        public class EquipmentHelper
        {
            [Data(Count = 178)] public List<EquipmentStruct> EquipmentList { get; set; } = new();
        }
        public byte[] ReadEquipmentData()
        {
            return MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_EQUIPMENT, MemoryMap.COUNT_EQUIPMENT * MemoryMap.SIZE_EQUIPMENT);
        }
        public void WriteEquipment()
        {
            EquipmentHelper equipHelper = new EquipmentHelper();
            foreach(Equipment_Wrapper wrapper in EquipmentList)
            {
                equipHelper.EquipmentList.Add(wrapper.Unwrap());
            }
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryMapping.WriteObject(stream, equipHelper);
                MemSharp_Service.Instance.Write(MemoryMap.ADDR_EQUIPMENT, stream.ToArray());
            }
        }

        public void ReadKeyItems()
        {
            KeyItems = new KeyItems_Wrapper();
            KeyItems.KeyItemBytes = MemSharp_Service.Instance.Read<byte>(MemoryMap.ADDR_SAVE_KEY_ITEMS, 7);
        }
        public void WriteKeyItems()
        {
            MemSharp_Service.Instance.Write(MemoryMap.ADDR_SAVE_KEY_ITEMS, KeyItems.KeyItemBytes);
        }
    }
}
