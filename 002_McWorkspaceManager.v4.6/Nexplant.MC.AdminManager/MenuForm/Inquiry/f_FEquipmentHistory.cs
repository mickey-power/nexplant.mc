﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEquipmentHistory.cs
--  Creator         : duchoi
--  Create Date     : 2013.05.22
--  Description     : FAMate Admin Manager Equipment History Form Class 
--  History         : Created by duchoi at 2013.05.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public partial class FEquipmentHistory : Nexplant.MC.Core.FaUIs.FBaseTabChildForm, FIInquiry
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        // --
        private FInquiryProgress m_fInqProgress = null;
        private DataTable m_dtFraseqphis = null;
        private DataTable m_dtFsyseqpevt = null;
        private List<string[]> m_lstReqTimes = null;
        string m_beforeKey = string.Empty;      
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentHistory(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentHistory(
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
                    m_dtFraseqphis = null;
                    m_dtFsyseqpevt = null;
                    m_lstReqTimes = null;
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
                base.fUIWizard.changeControlFontName(mnuMenu);
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

        private void designGridOfHistory(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Time");
                uds.Band.Columns.Add("Equipment");                
                uds.Band.Columns.Add("Event");
                uds.Band.Columns.Add("System Code");
                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Control Mode");
                uds.Band.Columns.Add("Primary State");
                uds.Band.Columns.Add("State");
                uds.Band.Columns.Add("Mode");
                uds.Band.Columns.Add("MDLN");
                uds.Band.Columns.Add("Soft Rev.");
                uds.Band.Columns.Add("Event Define");
                uds.Band.Columns.Add("EAP Event");
                uds.Band.Columns.Add("Equipment Recipe");
                uds.Band.Columns.Add("User ID");
                for (int i = 1; i <= 20; i++)
                {
                    uds.Band.Columns.Add("Header " + i.ToString());
                    uds.Band.Columns.Add("Data " + i.ToString());
                }  
                uds.Band.Columns.Add("Comment");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].CellAppearance.Image = Properties.Resources.History;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].Header.Fixed = true;
                grdList.DisplayLayout.Bands[0].Columns["Equipment"].Header.Fixed = true;                
                grdList.DisplayLayout.Bands[0].Columns["Event"].Header.Fixed = true;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].Width = 174;
                grdList.DisplayLayout.Bands[0].Columns["Equipment"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Event"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["System Code"].Width = 60;
                grdList.DisplayLayout.Bands[0].Columns["EAP"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Control Mode"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Primary State"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["State"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Mode"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["MDLN"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Soft Rev."].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Event Define"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["EAP Event"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Equipment Recipe"].Width = 140;
                grdList.DisplayLayout.Bands[0].Columns["User ID"].Width = 100;
                for (int i = 1; i <= 20; i++)
                {
                    grdList.DisplayLayout.Bands[0].Columns["Header " + i.ToString()].Width = 100;
                    grdList.DisplayLayout.Bands[0].Columns["Header " + i.ToString()].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    // --
                    grdList.DisplayLayout.Bands[0].Columns["Data " + i.ToString()].Width = 100;
                }
                grdList.DisplayLayout.Bands[0].Columns["Comment"].Width = 200;

                // --

                grdList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Override.FilterUIProvider = this.grdFilter;
                grdList.DisplayLayout.Override.TipStyleCell = TipStyle.Show;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Equipment"].Hidden = true;
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
                #region Init Data Table

                if (m_dtFraseqphis == null)
                {
                    m_dtFraseqphis = new DataTable();
                    foreach (string clmName in new string[] { "TRAN_TIME", "HIST_SEQ", "EQP_NAME", "SYSTEM", "EVENT_ID", "EAP", "CTRL_MODE", "PRI_STATE", "STATE", "EQP_MODE", "MDLN", "SOFTREV", "EVENT_DEFINE", "MC_EVENT_ID", "EQP_RCP_ID", "TRAN_USER_ID" })
                    {
                        // ***
                        // 2017.04.04 by spike.lee
                        // HIST_SEQ Sort를 숫자형으로 적용하도록 수정
                        // ***
                        if (clmName == "HIST_SEQ")
                        {
                            m_dtFraseqphis.Columns.Add(clmName, typeof(UInt64));
                        }
                        else
                        {
                            m_dtFraseqphis.Columns.Add(clmName, typeof(string));
                        }
                    }
                    // --
                    for (int i = 1; i <= 20; i++)
                    {
                        foreach (string clmName in new string[] { "EVT_H", "EVT_D" })
                        {
                            m_dtFraseqphis.Columns.Add(string.Format("{0}_{1}", clmName, i.ToString()), typeof(string));
                        }
                    }
                    // --
                    m_dtFraseqphis.Columns.Add("TRAN_COMMENT", typeof(string));
                }
                m_dtFraseqphis.Rows.Clear();

                // --

                if (m_dtFsyseqpevt == null)
                {
                    m_dtFsyseqpevt = new DataTable();
                    foreach (string clmName in new string[] { "EVENT_ID", "EVENT_DESC", "ISS_EVENT" })
                    {
                        m_dtFsyseqpevt.Columns.Add(clmName, typeof(string));
                    }
                }
                m_dtFsyseqpevt.Rows.Clear();

                #endregion

                // --

                initPropOfEquipmentHistory();

                // --

                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdList.endUpdate();

                // --

                refreshTotal();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {
                           
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void validationInputCondition(
            )
        {
            FSqlParams fSqlParams = null;
            string fromDateTime = string.Empty;
            string toDateTime = string.Empty;

            try
            {
                // ***
                // Date Time Validation
                // ***
                udtToTime.DateTime = udtToTime.ReadOnly ? DateTime.Now : udtToTime.DateTime;
                // --
                fromDateTime = udtFromTime.DateTime.ToString("yyyyMMddHHmmss000");
                toDateTime = udtToTime.DateTime.ToString("yyyyMMddHHmmss999");

                // --

                if (FCommon.convertStringToDateTime(toDateTime).Subtract(FCommon.convertStringToDateTime(fromDateTime)).TotalMilliseconds < 0)
                {
                    if (udtToTime.ReadOnly)
                    {
                        udtFromTime.Focus();
                    }
                    else
                    {
                        udtToTime.Focus();
                    }
                    // --
                    FDebug.throwFException(fUIWizard.generateMessage("E0015", new object[] { "Start and End Time" }));
                }

                // --

                // ***
                // Equipment Validation
                // ***
                if (txtEqpName.Text == string.Empty)
                {
                    txtEqpName.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Equipment" }));
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eqp_name", txtEqpName.Text);
                // --
                using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EquipmentHistory", "HasEquipment", fSqlParams, false))
                {
                    if (dt.Rows.Count == 0)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0010", new object[] { "Equipment" }));
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void attach(
            string eqpName
            )
        {
            try
            {
                txtEqpName.Text = eqpName;

                // --

                procMenuRefresh();

                // --

                udtFromTime.Focus();
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

        private void initPropOfEquipmentHistory(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropEquipmentHistory(m_fAdmCore, pgdProp);
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

        public void request(
            )
        {
            try
            {
                if (bwRequest.IsBusy)
                {
                    return;
                }

                // --

                bwRequest.RunWorkerAsync();
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

        private void doCollect(
            BackgroundWorker worker
            )
        {
            FSqlParams fSqlParams = null;
            int nextRowNumber = 0;
            int procCount = 0;

            try
            {
                // ***
                // 시작 보고
                // ***
                worker.ReportProgress(0);

                // --

                // ***
                // Search Equipment Events Definition
                // ***
                nextRowNumber = 0;
                // --
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Common", "EventSearch", "SearchEquipmentEventAll", fSqlParams, false, ref nextRowNumber))
                    {
                        dt.AsEnumerable().Take(dt.Rows.Count).CopyToDataTable(m_dtFsyseqpevt, LoadOption.OverwriteChanges);
                    }
                }
                while (nextRowNumber >= 0);

                // --

                // ***
                // Search Equipment Events
                // ***
                foreach (string[] reqTimes in m_lstReqTimes)
                {
                    if (worker.CancellationPending)
                    {
                        break;
                    }

                    // --

                    procCount++;
                    nextRowNumber = 0;
                    // --
                    fSqlParams = new FSqlParams();
                    fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                    fSqlParams.add("eqp_name", txtEqpName.Text);
                    fSqlParams.add("tran_from_time", reqTimes[0]);
                    fSqlParams.add("tran_to_time", reqTimes[1]);
                    // --
                    do
                    {
                        using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EquipmentHistory", "SearchEquipmentHistory", fSqlParams, false, ref nextRowNumber))
                        {
                            dt.AsEnumerable().Take(dt.Rows.Count).CopyToDataTable(m_dtFraseqphis, LoadOption.OverwriteChanges);
                        }
                        // --
                        worker.ReportProgress(procCount);
                    }
                    while (nextRowNumber >= 0);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshGridOfHistory(
             )
        {
            object[] cellValues = null;
            int rowIndex = 0;
            bool validDataField = false;
            string header = string.Empty;
            string data = string.Empty;

            try
            {
                grdList.beginUpdate(false);

                // --

                m_dtFraseqphis.DefaultView.Sort = "HIST_SEQ ASC";
                foreach (DataRow r in m_dtFraseqphis.DefaultView.ToTable().Rows)
                {
                    validDataField = true;
                    for (int i = 1; i <= 20; i++)
                    {
                        header = r["EVT_H_" + i.ToString()].ToString();
                        data = r["EVT_D_" + i.ToString()].ToString();
                        // --
                        if (header == string.Empty)
                        {
                            break;
                        }
                        if (data == string.Empty)
                        {
                            validDataField = false;
                            break;
                        }
                    }

                    // --

                    cellValues = new object[] {
                        FDataConvert.defaultDataTimeFormating(r["TRAN_TIME"].ToString()),
			            r["EQP_NAME"].ToString(),			            
                        r["EVENT_ID"].ToString(),
                        r["SYSTEM"].ToString(),
                        r["EAP"].ToString(),
                        r["CTRL_MODE"].ToString(),
                        r["PRI_STATE"].ToString(),
                        r["STATE"].ToString(),
                        r["EQP_MODE"].ToString(),
                        r["MDLN"].ToString(),
                        r["SOFTREV"].ToString(),
                        r["EVENT_DEFINE"].ToString(),
                        r["MC_EVENT_ID"].ToString(),  
                        r["EQP_RCP_ID"].ToString(),
                        r["TRAN_USER_ID"].ToString(),
                        r["EVT_H_1"].ToString(),
                        r["EVT_D_1"].ToString(),
                        r["EVT_H_2"].ToString(),
                        r["EVT_D_2"].ToString(),
                        r["EVT_H_3"].ToString(),
                        r["EVT_D_3"].ToString(),
                        r["EVT_H_4"].ToString(),
                        r["EVT_D_4"].ToString(),
                        r["EVT_H_5"].ToString(),
                        r["EVT_D_5"].ToString(),
                        r["EVT_H_6"].ToString(),
                        r["EVT_D_6"].ToString(),            
                        r["EVT_H_7"].ToString(),
                        r["EVT_D_7"].ToString(),   
                        r["EVT_H_8"].ToString(),
                        r["EVT_D_8"].ToString(),     
                        r["EVT_H_9"].ToString(),
                        r["EVT_D_9"].ToString(),
                        r["EVT_H_10"].ToString(),
                        r["EVT_D_10"].ToString(),
                        r["EVT_H_11"].ToString(),
                        r["EVT_D_11"].ToString(),
                        r["EVT_H_12"].ToString(),
                        r["EVT_D_12"].ToString(),
                        r["EVT_H_13"].ToString(),
                        r["EVT_D_13"].ToString(),
                        r["EVT_H_14"].ToString(),
                        r["EVT_D_14"].ToString(),
                        r["EVT_H_15"].ToString(),
                        r["EVT_D_15"].ToString(),
                        r["EVT_H_16"].ToString(),
                        r["EVT_D_16"].ToString(),
                        r["EVT_H_17"].ToString(),
                        r["EVT_D_17"].ToString(),
                        r["EVT_H_18"].ToString(),
                        r["EVT_D_18"].ToString(),
                        r["EVT_H_19"].ToString(),
                        r["EVT_D_19"].ToString(),
                        r["EVT_H_20"].ToString(),
                        r["EVT_D_20"].ToString(),
                        r["TRAN_COMMENT"].ToString() 
                        };
                    // --
                    rowIndex = grdList.appendDataRow(generateKey(new string[] { r["EQP_NAME"].ToString(), r["HIST_SEQ"].ToString()} ), cellValues).Index;
                    grdList.Rows[rowIndex].Tag = r;
                    
                    // --

                    m_dtFsyseqpevt.DefaultView.RowFilter = string.Format("EVENT_ID = '{0}'", r["EVENT_ID"].ToString());
                    if (m_dtFsyseqpevt.DefaultView.ToTable().Rows.Count > 0)
                    {
                        grdList.Rows[rowIndex].Cells["Event"].ToolTipText = m_dtFsyseqpevt.DefaultView.ToTable().Rows[0]["EVENT_DESC"].ToString();
                        // --
                        if (m_dtFsyseqpevt.DefaultView.ToTable().Rows[0]["ISS_EVENT"].ToString() == FYesNo.Yes.ToString())
                        {
                            grdList.Rows[rowIndex].Appearance.BackColor = Color.FromArgb(255, 221, 211);
                        }                        
                    }
                    // --
                    if (!validDataField)
                    {
                        grdList.Rows[rowIndex].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    }
                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.Rows.Count > 0)
                {
                    if (m_beforeKey != string.Empty)
                    {
                        grdList.activateDataRow(m_beforeKey);
                    }
                    if (grdList.activeDataRow == null)
                    {
                        grdList.ActiveRow = grdList.Rows[grdList.Rows.Count - 1];
                    }
                }

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                refreshTotal();
                // --
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshTotal(
            )
        {
            try
            {
                lblTotal.Text = grdList.Rows.VisibleRowCount.ToString("#,##0") + " / " + grdList.Rows.Count.ToString("#,##0");
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

        private void procMenuRefresh(
            )
        {
            try
            {
                m_beforeKey = grdList.activeDataRowKey;

                // --

                clear();

                // --

                validationInputCondition();

                // --

                m_lstReqTimes = FCommon.generateRequestTimes(
                    FCommon.convertStringToDateTime(udtFromTime.DateTime.ToString("yyyyMMddHHmmss000")),
                    FCommon.convertStringToDateTime(udtToTime.DateTime.ToString("yyyyMMddHHmmss999"))
                    );

                // --

                m_fInqProgress.ReqCount = m_lstReqTimes.Count;
                m_fInqProgress.StartPosition = FormStartPosition.CenterParent;
                m_fInqProgress.ShowDialog(this);
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

        private void procMenuExport(            
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_EquipmentHistory_" + (txtEqpName.Text == string.Empty ? "All" : txtEqpName.Text) + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export Equipment History to Excel";
                sfd.Filter = "Excel Files | *.xlsx";
                sfd.DefaultExt = "xlsx";
                sfd.InitialDirectory = m_fAdmCore.fOption.recentExportPath;
                sfd.FileName = fileName;
                // --
                if (sfd.ShowDialog(m_fAdmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                // --

                fileName = sfd.FileName;

                // --

                fExcelExp = new FExcelExporter2(fileName, m_fAdmCore.fUIWizard.fontName, 9);
                fExcelSht = fExcelExp.addExcelSheet("Equipment History");

                // --

                // ***
                // Title write
                // ***
                rowIndex = 0;
                fExcelSht.writeTitle(this.Text, rowIndex, 0);

                // --

                // ***
                // Input Condition (입력 조건) Write
                // ***
                rowIndex = 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Input Condition") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblFromTime.Text, udtFromTime.Text, rowIndex, 0);
                fExcelSht.writeCondition(lblToTime.Text, udtToTime.Text, rowIndex, 2);
                fExcelSht.writeCondition(lblEqpName.Text, txtEqpName.Text, rowIndex, 4);

                // --

                // ***
                // Equipment History Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Equipment History") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdList, rowIndex, 0);
                // --
                rowIndex += 1;
                fExcelSht.writeText("Total Count: " + grdList.Rows.Count.ToString(), rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                                
                // --

                // ***
                // Create Time Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("Create Time: " + FDataConvert.defaultNowDateTimeToString(), rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);

                // --

                fExcelExp.save();

                // --

                // ***
                // Last Excel Export Path 저장
                // ***
                m_fAdmCore.fOption.recentExportPath = Path.GetDirectoryName(fileName);

                // --

                // ***
                // Excel Open
                // ***
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0012"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fExcelExp != null)
                {
                    fExcelExp.Dispose();
                    fExcelExp = null;
                }

                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }

                sfd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private string generateKey(
            string[] items
            )
        {
            try
            {
                return string.Join(new string(new char[] { FConstants.KeySeparator }), items);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FEquipmentHistory Form Event Handler

        private void FEquipmentHistory_Load(
            object sender, 
            EventArgs e
            )
        {
            DateTime dateTime;

            try
            {
                FCursor.waitCursor();

                // --

                dateTime = DateTime.Now;
                // --
                udtFromTime.DateTime = DateTime.Parse(dateTime.AddDays(-m_fAdmCore.fOption.historySearchPeriod).ToString("yyyy-MM-dd") + " 00:00:00.000");
                udtToTime.DateTime = dateTime;
                ((StateEditorButton)udtToTime.ButtonsLeft[0]).Checked = false;

                // --

                m_fInqProgress = new FInquiryProgress(m_fAdmCore, this);
                m_fInqProgress.Canceled += new EventHandler<EventArgs>(fInqProgress_Canceled);

                // --

                designGridOfHistory();
                initPropOfEquipmentHistory();

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

        private void FEquipmentHistory_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fInqProgress != null)
                {
                    m_fInqProgress.Canceled -= new EventHandler<EventArgs>(fInqProgress_Canceled);
                    // --
                    m_fInqProgress.Dispose();
                    m_fInqProgress = null;
                }

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

        private void FEquipmentHistory_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                udtFromTime.Focus();
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

        private void FEquipmentHistory_KeyDown(
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
                    procMenuRefresh();
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

                if (e.Tool.Key == FMenuKey.MenuEqhRefresh)
                {
                    procMenuRefresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuEqhExport)
                {
                    procMenuExport();
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

        #region udtFromTime Control Event Handler

        private void udtFromTime_ValueChanged(
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

        #region udtToTime Control Event Handler

        private void udtToTime_AfterEditorButtonCheckStateChanged(
            object sender,
            Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (((StateEditorButton)e.Button).Checked)
                {
                    udtToTime.ReadOnly = false;
                    // --
                    udtToTime.Appearance.BackColor = Color.White;
                    udtToTime.Appearance.ForeColor = Color.Black;
                    // --
                    udtToTime.ButtonsLeft[0].Appearance.BorderColor = Color.White;
                    udtToTime.ButtonsLeft[0].Appearance.BackColor = Color.White;
                    // --
                    udtToTime.ButtonAppearance.BorderColor = Color.White;
                    udtToTime.ButtonAppearance.BackColor = Color.White;
                    // --
                    udtToTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59.999");
                }
                else
                {
                    udtToTime.ReadOnly = true;
                    // --
                    udtToTime.Appearance.BackColor = Color.WhiteSmoke;
                    udtToTime.Appearance.ForeColor = SystemColors.ControlDarkDark;
                    // --
                    udtToTime.ButtonsLeft[0].Appearance.BorderColor = Color.WhiteSmoke;
                    udtToTime.ButtonsLeft[0].Appearance.BackColor = Color.WhiteSmoke;
                    // --
                    udtToTime.ButtonAppearance.BorderColor = Color.WhiteSmoke;
                    udtToTime.ButtonAppearance.BackColor = Color.WhiteSmoke;
                    udtToTime.ButtonAppearance.BackColorDisabled = Color.WhiteSmoke;
                    udtToTime.ButtonAppearance.ForeColorDisabled = Color.DimGray;
                    // --
                    udtToTime.Value = DateTime.Now;
                }

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

        //------------------------------------------------------------------------------------------------------------------------

        private void udtToTime_ValueChanged(
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

        #region txtEqpName Control Event Handler

        private void txtEqpName_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FEquipmentSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FEquipmentSelector(m_fAdmCore, txtEqpName.Text, "");
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtEqpName.Text = fDialog.selectedEqpName;
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

        private void txtEqpName_ValueChanged(
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

        #region grdList Control Event Handler

        private void grdList_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                pgdProp.selectedObject = new FPropEquipmentHistory(m_fAdmCore, pgdProp, (DataRow)grdList.ActiveRow.Tag);
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

        private void grdList_AfterRowFilterChanged(
            object sender,
            AfterRowFilterChangedEventArgs e
            )
        {
            int activateIndex = -1;

            try
            {
                FCursor.waitCursor();

                // --

                initPropOfEquipmentHistory();
                if (e.Rows.VisibleRowCount == 0)
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                // --

                grdList.Selected.Rows.Clear();
                foreach (UltraGridRow r in e.Rows.GetFilteredInNonGroupByRows())
                {
                    if (r == grdList.ActiveRow)
                    {
                        activateIndex = r.VisibleIndex;
                        break;
                    }
                }
                // --
                if (activateIndex == -1)
                {
                    activateIndex = e.Rows.VisibleRowCount - 1;
                }
                grdList.ActiveRow = e.Rows.GetRowAtVisibleIndex(activateIndex);
                grdList.DisplayLayout.RowScrollRegions[0].ScrollRowIntoView(grdList.ActiveRow);

                // --

                grdList.endUpdate();

                // --

                refreshTotal();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstToolbar Control Event Handler

        private void rstToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdList.searchGridRow(e.searchWord))
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

        #region fInqProgress Control Event Handler

        private void fInqProgress_Canceled(
            object sender,
            EventArgs e
            )
        {
            try
            {
                if (bwRequest.WorkerSupportsCancellation)
                {
                    bwRequest.CancelAsync();
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

        #region bwRequest Control Event Handler

        private void bwRequest_DoWork(
            object sender,
            DoWorkEventArgs e
            )
        {
            try
            {
                doCollect((BackgroundWorker)sender);
            }
            catch (Exception ex)
            {
                this.Invoke(
                    new Action(() => { FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer); })
                    );
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void bwRequest_ProgressChanged(
            object sender,
            ProgressChangedEventArgs e
            )
        {
            try
            {
                if (!bwRequest.CancellationPending)
                {
                    m_fInqProgress.changedProgress(e.ProgressPercentage, m_dtFraseqphis.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                if (bwRequest.WorkerSupportsCancellation)
                {
                    bwRequest.CancelAsync();
                }
                // -
                this.Invoke(
                    new Action(() => { FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer); })
                    );
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void bwRequest_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e
            )
        {
            try
            {
                m_fInqProgress.Close();

                // --

                if (e.Error != null)
                {
                    throw e.Error;
                }

                // --

                refreshGridOfHistory();
            }
            catch (Exception ex)
            {
                this.Invoke(
                    new Action(() => { FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer); })
                    );
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
