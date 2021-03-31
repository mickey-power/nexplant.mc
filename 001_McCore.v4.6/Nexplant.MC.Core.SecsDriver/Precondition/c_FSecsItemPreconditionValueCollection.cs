﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsItemPreconditionValueCollection.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.09
--  Description     : FAMate Core FaSecsDriver SECS Item Precondition Value Collection Class 
--  History         : Created by spike.lee at 2011.03.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FSecsItemPreconditionValueCollection : FIPreconditionValueCollection, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FXmlNode m_fXmlNodeSit = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSecsItemPreconditionValueCollection(            
            FXmlNode fXmlNodeSit
            )            
        {
            m_fXmlNodeSit = fXmlNodeSit;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsItemPreconditionValueCollection(
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
                    m_fXmlNodeSit = null;            
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

        private string value
        {
            get
            {
                try
                {
                    return m_fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Precondition, FXmlTagSIT.D_Precondition);
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

        //------------------------------------------------------------------------------------------------------------------------

        public int count
        {
            get
            {
                string val = string.Empty;

                try
                {
                    val = this.value;
                    if (val == string.Empty)
                    {
                        return 0;
                    }

                    // --

                    return val.Split(FConstants.PreconditionValueSeparator).Count();
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

        public string this[int i]
        {
            get
            {
                string[] valueList = null;

                try
                {
                    valueList = this.value.Split(FConstants.PreconditionValueSeparator);
                    // --
                    if (i < 0 || i >= valueList.Length)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0014, "Index"));
                    }

                    // --

                    return valueList[i];
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
                return new FSecsItemPreconditionValueCollectionEnumerator(this);
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

        //------------------------------------------------------------------------------------------------------------------------

        public string getStringValue(
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
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object getValue(
            int index
            )
        {
            FFormat fFormat;

            try
            {
                fFormat = FEnumConverter.toFormat(m_fXmlNodeSit.get_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format));
                return FValueConverter.toValue(fFormat, this[index], 1);
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
