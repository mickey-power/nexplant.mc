﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHost.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaPlcDriver Host Class 
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FHost : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const int AutoCycleRunTime = 50;    // 추후 설정 여부 판단

        // --

        private bool m_disposed = false;
        // --
        private int m_transactionTimeout = 0;
        // --
        private FHostProtocol m_fHostProtocol = null;
        private FIHostDriver m_fHostDriver = null;
        private FIDPointer32 m_fTidPointer = null;
        private FDeviceState m_fDeviceState = FDeviceState.Closed;
        private FHostOpenTransaction m_fTranDataMessage = null;
        // --
        private FCodeLock m_fMainSync = null;
        private FThread m_fThdMain = null;
        private bool m_autoActionFirstSelectTransmitterRan = false;
        private bool m_autoActionAlwaysSelectTransmitterRan = false;
        private FStaticTimer m_fTmrAutoCycle = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHost(
            FHostProtocol fHostProtocol
            )
        {
            m_fHostProtocol = fHostProtocol;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHost(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                    // --
                    m_fHostProtocol = null;
                }                
                m_disposed = true;         
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FHostProtocol fHostProtocol
        {
            get
            {
                try
                {
                    return m_fHostProtocol;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FProtocolAgent fProtocolAgent
        {
            get
            {
                try
                {
                    return m_fHostProtocol.fProtocolAgent;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FPcdCore fPcdCore
        {
            get
            {
                try
                {
                    return m_fHostProtocol.fPcdCore;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FEventPusher fEventPusher
        {
            get
            {
                try
                {
                    return m_fHostProtocol.fPcdCore.fEventPusher;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcDriver fPlcDriver
        {
            get
            {
                try
                {
                    return m_fHostProtocol.fPcdCore.fPlcDriver;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FHostDevice fHostDevice
        {
            get
            {
                try
                {
                    return m_fHostProtocol.fHostDevice;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FIHostDriver fHostDriver
        {
            get
            {
                try
                {
                    return m_fHostDriver;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FIDPointer32 fTidPointer
        {
            get
            {
                try
                {
                    return m_fTidPointer;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FDeviceState fDeviceState
        {
            get
            {
                try
                {
                    return m_fDeviceState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDeviceState.Closed;
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
                m_fHostDriver = this.fHostDevice.createHostDriver();
                if (m_fHostDriver == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0041, "Host Driver"));
                }
                // --
                m_fHostDriver.HostDriverStateChanged += new FHostDriverStateChangedEventHandler(m_fHostDriver_HostDriverStateChanged);
                m_fHostDriver.HostDriverDataMessageReceived += new FHostDriverDataMessageReceivedEventHandler(m_fHostDriver_HostDriverDataMessageReceived);
                m_fHostDriver.HostDriverDataMessageSent += new FHostDriverDataMessageSentEventHandler(m_fHostDriver_HostDriverDataMessageSent);
                m_fHostDriver.HostDriverErrorRaised += new FHostDriverErrorRaisedEventHandler(m_fHostDriver_HostDriverErrorRaised);

                // --

                m_transactionTimeout = this.fHostDevice.transactionTimeout * 1000;

                // --

                m_fTidPointer = new FIDPointer32();
                m_fTranDataMessage = new FHostOpenTransaction(this.fPlcDriver, m_transactionTimeout);
                m_fTmrAutoCycle = new FStaticTimer();

                // --

                m_fMainSync = new FCodeLock();
                m_fThdMain = new FThread("FHostMainThread");
                m_fThdMain.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                m_fThdMain.start();
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
                if (m_fThdMain != null)
                {
                    m_fThdMain.stop();
                    m_fThdMain.Dispose();
                    m_fThdMain.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                    m_fThdMain = null;
                }

                if (m_fHostDriver != null)
                {
                    m_fHostDriver.HostDriverStateChanged -= new FHostDriverStateChangedEventHandler(m_fHostDriver_HostDriverStateChanged);
                    m_fHostDriver.HostDriverDataMessageReceived -= new FHostDriverDataMessageReceivedEventHandler(m_fHostDriver_HostDriverDataMessageReceived);
                    m_fHostDriver.HostDriverDataMessageSent -= new FHostDriverDataMessageSentEventHandler(m_fHostDriver_HostDriverDataMessageSent);
                    m_fHostDriver.HostDriverErrorRaised -= new FHostDriverErrorRaisedEventHandler(m_fHostDriver_HostDriverErrorRaised);
                    // --
                    m_fHostDriver.Dispose();
                    m_fHostDriver = null;
                }

                if (m_fTranDataMessage != null)
                {
                    m_fTranDataMessage.Dispose();
                    m_fTranDataMessage = null;
                }

                if (m_fTidPointer != null)
                {
                    m_fTidPointer.Dispose();
                    m_fTidPointer = null;
                }

                if (m_fTmrAutoCycle != null)
                {
                    m_fTmrAutoCycle.Dispose();
                    m_fTmrAutoCycle = null;
                }

                if (m_fMainSync != null)
                {
                    m_fMainSync.Dispose();
                    m_fMainSync = null;
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

        public void setDriverOption(
            )
        {
            try
            {
                m_fHostDriver.setDriverOption();
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

        public void changeDeviceState(
            FDeviceState fState
            )
        {
            FHostDeviceStateChangedLog fLog = null;
            FXmlNode[] fXmlNodeHtrList = null;
            try
            {
                m_fDeviceState = fState;
                this.fHostDevice.changeState(m_fDeviceState);      
          
                // --

                // ***
                // Trigger Parser
                // ***
                if (fPcdCore.fConfig.enabledEventsOfScenario)
                {
                    fXmlNodeHtrList = FHost2.parseConnectionTrigger(this.fPlcDriver, this.fHostDevice.fXmlNode, fState);
                    // --

                    fLog = new FHostDeviceStateChangedLog(
                        FPlcDriverLogCommon.createXmlNodeHDVL(this.fHostDevice.fXmlNode, FXmlTagHDVL.L_StateChanged)
                        );

                    // --

                    if (fXmlNodeHtrList != null)
                    {
                        foreach (FXmlNode fXmlNodeHtr in fXmlNodeHtrList)
                        {
                            this.fEventPusher.pushHostTriggerRaisedEvent(
                                FResultCode.Success,
                                string.Empty,
                                fXmlNodeHtr,
                                fLog
                                );
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLog = null;
                fXmlNodeHtrList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void open(
            )
        {
            try
            {
                m_fHostDriver.open();
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

        public void close(
            )
        {
            try
            {
                if (this.fDeviceState == FDeviceState.Selected)
                {
                    if (fPcdCore.fConfig.enabledEventsOfScenario)
                    {
                        // ***
                        // Auto Action First Close Transmitter 처리
                        // ***
                        this.fProtocolAgent.runHostAutoActionFirstCloseTransmitter(this.fHostDevice);

                        // ***
                        // Auto Action Always Close Transmitter 처리
                        // ***
                        this.fProtocolAgent.runHostAutoActionAlwaysCloseTransmitter(this.fHostDevice);
                    }

                    // --

                    // ***
                    // 2016.12.21 by spike.lee
                    // 모든 Event를 처리하고 Close 하도록 수정
                    // ***
                    while (this.fEventPusher.eventCount > 0 || !this.fHostDriver.sendCompleted)
                    {
                        if (System.Windows.Forms.Application.MessageLoop)
                        {
                            System.Windows.Forms.Application.DoEvents();
                        }
                        System.Threading.Thread.Sleep(1);
                    }
                }

                // --

                m_fHostDriver.close(); 
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

        public void send(
             FHostSession fHostSession,
             FHostMessageTransfer fHostMessageTransfer
             )
        {
            try
            {
                if (this.fDeviceState != FDeviceState.Selected)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0030, "Device"));
                }

                // --

                sendDataMessage(fHostSession, fHostMessageTransfer);
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

        public void pauseProtocol(
            )
        {
            try
            {
                m_fMainSync.wait();
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

        public void continueProtocol(
            )
        {
            try
            {
                m_fMainSync.set();
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

        private void sendDataMessage(
            FHostSession fHsn,
            FHostMessageTransfer fHmt
            )
        {
            FXmlNode fXmlNodeHdmg = null;
            UInt32 tid = 0;

            try
            {
                if (fHmt.hasTid)
                {
                    tid = fHmt.tid;
                }
                else
                {
                    tid = this.fTidPointer.uniqueId;
                }
                fXmlNodeHdmg = FHost2.parseHmtToHdmg(fHmt.fXmlNode, fHsn.machineId, fHsn.sessionId, tid);

                // --

                // ***
                // HostMessageTransfer에 RepositoryMaterial이 존재할 경우 Reply Message 전송 시, RepositoryMaterial를 검색하기 위한 Key를 저장한다.
                // ***
                if (fHmt.fRepositoryMaterial != null)
                {
                    fHmt.fRepositoryMaterial.setHostReplyKey(
                        this.fHostDevice.uniqueId,
                        fHsn.uniqueId,
                        tid
                        );
                }

                // --

                this.fHostDriver.send(new FHostDriverDataMessage(this.fPcdCore, fXmlNodeHdmg));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeHdmg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procStateOpened(
            )
        {
            try
            {
                this.changeDeviceState(FDeviceState.Opened);
                // --
                if (fPlcDriver.fPcdCore.fConfig.enabledEventsOfHostDeviceState)
                {
                    this.fEventPusher.pushHostDeviceStateChangedEvent(
                        this.fHostDevice,
                        FResultCode.Success,
                        string.Empty
                        );
                }

                // --

                m_autoActionAlwaysSelectTransmitterRan = false;

                // --

                // ***
                // Auto Cycle Run Time 중지
                // ***
                this.fProtocolAgent.clearHostAutoCycleTransmitter(this.fHostDevice);
                m_fTmrAutoCycle.stop();

                // --

                // ***
                // Host Retry Condtion 초기화
                // ***
                this.fProtocolAgent.clearHostRetryCondition(this.fHostDevice);
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procStateConnected(
            )
        {
            try
            {
                this.changeDeviceState(FDeviceState.Connected);
                // --
                if (fPlcDriver.fPcdCore.fConfig.enabledEventsOfHostDeviceState)
                {
                    this.fEventPusher.pushHostDeviceStateChangedEvent(
                        this.fHostDevice,
                        FResultCode.Success,
                        string.Empty
                        );
                }
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procStateSelected(
            )
        {
            try
            {
                this.changeDeviceState(FDeviceState.Selected);
                // --
                if (fPlcDriver.fPcdCore.fConfig.enabledEventsOfHostDeviceState)
                {
                    this.fEventPusher.pushHostDeviceStateChangedEvent(
                        this.fHostDevice,
                        FResultCode.Success,
                        string.Empty
                        );
                }

                // --

                // ***
                // Auto Cycle Run Time 실행
                // ***
                m_fTmrAutoCycle.start(AutoCycleRunTime);
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procStateClosed(
            )
        {
            try
            {
                this.changeDeviceState(FDeviceState.Closed);
                // --
                if (fPlcDriver.fPcdCore.fConfig.enabledEventsOfHostDeviceState)
                {
                    this.fEventPusher.pushHostDeviceStateChangedEvent(
                        this.fHostDevice,
                        FResultCode.Success,
                        string.Empty
                        );
                }
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procDataReceived(
            FHostDriverDataMessage fHdmg,
            bool ignoreMachineId,
            bool ignoreFormat
            )
        {
            FResultCode fResultCode = FResultCode.Success;
            string resultMessage = string.Empty;            
            FXmlNode fXmlNodeHsn = null;
            FXmlNode fXmlNodeHmg = null;
            FXmlNode fXmlNodeHmgl = null;
            FXmlNode[] fXmlNodeHtrList = null;
            string vfei = string.Empty;
            FHostDeviceDataMessageSentLog fTranLog = null;
            FHostDeviceDataMessageReceivedLog fLog = null;
            FHostMessage fHmg = null;
            FHostMessageTransfer fHmt = null;

            try
            {
                if (this.fDeviceState != FDeviceState.Selected)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0030, "Device"));                    
                }

                // --

                // ***
                // Host Open Transaction 검색 (Only Secondary Message)
                // ***
                if (fHdmg.fHostMessageType == FHostMessageType.Reply)
                {
                    fTranLog = m_fTranDataMessage.getTransaction(fHdmg.sessionId, fHdmg.tid);
                    if (fTranLog != null)
                    {
                        fXmlNodeHsn = fTranLog.fXmlNodeHsn;
                        fXmlNodeHmg = FHost2.getReplyMessage(this.fPlcDriver, fXmlNodeHsn, fTranLog.uniqueIdToString);
                    }
                }

                // --

                // ***
                // Host2 Parsing
                // ***
                fResultCode = FResultCode.Success;
                resultMessage = string.Empty;
                // --
                fXmlNodeHmgl = FHost2.parseHdmgToHmg(
                    this.fPlcDriver, 
                    this.fHostDevice, 
                    fHdmg, 
                    ignoreMachineId,
                    ignoreFormat,
                    ref fResultCode, 
                    ref resultMessage, 
                    ref fXmlNodeHsn, 
                    ref fXmlNodeHmg
                    );
                fLog = this.fEventPusher.createHostDeviceDataMessageReceivedLog(fXmlNodeHsn, fXmlNodeHmgl);

                // --               

                if (
                    this.fPcdCore.fConfig.enabledLogOfVfei ||
                    this.fPcdCore.fConfig.enabledEventsOfHostDeviceVfei
                    )
                {
                    // ***
                    // VFEI Parsing
                    // ***                
                    vfei = FMessageConverter.convertHdmgToVfei(fXmlNodeHmgl);

                    // --

                    // ***
                    // 2012.11.23 by spike.lee
                    // VFEI Log File은 Eanbled Event와 상관 없이 기록하도록 수정
                    // ***
                    if (this.fPcdCore.fConfig.enabledLogOfVfei)
                    {
                        this.fPcdCore.fLogWriter.pushVfeiLog(
                            FEventId.HostDeviceVfeiReceived,
                            FDataConvert.defaultNowDateTimeToString(),
                            this.fHostDevice.name,
                            fHdmg.sessionId,
                            FResultCode.Success,
                            string.Empty,
                            vfei
                            );
                    }

                    // --

                    if (this.fPcdCore.fConfig.enabledEventsOfHostDeviceVfei)
                    {
                        this.fEventPusher.pushHostDeviceVfeiReceivedEvent(
                            this.fHostDevice,
                            FResultCode.Success,
                            string.Empty,
                            fHdmg.machineId,
                            fHdmg.sessionId,
                            fHdmg.command,
                            fHdmg.fHostMessageType,
                            fHdmg.tid,
                            vfei
                            );
                    }                    
                }

                // --

                if (fResultCode == FResultCode.Success)
                {
                    if (fLog.fHostMessageType == FHostMessageType.Command || fLog.fHostMessageType == FHostMessageType.Unsolicited)
                    {
                        if (fLog.fHostMessageType == FHostMessageType.Command)
                        {
                            fXmlNodeHmg = FHost2.getReplyMessage(this.fPlcDriver, fXmlNodeHsn, fLog.uniqueIdToString);
                            if (fXmlNodeHmg != null)
                            {
                                fHmg = new FHostMessage(this.fPcdCore, fXmlNodeHmg);
                            }
                        }                        

                        // --

                        if (fPlcDriver.fPcdCore.fConfig.enabledEventsOfHostDeviceDataMessage)
                        {
                            this.fEventPusher.pushHostDeviceDataMessageReceivedEvent(
                                this.fHostDevice,
                                fResultCode,
                                resultMessage,
                                fLog,
                                fHmg
                                );
                        }

                        // --

                        if (fHmg != null)
                        {
                            if (fHmg.autoReply)
                            {
                                // ***
                                // Auto Reply Message Random Value 설정
                                // ***
                                fHmt = fHmg.createTransfer(fLog.tid);
                                FPlcDriverCommon.setHostItemRandomValue(fHmt.fXmlNode);

                                // --

                                this.sendDataMessage(new FHostSession(this.fPcdCore, fXmlNodeHsn), fHmt);
                            }
                            else
                            {
                                // ***
                                // Reply Message가 Auto Reply가 아닐 경우, TID를 Keeping한다.
                                // *** 
                                this.fProtocolAgent.fHostTidStorage.add(
                                    fLog.deviceUniqueId,
                                    fLog.sessionUniqueId,
                                    fHmg.uniqueId, 
                                    fLog.tid
                                    );
                            }
                        }
                    }                   
                    else
                    {
                        if (fTranLog == null)
                        {
                            fResultCode = FResultCode.Warninig;
                            resultMessage = FConstants.err_m_0031;
                        }
                        else
                        {
                            m_fTranDataMessage.closeTransaction(fTranLog);
                            clearRetryDataMessage(fTranLog.fXmlNode);   
                        }
                        // --

                        if (fPlcDriver.fPcdCore.fConfig.enabledEventsOfHostDeviceDataMessage)
                        {
                            this.fEventPusher.pushHostDeviceDataMessageReceivedEvent(
                                this.fHostDevice, 
                                fResultCode, 
                                resultMessage, 
                                fLog, 
                                null
                                );
                        }
                    }

                    // --

                    // ***
                    // Trigger Parser
                    // ***
                    if (fPcdCore.fConfig.enabledEventsOfScenario)
                    {
                        if (fResultCode == FResultCode.Success)
                        {
                            fXmlNodeHtrList = FHost2.parseExpressionTrigger(this.fPlcDriver, fXmlNodeHmgl);
                            foreach (FXmlNode fXmlNodeHtr in fXmlNodeHtrList)
                            {
                                this.fEventPusher.pushHostTriggerRaisedEvent(
                                    FResultCode.Success,
                                    string.Empty,
                                    fXmlNodeHtr,
                                    fLog
                                    );
                            }
                        }
                    }
                }
                else
                {
                    if (fPlcDriver.fPcdCore.fConfig.enabledEventsOfHostDeviceDataMessage)
                    {
                        this.fEventPusher.pushHostDeviceDataMessageReceivedEvent(
                            this.fHostDevice, 
                            fResultCode, 
                            resultMessage, 
                            fLog, 
                            null
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fXmlNodeHsn = null;
                fXmlNodeHmg = null;
                fXmlNodeHmgl = null;
                fXmlNodeHtrList = null;
                fTranLog = null;
                fLog = null;
                fHmg = null;
                fHmt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procDataSent(
            FHostDriverDataMessage fHdmg
            )
        {
            FResultCode fResultCode = FResultCode.Success;
            string resultMessage = string.Empty;
            FXmlNode fXmlNodeHsn = null;            
            FXmlNode fXmlNodeHmgl = null;
            string vfei = string.Empty;
            FHostDeviceDataMessageSentLog fLog = null;

            try
            {
                // ***
                // Host2 Parsing
                // ***
                fResultCode = FResultCode.Success;
                resultMessage = string.Empty;
                // --
                fXmlNodeHmgl = FHost2.parseHdmgToHmg(
                    this.fHostDevice,
                    fHdmg,
                    ref fResultCode,
                    ref resultMessage,
                    ref fXmlNodeHsn
                    );
                fLog = this.fEventPusher.createHostDeviceDataMessageSentLog(fXmlNodeHsn, fXmlNodeHmgl);

                // --
                
                if (
                    this.fPcdCore.fConfig.enabledLogOfVfei ||
                    this.fPcdCore.fConfig.enabledEventsOfHostDeviceVfei
                    )
                {
                    // ***
                    // VFEI Parsing
                    // ***
                    vfei = FMessageConverter.convertHdmgToVfei(fXmlNodeHmgl);
                    
                    // --

                    if (this.fPcdCore.fConfig.enabledLogOfVfei)
                    {
                        this.fPcdCore.fLogWriter.pushVfeiLog(
                            FEventId.HostDeviceVfeiSent,
                            FDataConvert.defaultNowDateTimeToString(),
                            this.fHostDevice.name,
                            fHdmg.sessionId,
                            FResultCode.Success,
                            string.Empty,
                            vfei
                            );
                    }

                    // --

                    if (this.fPcdCore.fConfig.enabledEventsOfHostDeviceVfei)
                    {
                        this.fEventPusher.pushHostDeviceVfeiSentEvent(
                            this.fHostDevice,
                            FResultCode.Success,
                            string.Empty,
                            fHdmg.machineId,
                            fHdmg.sessionId,
                            fHdmg.command,
                            fHdmg.fHostMessageType,
                            fHdmg.tid,
                            vfei
                            );
                    }                    
                }

                // --

                if (fPcdCore.fConfig.enabledEventsOfHostDeviceDataMessage)
                {
                    this.fEventPusher.pushHostDeviceDataMessageSentEvent(
                        this.fHostDevice,
                        fResultCode,
                        resultMessage,
                        fLog
                        );
                }

                // --

                if (fResultCode == FResultCode.Success)
                {
                    if (fLog.fHostMessageType == FHostMessageType.Command)
                    {
                        m_fTranDataMessage.openTransaction(
                            this.fEventPusher.createHostDeviceDataMessageSentLog(fLog.fXmlNodeHsn, fLog.fXmlNode.clone(false))
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fXmlNodeHsn = null;
                fXmlNodeHmgl = null;
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procOpenTransaction(
            )
        {
            FHostDeviceDataMessageSentLog fLog = null;
            FXmlNode[] fXmlNodeHtrList = null;
            FXmlNode fXmlNodeRetryHcn = null;

            try
            {
                while ((fLog = m_fTranDataMessage.getTimeoutTransaction()) != null)
                {
                    if (fPcdCore.fConfig.enabledEventsOfHostDeviceDataMessage)
                    {
                        this.fEventPusher.pushHostDeviceDataMessageSentEvent(
                            this.fHostDevice,
                            FResultCode.Error,
                            FConstants.err_m_0032,
                            fLog
                            );
                    }

                    // --

                    if (fPcdCore.fConfig.enabledEventsOfScenario)
                    {
                        fXmlNodeHtrList = FHost2.parseTimeoutTrigger(this.fPlcDriver, fLog.fXmlNode, ref fXmlNodeRetryHcn);
                        foreach (FXmlNode fXmlNodeHtr in fXmlNodeHtrList)
                        {
                            this.fEventPusher.pushHostTriggerRaisedEvent(
                                FResultCode.Success,
                                string.Empty,
                                fXmlNodeHtr,
                                fLog
                                );
                        }
                    }

                    // --

                    if (fXmlNodeRetryHcn != null)
                    {
                        procRetryDataMessage(fXmlNodeRetryHcn);
                    }
                }
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fLog = null;
                fXmlNodeHtrList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procRetryDataMessage(
            FXmlNode fXmlNodeHcn
            )
        {
            int retryLimit = 0;
            int retryCount = 0;
            FHostCondition fHcn = null;

            try
            {
                retryLimit = int.Parse(fXmlNodeHcn.get_attrVal(FXmlTagHCN.A_RetryLimit, FXmlTagHCN.D_RetryLimit));
                retryCount = int.Parse(fXmlNodeHcn.get_attrVal(FXmlTagHCN.A_RetryCount, FXmlTagHCN.D_RetryCount));

                // --

                // ***
                // Retry Limit 횟수만큼 시도되었을 경우, Retry 횟수 초기화
                // ***
                if (retryLimit == retryCount)
                {
                    fXmlNodeHcn.set_attrVal(FXmlTagHCN.A_RetryCount, FXmlTagHCN.D_RetryCount, "0");
                    return;
                }

                // --

                fHcn = new FHostCondition(this.fPcdCore, fXmlNodeHcn);
                fHcn.fMessage.createTransfer().send(fHcn.fSession);

                // --

                // ***
                // Retry 회수 증가
                // ***
                fXmlNodeHcn.set_attrVal(FXmlTagHCN.A_RetryCount, FXmlTagHCN.D_RetryCount, (retryCount + 1).ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHcn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procDeviceErrorRaised(
            Exception inEx
            )
        {
            try
            {
                FDebug.writeLog(inEx);
                // --
                if (this.fPcdCore.fConfig.enabledEventsOfHostDeviceError)
                {
                    this.fEventPusher.pushHostDeviceErrorRaisedEvent(
                        this.fHostDevice, 
                        FResultCode.Error, 
                        inEx.Message
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procDeviceErrorRaised(
            string errorMessage
            )
        {
            Exception inEx = null;

            try
            {
                inEx = new Exception(errorMessage);
                // --
                procDeviceErrorRaised(inEx);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void clearRetryDataMessage(
            FXmlNode fXmlNodeHmgl
            )
        {
            FXmlNodeList fXmlNodeListHcn = null;

            try
            {
                fXmlNodeListHcn = FHost2.getRetryCondition(this.fPlcDriver, fXmlNodeHmgl);
                foreach (FXmlNode fXmlNodeHcn in fXmlNodeListHcn)
                {
                    fXmlNodeHcn.set_attrVal(FXmlTagHCN.A_RetryCount, FXmlTagHCN.D_RetryCount, "0");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListHcn = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fHostDriver Event Handler

        private void m_fHostDriver_HostDriverStateChanged(
            object sender, 
            FHostDriverStateChangedEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                if (e.fState == FHostDriverState.Opened)
                {
                    procStateOpened();
                }
                else if (e.fState == FHostDriverState.Connected)
                {
                    procStateConnected();
                }
                else if (e.fState == FHostDriverState.Selected)
                {
                    procStateSelected();
                }
                else if (e.fState == FHostDriverState.Closed)
                {
                    procStateClosed();
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fHostDriver_HostDriverDataMessageReceived(
            object sender, 
            FHostDriverDataMessageReceivedEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --
                
                procDataReceived(e.fHostDriverDataMessage, e.ignoreMachineId, e.ignoreFormat);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fHostDriver_HostDriverDataMessageSent(
            object sender, 
            FHostDriverDataMessageSentEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                procDataSent(e.fHostDriverDataMessage);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void m_fHostDriver_HostDriverErrorRaised(
            object sender,
            FHostDriverErrorRaisedEventArgs e
            )
        {
            try
            {
                procDeviceErrorRaised(e.errorMessage);
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

        #region m_fThdMain Object Event Handler

        private void m_fThdMain_ThreadJobCalled(
            object sender, 
            FThreadEventArgs e
            )
        {
            bool waited = false;

            try
            {
                waited = m_fMainSync.tryWait(1);
                if (!waited)
                {
                    return;
                }

                // --

                if (this.fDeviceState != FDeviceState.Selected)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                if (fPcdCore.fConfig.enabledEventsOfScenario)
                {
                    // ***
                    // Auto Action First Select Transmitter 처리
                    // ***
                    if (!m_autoActionFirstSelectTransmitterRan)
                    {
                        m_autoActionFirstSelectTransmitterRan = true;
                        this.fProtocolAgent.runHostAutoActionFirstSelectTransmitter(this.fHostDevice);
                    }

                    // ***
                    // Auto Action Always Select Transmitter 처리
                    // ***
                    if (!m_autoActionAlwaysSelectTransmitterRan)
                    {
                        m_autoActionAlwaysSelectTransmitterRan = true;
                        this.fProtocolAgent.runHostAutoActionAlwaysSelectTransmitter(this.fHostDevice);
                    }
                    
                    // --

                    // ***
                    // Auto Cycle Transmitter 처리
                    // ***
                    if (m_fTmrAutoCycle.elasped(true))
                    {
                        this.fProtocolAgent.runHostAutoCycleTransmitter(this.fHostDevice);
                    }
                }

                // --

                // ***
                // Transaction Timer Check
                // ***
                procOpenTransaction();

                // --

                e.sleepThread(1);
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                if (waited)
                {
                    m_fMainSync.set();
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
