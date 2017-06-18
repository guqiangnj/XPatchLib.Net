﻿// Copyright © 2013-2017 - GuQiang
// Licensed under the LGPL-3.0 license. See LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
#if (NET_35_UP || NETSTANDARD)
using System.Xml.Linq;
#endif
using NUnit.Framework;

namespace XPatchLib.UnitTest.ForXml
{
    internal static class TestHelper
    {
        internal const string XmlHeaderContext = @"<?xml version=""1.0"" encoding=""utf-8""?>";

        internal static XmlWriterSettings DocumentSetting
        {
            get
            {
                var settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = false;
                return settings;
            }
        }

        internal static XmlWriterSettings FlagmentSetting
        {
            get
            {
                var settings = new XmlWriterSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                settings.Indent = true;
                settings.Encoding = new UTF8Encoding(false);
                settings.OmitXmlDeclaration = false;
                return settings;
            }
        }

        internal static ITextWriter CreateWriter(Stream output)
        {
            return CreateWriter(output, FlagmentSetting);
        }

        internal static ITextWriter CreateWriter(Stream output, XmlWriterSettings settings)
        {
            return new XmlTextWriter(XmlWriter.Create(output, settings));
        }

        #region Internal Methods

        internal static void PrivateAssert(Type pType, object pOriObj, object pChangedObj, string pChangedContext,
            string pAssert)
        {
            PrivateAssert(pType, pOriObj, pChangedObj, pChangedContext, pAssert,
                DateTimeSerializationMode.RoundtripKind);
        }

        internal static void PrivateAssert(Type pType, object pOriObj, object pChangedObj, string pChangedContext,
            string pAssert, DateTimeSerializationMode pMode)
        {
            using (var stream = new MemoryStream())
            {
                using (ITextWriter writer = CreateWriter(stream))
                {
                    writer.Setting.Mode = pMode;
                    Assert.IsTrue(
                        new DivideCore(writer, new TypeExtend(pType, writer.IgnoreAttributeType)).Divide(
                            ReflectionUtils.GetTypeFriendlyName(pType), pOriObj, pChangedObj));
                }

                using (XmlReader xmlReader = XmlReader.Create(stream))
                {
                    using (XmlTextReader reader = new XmlTextReader(xmlReader))
                    {
                        reader.Setting.Mode = pMode;
                        var combinedObj = new CombineCore(new TypeExtend(pType, null)).Combine(reader, pOriObj,
                            ReflectionUtils.GetTypeFriendlyName(pType));

                        AssertHelper.AreEqual(pChangedContext, stream, pAssert);

                        UnitTest.TestHelper.PrivateAssertObject(pChangedObj, combinedObj, pAssert);
                    }
                }
            }
        }

        internal static void PrivateAssertIEnumerable<T>(Type pType, object pOriObj, object pChangedObj,
            string pChangedContext, string pAssert)
        {
            PrivateAssertIEnumerable<T>(pType, pOriObj, pChangedObj, pChangedContext, pAssert,
                DateTimeSerializationMode.RoundtripKind);
        }

        internal static void PrivateAssertIEnumerable<T>(Type pType, object pOriObj, object pChangedObj,
            string pChangedContext, string pAssert, DateTimeSerializationMode pMode)
        {
            using (var stream = new MemoryStream())
            {
                using (ITextWriter writer = CreateWriter(stream, FlagmentSetting))
                {
                    writer.Setting.Mode = pMode;
                    Assert.IsTrue(
                        new DivideCore(writer, new TypeExtend(pType, writer.IgnoreAttributeType)).Divide(
                            ReflectionUtils.GetTypeFriendlyName(pType), pOriObj, pChangedObj));
                }
                using (XmlReader xmlReader = XmlReader.Create(stream))
                {
                    using (XmlTextReader reader = new XmlTextReader(xmlReader))
                    {
                        reader.Setting.Mode = pMode;
                        var combinedObj = new CombineCore(new TypeExtend(pType, null)).Combine(reader, pOriObj,
                            ReflectionUtils.GetTypeFriendlyName(pType));

#if (NET || NETSTANDARD_2_0_UP)
                        Trace.WriteLine(pChangedContext);
#endif

                        AssertHelper.AreEqual(pChangedContext, stream, pAssert);

                        UnitTest.TestHelper.PrivateAssertIEnumerable<T>(pChangedObj, combinedObj, pType, pAssert);
                    }
                }
            }
        }

#endregion Internal Methods
    }
}