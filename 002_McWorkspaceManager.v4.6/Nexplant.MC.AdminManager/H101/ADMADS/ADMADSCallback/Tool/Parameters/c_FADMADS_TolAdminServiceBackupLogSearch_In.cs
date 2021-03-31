/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2012 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADS_TolAdminServiceBackupLogSearch_In.cs
--  Creator         : baehyun.seo
--  Create Date     : 2013.01.08
--  Description     : Admin Agent Option 
--  History         : Created by baehyun.seo at 2013.01.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.H101Interface
{
    internal static class FADMADS_TolAdminServiceBackupLogSearch_In
    {

        //------------------------------------------------------------------------------------------------------------------------

        public const string E_ADMADS_TolAdminServiceBackupLogSearch_In = "ADMADS_TolAdminServiceBackupLogSearch_In";

        // --

        public const string A_hLanguage = "hLanguage";
        public const string A_hFactory = "hFactory";
        public const string A_hUserId = "hUserId";
        public const string A_hStep = "hStep";

        // --

        public const string D_hLanguage = "";
        public const string D_hFactory = "";
        public const string D_hUserId = "";
        public const string D_hStep = "";

        // --

        public static class FLog
        {
            public const string E_Log = "Log";

            // --

            public const string A_BackupLog = "BackupLog";
            public const string A_NextRowNumber = "NextRowNumber";

            // --

            public const string D_BackupLog = "";
            public const string D_NextRowNumber = "";
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
