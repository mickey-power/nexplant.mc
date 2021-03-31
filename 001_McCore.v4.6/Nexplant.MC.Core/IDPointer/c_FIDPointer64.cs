﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FIDPointer64.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.04
--  Description     : FAMate Core FaCommon Unique ID Pointer 64 Bit Class
--  History         : Created by spike.lee at 2011.01.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FIDPointer64 : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FCodeLock m_fCodeLock = null;
        private UInt64 m_min = UInt64.MinValue;
        private UInt64 m_max = UInt64.MaxValue;
        private UInt64 m_currentId = UInt64.MinValue;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FIDPointer64(
            )
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIDPointer64(
            UInt64 currentId
            )
            : this()
        {
            m_currentId = currentId;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIDPointer64(
            UInt64 min,
            UInt64 max,
            UInt64 currentId
            )
            : this()
        {
            m_min = min;
            m_max = max;
            m_currentId = currentId;
        }       

        //------------------------------------------------------------------------------------------------------------------------

        ~FIDPointer64(
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

        public UInt64 currentId
        {
            get
            {
                try
                {
                    m_fCodeLock.wait();
                    return m_currentId;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    m_fCodeLock.set();
                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public UInt64 uniqueId
        {
            get
            {
                UInt64 id = 0;

                try
                {
                    m_fCodeLock.wait();
                    id = m_currentId;
                    if (m_currentId >= m_max)
                    {
                        m_currentId = m_min;  // 현재 값 초기화
                    }
                    else
                    {
                        m_currentId++;
                    }
                    return id;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    m_fCodeLock.set();
                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public UInt64 min
        {
            get
            {
                try
                {
                    return m_min;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public UInt64 max
        {
            get
            {
                try
                {
                    return m_max;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_fCodeLock = new FCodeLock();
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

        private void term(
            )
        {
            try
            {
                if (m_fCodeLock != null)
                {
                    m_fCodeLock.Dispose();
                    m_fCodeLock = null;
                }
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

        public void reset(
            )
        {
            try
            {
                m_fCodeLock.wait();
                m_currentId = m_min;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void reset(
            UInt64 currentId
            )
        {
            try
            {
                m_fCodeLock.wait();
                m_currentId = currentId;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void reset(
            UInt64 min,
            UInt64 max,
            UInt64 currentId
            )
        {
            try
            {
                m_fCodeLock.wait();
                m_min = min;
                m_max = max;
                m_currentId = currentId;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
