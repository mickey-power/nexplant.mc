﻿namespace Nexplant.MC.AdminManager
{
    partial class FEapNameSelector
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            // ***
            // myDispose
            // ***
            myDispose(disposing);

            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            this.grdEqpList = new Nexplant.MC.Core.FaUIs.FGrid();
            this.rstEqp = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnReset = new Nexplant.MC.Core.FaUIs.FButton();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEqpList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.grdEqpList);
            this.pnlDialogClient.Controls.Add(this.rstEqp);
            this.pnlDialogClient.Location = new System.Drawing.Point(3, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(774, 362);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnReset);
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(779, 415);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnOk, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnReset, 0);
            // 
            // grdEqpList
            // 
            this.grdEqpList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.grdEqpList.DisplayLayout.Appearance = appearance1;
            this.grdEqpList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdEqpList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdEqpList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdEqpList.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdEqpList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grdEqpList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdEqpList.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grdEqpList.DisplayLayout.MaxColScrollRegions = 1;
            this.grdEqpList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdEqpList.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance6.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.grdEqpList.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.grdEqpList.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdEqpList.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdEqpList.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdEqpList.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdEqpList.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdEqpList.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdEqpList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdEqpList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdEqpList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdEqpList.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdEqpList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grdEqpList.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.grdEqpList.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdEqpList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdEqpList.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdEqpList.DisplayLayout.Override.CellPadding = 0;
            this.grdEqpList.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grdEqpList.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BackColor2 = System.Drawing.Color.Lavender;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Center";
            appearance10.TextVAlignAsString = "Middle";
            this.grdEqpList.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grdEqpList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdEqpList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdEqpList.DisplayLayout.Override.RowAppearance = appearance8;
            this.grdEqpList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdEqpList.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdEqpList.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance11.BackColor2 = System.Drawing.Color.LightGray;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.grdEqpList.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.grdEqpList.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdEqpList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdEqpList.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdEqpList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdEqpList.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.grdEqpList.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdEqpList.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdEqpList.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdEqpList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdEqpList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdEqpList.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdEqpList.DisplayLayout.UseFixedHeaders = true;
            this.grdEqpList.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdEqpList.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdEqpList.Location = new System.Drawing.Point(2, 25);
            this.grdEqpList.multiSelected = true;
            this.grdEqpList.Name = "grdEqpList";
            this.grdEqpList.Size = new System.Drawing.Size(769, 334);
            this.grdEqpList.TabIndex = 6;
            this.grdEqpList.Text = "fGrid1";
            this.grdEqpList.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdEqpList.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdEqpList.valueCopyOfClickedCell = false;
            this.grdEqpList.AfterRowActivate += new System.EventHandler(this.grdEqpList_AfterRowActivate);
            this.grdEqpList.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdEqpList_DoubleClickRow);
            // 
            // rstEqp
            // 
            this.rstEqp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstEqp.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstEqp.Location = new System.Drawing.Point(2, 2);
            this.rstEqp.Name = "rstEqp";
            this.rstEqp.refreshEnabled = true;
            this.rstEqp.Size = new System.Drawing.Size(768, 21);
            this.rstEqp.TabIndex = 5;
            this.rstEqp.RefreshRequested += new Nexplant.MC.Core.FaUIs.FRefreshRequestedEventHandler(this.rstEqp_RefreshRequested);
            this.rstEqp.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstEqp_SearchRequested);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.Enabled = false;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(589, 380);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnCancel.Location = new System.Drawing.Point(681, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnReset.Enabled = false;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnReset.Location = new System.Drawing.Point(12, 380);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(86, 28);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset(&R)";
            this.btnReset.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // FEapNameSelector
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(779, 442);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FEapNameSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EAP Name Selector";
            this.Load += new System.EventHandler(this.FEapNameSelector_Load);
            this.Shown += new System.EventHandler(this.FEapNameSelector_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FEapNameSelector_KeyDown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEqpList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnReset;
        private Core.FaUIs.FRefreshAndSearchToolbar rstEqp;
        private Core.FaUIs.FGrid grdEqpList;


    }
}
