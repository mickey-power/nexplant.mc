﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrSitlValueTransformerUITypeEditor.cs
--  Creator         : kitae
--  Create Date     : 2011.10.20
--  Description     : FAMate PLC Modeler Value Viewer UI Type Editor Property Class 
--  History         : Created by kitae at 2011.10.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing.Design;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager.FaOpcLogViewer
{
    public class FPropAttrValueViewerUITypeEditor : UITypeEditor
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override UITypeEditorEditStyle GetEditStyle(
            ITypeDescriptorContext context
            )
        {
            try
            {
                return UITypeEditorEditStyle.Modal;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {

            }
            return base.GetEditStyle(context);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override object EditValue(
            ITypeDescriptorContext context, 
            System.IServiceProvider provider, 
            object value
            )
        {
            FDynPropCusBase<FAdmCore> m_fProp = null;
            FValueViewer dialog = null;

            try
            {
                m_fProp = (FDynPropCusBase<FAdmCore>)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);

                // --

                dialog = new FValueViewer(m_fProp.mainObject, (string)value);
                dialog.ShowDialog();

                // --

                return value;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, null);
            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
            }
            return base.EditValue(context, provider, value);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
