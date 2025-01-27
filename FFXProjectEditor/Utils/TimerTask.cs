using System;
using System.Timers;

namespace FFXProjectEditor.Utils
{
    public class TimerTask
    {
        private Timer _timer;
        private Action _task;
        public bool IsRunning => _timer.Enabled;

        // Executes task every X milliseconds
        public TimerTask(double interval, Action task)
        {
            _timer = new Timer(interval);
            _task = task;
            _timer.Elapsed += (sender, e) => ExecuteTask();
            _timer.AutoReset = true; // Currently unused because the timer stops on execution errors
        }

        private void ExecuteTask()
        {
            try
            {
                _task?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Timer Task: {ex.Message}");
                Stop();
            }
        }

        public void Start()
        {
            if (!_timer.Enabled)
            {
                _timer.Start();
                Console.WriteLine("Timer started.");
            }
        }

        public void Stop()
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
                Console.WriteLine("Timer stopped.");
            }
        }

        public void ChangeInterval(double newInterval)
        {
            if (newInterval > 0)
            {
                Console.WriteLine($"Changing timer interval to {newInterval}ms.");
                _timer.Interval = newInterval; // Update the interval
            }
            else
            {
                Console.WriteLine("Invalid interval value.");
            }
        }

        /*
         * USAGE:
         * private TimerTask _timer;
         * _timer = new TimerTask(interval, MonitorPlayerInventory);
         * public void StartMonitoring() => _timer.Start();
         * public void StopMonitoring() => _timer.Stop();
         */
    }
}
