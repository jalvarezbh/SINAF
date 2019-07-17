using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Symbol.Fusion;
using Symbol.Fusion.WLAN;
using Symbol.Exceptions;
using Symbol.Audio;
using Symbol.StandardForms;

namespace ProjetoMobile.Util
{
    public class ControleHardware
    {
        private Symbol.Audio.Controller MyAudioController = null;

        public ControleHardware()
        {
            DesabilitarVolume();
        }

        public void ControlarRadioWiFi(bool ligar)
        {
            try
            {
                WLAN myCommandModeWlan = null;

                myCommandModeWlan = new WLAN(FusionAccessType.COMMAND_MODE);
                
                if (myCommandModeWlan != null)
                {
                    if (ligar)
                    {
                        myCommandModeWlan.Adapters[0].PowerState = Adapter.PowerStates.ON;
                        
                        Profile myProfile = getProfileByName("VITAL", myCommandModeWlan);
                        //Profile myProfile = getProfileByName("teste", myCommandModeWlan);
                        if (myProfile != null)
                        {
                            Symbol.Fusion.FusionResults result = myProfile.Connect(true);
                        }   
                    }
                    else
                        myCommandModeWlan.Adapters[0].PowerState = Adapter.PowerStates.OFF;
                }
                                
                myCommandModeWlan.Dispose();
                myCommandModeWlan = null;
            }
            catch
            {
            }
        }

        public bool VerificarRadioWiFi()
        {            
            try
            {                
                WLAN myCommandModeWlan = null;

                myCommandModeWlan = new WLAN(FusionAccessType.COMMAND_MODE);

                bool status = false;
                if (myCommandModeWlan != null)
                    status = myCommandModeWlan.Adapters[0].PowerState == Adapter.PowerStates.ON;
                
                myCommandModeWlan.Dispose();
                myCommandModeWlan = null;

                return status;
            }
            catch
            {
                return false;
            }

        }

        public void DesabilitarVolume()
        {
            Symbol.Audio.Device MyDevice = (Symbol.Audio.Device)Symbol.StandardForms.SelectDevice.Select(
                Symbol.Audio.Controller.Title,
                Symbol.Audio.Device.AvailableDevices);                        

            //check the device type
            switch (MyDevice.AudioType)
            {
                //if standard device
                case Symbol.Audio.AudioType.StandardAudio:
                    MyAudioController = new Symbol.Audio.StandardAudio(MyDevice);
                    break;

                //if simulated device
                case Symbol.Audio.AudioType.SimulatedAudio:
                    MyAudioController = new Symbol.Audio.SimulatedAudio(MyDevice);
                    break;

                default:
                    break;
            }

            
            this.MyAudioController.BeeperVolume = 0;           
        }

        private Profile getProfileByName(string profileName, WLAN myNewWlan)
        {
            Symbol.Fusion.WLAN.Profiles myProfiles = myNewWlan.Profiles;

            for (int profileIndex = 0; profileIndex < myProfiles.Length; profileIndex++)
            {
                Profile myProfile = myProfiles[profileIndex];
                if (profileName == myProfile.Name)
                {
                    return myProfile;
                }
            }
            return null;
        }           
    }
}
