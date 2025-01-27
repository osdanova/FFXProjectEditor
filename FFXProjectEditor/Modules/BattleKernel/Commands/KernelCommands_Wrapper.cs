using CommunityToolkit.Mvvm.ComponentModel;
using FFXProjectEditor.FfxLib.Ability;
using FFXProjectEditor.FfxLib.Common;
using FFXProjectEditor.Utils;
using FFXProjectEditor.Utils.Encoding;
using static FFXProjectEditor.FfxLib.Ability.Ability_Command;

namespace FFXProjectEditor.Modules.BattleKernel.Commands
{
    internal partial class KernelCommands_Wrapper : ObservableObject
    {
        [ObservableProperty] public int index;
        [ObservableProperty] public short anim1Id;
        [ObservableProperty] public short anim2Id;
        [ObservableProperty] public byte iconId;
        [ObservableProperty] public byte casterAnimId;
        [ObservableProperty] public byte menuProperties;
        [ObservableProperty] public byte subSubMenuCategorization;
        [ObservableProperty] public byte subMenuCategorization;
        [ObservableProperty] public sbyte characterUser;
        [ObservableProperty] public byte targetingFlags;
        [ObservableProperty] public byte targetsAllowed; // Apparently
        [ObservableProperty] public byte variousProperties1;
        [ObservableProperty] public byte variousProperties2;
        [ObservableProperty] public byte variousProperties3;
        [ObservableProperty] public byte animProperties;
        [ObservableProperty] public byte damageProperties;
        [ObservableProperty] public byte stealGil;
        [ObservableProperty] public byte partyPreview;
        [ObservableProperty] public byte damageType;
        [ObservableProperty] public byte moveRank;
        [ObservableProperty] public byte costMp;
        [ObservableProperty] public byte costOverdrive;
        [ObservableProperty] public byte attackCritBonus;
        [ObservableProperty] public byte damageFormula;
        [ObservableProperty] public byte attackAccuracy;
        [ObservableProperty] public byte attackPower;
        [ObservableProperty] public byte hitCount;
        [ObservableProperty] public byte shatterChance;
        [ObservableProperty] public byte elementFlags;
        [ObservableProperty] public StatsusSbyteList statusChance;
        [ObservableProperty] public StatsusDurationSbyteList statusDuration;
        [ObservableProperty] public short statusExtraFlags;
        [ObservableProperty] public short statBuffFlags;
        [ObservableProperty] public byte overdriveCategory;
        [ObservableProperty] public byte statBuffValue;
        [ObservableProperty] public short specialBuffFlags;
        //[ObservableProperty] public byte orderingIndexInMenu;
        //[ObservableProperty] public byte sphereTypeForSphereGrid;
        //[ObservableProperty] public byte unk1;
        //[ObservableProperty] public byte unk2;
        [ObservableProperty] public ExtraCommandInfo extraInfo;

        [ObservableProperty] public byte[] nameScriptBytes;
        [ObservableProperty] public byte[] unusedText1ScriptBytes;
        [ObservableProperty] public byte[] descriptionScriptBytes;
        [ObservableProperty] public byte[] unusedText2ScriptBytes;
        // Text ids kept to keep the original data. Ideally this would be calculated.
        [ObservableProperty] public ushort nameScriptId;
        [ObservableProperty] public ushort unusedText1ScriptId;
        [ObservableProperty] public ushort descriptionScriptId;
        [ObservableProperty] public ushort unusedText2ScriptId;

        public string Name => FfxEncoding.DecodeScript(nameScriptBytes).GetString(FfxEncoding.UsDecoder);
        public string Description => FfxEncoding.DecodeScript(descriptionScriptBytes).GetString(FfxEncoding.UsDecoder);

        public static KernelCommands_Wrapper Wrap(Ability_Command command)
        {
            KernelCommands_Wrapper wrapper = new();

            PropertyUtil.CopyProperties(command, wrapper);

            return wrapper;
        }
        public Ability_Command Unwrap()
        {
            Ability_Command command = new();

            PropertyUtil.CopyProperties(this, command);

            return command;
        }
    }
}
