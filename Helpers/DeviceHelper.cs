using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Estore.Ce.Helpers
{
    public class DeviceHelper
    {
        public static string GetDeviceId()
        {
            string deviceId;
            string deviceSerial = GetSerialNumber();
            switch (deviceSerial)
            {
                case "0x1C21A6016048A847":
                    deviceId = "SJUS1";
                    break;
                case "0x05059801D5476EF7":
                    deviceId = "SJUS2";
                    break;
                case "0x00195B2FF60701082D1C0C10080C2807":
                    deviceId = "GL1";
                    break;
                case "0x0596C202AA46C06A":
                    deviceId = "JCP1";
                    break;
                case "0x00195B2FF607010810151301040F3006":
                    deviceId = "JCP2";
                    break;
                case "0x00195B2FF607010835050B10080C2803":
                    deviceId = "JCP3";
                    break;
                case "0x04819F011F48528A":
                    deviceId = "JCP4";
                    break;
                default:
                    deviceId = "Unlicensed";
                    break;
            };
            return deviceId;
        }

        public static string GetSerialNumber()
        {
            Symbol.ResourceCoordination.TerminalInfo Version = new Symbol.ResourceCoordination.TerminalInfo();
            System.Text.StringBuilder MyUUID = new StringBuilder("0x");
            if (Version.UniqueUnitID != null)
            {
                //this code is actually from the Motorola SDK guid 
                foreach (byte b in Version.UniqueUnitID)
                {
                    MyUUID.Append(b.ToString("X2"));
                }
            }
            return MyUUID.ToString();
        }
    }
}
