﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostLibraryCollection.cs
--  Creator         : Kimsh
--  Create Date     : 2011.03.03
--  Description     : FAMate Core FaSecsDriver Host Library Collection Class 
--  History         : Created by Kimsh at 2011.03.03
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FHostLibraryCollection : FBaseObjectCollection<FHostLibraryCollection, FHostLibrary>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FHostLibraryCollection(
            FScdCore fScdCore,
            FXmlNodeList fXmlNodeList
            )
            : base(fScdCore, fXmlNodeList)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostLibraryCollection(
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

        public override FHostLibrary this[int i]
        {
            get
            {
                FXmlNode fXmlNode = null;

                try
                {
                    fXmlNode = fXmlNodeList[i];
                    if (fXmlNode == null)
                    {
                        return null;
                    }
                    return new FHostLibrary(fScdCore, fXmlNode);
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

        public override IEnumerator GetEnumerator(
            )
        {
            try
            {
                return new FHostLibraryCollectionEnumerator(this);
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
