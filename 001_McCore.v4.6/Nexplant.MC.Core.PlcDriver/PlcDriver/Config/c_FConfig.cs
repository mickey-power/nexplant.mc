﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FConfig.cs
--  Creator         : spike.lee
--  Create Date     : 2012.11.19
--  Description     : FAMate Core FaSecsDriver Confuguration Class 
--  History         : Created by spike.lee at 2012.11.19
                        - 기존 FEventConfig와 FLogConfig 통합 및 Host Driver Directory와 Log Directory Config까지 통합
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FConfig : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_eapName = string.Empty;
        // --
        private string m_hostDriverDirectory = string.Empty;
        private string m_logDirectory = string.Empty;        
        // --
        private bool m_enabledEventsOfPlcDeviceState = false;
        private bool m_enabledEventsOfPlcDeviceError = false;
        private bool m_enabledEventsOfPlcDeviceTimeout = false;
        private bool m_enabledEventsOfPlcDeviceData = false;
        private bool m_enabledEventsOfPlcDeviceDataMessage = false;
        // --
        private bool m_enabledEventsOfHostDeviceState = false;
        private bool m_enabledEventsOfHostDeviceError = false;
        private bool m_enabledEventsOfHostDeviceVfei = false;
        private bool m_enabledEventsOfHostDeviceDataMessage = false;
        private bool m_enabledEventsOfScenario = false;
        private bool m_enabledEventsOfApplication = false;
        // --       
        private bool m_enabledLogOfBinary = false;
        private bool m_enabledLogOfVfei = false;
        private bool m_enabledLogOfPlc = false;
        // --
        private long m_maxLogFileSizeOfBinary = 0;
        private long m_maxLogFileSizeOfVfei = 0;
        private long m_maxLogFileSizeOfPlc = 0;
        // --
        private long m_maxLogCountOfBinary = 0;
        private long m_maxLogCountOfVfei = 0;
        private long m_maxLogCountOfPlc = 0;
        // --
        // ***
        // 2017.04.03 by spike.lee
        // Repository Save (Keeping) 지원
        // ***
        private bool m_enabledRepositorySave = false;
        private string m_repositorySaveDirectory = string.Empty;
        private bool m_enabledRepositoryAutoRemove = false;
        private int m_repositoryKeepingPeriod = 0;  // 시간

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Contruction and Destruction 

        public FConfig(            
            )
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FConfig(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
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

        public string eapName
        {
            get
            {
                try
                {
                    return m_eapName;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    m_eapName = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string hostDriverDirectory
        {
            get
            {
                try
                {
                    return m_hostDriverDirectory;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    m_hostDriverDirectory = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string logDirectory
        {
            get
            {
                try
                {
                    return m_logDirectory;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    m_logDirectory = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfPlcDeviceState
        {
            get
            {
                try
                {
                    return m_enabledEventsOfPlcDeviceState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfPlcDeviceState = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfPlcDeviceError
        {
            get
            {
                try
                {
                    return m_enabledEventsOfPlcDeviceError;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfPlcDeviceError = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfPlcDeviceTimeout
        {
            get
            {
                try
                {
                    return m_enabledEventsOfPlcDeviceTimeout;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfPlcDeviceTimeout = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfPlcDeviceData
        {
            get
            {
                try
                {
                    return m_enabledEventsOfPlcDeviceData;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfPlcDeviceData = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfPlcDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledEventsOfPlcDeviceDataMessage;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfPlcDeviceDataMessage = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfHostDeviceState
        {
            get
            {
                try
                {
                    return m_enabledEventsOfHostDeviceState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfHostDeviceState = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfHostDeviceError
        {
            get
            {
                try
                {
                    return m_enabledEventsOfHostDeviceError;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfHostDeviceError = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfHostDeviceVfei
        {
            get
            {
                try
                {
                    return m_enabledEventsOfHostDeviceVfei;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfHostDeviceVfei = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfHostDeviceDataMessage
        {
            get
            {
                try
                {
                    return m_enabledEventsOfHostDeviceDataMessage;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfHostDeviceDataMessage = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfScenario
        {
            get
            {
                try
                {
                    return m_enabledEventsOfScenario;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfScenario = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledEventsOfApplication
        {
            get
            {
                try
                {
                    return m_enabledEventsOfApplication;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledEventsOfApplication = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }
       
        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledLogOfBinary
        {
            get
            {
                try
                {
                    return m_enabledLogOfBinary;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledLogOfBinary = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledLogOfVfei
        {
            get
            {
                try
                {
                    return m_enabledLogOfVfei;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledLogOfVfei = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledLogOfPlc
        {
            get
            {
                try
                {
                    return m_enabledLogOfPlc;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledLogOfPlc = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public long maxLogFileSizeOfBinary
        {
            get
            {
                try
                {
                    return m_maxLogFileSizeOfBinary;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    m_maxLogFileSizeOfBinary = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public long maxLogFileSizeOfVfei
        {
            get
            {
                try
                {
                    return m_maxLogFileSizeOfVfei;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    m_maxLogFileSizeOfVfei = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public long maxLogFileSizeOfPlc
        {
            get
            {
                try
                {
                    return m_maxLogFileSizeOfPlc;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    m_maxLogFileSizeOfPlc = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public long maxLogCountOfBinary
        {
            get
            {
                try
                {
                    return m_maxLogCountOfBinary;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    m_maxLogCountOfBinary = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public long maxLogCountOfVfei
        {
            get
            {
                try
                {
                    return m_maxLogCountOfVfei;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    m_maxLogCountOfVfei = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public long maxLogCountOfPlc
        {
            get
            {
                try
                {
                    return m_maxLogCountOfPlc;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    m_maxLogCountOfPlc = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string repositorySaveDirectory
        {
            get
            {
                try
                {
                    return m_repositorySaveDirectory;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    m_repositorySaveDirectory = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledRepositorySave
        {
            get
            {
                try
                {
                    return m_enabledRepositorySave;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledRepositorySave = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabledRepositoryAutoRemove
        {
            get
            {
                try
                {
                    return m_enabledRepositoryAutoRemove;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_enabledRepositoryAutoRemove = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int repositoryKeepingPeriod
        {
            get
            {
                try
                {
                    return m_repositoryKeepingPeriod;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    m_repositoryKeepingPeriod = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            string usrDirectory = string.Empty;

            try
            {
                // ***
                // EAP Name은 FScdCore Class 초기화 시 반드시 입력해야 함.
                // ***
                m_eapName = string.Empty;   

                // --

                usrDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Miracom FAMate\\FAMate Workspace Manager v4.5";
                m_hostDriverDirectory = Path.Combine(usrDirectory, "HostDriver");
                m_logDirectory = Path.Combine(usrDirectory, "Log");

                // -- 

                m_enabledEventsOfPlcDeviceState = true;
                m_enabledEventsOfPlcDeviceError = true;
                m_enabledEventsOfPlcDeviceTimeout = true;
                m_enabledEventsOfPlcDeviceData = false;
                m_enabledEventsOfPlcDeviceDataMessage = true;
                m_enabledEventsOfHostDeviceState = true;
                m_enabledEventsOfHostDeviceError = true;
                m_enabledEventsOfHostDeviceVfei = false;
                m_enabledEventsOfHostDeviceDataMessage = true;
                m_enabledEventsOfScenario = true;
                m_enabledEventsOfApplication = true;

                // --
                
                m_enabledLogOfBinary = false;
                m_enabledLogOfVfei = false;
                m_enabledLogOfPlc = false;
                
                // --
                
                m_maxLogFileSizeOfBinary = 5242880;     // 5MB
                m_maxLogFileSizeOfVfei = 5242880;       // 5MB
                m_maxLogFileSizeOfPlc = 5242880;        // 5MB

                // --

                m_maxLogCountOfBinary = 5000;
                m_maxLogCountOfVfei = 5000;
                m_maxLogCountOfPlc = 5000;

                // --

                // ***
                // 2017.04.03 by spike.lee
                // Repository Save (Keeping) 지원
                // ***
                m_repositorySaveDirectory = Path.Combine(usrDirectory, "Repository");
                m_enabledRepositorySave = false;
                m_enabledRepositoryAutoRemove = false;
                m_repositoryKeepingPeriod = 12;     // Default 12 시간
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
    }   // Class end
}   // Namespace end