﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropOtrl.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.11.07
--  Description     : FAMate OPC Modeler OPC Trigger Raised Log Property Source Object Class 
--  History         : Created by jungyoul.moon at 2013.11.07
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.OpcModeler
{
    public class FPropOtrl : FDynPropCusBase<FOpmCore>
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryResult = "[01] Result";
        private const string CategoryGeneral = "[02] General";
        private const string CategoryFont = "[03] Font";
        private const string CategoryEquipment = "[04] Equipment";
        private const string CategoryScenario = "[05] Scenario";
        private const string CategoryUserTag = "[06] User Tag";

        // --

        private bool m_disposed = false;
        // --
        private FOpcTriggerRaisedLog m_fOtrl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropOtrl(
            FOpmCore fOpmCore,
            FDynPropGrid fPropGrid,
            FOpcTriggerRaisedLog fOtrl
            )
            : base(fOpmCore, fOpmCore.fUIWizard, fPropGrid)
        {
            m_fOtrl = fOtrl;
            // --
            init();   
        }        

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropOtrl(
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
                    term();     
                    // --
                    m_fOtrl = null;
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
                    return m_fOtrl.time;
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
                    return m_fOtrl.fResultCode;
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
                    return m_fOtrl.resultMessage;
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
        
        #region General

        [Category(CategoryGeneral)]
        public string Type
        {
            get
            {
                try
                {
                    return m_fOtrl.fObjectLogType.ToString();
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
                    return m_fOtrl.uniqueIdToString;
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
        public string Name
        {
            get
            {
                try
                {
                    return m_fOtrl.name;
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
                    return m_fOtrl.description;
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
                    return m_fOtrl.fontColor;
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
                    return m_fOtrl.fontBold;
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
                    return m_fOtrl.equipmentUniqueIdToString;
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
                    return m_fOtrl.equipmentName;
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
                    return m_fOtrl.scenarioUniqueIdToString;
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
                    return m_fOtrl.scenarioName;
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

        #region User Tag

        [Category(CategoryUserTag)]
        public string UserTag1
        {
            get
            {
                try
                {
                    return m_fOtrl.userTag1;
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
                    return m_fOtrl.userTag2;
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
                    return m_fOtrl.userTag3;
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
                    return m_fOtrl.userTag4;
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
                    return m_fOtrl.userTag5;
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
        public FOpcTriggerRaisedLog fOpcTriggerRaisedLog
        {
            get
            {
                try
                {
                    return m_fOtrl;
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
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute("User Tag1"));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute("User Tag2"));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute("User Tag3"));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute("User Tag4"));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute("User Tag5"));
                
                // --

                base.fTypeDescriptor.properties["Time"].attributes.replace(new DefaultValueAttribute(m_fOtrl.time));
                base.fTypeDescriptor.properties["ResultCode"].attributes.replace(new DefaultValueAttribute(m_fOtrl.fResultCode));
                base.fTypeDescriptor.properties["ResultMessage"].attributes.replace(new DefaultValueAttribute(m_fOtrl.resultMessage));
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fOtrl.fObjectLogType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fOtrl.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fOtrl.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fOtrl.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fOtrl.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fOtrl.fontBold));
                // --
                base.fTypeDescriptor.properties["EquipmentId"].attributes.replace(new DefaultValueAttribute(m_fOtrl.equipmentUniqueIdToString));
                base.fTypeDescriptor.properties["EquipmentName"].attributes.replace(new DefaultValueAttribute(m_fOtrl.equipmentName));
                // -- 
                base.fTypeDescriptor.properties["ScenarioId"].attributes.replace(new DefaultValueAttribute(m_fOtrl.scenarioUniqueIdToString));
                base.fTypeDescriptor.properties["ScenarioName"].attributes.replace(new DefaultValueAttribute(m_fOtrl.scenarioName));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fOtrl.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fOtrl.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fOtrl.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fOtrl.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fOtrl.userTag5));
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

    } // Class End
} // Namespace End