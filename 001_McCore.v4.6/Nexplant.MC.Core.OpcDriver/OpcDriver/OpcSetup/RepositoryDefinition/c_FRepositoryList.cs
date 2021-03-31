﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FRepositoryList.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.08.26
--  Description     : FAMate Core FaOpcDriver Repository List Class
--  History         : Created by jungyoul.moon at 2013.08.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FRepositoryList : FBaseObject<FRepositoryList>, FIObject
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Constuction and Destruction

        public FRepositoryList(
          FOpcDriver fOpcDriver
            )
            : base(fOpcDriver.fOcdCore, FOpcDriverCommon.createXmlNodeRPL(fOpcDriver.fOcdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FRepositoryList(
            FOcdCore fOcdCore,
            FXmlNode fXmlNode
            )
            :base(fOcdCore, fXmlNode)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FRepositoryList(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void  myDispose(
            bool disposing
            )
        {
            if(!m_disposed)
            {
                if(disposing)
                {

                }
                m_disposed = true;
                
                // --

                base.myDispose(disposing);
            }
        }
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region properties

        public FObjectType fObjectType
        {
            get
            {
                try
                {
                    return FObjectType.RepositoryList;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.RepositoryList;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagRPL.A_UniqueId, FXmlTagRPL.D_UniqueId);
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

        public UInt64 uniqueId
        {
            get
            {
                try
                {
                    return UInt64.Parse(this.uniqueIdToString);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool locked
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagRPL.A_Locked, FXmlTagRPL.D_Locked));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string name
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagRPL.A_Name, FXmlTagRPL.D_Name);
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

            set
            {
                try
                {
                    FOpcDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagRPL.A_Name, FXmlTagRPL.D_Name, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string description
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagRPL.A_Description, FXmlTagRPL.D_Description);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagRPL.A_Description, FXmlTagRPL.D_Description, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public Color fontColor
        {
            get
            {
                try
                {
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagRPL.A_FontColor, FXmlTagRPL.D_FontColor));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    
                }
                return Color.Black;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagRPL.A_FontColor, FXmlTagRPL.D_FontColor, value.Name, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool fontBold
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagRPL.A_FontBold, FXmlTagRPL.D_FontBold));
                }
                catch(Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagRPL.A_FontBold, FXmlTagRPL.D_FontBold, FBoolean.fromBool(value), true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag1
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagRPL.A_UserTag1, FXmlTagRPL.D_UserTag1);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagRPL.A_UserTag1, FXmlTagRPL.D_UserTag1, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag2
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagRPL.A_UserTag2, FXmlTagRPL.D_UserTag2);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagRPL.A_UserTag2, FXmlTagRPL.D_UserTag2, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag3
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagRPL.A_UserTag3, FXmlTagRPL.D_UserTag3);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagRPL.A_UserTag3, FXmlTagRPL.D_UserTag3, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag4
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagRPL.A_UserTag4, FXmlTagRPL.D_UserTag4);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagRPL.A_UserTag4, FXmlTagRPL.D_UserTag4, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string userTag5
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagRPL.A_UserTag5, FXmlTagRPL.D_UserTag5);
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagRPL.A_UserTag5, FXmlTagRPL.D_UserTag5, value, true);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defUserTagName1
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(1);
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

        public string defUserTagName2
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(2);
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

        public string defUserTagName3
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(3);
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

        public string defUserTagName4
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(4);
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

        public string defUserTagName5
        {
            get
            {
                try
                {
                    return this.getDefUserTagName(5);
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

        public FOpcDriver fParent
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
                        return null;
                    }

                    // --

                    return this.fOpcDriver;
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

        public FRepositoryList fPreviousSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fPreviousSibling == null)
                    {
                        return null;
                    }

                    // --

                    return new FRepositoryList(this.fOcdCore, this.fXmlNode.fPreviousSibling);
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

        public FRepositoryList fNextSibling
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fNextSibling == null)
                    {
                        return null;
                    }

                    // --

                    return new FRepositoryList(this.fOcdCore, this.fXmlNode.fNextSibling);
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

        public FRepositoryCollection fChildRepositoryCollection
        {
            get
            {
                try
                {
                    return new FRepositoryCollection(this.fOcdCore, this.fXmlNode.selectNodes(FXmlTagRPS.E_Repository));
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

        public FObjectNameCollection fObjectNameCollection
        {
            get
            {
                try
                {
                    return this.getObjectNameCollection();
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

        public FObjectCollection fReferenceObjectCollection
        {
            get
            {
                try
                {
                    return new FObjectCollection(this.fOcdCore, this.fXmlNode.selectNodes("NULL"));
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

        public FObjectCollection fInclusionObjectCollection
        {
            get
            {
                try
                {
                    return new FObjectCollection(this.fOcdCore, this.fXmlNode.selectNodes("NULL"));
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

        public bool hasChild
        {
            get
            {
                try
                {
                    return this.fXmlNode.containsNode(FXmlTagRPS.E_Repository);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasHashTagChild
        {
            get
            {
                try
                {
                    return false;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canAppendChild
        {
            get
            {
                try
                {
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canInsertBefore
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canInsertAfter
        {
            get
            {
                try
                {
                    return this.canInsertBefore;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canRemove
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.locked)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canMoveUp
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.fXmlNode.fPreviousSibling == null)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canMoveDown
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.fXmlNode.fNextSibling == null)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public bool canCut
        {
            get
            {
                try
                {
                    if (this.fXmlNode.fParentNode == null || this.locked)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canCopy
        {
            get
            {
                try
                {
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canPasteSibling
        {
            get
            {
                try
                {
                    if (
                        this.fXmlNode.fParentNode == null ||                        
                        !FClipboard.containsData(FCbObjectFormat.RepositoryList)
                        )
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool canPasteChild
        {
            get
            {
                try
                {
                    if (!FClipboard.containsData(FCbObjectFormat.Repository))
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Methode

        public string ToString(
            FStringOption option
            )
        {
            string info = string.Empty;
            try
            {
                info = this.name;
                // --
                if (this.description != string.Empty)
                {
                    info += (" Desc=[" + this.description + "]");
                }
                // --
                return info;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FRepository appendChildRepository(
            FRepository fNewChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));
                // --
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fOpcDriver, this, fNewChild)
                        );
                }

                // --

                return fNewChild;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FRepository insertBeforeChildRepository(
            FRepository fNewChild,
            FRepository fRefChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));
                // --
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fOpcDriver, this, fNewChild)
                        );
                }

                // --

                return fNewChild;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FRepository insertAfterChildRepository(
            FRepository fNewChild,
            FRepository fRefChild
            )
        {
            try
            {
                FOpcDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FOpcDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);

                // --

                fNewChild.replace(this.fOcdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));
                // --
                if (this.isModelingObject)
                {
                    FOpcDriverCommon.resetUniqueId(this.fOcdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fOpcDriver, this, fNewChild)
                        );
                }
                
                // --

                return fNewChild;
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

        //------------------------------------------------------------------------------------------------------------------------

        public void remove(
            )
        {
            FIObject fParent = null;
            bool isModelingObject = false;

            try
            {
                FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);

                // --

                resetRelation();

                // --

                fParent = this.fParent;
                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fOpcDriver, fParent, this)
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FRepository removeChildRepository(
            FRepository fChild
            )
        {
            try
            {
                FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

                // --

                fChild.remove();

                // --

                return fChild;
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

        //------------------------------------------------------------------------------------------------------------------------

        public void removeChildRepository(
            FRepository[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FRepository fRps in fChilds)
                {
                    FOpcDriverCommon.validateRemoveChildObject(this.fXmlNode, fRps.fXmlNode);
                }

                // --

                foreach (FRepository fRps in fChilds)
                {
                    fRps.remove();
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

        public void removeAllChildRepository(
            )
        {
            FRepositoryCollection fRepositoryCollection = null;

            try
            {
                fRepositoryCollection = this.fChildRepositoryCollection;
                if (fRepositoryCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FRepository fRps in fRepositoryCollection)
                {
                    if (fRps.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FRepository fRps in fRepositoryCollection)
                {
                    fRps.remove();
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

        public void moveUp(
            )
        {
            bool isModelingObject = false;

            try
            {
                FOpcDriverCommon.validateMoveUpObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fOpcDriver, fParent, this)
                        );
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

        public void moveDown(
            )
        {
            bool isModelingObject = false;

            try
            {
                FOpcDriverCommon.validateMoveDownObject(this.fXmlNode);

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fOcdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fOcdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fOpcDriver, fParent, this)
                        );
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

        public void moveTo(
            FRepositoryList fRefObject
            )
        {
            try
            {
                FOpcDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

                // --

                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Object", "Modeling Object"));
                }

                if (!fRefObject.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Reference Object", "Modeling Object"));
                }

                if (!this.equalsModelingFile(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Modeling File", "same"));
                }

                // --                

                this.replace(this.fOcdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fOcdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                this.fOcdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fOpcDriver, this, fRefObject)
                    );
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

        internal void lockObject(
            )
        {
            try
            {
                if (this.locked)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagRPL.A_Locked, FXmlTagRPL.D_Locked, FBoolean.True, true);
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

        internal void unlockObject(
            )
        {
            string xpath = string.Empty;

            try
            {
                if (!this.locked)
                {
                    return;
                }

                // --

                // ***
                // Lock이 설정되어 있는 Repository이 존재할 경우 Unlock 작업을 최소한다.
                // ***
                xpath = FXmlTagRPS.E_Repository + "[@" + FXmlTagRPS.A_Locked + "='" + FBoolean.True + "']";
                if (this.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagRPL.A_Locked, FXmlTagRPL.D_Locked, FBoolean.False, true);
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

        public void copy(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);

                // --

                resetFlowNode(fXmlNode);
                this.copyObject(FCbObjectFormat.RepositoryList, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void cut(
            )
        {
            try
            {
                FOpcDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.RepositoryList, this.fXmlNode);
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

        public FRepositoryList pasteSibling(
            )
        {
            FRepositoryList fRepositoryList = null;

            try
            {
                FOpcDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.RepositoryList);

                // --

                fRepositoryList = (FRepositoryList)this.pasteObject(FCbObjectFormat.RepositoryList);
                return this.fParent.insertAfterChildRepositoryList(fRepositoryList, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRepositoryList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FRepository pasteChild(
            )
        {
            FRepository fRepository = null;

            try
            {
                FOpcDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.Repository);

                // --

                fRepository = (FRepository)this.pasteObject(FCbObjectFormat.Repository);
                return this.appendChildRepository(fRepository);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRepository = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FRepositoryCollection selectRepositoryByName(
            string name
            )
        {
            const string xpath = FXmlTagRPS.E_Repository + "[@" + FXmlTagRPS.A_Name + "='{0}']";

            try
            {
                return new FRepositoryCollection(
                    this.fOcdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, name))
                    );
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

        //------------------------------------------------------------------------------------------------------------------------

        public FRepository selectSingleRepositoryByName(
            string name
            )
        {
            const string xpath = FXmlTagRPS.E_Repository + "[@" + FXmlTagRPS.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FRepository(this.fOcdCore, fXmlNode);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNode = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void resetRelation(
            )
        {
            try
            {
                foreach (FRepository fRps in this.fChildRepositoryCollection)
                {
                    fRps.resetRelation();
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

        internal static void resetFlowNode(
            FXmlNode fXmlNode
            )
        {
            try
            {
                foreach (FXmlNode fXmlNodeRps in fXmlNode.selectNodes(FXmlTagRPS.E_Repository))
                {
                    FRepository.resetFlowNode(fXmlNodeRps);
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
