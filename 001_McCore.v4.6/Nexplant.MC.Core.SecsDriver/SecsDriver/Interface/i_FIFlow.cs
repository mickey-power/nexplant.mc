﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : i_FIFlow.cs
--  Creator         : spike.lee
--  Create Date     : 2011.05.30
--  Description     : FAMate Core FaSecsDriver Flow Type Object Interface
--  History         : Created by spike.lee at 2011.05.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public interface FIFlow
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        FFlowType fFlowType
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        FIFlow fPreviousSibling
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        FIFlow fNextSibling
        {
            get;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        FIFlow pasteSibling(
            );     
  
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Interface end
}   // Namespace end