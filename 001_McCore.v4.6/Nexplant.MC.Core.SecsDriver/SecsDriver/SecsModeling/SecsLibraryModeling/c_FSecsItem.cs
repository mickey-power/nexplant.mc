﻿/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsItem.cs
--  Creator         : spike.lee
--  Create Date     : 2011.02.11
--  Description     : FAMate Core FaSecsDriver SECS Item Class 
--  History         : Created by spike.lee at 2011.02.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    public class FSecsItem : FBaseObject<FSecsItem>, FIObject, FISecsOperand
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsItem(
            FSecsDriver fSecsDriver
            )
            : base(fSecsDriver.fScdCore, FSecsDriverCommon.createXmlNodeSIT(fSecsDriver.fScdCore.fXmlDoc))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsItem(
            FSecsDriver fSecsDriver,
            string name,
            FFormat fFormat,
            string stringValue
            )
            : base(FSecsDriverCommon.createXmlNodeSIT(fSecsDriver.fScdCore.fXmlDoc, name, fFormat, stringValue))
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsItem(
            FScdCore fScdCore,
            FXmlNode fXmlNode
            )
            : base(fScdCore, fXmlNode)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsItem(
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
                    
                }                

                m_disposed = true;

                // --
                
                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FObjectType fObjectType
        {
            get
            {
                try
                {
                    return FObjectType.SecsItem;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FObjectType.SecsDriver;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsOperandType fSecsOperandType
        {
            get
            {
                try
                {
                    return FSecsOperandType.SecsItem;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FSecsOperandType.SecsItem;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string uniqueIdToString
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_UniqueId, FXmlTagSIT.D_UniqueId);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSIT.A_Locked, FXmlTagSIT.D_Locked));
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
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_Name, FXmlTagSIT.D_Name);
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
                    FSecsDriverCommon.validateName(value, true);

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_Name, FXmlTagSIT.D_Name, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_Description, FXmlTagSIT.D_Description);
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
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_Description, FXmlTagSIT.D_Description, value, true);
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
                    return Color.FromName(this.fXmlNode.get_attrVal(FXmlTagSIT.A_FontColor, FXmlTagSIT.D_FontColor));
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
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_FontColor, FXmlTagSIT.D_FontColor, value.Name, true);
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
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSIT.A_FontBold, FXmlTagSIT.D_FontBold));
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

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_FontBold, FXmlTagSIT.D_FontBold, FBoolean.fromBool(value), true);
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

        public FPattern fPattern
        {
            get
            {
                try
                {
                    return FEnumConverter.toPattern(this.fXmlNode.get_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FPattern.Fixed;
            }

            set
            {
                try
                {
                    if (this.fPattern == value)
                    {
                        return;
                    }

                    // --                    

                    // ***
                    // Parent가 없는 SECS Item의 Pattern은 변경할 수 없다.
                    // ***
                    if (this.fParent == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "SECS Item without the Parent", "Pattern"));
                    }

                    // ***
                    // Parent가 SECS Message인 경우 Pattern를 변경할 수 없다.
                    // ***
                    if (
                        this.fParent.fObjectType == FObjectType.SecsMessage ||
                        this.fParent.fObjectType == FObjectType.SecsMessageTransfer
                        )
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "First SECS Item of SECS Message", "Pattern"));
                    }

                    if (value == FPattern.Fixed)
                    {
                        // ***
                        // Previous와 Next 형제가 Variable SECS Item이 아니어야 한다.
                        // ***                        
                        if (
                            (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable) &&
                            (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable)
                            )
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0010, "Pattern of the Previous SECS Item and the Next SECS Item", "Variable"));
                        }
                    }
                    else if (value == FPattern.Variable)
                    {                        
                        // ***
                        // 형제 Variable SECS Item과 연속적으로 이어져야 한다.                        
                        // ***
                        if (((FSecsItem)this.fParent).hasVariableChild)
                        {
                            if (this.fPreviousSibling == null && this.fNextSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous SECS Item and the Next SECS Item", "Variable"));
                            }
                            else if (this.fNextSibling == null && this.fPreviousSibling.fPattern != FPattern.Variable)
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous SECS Item and the Next SECS Item", "Variable"));
                            }
                            else if (
                                (this.fPreviousSibling != null) &&
                                (this.fNextSibling != null) &&
                                (this.fPreviousSibling.fPattern != FPattern.Variable && this.fNextSibling.fPattern != FPattern.Variable)
                                )
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous SECS Item and the Next SECS Item", "Variable"));
                            }
                        }                        
                    }                    

                    // --

                    // ***
                    // Pattern 변경 시, Fixed Length와 Scan Mode 초기화
                    // ***
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_FixedLength, FXmlTagSIT.D_FixedLength, "1");
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_ScanMode, FXmlTagSIT.D_ScanMode, FXmlTagSIT.D_ScanMode);
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern, FEnumConverter.fromPattern(value), true);
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

        public int fixedLength
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSIT.A_FixedLength, FXmlTagSIT.D_FixedLength));
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

            set
            {
                try
                {
                    // ***
                    // Parent가 없는 SECS Item의 Fixed Length는 변경할 수 없다.
                    // ***
                    if (this.fParent == null)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "SECS Item without the Parent", "Fixed Length"));
                    }

                    // ***
                    // Parent가 SECS Message인 경우 Fixed Length를 변경할 수 없다.
                    // ***
                    if (
                        this.fParent.fObjectType == FObjectType.SecsMessage ||
                        this.fParent.fObjectType == FObjectType.SecsMessageTransfer
                        )
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, "First SECS Item of SECS Message", "Fixed Length"));
                    }

                    // ***
                    // Pattern이 Fixed가 아닌 경우 Fixed Length를 변경할 수 없다.
                    // ***
                    if (this.fPattern != FPattern.Fixed)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern", "Fixed"));
                    }

                    if (value < 1)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0015, "Fixed Length"));
                    }

                    // --

                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_FixedLength, FXmlTagSIT.D_FixedLength, value.ToString(), true);
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

        public FFormat fFormat
        {
            get
            {
                try
                {
                    return FEnumConverter.toFormat(this.fXmlNode.get_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FFormat.Ascii;
            }

            set
            {
                try
                {
                    if (this.fFormat == value)
                    {
                        return;
                    }

                    // --

                    // ***
                    // Locked되어 있는 SECS Item의 Format은 변경할 수 없다.
                    // ***
                    if (this.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }

                    // ***
                    // 자식이 존재하는 List Format의 SECS Item은 Format를 변경할 수 없다.
                    // (자식이 존재하는 SECS Item의 Format은 변경할 수 없다.)
                    // ***
                    if (this.hasChild)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0013, "Object's Child"));
                    }

                    // ***
                    // 부모가 SECS Item이고 부모의 Format이 AsciiList인 경우 Format를 변경할 수 없다.
                    // ***
                    if (this.fParent != null && this.fParent.fObjectType == FObjectType.SecsItem && ((FSecsItem)this.fParent).fFormat == FFormat.AsciiList)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0010, "Parent's Format", "AsciiList"));
                    }

                    // ***
                    // Add by Jeff.Kim 2017.11.29
                    // Host 에서 사용하기 위해 Char 추가, SECS에서는 Char Format 은 사용할수 없다. 
                    // ***
                    if (value == FFormat.Char)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0019, "Char"));
                    }

                    // --
                    
                    setChangedFormat();
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_Format, FXmlTagSIT.D_Format, FEnumConverter.fromFormat(value), true);                    
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

        public FSecsLengthBytes lengthBytes
        {
            get
            {
                try
                {
                    return FEnumConverter.toSecsLengthBytes(this.fXmlNode.get_attrVal(FXmlTagSIT.A_LengthBytes, FXmlTagSIT.D_LengthBytes));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FSecsLengthBytes.Auto;
            }

            set
            {
                try
                {
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_LengthBytes, FXmlTagSIT.D_LengthBytes, FEnumConverter.fromSecsLengthBytes(value), true);
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

        public FDataScanMode fScanMode
        {
            get
            {
                try
                {
                    return FEnumConverter.toDataScanMode(this.fXmlNode.get_attrVal(FXmlTagSIT.A_ScanMode, FXmlTagSIT.D_ScanMode));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDataScanMode.Local;
            }

            set
            {
                try
                {
                    if (this.fPattern != FPattern.Fixed)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern", "Fixed"));
                    }

                    // --

                    fXmlNode.set_attrVal(FXmlTagSIT.A_ScanMode, FXmlTagSIT.D_ScanMode, FEnumConverter.fromDataScanMode(value), true);
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

        public string originalStringValue
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value);
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
                FFormat fFormat;
                FSecsLengthBytes lengthBytes;
                int length = 0;
                string val = string.Empty;

                try
                {
                    fFormat = this.fFormat;
                    lengthBytes = this.lengthBytes;

                    // --

                    // ***
                    // List, Unknown, Raw Format은 Value를 설정할 수 없다.
                    // ***
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Value"));
                    }

                    // --

                    val = FValueConverter.fromStringValue(fFormat, lengthBytes, value, out length);   
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value, val, true);
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

        public string[] originalStringArrayValue
        {
            get
            {
                try
                {
                    return FValueConverter.toStringArrayValue(this.fFormat, this.originalStringValue);
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

            set
            {
                FFormat fFormat;
                FSecsLengthBytes lengthBytes;
                int length = 0;
                string val = string.Empty;

                try
                {
                    fFormat = this.fFormat;
                    lengthBytes = this.lengthBytes;

                    // --

                    // ***
                    // List, Unknown, Raw Format은 Value를 설정할 수 없다.
                    // ***
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Value"));
                    }

                    // --

                    val = FValueConverter.fromStringArrayValue(fFormat, lengthBytes, value, out length);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value, val, true);
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

        public object originalValue
        {
            get
            {
                try
                {
                    return FValueConverter.toValue(this.fFormat, this.originalStringValue, this.originalLength);
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

            set
            {
                FFormat fFormat;
                FSecsLengthBytes lengthBytes;
                int length = 0;
                string val = string.Empty;

                try
                {
                    fFormat = this.fFormat;
                    lengthBytes = this.lengthBytes;

                    // --

                    // ***
                    // List, Unknown, Raw Format은 Value를 설정할 수 없다.
                    // ***
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Value"));
                    }

                    // --

                    val = FValueConverter.fromValue(fFormat, lengthBytes, value, out length);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, length.ToString());
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value, val, true);
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

        public string originalEncodingValue
        {
            get
            {
                try
                {
                    return FValueConverter.toEncodingValue(this.fFormat, this.originalStringValue);                    
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

        public int originalLength
        {
            get
            {
                try
                {
                    return int.Parse(this.fXmlNode.get_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length));
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

        public string stringValue
        {
            get
            {
                int length = 0;

                try
                {
                    return FValueConverter.toDataConversionStringValue(
                        this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagSIT.A_DataConversionSetExpression, FXmlTagSIT.D_DataConversionSetExpression),
                        ref length
                        );
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

        public string[] stringArrayValue
        {
            get
            {
                try
                {
                    return FValueConverter.toConversionedStringArrayValue(
                        this.fFormat, 
                        this.originalStringValue, 
                        this.fXmlNode.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagSIT.A_DataConversionSetExpression, FXmlTagSIT.D_DataConversionSetExpression)
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object value
        {
            get
            {
                try
                {
                    return FValueConverter.toDataConversionedValue(
                        this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagSIT.A_DataConversionSetExpression, FXmlTagSIT.D_DataConversionSetExpression),
                        this.originalLength
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string encodingValue
        {
            get
            {
                try
                {
                    return FValueConverter.toDataConversionedEncodingValue(
                        this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagSIT.A_DataConversionSetExpression, FXmlTagSIT.D_DataConversionSetExpression)
                        );
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

        public int length
        {
            get
            {
                int length = 0;

                try
                {
                    length = this.originalLength;
                    FValueConverter.toDataConversionStringValue(
                        this.fFormat,
                        this.originalStringValue,
                        this.fXmlNode.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer),
                        this.fXmlNode.get_attrVal(FXmlTagSIT.A_DataConversionSetExpression, FXmlTagSIT.D_DataConversionSetExpression),
                        ref length
                        );
                    return length;
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

        public bool isArrayValue
        {
            get
            {
                FFormat fFormat;

                try
                {
                    fFormat = this.fFormat;
                    if (
                        fFormat == FFormat.List || 
                        fFormat == FFormat.AsciiList ||
                        fFormat == FFormat.Ascii ||
                        fFormat == FFormat.Char || 
                        fFormat == FFormat.JIS8 || 
                        fFormat == FFormat.A2 || 
                        fFormat == FFormat.Unknown || 
                        fFormat == FFormat.Raw
                        )
                    {
                        return false;
                    }
                    
                    // --                    

                    if (this.length > 1)
                    {
                        return true;
                    }
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

        public bool isNullValue
        {
            get
            {
                FFormat fFormat;

                try
                {
                    fFormat = this.fFormat;
                    if (
                        fFormat == FFormat.List ||                        
                        fFormat == FFormat.AsciiList ||
                        fFormat == FFormat.Unknown ||
                        fFormat == FFormat.Raw
                        )
                    {
                        return true;
                    }

                    // --                    

                    if (this.length == 0)
                    {
                        return true;
                    }
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

        public Type valueType
        {
            get
            {
                try
                {
                    return FValueConverter.getValueType(this.fFormat);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return typeof(object);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool randomValue
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSIT.A_RandomValue, FXmlTagSIT.D_RandomValue));
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

            set
            {
                string minValue = string.Empty;
                string maxValue = string.Empty;

                try
                {
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.A2 || fFormat == FFormat.Ascii || fFormat == FFormat.Char || fFormat == FFormat.JIS8)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Random Value"));
                    }

                    // --

                    if (value == true)
                    {
                        minValue = FValueConverter.getDataTypeMin(this.valueType);
                        maxValue = FValueConverter.getDataTypeMax(this.valueType);
                    }

                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_RandomValueMin, FXmlTagSIT.D_RandomValueMin, minValue, false);
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_RandomValueMax, FXmlTagSIT.D_RandomValueMax, maxValue, false);
                    // --
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_RandomValue, FXmlTagSIT.D_RandomValue, FBoolean.fromBool(value), true);                    
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

        public string randomValueMin
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_RandomValueMin, FXmlTagSIT.D_RandomValueMin);
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
                    if (!this.randomValue)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Random Value", "True"));
                    }

                    if (fFormat == FFormat.F8)
                    {
                        if (!FSecsDriverCommon.validateFormatRange(FFormat.F4, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                        }

                        if (!FSecsDriverCommon.validateMinMax(FFormat.F4, value, randomValueMax))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                        }
                    }
                    else
                    {
                        if (!FSecsDriverCommon.validateFormatRange(fFormat, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                        }

                        if (!FSecsDriverCommon.validateMinMax(fFormat, value, randomValueMax))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Min"));
                        }
                    }
                    
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_RandomValueMin, FXmlTagSIT.D_RandomValueMin, value, true);                   
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

        public string randomValueMax
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_RandomValueMax, FXmlTagSIT.D_RandomValueMax);
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
                    if (!randomValue)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0011, "Random Value", "True"));
                    }

                    if (fFormat == FFormat.F8)
                    {
                        if (!FSecsDriverCommon.validateFormatRange(FFormat.F4, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                        }

                        if (!FSecsDriverCommon.validateMinMax(FFormat.F4, randomValueMin, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                        }
                    }
                    else
                    {
                        if (!FSecsDriverCommon.validateFormatRange(fFormat, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                        }

                        if (!FSecsDriverCommon.validateMinMax(fFormat, randomValueMin, value))
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0014, "Max"));
                        }
                    }
                    

                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_RandomValueMax, FXmlTagSIT.D_RandomValueMax, value, true);
                    // --
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

        public FSecsItemValueTransformer fValueTransformer
        {
            get
            {
                try
                {
                    return new FSecsItemValueTransformer(this);
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

        public FSecsItemPrecondition fPrecondition
        {
            get
            {
                try
                {
                    return new FSecsItemPrecondition(this);
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

        public string reservedWord
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_ReservedWord, FXmlTagSIT.D_ReservedWord);
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
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_ReservedWord, FXmlTagSIT.D_ReservedWord, value, true);
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

        public bool extraction
        {
            get
            {
                try
                {
                    return FBoolean.toBool(this.fXmlNode.get_attrVal(FXmlTagSIT.A_Extraction, FXmlTagSIT.D_Extraction));
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

            set
            {
                try
                {
                    fXmlNode.set_attrVal(FXmlTagSIT.A_Extraction, FXmlTagSIT.D_Extraction, FBoolean.fromBool(value), true);
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

        public FDataConversionSet fDataConversionSet
        {
            get
            {
                string id = string.Empty;
                string xpath = string.Empty;

                try
                {
                    id = this.fXmlNode.get_attrVal(FXmlTagSIT.A_DataConversionSetID, FXmlTagSIT.D_DataConversionSetID);
                    if (id == string.Empty)
                    {
                        return null;
                    }

                    // --

                    xpath =
                        FXmlTagSET.E_Setup +
                        "/" + FXmlTagDCD.E_DataConversionSetDefinition +
                        "/" + FXmlTagDCL.E_DataConversionSetList +
                        "/" + FXmlTagDCS.E_DataConversionSet + "[@" + FXmlTagDCS.A_UniqueId + "='" + id + "']";
                    // --
                    return new FDataConversionSet(this.fScdCore, this.fSecsDriver.fXmlNode.selectSingleNode(xpath));
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

        public string dataConversionSetName
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_DataConversionSetName, FXmlTagSIT.D_DataConversionSetName);
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
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_DataConversionSetName, FXmlTagSIT.D_DataConversionSetName, value, false);
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

        public string dataConversionSetExpression
        {
            get
            {
                try
                {
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_DataConversionSetExpression, FXmlTagSIT.D_DataConversionSetExpression);
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
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_DataConversionSetExpression, FXmlTagSIT.D_DataConversionSetExpression, value, false);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_UserTag1, FXmlTagSIT.D_UserTag1);
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
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_UserTag1, FXmlTagSIT.D_UserTag1, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_UserTag2, FXmlTagSIT.D_UserTag2);
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
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_UserTag2, FXmlTagSIT.D_UserTag2, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_UserTag3, FXmlTagSIT.D_UserTag3);
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
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_UserTag3, FXmlTagSIT.D_UserTag3, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_UserTag4, FXmlTagSIT.D_UserTag4);
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
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_UserTag4, FXmlTagSIT.D_UserTag4, value, true);
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
                    return this.fXmlNode.get_attrVal(FXmlTagSIT.A_UserTag5, FXmlTagSIT.D_UserTag5);
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
                    this.fXmlNode.set_attrVal(FXmlTagSIT.A_UserTag5, FXmlTagSIT.D_UserTag5, value, true);
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
        
        public FSecsItemCollection fChildSecsItemCollection
        {
            get
            {
                try
                {
                    return new FSecsItemCollection(this.fScdCore, this.fXmlNode.selectNodes(FXmlTagSIT.E_SecsItem));
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

        public FIObject fParent
        {
            get
            {
                FXmlNode fXmlNodeParent = null;
                string messageType = string.Empty;

                try
                {
                    fXmlNodeParent = this.fXmlNode.fParentNode;
                    if (fXmlNodeParent == null)
                    {
                        return null;
                    }

                    // --

                    if (fXmlNodeParent.name == FXmlTagSMG.E_SecsMessage)
                    {
                        messageType = fXmlNodeParent.get_attrVal(FXmlTagSMG.A_MessageType, FXmlTagSMG.D_MessageType);
                        if (messageType == FXmlTagSMG.M_Message)
                        {
                            return new FSecsMessage(this.fScdCore, fXmlNodeParent);
                        }
                        else if (messageType == FXmlTagSMG.M_MessageTransfer)
                        {
                            return new FSecsMessageTransfer(this.fScdCore, fXmlNodeParent);
                        }
                        return null;
                    }
                    return new FSecsItem(this.fScdCore, fXmlNodeParent);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fXmlNodeParent = null;
                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsItem fPreviousSibling
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

                    return new FSecsItem(this.fScdCore, this.fXmlNode.fPreviousSibling);
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

        public FSecsItem fNextSibling
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

                    return new FSecsItem(this.fScdCore, this.fXmlNode.fNextSibling);
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
                    return this.fXmlNode.containsNode(FXmlTagSIT.E_SecsItem);
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

        public bool hasFixedChild
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Fixed) + "']";
                    return this.fXmlNode.containsNode(xpath);
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

        public bool hasVariableChild
        {
            get
            {
                string xpath = string.Empty;

                try
                {
                    xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Pattern + "='" + FEnumConverter.fromPattern(FPattern.Variable) + "']";
                    return this.fXmlNode.containsNode(xpath);
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

        public bool hasValueTransformer
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer) == string.Empty)
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

        public bool hasDataConversionSet
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagSIT.A_DataConversionSetID, FXmlTagSIT.D_DataConversionSetID) == string.Empty)
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

        public bool hasPrecondition
        {
            get
            {
                try
                {
                    if (this.fXmlNode.get_attrVal(FXmlTagSIT.A_Precondition, FXmlTagSIT.D_Precondition) == string.Empty)
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

        public bool canAppendChild
        {
            get
            {
                try
                {
                    // ***
                    // SECS Item Format이 List인 경우에만 Child Item를 가질 수 있다. (SECS Protocol)                    
                    // ***
                    if (this.fFormat == FFormat.List || this.fFormat == FFormat.AsciiList)
                    {
                        return true;
                    }
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

        public bool canInsertBefore
        {
            get
            {
                FIObject fParent = null;

                try
                {
                    // ***
                    // Parent가 존재하지 않거나 Parent가 SECS Message일 경우, Insert 작업을 수행할 없다.
                    // ***
                    fParent = this.fParent;
                    if (fParent == null || fParent.fObjectType == FObjectType.SecsMessage)
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
                    fParent = null;
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

        public bool canUseValueTransformer
        {
            get
            {
                FFormat fFormat;

                try
                {
                    fFormat = this.fFormat;
                    
                    // --

                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
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

        public bool canUsePrecondition
        {
            get
            {
                FFormat fFormat;

                try
                {
                    fFormat = this.fFormat;

                    // --

                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
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

                    // --
                    
                    if (this.fPattern == FPattern.Variable)
                    {
                        if (
                            this.fPreviousSibling.fPattern == FPattern.Fixed && 
                            this.fNextSibling != null && 
                            this.fNextSibling.fPattern == FPattern.Variable
                            )
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (
                            this.fPreviousSibling.fPattern == FPattern.Variable && 
                            this.fPreviousSibling.fPreviousSibling != null && 
                            this.fPreviousSibling.fPreviousSibling.fPattern == FPattern.Variable
                            )
                        {
                            return false;
                        }
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

                    // --
                    
                    if (this.fPattern == FPattern.Variable)
                    {
                        if (
                            this.fNextSibling.fPattern == FPattern.Fixed && 
                            this.fPreviousSibling != null && 
                            this.fPreviousSibling.fPattern == FPattern.Variable
                            )
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (
                            this.fNextSibling.fPattern == FPattern.Variable && 
                            this.fNextSibling.fNextSibling != null && 
                            this.fNextSibling.fNextSibling.fPattern == FPattern.Variable
                            )
                        {
                            return false;
                        }
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

        public FSecsLibrary fAncestorSecsLibrary
        {
            get
            {
                try
                {
                    return this.getAncestorSecsLibrary();
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

        public FSecsMessage fAncestorSecsMessage
        {
            get
            {
                try
                {
                    return this.getAncestorSecsMessage();
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
                FSecsMessage fSmg = null;
                string xpath = string.Empty;

                try
                {
                    fSmg = this.fAncestorSecsMessage;
                    if (fSmg == null)
                    {
                        xpath = "NULL";
                    }
                    else
                    {
                        xpath =
                            "../../../../../../" + FXmlTagEQM.E_EquipmentModeling +
                            "/" + FXmlTagEQP.E_Equipment +
                            "/" + FXmlTagSNG.E_ScenarioGroup +
                            "/" + FXmlTagSNR.E_Scenario +
                            "/" + FXmlTagSTR.E_SecsTrigger +
                            "/" + FXmlTagSCN.E_SecsCondition +
                            "//" + FXmlTagSEP.E_SecsExpression + "[@" + FXmlTagSEP.A_OperandId + "='" + this.uniqueIdToString + "']";
                    }
                    // --
                    return new FObjectCollection(this.fScdCore, fSmg.fXmlNode.selectNodes(xpath));
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    fSmg = null;
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
                    return new FObjectCollection(this.fScdCore, this.fXmlNode.selectNodes("NULL"));
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
                        !FClipboard.containsData(FCbObjectFormat.SecsItem) || 
                        (this.fParent.fObjectType == FObjectType.SecsMessage && this.fParent.hasChild)
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
                    if (
                        !FClipboard.containsData(FCbObjectFormat.SecsItem) ||
                        (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public string ToString(
            FStringOption option
            )
        {
            StringBuilder info = null;
            int length = 0;
            string value = string.Empty;            

            try
            {
                info = new StringBuilder();
                
                // --

                if (option == FStringOption.Default)
                {
                    info.Append(this.name); 
                }
                else
                {
                    if (fPattern == FPattern.Fixed && this.fixedLength > 1)
                    {
                        info.Append("[fx(" + this.fixedLength.ToString() + ").] ");
                    }
                    else if (fPattern == FPattern.Variable)
                    {
                        info.Append("[vr.] ");
                    }
                    
                    // --

                    if (this.hasValueTransformer)
                    {
                        info.Append("[vt.] ");
                    }

                    // --

                    if (this.hasDataConversionSet)
                    {
                        info.Append("[dc.] ");
                    }

                    // --

                    if (this.hasPrecondition)
                    {
                        info.Append("[pc.] ");
                    }

                    // --

                    // ***
                    // 2017.03.27 by spike.lee Scan Mode Attribute 추가
                    // ***
                    if (this.fScanMode == FDataScanMode.Global)
                    {
                        info.Append("[g.]");
                    }

                    // --

                    info.Append(FEnumConverter.fromFormat(fFormat));
                    length = this.originalLength;
                    // --
                    if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                    {
                        info.Append("[" + length.ToString() + "] " + this.name);
                    }
                    else if (fFormat == FFormat.Ascii || fFormat == FFormat.JIS8 || fFormat == FFormat.A2 || fFormat == FFormat.Char)
                    {
                        value = FValueConverter.toDataConversionedEncodingValue(
                            fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer),
                            this.dataConversionSetExpression,
                            ref length
                            );                        

                        // --
                        
                        // ***
                        // 2014.04.21 by spike.lee
                        // 데이터 표시 길이 제한 (Client 과부하 문제 해결)
                        // ***
                        info.Append("[" + length.ToString() + "] " + this.name + "=\"");
                        // --
                        if (value.Length > 1000)
                        {
                            info.Append(value.Substring(0, 1000));
                        }
                        else
                        {
                            info.Append(value);
                        }
                        // --
                        info.Append("\"");
                    }
                    else
                    {
                        value = FValueConverter.toDataConversionStringValue(
                            fFormat,
                            this.originalStringValue,
                            this.fXmlNode.get_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer),
                            this.dataConversionSetExpression,
                            ref length
                            );

                        // --

                        // ***
                        // 2014.04.21 by spike.lee
                        // 데이터 표시 길이 제한 (Client 과부하 문제 해결)
                        // ***
                        info.Append("[" + length.ToString() + "] " + this.name + "=\"");
                        // --
                        if (value.Length > 1000)
                        {
                            info.Append(value.Substring(0, 1000));
                        }
                        else
                        {
                            info.Append(value);
                        }
                        // --
                        info.Append("\"");
                    }
                }                
                
                // --
                
                if (this.description != string.Empty)
                {
                    info.Append(" Desc=[" + this.description + "]");
                }
                // --
                return info.ToString();
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

        public FSecsItem appendChildSecsItem(
            FSecsItem fNewChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                
                // ***
                // Format이 List인 SECS Item만이 Child SECS Item를 가질 수 있다.
                // ***
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Item's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child SECS Item만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.appendChild(fNewChild.fXmlNode));                

                // --

                // ***
                // 현재 SECS Item의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, (this.originalLength + 1).ToString());

                // --

                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --
                    this.fScdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectAppendCompleted, this.fSecsDriver, this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this.fParent, this)
                        });
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

        public FSecsItem appendChildSecsItem(
            FSecsDriver fSecsDriver,
            string name,
            FFormat fFormat,
            string stringValue
            )
        {
            try
            {
                return appendChildSecsItem(new FSecsItem(fSecsDriver, name, fFormat, stringValue));
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

        public FSecsItem insertBeforeChildSecsItem(
            FSecsItem fNewChild,
            FSecsItem fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);
                // --
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Item's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child SECS Item만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertBefore(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 SECS Item의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, (this.originalLength + 1).ToString());

                // --

                // ***
                // 추가된 Child의 Previous SECS Item과 Next SECS Item의 Pattern이 Variable일 경우,
                // 추가된 Child의 Pattern를 Variable로 설정한다.
                // ***                
                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
                }
                
                // --                
                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --                    
                    this.fScdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectInsertBeforeCompleted, this.fSecsDriver, this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this.fParent, this)
                        });
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

        public FSecsItem insertBeforeChildSecsItem(
            FSecsDriver fSecsDriver,
            string name,
            FFormat fFormat,
            string stringValue,
            FSecsItem fRefChild
            )
        {
            try
            {
                return insertBeforeChildSecsItem(
                    new FSecsItem(fSecsDriver, name, fFormat, stringValue),
                    fRefChild
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

        public FSecsItem insertAfterChildSecsItem(
            FSecsItem fNewChild, 
            FSecsItem fRefChild
            )
        {
            try
            {
                FSecsDriverCommon.validateNewChildObject(fNewChild.fXmlNode);
                FSecsDriverCommon.validateRefChildObject(this.fXmlNode, fRefChild.fXmlNode);
                // --
                if (this.fFormat != FFormat.List && this.fFormat != FFormat.AsciiList)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Item's Format", "List or the AsciiList"));
                }

                // ***
                // Format이 AsciiList인 경우 Ascii Format의 Child SECS Item만을 가질 수 있다.
                // ***
                if (this.fFormat == FFormat.AsciiList && fNewChild.fFormat != FFormat.Ascii)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Format of New Child", "Ascii"));
                }

                // --

                fNewChild.replace(this.fScdCore, this.fXmlNode.insertAfter(fNewChild.fXmlNode, fRefChild.fXmlNode));

                // --

                // ***
                // 현재 SECS Item의 Length 1 증가
                // ***
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, (this.originalLength + 1).ToString());

                // --

                // ***
                // 추가된 Child의 Previous SECS Item과 Next SECS Item의 Pattern이 Variable일 경우,
                // 추가된 Child의 Pattern를 Variable로 설정한다.
                // ***                
                if (
                    (fNewChild.fPreviousSibling != null && fNewChild.fPreviousSibling.fPattern == FPattern.Variable) &&
                    (fNewChild.fNextSibling != null && fNewChild.fNextSibling.fPattern == FPattern.Variable)
                    )
                {
                    fNewChild.fXmlNode.set_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Variable));
                }

                // --                
                
                if (this.isModelingObject)
                {
                    FSecsDriverCommon.resetUniqueId(this.fScdCore.fIdPointer, fNewChild.fXmlNode);
                    // --                    
                    this.fScdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                        new FObjectEventArgs(FEventId.ObjectInsertAfterCompleted, this.fSecsDriver, this, fNewChild),
                        new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, this.fParent, this)
                        });
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

        public FSecsItem insertAfterChildSecsItem(
            FSecsDriver fSecsDriver,
            string name,
            FFormat fFormat,
            string stringValue,
            FSecsItem fRefChild
            )
        {
            try
            {
                return insertAfterChildSecsItem(
                    new FSecsItem(fSecsDriver, name, fFormat, stringValue),
                    fRefChild
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

        public void remove(
            )
        {
            FIObject fParent = null;
            bool isModelingObject = false;
            int length = 0;

            try
            {
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode.fParentNode, this.fXmlNode);

                // --

                // ***
                // 2013.08.12 by spike.lee
                // DataConversionSet Reset Add
                // ***
                resetRelation();

                // --

                isModelingObject = this.isModelingObject;
                fParent = this.fParent;                                                
                if (fParent.fObjectType == FObjectType.SecsMessage)
                {
                    this.replace(this.fScdCore, ((FSecsMessage)fParent).fXmlNode.removeChild(this.fXmlNode));
                }
                else if (fParent.fObjectType == FObjectType.SecsMessageTransfer)
                {
                    this.replace(this.fScdCore, ((FSecsMessageTransfer)fParent).fXmlNode.removeChild(this.fXmlNode));
                }
                else
                {
                    this.replace(this.fScdCore, ((FSecsItem)fParent).fXmlNode.removeChild(this.fXmlNode));
                    // --
                    length = int.Parse(((FSecsItem)fParent).fXmlNode.get_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length)) - 1;
                    ((FSecsItem)fParent).fXmlNode.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, length.ToString());
                }

                // --

                // ***
                // Remove 시, Pattern(Fixed)과 Fixed Length(1) 초기화
                // ***
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_FixedLength, FXmlTagSIT.D_FixedLength, "1");

                // --

                if (isModelingObject)
                {
                    if (fParent.fObjectType == FObjectType.SecsMessage)
                    {
                        this.fScdCore.fEventPusher.pushEvent(
                            new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fSecsDriver, fParent, this)
                            );
                    }
                    else
                    {
                        this.fScdCore.fEventPusher.pushEvent(new FEventArgsBase[]{
                            new FObjectEventArgs(FEventId.ObjectRemoveCompleted, this.fSecsDriver, fParent, this),
                            new FObjectEventArgs(FEventId.ObjectModifyCompleted, this.fSecsDriver, ((FSecsItem)fParent).fParent, fParent)
                            });
                    }                                       
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

        public FSecsItem removeChildSecsItem(
            FSecsItem fChild
            )
        {
            try
            {
                FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fChild.fXmlNode);

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

        public void removeChildSecsItem(
            FSecsItem[] fChilds
            )
        {
            try
            {
                if (fChilds.Length == 0)
                {
                    return;
                }

                // --

                foreach (FSecsItem fSit in fChilds)
                {
                    FSecsDriverCommon.validateRemoveChildObject(this.fXmlNode, fSit.fXmlNode);
                }

                // --

                foreach (FSecsItem fSit in fChilds)
                {
                    fSit.remove();      
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

        public void removeAllChildSecsItem(
            )
        {
            FSecsItemCollection fSitCollection = null;

            try
            {
                fSitCollection = this.fChildSecsItemCollection;               
                if (fSitCollection.count == 0)
                {
                    return;
                }

                // --

                foreach (FSecsItem fSit in fSitCollection)
                {
                    if (fSit.locked)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Object"));
                    }
                }

                // --

                foreach (FSecsItem fSit in fSitCollection)
                {
                    fSit.remove();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fSitCollection != null)
                {
                    fSitCollection.Dispose();
                    fSitCollection = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveUp(
            )
        {
            bool isModelingObject = false;

            try
            {
                FSecsDriverCommon.validateMoveUpObject(this.fXmlNode);
                // --
                if (!this.canMoveUp)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0021, "Object"));
                }

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveUp());

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveUpCompleted, this.fSecsDriver, fParent, this)
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
                FSecsDriverCommon.validateMoveDownObject(this.fXmlNode);
                // --
                if (!this.canMoveDown)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0022, "Object"));
                }

                // --

                isModelingObject = this.isModelingObject;
                this.replace(this.fScdCore, this.fXmlNode.moveDown());

                // --

                if (isModelingObject)
                {
                    this.fScdCore.fEventPusher.pushEvent(
                        new FObjectEventArgs(FEventId.ObjectMoveDownCompleted, this.fSecsDriver, fParent, this)
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
            FSecsItem fRefObject
            )
        {
            FSecsItem fOldParent = null;

            try
            {
                FSecsDriverCommon.validateMoveToObject(this.fXmlNode, fRefObject.fXmlNode);

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

                if (!this.fAncestorSecsMessage.Equals(fRefObject.fAncestorSecsMessage))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0061, "Ancestor SECS Message ", "same"));
                }

                if (fRefObject.fParent.fObjectType == FObjectType.SecsMessage)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "SECS Item to SECS Message"));
                }

                if (this.containsObject(fRefObject))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0060, "Object", "Child"));
                }

                if (((FSecsItem)fRefObject.fParent).hasVariableChild)
                {
                    if (this.fPattern == FPattern.Variable)
                    {
                        if (
                            fRefObject.fPattern != FPattern.Variable && 
                            (fRefObject.fNextSibling == null || fRefObject.fNextSibling.fPattern == FPattern.Fixed)
                            )
                        {
                            if (
                                !this.fParent.Equals(fRefObject.fParent) ||
                                (this.fPreviousSibling != null && this.fPreviousSibling.fPattern == FPattern.Variable) ||
                                (this.fNextSibling != null && this.fNextSibling.fPattern == FPattern.Variable)
                                )
                            {
                                FDebug.throwFException(string.Format(FConstants.err_m_0011, "Pattern of the Previous SECS Item and the Next SECS Item", "Variable"));
                            }
                        }
                    }
                    else
                    {
                        if (
                            fRefObject.fPattern != FPattern.Fixed &&
                            fRefObject.fNextSibling != null &&
                            fRefObject.fNextSibling.fPattern != FPattern.Fixed
                            )
                        {
                            FDebug.throwFException(string.Format(FConstants.err_m_0010, "Pattern of the Previous SECS Item and the Next SECS Item", "Variable"));
                        }
                    }
                }

                // --

                fOldParent = (FSecsItem)(this.fParent);

                // --                

                this.replace(this.fScdCore, this.fXmlNode.fParentNode.removeChild(this.fXmlNode));
                this.replace(this.fScdCore, fRefObject.fXmlNode.fParentNode.insertAfter(this.fXmlNode, fRefObject.fXmlNode));

                // --

                if (!this.fParent.Equals(fOldParent))
                {
                    if (this.locked)
                    {
                        fOldParent.unlockObject();
                        ((FSecsItem)this.fParent).lockObject(); 
                    }
                    // --
                    fOldParent.fXmlNode.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, (fOldParent.length - 1).ToString(), true);
                    ((FSecsItem)this.fParent).fXmlNode.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, (((FSecsItem)this.fParent).length + 1).ToString(), true);                  
                }

                // --

                this.fScdCore.fEventPusher.pushEvent(
                    new FObjectMoveToCompletedEventArgs(FEventId.ObjectMoveToCompleted, this.fSecsDriver, this, fRefObject)
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOldParent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setChangedFormat(
            )
        {
            try
            {
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_LengthBytes, FXmlTagSIT.D_LengthBytes, FXmlTagSIT.D_LengthBytes);
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_Value, FXmlTagSIT.D_Value, FXmlTagSIT.D_Value);
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_Length, FXmlTagSIT.D_Length, FXmlTagSIT.D_Length);
                // --
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_Transformer, FXmlTagSIT.D_Transformer, FXmlTagSIT.D_Transformer);
                // --
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_Precondition, FXmlTagSIT.D_Precondition, FXmlTagSIT.D_Precondition);
                // --
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_RandomValue, FXmlTagSIT.D_RandomValue, FXmlTagSIT.D_RandomValue);
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_RandomValueMin, FXmlTagSIT.D_RandomValueMin, FXmlTagSIT.D_RandomValueMin);
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_RandomValueMax, FXmlTagSIT.D_RandomValueMax, FXmlTagSIT.D_RandomValueMax);

                // --

                resetRelation();
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

                // ***
                // SECS Item에 대한 Lock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_Locked, FXmlTagSIT.D_Locked, FBoolean.True, true);

                // --

                // ***
                // Parent SECS Item에 대한 Lock 처리
                // ***
                if (this.fParent.fObjectType == FObjectType.SecsItem)
                {
                    ((FSecsItem)this.fParent).lockObject();
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
                // Lock이 설정된 자식 SECS Item이 존재할 경우 Unlock 작업을 취소한다.
                // ***
                xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Locked + "='" + FBoolean.True + "']";
                if (this.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // ***
                // SECS Item이 SECS Expression에 사용되었을 경우 Unlock 작업을 취소한다.
                // ***
                xpath =
                    FXmlTagEQM.E_EquipmentModeling +
                    "/" + FXmlTagEQP.E_Equipment +
                    "/" + FXmlTagSNG.E_ScenarioGroup +
                    "/" + FXmlTagSNR.E_Scenario +
                    "/" + FXmlTagSTR.E_SecsTrigger +
                    "/" + FXmlTagSCN.E_SecsCondition +
                    "//" + FXmlTagSEP.E_SecsExpression + "[@" + FXmlTagSEP.A_OperandId + "='" + this.uniqueIdToString + "']";                                    
                if (this.fSecsDriver.fXmlNode.containsNode(xpath))
                {
                    return;
                }

                // --

                // ***
                // SECS Item에 대한 Unlock 처리
                // ***
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_Locked, FXmlTagSIT.D_Locked, FBoolean.False, true);

                // --

                // ***
                // Parent SECS Item에 대한 Unlcok 처리
                // ***
                if (this.fParent.fObjectType == FObjectType.SecsItem)
                {
                    ((FSecsItem)this.fParent).unlockObject();
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

        public void cut(
            )
        {
            try
            {
                FSecsDriverCommon.validateCutObject(this.fXmlNode);

                // --

                this.remove();

                // --

                resetFlowNode(this.fXmlNode);
                this.copyObject(FCbObjectFormat.SecsItem, this.fXmlNode);
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

                // ***
                // Copy 시, Pattern(Fixed)과 Fixed Length(1) 초기화
                // ***
                fXmlNode.set_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                fXmlNode.set_attrVal(FXmlTagSIT.A_FixedLength, FXmlTagSIT.D_FixedLength, "1");

                // --

                resetFlowNode(fXmlNode);
                this.copyObject(FCbObjectFormat.SecsItem, fXmlNode);
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

        public FSecsItem pasteSibling(
            )
        {
            FIObject fParent = null;
            FSecsItem fSecsItem = null;

            try
            {
                FSecsDriverCommon.validatePasteSiblingObject(this.fXmlNode, FCbObjectFormat.SecsItem);

                // --

                fParent = this.fParent;
                fSecsItem = (FSecsItem)this.pasteObject(FCbObjectFormat.SecsItem);
                // --
                if (
                    fParent.fObjectType == FObjectType.SecsMessage ||
                    fParent.fObjectType == FObjectType.SecsMessageTransfer
                    )
                {
                    if (this.fParent.canAppendChild)
                    {
                        if (fParent.fObjectType == FObjectType.SecsMessage)
                        {
                            return ((FSecsMessage)this.fParent).appendChildSecsItem(fSecsItem);
                        }
                        return ((FSecsMessageTransfer)this.fParent).appendChildSecsItem(fSecsItem);                        
                    }
                    else
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0018, "SECS Item", "1"));
                    }
                }                
                return ((FSecsItem)this.fParent).insertAfterChildSecsItem(fSecsItem, this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParent = null;
                fSecsItem = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsItem pasteChild(
            )
        {
            FSecsItem fSecsItem = null;

            try
            {
                FSecsDriverCommon.validatePasteChildObject(this.fXmlNode, FCbObjectFormat.SecsItem);

                // --

                fSecsItem = (FSecsItem)this.pasteObject(FCbObjectFormat.SecsItem);
                return this.appendChildSecsItem(fSecsItem);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsItem = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void setDataConversionSet(
            FDataConversionSet fDataConversionSet
            )
        {
            FFormat fFormat;
            string oldDcsId = string.Empty;
            string newDcsId = string.Empty;

            try
            {
                // ***
                // Data Conversion Set 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!fDataConversionSet.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Data Conversion Set", "Modeling File"));
                }

                // ***
                // 이 SECS Item 개체가 Modeling File에 포함된 개체인지 검사
                // ***
                if (!this.isModelingObject)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0017, "Secs Item", "Modeling File"));
                }

                // ***
                // Data Conversion Set와 Secs Item의 Modeling File이 동일한지 검사
                // ***
                if (!this.equalsModelingFile(fDataConversionSet))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0011, "Modeling File of the Data Conversion Set and the Secs Item", "same"));
                }

                // --

                fFormat = this.fFormat;
                if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Unknown || fFormat == FFormat.Raw)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0006, fFormat.ToString() + " Format", "Data Conversion Set"));
                }

                // --

                oldDcsId = this.fXmlNode.get_attrVal(FXmlTagSIT.A_DataConversionSetID, FXmlTagSIT.D_DataConversionSetID);
                newDcsId = fDataConversionSet.uniqueIdToString;
                if (oldDcsId == newDcsId)
                {
                    return;
                }

                // --

                if (oldDcsId != string.Empty)
                {
                    resetDataConversionSet(false);
                }

                // --
                
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_DataConversionSetExpression, FXmlTagSIT.D_DataConversionSetExpression, fDataConversionSet.expression, false);
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_DataConversionSetName, FXmlTagSIT.D_DataConversionSetName, fDataConversionSet.name, false);
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_DataConversionSetID, FXmlTagSIT.D_DataConversionSetID, newDcsId, true);
                // --
                fDataConversionSet.lockObject();
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

        internal void resetDataConversionSet(
            bool isModifyEvent
            )
        {
            FDataConversionSet fDcs = null;

            try
            {
                foreach (FSecsItem fSit in this.fChildSecsItemCollection)
                {
                    fSit.resetDataConversionSet(isModifyEvent);
                }

                // --

                fDcs = this.fDataConversionSet;
                if (fDcs == null)
                {
                    return;
                }

                // --

                this.fXmlNode.set_attrVal(FXmlTagSIT.A_DataConversionSetExpression, FXmlTagSIT.D_DataConversionSetExpression, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_DataConversionSetName, FXmlTagSIT.D_DataConversionSetName, string.Empty, false);
                this.fXmlNode.set_attrVal(FXmlTagSIT.A_DataConversionSetID, FXmlTagSIT.D_DataConversionSetID, string.Empty, isModifyEvent);
                // --
                fDcs.unlockObject();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDcs = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void resetDataConversionSet(
            )
        {
            try
            {
                resetDataConversionSet(true);
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

        internal void resetRelation(
            )
        {
            try
            {
                resetDataConversionSet(false);
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
                fXmlNode.set_attrVal(FXmlTagSIT.A_DataConversionSetExpression, FXmlTagSIT.D_DataConversionSetExpression, string.Empty);
                fXmlNode.set_attrVal(FXmlTagSIT.A_DataConversionSetName, FXmlTagSIT.D_DataConversionSetName, string.Empty);
                fXmlNode.set_attrVal(FXmlTagSIT.A_DataConversionSetID, FXmlTagSIT.D_DataConversionSetID, string.Empty);

                // --

                foreach (FXmlNode fXmlNodeSit in fXmlNode.selectNodes(FXmlTagSIT.E_SecsItem))
                {
                    FSecsItem.resetFlowNode(fXmlNodeSit);
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

        public FSecsItemCollection selectSecsItemByName(
            string name
            )
        {
            const string xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Name + "='{0}']";

            try
            {
                return new FSecsItemCollection(
                    this.fScdCore,
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

        public FSecsItem selectSingleSecsItemByName(
            string name
            )
        {
            const string xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        public FSecsItemCollection selectAllSecsItemByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Name + "='{0}']";

            try
            {
                return new FSecsItemCollection(
                    this.fScdCore,
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

        public FSecsItem selectSingleAllSecsItemByName(
            string name
            )
        {
            const string xpath = ".//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Name + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, name));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        public FSecsItemCollection selectSecsItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_ReservedWord + "='{0}']";

            try
            {
                return new FSecsItemCollection(
                    this.fScdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, reservedWord))
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

        public FSecsItem selectSingleSecsItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        public FSecsItemCollection selectAllSecsItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_ReservedWord + "='{0}']";

            try
            {
                return new FSecsItemCollection(
                    this.fScdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, reservedWord))
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

        public FSecsItem selectSingleAllSecsItemByReservedWord(
            string reservedWord
            )
        {
            const string xpath = ".//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_ReservedWord + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, reservedWord));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        public FSecsItemCollection selectSecsItemByExtraction(
            )
        {
            const string xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Extraction + "='{0}']";

            try
            {
                return new FSecsItemCollection(
                    this.fScdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, FBoolean.True))
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

        public FSecsItem selectSingleSecsItemByExtraction(
            )
        {
            const string xpath = FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        public FSecsItemCollection selectAllSecsItemByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Extraction + "='{0}']";

            try
            {
                return new FSecsItemCollection(
                    this.fScdCore,
                    this.fXmlNode.selectNodes(string.Format(xpath, FBoolean.True))
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

        public FSecsItem selectAllSingleSecsItemByExtraction(
            )
        {
            const string xpath = ".//" + FXmlTagSIT.E_SecsItem + "[@" + FXmlTagSIT.A_Extraction + "='{0}']";
            // --
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.selectSingleNode(string.Format(xpath, FBoolean.True));
                if (fXmlNode == null)
                {
                    return null;
                }
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        public FSecsItem selectSingleAllSecsItemByIndex(
            params object[] args
            )
        {
            FXmlNode fXmlNode = null;
            int index = 0;

            try
            {
                if (args == null || args.Length == 0)
                {
                    return null;
                }

                // --

                fXmlNode = this.fXmlNode;
                // --
                foreach (object obj in args)
                {
                    index = (int)obj;
                    // --
                    if (index >= fXmlNode.fChildNodes.count)
                    {
                        return null;
                    }
                    // --
                    fXmlNode = fXmlNode.fChildNodes[index];
                }
                // --
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        // ***
        // 2017.03.22 by spike.lee
        // 객체 Clone 기능 추가
        // ***
        public FSecsItem clone(
            )
        {
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = this.fXmlNode.clone(true);

                // --

                // ***
                // Clone 시, Pattern(Fixed)과 Fixed Length(1) 초기화
                // ***
                fXmlNode.set_attrVal(FXmlTagSIT.A_Pattern, FXmlTagSIT.D_Pattern, FEnumConverter.fromPattern(FPattern.Fixed));
                fXmlNode.set_attrVal(FXmlTagSIT.A_FixedLength, FXmlTagSIT.D_FixedLength, "1");

                // --

                resetFlowNode(fXmlNode);
                FSecsDriverCommon.resetLocked(fXmlNode);
                return new FSecsItem(this.fScdCore, fXmlNode);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
