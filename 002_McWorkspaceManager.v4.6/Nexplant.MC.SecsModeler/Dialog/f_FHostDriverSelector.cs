﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FHostDriverSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.24
--  Description     : FAMate SECS Modeler Host Driver Selector Form Class 
--  History         : Created by spike.lee at 2011.03.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.SecsModeler
{
    public partial class FHostDriverSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FHostDevice m_fHdv = null;
        private string m_selectedFileName = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostDriverSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostDriverSelector(
            FSsmCore fSsmCore,
            FHostDevice fHdv
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fHdv = fHdv;
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
                    m_fSsmCore = null;
                    m_fHdv = null;                    
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string selectedFileName
        {
            get
            {
                try
                {
                    return m_selectedFileName;
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

        #region Methods

        private void designGridOfHostDriver(
           )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdHostDriver.dataSource;
                // --
                uds.Band.Columns.Add("File Name");
                uds.Band.Columns.Add("Description");

                // --

                grdHostDriver.DisplayLayout.Bands[0].Columns["File Name"].CellAppearance.Image = Properties.Resources.File_Dll;
                // --
                grdHostDriver.DisplayLayout.Bands[0].Columns["File Name"].Width = 200;
                grdHostDriver.DisplayLayout.Bands[0].Columns["Description"].Width = 250;
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

        private void refreshGridOfHostDriver(
            )
        {
            const string SearchPattern = "*.dll";

            // -- 

            string[] fileNameList = null;
            FIHostDriver fHostDriver = null;
            object[] cellValues = null;
            string activeDataRowKey = string.Empty;            

            try
            {
                grdHostDriver.beginUpdate();

                // --

                grdHostDriver.removeAllDataRow();
                btnOk.Enabled = false;

                // --

                fileNameList = Directory.GetFiles(m_fSsmCore.fSsmFileInfo.fSecsDriver.hostDriverDirectory, SearchPattern);
                foreach (string fileName in fileNameList)
                {
                    fHostDriver = m_fHdv.createHostDriver(fileName);
                    if (fHostDriver == null)
                    {
                        continue;
                    }

                    // --
                    cellValues = new object[] {
                        Path.GetFileName(fileName),
                        fHostDriver.description
                    };
                    grdHostDriver.appendDataRow(fileName, cellValues);

                    if ((string)cellValues[0] == m_fHdv.driver)
                    {
                        activeDataRowKey = fileName;
                    }
                }                

                // --

                grdHostDriver.endUpdate();

                // --

                grdHostDriver.DisplayLayout.Bands[0].SortedColumns.Add("File Name", false);
                if (grdHostDriver.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdHostDriver.ActiveRow = grdHostDriver.Rows[0];
                    }
                    else
                    {
                        grdHostDriver.activateDataRow(activeDataRowKey);
                    }
                    btnOk.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                grdHostDriver.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fHostDriver = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void selectFileName(
            )
        {
            try
            {
                m_selectedFileName = grdHostDriver.activeDataRowKey;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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

        #region FHostDriverSelector Form Event Handler

        private void FHostDriverSelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfHostDriver();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FHostDriverSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfHostDriver();
                if (m_fHdv.driver != string.Empty)
                {
                    btnReset.Enabled = true;
                }                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdHostDriver Control Event Handler

        private void grdHostDriver_DoubleClickRow(
            object sender,
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                selectFileName();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
            try
            {
                FCursor.waitCursor();

                // --

                selectFileName();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnReset Control Event Handler

        private void btnReset_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_selectedFileName = string.Empty;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
