using System.IO;
using System.Timers;

namespace WindowsService
{
    public class Card
    {
        private readonly Timer _cardTimer;

        public Card()
        {
            _cardTimer = new Timer(5000) { AutoReset = true };
            _cardTimer.Elapsed += CardTimerElapsed;
        }

        private void CardTimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] input = new string[] { User.PrintUserLastName() };
            File.AppendAllLines(@"C:\Card.txt", input);
        }

        public void Start()
        {
            _cardTimer.Start();
        }
        public void Stop()
        {
            _cardTimer.Stop();
        }
    }
}
