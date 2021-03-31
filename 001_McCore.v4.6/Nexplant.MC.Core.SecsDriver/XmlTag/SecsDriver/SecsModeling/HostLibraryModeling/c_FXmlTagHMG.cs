﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagHMG.cs
--  Creator         : Kimsh
--  Create Date     : 2011.03.08
--  Description     : FAMate Core FaSecsDriver Host Message XML Tag Definition Class 
--  History         : Created by Kimsh at 2011.03.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal static class FXmlTagHMG
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Host Message Type
        // ***
        public const string M_Message = "M";
        public const string M_MessageTransfer = "T";
        public const string M_HostDriverDataMessage = "D";

        // --

        // ***
        // Host Message Element and Attribute 
        // ***
        public const string E_HostMessage = "HMG";
        // --
        public const string A_MessageType = "M";
        public const string A_UniqueId = "I";
        public const string A_Locked = "LC";
        public const string A_Name = "N";
        public const string A_Description = "D";
        public const string A_FontColor = "FC";
        public const string A_FontBold = "FB";
        public const string A_Command = "C";        
        public const string A_Version = "V";        
        public const string A_HostMessageType = "MT";
        public const string A_MultiCastMessage = "MC";
        public const string A_GuaranteedMessage = "GT";
        // --
        public const string A_CastChannel = "CC";
        // --
        public const string A_Spooling = "SP";
        public const string A_AutoReply = "A";
        public const string A_LogEnabled = "LE";
        public const string A_LogLevel = "LV";      // 2017.07.04 by spike.lee Log Level Add
        public const string A_UserTag1 = "TG1";
        public const string A_UserTag2 = "TG2";
        public const string A_UserTag3 = "TG3";
        public const string A_UserTag4 = "TG4";
        public const string A_UserTag5 = "TG5";
        // --
        public const string D_MessageType = "M";
        public const string D_UniqueId = "";
        public const string D_Locked = "F";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_Command = "";
        public const string D_Version = "";
        public const string D_HostMessageType = "";
        public const string D_MultiCastMessage = "F";
        public const string D_GuaranteedMessage = "F";
        // --
        public const string D_CastChannel = "";
        // --
        public const string D_Spooling = "F";
        public const string D_AutoReply = "T";
        public const string D_LogEnabled = "T";
        public const string D_LogLevel = "1";       // 2017.07.04 by spike.lee Log Level Add
        public const string D_UserTag1 = "";
        public const string D_UserTag2 = "";
        public const string D_UserTag3 = "";
        public const string D_UserTag4 = "";
        public const string D_UserTag5 = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
