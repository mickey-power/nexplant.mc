﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostDeviceDataMessageReceivedEventArgs.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaPlcDriver Host Device Data Message Received Event Arguments Class 
--  History         : Created by Jeff.Kim at 2013.07.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    [Serializable]
    public class FHostDeviceDataMessageReceivedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPlcDriver m_fPlcDriver = null;
        private FHostDevice m_fHostDevice = null;
        private FHostSession m_fHostSession = null;
        private FHostDeviceDataMessageReceivedLog m_fHostDeviceDataMessageReceivedLog = null;
        private FHostMessage m_fReplyHostMessage = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FHostDeviceDataMessageReceivedEventArgs(            
            FEventId fEventId,
            FPlcDriver fPlcDriver,
            FHostDevice fHostDevice,
            FHostSession fHostSession,
            FHostDeviceDataMessageReceivedLog fHostDeviceDataMessageReceivedLog,
            FHostMessage fReplyHostMessage
            )
            : base(fEventId)
        {
            m_fPlcDriver = fPlcDriver;
            m_fHostDevice = fHostDevice;
            m_fHostSession = fHostSession;
            m_fHostDeviceDataMessageReceivedLog = fHostDeviceDataMessageReceivedLog;
            m_fReplyHostMessage = fReplyHostMessage;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostDeviceDataMessageReceivedEventArgs(
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
                    m_fPlcDriver = null;
                    m_fHostDevice = null;
                    m_fHostSession = null;
                    m_fHostDeviceDataMessageReceivedLog = null;
                    m_fReplyHostMessage = null;
                }                

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FPlcDriver fPlcDriver
        {
            get
            {
                try
                {
                    return m_fPlcDriver;
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

        public FHostDevice fHostDevice
        {
            get
            {
                try
                {
                    return m_fHostDevice;
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

        public FHostSession fHostSession
        {
            get
            {
                try
                {
                    return m_fHostSession;
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

        public FHostDeviceDataMessageReceivedLog fHostDeviceDataMessageReceivedLog
        {
            get
            {
                try
                {
                    return m_fHostDeviceDataMessageReceivedLog;
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

        public FHostMessage fReplyHostMessage
        {
            get
            {
                try
                {
                    return m_fReplyHostMessage;
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
