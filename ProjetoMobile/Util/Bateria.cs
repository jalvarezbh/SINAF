using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ProjetoMobile.Util
{
    internal class SYSTEM_POWER_STATUS_EX
    {
        public byte ACLineStatus;
        public byte BatteryFlag;
        public byte BatteryLifePercent;
        public byte Reserved1;
        public uint BatteryLifeTime;
        public uint BatteryFullLifeTime;
        public byte Reserved2;
        public byte BackupBatteryFlag;
        public byte BackupBatteryLifePercent;
        public byte Reserved3;
        public uint BackupBatteryLifeTime;
        public uint BackupBatteryFullLifeTime;
    }

    public class Bateria
    {
        public Bateria()
        {
        }

        [DllImport("coredll")]
        private static extern uint GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX lpSystemPowerStatus, bool fUpdate);

        public int BatteryLifePercent
        {
            get
            {
                SYSTEM_POWER_STATUS_EX status = new SYSTEM_POWER_STATUS_EX();
                if (GetSystemPowerStatusEx(status, false) == 1)
                {
                    return status.BatteryLifePercent;
                }
                else
                {
                    return 100;
                }
            }
        }

        public bool UsingACPower
        {
            get
            {
                SYSTEM_POWER_STATUS_EX status = new SYSTEM_POWER_STATUS_EX();
                if (GetSystemPowerStatusEx(status, false) == 1)
                {
                    return (status.ACLineStatus == 1);
                }
                else
                {
                    return false;
                }
            }
        }

        public Image BatteryImage()
        {
            Bateria status = new Bateria();

            if (status.BatteryLifePercent > 75)
            {
                return ProjetoMobile.Properties.Resources.Bateria_100;
            }
            else if (status.BatteryLifePercent > 50)
            {
                return ProjetoMobile.Properties.Resources.Bateria_75;
            }
            else if (status.BatteryLifePercent > 25)
            {
                return ProjetoMobile.Properties.Resources.Bateria_50;
            }
            else
            {
                return ProjetoMobile.Properties.Resources.Bateria_25;
            }
        }
    }
}
