﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : i_FIFlowCtrl.cs
--  Creator         : byjeon
--  Create Date     : 2012.10.15
--  Description     : FAMate Core FaSecsDriver WPF Flow Control(FSecsTriggerFlow, FSecsTransmitterFlow,
--                    FHostTriggerFlow, FHostTransmitterFlow, FCallbackFlow, FStopFlow, FBranchFlow)
--                    Object Interface
--  History         : Created by byjeon at 2012.10.15
----------------------------------------------------------------------------------------------------------*/
using System.Drawing;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public interface FIFlowCtrl
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        FFlowCtrlType fFlowCtrlType
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        string key
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        string text
        {
            get;
            set;
        }

        //------------------------------------------------------------------------------------------------------------------------

        Color fontColor
        {
            get;
            set;
        }

        //------------------------------------------------------------------------------------------------------------------------

        bool fontBold
        {
            get;
            set;
        }

        //------------------------------------------------------------------------------------------------------------------------

        Image image
        {
            get;
            set;
        }

        //------------------------------------------------------------------------------------------------------------------------

        bool isActive
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        FIFlowCtrl fPreviousSibling
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        FIFlowCtrl fNextSibling
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        object Tag
        {
            get;
            set;
        }

        //------------------------------------------------------------------------------------------------------------------------

        System.Windows.Controls.StackPanel panel
        {
            get;
            set;
        }

        //------------------------------------------------------------------------------------------------------------------------

        FFlowContainer fParent
        {
            get;
            set;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Interface end
}   // Namespace end