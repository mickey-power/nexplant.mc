﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseObjectLogCollection.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.29
--  Description     : FAMate Core FaSecsDriver Base Object Log Collection Class 
--  History         : Created by spike.lee at 2011.09.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public abstract class FBaseObjectLogCollection<T1,T2> : FBaseCollection<T1,T2>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPcdlCore m_fPcdlCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FBaseObjectLogCollection(
            FPcdlCore fPcdlCore,
            FXmlNodeList fXmlNodeList
            )
            : base(fXmlNodeList)
        {
            m_fPcdlCore = fPcdlCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FBaseObjectLogCollection(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fPcdlCore = null;
                }                
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        internal FPcdlCore fPcdlCore
        {
            get
            {
                try
                {
                    return m_fPcdlCore;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
