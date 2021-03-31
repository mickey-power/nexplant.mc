﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FValueEditor.cs
--  Creator         : kitae kim
--  Create Date     : 2011.08.10
--  Description     : FAMate Workspace Manager ValueEditor Form Class 
--  History         : Created by kitae kim at 2011.08.10
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.TcpModeler
{
    public partial class FValueEditor : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FTcmCore m_fTcmCore = null;
        private FIObject m_fObject = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FValueEditor(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FValueEditor(
            FTcmCore fTcmCore,            
            FIObject fObject
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
            m_fObject = fObject;
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
                    m_fTcmCore = null;
                    m_fObject = null;
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
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FValueEditor Form Event Handler

        private void FValueEditor_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                if (m_fObject.fObjectType == FObjectType.TcpItem)
                {
                    rtxValue.Text = ((FTcpItem)m_fObject).originalStringValue;
                }
                else if (m_fObject.fObjectType == FObjectType.HostItem)
                {
                    rtxValue.Text = ((FHostItem)m_fObject).originalStringValue;
                }
                else if (m_fObject.fObjectType == FObjectType.Data)
                {
                    rtxValue.Text = ((FData)m_fObject).originalStringValue;
                }
                else if (m_fObject.fObjectType == FObjectType.Environment)
                {
                    rtxValue.Text = ((FEnvironment)m_fObject).stringValue;
                }
                else if (m_fObject.fObjectType == FObjectType.Column)
                {
                    rtxValue.Text = ((FColumn)m_fObject).originalStringValue;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region  btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                
                if (m_fObject.fObjectType == FObjectType.TcpItem)
                {
                    ((FTcpItem)m_fObject).originalStringValue = rtxValue.Text;
                }
                else if (m_fObject.fObjectType == FObjectType.HostItem)
                {
                    ((FHostItem)m_fObject).originalStringValue = rtxValue.Text;
                }
                else if (m_fObject.fObjectType == FObjectType.Data)
                {
                    ((FData)m_fObject).originalStringValue = rtxValue.Text;
                }
                else if (m_fObject.fObjectType == FObjectType.Environment)
                {
                    ((FEnvironment)m_fObject).stringValue = rtxValue.Text;
                }
                else if (m_fObject.fObjectType == FObjectType.Column)
                {
                    ((FColumn)m_fObject).originalStringValue = rtxValue.Text;
                }

                // --

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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