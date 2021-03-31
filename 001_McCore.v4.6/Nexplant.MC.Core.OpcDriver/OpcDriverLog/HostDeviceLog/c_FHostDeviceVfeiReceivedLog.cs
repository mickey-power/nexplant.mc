﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostDeviceVfeiReceivedLog.cs
--  Creator         : spike.lee
--  Create Date     : 2011.11.14
--  Description     : FAMate Core FaOpcDriver Host Device VFEI Received Log Class 
--  History         : Created by spike.lee at 2011.11.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FHostDeviceVfeiReceivedLog : FHostDeviceVfeiLog<FHostDeviceVfeiReceivedLog>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FHostDeviceVfeiReceivedLog(      
            FXmlNode fXmlNode
            )
            : base(fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FHostDeviceVfeiReceivedLog(
            FOcdlCore fOcdlCore, 
            FXmlNode fXmlNode
            )
            : base(fOcdlCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostDeviceVfeiReceivedLog(
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
                    
                }                
                m_disposed = true;                

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public override FObjectLogType fObjectLogType
        {
            get
            {
                try
                {
                    return FObjectLogType.HostDeviceVfeiReceivedLog;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectLogType.HostDeviceVfeiReceivedLog;
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
