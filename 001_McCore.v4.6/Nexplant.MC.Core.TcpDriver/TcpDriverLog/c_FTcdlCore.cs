﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcdlCore.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2011.09.28
--  Description     : FAMate Core FaTcpDriver TCP Driver Log Core Class 
--  History         : Created by spike.lee at 2011.09.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal class FTcdlCore : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcpDriverLog m_fTcpDriverLog = null;
        private FXmlDocument m_fXmlDoc = null;
        private FXmlNode m_fXmlNodeTcdl = null;
        private FIDPointer64 m_fIdPointer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcdlCore(            
            )           
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcdlCore(
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
                    term();
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

        public FXmlDocument fXmlDoc
        {
            get
            {
                try
                {
                    return m_fXmlDoc;
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

        public FXmlNode fXmlNodeTcdl
        {
            get
            {
                try
                {
                    return m_fXmlNodeTcdl;
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

        public FIDPointer64 fIdPointer
        {
            get
            {
                try
                {
                    return m_fIdPointer;
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

        public FTcpDriverLog fTcpDriverLog
        {
            get
            {
                try
                {
                    return m_fTcpDriverLog;
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

            set
            {
                try
                {
                    m_fTcpDriverLog = value;
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
            FXmlNode fXmlNodeFam = null;

            try
            {
                m_fIdPointer = new FIDPointer64();
                m_fXmlDoc = new FXmlDocument();
                m_fXmlDoc.preserveWhiteSpace = false;
                m_fXmlDoc.appendChild(m_fXmlDoc.createXmlDeclaration("1.0", string.Empty, string.Empty));

                // --

                fXmlNodeFam = m_fXmlDoc.appendChild(FTcpDriverLogCommon.createXmlNodeFAM(m_fXmlDoc));
                // --
                m_fXmlNodeTcdl = fXmlNodeFam.appendChild(FTcpDriverLogCommon.createXmlNodeTCDL(m_fXmlDoc));
                m_fXmlNodeTcdl.set_attrVal(FXmlTagTCDL.A_UniqueId, FXmlTagTCDL.D_UniqueId, m_fIdPointer.uniqueId.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeFam != null)
                {
                    fXmlNodeFam.Dispose();
                    fXmlNodeFam = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void term(
            )
        {
            try
            {
                if (m_fXmlNodeTcdl != null)
                {
                    m_fXmlNodeTcdl.Dispose();
                    m_fXmlNodeTcdl = null;
                }

                if (m_fXmlDoc != null)
                {
                    m_fXmlDoc.Dispose();
                    m_fXmlDoc = null;
                }

                if (m_fIdPointer != null)
                {
                    m_fIdPointer.Dispose();
                    m_fIdPointer = null;
                }

                // --
                m_fTcpDriverLog = null;
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

        public void openLogFile(
            string fileName
            )
        {
            FIDPointer64 fIdPointer = null;
            FXmlDocument fXmlDoc = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeTcdl = null;

            try
            {
                fIdPointer = new FIDPointer64();
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.load(fileName);

                // --
                fXmlNodeFam = fXmlDoc.selectSingleNode(FXmlTagFAM.E_FAMate);
                fIdPointer.reset(UInt64.Parse(fXmlNodeFam.get_attrVal(FXmlTagFAM.A_UniqueIdPointer, FXmlTagFAM.D_UniqueIdPointer)));
                // --
                fXmlNodeTcdl = fXmlNodeFam.selectSingleNode(FXmlTagTCDL.E_TcpDriver);

                // --                

                if (m_fIdPointer != null)
                {
                    m_fIdPointer.Dispose();
                    m_fIdPointer = null;
                }

                if (m_fXmlDoc != null)
                {
                    m_fXmlDoc.Dispose();
                    m_fXmlDoc = null;
                }

                // --

                m_fIdPointer = fIdPointer;
                m_fXmlDoc = fXmlDoc;
                m_fXmlNodeTcdl = fXmlNodeTcdl;

                // --

                if (fIdPointer.currentId == 0)
                {
                    FTcpDriverLogCommon.resetLogUniqueId(m_fIdPointer, m_fXmlNodeTcdl);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fIdPointer = null;
                fXmlDoc = null;
                fXmlNodeTcdl = null;
                if (fXmlNodeFam != null)
                {
                    fXmlNodeFam.Dispose();
                    fXmlNodeFam = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void saveLogFile(
            string fileName
            )
        {
            FXmlNode fXmlNodeFam = null;

            try
            {
                fXmlNodeFam = m_fXmlDoc.selectSingleNode(FXmlTagFAM.E_FAMate);
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_UniqueIdPointer, FXmlTagFAM.D_UniqueIdPointer, m_fIdPointer.currentId.ToString());
                fXmlNodeFam.set_attrVal(FXmlTagFAM.A_FileUpdateTime, FXmlTagFAM.D_FileUpdateTime, FDataConvert.defaultNowDateTimeToString());

                // -- 

                m_fXmlDoc.save(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fXmlNodeFam != null)
                {
                    fXmlNodeFam.Dispose();
                    fXmlNodeFam = null;
                }
            }                
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
