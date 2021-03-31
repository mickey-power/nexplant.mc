﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEventArgsBase.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaOpcDriver Event Arguments Base Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    [Serializable]
    public abstract class FEventArgsBase : EventArgs, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FEventId m_fEventId = FEventId.None;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FEventArgsBase(            
            FEventId fOpcEventId
            )
        {
            m_fEventId = fOpcEventId;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEventArgsBase(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                            
                }                

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region Properties

        internal FEventId fOpcEventId
        {
            get
            {
                try
                {
                    return m_fEventId;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FEventId.None;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
