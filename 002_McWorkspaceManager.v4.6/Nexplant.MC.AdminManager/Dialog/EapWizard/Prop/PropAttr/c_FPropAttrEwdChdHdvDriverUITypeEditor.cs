﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAttrEwdChdHdvDriverUITypeEditor.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2015.11.11
--  Description     : FAMate Admin Manager Host Device Host Driver Setup for Custom Host Driver UI Type Editor Property Class 
--  History         : Created by Jeff.Kim at 2015.11.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.AdminManager
{
    public class FPropAttrEwdChdHdvDriverUITypeEditor : UITypeEditor
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

        public override object  EditValue(
            ITypeDescriptorContext context, 
            IServiceProvider provider, 
            object value
            )
        {
            FPropEwdChdHdv fPropEwdHdv = null;
            FOpcHostDriverSelector dialog = null;

            try
            {
                fPropEwdHdv = (FPropEwdChdHdv)((FDynPropGridTypeDescriptor)context.Instance).GetPropertyOwner(null);
                
                // --

                dialog = new FOpcHostDriverSelector(fPropEwdHdv.mainObject, fPropEwdHdv.fHostDevice);
                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return string.Empty;
                }
                
                // --

                fPropEwdHdv.setHostDriver(dialog.selectedFileName);
                
                // --

                return string.Empty;
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
                fPropEwdHdv = null;
            }
 	        return base.EditValue(context, provider, value);
        }        
    
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
