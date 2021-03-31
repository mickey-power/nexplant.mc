﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : i_FIProcedureExecutor.cs
--  Creator         : byjeon
--  Create Date     : 2014.08.11
--  Description     : FAMate Core FaCommon Database ProcedureExecutor Interface
--  History         : Created by byjeon at 2014.08.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public interface FIProcedureExecutor
    {
        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        string connectionString
        {
            get;
            set;
        }

        int timeout
        {
            get;
            set;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        FDbOutputCollection execute(
            FProcedure fProcedure
            );

        //------------------------------------------------------------------------------------------------------------------------

        FDbOutputCollection execute(
            FProcedure fProcedure,
            int timeout
            );

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    } // Interface end
} // Namespace end
