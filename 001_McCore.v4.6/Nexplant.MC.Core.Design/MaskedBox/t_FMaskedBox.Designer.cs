﻿namespace Nexplant.MC.Core.FaUIs
{
    partial class FMaskedBox
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();     
       
            // --

            this.Font = new System.Drawing.Font("Verdana", 9F);
            // --
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            // --
            this.AutoSize = false;
            this.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Height = 21;
        }

        #endregion

    }
}
