﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : i_FIPrecondition.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaOpcDriver Precondition Interface
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public interface FIPrecondition
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        FFormat fFormat
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        FIPreconditionValueCollection fPreconditionValueCollection
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        bool canInsertBeforeValue
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        bool canInsertAfterValue
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        bool canAppendValue
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        bool canRemoveValue
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        bool canRemoveAllValue
        {
            get;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        string insertBeforeStringValue(
            int index,
            string value
            );

        //------------------------------------------------------------------------------------------------------------------------

        object insertBeforeValue(
            int index,
            object value
            );

        //------------------------------------------------------------------------------------------------------------------------

        string insertAfterStringValue(
            int index,
            string value
            );

        //------------------------------------------------------------------------------------------------------------------------

        object insertAfterValue(
            int index,
            object value
            );

        //------------------------------------------------------------------------------------------------------------------------

        string appendStringValue(
            string value
            );

        //------------------------------------------------------------------------------------------------------------------------

        object appendValue(
            object value
            );

        //------------------------------------------------------------------------------------------------------------------------

        string replaceStringValue(
            int index,
            string value
            );

        //------------------------------------------------------------------------------------------------------------------------

        object replaceValue(
            int index,
            object value
            );

        //------------------------------------------------------------------------------------------------------------------------

        string removeStringValue(
            int index
            );

        //------------------------------------------------------------------------------------------------------------------------

        object removeValue(
            int index
            );

        //------------------------------------------------------------------------------------------------------------------------

        void removeAllValue(
            );

        //------------------------------------------------------------------------------------------------------------------------

        string moveUpStringValue(
            int index
            );

        //------------------------------------------------------------------------------------------------------------------------

        object moveUpValue(
            int index
            );

        //------------------------------------------------------------------------------------------------------------------------

        string moveDownStringValue(
            int index
            );

        //------------------------------------------------------------------------------------------------------------------------

        object moveDownValue(
            int index
            );

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Interface end
}   // Class end
