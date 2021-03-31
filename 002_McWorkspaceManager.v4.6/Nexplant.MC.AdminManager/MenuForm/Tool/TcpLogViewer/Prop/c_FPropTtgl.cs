﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropTtgl.cs
--  Creator         : spike.lee
--  Create Date     : 2012.01.03
--  Description     : FAMate TCP Modeler Storage Performed Log Property Source Object Class 
--  History         : Created by kitae at 2012.01.03
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager.FaTcpLogViewer
{
    public class FPropTtgl : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryResult = "[01] Result";
        private const string CategoryGeneral = "[02] General";
        private const string CategoryFont = "[03] Font";
        private const string CategoryEquipment = "[04] Equipment";
        private const string CategoryScenario = "[05] Scenario";
        private const string CategoryAction = "[06] Action";
        private const string CategoryRepository = "[07] Repository";
        private const string CategoryBranch = "[08] Branch";
        private const string CategoryUserTag = "[09] User Tag";

        // --

        private bool m_disposed = false;
        // --
        private FStoragePerformedLog m_fStgl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropTtgl(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FStoragePerformedLog fStgl
            )
            :base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fStgl = fStgl;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropTtgl(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void  myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                    // --
                    m_fStgl = null;
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Result

        [Category(CategoryResult)]
        public string Time
        {
            get
            {
                try
                {
                    return m_fStgl.time;
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

        [Category(CategoryResult)]
        public FResultCode ResultCode
        {
            get
            {
                try
                {
                    return m_fStgl.fResultCode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FResultCode.Error;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryResult)]
        public string ResultMessage
        {
            get
            {
                try
                {
                    return m_fStgl.resultMessage;
                }
                catch(Exception ex)
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

        #region General

        [Category(CategoryGeneral)]
        public string Type
        {
            get
            {
                try
                {
                    return m_fStgl.fObjectLogType.ToString();
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
        public string ID
        {
            get
            {
                try
                {
                    return m_fStgl.uniqueIdToString;
                }
                catch(Exception ex)
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
        public string Name
        {
            get
            {
                try
                {
                    return m_fStgl.name;
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
                    return m_fStgl.description;
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

        #region Font
        [Category(CategoryFont)]
        public Color FontColor
        {
            get
            {
                try
                {
                    return m_fStgl.fontColor;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return Color.Black;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFont)]
        public bool FontBold
        {
            get
            {
                try
                {
                    return m_fStgl.fontBold;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Equipment

        [Category(CategoryEquipment)]
        public string EquipmentId
        {
            get
            {
                try
                {
                    return m_fStgl.equipmentUniqueIdToString;
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

        [Category(CategoryEquipment)]
        public string EquipmentName
        {
            get
            {
                try
                {
                    return m_fStgl.equipmentName;
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

        #region Scenario

        [Category(CategoryScenario)]
        public string ScenarioId
        {
            get
            {
                try
                {
                    return m_fStgl.scenarioUniqueIdToString;
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

        [Category(CategoryScenario)]
        public string ScenarioName
        {
            get
            {
                try
                {
                    return m_fStgl.scenarioName;
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

        #region Action

        [Category(CategoryAction)]
        public FStorageAction Action
        {
            get
            {
                try
                {
                    return m_fStgl.fAction;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FStorageAction.Select;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Repository

        [Category(CategoryRepository)]
        public string RepositoryId
        {
            get
            {
                try
                {
                    return m_fStgl.repositoryUniqueIdToString;
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

        [Category(CategoryRepository)]
        public string RepositoryName
        {
            get
            {
                try
                {
                    return m_fStgl.repositoryName;
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

        #region Branch

        [Category(CategoryBranch)]
        public bool UsedBranch
        {
            get
            {
                try
                {
                    return m_fStgl.usedBranch;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryBranch)]
        public string LocationId
        {
            get
            {
                try
                {
                    return m_fStgl.locationUniqueIdToString;
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

        [Category(CategoryBranch)]
        public string Location
        {
            get
            {
                try
                {
                    return m_fStgl.locationName;
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

        #region User Tag

        [Category(CategoryUserTag)]
        public string UserTag1
        {
            get
            {
                try
                {
                    return m_fStgl.userTag1;
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

        [Category(CategoryUserTag)]
        public string UserTag2
        {
            get
            {
                try
                {
                    return m_fStgl.userTag2;
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

        [Category(CategoryUserTag)]
        public string UserTag3
        {
            get
            {
                try
                {
                    return m_fStgl.userTag3;
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

        [Category(CategoryUserTag)]
        public string UserTag4
        {
            get
            {
                try
                {
                    return m_fStgl.userTag4;
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

        [Category(CategoryUserTag)]
        public string UserTag5
        {
            get
            {
                try
                {
                    return m_fStgl.userTag5;
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
        public FStoragePerformedLog fStoragePerformedLog
        {
            get
            {
                try
                {
                    return m_fStgl;
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

        private void init(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["Time"].attributes.replace(new DisplayNameAttribute("Time"));
                base.fTypeDescriptor.properties["ResultCode"].attributes.replace(new DisplayNameAttribute("Result Code"));
                base.fTypeDescriptor.properties["ResultMessage"].attributes.replace(new DisplayNameAttribute("Result Message"));
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DisplayNameAttribute("Color"));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DisplayNameAttribute("Bold"));
                // --
                base.fTypeDescriptor.properties["EquipmentId"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["EquipmentName"].attributes.replace(new DisplayNameAttribute("Name"));
                // --
                base.fTypeDescriptor.properties["ScenarioId"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["ScenarioName"].attributes.replace(new DisplayNameAttribute("Name"));
                // --
                base.fTypeDescriptor.properties["Action"].attributes.replace(new DisplayNameAttribute("Action"));
                // --
                base.fTypeDescriptor.properties["RepositoryId"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["RepositoryName"].attributes.replace(new DisplayNameAttribute("Name"));
                // --
                base.fTypeDescriptor.properties["UsedBranch"].attributes.replace(new DisplayNameAttribute("Used"));
                base.fTypeDescriptor.properties["LocationId"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["Location"].attributes.replace(new DisplayNameAttribute("Name"));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute("User Tag1"));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute("User Tag2"));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute("User Tag3"));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute("User Tag4"));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute("User Tag5"));

                // --

                base.fTypeDescriptor.properties["Time"].attributes.replace(new DefaultValueAttribute(m_fStgl.time));
                base.fTypeDescriptor.properties["ResultCode"].attributes.replace(new DefaultValueAttribute(m_fStgl.fResultCode));
                base.fTypeDescriptor.properties["ResultMessage"].attributes.replace(new DefaultValueAttribute(m_fStgl.resultMessage));
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fStgl.fObjectLogType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fStgl.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fStgl.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fStgl.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fStgl.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fStgl.fontBold));
                // --
                base.fTypeDescriptor.properties["EquipmentId"].attributes.replace(new DefaultValueAttribute(m_fStgl.equipmentUniqueIdToString));
                base.fTypeDescriptor.properties["EquipmentName"].attributes.replace(new DefaultValueAttribute(m_fStgl.equipmentName));
                // -- 
                base.fTypeDescriptor.properties["ScenarioId"].attributes.replace(new DefaultValueAttribute(m_fStgl.scenarioUniqueIdToString));
                base.fTypeDescriptor.properties["ScenarioName"].attributes.replace(new DefaultValueAttribute(m_fStgl.scenarioName));
                // --
                base.fTypeDescriptor.properties["Action"].attributes.replace(new DefaultValueAttribute(m_fStgl.fAction));
                // --
                base.fTypeDescriptor.properties["RepositoryId"].attributes.replace(new DefaultValueAttribute(m_fStgl.repositoryUniqueIdToString));
                base.fTypeDescriptor.properties["RepositoryName"].attributes.replace(new DefaultValueAttribute(m_fStgl.repositoryName));
                // --
                base.fTypeDescriptor.properties["UsedBranch"].attributes.replace(new DefaultValueAttribute(m_fStgl.usedBranch));
                base.fTypeDescriptor.properties["LocationId"].attributes.replace(new DefaultValueAttribute(m_fStgl.locationUniqueIdToString));
                base.fTypeDescriptor.properties["Location"].attributes.replace(new DefaultValueAttribute(m_fStgl.locationName));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fStgl.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fStgl.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fStgl.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fStgl.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fStgl.userTag5));

                // --

                if (!m_fStgl.usedBranch)
                {
                    base.fTypeDescriptor.properties["LocationId"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["Location"].attributes.replace(new BrowsableAttribute(false));
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

        private void term(
            )
        {
            try
            {

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
