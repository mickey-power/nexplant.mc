﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagOEI.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.12
--  Description     : FAMate Core FaOpcDriver OPC Event Item XML Tag Definition Class 
--  History         : Created by spike.lee at 2013.07.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal static class FXmlTagOEI
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // OPC Event Item Element and Attribute 
        // ***
        public const string E_OpcEventItem = "OEI";
        // --
        public const string A_UniqueId = "I";
        public const string A_Locked = "LC";
        public const string A_Name = "N";
        public const string A_Description = "D";
        public const string A_FontColor = "FC";
        public const string A_FontBold = "FB";
        public const string A_ItemName = "IN";
        public const string A_ItemFormat = "IF";
        public const string A_ItemArray = "IA";
        public const string A_ItemStart = "IS";
        public const string A_ItemLength = "IL";
        public const string A_AlwaysEvent = "AE";
        public const string A_IgnoreFirst = "IG";
        public const string A_Format = "F";
        public const string A_Length = "L";
        public const string A_Value = "V";
        public const string A_Transformer = "TF";
        public const string A_HashTag = "HT";
        public const string A_UserTag1 = "TG1";
        public const string A_UserTag2 = "TG2";
        public const string A_UserTag3 = "TG3";
        public const string A_UserTag4 = "TG4";
        public const string A_UserTag5 = "TG5";
        // --
        public const string D_UniqueId = "";
        public const string D_Locked = "F";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_FontColor = "Black";
        public const string D_FontBold = "F";
        public const string D_ItemName = "";
        public const string D_ItemFormat = "BL";
        public const string D_ItemArray = "F";
        public const string D_ItemStart = "0";
        public const string D_ItemLength = "1";
        public const string D_AlwaysEvent = "F";
        public const string D_IgnoreFirst = "T";
        public const string D_Format = "";
        public const string D_Length = "0";
        public const string D_Value = "";
        public const string D_Transformer = "";
        public const string D_HashTag = "F";
        public const string D_UserTag1 = "";
        public const string D_UserTag2 = "";
        public const string D_UserTag3 = "";
        public const string D_UserTag4 = "";
        public const string D_UserTag5 = "";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
