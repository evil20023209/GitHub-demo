using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.VisaNS;
using Ivi.Visa;
using System.Windows.Forms;

namespace Csharp
{
    public class Keysight : IScope
    {
        public Keysight()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }
        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");

            dllName = dllName.Replace(".", "_");

            if (dllName.EndsWith("_resources")) return null;

            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());

            byte[] bytes = (byte[])rm.GetObject(dllName);

            return System.Reflection.Assembly.Load(bytes);
        }
        private MessageBasedSession mbSession;
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   Connect
        //
        //! @author :   Sean.Lin
        //
        //! @date   :   2017.10.12
        //
        //! @brief  :   01. 利用NI VISA找出Keysight的INTSR，做為和usb的溝通 
        //              02. 修正示波器(型號:KEYSIGHT 4024A)連結失敗的問題，修改Resource name由USB0::0x0957::0x17A6::MY56310669::INSTR 
        //                  更正為USB0::0x0957::0x17A6::MY56310667::INSTR
        //
        //! @param  :   TYPE eScopeType
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        public void Connect(TYPE eScopeType)
        {
            ResourceManager rm = ResourceManager.GetLocalManager();
            //using (var rmSession = new ResourceManager())
            //{
            switch (eScopeType)
            {

                //case (TYPE.KEYSIGHT_2024A):
                //    mbSession = (MessageBasedSession)rmSession.Open("USB0::0x0957::0x1796::MY54490605::0::INSTR");
                //    break;
                //case (TYPE.KEYSIGHT_4024A):
                //    mbSession = (MessageBasedSession)rmSession.Open("USB0::0x0957::0x17A6::MY56310669::INSTR");
                //    break;
                case (TYPE.KEYSIGHT_2024A):
                    mbSession = (MessageBasedSession)rm.Open("USB0::0x0957::0x1796::MY54490605::0::INSTR");
                    break;
                //case (TYPE.KEYSIGHT_4024A):
                //    mbSession = (MessageBasedSession)rm.Open("USB0::0x0957::0x17A6::MY56310669::INSTR");  //修改10669->10667 Sean.Lin_20171012  667<->669
                //    break;
                case (TYPE.KEYSIGHT_4024A):
                    mbSession = (MessageBasedSession)rm.Open("USB0::0x0957::0x17A6::MY56310667::INSTR");
                    break;
            }
            //}
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   Disconnect
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.06
        //
        //! @brief  :   Let PC disconnect osilloscope.
        //
        //! @param  :   NONE
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        public void Disconnect()
        {
            mbSession.Dispose();//Releases all resources 
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   Init
        //
        //! @author :   Sean.Lin
        //
        //! @date   :   2017.10.12
        //
        //! @brief  :   01. osilloscope setting
        //              02. scale set 500mV->1000mV，垂直刻度由每格500mA->1A，改善高瓦數電流Overflow問題
        //
        //! @param  :   NONE
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        public void Init()
        {
            //mbSession.RawIO.Write("*RST");//reset

            //mbSession.RawIO.Write(":CHANnel2:DISPlay 1");//turns the display of the channel2 on
            //mbSession.RawIO.Write(":CHANnel2:UNITs AMPere");//sets the measurement units for the connected probe. Select VOLT for a voltage probe and select AMPere for a current probe.

            ////specifies the probe attenuation(衰減) factor for the selected channel. 
            ////The probe attenuation factor may be 0.001 to 10000.
            //mbSession.RawIO.Write(":CHANnel1:PROBe 1000");
            //mbSession.RawIO.Write(":CHANnel2:PROBe 1");

            ////CHANnel<n>:SCALe sets the vertical scale, or units per division, of the selected channel.
            ////If the probe attenuation is changed, the scale value is multiplied by the probe's attenuation factor
            //mbSession.RawIO.Write(":CHANnel1:SCALe 500V");
            //mbSession.RawIO.Write(":CHANnel2:SCALe 500mV");

            //mbSession.RawIO.Write(":TIMebase:RANGe 0.01");//sets the full-scale horizontal time in seconds for the main window. The range is 10 times the current time-per-division setting.
            //mbSession.RawIO.Write(":TRIGger[:EDGE]:LEVel 40");//sets the trigger level voltage for the active trigger source.

            /////////////////////////////////////
            mbSession.Write("*RST");//reset

            mbSession.Write(":CHANnel2:DISPlay 1");//turns the display of the channel2 on
            mbSession.Write(":CHANnel2:UNITs AMPere");//sets the measurement units for the connected probe. Select VOLT for a voltage probe and select AMPere for a current probe.

            //specifies the probe attenuation(衰減) factor for the selected channel. 
            //The probe attenuation factor may be 0.001 to 10000.
            mbSession.Write(":CHANnel1:PROBe 1000");
            mbSession.Write(":CHANnel2:PROBe 1");

            //CHANnel<n>:SCALe sets the vertical scale, or units per division, of the selected channel.
            //If the probe attenuation is changed, the scale value is multiplied by the probe's attenuation factor
            mbSession.Write(":CHANnel1:SCALe 500V");
            //mbSession.Write(":CHANnel2:SCALe 500mV"); //更改500mV->1000mV   OS垂直刻度由每格500mA->1A   Sean.Lin20171012
            mbSession.Write(":CHANnel2:SCALe 1000mV");

            mbSession.Write(":TIMebase:RANGe 0.01");//sets the full-scale horizontal time in seconds for the main window. The range is 10 times the current time-per-division setting.
            mbSession.Write(":TRIGger[:EDGE]:LEVel 40");//sets the trigger level voltage for the active trigger source.
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   RMS_Get
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.06
        //
        //! @brief  :   get the rms value of osilloscope voltage and currnet.
        //
        //! @param  :   uint uiChannel: =1:voltage probe
        //                              =2:current probe
        //
        //! @return :   volatage or currnet value.
        //
        //**********************************************************************************************************************
        public double RMS_Get(uint uiChannel)
        {
            //string strCmd = ":MEASure:VRMS? CYCLE,AC,CHANnel" + uiChannel;//installs a screen measurement and starts an RMS value measurement.
            //Query:Performs a synchronous write of byte array data, followed by a synchronous read.
            //mbSession.SynchronizeCallbacks = true;

            //mbSession.RawIO.Write(strCmd);
            //string strData = mbSession.RawIO.ReadString();
            string strCmd = ":MEASure:VRMS? AC,CHANnel" + uiChannel;
            string strData = mbSession.Query(strCmd);


            return Convert.ToDouble(strData);
        }
    }
}
