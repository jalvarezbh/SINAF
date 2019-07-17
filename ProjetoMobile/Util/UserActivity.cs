using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace ProjetoMobile.Util
{
    public sealed class UserActivity : Component, IDisposable
    {

        #region PInvoke declarations
        private static readonly Int32 EVENT_ALL_ACCESS = 0x1F0003;
        private static readonly string Activity = "PowerManager/UserActivity_Active";
        private static readonly string Inactivity = "PowerManager/UserActivity_Inactive";

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern IntPtr OpenEvent(int desiredAccess, bool inheritHandle, string name);

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern IntPtr CreateEvent(IntPtr securityAttributes, bool IsManual, bool initialState, string name);

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern bool EventModify(IntPtr hEvent, UInt32 dEvent);

        private enum EventFlags
        {
            Pulse = 1,
            Reset = 2,
            Set = 3,
        }

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr handle);

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern int WaitForSingleObject(IntPtr handle, UInt32 dwMilliseconds);

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern int WaitForMultipleObjects(UInt32 nCount, IntPtr[] lpHandles, bool fWaitAll, UInt32 dwMilliseconds);

        // In WinCE SetEvent is a Macro that calls EventModify
        private static bool SetEvent(IntPtr hEvent)
        {
            return EventModify(hEvent, (UInt32)EventFlags.Set);
        }
        #endregion

        #region Dispose Pattern for Derived Classes
        protected override void Dispose(bool bDisposing)
        {
            if (bDisposing)
            {
                // destroy Managed resources
            }

            // destroy Unmanaged resources
            SetEvent(QuitHandle);

            base.Dispose(bDisposing);
        }
        #endregion

        private IntPtr QuitHandle;
        private Action<bool> SignalActivity;
        private Control Control;

        /// <summary>
        /// Start monitoring the user activity
        /// </summary>
        /// <param name="control">Windows Form control used to invoke the delegate</param>
        /// <param name="signalActivity">delegate to call when the user activity changes</param>
        public void Start(Control control, Action<bool> signalActivity)
        {
            Control = control;
            SignalActivity = signalActivity;
            QuitHandle = CreateEvent(IntPtr.Zero, true, false, null);
            Thread t = new Thread(MonitorUserActivity);
            t.IsBackground = true;
            t.Start();
        }

        public void Quit()
        {
            this.Dispose();
        }

        public bool IsUserActive { get; private set; }

        private void MonitorUserActivity()
        {
            IntPtr activitySignal = OpenEvent(EVENT_ALL_ACCESS, false, Activity);
            IntPtr inactivitySignal = OpenEvent(EVENT_ALL_ACCESS, false, Inactivity);

            if (activitySignal == IntPtr.Zero || inactivitySignal == IntPtr.Zero)
            {
                return;
            }

            IntPtr[] evtActivity = new IntPtr[] { QuitHandle, activitySignal };
            IntPtr[] evtInactivity = new IntPtr[] { QuitHandle, inactivitySignal };

            // First we have to check for user activity without waiting
            // IsUserActive will be set only if currently there is user activity
            int result = WaitForSingleObject(activitySignal, 0);
            IsUserActive = (result == 0);  // result == 0 <==> object is signaled

            while (true)
            {
                if (IsUserActive)
                    result = WaitForMultipleObjects((uint)evtActivity.Length, evtInactivity, false, uint.MaxValue);
                else
                    result = WaitForMultipleObjects((uint)evtActivity.Length, evtActivity, false, uint.MaxValue);

                if (result == 0)
                {
                    CloseHandle(activitySignal);
                    CloseHandle(inactivitySignal);
                    CloseHandle(QuitHandle);
                    return;
                }

                if (result == -1)
                {
                    Trace.WriteLine("WaitForMultipleObjects returned WAIT_FAILED (-1)");
                    return;
                }

                Debug.Assert(result == 1, "result was already checked for the other possible values");
                IsUserActive = !IsUserActive;
                SetUserActivity(IsUserActive);
            }
        }

        private void SetUserActivity(bool IsActive)
        {
            Control.Invoke(SignalActivity, IsActive);
        }
    }
}
