﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropEquipmentHistory.cs
--  Creator         : duchoi
--  Create Date     : 2013.05.22
--  Description     : FAMate Admin Manager Equipment History Property Source Object Class 
--  History         : Created by duchoi at 2013.05.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Reflection;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropEquipmentHistory : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryEvent = "[02] Event";
        private const string CategoryState = "[03] State";
        private const string CategoryInformation = "[04] Information";
        private const string CategoryData = "[05] Data Field";
        private const string CategoryComment = "[06] Comments";

        // --

        private bool m_disposed = false;
        string m_tranTime = string.Empty;
        string m_eqpName = string.Empty;
        string m_eventId = string.Empty;
        string m_systemCode = string.Empty;
        string m_eap = string.Empty;
        string m_controlMode = string.Empty;
        string m_priState = string.Empty;
        string m_state = string.Empty;
        string m_mode = string.Empty;
        string m_mdln = string.Empty;
        string m_softRev = string.Empty;
        string m_userId = string.Empty;
        string m_eventDefine = string.Empty;
        string m_eapEventId = string.Empty;
        string m_eqpRecipe = string.Empty;
        string m_eventHeader1 = string.Empty;
        string m_eventData1 = string.Empty;
        string m_eventHeader2 = string.Empty;
        string m_eventData2 = string.Empty;
        string m_eventHeader3 = string.Empty;
        string m_eventData3 = string.Empty;
        string m_eventHeader4 = string.Empty;
        string m_eventData4 = string.Empty;
        string m_eventHeader5 = string.Empty;
        string m_eventData5 = string.Empty;
        string m_eventHeader6 = string.Empty;
        string m_eventData6 = string.Empty;
        string m_eventHeader7 = string.Empty;
        string m_eventData7 = string.Empty;
        string m_eventHeader8 = string.Empty;
        string m_eventData8 = string.Empty;
        string m_eventHeader9 = string.Empty;
        string m_eventData9 = string.Empty;
        string m_eventHeader10 = string.Empty;
        string m_eventData10 = string.Empty;
        string m_eventHeader11 = string.Empty;
        string m_eventData11 = string.Empty;
        string m_eventHeader12 = string.Empty;
        string m_eventData12 = string.Empty;
        string m_eventHeader13 = string.Empty;
        string m_eventData13 = string.Empty;
        string m_eventHeader14 = string.Empty;
        string m_eventData14 = string.Empty;
        string m_eventHeader15 = string.Empty;
        string m_eventData15 = string.Empty;
        string m_eventHeader16 = string.Empty;
        string m_eventData16 = string.Empty;
        string m_eventHeader17 = string.Empty;
        string m_eventData17 = string.Empty;
        string m_eventHeader18 = string.Empty;
        string m_eventData18 = string.Empty;
        string m_eventHeader19 = string.Empty;
        string m_eventData19 = string.Empty;
        string m_eventHeader20 = string.Empty;
        string m_eventData20 = string.Empty;
        string m_comments = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropEquipmentHistory(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            DataRow dr
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            init(dr);   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropEquipmentHistory(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid
            )
            : this(fAdmCore, fPropGrid, null)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropEquipmentHistory(
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

        #region  General

        [Category(CategoryGeneral)]
        public string Time
        {
            get
            {
                try
                {
                    return m_tranTime;
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
        public string EqpName
        {
            get
            {
                try
                {
                    return m_eqpName;
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
        public string Eap
        {
            get
            {
                try
                {
                    return m_eap;
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
        public string UserId
        {
            get
            {
                try
                {
                    return m_userId;
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

        //[Category(CategoryGeneral)]
        //public string EqpRecipe
        //{
        //    get
        //    {
        //        try
        //        {
        //            return m_eqpRecipe;
        //        }
        //        catch (Exception ex)
        //        {
        //            FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
        //        }
        //        finally
        //        {

        //        }
        //        return string.Empty;
        //    }
        //}

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Event

        [Category(CategoryEvent)]
        public string SystemCode
        {
            get
            {
                try
                {
                    return m_systemCode;
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

        [Category(CategoryEvent)]
        public string EventId
        {
            get
            {
                try
                {
                    return m_eventId;
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

        [Category(CategoryEvent)]
        public string EapEventId
        {
            get
            {
                try
                {
                    return m_eapEventId;
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

        #region State

        [Category(CategoryState)]
        public string ControlMode
        {
            get
            {
                try
                {
                    return m_controlMode;
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

        [Category(CategoryState)]
        public string PrimaryState
        {
            get
            {
                try
                {
                    return m_priState;
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

        [Category(CategoryState)]
        public string State
        {
            get
            {
                try
                {
                    return m_state;
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

        [Category(CategoryState)]
        public string Mode
        {
            get
            {
                try
                {
                    return m_mode;
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

        #region Information

        [Category(CategoryInformation)]
        public string MDLN
        {
            get
            {
                try
                {
                    return m_mdln;
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

        [Category(CategoryInformation)]
        public string SoftRev
        {
            get
            {
                try
                {
                    return m_softRev;
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

        [Category(CategoryInformation)]
        public string EventDefine
        {
            get
            {
                try
                {
                    return m_eventDefine;
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

        #region Customizing Field

        [Category(CategoryData)]
        public string Data1
        {
            get
            {
                try
                {
                    return m_eventData1;
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

        [Category(CategoryData)]
        public string Data2
        {
            get
            {
                try
                {
                    return m_eventData2;
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

        [Category(CategoryData)]
        public string Data3
        {
            get
            {
                try
                {
                    return m_eventData3;
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

        [Category(CategoryData)]
        public string Data4
        {
            get
            {
                try
                {
                    return m_eventData4;
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

        [Category(CategoryData)]
        public string Data5
        {
            get
            {
                try
                {
                    return m_eventData5;
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

        [Category(CategoryData)]
        public string Data6
        {
            get
            {
                try
                {
                    return m_eventData6;
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

        [Category(CategoryData)]
        public string Data7
        {
            get
            {
                try
                {
                    return m_eventData7;
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

        [Category(CategoryData)]
        public string Data8
        {
            get
            {
                try
                {
                    return m_eventData8;
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

        [Category(CategoryData)]
        public string Data9
        {
            get
            {
                try
                {
                    return m_eventData9;
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

        [Category(CategoryData)]
        public string Data10
        {
            get
            {
                try
                {
                    return m_eventData10;
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

        [Category(CategoryData)]
        public string Data11
        {
            get
            {
                try
                {
                    return m_eventData11;
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

        [Category(CategoryData)]
        public string Data12
        {
            get
            {
                try
                {
                    return m_eventData12;
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

        [Category(CategoryData)]
        public string Data13
        {
            get
            {
                try
                {
                    return m_eventData13;
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

        [Category(CategoryData)]
        public string Data14
        {
            get
            {
                try
                {
                    return m_eventData14;
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

        [Category(CategoryData)]
        public string Data15
        {
            get
            {
                try
                {
                    return m_eventData15;
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

        [Category(CategoryData)]
        public string Data16
        {
            get
            {
                try
                {
                    return m_eventData16;
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

        [Category(CategoryData)]
        public string Data17
        {
            get
            {
                try
                {
                    return m_eventData17;
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

        [Category(CategoryData)]
        public string Data18
        {
            get
            {
                try
                {
                    return m_eventData18;
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

        [Category(CategoryData)]
        public string Data19
        {
            get
            {
                try
                {
                    return m_eventData19;
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

        [Category(CategoryData)]
        public string Data20
        {
            get
            {
                try
                {
                    return m_eventData20;
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

        #region Comments

        [Category(CategoryComment)]
        [Editor(typeof(FPropAttrCommentViewUITypeEditor), typeof(UITypeEditor))]
        public string Comment
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            DataRow dr
            )
        {
            try
            {
                if (dr != null)
                {
                    m_tranTime          = FDataConvert.defaultDataTimeFormating(dr["TRAN_TIME"].ToString());
                    m_eqpName           = dr["EQP_NAME"].ToString();
                    m_systemCode        = dr["SYSTEM"].ToString();
                    m_eventId           = dr["EVENT_ID"].ToString();
                    m_eap               = dr["EAP"].ToString();
                    m_controlMode       = dr["CTRL_MODE"].ToString();
                    m_priState          = dr["PRI_STATE"].ToString();
                    m_state             = dr["STATE"].ToString();
                    m_mode              = dr["EQP_MODE"].ToString();
                    m_mdln              = dr["MDLN"].ToString();
                    m_softRev           = dr["SOFTREV"].ToString();
                    m_eventDefine       = dr["EVENT_DEFINE"].ToString();
                    m_eapEventId        = dr["MC_EVENT_ID"].ToString();
                    m_eqpRecipe         = dr["EQP_RCP_ID"].ToString(); 
                    m_userId            = dr["TRAN_USER_ID"].ToString();
                    m_eventHeader1      = dr["EVT_H_1"].ToString();
                    m_eventData1        = dr["EVT_D_1"].ToString();
                    m_eventHeader2      = dr["EVT_H_2"].ToString();
                    m_eventData2        = dr["EVT_D_2"].ToString();
                    m_eventHeader3      = dr["EVT_H_3"].ToString();
                    m_eventData3        = dr["EVT_D_3"].ToString();
                    m_eventHeader4      = dr["EVT_H_4"].ToString();
                    m_eventData4        = dr["EVT_D_4"].ToString();
                    m_eventHeader5      = dr["EVT_H_5"].ToString();
                    m_eventData5        = dr["EVT_D_5"].ToString();
                    m_eventHeader6      = dr["EVT_H_6"].ToString();
                    m_eventData6        = dr["EVT_D_6"].ToString();
                    m_eventHeader7      = dr["EVT_H_7"].ToString();
                    m_eventData7        = dr["EVT_D_7"].ToString();
                    m_eventHeader8      = dr["EVT_H_8"].ToString();
                    m_eventData8        = dr["EVT_D_8"].ToString();
                    m_eventHeader9      = dr["EVT_H_9"].ToString();
                    m_eventData9        = dr["EVT_D_9"].ToString();
                    m_eventHeader10     = dr["EVT_H_10"].ToString();
                    m_eventData10       = dr["EVT_D_10"].ToString();
                    m_eventHeader11     = dr["EVT_H_11"].ToString();
                    m_eventData11       = dr["EVT_D_11"].ToString();
                    m_eventHeader12     = dr["EVT_H_12"].ToString();
                    m_eventData12       = dr["EVT_D_12"].ToString();
                    m_eventHeader13     = dr["EVT_H_13"].ToString();
                    m_eventData13       = dr["EVT_D_13"].ToString();
                    m_eventHeader14     = dr["EVT_H_14"].ToString();
                    m_eventData14       = dr["EVT_D_14"].ToString();
                    m_eventHeader15     = dr["EVT_H_15"].ToString();
                    m_eventData15       = dr["EVT_D_15"].ToString();
                    m_eventHeader16     = dr["EVT_H_16"].ToString();
                    m_eventData16       = dr["EVT_D_16"].ToString();
                    m_eventHeader17     = dr["EVT_H_17"].ToString();
                    m_eventData17       = dr["EVT_D_17"].ToString();
                    m_eventHeader18     = dr["EVT_H_18"].ToString();
                    m_eventData18       = dr["EVT_D_18"].ToString();
                    m_eventHeader19     = dr["EVT_H_19"].ToString();
                    m_eventData19       = dr["EVT_D_19"].ToString();
                    m_eventHeader20     = dr["EVT_H_20"].ToString();
                    m_eventData20       = dr["EVT_D_20"].ToString();
                    m_comments          = dr["TRAN_COMMENT"].ToString();
                    }

                // --

                base.fTypeDescriptor.properties["Time"].attributes.replace(new DisplayNameAttribute("Time"));
                base.fTypeDescriptor.properties["EqpName"].attributes.replace(new DisplayNameAttribute("Equipment"));
                base.fTypeDescriptor.properties["EventId"].attributes.replace(new DisplayNameAttribute("Event"));
                base.fTypeDescriptor.properties["SystemCode"].attributes.replace(new DisplayNameAttribute("System Code"));
                base.fTypeDescriptor.properties["Eap"].attributes.replace(new DisplayNameAttribute("EAP"));
                base.fTypeDescriptor.properties["ControlMode"].attributes.replace(new DisplayNameAttribute("Control Mode"));
                base.fTypeDescriptor.properties["PrimaryState"].attributes.replace(new DisplayNameAttribute("Primary State"));
                base.fTypeDescriptor.properties["State"].attributes.replace(new DisplayNameAttribute("State"));
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new DisplayNameAttribute("Mode"));
                base.fTypeDescriptor.properties["MDLN"].attributes.replace(new DisplayNameAttribute("MDLN"));
                base.fTypeDescriptor.properties["SoftRev"].attributes.replace(new DisplayNameAttribute("Soft Rev."));
                base.fTypeDescriptor.properties["EventDefine"].attributes.replace(new DisplayNameAttribute("Event Define"));
                base.fTypeDescriptor.properties["EapEventId"].attributes.replace(new DisplayNameAttribute("EAP Event"));
                //base.fTypeDescriptor.properties["EqpRecipe"].attributes.replace(new DisplayNameAttribute("Equipment Recipe"));
                base.fTypeDescriptor.properties["UserId"].attributes.replace(new DisplayNameAttribute("User ID"));
                // --
                base.fTypeDescriptor.properties["Data1"].attributes.replace(new DisplayNameAttribute(m_eventHeader1));
                base.fTypeDescriptor.properties["Data2"].attributes.replace(new DisplayNameAttribute(m_eventHeader2));
                base.fTypeDescriptor.properties["Data3"].attributes.replace(new DisplayNameAttribute(m_eventHeader3));
                base.fTypeDescriptor.properties["Data4"].attributes.replace(new DisplayNameAttribute(m_eventHeader4));
                base.fTypeDescriptor.properties["Data5"].attributes.replace(new DisplayNameAttribute(m_eventHeader5));
                base.fTypeDescriptor.properties["Data6"].attributes.replace(new DisplayNameAttribute(m_eventHeader6));
                base.fTypeDescriptor.properties["Data7"].attributes.replace(new DisplayNameAttribute(m_eventHeader7));
                base.fTypeDescriptor.properties["Data8"].attributes.replace(new DisplayNameAttribute(m_eventHeader8));
                base.fTypeDescriptor.properties["Data9"].attributes.replace(new DisplayNameAttribute(m_eventHeader9));
                base.fTypeDescriptor.properties["Data10"].attributes.replace(new DisplayNameAttribute(m_eventHeader10));
                base.fTypeDescriptor.properties["Data11"].attributes.replace(new DisplayNameAttribute(m_eventHeader11));
                base.fTypeDescriptor.properties["Data12"].attributes.replace(new DisplayNameAttribute(m_eventHeader12));
                base.fTypeDescriptor.properties["Data13"].attributes.replace(new DisplayNameAttribute(m_eventHeader13));
                base.fTypeDescriptor.properties["Data14"].attributes.replace(new DisplayNameAttribute(m_eventHeader14));
                base.fTypeDescriptor.properties["Data15"].attributes.replace(new DisplayNameAttribute(m_eventHeader15));
                base.fTypeDescriptor.properties["Data16"].attributes.replace(new DisplayNameAttribute(m_eventHeader16));
                base.fTypeDescriptor.properties["Data17"].attributes.replace(new DisplayNameAttribute(m_eventHeader17));
                base.fTypeDescriptor.properties["Data18"].attributes.replace(new DisplayNameAttribute(m_eventHeader18));
                base.fTypeDescriptor.properties["Data19"].attributes.replace(new DisplayNameAttribute(m_eventHeader19));
                base.fTypeDescriptor.properties["Data20"].attributes.replace(new DisplayNameAttribute(m_eventHeader20));
                // --

                base.fTypeDescriptor.properties["Comment"].attributes.replace(new DisplayNameAttribute("Comment"));

                // --

				base.fTypeDescriptor.properties["Time"].attributes.replace(new DefaultValueAttribute(m_tranTime));
                base.fTypeDescriptor.properties["EqpName"].attributes.replace(new DefaultValueAttribute(m_eqpName));
                base.fTypeDescriptor.properties["EventId"].attributes.replace(new DefaultValueAttribute(m_eventId));
                base.fTypeDescriptor.properties["SystemCode"].attributes.replace(new DefaultValueAttribute(m_systemCode));
                base.fTypeDescriptor.properties["Eap"].attributes.replace(new DefaultValueAttribute(m_eap));
                base.fTypeDescriptor.properties["ControlMode"].attributes.replace(new DefaultValueAttribute(m_controlMode));
                base.fTypeDescriptor.properties["PrimaryState"].attributes.replace(new DefaultValueAttribute(m_priState));
                base.fTypeDescriptor.properties["State"].attributes.replace(new DefaultValueAttribute(m_state));
                base.fTypeDescriptor.properties["Mode"].attributes.replace(new DefaultValueAttribute(m_mode));
                base.fTypeDescriptor.properties["MDLN"].attributes.replace(new DefaultValueAttribute(m_mdln));
                base.fTypeDescriptor.properties["SoftRev"].attributes.replace(new DefaultValueAttribute(m_softRev));
                base.fTypeDescriptor.properties["EventDefine"].attributes.replace(new DefaultValueAttribute(m_eventDefine));
                base.fTypeDescriptor.properties["EapEventId"].attributes.replace(new DefaultValueAttribute(m_eapEventId));
                //base.fTypeDescriptor.properties["EqpRecipe"].attributes.replace(new DefaultValueAttribute(m_eqpRecipe));
                base.fTypeDescriptor.properties["UserId"].attributes.replace(new DefaultValueAttribute(m_userId));
                // --
                base.fTypeDescriptor.properties["Data1"].attributes.replace(new DefaultValueAttribute(m_eventData1));
                base.fTypeDescriptor.properties["Data2"].attributes.replace(new DefaultValueAttribute(m_eventData2));
                base.fTypeDescriptor.properties["Data3"].attributes.replace(new DefaultValueAttribute(m_eventData3));
                base.fTypeDescriptor.properties["Data4"].attributes.replace(new DefaultValueAttribute(m_eventData4));
                base.fTypeDescriptor.properties["Data5"].attributes.replace(new DefaultValueAttribute(m_eventData5));
                base.fTypeDescriptor.properties["Data6"].attributes.replace(new DefaultValueAttribute(m_eventData6));
                base.fTypeDescriptor.properties["Data7"].attributes.replace(new DefaultValueAttribute(m_eventData7));
                base.fTypeDescriptor.properties["Data8"].attributes.replace(new DefaultValueAttribute(m_eventData8));
                base.fTypeDescriptor.properties["Data9"].attributes.replace(new DefaultValueAttribute(m_eventData9));
                base.fTypeDescriptor.properties["Data10"].attributes.replace(new DefaultValueAttribute(m_eventData10));
                base.fTypeDescriptor.properties["Data11"].attributes.replace(new DefaultValueAttribute(m_eventData11));
                base.fTypeDescriptor.properties["Data12"].attributes.replace(new DefaultValueAttribute(m_eventData12));
                base.fTypeDescriptor.properties["Data13"].attributes.replace(new DefaultValueAttribute(m_eventData13));
                base.fTypeDescriptor.properties["Data14"].attributes.replace(new DefaultValueAttribute(m_eventData14));
                base.fTypeDescriptor.properties["Data15"].attributes.replace(new DefaultValueAttribute(m_eventData15));
                base.fTypeDescriptor.properties["Data16"].attributes.replace(new DefaultValueAttribute(m_eventData16));
                base.fTypeDescriptor.properties["Data17"].attributes.replace(new DefaultValueAttribute(m_eventData17));
                base.fTypeDescriptor.properties["Data18"].attributes.replace(new DefaultValueAttribute(m_eventData18));
                base.fTypeDescriptor.properties["Data19"].attributes.replace(new DefaultValueAttribute(m_eventData19));
                base.fTypeDescriptor.properties["Data20"].attributes.replace(new DefaultValueAttribute(m_eventData20));
                // --
                base.fTypeDescriptor.properties["Comment"].attributes.replace(new DefaultValueAttribute(m_comments));

                // --

                base.fTypeDescriptor.properties["Data1"].attributes.replace(new BrowsableAttribute(m_eventHeader1 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data2"].attributes.replace(new BrowsableAttribute(m_eventHeader2 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data3"].attributes.replace(new BrowsableAttribute(m_eventHeader3 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data4"].attributes.replace(new BrowsableAttribute(m_eventHeader4 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data5"].attributes.replace(new BrowsableAttribute(m_eventHeader5 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data6"].attributes.replace(new BrowsableAttribute(m_eventHeader6 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data7"].attributes.replace(new BrowsableAttribute(m_eventHeader7 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data8"].attributes.replace(new BrowsableAttribute(m_eventHeader8 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data9"].attributes.replace(new BrowsableAttribute(m_eventHeader9 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data10"].attributes.replace(new BrowsableAttribute(m_eventHeader10 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data11"].attributes.replace(new BrowsableAttribute(m_eventHeader11 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data12"].attributes.replace(new BrowsableAttribute(m_eventHeader12 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data13"].attributes.replace(new BrowsableAttribute(m_eventHeader13 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data14"].attributes.replace(new BrowsableAttribute(m_eventHeader14 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data15"].attributes.replace(new BrowsableAttribute(m_eventHeader15 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data16"].attributes.replace(new BrowsableAttribute(m_eventHeader16 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data17"].attributes.replace(new BrowsableAttribute(m_eventHeader17 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data18"].attributes.replace(new BrowsableAttribute(m_eventHeader18 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data19"].attributes.replace(new BrowsableAttribute(m_eventHeader19 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data20"].attributes.replace(new BrowsableAttribute(m_eventHeader20 == string.Empty ? false : true));
                
                // --
                
                this.fPropGrid.Refresh();
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
