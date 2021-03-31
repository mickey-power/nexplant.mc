﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FValueTransformationViewer.cs
--  Creator         : kitae. Kim
--  Create Date     : 2011.10.20
--  Description     : FAMate OPC Modeler Value Transformation Viewer Form Class 
--  History         : Created by kitae. Kim at 2011.10.20
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
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.OpcModeler
{
    public partial class FValueTransformationViewer : Nexplant.MC.Core.FaUIs.FBaseStandardForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FFormat m_fFormat = FFormat.Ascii;
        private FIValueTransformerLog m_fValueTransformerLog = null;
        // --
        private int m_keyIndex = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FValueTransformationViewer()
        {
            InitializeComponent();
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public FValueTransformationViewer(
            FOpmCore fOpmCore,
            FFormat fFormat,
            FIValueTransformerLog fValueTransformerLog
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
            m_fFormat = fFormat;
            m_fValueTransformerLog = fValueTransformerLog;
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
                    m_fOpmCore = null;
                    m_fValueTransformerLog = null;
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

        private void disingGridOfValueFomula(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Key");
                uds.Band.Columns.Add("Index");
                uds.Band.Columns.Add("Value Formula");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Index"].CellAppearance.Image = Properties.Resources.ValueFormula;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Key"].Hidden = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Index"].Width = 60;
                grdList.DisplayLayout.Bands[0].Columns["Value Formula"].Width = 120;

                // --

                grdList.DisplayLayout.Override.HeaderClickAction -= Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
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

        private void refreshGridOfValueFormula(
            )
        {
            FIValueFormulaCollection fValueFormulaCollection = null;            
            FIValueFormula fValueFormula = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;

            try
            {
                grdList.beginUpdate();

                // --

                fValueFormulaCollection = m_fValueTransformerLog.fValueFormulaCollection;
                // --
                for(int i = 0; i< fValueFormulaCollection.count; i++)
                {
                    fValueFormula = fValueFormulaCollection[i];
                    // --
                    cellValues = new object[]
                    {
                        m_keyIndex.ToString(),                        
                        i.ToString(),
                        fValueFormula.ToString()
                    };
                    // --
                    dataRow = grdList.appendDataRow((string)cellValues[0], cellValues);
                    dataRow.Tag = fValueFormula;

                    // --
                    m_keyIndex++;
                }
                
                // --

                grdList.endUpdate();

                if (grdList.Rows.Count > 0)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fValueFormulaCollection = null;
                fValueFormula = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateValueFormulaIndex(
            )
        {
            try
            {
                grdList.beginUpdate();

                // --

                for (int i = 0; i < grdList.Rows.Count; i++)
                {
                    grdList.getDataRow(i).SetCellValue("Index", i.ToString());
                }

                // --

                grdList.endUpdate();
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

        #region FValueTransformationViewer Form Event Handler

        private void FValueTransformationViewer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // ---

                disingGridOfValueFomula();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FValueTransformationViewer_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfValueFormula();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FValueTransformationViewer_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
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
}   // Namespcae end
