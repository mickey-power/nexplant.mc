﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCustom001SendBuffer.cs
--  Creator         : spike.lee
--  Create Date     : 2016.04.21
--  Description     : FAMate Core FaTcpDriver Custom_001 Send Buffer Class 
--  History         : Created by spike.lee at 2016.04.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal class FCustom001SendBuffer : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FXmlNode m_fXmlNodeMsg = null;
        private string m_xml = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCustom001SendBuffer(            
            )
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FCustom001SendBuffer(
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
                    m_fXmlNodeMsg = null;
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

        public FXmlNode fMsg
        {
            get
            {
                try
                {
                    return m_fXmlNodeMsg;
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

        public string xml
        {
            get
            {
                try
                {
                    return m_xml;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void genDataMessage(
            FXmlNode fXmlNodeMsg
            )
        {
            try
            {
                m_fXmlNodeMsg = fXmlNodeMsg;
                m_xml = m_fXmlNodeMsg.xmlToString(true);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public byte[] getBinaryData(
            )
        {
            byte[] btEtx = new byte[] { 0x0A, 0x0A };
            ArrayList bin = null;

            try
            {
                bin = new ArrayList();
                bin.AddRange(Encoding.Default.GetBytes(m_xml));
                bin.AddRange(btEtx);                
                // --
                return (byte[])bin.ToArray(typeof(byte));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
