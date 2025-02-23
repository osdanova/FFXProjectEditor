namespace FFXProjectEditor.Modules.DebugMenu
{
    internal class ChocoboData_Wrapper
    {
        public byte[] bytes { get; set; } = new byte[4];

        public byte BalloonsOwn { get => bytes[0]; set => bytes[0] = value; }
        public byte BalloonsOpponent { get => bytes[1]; set => bytes[1] = value; }
        public byte HitsOwn { get => bytes[2]; set => bytes[2] = value; }
        public byte HitsOpponent { get => bytes[3]; set => bytes[3] = value; }
    }
}
