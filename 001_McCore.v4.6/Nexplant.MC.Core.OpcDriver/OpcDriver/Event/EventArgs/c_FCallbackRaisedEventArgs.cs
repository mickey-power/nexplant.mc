﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCallbackRaisedEventArgs.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2011.10.31
--  Description     : FAMate Core FaOpcDriver Callback Raised Event Arguments Class 
--  History         : Created by Jeff.Kim at 2011.10.31
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    [Serializable]
    public class FCallbackRaisedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpcDriver m_fOpcDriver = null;
        private FCallbackRaisedLog m_fCallbackRaisedLog = null;
        private FScenarioData m_fScenarioData = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FCallbackRaisedEventArgs(            
            FEventId fEventId,
            FOpcDriver fOpcDriver,
            FCallbackRaisedLog fCallbackRaisedLog,
            FScenarioData fScenarioData
            )
            : base(fEventId)
        {
            m_fOpcDriver = fOpcDriver;
            m_fCallbackRaisedLog = fCallbackRaisedLog;
            m_fScenarioData = fScenarioData;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FCallbackRaisedEventArgs(
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
                    m_fOpcDriver = null;
                    m_fCallbackRaisedLog = null;
                    m_fScenarioData = null;
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FOpcDriver fOpcDriver
        {
            get
            {
                try
                {
                    return m_fOpcDriver;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FCallbackRaisedLog fCallbackRaisedLog
        {
            get
            {
                try
                {
                    return m_fCallbackRaisedLog;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FScenarioData fScenarioData
        {
            get
            {
                try
                {
                    return m_fScenarioData;
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
