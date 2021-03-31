﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropSdmrl.cs
--  Creator         : byJeon
--  Create Date     : 2011.10.18
--  Description     : FAMate SECS Modeler SECS Device Data Message Received Log Property Source Object Class 
--  History         : Created by byJeon at 2011.10.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager.FaSecsLogViewer
{
    public class FPropSdmrl : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryResult = "[01] Result";
        private const string CategoryGeneral = "[02] General";
        private const string CategoryFont = "[03] Font";
        private const string CategoryDevice = "[04] Device";
        private const string CategorySession = "[05] Session";
        private const string CategoryLength = "[06] Length";
        private const string CategoryHeader = "[07] Header";
        private const string CategoryReply = "[08] Reply";
        private const string CategoryUserTag = "[09] User Tag";

        // --

        private bool m_disposed = false;
        // --
        private FSecsDeviceDataMessageReceivedLog m_fSdmrl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropSdmrl(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            FSecsDeviceDataMessageReceivedLog fSdmrl
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_fSdmrl = fSdmrl;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropSdmrl(
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
                    // --
                    m_fSdmrl = null;
                }

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Result

        [Category(CategoryResult)]
        public string Time
        {
            get
            {
                try
                {
                    return m_fSdmrl.time;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryResult)]
        public FResultCode ResultCode
        {
            get
            {
                try
                {
                    return m_fSdmrl.fResultCode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FResultCode.Error;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryResult)]
        public string ResultMessage
        {
            get
            {
                try
                {
                    return m_fSdmrl.resultMessage;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region General

        [Category(CategoryGeneral)]
        public string Type
        {
            get
            {
                try
                {
                    return m_fSdmrl.fObjectLogType.ToString();
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }



        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string ID
        {
            get
            {
                try
                {
                    return m_fSdmrl.uniqueIdToString;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string Name
        {
            get
            {
                try
                {
                    return m_fSdmrl.name;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string Description
        {
            get
            {
                try
                {
                    return m_fSdmrl.description;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Font

        [Category(CategoryFont)]
        public Color FontColor
        {
            get
            {
                try
                {
                    return m_fSdmrl.fontColor;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return Color.Black;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFont)]
        public bool FontBold
        {
            get
            {
                try
                {
                    return m_fSdmrl.fontBold;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Device

        [Category(CategoryDevice)]
        public string DeviceId
        {
            get
            {
                try
                {
                    return m_fSdmrl.deviceUniqueIdToString;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryDevice)]
        public string DeviceName
        {
            get
            {
                try
                {
                    return m_fSdmrl.deviceName;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Session

        [Category(CategorySession)]
        public string SessionUniqueId
        {
            get
            {
                try
                {
                    return m_fSdmrl.sessionUniqueIdToString;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategorySession)]
        public string SessionName
        {
            get
            {
                try
                {
                    return m_fSdmrl.sessionName;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Length

        [Category(CategoryLength)]
        public long Length
        {
            get
            {
                try
                {
                    return m_fSdmrl.length;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }
        }

        #endregion
                
        //------------------------------------------------------------------------------------------------------------------------

        #region Header

        [Category(CategoryHeader)]
        public int SessionId
        {
            get
            {
                try
                {
                    return m_fSdmrl.sessionId;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryHeader)]
        public int Stream
        {
            get
            {
                try
                {
                    return m_fSdmrl.stream;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryHeader)]
        public int Function
        {
            get
            {
                try
                {
                    return m_fSdmrl.function;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryHeader)]
        public int Version
        {
            get
            {
                try
                {
                    return m_fSdmrl.version;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryHeader)]
        public bool WBit
        {
            get
            {
                try
                {
                    return m_fSdmrl.wBit;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryHeader)]
        public long SystemBytes
        {
            get
            {
                try
                {
                    return m_fSdmrl.systemBytes;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return 0;
            }
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Reply

        [Category(CategoryReply)]
        public bool AutoReply
        {
            get
            {
                try
                {
                    return m_fSdmrl.autoReply;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return false;
            }
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

        #region User Tag

        [Category(CategoryUserTag)]
        public string UserTag1
        {
            get
            {
                try
                {
                    return m_fSdmrl.userTag1;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryUserTag)]
        public string UserTag2
        {
            get
            {
                try
                {
                    return m_fSdmrl.userTag2;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }            
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryUserTag)]
        public string UserTag3
        {
            get
            {
                try
                {
                    return m_fSdmrl.userTag3;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryUserTag)]
        public string UserTag4
        {
            get
            {
                try
                {
                    return m_fSdmrl.userTag4;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryUserTag)]
        public string UserTag5
        {
            get
            {
                try
                {
                    return m_fSdmrl.userTag5;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        [Browsable(false)]
        public FSecsDeviceDataMessageReceivedLog fSecsDeviceDataMessageReceivedLog
        {
            get
            {
                try
                {
                    return m_fSdmrl;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

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
                base.fTypeDescriptor.properties["Time"].attributes.replace(new DisplayNameAttribute("Time"));
                base.fTypeDescriptor.properties["ResultCode"].attributes.replace(new DisplayNameAttribute("Result Code"));
                base.fTypeDescriptor.properties["ResultMessage"].attributes.replace(new DisplayNameAttribute("Result Message"));
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DisplayNameAttribute("Color"));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DisplayNameAttribute("Bold"));
                // --
                base.fTypeDescriptor.properties["DeviceId"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["DeviceName"].attributes.replace(new DisplayNameAttribute("Name"));
                // --
                base.fTypeDescriptor.properties["SessionUniqueId"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["SessionName"].attributes.replace(new DisplayNameAttribute("Name"));
                // --
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DisplayNameAttribute("Length"));
                // --
                base.fTypeDescriptor.properties["SessionId"].attributes.replace(new DisplayNameAttribute("Session ID"));
                base.fTypeDescriptor.properties["Stream"].attributes.replace(new DisplayNameAttribute("Stream"));
                base.fTypeDescriptor.properties["Function"].attributes.replace(new DisplayNameAttribute("Function"));
                base.fTypeDescriptor.properties["Version"].attributes.replace(new DisplayNameAttribute("Version"));
                base.fTypeDescriptor.properties["WBit"].attributes.replace(new DisplayNameAttribute("W-Bit"));
                base.fTypeDescriptor.properties["SystemBytes"].attributes.replace(new DisplayNameAttribute("System Bytes"));
                // --
                base.fTypeDescriptor.properties["AutoReply"].attributes.replace(new DisplayNameAttribute("Auto Reply"));
                // --   
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DisplayNameAttribute("User Tag1"));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DisplayNameAttribute("User Tag2"));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DisplayNameAttribute("User Tag3"));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DisplayNameAttribute("User Tag4"));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DisplayNameAttribute("User Tag5"));

                // --

                base.fTypeDescriptor.properties["Time"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.time));
                base.fTypeDescriptor.properties["ResultCode"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.fResultCode));
                base.fTypeDescriptor.properties["ResultMessage"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.resultMessage));
                // --
                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.fObjectLogType.ToString()));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.uniqueIdToString));
                base.fTypeDescriptor.properties["Name"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.name));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.description));
                // --
                base.fTypeDescriptor.properties["FontColor"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.fontColor));
                base.fTypeDescriptor.properties["FontBold"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.fontBold));
                // --
                base.fTypeDescriptor.properties["DeviceId"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.deviceUniqueIdToString));
                base.fTypeDescriptor.properties["DeviceName"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.deviceName));
                // --
                base.fTypeDescriptor.properties["SessionUniqueId"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.sessionUniqueIdToString));
                base.fTypeDescriptor.properties["SessionName"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.sessionName));
                // --
                base.fTypeDescriptor.properties["Length"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.length));
                // --
                base.fTypeDescriptor.properties["SessionId"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.sessionId));
                base.fTypeDescriptor.properties["Stream"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.stream));
                base.fTypeDescriptor.properties["Function"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.function));
                base.fTypeDescriptor.properties["Version"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.version));
                base.fTypeDescriptor.properties["WBit"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.wBit));
                base.fTypeDescriptor.properties["SystemBytes"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.systemBytes));
                // --
                base.fTypeDescriptor.properties["AutoReply"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.autoReply));
                // --
                base.fTypeDescriptor.properties["UserTag1"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.userTag1));
                base.fTypeDescriptor.properties["UserTag2"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.userTag2));
                base.fTypeDescriptor.properties["UserTag3"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.userTag3));
                base.fTypeDescriptor.properties["UserTag4"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.userTag4));
                base.fTypeDescriptor.properties["UserTag5"].attributes.replace(new DefaultValueAttribute(m_fSdmrl.userTag5));

                // -- 

                if (m_fSdmrl.isPrimary)
                {
                    base.fTypeDescriptor.properties["WBit"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["AutoReply"].attributes.replace(new BrowsableAttribute(false));
                }
                else if (m_fSdmrl.isSecondary)
                {
                    base.fTypeDescriptor.properties["WBit"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["AutoReply"].attributes.replace(new BrowsableAttribute(true));
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

    }   // Class end
}   // Namespace end
