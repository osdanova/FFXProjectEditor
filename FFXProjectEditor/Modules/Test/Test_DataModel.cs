using Avalonia.Threading;
using FFXProjectEditor.FfxLib.Memory;
using FFXProjectEditor.Modules.DebugMenu;
using FFXProjectEditor.Services;
using FFXProjectEditor.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FFXProjectEditor.Modules.Test
{
    internal class Test_DataModel
    {
        private const int _timerMilliseconds = 1000;
        private bool AutoRefreshEnabled = true;

        private int ADDR_PROGRESS = MemoryMap.ADDR_SAVEDATA + 0xBEC;
        private int ADDR_ENC_MOD = MemoryMap.ADDR_SAVEDATA + 0xE4;

        ProgressFlags_Wrapper Progress { get; set; }
        EncounterMods_Wrapper EncMods { get; set; }
        ushort ProgressBytes { get; set; }
        int EncModBytes { get; set; }

        public Test_DataModel()
        {
            Progress = new ProgressFlags_Wrapper(ReadProgress());
            EncMods = new EncounterMods_Wrapper(ReadEncMods());
        }

        public void TimerTask()
        {
            //ushort progressBytes = ReadProgress();
            int encModBytes = ReadEncMods();

            //if (ProgressBytes != progressBytes)
            //    Debug.WriteLine("ProgressBytes: " + progressBytes);
            if (EncModBytes != encModBytes)
                Debug.WriteLine("EncModBytes: " + encModBytes);

            //ProgressBytes = progressBytes;
            EncModBytes = encModBytes;

            //ProgressFlags_Wrapper newProgress = new ProgressFlags_Wrapper(progressBytes);
            EncounterMods_Wrapper newEncMods = new EncounterMods_Wrapper(encModBytes);

            //PropertyUtil.CopyProperties(newProgress, Progress);
            PropertyUtil.CopyProperties(newEncMods, EncMods);
        }

        public ushort ReadProgress()
        {
            return MemSharp_Service.Instance.Read<ushort>(ADDR_PROGRESS);
        }
        public int ReadEncMods()
        {
            return MemSharp_Service.Instance.Read<ushort>(ADDR_ENC_MOD);
        }

        /******************************************
         * REFRESH TIMER
         ******************************************/
        private Timer _timer = new Timer();
        public void StartReading()
        {
            _timer = new Timer(_timerMilliseconds); // 1-second interval
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true; // Keep running periodically
            _timer.Start();
            Debug.WriteLine("TEST timer started");
        }

        public void StopReading()
        {
            if (_timer != null)
            {
                _timer.Elapsed -= OnTimerElapsed; // Unsubscribe event to avoid memory leaks
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
                Debug.WriteLine("TEST timer stopped");
            }
        }

        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            try
            {
                // Enforce the method to run on the UI thread to access the ContentFrames
                Dispatcher.UIThread.Post(() =>
                {
                    try
                    {
                        if (AutoRefreshEnabled)
                        {
                            try
                            {
                                TimerTask();
                            }
                            catch (Exception ex) { }
                        }
                    }
                    catch (Exception ex) { }
                });
            }
            catch (Exception ex) { }
        }
    }
}
