﻿using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPatchLib.UnitTest.TestClass;

namespace XPatchLib.UnitTest
{
    [TestClass]
    public class TestJsonSerializer
    {
        #region Private Fields

        private const string ChangedContext = "{\"BookClass\":{\"Author\":{\"Name\":\"" + newAuthorName + "\"}}}";

        private const string newAuthorName = "Barack Obama";

        #endregion Private Fields

        #region Private Properties

        private BookClass OriObject
        {
            get
            {
                return BookClass.GetSampleInstance();
            }
        }

        private BookClass RevObject
        {
            get
            {
                BookClass revObj = BookClass.GetSampleInstance();
                    revObj.Author.Name = newAuthorName;
                return revObj;
            }
        }

        #endregion Private Properties

        #region Public Methods

        [TestMethod]
        [Description("测试JsonSerializer中参数类型为Stream的Divide和Combine方法")]
        public void TestJsonSerializerStreamDivideAndCombine()
        {
//            string s1 =
//"{\"AuthToken\": \"ASDAF\", \"ID\": 10, \"Data\": {\"key\": 2}}";
//            s1 = "{\"BookClass\":{\"Author\":{\"Name\":\"Barack Obama\"}}}";
//            byte[] bytes = Encoding.Unicode.GetBytes(s1);

            //using (XmlDictionaryReader reader =
            //    JsonReaderWriterFactory.CreateJsonReader(bytes,
            //     new XmlDictionaryReaderQuotas()))
            //{
            //    while (reader.Read())
            //    {
            //        Debug.WriteLine("Type={0}\tName={1}\tValue={2}",
            //            reader.NodeType, reader.Name, reader.Value);
            //        if (reader.AttributeCount > 0)
            //        {
            //            while (reader.MoveToNextAttribute())
            //            {
            //                Debug.WriteLine("Type={0}\tName={1}\tValue={2}",
            //                    reader.NodeType, reader.Name, reader.Value);
            //            }
            //        }
            //    }
            //}


            JsonSerializer serializer = new JsonSerializer(typeof(BookClass), true);
            using (var stream = new MemoryStream())
            {
                serializer.Divide(stream, OriObject, RevObject);
                var context = UnitTest.TestHelper.StreamToString(stream);
                Assert.AreEqual(ChangedContext, context);
            }
            serializer = new JsonSerializer(typeof(BookClass), true);
            string s = string.Empty;
            using (var stream = new MemoryStream())
            {
                serializer.Divide(stream, OriObject, RevObject);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    s= reader.ReadToEnd();
                }
            }
            byte[] byteArray = Encoding.UTF8.GetBytes(s);
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                var changedObj = serializer.Combine(ms, OriObject, true) as BookClass;
                Assert.AreEqual(RevObject, changedObj);
            }
        }

        [TestMethod]
        [Description("测试JsonSerializer中参数类型为TextWriter的Divide方法和TextReader的Combine方法")]
        public void TestJsonSerializerTextWriterDivideAndTextReaderCombine()
        {
            JsonSerializer serializer = new JsonSerializer(typeof(BookClass), true);
            var sb = new StringBuilder();
            using (var swr = new StringWriter(sb))
            {
                serializer.Divide(swr, OriObject, RevObject);
                sb.Replace("utf-16", "utf-8");
                Assert.AreEqual(ChangedContext, sb.ToString());
            }
            Assert.Fail("Not Complete");
            //serializer = new JsonSerializer(typeof(BookClass));
            //using (var reader = new StringReader(ChangedContext))
            //{
            //    var changedObj = serializer.Combine(reader, OriObject) as BookClass;
            //    Assert.AreEqual(RevObject, changedObj);
            //}
        }

        [TestMethod]
        [Description("测试JsonSerializer中参数类型为XmlWriter的Divide方法和XmlReader的Combine方法")]
        public void TestJsonSerializerXmlWriterDivideAndXmlReaderCombine()
        {
            Assert.Fail("Not Complete");
            //JsonSerializer serializer = new JsonSerializer(typeof(BookClass), true);
            //using (var stream = new MemoryStream())
            //{
            //    var setting = new XmlWriterSettings();
            //    setting.Encoding = new UTF8Encoding(false);
            //    setting.Indent = true;
            //    using (var xwr = XmlWriter.Create(stream, setting))
            //    {
            //        serializer.Divide(xwr, OriObject, RevObject);
            //        Assert.AreEqual(ChangedContext, Encoding.UTF8.GetString(stream.ToArray()));
            //    }
            //}
            //serializer = new JsonSerializer(typeof(BookClass));
            //using (var stream = new MemoryStream())
            //{
            //    serializer.Divide(stream, OriObject, RevObject);
            //    stream.Position = 0;
            //    using (var reader = XmlReader.Create(stream))
            //    {
            //        var changedObjByReader = serializer.Combine(reader, OriObject) as BookClass;
            //        Assert.AreEqual(RevObject, changedObjByReader);
            //    }
            //}
        }

        #endregion Public Methods
    }
}