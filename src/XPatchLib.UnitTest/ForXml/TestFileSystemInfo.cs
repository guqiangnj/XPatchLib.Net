﻿// Copyright © 2013-2018 - GuQiang
// Licensed under the LGPL-3.0 license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Reflection;
#if NUNIT
using NUnit.Framework;
#elif XUNIT
using Xunit;
using Test = Xunit.FactAttribute;
using Assert = XPatchLib.UnitTest.XUnitAssert;
#endif

namespace XPatchLib.UnitTest.ForXml
{
    [TestFixture]
    public class TestFileSystemInfo:TestBase
    {
#if NET || NETSTANDARD_1_3_UP
        [Test]
        public void TestDirectoryInfo()
        {
            DirectoryInfo tempInfo = new DirectoryInfo(Path.GetTempPath());
            string output = DoSerializer_Divide(null, tempInfo);
//            Assert.AreEqual(@"<?xml version=""1.0"" encoding=""utf-8""?>
//<DirectoryInfo>
//  <OriginalPath>C:\Users\GuQiang\AppData\Local\Temp\</OriginalPath>
//  <FullPath>C:\Users\GuQiang\AppData\Local\Temp\</FullPath>
//</DirectoryInfo>", output);
            LogHelper.Debug(output);

            DirectoryInfo tempInfo1 = DoSerializer_Combie<DirectoryInfo>(output, null, true);

            Assert.AreEqual(tempInfo.Name, tempInfo1.Name);
            Assert.AreEqual(tempInfo.FullName, tempInfo1.FullName);
            Assert.AreEqual(tempInfo.CreationTimeUtc, tempInfo1.CreationTimeUtc);
            Assert.AreEqual(tempInfo.LastAccessTimeUtc, tempInfo1.LastAccessTimeUtc);
            Assert.AreEqual(tempInfo.LastWriteTimeUtc, tempInfo1.LastWriteTimeUtc);
        }

        [Test]
        public void TestFileInfo()
        {
            FileInfo tempInfo = new FileInfo(ResolvePath("log4net.config"));
            string output = DoSerializer_Divide(null, tempInfo);
            //            Assert.AreEqual(@"<?xml version=""1.0"" encoding=""utf-8""?>
            //<DirectoryInfo>
            //  <OriginalPath>C:\Users\GuQiang\AppData\Local\Temp\</OriginalPath>
            //  <FullPath>C:\Users\GuQiang\AppData\Local\Temp\</FullPath>
            //</DirectoryInfo>", output);
            LogHelper.Debug(output);

            FileInfo tempInfo1 = DoSerializer_Combie<FileInfo>(output, null, true);

            Assert.AreEqual(tempInfo.Name, tempInfo1.Name);
            Assert.AreEqual(tempInfo.FullName, tempInfo1.FullName);
            Assert.AreEqual(tempInfo.CreationTimeUtc, tempInfo1.CreationTimeUtc);
            Assert.AreEqual(tempInfo.LastAccessTimeUtc, tempInfo1.LastAccessTimeUtc);
            Assert.AreEqual(tempInfo.LastWriteTimeUtc, tempInfo1.LastWriteTimeUtc);
        }
#endif

#if NET || NETSTANDARD_2_0_UP
        [Test]
        public void TestDriveInfo()
        {
            DriveInfo tempInfo = DriveInfo.GetDrives()[0];
            string output = DoSerializer_Divide(null, tempInfo);
            //            Assert.AreEqual(@"<?xml version=""1.0"" encoding=""utf-8""?>
            //<DirectoryInfo>
            //  <OriginalPath>C:\Users\GuQiang\AppData\Local\Temp\</OriginalPath>
            //  <FullPath>C:\Users\GuQiang\AppData\Local\Temp\</FullPath>
            //</DirectoryInfo>", output);
            LogHelper.Debug(output);

            DriveInfo tempInfo1 = DoSerializer_Combie<DriveInfo>(output, null, true);

            Assert.AreEqual(tempInfo.Name, tempInfo1.Name);
            Assert.AreEqual(tempInfo.TotalSize, tempInfo1.TotalSize);
        }
#endif
    }
}