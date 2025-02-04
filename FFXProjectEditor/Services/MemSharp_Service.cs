using Binarysharp.MSharp;
using FFXProjectEditor.Utils;
using System;
using System.Text;

namespace FFXProjectEditor.Services
{
    public class MemSharp_Service : SingletonBase<MemSharp_Service>
    {
        public MemorySharp MemSharp { get; set; }

        public bool IsAvailable()
        {
            if (!OperatingSystem.IsWindows())
            {
                return false;
            }

            if (Process_Service.Instance.IsAlive)
            {
                if (MemSharp == null)
                {
                    MemSharp = new MemorySharp(Process_Service.Instance.GameProcess);
                    return true;
                }

                if (MemSharp.IsRunning)
                {
                    return true;
                }
                else
                {
                    MemSharp = new MemorySharp(Process_Service.Instance.GameProcess);
                    return true;
                }
            }

            return false;
        }

        private readonly Encoding _defaultEncoding = Encoding.UTF8;
        public T Read<T>(int offset, bool isRelative = true)
        {
            if (!IsAvailable()) return default(T);
            return MemSharp.Read<T>((IntPtr)offset, isRelative);
        }
        public T[] Read<T>(int offset, int count, bool isRelative = true)
        {
            if (!IsAvailable()) return default(T[]);
            return MemSharp.Read<T>((IntPtr)offset, count, isRelative);
        }
        public string ReadString(int offset, int strLength = 512, Encoding? enc = null, bool isRelative = true)
        {
            if (!IsAvailable()) return "";
            if (enc == null) enc = _defaultEncoding;
            return MemSharp.ReadString((IntPtr)offset, enc, isRelative, strLength);
        }

        public void Write(int offset, byte[] value, bool isRelative = true)
        {
            if (!IsAvailable()) return;
            MemSharp.Write((IntPtr)offset, value, isRelative);
        }
        public void Write<T>(int offset, T value, bool isRelative = true)
        {
            if (!IsAvailable()) return;
            MemSharp.Write((IntPtr)offset, value, isRelative);
        }
        public void Write<T>(int offset, T[] value, bool isRelative = true)
        {
            if (!IsAvailable()) return;
            MemSharp.Write((IntPtr)offset, value, isRelative);
        }
        public void WriteString(int offset, string text, Encoding? enc = null, bool isRelative = true)
        {
            if (!IsAvailable()) return;
            if (enc == null) enc = _defaultEncoding;
            MemSharp.WriteString((IntPtr)offset, text, enc, isRelative);
        }
    }
}
