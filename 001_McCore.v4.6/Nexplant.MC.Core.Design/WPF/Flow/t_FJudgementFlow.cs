﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FJudgementFlow.cs
--  Creator         : spike.lee
--  Create Date     : 2012.01.17
--  Description     : FAMate Core FaUIs Judgement Flow Control
--  History         : Created by spike.lee at 2012.01.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public partial class FJudgementFlow : FBaseFlowCtrl, FIFlowCtrl
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_key = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FJudgementFlow(
            )
            : this(Nexplant.MC.Core.Properties.Resources.not_defined)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FJudgementFlow(
            Image image
            )
            : base("JudgementFlow", image)
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FJudgementFlow(
            string key
            )
            : this(Nexplant.MC.Core.Properties.Resources.not_defined)
        {
            m_key = key;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FJudgementFlow(
            string key,
            Image image
            )
            : this(image)
        {
            m_key = key;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FJudgementFlow(
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
                    return FFlowCtrlType.Judgement;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FFlowCtrlType.Judgement;
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

        //------------------------------------------------------------------------------------------------------------------------

        public System.Windows.Controls.Canvas symbol
        {
            get
            {
                System.Windows.Controls.Canvas flowCanvas = null;
                System.Windows.Shapes.Polygon polygon = null;
                System.Windows.Media.PointCollection points = null;
                System.Windows.Style oldStyle = null;

                try
                {
                    applyWindowSize();

                    // --

                    flowCanvas = new System.Windows.Controls.Canvas();
                    polygon = new System.Windows.Shapes.Polygon();
                    polygon.Stroke = System.Windows.Media.Brushes.Blue;
                    polygon.StrokeThickness = strokeThickness;
                    // --
                    points = new System.Windows.Media.PointCollection();
                    points.Add(new System.Windows.Point(leftCenter + additionalX, verticalMargin + additionalY));
                    points.Add(new System.Windows.Point(rightCenter - additionalX, verticalMargin + additionalY));
                    points.Add(new System.Windows.Point(rightCenter, middlePosition));
                    points.Add(new System.Windows.Point(rightCenter - additionalX, height - verticalMargin - additionalY));
                    points.Add(new System.Windows.Point(leftCenter + additionalX, height - verticalMargin - additionalY));
                    points.Add(new System.Windows.Point(leftCenter, middlePosition));
                    polygon.Points = points;
                    polygon.Fill = defaultBgColor;
                    // -- 
                    flowCanvas.Children.Add(polygon);
                    // --
                    
                    oldStyle = panel.Style;
                    panel.MouseDown -= FBaseFlowCtrl_MouseDown;
                    // --                    
                    panel = drawImageAndText(FFlowCtrlType.Judgement, text);
                    panel.Style = oldStyle;
                    panel.MouseDown += FBaseFlowCtrl_MouseDown;

                    // -- 

                    flowCanvas.Children.Add(eqBaseLine);
                    flowCanvas.Children.Add(eapBaseLine);
                    flowCanvas.Children.Add(hostBaseLine);
                    flowCanvas.Children.Add(panel);

                    // -- 

                    System.Windows.Controls.StackPanel.SetZIndex(polygon, 100);
                    System.Windows.Controls.StackPanel.SetZIndex(panel, 101);

                    // -- 

                    return flowCanvas;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    points = null;
                    polygon = null;
                    flowCanvas = null;
                }
                return null;
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
                panel = new System.Windows.Controls.StackPanel();
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
                if (panel != null)
                {
                    panel.MouseDown -= FBaseFlowCtrl_MouseDown;
                    panel = null;
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
}   // Namespace end
