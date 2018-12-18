using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.DualShock4;
using static Nefarius.ViGEm.Client.Targets.DualShock4.DualShock4Buttons;

namespace VigemTest
{
    class RootController
    {
        public void Run()
        {
            var vClient = new ViGEmClient();
            var dsTarget = new DualShock4Controller(vClient);
            dsTarget.Connect();

            Console.ReadLine();

            dsTarget.SendReport(new DualShock4Report
            {
                Buttons = (ushort)(Square | Circle | Triangle | Cross),
               // SixAxes = new byte[] {0x00, 0x00, 0x00, 0xA0, 0xA1, 0xB0, 0xB1, 0xC0, 0xC1, 0xD0, 0xD1, 0xE0, 0xE1, 0xF0, 0xF1}
            });


            Console.ReadLine();

            dsTarget.Disconnect();
        }

        private async Task SendReports(DualShock4Controller target, CancellationToken stopToken)
        {
            do
            {
                target.SendReport(new DualShock4Report
                {
                    Buttons = (ushort)(Square | Circle | Triangle | Cross),
                });

                await Task.Delay(10, stopToken);
                if (stopToken.IsCancellationRequested)
                {
                    return;
                }

            } while (true);
        }
    }
}
