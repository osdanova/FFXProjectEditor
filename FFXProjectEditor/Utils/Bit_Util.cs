using System;

namespace FFXProjectEditor.Utils
{
    public static class Bit_Util
    {
        public static bool GetBit<T>(this T value, int bitPosition) where T : struct
        {
            int intValue = Convert.ToInt32(value);
            return (intValue & (1 << bitPosition)) != 0;
        }
        public static T SetBit<T>(this T value, int bitPosition, bool set) where T : struct
        {
            int intValue = Convert.ToInt32(value);
            if (set)
                intValue |= (1 << bitPosition);
            else
                intValue &= ~(1 << bitPosition);

            return (T)Convert.ChangeType(intValue, typeof(T));
        }

        public static bool GetBit(this byte[] bytes, int bitPosition)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            int byteIndex = bitPosition / 8;
            int bitOffset = bitPosition % 8;

            if (byteIndex >= bytes.Length)
                throw new ArgumentOutOfRangeException(nameof(bitPosition), "Bit position exceeds array bounds.");

            return (bytes[byteIndex] & (1 << bitOffset)) != 0;
        }
        public static void SetBit(this byte[] bytes, int bitPosition, bool set)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            int byteIndex = bitPosition / 8;
            int bitOffset = bitPosition % 8;

            if (byteIndex >= bytes.Length)
                throw new ArgumentOutOfRangeException(nameof(bitPosition), "Bit position exceeds array bounds.");

            if (set)
                bytes[byteIndex] |= (byte)(1 << bitOffset);
            else
                bytes[byteIndex] &= (byte)~(1 << bitOffset);
        }

    }
}
