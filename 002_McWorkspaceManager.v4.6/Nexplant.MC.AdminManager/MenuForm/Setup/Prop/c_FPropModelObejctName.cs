﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropMakerGroup.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2012.05.31
--  Description     : FAMate Admin Manager Model Object Name Property Source Object Class 
--  History         : Created by tjkim at 2012.05.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.Data;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public class FPropModelObjectName : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";

        // --

        private bool m_disposed = false;
        // --
        private bool m_tranEnabled = false;
        // --
        private string m_objectName = string.Empty;
        private string m_description = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropModelObjectName(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            DataTable dt,
            bool tranEnabled
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_tranEnabled = tranEnabled;
            // --
            init(dt);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropModelObjectName(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            bool readOnly
            )
            : this(fAdmCore, fPropGrid, null, readOnly)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropModelObjectName(
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

        #region General

        [Category(CategoryGeneral)]
        public string ObjectName
        {
            get
            {
                try
                {
                    return m_objectName;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
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
                    m_objectName = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string Description
        {
            get
            {
                try
                {
                    return m_description;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
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
                    m_description = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            DataTable dt
            )
        {
            try
            {
                if (dt != null)
                {
                    m_objectName = dt.Rows[0][0].ToString();
                    m_description = dt.Rows[0][1].ToString();
                }

                // --

                base.fTypeDescriptor.properties["ObjectName"].attributes.replace(new DisplayNameAttribute("Object Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
               
                // --

                // ***
                // 2014.09.10 by spike.lee
                // 데이터 키 정의
                // ***
                base.fTypeDescriptor.properties["ObjectName"].attributes.replace(new ParenthesizePropertyNameAttribute(true));

                // --

                base.fTypeDescriptor.properties["ObjectName"].attributes.replace(new DefaultValueAttribute(m_objectName));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["ObjectName"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
