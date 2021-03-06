﻿// Copyright © 2013-2017 - GuQiang
// Licensed under the LGPL-3.0 license. See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace XPatchLib.UnitTest.TestClass
{
    public class XmlIgnoreClass
    {
#if (!NETSTANDARD_1_0 && !NETSTANDARD_1_3)
        [XmlIgnore]
#endif
        public string A { get; set; }

        [XPatchLibXmlIgnore]
        public string B { get; set; }

        public override bool Equals(object obj)
        {
            XmlIgnoreClass c = obj as XmlIgnoreClass;
            if (c == null) return false;
            return string.Equals(A, c.A) && string.Equals(B, c.B);
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class XPatchLibXmlIgnoreAttribute : Attribute
    {
        
    }
}