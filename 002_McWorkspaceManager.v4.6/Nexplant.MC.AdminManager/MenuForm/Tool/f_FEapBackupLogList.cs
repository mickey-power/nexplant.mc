﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapBackupLogList.cs
--  Creator         : baehyun.seo
--  Create Date     : 2013.01.14
--  Description     : FAMate Admin Manager EAP Backup Log List Form Class 
--  History         : Created by baehyun.seo at 2013.01.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FEapBackupLogList : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_cleared = true;
        private string m_beforeEapType = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapBackupLogList()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapBackupLogList(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
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
                    m_fAdmCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                base.fUIWizard.changeControlCaption(mnuMenu);
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

        protected override void changeControlFontName(
            )
        {
            try
            {
                base.changeControlFontName();
                base.fUIWizard.changeControlCaption(mnuMenu);
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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                if (m_cleared)
                {
                    mnuMenu.Tools[FMenuKey.MenuEblDownload].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuEblView].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuEblDownload].SharedProps.Enabled = grdBackup.activeDataRowKey == string.Empty && grdLog.activeDataRowKey == string.Empty ? false : true;
                    mnuMenu.Tools[FMenuKey.MenuEblView].SharedProps.Enabled = grdLog.activeDataRowKey == string.Empty ? false : true;
                }

                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------   

        private Image getImageOfLog(
            string fileName
            )
        {
            string fileExtension = string.Empty;

            try
            {
                fileExtension = Path.GetExtension(fileName);

                if (fileExtension == ".dlg")
                {
                    return grdLog.ImageList.Images["File_Dlg"];
                }
                else if (fileExtension == ".wlg")
                {
                    return grdLog.ImageList.Images["File_Log"];
                }
                else if (fileExtension == ".sml")
                {
                    return grdLog.ImageList.Images["File_Sml"];
                }
                else if (fileExtension == ".xlg")
                {
                    return grdLog.ImageList.Images["File_Xlg"];
                }
                else if (fileExtension == ".vfe")
                {
                    return grdLog.ImageList.Images["File_Vfe"];
                }
                else if (fileExtension == ".bng")
                {
                    return grdLog.ImageList.Images["File_Bng"];
                }
                else if (fileExtension == ".ssl")
                {
                    return grdLog.ImageList.Images["File_Ssl"];
                }
                else if (fileExtension == ".psl")
                {
                    return grdLog.ImageList.Images["File_Psl"];
                }
                else if (fileExtension == ".osl")
                {
                    return grdLog.ImageList.Images["File_Osl"];
                }
                else if (fileExtension == ".tsl")
                {
                    return grdLog.ImageList.Images["File_Tsl"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return grdLog.ImageList.Images["File_Dlg"];
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designComboOfLogType(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbLogType.dataSource;

                // --

                uds.Band.Columns.Add("Log Type");

                // --

                ucbLogType.Appearance.Image = Properties.Resources.Log;

                // --

                ucbLogType.DisplayLayout.Bands[0].Columns["Log Type"].CellAppearance.Image = Properties.Resources.Log;

                // --

                ucbLogType.DisplayLayout.Bands[0].Columns["Log Type"].Width = ucbLogType.Width - 2;
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

        private void designGridOfBackupList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdBackup.dataSource;
                // --
                uds.Band.Columns.Add("File Name");
                uds.Band.Columns.Add("Start Time");
                uds.Band.Columns.Add("Creation Time");
                uds.Band.Columns.Add("Last Write Time");
                uds.Band.Columns.Add("Last Access Time");
                uds.Band.Columns.Add("Size");

                // --

                grdBackup.DisplayLayout.Bands[0].Columns["File Name"].CellAppearance.Image = Properties.Resources.File_Zip;
                // --
                grdBackup.DisplayLayout.Bands[0].Columns["Start Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdBackup.DisplayLayout.Bands[0].Columns["Creation Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdBackup.DisplayLayout.Bands[0].Columns["Last Write Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdBackup.DisplayLayout.Bands[0].Columns["Last Access Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdBackup.DisplayLayout.Bands[0].Columns["Size"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdBackup.DisplayLayout.Bands[0].Columns["File Name"].Header.Fixed = true;
                // --
                grdBackup.DisplayLayout.Bands[0].Columns["File Name"].Width = 250;
                grdBackup.DisplayLayout.Bands[0].Columns["Start Time"].Width = 160;
                grdBackup.DisplayLayout.Bands[0].Columns["Creation Time"].Width = 160;
                grdBackup.DisplayLayout.Bands[0].Columns["Last Write Time"].Width = 160;
                grdBackup.DisplayLayout.Bands[0].Columns["Last Access Time"].Width = 160;
                grdBackup.DisplayLayout.Bands[0].Columns["Size"].Width = 60;
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

        private void designGridOfLogList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdLog.dataSource;
                // --
                uds.Band.Columns.Add("File Name");
                uds.Band.Columns.Add("Start Time");
                uds.Band.Columns.Add("Creation Time");
                uds.Band.Columns.Add("Last Write Time");
                uds.Band.Columns.Add("Last Access Time");
                uds.Band.Columns.Add("Size");

                // --

                grdLog.DisplayLayout.Bands[0].Columns["Start Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdLog.DisplayLayout.Bands[0].Columns["Creation Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdLog.DisplayLayout.Bands[0].Columns["Last Write Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdLog.DisplayLayout.Bands[0].Columns["Last Access Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdLog.DisplayLayout.Bands[0].Columns["Size"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdLog.DisplayLayout.Bands[0].Columns["File Name"].Header.Fixed = true;
                // --
                grdLog.DisplayLayout.Bands[0].Columns["File Name"].Width = 250;
                grdLog.DisplayLayout.Bands[0].Columns["Start Time"].Width = 160;
                grdLog.DisplayLayout.Bands[0].Columns["Creation Time"].Width = 160;
                grdLog.DisplayLayout.Bands[0].Columns["Last Write Time"].Width = 160;
                grdLog.DisplayLayout.Bands[0].Columns["Last Access Time"].Width = 160;
                grdLog.DisplayLayout.Bands[0].Columns["Size"].Width = 60;

                // --

                grdLog.ImageList = new ImageList();
                // --
                grdLog.ImageList.Images.Add("File_Dlg", Properties.Resources.File_Dlg);
                grdLog.ImageList.Images.Add("File_Ssl", Properties.Resources.File_Ssl);
                grdLog.ImageList.Images.Add("File_Sml", Properties.Resources.File_Sml);
                grdLog.ImageList.Images.Add("File_Vfe", Properties.Resources.File_Vfe);
                grdLog.ImageList.Images.Add("File_Bng", Properties.Resources.File_Bng);
                grdLog.ImageList.Images.Add("File_Osl", Properties.Resources.File_Osl);
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

        private void clear(
            )
        {
            try
            {
                if (m_cleared)
                {
                    return;
                }

                // --

                grdBackup.beginUpdate();
                grdLog.beginUpdate();

                // --

                // ***
                // EAP Backup Log List Clear
                // ***
                grdBackup.removeAllDataRow();
                grdLog.removeAllDataRow();

                // --

                grdBackup.endUpdate();
                grdLog.endUpdate();

                // --

                refreshBackupLogTotal();
                refreshLogTotal();

                // --

                m_cleared = true;
                controlMenu();
            }
            catch (Exception ex)
            {
                grdLog.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void attach(
            string eapName,
            string eapType
            )
        {
            try
            {
                txtEapName.Text = eapName;
                // --
                refreshComboOfLogType(eapType);
                refreshGridOfBackupLogList();

                // --

                grdBackup.Focus();
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

        private void refreshComboOfLogType(
            string eapType
            )
        {
            try
            {
                if (m_beforeEapType == eapType)
                {
                    return;
                }

                // --

                ucbLogType.beginUpdate(false);
                ucbLogType.removeAllDataRow();

                // --

                foreach (string s in Enum.GetNames(typeof(FEapLogType)))
                {
                    if (s == FEapLogType.SECS.ToString())
                    {
                        if (
                            eapType != FEapType.SECS.ToString() &&
                            eapType != FEapType.Process.ToString()
                            )
                        {
                            continue;
                        }
                    }
                    //else if (s == FEapLogType.PLC.ToString())
                    //{
                    //    if (
                    //        eapType != FEapType.PLC.ToString() &&
                    //        eapType != FEapType.Process.ToString()
                    //        )
                    //    {
                    //        continue;
                    //    }
                    //}
                    else if (s == FEapLogType.OPC.ToString())
                    {
                        if (
                            eapType != FEapType.OPC.ToString() &&
                            eapType != FEapType.Process.ToString()
                            )
                        {
                            continue;
                        }
                    }
                    else if (s == FEapLogType.TCP.ToString())
                    {
                        if (
                            eapType != FEapType.TCP.ToString() &&
                            eapType != FEapType.Process.ToString()
                            )
                        {
                            continue;
                        }
                    }
                    else if (s == FEapLogType.Debug.ToString())
                    {

                    }
                    else if (s == FEapLogType.SML.ToString())
                    {
                        if (eapType != FEapType.SECS.ToString())
                        {
                            continue;
                        }
                    }
                    else if (s == FEapLogType.XLG.ToString())
                    {
                        if (eapType != FEapType.TCP.ToString())
                        {
                            continue;
                        }
                    }
                    else if (s == FEapLogType.VFEI.ToString())
                    {
                        if (
                            eapType != FEapType.SECS.ToString() &&
                            //eapType != FEapType.PLC.ToString() &&
                            eapType != FEapType.TCP.ToString() &&
                            eapType != FEapType.OPC.ToString() &&
                            eapType != FEapType.Process.ToString()
                            )
                        {
                            continue;
                        }
                    }
                    else if (s == FEapLogType.Binary.ToString())
                    {
                        if (
                            eapType != FEapType.SECS.ToString() &&
                            //eapType != FEapType.PLC.ToString() &&
                            eapType != FEapType.TCP.ToString() &&
                            eapType != FEapType.Process.ToString()
                            )
                        {
                            continue;
                        }
                    }
                    else if (s == FEapLogType.Log.ToString())
                    {

                    }
                    else if (s == FEapLogType.WLG.ToString())
                    {
                        continue;
                    }
                    // --
                    ucbLogType.appendDataRow(s, new object[] { s });
                }

                // --

                ucbLogType.endUpdate(false);

                // --

                if (eapType == FEapType.SECS.ToString())
                {
                    ucbLogType.Text = FEapLogType.SECS.ToString();
                }
                //else if (eapType == FEapType.PLC.ToString())
                //{
                //    ucbLogType.Text = FEapLogType.PLC.ToString();
                //}
                else if (eapType == FEapType.OPC.ToString())
                {
                    ucbLogType.Text = FEapLogType.OPC.ToString();
                }
                else if (eapType == FEapType.TCP.ToString())
                {
                    ucbLogType.Text = FEapLogType.TCP.ToString();
                }
                else if (eapType == FEapType.FILE.ToString())
                {
                    ucbLogType.Text = FEapLogType.Log.ToString();
                }
                else
                {
                    ucbLogType.Text = FEapLogType.All.ToString();
                }
                // --
                m_beforeEapType = eapType;
            }
            catch (Exception ex)
            {
                ucbLogType.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshGridOfBackupLogList(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                beforeKey = grdBackup.activeDataRowKey;
                // --
                grdBackup.beginUpdate(false);
                grdBackup.removeAllDataRow();
                grdBackup.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                #region Validation

                if (txtEapName.Text.Trim() == string.Empty)
                {
                    grdBackup.endUpdate(false);
                    txtEapName.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "EAP" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolEapBackupLogList_In.E_ADMADS_TolEapBackupLogList_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogList_In.A_hLanguage, FADMADS_TolEapBackupLogList_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogList_In.A_hFactory, FADMADS_TolEapBackupLogList_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogList_In.A_hUserId, FADMADS_TolEapBackupLogList_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogList_In.A_hStep, FADMADS_TolEapBackupLogList_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolEapBackupLogList_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(FADMADS_TolEapBackupLogList_In.FLog.A_Eap, FADMADS_TolEapBackupLogList_In.FLog.D_Eap, txtEapName.Text);
                fXmlNodeInLog.set_elemVal(FADMADS_TolEapBackupLogList_In.FLog.A_Type, FADMADS_TolEapBackupLogList_In.FLog.D_Type, ucbLogType.Text);

                // --

                do
                {
                    fXmlNodeInLog.set_elemVal(FADMADS_TolEapBackupLogList_In.FLog.A_NextRowNumber, FADMADS_TolEapBackupLogList_In.FLog.D_NextRowNumber, nextRowNumber.ToString());

                    // --

                    FADMADSCaster.ADMADS_TolEapBackupLogList_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_TolEapBackupLogList_Out.A_hStatus, FADMADS_TolEapBackupLogList_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_TolEapBackupLogList_Out.A_hStatusMessage, FADMADS_TolEapBackupLogList_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    fXmlNodeOutTbl = fXmlNodeOut.get_elem(FADMADS_TolEapBackupLogList_Out.FTable.E_Table);
                    // --
                    dt = FDbWizard.stringToDataTable(fXmlNodeOutTbl.get_elemVal(FADMADS_TolEapBackupLogList_Out.FTable.A_Rows, FADMADS_TolEapBackupLogList_Out.FTable.D_Rows));
                    //--
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0],   // File Name
                            FDataConvert.defaultDataTimeFormating(r[0].ToString().Substring(0, 17)),
                            r[1],   // CreationTime
                            r[2],   // LastWriteTime
                            r[3],   // LastAccessTime
                            r[4]    // Size
                            };
                        key = (string)cellValues[0];
                        index = grdBackup.appendDataRow(key, cellValues).Index;
                    }

                    // --

                    nextRowNumber = int.Parse(
                        fXmlNodeOutTbl.get_elemVal(FADMADS_TolEapBackupLogList_Out.FTable.A_NextRowNumber, FADMADS_TolEapBackupLogList_Out.FTable.D_NextRowNumber)
                        );
                } while (nextRowNumber >= 0);

                // --

                grdBackup.endUpdate(false);
                grdBackup.DisplayLayout.Bands[0].SortedColumns.Add("File Name", false);

                // --

                if (grdBackup.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdBackup.activateDataRow(beforeKey);
                    }
                    if (grdBackup.activeDataRow == null)
                    {
                        grdBackup.ActiveRow = grdBackup.Rows[grdBackup.Rows.Count - 1];
                    }
                }

                // --

                m_cleared = false;
                controlMenu();

                // --

                refreshBackupLogTotal();

                // --

                grdBackup.Focus();
            }
            catch (Exception ex)
            {
                grdBackup.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshGridOfLogList(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                beforeKey = grdLog.activeDataRowKey;
                // --
                grdLog.beginUpdate(false);
                grdLog.removeAllDataRow();
                grdLog.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolEapBackupLogSearch_In.E_ADMADS_TolEapBackupLogSearch_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogSearch_In.A_hLanguage, FADMADS_TolEapBackupLogSearch_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogSearch_In.A_hFactory, FADMADS_TolEapBackupLogSearch_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogSearch_In.A_hUserId, FADMADS_TolEapBackupLogSearch_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogSearch_In.A_hStep, FADMADS_TolEapBackupLogSearch_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolEapBackupLogSearch_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(FADMADS_TolEapBackupLogSearch_In.FLog.A_Eap, FADMADS_TolEapBackupLogSearch_In.FLog.D_Eap, txtEapName.Text);
                fXmlNodeInLog.set_elemVal(FADMADS_TolEapBackupLogSearch_In.FLog.A_File, FADMADS_TolEapBackupLogSearch_In.FLog.D_File, grdBackup.activeDataRowKey);

                // --

                do
                {
                    fXmlNodeInLog.set_elemVal(FADMADS_TolEapBackupLogSearch_In.FLog.A_NextRowNumber, FADMADS_TolEapBackupLogSearch_In.FLog.D_NextRowNumber, nextRowNumber.ToString());

                    // --

                    FADMADSCaster.ADMADS_TolEapBackupLogSearch_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_TolEapBackupLogSearch_Out.A_hStatus, FADMADS_TolEapBackupLogSearch_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_TolEapBackupLogSearch_Out.A_hStatusMessage, FADMADS_TolEapBackupLogSearch_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    fXmlNodeOutTbl = fXmlNodeOut.get_elem(FADMADS_TolEapBackupLogSearch_Out.FTable.E_Table);
                    // --
                    dt = FDbWizard.stringToDataTable(fXmlNodeOutTbl.get_elemVal(FADMADS_TolEapBackupLogSearch_Out.FTable.A_Rows, FADMADS_TolEapBackupLogSearch_Out.FTable.D_Rows));
                    //--
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0],   // File Name
                            FDataConvert.defaultDataTimeFormating(r[0].ToString().Substring(0, 17)),
                            r[1],   // CreationTime
                            r[2],   // LastWriteTime
                            r[3],   // LastAccessTime
                            r[4]    // Size
                            };
                        key = (string)cellValues[0];
                        index = grdLog.appendDataRow(key, cellValues).Index;

                        // --

                        grdLog.Rows[index].Cells[0].Appearance.Image = getImageOfLog(r[0].ToString());
                    }

                    // --

                    nextRowNumber = int.Parse(
                        fXmlNodeOutTbl.get_elemVal(FADMADS_TolEapBackupLogSearch_Out.FTable.A_NextRowNumber, FADMADS_TolEapBackupLogSearch_Out.FTable.D_NextRowNumber)
                        );
                } while (nextRowNumber >= 0);

                // --

                grdLog.endUpdate(false);
                grdLog.DisplayLayout.Bands[0].SortedColumns.Add("File Name", false);

                // --

                if (grdLog.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdLog.activateDataRow(beforeKey);
                    }
                    if (grdLog.activeDataRow == null)
                    {
                        grdLog.ActiveRow = grdLog.Rows[grdLog.Rows.Count - 1];
                    }
                }

                // --

                refreshLogTotal();

                // --

                m_cleared = false;
                controlMenu();
            }
            catch (Exception ex)
            {
                grdLog.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------ 

        private void refreshBackupLogTotal(
            )
        {
            try
            {
                lblBackupLogTotal.Text = grdBackup.Rows.Count.ToString("#,##0");
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

        private void refreshLogTotal(
            )
        {
            try
            {
                lblLogTotal.Text = grdLog.Rows.Count.ToString("#,##0");
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

        private void downloadBackupFile(
            string downloadFilePath
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            FFtp fFtp = null;
            string tempFilePath = string.Empty;
            string zipFileName = string.Empty;

            try
            {
                fFtp = FCommon.createFtp(m_fAdmCore);

                // --

                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolEapBackupLogDownload_In.E_ADMADS_TolEapBackupLogDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogDownload_In.A_hLanguage, FADMADS_TolEapBackupLogDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogDownload_In.A_hFactory, FADMADS_TolEapBackupLogDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogDownload_In.A_hUserId, FADMADS_TolEapBackupLogDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogDownload_In.A_hStep, FADMADS_TolEapBackupLogDownload_In.D_hStep, "1");
                
                // --

                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolEapBackupLogDownload_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapBackupLogDownload_In.FLog.A_Eap,
                    FADMADS_TolEapBackupLogDownload_In.FLog.D_Eap, 
                    txtEapName.Text
                    );

                // --

                foreach (string key in grdBackup.selectedDataRowKeys)
                {
                    fXmlNodeInLog.set_elemVal(
                        FADMADS_TolEapBackupLogDownload_In.FLog.A_File,
                        FADMADS_TolEapBackupLogDownload_In.FLog.D_File, 
                        key
                        );

                    // --

                    FADMADSCaster.ADMADS_TolEapBackupLogDownload_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_TolEapBackupLogDownload_Out.A_hStatus, FADMADS_TolEapBackupLogDownload_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_TolEapBackupLogDownload_Out.A_hStatusMessage, FADMADS_TolEapBackupLogDownload_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolEapBackupLogDownload_Out.FLog.E_Log);
                    zipFileName = fXmlNodeOutLog.get_elemVal(
                        FADMADS_TolEapBackupLogDownload_Out.FLog.A_Path,
                        FADMADS_TolEapBackupLogDownload_Out.FLog.D_Path
                        );

                    // --

                    fFtp.downloadFiles(tempFilePath, zipFileName);
                    fFtp.deleteFiles(zipFileName);

                    // --

                    zipFileName = Path.Combine(tempFilePath, zipFileName);

                    // --

                    F7Zip.unpack(zipFileName, downloadFilePath);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fFtp != null)
                {
                    fFtp.Dispose();
                    fFtp = null;
                }

                // --

                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutLog = null;

                // --

                FCommon.deleteDirectory(tempFilePath);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------ 

        private void downloadLogFile(
            string downloadFilePath
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            FFtp fFtp = null;
            string tempFilePath = string.Empty;
            string tempFileName = string.Empty;
            string backupFileName = string.Empty;
            string logFileName = string.Empty;
            string downloadFileName = string.Empty;

            try
            {
                fFtp = FCommon.createFtp(m_fAdmCore);

                // --

                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TolEapBackupLogDownload_In.E_ADMADS_TolEapBackupLogDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogDownload_In.A_hLanguage, FADMADS_TolEapBackupLogDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogDownload_In.A_hFactory, FADMADS_TolEapBackupLogDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogDownload_In.A_hUserId, FADMADS_TolEapBackupLogDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TolEapBackupLogDownload_In.A_hStep, FADMADS_TolEapBackupLogDownload_In.D_hStep, "1");
                
                // --

                fXmlNodeInLog = fXmlNodeIn.set_elem(FADMADS_TolEapBackupLogDownload_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapBackupLogDownload_In.FLog.A_Eap,
                    FADMADS_TolEapBackupLogDownload_In.FLog.D_Eap, 
                    txtEapName.Text
                    );
                fXmlNodeInLog.set_elemVal(
                    FADMADS_TolEapBackupLogDownload_In.FLog.A_File,
                    FADMADS_TolEapBackupLogDownload_In.FLog.D_File, 
                    grdBackup.activeDataRowKey
                    );

                // --

                FADMADSCaster.ADMADS_TolEapBackupLogDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TolEapBackupLogDownload_Out.A_hStatus, FADMADS_TolEapBackupLogDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_TolEapBackupLogDownload_Out.A_hStatusMessage, FADMADS_TolEapBackupLogDownload_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FADMADS_TolEapBackupLogDownload_Out.FLog.E_Log);
                tempFileName = fXmlNodeOutLog.get_elemVal(
                    FADMADS_TolEapBackupLogDownload_Out.FLog.A_Path,
                    FADMADS_TolEapBackupLogDownload_Out.FLog.D_Path
                    );

                // --

                fFtp.downloadFiles(tempFilePath, tempFileName);
                fFtp.deleteFiles(tempFileName);

                // --
                
                tempFileName = Path.Combine(tempFilePath, tempFileName);
                F7Zip.unpack(tempFileName, tempFilePath);

                // --

                backupFileName = Path.Combine(tempFilePath, grdBackup.activeDataRowKey);
                F7Zip.unpack(backupFileName, tempFilePath);

                // --

                foreach (string key in grdLog.selectedDataRowKeys)
                {
                    logFileName = Path.Combine(tempFilePath, key);
                    downloadFileName = Path.Combine(downloadFilePath, key);

                    // --

                    if (File.Exists(downloadFileName))
                    {
                        if (FMessageBox.showQuestion(
                            FConstants.ApplicationName,
                            m_fAdmCore.fUIWizard.generateMessage("Q0014", new object[] { key }),
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button2,
                            this
                            ) == DialogResult.No)
                        {
                            continue;
                        }
                    }

                    // -- 

                    File.Copy(logFileName, downloadFileName, true);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fFtp != null)
                {
                    fFtp.Dispose();
                    fFtp = null;
                }

                // --

                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutLog = null;

                // --

                FCommon.deleteDirectory(tempFilePath);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------ 

        private void download(
            )
        {
            FolderBrowserDialog fbd = null;
            string downloadFilePath = string.Empty;

            try
            {
                fbd = new FolderBrowserDialog();
                fbd.SelectedPath = m_fAdmCore.fOption.recentLogDownloadPath;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                m_fAdmCore.fOption.recentLogDownloadPath = fbd.SelectedPath;

                // -- 

                downloadFilePath = Path.Combine(fbd.SelectedPath, m_fAdmCore.fOption.factory + "_Eap_Log");
                if (!Directory.Exists(downloadFilePath))
                {
                    Directory.CreateDirectory(downloadFilePath);
                }

                // --

                if (grdBackup.Focused)
                {
                    downloadBackupFile(downloadFilePath);
                }
                else
                {
                    downloadLogFile(downloadFilePath);
                }

                // --

                // ***
                // Download Folder Open
                // ***
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0006"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                Process.Start("explorer.exe", fbd.SelectedPath);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fbd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------ 

        private void viewOfLog(
            )
        {
            FEapLogViewer fEapLogViewer = null;
            FDebugLogViewer fDebugLogViewer = null;
            FSecsTotalLogViewer fSecsLogViewer = null;
            //FPlcLogViewer fPlcLogViewer = null;
            FOpcTotalLogViewer fOpcLogViewer = null;
            FTcpTotalLogViewer fTcpLogViewer = null;
            FFileLogViewer fFileLogViewer = null;
            FBinaryLogViewer fBinaryLogViewer = null;
            FSmlLogViewer fSmlLogViewer = null;
            FXlgLogViewer fXlgLogViewer = null;
            FVfeiLogViewer fVfeiLogViewer = null;
            string extension = string.Empty;

            try
            {
                extension = grdLog.activeDataRowKey.Substring(grdLog.activeDataRowKey.Length - 3);

                // --

                if (extension == FExtensionType.log.ToString())
                {
                    if (m_beforeEapType == FEapType.FILE.ToString())
                    {
                        foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                        {
                            if (fChildForm is FFileLogViewer &&
                                ((FFileLogViewer)fChildForm).fileName == grdLog.activeDataRowKey)
                            {
                                fFileLogViewer = (FFileLogViewer)fChildForm;
                                fFileLogViewer.refreshLog();
                                fFileLogViewer.activate();
                                return;
                            }
                        }

                        // --

                        fFileLogViewer = new FFileLogViewer(m_fAdmCore, txtEapName.Text, grdBackup.activeDataRowKey, grdLog.activeDataRowKey);
                        m_fAdmCore.fAdmContainer.showChild(fFileLogViewer);
                        fFileLogViewer.activate();
                    }
                    else
                    {
                        foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                        {
                            if (fChildForm is FEapLogViewer &&
                                ((FEapLogViewer)fChildForm).fileName == grdLog.activeDataRowKey)
                            {
                                fEapLogViewer = (FEapLogViewer)fChildForm;
                                fEapLogViewer.refreshLog();
                                fEapLogViewer.activate();
                                return;
                            }
                        }

                        // --

                        fEapLogViewer = new FEapLogViewer(m_fAdmCore, txtEapName.Text, grdBackup.activeDataRowKey, grdLog.activeDataRowKey);
                        m_fAdmCore.fAdmContainer.showChild(fEapLogViewer);
                        fEapLogViewer.activate();
                    }
                }
                else if (extension == FExtensionType.dlg.ToString())
                {
                    foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                    {
                        if (fChildForm is FDebugLogViewer &&
                            ((FDebugLogViewer)fChildForm).fileName == grdLog.activeDataRowKey)
                        {
                            fDebugLogViewer = (FDebugLogViewer)fChildForm;
                            fDebugLogViewer.refreshLog();
                            fDebugLogViewer.activate();
                            return;
                        }
                    }

                    // --

                    fDebugLogViewer = new FDebugLogViewer(
                        m_fAdmCore, 
                        string.Empty, 
                        txtEapName.Text, 
                        string.Empty,
                        grdBackup.activeDataRowKey, 
                        grdLog.activeDataRowKey, 
                        FLogFileType.EapLogFile
                        );
                    m_fAdmCore.fAdmContainer.showChild(fDebugLogViewer);
                    fDebugLogViewer.activate();
                }
                else if (extension == FExtensionType.ssl.ToString())
                {
                    foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                    {
                        if (fChildForm is FSecsTotalLogViewer &&
                            ((FSecsTotalLogViewer)fChildForm).fileName == grdLog.activeDataRowKey)
                        {
                            fSecsLogViewer = (FSecsTotalLogViewer)fChildForm;
                            fSecsLogViewer.refreshLog();
                            fSecsLogViewer.activate();
                            return;
                        }
                    }

                    // --

                    fSecsLogViewer = new FSecsTotalLogViewer(m_fAdmCore, txtEapName.Text, grdBackup.activeDataRowKey, grdLog.activeDataRowKey);
                    m_fAdmCore.fAdmContainer.showChild(fSecsLogViewer);
                    fSecsLogViewer.activate();
                }
                //else if (extension == FExtensionType.psl.ToString())
                //{
                //    foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                //    {
                //        if (fChildForm is FPlcLogViewer &&
                //            ((FPlcLogViewer)fChildForm).fileName == grdLog.activeDataRowKey)
                //        {
                //            fPlcLogViewer = (FPlcLogViewer)fChildForm;
                //            fPlcLogViewer.refreshLog();
                //            fPlcLogViewer.activate();
                //            return;
                //        }
                //    }

                //    // --

                //    fPlcLogViewer = new FPlcLogViewer(m_fAdmCore, txtEapName.Text, string.Empty, grdLog.activeDataRowKey);
                //    m_fAdmCore.fAdmContainer.showChild(fPlcLogViewer);
                //    fPlcLogViewer.activate();
                //}
                else if (extension == FExtensionType.osl.ToString())
                {
                    foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                    {
                        if (fChildForm is FOpcTotalLogViewer &&
                            ((FOpcTotalLogViewer)fChildForm).fileName == grdLog.activeDataRowKey)
                        {
                            fOpcLogViewer = (FOpcTotalLogViewer)fChildForm;
                            fOpcLogViewer.refreshLog();
                            fOpcLogViewer.activate();
                            return;
                        }
                    }

                    // --

                    fOpcLogViewer = new FOpcTotalLogViewer(m_fAdmCore, txtEapName.Text, grdBackup.activeDataRowKey, grdLog.activeDataRowKey);
                    m_fAdmCore.fAdmContainer.showChild(fOpcLogViewer);
                    fOpcLogViewer.activate();
                }
                else if (extension == FExtensionType.tsl.ToString())
                {
                    foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                    {
                        if (fChildForm is FTcpTotalLogViewer &&
                            ((FTcpTotalLogViewer)fChildForm).fileName == grdLog.activeDataRowKey)
                        {
                            fTcpLogViewer = (FTcpTotalLogViewer)fChildForm;
                            fTcpLogViewer.refreshLog();
                            fTcpLogViewer.activate();
                            return;
                        }
                    }

                    // --

                    fTcpLogViewer = new FTcpTotalLogViewer(m_fAdmCore, txtEapName.Text, grdBackup.activeDataRowKey, grdLog.activeDataRowKey);
                    m_fAdmCore.fAdmContainer.showChild(fTcpLogViewer);
                    fTcpLogViewer.activate();
                }
                else if (extension == FExtensionType.bng.ToString())
                {
                    foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                    {
                        if (fChildForm is FBinaryLogViewer &&
                            ((FBinaryLogViewer)fChildForm).fileName == grdLog.activeDataRowKey)
                        {
                            fBinaryLogViewer = (FBinaryLogViewer)fChildForm;
                            fBinaryLogViewer.refreshLog();
                            fBinaryLogViewer.activate();
                            return;
                        }
                    }

                    // --

                    fBinaryLogViewer = new FBinaryLogViewer(m_fAdmCore, txtEapName.Text, grdBackup.activeDataRowKey, grdLog.activeDataRowKey);
                    m_fAdmCore.fAdmContainer.showChild(fBinaryLogViewer);
                    fBinaryLogViewer.activate();
                }
                else if (extension == FExtensionType.sml.ToString())
                {
                    foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                    {
                        if (fChildForm is FSmlLogViewer &&
                            ((FSmlLogViewer)fChildForm).fileName == grdLog.activeDataRowKey)
                        {
                            fSmlLogViewer = (FSmlLogViewer)fChildForm;
                            fSmlLogViewer.refreshLog();
                            fSmlLogViewer.activate();
                            return;
                        }
                    }

                    // --

                    fSmlLogViewer = new FSmlLogViewer(m_fAdmCore, txtEapName.Text, grdBackup.activeDataRowKey, grdLog.activeDataRowKey);
                    m_fAdmCore.fAdmContainer.showChild(fSmlLogViewer);
                    fSmlLogViewer.activate();
                }
                else if (extension == FExtensionType.xlg.ToString())
                {
                    foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                    {
                        if (fChildForm is FXlgLogViewer &&
                            ((FXlgLogViewer)fChildForm).fileName == grdLog.activeDataRowKey)
                        {
                            fXlgLogViewer = (FXlgLogViewer)fChildForm;
                            fXlgLogViewer.refreshLog();
                            fXlgLogViewer.activate();
                            return;
                        }
                    }

                    // --

                    fXlgLogViewer = new FXlgLogViewer(m_fAdmCore, txtEapName.Text, grdBackup.activeDataRowKey, grdLog.activeDataRowKey);
                    m_fAdmCore.fAdmContainer.showChild(fXlgLogViewer);
                    fXlgLogViewer.activate();
                }
                else if (extension == FExtensionType.vfe.ToString())
                {
                    foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                    {
                        if (fChildForm is FVfeiLogViewer &&
                            ((FVfeiLogViewer)fChildForm).fileName == grdLog.activeDataRowKey)
                        {
                            fVfeiLogViewer = (FVfeiLogViewer)fChildForm;
                            fVfeiLogViewer.refreshLog();
                            fVfeiLogViewer.activate();
                            return;
                        }
                    }

                    // --

                    fVfeiLogViewer = new FVfeiLogViewer(m_fAdmCore, txtEapName.Text, grdBackup.activeDataRowKey, grdLog.activeDataRowKey);
                    m_fAdmCore.fAdmContainer.showChild(fVfeiLogViewer);
                    fVfeiLogViewer.activate();
                }
                else if (extension == FExtensionType.wlg.ToString())
                {
                    foreach (FBaseTabChildForm fChildForm in m_fAdmCore.fAdmContainer.fChilds)
                    {
                        if (fChildForm is FEapLogViewer &&
                            ((FEapLogViewer)fChildForm).fileName == grdLog.activeDataRowKey)
                        {
                            fEapLogViewer = (FEapLogViewer)fChildForm;
                            fEapLogViewer.refreshLog();
                            fEapLogViewer.activate();
                            return;
                        }
                    }

                    // --

                    fEapLogViewer = new FEapLogViewer(m_fAdmCore, txtEapName.Text, string.Empty, grdLog.activeDataRowKey);
                    m_fAdmCore.fAdmContainer.showChild(fEapLogViewer);
                    fEapLogViewer.activate();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapLogViewer = null;
                fDebugLogViewer = null;
                fSecsLogViewer = null;
                //fPlcLogViewer = null;
                fOpcLogViewer = null;
                fTcpLogViewer = null;
                fBinaryLogViewer = null;
                fSmlLogViewer = null;
                fXlgLogViewer = null;
                fVfeiLogViewer = null;
                fFileLogViewer = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FEapBackupLogList Form Event Handler

        private void FEapBackupLogList_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --            

                designComboOfLogType();
                // --
                designGridOfBackupList();
                designGridOfLogList();

                // --

                m_fAdmCore.fOption.fChildFormList.add(this);
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

        private void FEapBackupLogList_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --                

                controlMenu();

                // --

                txtEapName.Focus();
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

        private void FEapBackupLogList_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fAdmCore.fOption.fChildFormList.remove(this);
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

        private void FEapBackupLogList_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    FCursor.waitCursor();
                    // --
                    if (grdLog.Focused)
                    {
                        refreshGridOfLogList();
                    }
                    else
                    {
                        refreshGridOfBackupLogList();
                    }
                    // --
                    FCursor.defaultCursor();
                }
            }
            catch (Exception ex)
            {
                FCursor.defaultCursor();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender,
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuAblRefresh)
                {
                    refreshGridOfBackupLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuAblDownload)
                {
                    download();
                }
                else if (e.Tool.Key == FMenuKey.MenuAblView)
                {
                    viewOfLog();
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

        #region grdBackup Control Event Handler

        private void grdBackup_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfLogList();
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

        private void grdBackup_MouseDown(
            object sender,
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdBackup.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdBackup.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdBackup.ActiveRow = grdBackup.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuAblView].SharedProps.Visible = false;

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuAblPopupMenu);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                r = null;
                // --
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdLog Control Event Handler

        private void grdLog_DoubleClickRow(
            object sender, 
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                viewOfLog();
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

        private void grdLog_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdLog.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdLog.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdLog.ActiveRow = grdLog.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuAblView].SharedProps.Visible = true;

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuAblPopupMenu);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                r = null;
                // --
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region txtEapName Control Event Handler

        private void txtEapName_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FEapSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FEapSelector(m_fAdmCore, txtEapName.Text, "N");
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtEapName.Text = fDialog.selectedEapName;
                refreshComboOfLogType(fDialog.selectedType);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void txtEapName_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                clear();
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

        #region ucbLogType Control Event Handler

        private void ucbLogType_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                clear();
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

        #region rstBackup Control Event Handler

        private void rstBackup_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdBackup.searchGridRow(e.searchWord))
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
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

        #region rstLog Control Event Handler

        private void rstLog_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfLogList();
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

        private void rstLog_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdLog.searchGridRow(e.searchWord))
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
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

    }   // Class end
}   // Namespace end
