﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2021 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpOpenTransaction.cs
--  Creator         : Sunghoon.Park
--  Create Date     : 2021.03.22
--  Description     : NexplantMC Core FaTcpDriver TCP Device Driver Arguments Class 
--  History         : Created by Sunghoon.Park at 2021.03.22
----------------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FTcpDeviceDriverArgs : IDisposable
    {
        private bool m_disposed = false;
        // --
        private FTcpDriver m_fTcpDriver = null;
        private FTcpDevice m_fTcpDevice = null; 
        //--

        #region Class Construction and Destruction

        internal FTcpDeviceDriverArgs(
            FTcpDriver fTcpDriver,
            FTcpDevice fTcpDevice
            )
        {
            m_fTcpDriver = fTcpDriver;
            m_fTcpDevice = fTcpDevice;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpDeviceDriverArgs(
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
                    m_fTcpDriver = null;
                    m_fTcpDevice = null;
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

        public FTcpDriver fTcpDriver
        {
            get
            {
                try
                {
                    return m_fTcpDriver;
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

        public FTcpDevice fTcpDevice
        {
            get
            {
                try
                {
                    return m_fTcpDevice;
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
