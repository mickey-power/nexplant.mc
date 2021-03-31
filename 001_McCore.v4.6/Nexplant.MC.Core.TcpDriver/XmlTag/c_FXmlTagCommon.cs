﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlTagCommon.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.09
--  Description     : FAMate Core FaTcpDriver Common XML Tag Definition Class 
--  History         : Created by spike.lee at 2013.07.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal static class FXmlTagCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // Common Attribute 
        // ***        
        public const string A_UniqueId = "I";        
        public const string A_Locked = "LC";
        public const string A_Name = "N";
        public const string A_Description = "D";
        public const string A_LogUniqueId = "Q";
        // --
        public const string D_UniqueId = "0";        
        public const string D_Locked = "F";
        public const string D_Name = "";
        public const string D_Description = "";
        public const string D_LogUniqueId = "0";

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
