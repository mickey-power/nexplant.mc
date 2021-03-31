﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropComponentVersion.cs
--  Creator         : mjkim
--  Create Date     : 2012.04.10
--  Description     : FAMate Admin Manager Component Version Property Source Object Class 
--  History         : Created by mjkim at 2012.04.10
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
    public class FPropComponentVersion : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral       = "[01] General";
        private const string CategoryRelease       = "[02] Release";
        private const string CategoryComponentFile = "[03] Component File";

        // --

        private bool m_disposed = false;
        // --
        private bool m_tranEnabled = false;
        // --
        private string m_component = string.Empty;
        private string m_description = string.Empty;
        private string m_comments = string.Empty;
        private string m_release = FYesNo.No.ToString();
        private string m_oldPath = string.Empty;
        private string m_newFile = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropComponentVersion(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            DataTable dt,
            bool tranEnabled
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_tranEnabled = tranEnabled;

            // --

            if (dt != null)
            {
                m_component = dt.Rows[0][0].ToString();
                m_description = dt.Rows[0][1].ToString();
                m_comments = dt.Rows[0][2].ToString();
                m_release = dt.Rows[0][3].ToString();
                m_oldPath = dt.Rows[0][4].ToString();
            }

            // --

            init();   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropComponentVersion(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid, 
            string component,
            bool tranEnabled
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_tranEnabled = tranEnabled;
            m_component = component;

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropComponentVersion(
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
        public string Component
        {
            get
            {
                try
                {
                    return m_component;
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

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        [Editor(typeof(FPropAttrCommentEditUITypeEditor), typeof(UITypeEditor))]
        public string Comments
        {
            get
            {
                try
                {
                    return m_comments;
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
                    m_comments = value;
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

        #region Release

        [Category(CategoryRelease)]
        public FYesNo Release
        {
            get
            {
                try
                {
                    return (FYesNo)Enum.Parse(typeof(FYesNo), m_release);
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.No;
            }

            set
            {
                try
                {
                    m_release = value.ToString();
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

        #region Component File

        [Category(CategoryComponentFile)]
        [Editor(typeof(FPropAttrFileBrowserUITypeEditor), typeof(UITypeEditor))]
        public string File
        {
            get
            {
                try
                {
                    if (m_newFile == string.Empty)
                    {
                        return m_oldPath;
                    }
                    return m_newFile;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        [Browsable(false)]
        public string oldPath
        {
            get
            {
                try
                {
                    return m_oldPath;
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

        [Browsable(false)]
        public string newFile
        {
            get
            {
                try
                {
                    return m_newFile;
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
                    m_newFile = value;
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
            try
            {
                base.fTypeDescriptor.properties["Component"].attributes.replace(new DisplayNameAttribute("Component"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                base.fTypeDescriptor.properties["Comments"].attributes.replace(new DisplayNameAttribute("Comments"));
                base.fTypeDescriptor.properties["Release"].attributes.replace(new DisplayNameAttribute("Release"));
                base.fTypeDescriptor.properties["Files"].attributes.replace(new DisplayNameAttribute("Files"));

                // --

                // ***
                // 2014.09.10 by spike.lee
                // 데이터 키 정의
                // ***
                base.fTypeDescriptor.properties["Component"].attributes.replace(new ParenthesizePropertyNameAttribute(true));

                // --

                base.fTypeDescriptor.properties["Component"].attributes.replace(new DefaultValueAttribute(m_component));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                base.fTypeDescriptor.properties["Comments"].attributes.replace(new DefaultValueAttribute(m_comments));
                base.fTypeDescriptor.properties["Release"].attributes.replace(new DefaultValueAttribute(m_release));
                base.fTypeDescriptor.properties["File"].attributes.replace(new DefaultValueAttribute(m_oldPath));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["Component"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Comments"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Release"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["File"].attributes.replace(new ReadOnlyAttribute(true));

                    // --

                    base.fTypeDescriptor.properties["Comments"].attributes.replace(new EditorAttribute("", typeof(UITypeEditor)));
                    base.fTypeDescriptor.properties["File"].attributes.replace(new EditorAttribute("", typeof(UITypeEditor)));
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
