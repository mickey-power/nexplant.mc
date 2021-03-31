/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_ADMADS_TolComponentVerDataPush_Nrp.cs
--  Creator         : spike.lee
--  Create Date     : 2013.01.17
--  Description     : <Generated Class File Description>
--  History         : Created by spike.lee at 2013.01.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.AdminManager;

namespace Nexplant.MC.H101Interface
{
    internal partial class FADMADSCallback
    {

        //------------------------------------------------------------------------------------------------------------------------

        public override void ADMADS_TolComponentVerDataPush_Nrp(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInComVer = null;
            FMonitoringComponentVerDataReceivedEventArgs e = null;
            string type = string.Empty;
            string factory = string.Empty;
            string component = string.Empty;
            string componentVer = string.Empty;

            try
            {
                factory = fXmlNodeIn.get_elemVal(FADMADS_TolComponentVerDataPush_In.A_hFactory, FADMADS_TolComponentVerDataPush_In.D_hFactory);
                // --
                if (factory != m_fAdmCore.fOption.factory)
                {
                    return;
                }

                // --

                fXmlNodeInComVer = fXmlNodeIn.get_elem(FADMADS_TolComponentVerDataPush_In.FComponentVer.E_ComponentVer);
                type = fXmlNodeInComVer.get_elemVal(FADMADS_TolComponentVerDataPush_In.FComponentVer.A_MonDataType, FADMADS_TolComponentVerDataPush_In.FComponentVer.D_MonDataType);
                component = fXmlNodeInComVer.get_elemVal(FADMADS_TolComponentVerDataPush_In.FComponentVer.A_Name, FADMADS_TolComponentVerDataPush_In.FComponentVer.D_Name);
                componentVer = fXmlNodeInComVer.get_elemVal(FADMADS_TolComponentVerDataPush_In.FComponentVer.A_Version, FADMADS_TolComponentVerDataPush_In.FComponentVer.D_Version);

                // --

                e = new FMonitoringComponentVerDataReceivedEventArgs(
                    (FMonitoringDataType)Enum.Parse(typeof(FMonitoringDataType), type),
                    factory,
                    component,
                    int.Parse(componentVer),
                    fXmlNodeInComVer
                    );
                // --
                m_fAdmCore.onMonitoringComponentVerDataReceived(e);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fXmlNodeInComVer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
