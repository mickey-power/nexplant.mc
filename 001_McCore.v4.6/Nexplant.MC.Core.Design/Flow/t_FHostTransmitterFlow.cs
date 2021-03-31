﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FHostTransmitterFlow.cs
--  Creator         : spike.lee
--  Create Date     : 2011.07.20
--  Description     : FAMate Core FaUIs Host Transmitter Flow Control
--  History         : Created by spike.lee at 2011.07.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Nexplant.MC.Core.FaCommon;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FHostTransmitterFlow : FBaseFlowCtrl, FIFlowCtrl
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_key = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostTransmitterFlow(
            )
            : base("HostTransmitterFlow")
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostTransmitterFlow(
            string key
            )
            : this()
        {
            m_key = key;
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
                }

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FFlowCtrlType fFlowCtrlType
        {
            get
            {
                try
                {
                    return FFlowCtrlType.HostTransmitter;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FFlowCtrlType.HostTransmitter;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string key
        {
            get
            {
                try
                {
                    return m_key;
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

        private void init(
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

        #region FHostTransmitterFlow Control Event Handler

        private void FHostTransmitterFlow_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FHostTransmitterFlow", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region pnlMain Control Event Handler

        private void pnlMain_PaintClient(
            object sender, 
            PaintEventArgs e
            )
        {
            Pen pen = null;
            int x1 = 0;
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;

            try
            {
                if (!this.IsHandleCreated)
                {
                    return;
                }

                // --

                pen = new Pen(Color.SeaGreen, 3);

                // ***
                // Transmitter Arrow
                // ***
                x1 = pnlMain.Width / 2 + 10;
                x2 = pnlMain.Width - 10;
                y1 = 25;
                y2 = 25;                
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);

                pen.Dispose();
                pen = null;

                // --

                pen = new Pen(Color.SeaGreen, 5);
                pen.EndCap = LineCap.ArrowAnchor;          
      
                x2 = pnlMain.Width - 10;
                x1 = x2 - 5;
                e.Graphics.DrawLine(pen, x1, y1, x2, y2);

                pen.Dispose();
                pen = null;

                // --

                grdContents.Left = pnlMain.Width / 2 + 19;
                grdContents.Top = 4;
                grdContents.Width = pnlMain.Width / 2 - 39;
                grdContents.Height = 20;
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FHostTransmitterFlow", ex, null);
            }
            finally
            {
                if (pen != null)
                {
                    pen.Dispose();
                    pen = null;
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
