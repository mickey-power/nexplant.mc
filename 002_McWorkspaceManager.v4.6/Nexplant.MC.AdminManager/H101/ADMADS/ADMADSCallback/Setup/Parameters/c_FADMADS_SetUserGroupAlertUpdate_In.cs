/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADS_SetUserGroupAlertUpdate_In.cs
--  Creator         : TJ.Kim
--  Create Date     : 2013.05.16
--  Description     : <Generated Class File Description>
--  History         : Created by TJ.Kim at 2013.05.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    internal static class FADMADS_SetUserGroupAlertUpdate_In
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_ADMADS_SetUserGroupAlertUpdate_In = "ADMADS_SetUserGroupAlertUpdate_In";

        // --

        public const string A_hLanguage = "hLanguage";
        public const string A_hFactory = "hFactory";
        public const string A_hUserId = "hUserId";
        public const string A_hHostIp = "hHostIp";
        public const string A_hHostName = "hHostName";
        public const string A_hStep = "hStep";

        // --

        public const string D_hLanguage = "";
        public const string D_hFactory = "";
        public const string D_hUserId = "";
        public const string D_hHostIp = "";
        public const string D_hHostName = "";
        public const string D_hStep = "";

        // --

        public static class FAlert
        {
            public const string E_Alert = "Alert";

            // --

            public const string A_UserGroup = "UserGroup";
            public const string A_EventType = "EventType";

            // --

            public const string D_UserGroup = "";
            public const string D_EventType = "";

            // --

            public static class FEvent
            {
                public const string E_Event = "Event";

                // --

                public const string A_Event = "Event";
                public const string A_EnabledAlert = "EnabledAlert";

                // --

                public const string D_Event = "";
                public const string D_EnabledAlert = "";
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
