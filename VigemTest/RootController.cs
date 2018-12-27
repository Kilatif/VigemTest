using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HidSharp;
using HidSharp.Reports;

namespace VigemTest
{

    class RootController
    {
        public void Run()
        {
            var list = DeviceList.Local;

            var hidDeviceList = list.GetHidDevices().ToArray();
            hidDeviceList = hidDeviceList.Where(dev => dev.GetManufacturer().Contains("Nintendo")).ToArray();

            if (hidDeviceList.Length == 0)
            {
                return;
            }

            var device = hidDeviceList[0];

            if (device.TryOpen(out var stream))
            {
                stream.ReadTimeout = Timeout.Infinite;
                var reportDescriptor = device.GetReportDescriptor();
                var inputReportBuffer = new byte[device.GetMaxInputReportLength()];
                var inputReceiver = reportDescriptor.CreateHidDeviceInputReceiver();

                inputReceiver.Received += (sender, e) =>
                {
                    inputReceiver.TryRead(inputReportBuffer, 0, out _);
                };

                inputReceiver.Start(stream);
            }

            Console.ReadKey();

            stream.Dispose();
        }
    }
}
