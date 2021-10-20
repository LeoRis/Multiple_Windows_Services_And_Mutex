using System;
using System.IO;
using System.Timers;

namespace WindowsService
{
    public class Device
    {
        private readonly Timer _timer;

        public Device()
        {
            _timer = new Timer(5000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] input = new string[] { User.PrintUserFirstName() };
            File.AppendAllLines(@"C:\Device.txt", input);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

    }
}
