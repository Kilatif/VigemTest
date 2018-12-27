using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidSharp;

namespace VigemTest
{
    enum SixAxisSource
    {
        Left, Right
    }

    class JoyConsProDevice
    {
        private const int LeftJoyConProductId = 0x2006;
        private const int RightJoyConProductId = 0x2007;

        private HidDevice _leftJoyCon;
        private HidDevice _rightJoyCon;

        public SixAxisSource _sixAxisSource = SixAxisSource.Right;

        public void Initialize()
        {
            var list = DeviceList.Local;

            var hidDeviceList = list.GetHidDevices().ToArray();
            hidDeviceList = hidDeviceList.Where(dev => dev.GetManufacturer().Contains("Nintendo")).ToArray();
        }
    }
}
