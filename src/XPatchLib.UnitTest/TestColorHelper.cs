﻿// Copyright © 2013-2017 - GuQiang
// Licensed under the LGPL-3.0 license. See LICENSE file in the project root for full license information.

#if (NET || NETSTANDARD_2_0_UP)

using System.Diagnostics;
using System.Drawing;
#if NUNIT
using NUnit.Framework;

#elif XUNIT
using Xunit;
using Test = Xunit.FactAttribute;
using Assert = XPatchLib.UnitTest.XUnitAssert;
#endif

namespace XPatchLib.UnitTest
{
    [TestFixture]
    public class TestColorHelper
    {
        [Test]
        public void ColorHelperTest()
        {
            Assert.AreEqual("Aqua", ColorHelper.TransToString(Color.Aqua));

            Assert.AreEqual("#FFFFFFFF", ColorHelper.TransToString(Color.FromArgb(255, 255, 255)));

            Color result;
            ColorHelper.TryTransFromString("AliceBlue", out result);
            Assert.AreEqual(Color.AliceBlue, result);

            LogHelper.Debug(result.Name);
            LogHelper.Debug(result.A);
            LogHelper.Debug(result.R);
            LogHelper.Debug(result.G);
            LogHelper.Debug(result.B);

            ColorHelper.TryTransFromString("#FFFFFFFF", out result);
            Assert.AreEqual(Color.FromArgb(255, 255, 255), result);

            LogHelper.Debug(result.Name);
            LogHelper.Debug(result.A);
            LogHelper.Debug(result.R);
            LogHelper.Debug(result.G);
            LogHelper.Debug(result.B);

            Assert.IsFalse(ColorHelper.TryTransFromString("", out result));
            Assert.IsFalse(ColorHelper.TryTransFromString("#", out result));
            Assert.IsFalse(ColorHelper.TryTransFromString(" ", out result));
            Assert.IsFalse(ColorHelper.TryTransFromString(null, out result));
        }
    }
}

#endif