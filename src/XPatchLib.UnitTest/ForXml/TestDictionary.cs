﻿// Copyright © 2013-2017 - GuQiang
// Licensed under the LGPL-3.0 license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using NUnit.Framework;
#if (NET_35_UP || NETSTANDARD)
using System.Xml.Linq;
#endif

namespace XPatchLib.UnitTest.ForXml
{
    [TestFixture]
    public class TestDictionary:TestBase
    {
        [SetUp]
        public void Init()
        {
            _oriDic = new Dictionary<string, string>(4);
            _oriDic.Add("Akey", "Avalue");
            _oriDic.Add("Bkey", "Bvalue");
            _oriDic.Add("Ckey", "Cvalue");
            _oriDic.Add("Dkey", "Dvalue");

            _complex_Changed_Dic = new Dictionary<string, string>();
            _complex_Changed_Dic.Add("Akey", "Avalue");
            _complex_Changed_Dic.Add("Bkey", "newBkey");
            _complex_Changed_Dic.Add("Dkey", null);
            _complex_Changed_Dic.Add("Ekey", "EValue");

            _edit_Dic = new Dictionary<string, string>(4);
            _edit_Dic.Add("Akey", "newAvalue");
            _edit_Dic.Add("Bkey", "newBvalue");
            _edit_Dic.Add("Ckey", "newCvalue");
            _edit_Dic.Add("Dkey", "newDvalue");

            _create_Dic=new Dictionary<string, string>(4);
            _create_Dic.Add("Akey", "Avalue");
            _create_Dic.Add("Bkey", "Bvalue");
            _create_Dic.Add("Ckey", "Cvalue");
            _create_Dic.Add("Dkey", "Dvalue");

            _remove_Dic=new Dictionary<string, string>(2);
            _remove_Dic.Add("Akey", "Avalue");
            _remove_Dic.Add("Bkey", "Bvalue");

            _setNull_Dic = new Dictionary<string, string>(4);
            _setNull_Dic.Add("Akey", null);
            _setNull_Dic.Add("Bkey", null);
            _setNull_Dic.Add("Ckey", null);
            _setNull_Dic.Add("Dkey", null);

            _Dic_Array = new Dictionary<string, string>[]
                {_complex_Changed_Dic, _edit_Dic, _create_Dic, _remove_Dic, _setNull_Dic};
            _Context_Array = new string[]
            {
                ComplexOperatorChangedContext, EditChangedContext, CreateChangedContext, RemoveChangedContext,
                SetNullChangedContext
            };
        }
        #region 字典对象定义
        //原始字典对象
        private Dictionary<string, string> _oriDic;
        //包含各种变更的复杂变更后的字典对象
        private Dictionary<string, string> _complex_Changed_Dic;
        //变更后的字典对象
        private Dictionary<string, string> _edit_Dic;
        //从Null开始创建的字典对象
        private Dictionary<string, string> _create_Dic;
        //Remove子项后的字典对象
        private Dictionary<string, string> _remove_Dic;
        //将所有子项的Value值设置为Null以后的字典对象
        private Dictionary<string, string> _setNull_Dic;
        #endregion
        private Dictionary<string,string>[] _Dic_Array;
        private string[] _Context_Array;

        #region 变更字符串定义

        private const string ComplexOperatorChangedContext = @"<Dictionary_String_String>
  <KeyValuePair_String_String Action=""Remove"">
    <Key>Ckey</Key>
  </KeyValuePair_String_String>
  <KeyValuePair_String_String>
    <Key>Bkey</Key>
    <Value>newBkey</Value>
  </KeyValuePair_String_String>
  <KeyValuePair_String_String Action=""SetNull"">
    <Key>Dkey</Key>
  </KeyValuePair_String_String>
  <KeyValuePair_String_String Action=""Add"">
    <Key>Ekey</Key>
    <Value>EValue</Value>
  </KeyValuePair_String_String>
</Dictionary_String_String>";

        private const string CreateChangedContext = @"<Dictionary_String_String>
  <KeyValuePair_String_String Action=""Add"">
    <Key>Akey</Key>
    <Value>Avalue</Value>
  </KeyValuePair_String_String>
  <KeyValuePair_String_String Action=""Add"">
    <Key>Bkey</Key>
    <Value>Bvalue</Value>
  </KeyValuePair_String_String>
  <KeyValuePair_String_String Action=""Add"">
    <Key>Ckey</Key>
    <Value>Cvalue</Value>
  </KeyValuePair_String_String>
  <KeyValuePair_String_String Action=""Add"">
    <Key>Dkey</Key>
    <Value>Dvalue</Value>
  </KeyValuePair_String_String>
</Dictionary_String_String>";

        private const string EditChangedContext = @"<Dictionary_String_String>
  <KeyValuePair_String_String>
    <Key>Akey</Key>
    <Value>newAvalue</Value>
  </KeyValuePair_String_String>
  <KeyValuePair_String_String>
    <Key>Bkey</Key>
    <Value>newBvalue</Value>
  </KeyValuePair_String_String>
  <KeyValuePair_String_String>
    <Key>Ckey</Key>
    <Value>newCvalue</Value>
  </KeyValuePair_String_String>
  <KeyValuePair_String_String>
    <Key>Dkey</Key>
    <Value>newDvalue</Value>
  </KeyValuePair_String_String>
</Dictionary_String_String>";

        private const string RemoveChangedContext = @"<Dictionary_String_String>
  <KeyValuePair_String_String Action=""Remove"">
    <Key>Ckey</Key>
  </KeyValuePair_String_String>
  <KeyValuePair_String_String Action=""Remove"">
    <Key>Dkey</Key>
  </KeyValuePair_String_String>
</Dictionary_String_String>";

        private const string SetNullChangedContext = @"<Dictionary_String_String>
  <KeyValuePair_String_String Action=""SetNull"">
    <Key>Akey</Key>
  </KeyValuePair_String_String>
  <KeyValuePair_String_String Action=""SetNull"">
    <Key>Bkey</Key>
  </KeyValuePair_String_String>
  <KeyValuePair_String_String Action=""SetNull"">
    <Key>Ckey</Key>
  </KeyValuePair_String_String>
  <KeyValuePair_String_String Action=""SetNull"">
    <Key>Dkey</Key>
  </KeyValuePair_String_String>
</Dictionary_String_String>";
        #endregion

        #region 原始对象附加增量字符串以后的对象实例与预期对象实例间的对比
        [Test]
        [Description("检测CombineCore的Combine方法对字典类型对象的合并操作")]
        public void TestCombineCore_Combine_Dictionary()
        {
            for (int i = 0; i < _Context_Array.Length; i++)
            {
                var newDic = DoCombineCore_Combie(_Context_Array[i], _oriDic);
                //在使用非Serializer入口做增量内容合并时，不会对原始对象进行深克隆
                AssertDictionary(_Dic_Array[i], newDic, i.ToString(), true, false);
                Assert.AreEqual(_oriDic.GetHashCode(), newDic.GetHashCode());
                Init();
            }
        }
        [Test]
        [Description("检测CombineIDictionary的Combine方法对字典类型对象的合并操作")]
        public void TestCombineIDictionary_Combine_Dictionary()
        {
            for (int i = 0; i < _Context_Array.Length; i++)
            {
                var newDic = DoCombineIDictionary_Combie(_Context_Array[i], _oriDic);
                //在使用非Serializer入口做增量内容合并时，不会对原始对象进行深克隆
                AssertDictionary(_Dic_Array[i], newDic, i.ToString(), true, false);
                Assert.AreEqual(_oriDic.GetHashCode(), newDic.GetHashCode());
                Init();
            }
        }
        [Test]
        [Description("检测CombineIDictionary的Combine方法对字典类型对象的合并操作")]
        public void TestSerializer_Combine_Dictionary()
        {
            for (int i = 0; i < _Context_Array.Length; i++)
            {
                //不做深克隆时
                var newDic = DoSerializer_Combie(_Context_Array[i], _oriDic);
                AssertDictionary(_Dic_Array[i], newDic, i.ToString(), true, false);
                Assert.AreEqual(_oriDic.GetHashCode(), newDic.GetHashCode());
                Init();
                newDic = null;
                //做深克隆时
                newDic = DoSerializer_Combie(ComplexOperatorChangedContext, _oriDic, true);
                AssertDictionary(_Dic_Array[i], newDic, i.ToString(), true, false);
                Assert.AreNotEqual(_oriDic.GetHashCode(), newDic.GetHashCode());
            }
        }
        #endregion

        #region 增量对象实例与原始对象实例间产生增量是否符合预期

        [Test]
        [Description("使用DivideCore中的Divide方法在原始字典对象与目标字典对象之间产生增量，并验证增量内容是否符合预期")]
        public void TestDivideCore_Divide_Dictionary()
        {
            for (int i = 0; i < _Context_Array.Length; i++)
            {
                var context = DoDivideCore_Divide(_oriDic, _Dic_Array[i]);
                Assert.AreEqual(_Context_Array[i], context);
            }
        }

        [Test]
        [Description("使用DivideCore中的Divide方法在原始字典对象与目标字典对象之间产生增量，并验证增量内容是否符合预期")]
        public void TestDivideDictionary_Divide_Dictionary()
        {
            for (int i = 0; i < _Context_Array.Length; i++)
            {
                var context = DoDivideIDictionary_Divide(_oriDic, _Dic_Array[i]);
                Assert.AreEqual(_Context_Array[i], context);
            }
        }

        [Test]
        [Description("使用Serializer中的Divide方法在原始字典对象与目标字典对象之间产生增量，并验证增量内容是否符合预期")]
        public void TestSerializer_Divide_Dictionary()
        {
            for (int i = 0; i < _Context_Array.Length; i++)
            {
                var context = DoSerializer_Divide(_oriDic, _Dic_Array[i]);
                Assert.AreEqual(_Context_Array[i], context);
            }
        }
        #endregion
    }
}