using System;
using System.Runtime.InteropServices;

namespace ProjetoMobile.Util
{
    public class DataHora
    {
        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        [DllImport("coredll.dll")]
        public extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);

        [DllImport("coredll.dll")]
        public extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);

        [DllImport("coredll.dll")]
        public extern static uint SetLocalTime(ref SYSTEMTIME lpSystemTime);

        public static void AcertaDataHora(DateTime trts)
        {
            SYSTEMTIME st;

            st.wYear = (ushort)trts.Year;
            st.wMonth = (ushort)trts.Month;
            st.wDayOfWeek = (ushort)trts.DayOfWeek;
            st.wDay = (ushort)trts.Day;
            st.wHour = (ushort)trts.Hour;
            st.wMinute = (ushort)trts.Minute;
            st.wSecond = (ushort)trts.Second;
            st.wMilliseconds = (ushort)trts.Millisecond;

            SetSystemTime(ref st);
            SetLocalTime(ref st);
        }
    }
}
