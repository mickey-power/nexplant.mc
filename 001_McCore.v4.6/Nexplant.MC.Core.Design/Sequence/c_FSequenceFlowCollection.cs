﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSequenceFlowCollection.cs
--  Creator         : spike.lee
--  Create Date     : 2011.04.12
--  Description     : FAMate Core UIs Sequence Flow Collection Class 
--  History         : Created by spike.lee at 2011.04.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public class FSequenceFlowCollection : IEnumerable, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<FSequenceFlow> m_fSequenceFlowList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSequenceFlowCollection(
            List<FSequenceFlow> fSequenceFlowList
            )
        {
            m_fSequenceFlowList = fSequenceFlowList;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSequenceFlowCollection(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fSequenceFlowList = null;
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

        public int count
        {
            get
            {
                try
                {
                    return m_fSequenceFlowList.Count;
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

        public FSequenceFlow this[int i]
        {
            get
            {
                try
                {
                    if (i < 0 || i >= m_fSequenceFlowList.Count)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0001, "Index"));
                    }

                    // --

                    return m_fSequenceFlowList[i];
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

        public IEnumerator GetEnumerator(
            )
        {
            try
            {
                return new FSequenceFlowCollectionEnumerator(this);
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

        //------------------------------------------------------------------------------------------------------------------------

        public object item(
            int index
            )
        {
            try
            {
                return this[index];
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
