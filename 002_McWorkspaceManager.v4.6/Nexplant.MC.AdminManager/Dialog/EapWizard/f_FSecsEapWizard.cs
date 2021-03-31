﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecsEapWizard.cs
--  Creator         : spike.lee
--  Create Date     : 2012.05.03
--  Description     : FAMate Admin Manager EAP Wizard for SECS Form Class 
--  History         : Created by spike.lee at 2012.05.03
--                    Modified by spike.lee at 2014.03.27
--                      - EAP의 Operation Mode(Server, Client) 정보 추가
--                        - Server : Server에서 EAP를 운영하는 모드
--                        - Client : Client에서 EAP를 운영하는 모드 (이 경우 EAP를 Start하거나 Stop할 수 없음)
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.H101Interface;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinTree;

namespace Nexplant.MC.AdminManager
{
    public partial class FSecsEapWizard : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private FSecsDriver m_fSecsDriver = null;
        private FHostDevice m_fHostDevice = null;       // Host Device의 Host Driver Option 설정용
        private FEnvironment m_fEnvironmentD = null;    // Display용 Environment
        private FEnvironment m_fEnvironmentS = null;    // Setting용 Environment
        private FEapWizardData m_fEapWizardData = null;
        private string m_eapName = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsEapWizard(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsEapWizard(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;

            // --

            m_fEapWizardData = new FEapWizardData();
            m_fEapWizardData.wizardMode = FEapWizardMode.New;
            m_fEapWizardData.fEapType = FEapType.SECS;
            m_fEapWizardData.fOperMode = FEapOperationMode.Server;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsEapWizard(
            FAdmCore fAdmCore,
            FEapWizardData fEapWizardData
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;

            // --

            m_fEapWizardData = fEapWizardData;            
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
                    m_fHostDevice = null;
                    m_fEnvironmentD = null;
                    m_fEnvironmentS = null;
                    if (m_fSecsDriver != null)
                    {
                        m_fSecsDriver.Dispose();
                        m_fSecsDriver = null;
                    }
                    // --
                    m_fAdmCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FEapWizardData fEapWizardData
        {
            get
            {
                try
                {
                    return m_fEapWizardData;
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

        public FHostDevice fHostDevice
        {
            get
            {
                try
                {
                    return m_fHostDevice;
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

        public FEapOperationMode fOperMode
        {
            get
            {
                try
                {
                    return (FEapOperationMode)Enum.Parse(typeof(FEapOperationMode), ucbOperMode.Text);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FEapOperationMode.Server;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void designComboOfOperMode(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbOperMode.dataSource;
                // --
                uds.Band.Columns.Add("Operation Mode");

                // --

                ucbOperMode.DisplayLayout.Bands[0].Columns["Operation Mode"].Width = 120;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                uds = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designComboOfLanguage(
          )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbLanguage.dataSource;
                // --
                uds.Band.Columns.Add("Language");

                // --

                ucbLanguage.DisplayLayout.Bands[0].Columns["Language"].Width = 120;
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

        private void loadEapWizardData(
            )
        {
            try
            {
                if (m_fEapWizardData.wizardMode == FEapWizardMode.Update)
                {
                    txtEap.Text = m_fEapWizardData.eap;
                }
                else
                {
                    txtEap.Text = string.Empty;
                }
                txtDesc.Text = m_fEapWizardData.description;
                // --
                ucbOperMode.Value = m_fEapWizardData.fOperMode.ToString();
                txtSvrName.Text = m_fEapWizardData.server;
                // --
                txtPackage.Text = m_fEapWizardData.package;
                txtPackageVer.Text = m_fEapWizardData.packageVer;
                txtModel.Text = m_fEapWizardData.model;
                txtModelVer.Text = m_fEapWizardData.modelVer;
                // --
                if (m_fEapWizardData.usedComponent == FYesNo.Yes)
                {
                    ((StateEditorButton)txtComponent.ButtonsLeft["Enabled"]).Checked = true;
                    txtComponent.Text = m_fEapWizardData.component;
                    txtComponentVer.Text = m_fEapWizardData.componentVer;
                }
                else
                {
                    ((StateEditorButton)txtComponent.ButtonsLeft["Enabled"]).Checked = false;
                    ((EditorButton)txtComponentVer.ButtonsRight["List"]).Enabled = false;
                }

                // --

                if (m_fEapWizardData.wizardMode == FEapWizardMode.Clone)
                {
                    ucbOperMode.Enabled = false;
                    // --
                    loadEapConfig();
                }
                else if (m_fEapWizardData.wizardMode == FEapWizardMode.Update)
                {
                    txtEap.Enabled = false;
                    ucbOperMode.Enabled = false;
                    txtSvrName.Enabled = false;
                    // --
                    loadEapConfig();
                }
                else
                {
                    loadDefaultEapConfig();
                }

                // --

                if (m_fEapWizardData.model != string.Empty)
                {
                    loadEapSchema();
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

        private void loadEapConfig(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                if (m_fEapWizardData.wizardMode == FEapWizardMode.Clone)
                {
                    fSqlParams.add("eap", m_fEapWizardData.eap);
                }
                else
                {
                    fSqlParams.add("eap", txtEap.Text);
                }
                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EapWizard", "SearchEap", fSqlParams, true);

                // --

                ucbLanguage.Value = dt.Rows[0]["CFG_LANGUAGE"].ToString();
                txtUserId.Text = dt.Rows[0]["CFG_USER_ID"].ToString();
                // --
                nmbDebugLogKeepingPeriod.Value = dt.Rows[0]["CFG_DEBUG_LOG_KEEPING_PERIOD"].ToString();
                // --
                chkEnabledLogOfBinary.Checked = (dt.Rows[0]["CFG_BIN_LOG_ENABLED"].ToString() == FYesNo.Yes.ToString() ? true : false);
                nmbMaxLogFileSizeOfBinaryM.Value = int.Parse(dt.Rows[0]["CFG_MAX_BIN_LOG_FILE_SIZE"].ToString()) / 1024 / 1024;
                nmbMaxLogFileSizeOfBinaryB.Value = dt.Rows[0]["CFG_MAX_BIN_LOG_FILE_SIZE"].ToString();
                // --
                chkEnabledLogOfSml.Checked = (dt.Rows[0]["CFG_SML_LOG_ENABLED"].ToString() == FYesNo.Yes.ToString() ? true : false);
                nmbMaxLogFileSizeOfSmlM.Value = int.Parse(dt.Rows[0]["CFG_MAX_SML_LOG_FILE_SIZE"].ToString()) / 1024 / 1024;
                nmbMaxLogFileSizeOfSmlB.Value = dt.Rows[0]["CFG_MAX_SML_LOG_FILE_SIZE"].ToString();
                // --
                chkEnabledLogOfVfei.Checked = (dt.Rows[0]["CFG_VFEI_LOG_ENABLED"].ToString() == FYesNo.Yes.ToString() ? true : false);
                nmbMaxLogFileSizeOfVfeiM.Value = int.Parse(dt.Rows[0]["CFG_MAX_VFEI_LOG_FILE_SIZE"].ToString()) / 1024 / 1024;
                nmbMaxLogFileSizeOfVfeiB.Value = dt.Rows[0]["CFG_MAX_VFEI_LOG_FILE_SIZE"].ToString();
                // --
                chkEnabledLogOfSecs.Checked = (dt.Rows[0]["CFG_SECS_LOG_ENABLED"].ToString() == FYesNo.Yes.ToString() ? true : false);
                nmbMaxLogFileSizeOfSecsM.Value = int.Parse(dt.Rows[0]["CFG_MAX_SECS_LOG_FILE_SIZE"].ToString()) / 1024 / 1024;
                nmbMaxLogFileSizeOfSecsB.Value = dt.Rows[0]["CFG_MAX_SECS_LOG_FILE_SIZE"].ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadDefaultEapConfig(
            )
        {
            try
            {
                ucbLanguage.Value = FLanguage.Default.ToString();
                txtUserId.Text = "EAP";
                // --
                nmbDebugLogKeepingPeriod.Value = 30;
                // --
                chkEnabledLogOfBinary.Checked = false;
                nmbMaxLogFileSizeOfBinaryM.Value = 5;
                nmbMaxLogFileSizeOfBinaryB.Value = 5 * 1024 * 1024;
                // --
                chkEnabledLogOfSml.Checked = false;
                nmbMaxLogFileSizeOfSmlM.Value = 5;
                nmbMaxLogFileSizeOfSmlB.Value = 5 * 1024 * 1024;
                // --
                chkEnabledLogOfVfei.Checked = false;
                nmbMaxLogFileSizeOfVfeiM.Value = 5;
                nmbMaxLogFileSizeOfVfeiB.Value = 5 * 1024 * 1024;
                // --
                chkEnabledLogOfSecs.Checked = true;
                nmbMaxLogFileSizeOfSecsM.Value = 5;
                nmbMaxLogFileSizeOfSecsB.Value = 5 * 1024 * 1024;
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

        private void loadEapSchema(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSch = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutSch = null;
            FXmlNode fXmlNodeOutScd = null;

            try
            {
                if (txtModel.Text == string.Empty && txtModelVer.Text == string.Empty)
                {
                    tvwSdv.Nodes.Clear();
                    tvwHdv.Nodes.Clear();
                    tvwEqp.Nodes.Clear();
                    return;
                }

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_DlgEapWizardEapSchemaSearch_In.E_ADMADS_DlgEapWizardEapSchemaSearch_In);
                // --
                fXmlNodeIn.set_elemVal(FADMADS_DlgEapWizardEapSchemaSearch_In.A_hLanguage, FADMADS_DlgEapWizardEapSchemaSearch_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_DlgEapWizardEapSchemaSearch_In.A_hFactory, FADMADS_DlgEapWizardEapSchemaSearch_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_DlgEapWizardEapSchemaSearch_In.A_hUserId, FADMADS_DlgEapWizardEapSchemaSearch_In.D_hUserId, m_fAdmCore.fOption.user);
                if (m_fEapWizardData.wizardMode == FEapWizardMode.Update || 
                    m_fEapWizardData.wizardMode == FEapWizardMode.Clone)
                {
                    fXmlNodeIn.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_In.A_hStep,
                        FADMADS_DlgEapWizardEapSchemaSearch_In.D_hStep,
                        "2"
                        );
                }
                else
                {
                    fXmlNodeIn.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_In.A_hStep,
                        FADMADS_DlgEapWizardEapSchemaSearch_In.D_hStep,
                        "1"
                        );
                }

                // --

                fXmlNodeInSch = fXmlNodeIn.set_elem(FADMADS_DlgEapWizardEapSchemaSearch_In.FSchema.E_Schema);
                
                // --

                if (m_fEapWizardData.wizardMode == FEapWizardMode.Clone)
                {
                    fXmlNodeInSch.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_In.FSchema.A_Eap,
                        FADMADS_DlgEapWizardEapSchemaSearch_In.FSchema.D_Eap,
                        m_fEapWizardData.eap
                    );

                    // --
                }
                else
                {
                    fXmlNodeInSch.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_In.FSchema.A_Eap,
                        FADMADS_DlgEapWizardEapSchemaSearch_In.FSchema.D_Eap,
                        txtEap.Text
                    );
                }
                
                // --

                m_eapName = txtEap.Text;

                // --

                fXmlNodeInSch.set_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_In.FSchema.A_Model,
                    FADMADS_DlgEapWizardEapSchemaSearch_In.FSchema.D_Model,
                    txtModel.Text
                    );
                fXmlNodeInSch.set_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_In.FSchema.A_Version,
                    FADMADS_DlgEapWizardEapSchemaSearch_In.FSchema.D_Version,
                    txtModelVer.Text
                    );

                // --

                FADMADSCaster.ADMADS_DlgEapWizardEapSchemaSearch_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_DlgEapWizardEapSchemaSearch_Out.A_hStatus, FADMADS_DlgEapWizardEapSchemaSearch_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_DlgEapWizardEapSchemaSearch_Out.A_hStatusMessage, FADMADS_DlgEapWizardEapSchemaSearch_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutSch = fXmlNodeOut.get_elem(FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.E_Schema);
                fXmlNodeOutScd = fXmlNodeOutSch.get_elem(FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver);

                // --

                refreshTreeOfSecsDevice(fXmlNodeOutScd);
                refreshTreeOfHostDevice(fXmlNodeOutScd);
                refreshTreeOfEquipment(fXmlNodeOutScd);
                refreshTreeOfEnvironment(fXmlNodeOutScd);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSch = null;
                fXmlNodeOut = null;
                fXmlNodeOutSch = null;
                fXmlNodeOutScd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshComboOfOperMode(
             )
        {
            try
            {
                ucbOperMode.beginUpdate(false);
                ucbOperMode.removeAllDataRow();

                // --

                foreach (string s in Enum.GetNames(typeof(FEapOperationMode)))
                {
                    ucbOperMode.appendDataRow(s, new object[] { s });
                }

                // --

                ucbOperMode.endUpdate(false);

                // --

                ucbOperMode.ActiveRow = ucbOperMode.Rows[0];
            }
            catch (Exception ex)
            {
                ucbOperMode.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshComboOfLanguage(
            )
        {
            try
            {
                ucbLanguage.beginUpdate();

                // --

                foreach (string s in Enum.GetNames(typeof(FLanguage)))
                {
                    ucbLanguage.appendDataRow(s, new object[] { s });
                }

                // --

                ucbLanguage.endUpdate();

                // --

                ucbLanguage.ActiveRow = ucbLanguage.Rows[0];
            }
            catch (Exception ex)
            {
                ucbLanguage.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeOfSecsDevice(
            FXmlNode fXmlNodeScd
            )
        {
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeSdv = null;
            UltraTreeNode tNodeSsn = null;
            int keyIndex = 0;

            try
            {
                tvwSdv.beginUpdate();
                tvwSdv.Nodes.Clear();

                // --
                // ***
                // 2018.03.28 by Jeff.Kim
                // Clone인 경우 SECS Device의 이름을 Eap 이름으로 설정하도록 처리
                // ***
                if (m_fEapWizardData.wizardMode != FEapWizardMode.Update)
                {
                    fXmlNodeScd.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.D_Name,
                        m_eapName
                        );
                }
                
                // --

                tNodeScd = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeScd));
                tNodeScd.Override.NodeAppearance.Image = Properties.Resources.SecsDriver;
                keyIndex++;
                tNodeScd.Tag = fXmlNodeScd;

                // --

                foreach (FXmlNode fXmlNodeSdv in fXmlNodeScd.get_elemList(FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.E_SecsDevice))
                {
                    // ***
                    // 2017.03.31 by spike.lee
                    // New와 Clone인 경우 SECS Device의 이름을 Eap 이름으로 설정하도록 처리
                    // ***
                    if (m_fEapWizardData.wizardMode != FEapWizardMode.Update)
                    {
                        fXmlNodeSdv.set_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Name,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Name,
                            m_eapName
                            );
                    }

                    // --
                    
                    tNodeSdv = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeSdv));
                    tNodeSdv.Override.NodeAppearance.Image = Properties.Resources.SecsDevice;
                    keyIndex++;
                    tNodeSdv.Tag = fXmlNodeSdv;
                    tNodeScd.Nodes.Add(tNodeSdv);

                    // --

                    foreach (FXmlNode fXmlNodeSsn in fXmlNodeSdv.get_elemList(FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession))
                    {
                        // ***
                        // 2017.03.31 by spike.lee
                        // New와 Clone인 경우 SECS Session의 이름을 Eap 이름으로 설정하도록 처리
                        // ***
                        if (m_fEapWizardData.wizardMode != FEapWizardMode.Update)
                        {
                            fXmlNodeSsn.set_elemVal(
                                FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_Name,
                                FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_Name,
                                m_eapName
                                );
                        }

                        // --

                        tNodeSsn = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeSsn));
                        tNodeSsn.Override.NodeAppearance.Image = Properties.Resources.SecsSession;
                        keyIndex++;
                        tNodeSsn.Tag = fXmlNodeSsn;
                        tNodeSdv.Nodes.Add(tNodeSsn);
                    }
                }

                // --

                tvwSdv.Nodes.Add(tNodeScd);
                tvwSdv.ExpandAll();
                // --
                tvwSdv.ActiveNode = tNodeScd;

                // --

                tvwSdv.endUpdate();
            }
            catch (Exception ex)
            {
                tvwSdv.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeScd = null;
                tNodeSdv = null;
                tNodeSsn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeOfHostDevice(
            FXmlNode fXmlNodeScd
            )
        {
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeHdv = null;
            UltraTreeNode tNodeHsn = null;
            int keyIndex = 0;

            try
            {
                tvwHdv.beginUpdate();
                tvwHdv.Nodes.Clear();

                // --
                // ***
                // 2018.03.28 by Jeff.Kim
                // Clone인 경우 SECS Device의 이름을 Eap 이름으로 설정하도록 처리
                // ***
                if (m_fEapWizardData.wizardMode != FEapWizardMode.Update)
                {
                    fXmlNodeScd.set_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.D_Name,
                        m_eapName
                        );
                }

                // --

                tNodeScd = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeScd));
                tNodeScd.Override.NodeAppearance.Image = Properties.Resources.SecsDriver;
                keyIndex++;
                tNodeScd.Tag = fXmlNodeScd;

                // --

                foreach (FXmlNode fXmlNodeHdv in fXmlNodeScd.get_elemList(FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.E_HostDevice))
                {
                    tNodeHdv = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeHdv));
                    tNodeHdv.Override.NodeAppearance.Image = Properties.Resources.HostDevice;
                    keyIndex++;
                    tNodeHdv.Tag = fXmlNodeHdv;
                    tNodeScd.Nodes.Add(tNodeHdv);

                    // --

                    foreach (FXmlNode fXmlNodeHsn in fXmlNodeHdv.get_elemList(FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.E_HostSession))
                    {
                        // --
                        // ***
                        // 2018.03.28 by Jeff.Kim
                        // Clone인 경우 SECS Device의 이름을 Eap 이름으로 설정하도록 처리
                        // ***
                        if (m_fEapWizardData.wizardMode != FEapWizardMode.Update)
                        {
                            fXmlNodeHsn.set_elemVal(
                                FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_MachineId,
                                FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_MachineId,
                                m_eapName
                                );
                        }

                        // --

                        tNodeHsn = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeHsn));
                        tNodeHsn.Override.NodeAppearance.Image = Properties.Resources.HostSession;
                        keyIndex++;
                        tNodeHsn.Tag = fXmlNodeHsn;
                        tNodeHdv.Nodes.Add(tNodeHsn);
                    }
                }

                // --

                tvwHdv.Nodes.Add(tNodeScd);
                tvwHdv.ExpandAll();
                // --
                tvwHdv.ActiveNode = tNodeScd;

                // --

                tvwHdv.endUpdate();
            }
            catch (Exception ex)
            {
                tvwHdv.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeScd = null;
                tNodeHdv = null;
                tNodeHsn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeOfEquipment(
            FXmlNode fXmlNodeScd
            )
        {
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeEqp = null;
            int keyIndex = 0;

            try
            {
                tvwEqp.beginUpdate();
                tvwEqp.Nodes.Clear();

                // --

                tNodeScd = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeScd));
                tNodeScd.Override.NodeAppearance.Image = Properties.Resources.SecsDriver;
                keyIndex++;
                tNodeScd.Tag = fXmlNodeScd;

                // --

                foreach (FXmlNode fXmlNodeEqp in fXmlNodeScd.get_elemList(FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment))
                {
                    // ***
                    // 2017.03.31 by spike.lee
                    // New와 Clone인 경우 SECS Session의 이름을 Eap 이름으로 설정하도록 처리
                    // ***
                    if (m_fEapWizardData.wizardMode != FEapWizardMode.Update)
                    {
                        fXmlNodeEqp.set_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Name,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Name,
                            m_eapName
                            );
                    }

                    // --

                    tNodeEqp = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeEqp));
                    tNodeEqp.Override.NodeAppearance.Image = Properties.Resources.Equipment;
                    keyIndex++;
                    tNodeEqp.Tag = fXmlNodeEqp;
                    tNodeScd.Nodes.Add(tNodeEqp);
                }

                // --

                tvwEqp.Nodes.Add(tNodeScd);
                tvwEqp.ExpandAll();
                // --
                tvwEqp.ActiveNode = tNodeScd;

                // --

                tvwEqp.endUpdate();
            }
            catch (Exception ex)
            {
                tvwEqp.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeScd = null;
                tNodeEqp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTreeOfEnvironment(
            FXmlNode fXmlNodeScd
            )
        {
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeEnl = null;
            UltraTreeNode tNodeEnv = null;
            int keyIndex = 0;
            string format = string.Empty;

            try
            {
                tvwEnv.beginUpdate();
                tvwEnv.Nodes.Clear();

                // --

                tNodeScd = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeScd));
                tNodeScd.Override.NodeAppearance.Image = Properties.Resources.SecsDriver;
                keyIndex++;
                tNodeScd.Tag = fXmlNodeScd;

                // --

                foreach (FXmlNode fXmlNodeEnl in fXmlNodeScd.get_elemList(FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.E_EnvironmentList))
                {
                    tNodeEnl = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeEnl));
                    tNodeEnl.Override.NodeAppearance.Image = Properties.Resources.EnvironmentList;
                    keyIndex++;
                    tNodeEnl.Tag = fXmlNodeEnl;
                    tNodeScd.Nodes.Add(tNodeEnl);

                    // --

                    foreach (FXmlNode fXmlNodeEnv in fXmlNodeEnl.get_elemList(FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.E_Environment))
                    {
                        format = fXmlNodeEnv.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Format,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Format
                            ).Trim();

                        // --

                        tNodeEnv = new UltraTreeNode(keyIndex.ToString(), getSchemaObjectText(fXmlNodeEnv));
                        if (format == FFormat.List.ToString() || format == FFormat.AsciiList.ToString())
                        {
                            tNodeEnv.Override.NodeAppearance.Image = Properties.Resources.Environment_List;
                        }
                        else
                        {
                            tNodeEnv.Override.NodeAppearance.Image = Properties.Resources.Environment;
                        }
                        keyIndex++;
                        tNodeEnv.Tag = fXmlNodeEnv;
                        tNodeEnl.Nodes.Add(tNodeEnv);
                    }
                }

                // --

                tvwEnv.Nodes.Add(tNodeScd);
                tvwEnv.ExpandAll();
                // --
                tvwEnv.ActiveNode = tNodeScd;

                // --

                tvwEnv.endUpdate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeScd = null;
                tNodeEnl = null;
                tNodeEnv = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private string getSchemaObjectText(
            FXmlNode fXmlNode
            )
        {
            string info = string.Empty;
            string name = string.Empty;
            string desc = string.Empty;
            FFormat fFormat = FFormat.List;
            string value = string.Empty;

            try
            {
                if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.D_Description
                        ).Trim();
                    // --
                    info = name;
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.E_SecsDevice)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Description
                        ).Trim();
                    // --
                    info = name;
                    // --
                    info += " Protocol=[";
                    info += fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Protocol,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Protocol
                        ).Trim();
                    info += "]";
                    // --
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_Description
                        ).Trim();
                    // --
                    info = name;
                    // --
                    info += " SessionID=[";
                    info += fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_SessionId,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_SessionId
                        ).Trim();
                    info += "]";
                    // --
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.E_HostDevice)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Description
                        ).Trim();
                    // --
                    info = name;
                    // --
                    info += " Driver=[";
                    info += fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Driver,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Driver
                        ).Trim();
                    info += "]";
                    // --
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.E_HostSession)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_Description
                        ).Trim();
                    // --
                    info = name;
                    // --
                    info += " MachineID=[";
                    info += fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_MachineId,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_MachineId
                        ).Trim();
                    info += "]";
                    // --
                    info += " SessionID=[";
                    info += fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_SessionId,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_SessionId
                        ).Trim();
                    info += "]";
                    // --
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Description
                        ).Trim();
                    // --                    
                    info += " " + name;
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.E_EnvironmentList)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.D_Description
                        ).Trim();
                    // --                    
                    info = name;
                    if (desc != string.Empty)
                    {
                        info += " Desc=[" + desc + "]";
                    }
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.E_Environment)
                {
                    name = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Name
                        ).Trim();
                    desc = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Description
                        ).Trim();
                    fFormat = (FFormat)Enum.Parse(
                        typeof(FFormat),
                        fXmlNode.get_elemVal(FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Format, FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Format).Trim()
                        );
                    value = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Value,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Value
                        ).Trim();
                    // --
                    m_fEnvironmentD.name = name;
                    m_fEnvironmentD.description = desc;
                    m_fEnvironmentD.fFormat = fFormat;
                    if (fFormat != FFormat.List && fFormat != FFormat.AsciiList && fFormat != FFormat.Unknown && fFormat != FFormat.Raw)
                    {
                        m_fEnvironmentD.stringValue = value;
                    }
                    // --
                    info = m_fEnvironmentD.ToString(FStringOption.Detail);
                }

                // --

                return info;
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

        public void refreshSchemaObject(
            FXmlNode fXmlNode,
            UltraTreeNode tNode
            )
        {
            string info = string.Empty;

            try
            {
                info = getSchemaObjectText(fXmlNode);
                tNode.Text = info;
                // --
                if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver)
                {
                    if (tvwSdv.Nodes[0] != tNode)
                    {
                        tvwSdv.Nodes[0].Text = info;
                        if (tvwSdv.Nodes[0].IsActive)
                        {
                            pgdSdv.Refresh();
                        }
                    }

                    if (tvwHdv.Nodes[0] != tNode)
                    {
                        tvwHdv.Nodes[0].Text = info;
                        if (tvwHdv.Nodes[0].IsActive)
                        {
                            pgdHdv.Refresh();
                        }
                    }

                    if (tvwEqp.Nodes[0] != tNode)
                    {
                        tvwEqp.Nodes[0].Text = info;
                        if (tvwEqp.Nodes[0].IsActive)
                        {
                            pgdEqp.Refresh();
                        }
                    }

                    if (tvwEnv.Nodes[0] != tNode)
                    {
                        tvwEnv.Nodes[0].Text = info;
                        if (tvwEnv.Nodes[0].IsActive)
                        {
                            pgdEnv.Refresh();
                        }
                    }
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

        private void showServerSelector(
            )
        {
            FServerSelector fDialog = null;
            string serverType = FServerType.Real.ToString();

            try
            {
                if ((string)ucbOperMode.Value == FEapOperationMode.Client.ToString())
                {
                    serverType = FServerType.Virtual.ToString();
                }

                fDialog = new FServerSelector(m_fAdmCore, serverType, txtSvrName.Text, "N");
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtSvrName.Text = fDialog.selectedServer;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void showPackageVerSelector(
            )
        {
            FPackageVersionSelector fDialog = null;

            try
            {
                fDialog = new FPackageVersionSelector(m_fAdmCore, FEapType.SECS.ToString(), txtPackage.Text, txtPackageVer.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtPackage.Text = fDialog.selectedPackage;
                txtPackageVer.Text = fDialog.selectedPackageVer;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void showModelVerSelector(
            )
        {
            FModelVersionSelector fDialog = null;

            try
            {
                fDialog = new FModelVersionSelector(m_fAdmCore, FEapType.SECS.ToString(), txtModel.Text, txtModelVer.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                if (txtModel.Text != fDialog.selectedModel || txtModelVer.Text != fDialog.selectedModelVer)
                {
                    txtModel.Text = fDialog.selectedModel;
                    txtModelVer.Text = fDialog.selectedModelVer;
                    // --
                    loadEapSchema();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void showComponentVerSelector(
            )
        {
            FComponentVersionSelector fDialog = null;

            try
            {
                fDialog = new FComponentVersionSelector(m_fAdmCore, FEapType.SECS.ToString(), txtComponent.Text, txtComponentVer.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtComponent.Text = fDialog.selectedComponent;
                txtComponentVer.Text = fDialog.selectedComponentVer;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void validateStep100(
            )
        {
            string errorMessage = string.Empty;

            try
            {
                if (!FCommon.validateName(txtEap.Text, true, ref errorMessage, m_fAdmCore.fUIWizard, "EAP"))
                {
                    txtEap.Focus();
                    FDebug.throwFException(errorMessage);
                }

                if (txtSvrName.Text == string.Empty)
                {
                    txtSvrName.Focus();
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Server" }));
                }

                if (txtPackage.Text == string.Empty)
                {
                    txtPackageVer.Focus();
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Package" }));
                }

                if (txtModel.Text == string.Empty)
                {
                    txtModelVer.Focus();
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Model" }));
                }

                if (((StateEditorButton)txtComponent.ButtonsLeft["Enabled"]).Checked && txtComponent.Text == string.Empty)
                {
                    txtComponentVer.Focus();
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Component" }));
                }

                // --

                if (!FCommon.validateName(txtUserId.Text, true, ref errorMessage, m_fAdmCore.fUIWizard, "User ID"))
                {
                    txtUserId.Focus();
                    FDebug.throwFException(errorMessage);
                }

                if ((int)nmbMaxLogFileSizeOfSecsB.Value < 1)
                {
                    nmbMaxLogFileSizeOfSecsB.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Max SECS Log File Size" }));
                }

                if ((int)nmbMaxLogFileSizeOfBinaryB.Value < 1)
                {
                    nmbMaxLogFileSizeOfBinaryB.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Max Binary Log File Size" }));
                }

                if ((int)nmbMaxLogFileSizeOfSmlB.Value < 1)
                {
                    nmbMaxLogFileSizeOfSmlB.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Max SML Log File Size" }));
                }

                if ((int)nmbMaxLogFileSizeOfVfeiB.Value < 1)
                {
                    nmbMaxLogFileSizeOfVfeiB.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Max VFEI Log File Size" }));
                }                

                if ((int)nmbDebugLogKeepingPeriod.Value < 1)
                {
                    nmbDebugLogKeepingPeriod.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Debug Log Keeping Period" }));
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

        private void procPreviousStep(
            )
        {
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;

                // --

                if (key == "General")
                {
                    
                }
                else if (key == "SECS")
                {
                    key = "General";

                    // --

                    btnPrevious.Enabled = false;
                    btnNext.Enabled = true;
                    // --
                    btnConfigDefault.Enabled = true;

                    // --

                    txtEap.Focus();
                }                
                else if (key == "Host")
                {
                    key = "SECS";

                    // --

                    tvwSdv.Focus();
                }
                else if (key == "Equipment")
                {
                    key = "Host";

                    // --

                    tvwHdv.Focus();
                }
                else if (key == "Environment")
                {
                    key = "Equipment";

                    // --

                    btnNext.Enabled = true;
                    btnOk.Enabled = false;

                    // --

                    tvwEqp.Focus();
                }                

                // --

                tabMain.ActiveTab.Visible = false;
                tabMain.ActiveTab = tabMain.Tabs[key];                
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

        private void procNextStep(
            )
        {
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;

                // --

                if (key == "General")
                {
                    validateStep100();
                    
                    // --
                    
                    key = "SECS";

                    // --

                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                    // --
                    btnConfigDefault.Enabled = false;

                    // --

                    tvwSdv.Focus();

                    // --

                    loadEapSchema();
                }
                else if (key == "SECS")
                {
                    key = "Host";

                    // --

                    tvwHdv.Focus();
                }                
                else if (key == "Host")
                {
                    key = "Equipment";

                    // --

                    tvwEqp.Focus();
                }
                else if (key == "Equipment")
                {
                    key = "Environment";

                    // --

                    btnNext.Enabled = false;
                    btnOk.Enabled = true;                 

                    // --

                    tvwEnv.Focus();
                }
                else if (key == "Environment")
                {
                             
                }                

                // --

                tabMain.ActiveTab.Visible = false;
                tabMain.ActiveTab = tabMain.Tabs[key];                
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

        #region FEapWizard Form Event Handler

        private void FEapWizard_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((StateEditorButton)txtComponent.ButtonsLeft["Enabled"]).AfterCheckStateChanged += new EditorButtonEventHandler(txtCommon_LeftButtonAfterCheckStateChanged);
                // --
                ((EditorButton)txtSvrName.ButtonsRight["List"]).Click += new EditorButtonEventHandler(txtCommon_RightButtonClick);
                ((EditorButton)txtPackageVer.ButtonsRight["List"]).Click += new EditorButtonEventHandler(txtCommon_RightButtonClick);
                ((EditorButton)txtModelVer.ButtonsRight["List"]).Click += new EditorButtonEventHandler(txtCommon_RightButtonClick);
                ((EditorButton)txtComponentVer.ButtonsRight["List"]).Click += new EditorButtonEventHandler(txtCommon_RightButtonClick);

                // --

                designComboOfOperMode();
                designComboOfLanguage();

                // --

                refreshComboOfOperMode();
                refreshComboOfLanguage();

                // --

                m_fSecsDriver = new FSecsDriver(m_fAdmCore.fWsmCore.appPath + "\\License\\license.lic");
                m_fHostDevice = m_fSecsDriver.appendChildHostDevice(new FHostDevice(m_fSecsDriver));
                m_fEnvironmentD = new FEnvironment(m_fSecsDriver);
                m_fEnvironmentS = new FEnvironment(m_fSecsDriver);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
                this.Close();
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FEapWizard_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadEapWizardData();

                // --

                btnNext.Enabled = true;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FEapWizard_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                ((StateEditorButton)txtComponent.ButtonsLeft["Enabled"]).AfterCheckStateChanged -= new EditorButtonEventHandler(txtCommon_LeftButtonAfterCheckStateChanged);
                // --
                ((EditorButton)txtSvrName.ButtonsRight["List"]).Click -= new EditorButtonEventHandler(txtCommon_RightButtonClick);
                ((EditorButton)txtPackageVer.ButtonsRight["List"]).Click -= new EditorButtonEventHandler(txtCommon_RightButtonClick);
                ((EditorButton)txtModelVer.ButtonsRight["List"]).Click -= new EditorButtonEventHandler(txtCommon_RightButtonClick);
                ((EditorButton)txtComponentVer.ButtonsRight["List"]).Click -= new EditorButtonEventHandler(txtCommon_RightButtonClick);

                // --

                m_fHostDevice = null;
                m_fEnvironmentD = null;
                m_fEnvironmentS = null;
                if (m_fSecsDriver != null)
                {
                    m_fSecsDriver.Dispose();
                    m_fSecsDriver = null;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region DropDownListCombo Control Common Event Handler

        private void ucbCommon_ValueChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (sender == ucbOperMode)
                {
                    txtSvrName.Value = string.Empty;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region TextBox Common Control Event Handler

        private void txtCommon_LeftButtonAfterCheckStateChanged(
            object sender,
            EditorButtonEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (sender == txtComponent.ButtonsLeft["Enabled"])
                {
                    if (((StateEditorButton)e.Button).CheckState == CheckState.Checked)
                    {
                        ((EditorButton)txtComponentVer.ButtonsRight["List"]).Enabled = true;
                    }
                    else
                    {
                        ((EditorButton)txtComponentVer.ButtonsRight["List"]).Enabled = false;
                        // --
                        txtComponent.Text = string.Empty;
                        txtComponentVer.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void txtCommon_RightButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --                

                if (sender == txtSvrName.ButtonsRight["List"])
                {
                    showServerSelector();
                }
                else if (sender == txtPackageVer.ButtonsRight["List"])
                {
                    showPackageVerSelector();
                }
                else if (sender == txtModelVer.ButtonsRight["List"])
                {
                    showModelVerSelector();
                }
                else if (sender == txtComponentVer.ButtonsRight["List"])
                {
                    showComponentVerSelector();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Common NumericBox Control Event Handler

        private void CommonNumericBoxControl_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            FNumericBox nmb = null;

            try
            {
                nmb = (FNumericBox)sender;

                // --

                if (!nmb.Focused)
                {
                    return;
                }

                // --

                if (nmb == nmbMaxLogFileSizeOfBinaryM)
                {
                    nmbMaxLogFileSizeOfBinaryB.Value = (int)nmb.Value * 1024 * 1024;
                }
                else if (nmb == nmbMaxLogFileSizeOfBinaryB)
                {
                    nmbMaxLogFileSizeOfBinaryM.Value = (int)nmb.Value / 1024 / 1024;
                }
                else if (nmb == nmbMaxLogFileSizeOfSmlM)
                {
                    nmbMaxLogFileSizeOfSmlB.Value = (int)nmb.Value * 1024 * 1024;
                }
                else if (nmb == nmbMaxLogFileSizeOfSmlB)
                {
                    nmbMaxLogFileSizeOfSmlM.Value = (int)nmb.Value / 1024 / 1024;
                }
                else if (nmb == nmbMaxLogFileSizeOfVfeiM)
                {
                    nmbMaxLogFileSizeOfVfeiB.Value = (int)nmb.Value * 1024 * 1024;
                }
                else if (nmb == nmbMaxLogFileSizeOfVfeiB)
                {
                    nmbMaxLogFileSizeOfVfeiM.Value = (int)nmb.Value / 1024 / 1024;
                }
                else if (nmb == nmbMaxLogFileSizeOfSecsM)
                {
                    nmbMaxLogFileSizeOfSecsB.Value = (int)nmb.Value * 1024 * 1024;
                }
                else if (nmb == nmbMaxLogFileSizeOfSecsB)
                {
                    nmbMaxLogFileSizeOfSecsM.Value = (int)nmb.Value / 1024 / 1024;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {
                nmb = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnPrevious Control Event Handler

        private void btnPrevious_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procPreviousStep();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnNext Control Event Handler

        private void btnNext_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procNextStep();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnOk Control Event Handler

        private void btnOk_Click(
            object sender,
            EventArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeInCfg = null;
            FXmlNode fXmlNodeInScd = null;
            FXmlNode fXmlNodeInSdv = null;
            FXmlNode fXmlNodeInSsn = null;
            FXmlNode fXmlNodeInHdv = null;
            FXmlNode fXmlNodeInHsn = null;
            FXmlNode fXmlNodeInEqp = null;
            FXmlNode fXmlNodeInEnl = null;
            FXmlNode fXmlNodeInEnv = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNode = null;
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeSdv = null;
            UltraTreeNode tNodeSsn = null;
            UltraTreeNode tNodeHdv = null;
            UltraTreeNode tNodeHsn = null;
            UltraTreeNode tNodeEqp = null;
            UltraTreeNode tNodeEnl = null;
            UltraTreeNode tNodeEnv = null;
            // --
            string eap = string.Empty;
            string eapDesc = string.Empty;
            string eapType = string.Empty;
            string operMode = string.Empty;
            string server = string.Empty;
            string package = string.Empty;
            string packageVer = string.Empty;
            string model = string.Empty;
            string modelVer = string.Empty;
            string usedComponent = string.Empty;
            string component = string.Empty;
            string componentVer = string.Empty;
            // --
            string language = string.Empty;
            string userId = string.Empty;
            string debugLogKeepingPeriod = string.Empty;
            string binaryLogEnabled = string.Empty;
            string maxBinaryLogFileSize = string.Empty;
            string smlLogEnabled = string.Empty;
            string maxSmlLogFileSize = string.Empty;
            string vfeiLogEnabled = string.Empty;
            string maxVfeiLogFileSize = string.Empty;
            string secsLogEnabled = string.Empty;
            string maxSecsLogFileSize = string.Empty;
            // --
            string secsDriver = string.Empty;
            string secsDriverDesc = string.Empty;
            // --
            string secsDevice = string.Empty;
            string secsDeviceDesc = string.Empty;
            string secsDeviceMode = string.Empty;
            string protocol = string.Empty;
            string connectMode = string.Empty;
            string localIp = string.Empty;
            string localPort = string.Empty;
            string remoteIp = string.Empty;
            string remotePort = string.Empty;
            string serialPort = string.Empty;
            string baud = string.Empty;
            string rbit = string.Empty;
            string interleave = string.Empty;
            string duplicateError = string.Empty;
            string ignoreSystemBytes = string.Empty;
            string linkTestPeriod = string.Empty;
            string retryLimit = string.Empty;
            string t1Timeout = string.Empty;
            string t2Timeout = string.Empty;
            string t3Timeout = string.Empty;
            string t4Timeout = string.Empty;
            string t5Timeout = string.Empty;
            string t6Timeout = string.Empty;
            string t7Timeout = string.Empty;
            string t8Timeout = string.Empty;
            // --
            string secsSession = string.Empty;
            string secsSessionDesc = string.Empty;
            string secsSessionId = string.Empty;
            // --
            string hostDevice = string.Empty;
            string hostDeviceDesc = string.Empty;
            string hostDeviceMode = string.Empty;
            string driver = string.Empty;
            string driverDesc = string.Empty;
            string driverOption = string.Empty;
            string tTimeout = string.Empty;
            // --
            string hostSession = string.Empty;
            string hostSessionDesc = string.Empty;
            string machineId = string.Empty;
            string hostSessionId = string.Empty;
            // --
            string equipment = string.Empty;
            string equipmentDesc = string.Empty;
            // --
            string environmentList = string.Empty;
            string environmentListDesc = string.Empty;
            // --
            string environment = string.Empty;
            string environmentDesc = string.Empty;
            string environmentUniqueId = string.Empty;
            string environmentFormat = string.Empty;
            string environmentLength = string.Empty;
            string environmentValue = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEapUpdate_In.E_ADMADS_SetEapUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hLanguage, FADMADS_SetEapUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hFactory, FADMADS_SetEapUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hUserId, FADMADS_SetEapUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hHostIp, FADMADS_SetEapUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hHostName, FADMADS_SetEapUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                if (m_fEapWizardData.wizardMode == FEapWizardMode.Update)
                {
                    fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hStep, FADMADS_SetEapUpdate_In.D_hStep, "1");
                }
                else
                {
                    fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hStep, FADMADS_SetEapUpdate_In.D_hStep, "2");
                }

                // --

                #region MC

                eap = txtEap.Text;
                eapDesc = txtDesc.Text == string.Empty ? " " : txtDesc.Text;
                eapType = FEapType.SECS.ToString();
                operMode = ucbOperMode.Text;
                server = txtSvrName.Text;
                package = txtPackage.Text;
                packageVer = txtPackageVer.Text;
                model = txtModel.Text;
                modelVer = txtModelVer.Text;
                usedComponent = ((StateEditorButton)txtComponent.ButtonsLeft["Enabled"]).CheckState == CheckState.Checked ? FYesNo.Yes.ToString() : FYesNo.No.ToString();
                component = txtComponent.Text == string.Empty ? " " : txtComponent.Text;
                componentVer = txtComponentVer.Text == string.Empty ? "0" : txtComponentVer.Text;
                // --
                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_SetEapUpdate_In.FEap.E_Eap);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_Name, FADMADS_SetEapUpdate_In.FEap.D_Name, eap);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_Description, FADMADS_SetEapUpdate_In.FEap.D_Description, eapDesc);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_EapType, FADMADS_SetEapUpdate_In.FEap.D_EapType, eapType);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_OperMode, FADMADS_SetEapUpdate_In.FEap.D_OperMode, operMode);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_Server, FADMADS_SetEapUpdate_In.FEap.D_Server, server);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_Package, FADMADS_SetEapUpdate_In.FEap.D_Package, package);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_PackageVer, FADMADS_SetEapUpdate_In.FEap.D_PackageVer, packageVer);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_Model, FADMADS_SetEapUpdate_In.FEap.D_Model, model);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_ModelVer, FADMADS_SetEapUpdate_In.FEap.D_ModelVer, modelVer);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_UsedComponent, FADMADS_SetEapUpdate_In.FEap.D_UsedComponent, usedComponent);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_Component, FADMADS_SetEapUpdate_In.FEap.D_Component, component);
                fXmlNodeInEap.set_elemVal(FADMADS_SetEapUpdate_In.FEap.A_ComponentVer, FADMADS_SetEapUpdate_In.FEap.D_ComponentVer, componentVer);

                #endregion

                // --

                #region Config

                language = ucbLanguage.Value.ToString();
                userId = txtUserId.Text;
                debugLogKeepingPeriod = nmbDebugLogKeepingPeriod.Value.ToString();
                binaryLogEnabled = (chkEnabledLogOfBinary.Checked == true ? FYesNo.Yes.ToString() : FYesNo.No.ToString());
                maxBinaryLogFileSize = nmbMaxLogFileSizeOfBinaryB.Value.ToString();
                smlLogEnabled = (chkEnabledLogOfSml.Checked == true ? FYesNo.Yes.ToString() : FYesNo.No.ToString());
                maxSmlLogFileSize = nmbMaxLogFileSizeOfSmlB.Value.ToString();
                vfeiLogEnabled = (chkEnabledLogOfVfei.Checked == true ? FYesNo.Yes.ToString() : FYesNo.No.ToString());
                maxVfeiLogFileSize = nmbMaxLogFileSizeOfVfeiB.Value.ToString();
                secsLogEnabled = (chkEnabledLogOfSecs.Checked == true ? FYesNo.Yes.ToString() : FYesNo.No.ToString());
                maxSecsLogFileSize = nmbMaxLogFileSizeOfSecsB.Value.ToString();
                // --
                fXmlNodeInCfg = fXmlNodeInEap.set_elem(FADMADS_SetEapUpdate_In.FEap.FConfig.E_Config);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_Language, FADMADS_SetEapUpdate_In.FEap.FConfig.D_Language, language);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_UserId, FADMADS_SetEapUpdate_In.FEap.FConfig.D_UserId, userId);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_DebugLogKeepingPeriod, FADMADS_SetEapUpdate_In.FEap.FConfig.D_DebugLogKeepingPeriod, debugLogKeepingPeriod);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_BinaryLogEnabled, FADMADS_SetEapUpdate_In.FEap.FConfig.D_BinaryLogEnabled, binaryLogEnabled);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_MaxBinaryLogFileSize, FADMADS_SetEapUpdate_In.FEap.FConfig.D_MaxBinaryLogFileSize, maxBinaryLogFileSize);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_SmlLogEnabled, FADMADS_SetEapUpdate_In.FEap.FConfig.D_SmlLogEnabled, smlLogEnabled);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_MaxSmlLogFileSize, FADMADS_SetEapUpdate_In.FEap.FConfig.D_MaxSmlLogFileSize, maxSmlLogFileSize);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_VfeiLogEnabled, FADMADS_SetEapUpdate_In.FEap.FConfig.D_VfeiLogEnabled, vfeiLogEnabled);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_MaxVfeiLogFileSize, FADMADS_SetEapUpdate_In.FEap.FConfig.D_MaxVfeiLogFileSize, maxVfeiLogFileSize);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_SecsLogEnabled, FADMADS_SetEapUpdate_In.FEap.FConfig.D_SecsLogEnabled, secsLogEnabled);
                fXmlNodeInCfg.set_elemVal(FADMADS_SetEapUpdate_In.FEap.FConfig.A_MaxSecsLogFileSize, FADMADS_SetEapUpdate_In.FEap.FConfig.D_MaxSecsLogFileSize, maxSecsLogFileSize);

                #endregion

                // --

                #region SECS Driver

                tNodeScd = tvwSdv.Nodes[0];
                fXmlNode = (FXmlNode)tNodeScd.Tag;
                // --
                secsDriver = fXmlNode.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.A_Name,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.D_Name
                    );
                secsDriverDesc = fXmlNode.get_elemVal(
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.A_Description,
                    FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.D_Description
                    );
                // --
                fXmlNodeInScd = fXmlNodeInEap.set_elem(FADMADS_SetEapUpdate_In.FEap.FSecsDriver.E_SecsDriver);
                fXmlNodeInScd.set_elemVal(
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.A_Name,
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.D_Name,
                    secsDriver
                    );
                fXmlNodeInScd.set_elemVal(
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.A_Description,
                    FADMADS_SetEapUpdate_In.FEap.FSecsDriver.D_Description,
                    secsDriverDesc == string.Empty ? " " : secsDriverDesc
                    );

                #endregion

                // --

                #region SECS Device

                for (int i = 0; i < tNodeScd.Nodes.Count; i++)
                {
                    tNodeSdv = tNodeScd.Nodes[i];
                    fXmlNode = (FXmlNode)tNodeSdv.Tag;
                    // --
                    secsDevice = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Name
                        );
                    secsDeviceDesc = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Description
                        );
                    secsDeviceMode = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Mode,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Mode
                        );
                    protocol = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Protocol,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Protocol
                        );
                    connectMode = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_ConnectMode,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_ConnectMode
                        );
                    localIp = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LocalIp,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LocalIp
                        );
                    localPort = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LocalPort,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LocalPort
                        );
                    remoteIp = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RemoteIp,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RemoteIp
                        );
                    remotePort = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RemotePort,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RemotePort
                        );
                    serialPort = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_SerialPort,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_SerialPort
                        );
                    baud = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Baud,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Baud
                        );
                    rbit = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RBit,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RBit
                        );
                    interleave = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_Interleave,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_Interleave
                        );
                    duplicateError = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_DuplicateError,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_DuplicateError
                        );
                    ignoreSystemBytes = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_IgnoreSystemBytes,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_IgnoreSystemBytes
                        );
                    linkTestPeriod = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_LinkTestTimePeriod,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_LinkTestTimePeriod
                        );
                    retryLimit = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_RetryLimit,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_RetryLimit
                        );
                    t1Timeout = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T1Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T1Timeout
                        );
                    t2Timeout = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T2Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T2Timeout
                        );
                    t3Timeout = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T3Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T3Timeout
                        );
                    t4Timeout = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T4Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T4Timeout
                        );
                    t5Timeout = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T5Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T5Timeout
                        );
                    t6Timeout = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T6Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T6Timeout
                        );
                    t7Timeout = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T7Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T7Timeout
                        );
                    t8Timeout = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.A_T8Timeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.D_T8Timeout
                        );
                    // --
                    fXmlNodeInSdv = fXmlNodeInScd.add_elem(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.E_SecsDevice
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_Seq,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_Seq,
                        i.ToString()
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_Name,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_Name,
                        secsDevice
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_Description,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_Description,
                        secsDeviceDesc == string.Empty ? " " : secsDeviceDesc
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_Mode,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_Mode,
                        secsDeviceMode
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_Protocol,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_Protocol,
                        protocol
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_ConnectMode,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_ConnectMode,
                        connectMode
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_LocalIp,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_LocalIp,
                        localIp
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_LocalPort,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_LocalPort,
                        localPort
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_RemoteIp,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_RemoteIp,
                        remoteIp
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_RemotePort,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_RemotePort,
                        remotePort
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_SerialPort,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_SerialPort,
                        serialPort
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_Baud,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_Baud,
                        baud
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_RBit,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_RBit,
                        rbit
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_Interleave,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_Interleave,
                        interleave
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_DuplicateError,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_DuplicateError,
                        duplicateError
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_IgnoreSystemBytes,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_IgnoreSystemBytes,
                        ignoreSystemBytes
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_LinkTestTimePeriod,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_LinkTestTimePeriod,
                        linkTestPeriod
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_RetryLimit,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_RetryLimit,
                        retryLimit
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_OpcUrl,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_OpcUrl,
                        " "
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_OpcHandleId,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_OpcHandleId,
                        "0"
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_OpcLocalId,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_OpcLocalId,
                        " "
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_OpcDefaultNamespace,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_OpcDefaultNamespace,
                        " "
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_OpcKeepAliveTime,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_OpcKeepAliveTime,
                        "0"
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_OpcEventReloadTime,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_OpcEventReloadTime,
                        "0"
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_T1Timeout,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_T1Timeout,
                        t1Timeout
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_T2Timeout,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_T2Timeout,
                        t2Timeout
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_T3Timeout,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_T3Timeout,
                        t3Timeout
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_T4Timeout,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_T4Timeout,
                        t4Timeout
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_T5Timeout,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_T5Timeout,
                        t5Timeout
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_T6Timeout,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_T6Timeout,
                        t6Timeout
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_T7Timeout,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_T7Timeout,
                        t7Timeout
                        );
                    fXmlNodeInSdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.A_T8Timeout,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.D_T8Timeout,
                        t8Timeout
                        );

                    // --

                    #region SECS Session

                    for (int j = 0; j < tNodeSdv.Nodes.Count; j++)
                    {
                        tNodeSsn = tNodeSdv.Nodes[j];
                        fXmlNode = (FXmlNode)tNodeSsn.Tag;
                        // --
                        secsSession = fXmlNode.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_Name,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_Name
                            );
                        secsSessionDesc = fXmlNode.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_Description,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_Description
                            );
                        secsSessionId = fXmlNode.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.A_SessionId,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.D_SessionId
                            );
                        // --
                        fXmlNodeInSsn = fXmlNodeInSdv.add_elem(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_Seq,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_Seq,
                            j.ToString()
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_Name,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_Name,
                            secsSession
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_Description,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_Description,
                            secsSessionDesc == string.Empty ? " " : secsSessionDesc
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_SessionId,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_SessionId,
                            secsSessionId
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_ScanEnabled,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_ScanEnabled,
                            " "
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_ScanTime,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_ScanTime,
                            "0"
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_AutoClear,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_AutoClear,
                            " "
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_LinkMapExpression,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_LinkMapExpression,
                            " "
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_ReadBitDeviceCode,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_ReadBitDeviceCode,
                            " "
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_ReadBitStartAddress,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_ReadBitStartAddress,
                            "0"
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_ReadBitLength,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_ReadBitLength,
                            "0"
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_ReadWordDeviceCode,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_ReadWordDeviceCode,
                            " "
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_ReadWordStartAddress,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_ReadWordStartAddress,
                            "0"
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_ReadWordLength,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_ReadWordLength,
                            "0"
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_WriteBitDeviceCode,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_WriteBitDeviceCode,
                            " "
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_WriteBitStartAddress,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_WriteBitStartAddress,
                            "0"
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_WriteBitLength,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_WriteBitLength,
                            "0"
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_WriteWordDeviceCode,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_WriteWordDeviceCode,
                            " "
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_WriteWordStartAddress,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_WriteWordStartAddress,
                            "0"
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_WriteWordLength,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_WriteWordLength,
                            "0"
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_OpcChannel,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_OpcChannel,
                            " "
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_OpcUpdateRate,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_OpcUpdateRate,
                            "0"
                            );
                        fXmlNodeInSsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.A_OpcDeadBand,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FSecsDevice.FSecsSession.D_OpcDeadBand,
                            "0"
                            );
                    }

                    #endregion
                }

                #endregion

                // --

                #region Host Device

                tNodeScd = tvwHdv.Nodes[0];
                // --
                for (int i = 0; i < tNodeScd.Nodes.Count; i++)
                {
                    tNodeHdv = tNodeScd.Nodes[i];
                    fXmlNode = (FXmlNode)tNodeHdv.Tag;
                    // --
                    hostDevice = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Name
                        );
                    hostDeviceDesc = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Description
                        );
                    hostDeviceMode = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Mode,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Mode
                        );
                    driver = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_Driver,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_Driver
                        );
                    driverDesc = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_DriverDescription,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_DriverDescription
                        );
                    driverOption = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_DriverOption,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_DriverOption
                        );
                    tTimeout = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.A_TransactionTimeout,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.D_TransactionTimeout
                        );
                    // --
                    fXmlNodeInHdv = fXmlNodeInScd.add_elem(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.E_HostDevice
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_Seq,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_Seq,
                        i.ToString()
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_Name,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_Name,
                        hostDevice
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_Description,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_Description,
                        hostDeviceDesc == string.Empty ? " " : hostDeviceDesc
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_Mode,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_Mode,
                        hostDeviceMode
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_Driver,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_Driver,
                        driver == string.Empty ? " " : driver
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_DriverDescription,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_DriverDescription,
                        driverDesc == string.Empty ? " " : driverDesc
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_DriverOption,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_DriverOption,
                        driverOption == string.Empty ? " " : driverOption
                        );
                    fXmlNodeInHdv.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.A_TransactionTimeout,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.D_TransactionTimeout,
                        tTimeout
                        );

                    // --

                    #region Host Session

                    for (int j = 0; j < tNodeHdv.Nodes.Count; j++)
                    {
                        tNodeHsn = tNodeHdv.Nodes[j];
                        fXmlNode = (FXmlNode)tNodeHsn.Tag;
                        // --
                        hostSession = fXmlNode.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_Name,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_Name
                            );
                        hostSessionDesc = fXmlNode.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_Description,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_Description
                            );
                        machineId = fXmlNode.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_MachineId,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_MachineId
                            );
                        hostSessionId = fXmlNode.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.A_SessionId,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.D_SessionId
                            );
                        // --
                        fXmlNodeInHsn = fXmlNodeInHdv.add_elem(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.FHostSession.E_HostSession
                            );
                        fXmlNodeInHsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.FHostSession.A_Seq,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.FHostSession.D_Seq,
                            j.ToString()
                            );
                        fXmlNodeInHsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.FHostSession.A_Name,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.FHostSession.D_Name,
                            hostSession
                            );
                        fXmlNodeInHsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.FHostSession.A_Description,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.FHostSession.D_Description,
                            hostSessionDesc == string.Empty ? " " : hostSessionDesc
                            );
                        fXmlNodeInHsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.FHostSession.A_MachineId,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.FHostSession.D_MachineId,
                            machineId
                            );
                        fXmlNodeInHsn.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.FHostSession.A_SessionId,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FHostDevice.FHostSession.D_SessionId,
                            hostSessionId
                            );
                    }

                    #endregion
                }

                #endregion

                // --

                #region Equipment

                tNodeScd = tvwEqp.Nodes[0];
                // --
                for (int i = 0; i < tNodeScd.Nodes.Count; i++)
                {
                    tNodeEqp = tNodeScd.Nodes[i];
                    fXmlNode = (FXmlNode)tNodeEqp.Tag;
                    // --
                    equipment = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Name
                        );
                    equipmentDesc = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.D_Description
                        );
                    // --
                    fXmlNodeInEqp = fXmlNodeInScd.add_elem(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.E_Equipment
                        );
                    fXmlNodeInEqp.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.A_Seq,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.D_Seq,
                        i.ToString()
                        );
                    fXmlNodeInEqp.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.A_Name,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.D_Name,
                        equipment
                        );
                    fXmlNodeInEqp.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.A_Description,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEquipment.D_Description,
                        equipmentDesc == string.Empty ? " " : equipmentDesc
                        );
                }

                #endregion

                // --                

                #region Environment List

                tNodeScd = tvwEnv.Nodes[0];
                // --
                for (int i = 0; i < tNodeScd.Nodes.Count; i++)
                {
                    tNodeEnl = tNodeScd.Nodes[i];
                    fXmlNode = (FXmlNode)tNodeEnl.Tag;
                    // --
                    environmentList = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.A_Name,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.D_Name
                        );
                    environmentListDesc = fXmlNode.get_elemVal(
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.A_Description,
                        FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.D_Description
                        );
                    // --
                    fXmlNodeInEnl = fXmlNodeInScd.add_elem(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.E_EnvironmentList
                        );
                    fXmlNodeInEnl.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.A_Seq,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.D_Seq,
                        i.ToString()
                        );
                    fXmlNodeInEnl.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.A_Name,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.D_Name,
                        environmentList
                        );
                    fXmlNodeInEnl.set_elemVal(
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.A_Description,
                        FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.D_Description,
                        environmentListDesc
                        );

                    // --

                    #region Environment

                    for (int j = 0; j < tNodeEnl.Nodes.Count; j++)
                    {
                        tNodeEnv = tNodeEnl.Nodes[j];
                        fXmlNode = (FXmlNode)tNodeEnv.Tag;
                        // --
                        environment = fXmlNode.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Name,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Name
                            );
                        environmentDesc = fXmlNode.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Description,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Description
                            );
                        environmentUniqueId = fXmlNode.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_UniqueId,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_UniqueId
                            );
                        environmentFormat = fXmlNode.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Format,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Format
                            );
                        environmentLength = fXmlNode.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Length,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Length
                            );
                        environmentValue = fXmlNode.get_elemVal(
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.A_Value,
                            FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.D_Value
                            );
                        // --
                        fXmlNodeInEnv = fXmlNodeInEnl.add_elem(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.E_Environment
                            );
                        fXmlNodeInEnv.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.A_Seq,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.D_Seq,
                            j.ToString()
                            );
                        fXmlNodeInEnv.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.A_Name,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.D_Name,
                            environment
                            );
                        fXmlNodeInEnv.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.A_Description,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.D_Description,
                            environmentDesc
                            );
                        fXmlNodeInEnv.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.A_UniqueId,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.D_UniqueId,
                            environmentUniqueId
                            );
                        fXmlNodeInEnv.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.A_Format,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.D_Format,
                            environmentFormat
                            );
                        fXmlNodeInEnv.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.A_Length,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.D_Length,
                            environmentLength
                            );
                        fXmlNodeInEnv.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.A_Value,
                            FADMADS_SetEapUpdate_In.FEap.FSecsDriver.FEnvironmentList.FEnvironment.D_Value,
                            environmentValue
                            );
                    }

                    #endregion
                }

                #endregion

                // --                

                FADMADSCaster.ADMADS_SetEapUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetEapUpdate_Out.A_hStatus, FADMADS_SetEapUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetEapUpdate_Out.A_hStatusMessage, FADMADS_SetEapUpdate_Out.D_hStatusMessage));
                }

                // --

                m_fEapWizardData.eap = eap;
                m_fEapWizardData.description = eapDesc;
                m_fEapWizardData.fOperMode = (FEapOperationMode)Enum.Parse(typeof(FEapOperationMode), operMode);
                m_fEapWizardData.server = server;
                m_fEapWizardData.package = package;
                m_fEapWizardData.packageVer = packageVer;
                m_fEapWizardData.model = model;
                m_fEapWizardData.modelVer = modelVer;
                m_fEapWizardData.usedComponent = usedComponent == FYesNo.Yes.ToString() ? FYesNo.Yes : FYesNo.No;
                m_fEapWizardData.component = component;
                m_fEapWizardData.componentVer = componentVer;

                // --

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEap = null;
                fXmlNodeInCfg = null;
                fXmlNodeInScd = null;
                fXmlNodeInSdv = null;
                fXmlNodeInSsn = null;
                fXmlNodeInHdv = null;
                fXmlNodeInHsn = null;
                fXmlNodeInEqp = null;
                fXmlNodeInEnl = null;
                fXmlNodeInEnv = null;
                fXmlNodeOut = null;
                fXmlNode = null;
                tNodeScd = null;
                tNodeSdv = null;
                tNodeSsn = null;
                tNodeHdv = null;
                tNodeHsn = null;
                tNodeEqp = null;
                tNodeEnl = null;
                tNodeEnv = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnCancel Control Event Handler

        private void btnCancel_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnConfigDefault Control Event Handler

        private void btnConfigDefault_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadDefaultEapConfig();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tabMain Control Event Handler

        private void tabMain_ActiveTabChanging(
            object sender, 
            Infragistics.Win.UltraWinTabControl.ActiveTabChangingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                e.Tab.Visible = true;                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region TreeView Common Control Event Handler

        private void tvwCommon_AfterActivate(
            object sender,
            NodeEventArgs e
            )
        {
            FTreeView fTreeView = null;
            FXmlNode fXmlNode = null;


            try
            {
                fTreeView = (FTreeView)sender;
                if (fTreeView.ActiveNode == null)
                {
                    return;
                }

                // --

                fXmlNode = (FXmlNode)fTreeView.ActiveNode.Tag;

                // --

                if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.E_SecsDriver)
                {
                    if (fTreeView == tvwSdv)
                    {
                        pgdSdv.selectedObject = new FPropEwdSecsScd(m_fAdmCore, pgdSdv, this, fTreeView.ActiveNode, fXmlNode);
                    }
                    else if (fTreeView == tvwHdv)
                    {
                        pgdHdv.selectedObject = new FPropEwdSecsScd(m_fAdmCore, pgdHdv, this, fTreeView.ActiveNode, fXmlNode);
                    }
                    else if (fTreeView == tvwEqp)
                    {
                        pgdEqp.selectedObject = new FPropEwdSecsScd(m_fAdmCore, pgdEqp, this, fTreeView.ActiveNode, fXmlNode);
                    }
                    else if (fTreeView == tvwEnv)
                    {
                        pgdEnv.selectedObject = new FPropEwdSecsScd(m_fAdmCore, pgdEnv, this, fTreeView.ActiveNode, fXmlNode);
                    }
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.E_SecsDevice)
                {
                    pgdSdv.selectedObject = new FPropEwdSecsSdv(m_fAdmCore, pgdSdv, this, fTreeView.ActiveNode, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FSecsDevice.FSecsSession.E_SecsSession)
                {
                    pgdSdv.selectedObject = new FPropEwdSecsSsn(m_fAdmCore, pgdSdv, this, fTreeView.ActiveNode, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.E_HostDevice)
                {
                    pgdHdv.selectedObject = new FPropEwdSecsHdv(m_fAdmCore, pgdHdv, this, fTreeView.ActiveNode, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FHostDevice.FHostSession.E_HostSession)
                {
                    pgdHdv.selectedObject = new FPropEwdSecsHsn(m_fAdmCore, pgdHdv, this, fTreeView.ActiveNode, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEquipment.E_Equipment)
                {
                    pgdEqp.selectedObject = new FPropEwdSecsEqp(m_fAdmCore, pgdEqp, this, fTreeView.ActiveNode, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.E_EnvironmentList)
                {
                    pgdEnv.selectedObject = new FPropEwdSecsEnl(m_fAdmCore, pgdEnv, this, fTreeView.ActiveNode, fXmlNode);
                }
                else if (fXmlNode.name == FADMADS_DlgEapWizardEapSchemaSearch_Out.FSchema.FSecsDriver.FEnvironmentList.FEnvironment.E_Environment)
                {
                    pgdEnv.selectedObject = new FPropEwdSecsEnv(m_fAdmCore, pgdEnv, this, fTreeView.ActiveNode, fXmlNode, m_fEnvironmentS);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fTreeView = null;
                fXmlNode = null;
            }
        }

        #endregion       

        //------------------------------------------------------------------------------------------------------------------------

        #region txtEap Control Event Handler

        private void txtEap_EditorButtonClick(
            object sender, 
            EditorButtonEventArgs e
            )
        {
            FEapNameSelector dialog = null;
            string dept = string.Empty;

            try
            {
                dialog = new FEapNameSelector(
                   m_fAdmCore,
                   txtEap.Text,
                   "N"
                   );
                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                if (dialog.selectedEqpName != null)
                {
                    txtEap.Text = dialog.selectedEqpName;
                    txtDesc.Text = dialog.selectedEqpDesc;
                }
                else
                {
                    txtEap.Text = string.Empty;
                    txtDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                dialog = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
