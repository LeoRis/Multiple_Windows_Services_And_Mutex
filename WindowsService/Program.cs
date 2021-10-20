using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace WindowsService
{

    class Program
    {
        static void Main()
        {

            Mutex _mutex = new Mutex();

            bool _userInput = true;

            if (_userInput)
            {
                Console.WriteLine("Insert 1 for true, 0 for false:");
                if (Convert.ToBoolean(Console.ReadLine()))
                {
                    Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            var exitCode = HostFactory.Run(x =>
                            {
                                x.Service<Device>(d =>
                                {
                                    d.ConstructUsing(device => new Device());
                                    d.WhenStarted(device => device.Start());
                                    d.WhenStopped(device => device.Stop());
                                });

                                x.RunAsLocalSystem();

                                x.SetServiceName("DeviceService");
                                x.SetDisplayName("Device Service");
                                x.SetDescription("This is the service for using the device.");
                            });

                            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
                            Environment.ExitCode = exitCodeValue;
                        }
                        finally
                        {
                            _mutex.ReleaseMutex();
                        }
                    });
                }
            }
            else
            {
                var secondExitCode = HostFactory.Run(z =>
                {
                    z.Service<Card>(c =>
                    {
                        c.ConstructUsing(card => new Card());
                        c.WhenStarted(card => card.Start());
                        c.WhenStopped(card => card.Stop());
                    });

                    z.RunAsLocalSystem();

                    z.SetServiceName("CardService");
                    z.SetDisplayName("Card Service");
                    z.SetDescription("This is the service for using the card.");
                });

                int secondExitCodeValue = (int)Convert.ChangeType(secondExitCode, secondExitCode.GetType());
                Environment.ExitCode = secondExitCodeValue;
            }
        }
    }
}
