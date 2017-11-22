using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NationalInstruments.VisaNS;
//using Ivi.Visa;


namespace Csharp
{
    public class Lecroy : IScope
    {
        public Lecroy()
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
        private MessageBasedSession mbSession;//Provides access to the message-based functionality, such as reading and writing, available in VISA.
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   Connect
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.10
        //
        //! @brief  :   利用NI VISA找出Lecroy的INTSR，做為和usb的溝通
        //
        //! @param  :   TYPE eScopeType
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        public void Connect(TYPE eScopeType)
        {
            ResourceManager rm = ResourceManager.GetLocalManager();
            mbSession = (MessageBasedSession)rm.Open("USB0::0x05FF::0x1023::LCRY3703N15385::INSTR");
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   Disconnect
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.10
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
            mbSession.Dispose();
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   Init
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.10
        //
        //! @brief  :   osilloscope setting
        //
        //! @param  :   NONE
        //
        //! @return :   NONE
        //
        //**********************************************************************************************************************
        public void Init()
        {
            mbSession.Write("*RST");//reset

            mbSession.Write("C2:TRA ON");//channel2, enables the display of a trace

            mbSession.Write("C1:ATTN 1000");//Selects the vertical attenuation factor of the probe
            mbSession.Write("C2:ATTN 1");

            mbSession.Write("C1:VDIV 500V");//Sets the vertical sensitivity in volts/div. 
            mbSession.Write("C2:VDIV 500MV");

            mbSession.Write("TDIV 1MS");//Modifies the timebase setting. 
            mbSession.Write("C1:TRLV 40V");//Adjusts the level of the specified trigger source. 

            mbSession.Write("TRMD AUTO");//Specifies Trigger mode.
        }
        //**********************************************************************************************************************
        //
        // Copyright (C) 2017, ND CO.,LTD. Taiwan  All Rights Reserved
        //
        //! @fn     :   RMS_Get
        //
        //! @author :   Grace.Lee
        //
        //! @date   :   2017.07.10
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
            string strCmd = "C" + uiChannel + ":PAVA? RMS ";//Returns current parameter, mask test values.
            string strData = mbSession.Query(strCmd);
            //Query:Performs a synchronous write of byte array data, followed by a synchronous read.
            
            string[] strSplit = strData.Split(',');//根據陣列中的字元分割字串成子字串。

            return Convert.ToDouble(strSplit[1].Trim('V'));//移除陣列中指定之一組字元的所有開頭和結尾指定項目。
        }
    }
}
