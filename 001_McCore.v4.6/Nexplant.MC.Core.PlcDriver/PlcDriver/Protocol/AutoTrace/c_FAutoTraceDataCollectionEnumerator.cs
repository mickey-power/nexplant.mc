﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FAutoTraceDataCollectionEnumerator.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.11.18
--  Description     : FAMate Core FaPlcDriver Auto Trace Data Collection Enumerator Class 
--  History         : Created by jungyoul.moon at 2013.11.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FAutoTraceDataCollectionEnumerator : FBaseCollectionEnumerator<FAutoTraceDataCollection>
    {

        //------------------------------------------------------------------------------------------------------------------------        

        #region Class Construction and Destruction

        public FAutoTraceDataCollectionEnumerator(
            FAutoTraceDataCollection collection
            ) 
            : base(collection)
        {
            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------     
            
    }   // Class end
}   // Namespace end
