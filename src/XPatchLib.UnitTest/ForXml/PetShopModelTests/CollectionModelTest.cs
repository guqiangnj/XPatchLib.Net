﻿// Copyright © 2013-2017 - GuQiang
// Licensed under the LGPL-3.0 license. See LICENSE file in the project root for full license information.

using System.Collections.ObjectModel;
using System.Xml;
using XPatchLib.UnitTest.PetShopModelTests.Models;
#if NUNIT
using NUnit.Framework;
#elif XUNIT
using Xunit;
using Test = Xunit.FactAttribute;
using Assert = XPatchLib.UnitTest.XUnitAssert;
#endif

namespace XPatchLib.UnitTest.ForXml.PetShopModelTests
{
    [TestFixture]
    public class CollectionModelTest:TestBase
    {
        [Test]
        [Description("测试Collection类型的复杂类型对象增加的增量内容是否产生正确，是否能够正确合并，并且合并后值相等")]
        public void TestOrderInfoCollectionAddDivideAndCombine()
        {
            var oriObjs = new Collection<OrderInfo>();
            var changedObjs = new Collection<OrderInfo>();

            oriObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(1));
            oriObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(2));

            changedObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(1));
            changedObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(2));
            changedObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(3));

            var changedContext = @"<" + ReflectionUtils.GetTypeFriendlyName(typeof(Collection<OrderInfo>)) + @">
  <OrderInfo Action=""Add"">
    <BillingAddress>
      <Address1>" + changedObjs[2].BillingAddress.Address1 + @"</Address1>
      <Address2 />
      <AddressId>" + changedObjs[2].BillingAddress.AddressId + @"</AddressId>
      <City>" + changedObjs[2].BillingAddress.City + @"</City>
      <Country>" + changedObjs[2].BillingAddress.Country + @"</Country>
      <Email />
      <FirstName>" + changedObjs[2].BillingAddress.FirstName + @"</FirstName>
      <LastName>" + changedObjs[2].BillingAddress.LastName + @"</LastName>
      <Phone>" + changedObjs[2].BillingAddress.Phone + @"</Phone>
      <State />
      <Zip>" + changedObjs[2].BillingAddress.Zip + @"</Zip>
    </BillingAddress>
    <CreditCard>
      <CardExpiration>" + changedObjs[2].CreditCard.CardExpiration + @"</CardExpiration>
      <CardId>" + changedObjs[2].CreditCard.CardId + @"</CardId>
      <CardNumber>" + changedObjs[2].CreditCard.CardNumber + @"</CardNumber>
      <CardType>" + changedObjs[2].CreditCard.CardType + @"</CardType>
    </CreditCard>
    <Date>" + XmlConvert.ToString(changedObjs[2].Date, XmlDateTimeSerializationMode.RoundtripKind) + @"</Date>
    <OrderId>" + changedObjs[2].OrderId + @"</OrderId>
    <OrderTotal>" + changedObjs[2].OrderTotal + @"</OrderTotal>
    <UserId>" + changedObjs[2].UserId + @"</UserId>
  </OrderInfo>
</" + ReflectionUtils.GetTypeFriendlyName(typeof(Collection<OrderInfo>)) + @">";

            DoAssert(typeof(Collection<OrderInfo>), changedContext, oriObjs, changedObjs, true);
            DoAssert(typeof(Collection<OrderInfo>), changedContext, oriObjs, changedObjs, false);
        }

        [Test]
        [Description("测试Collection类型的复杂类型对象插入的增量内容是否产生正确，是否能够正确合并，并且合并后值相等")]
        public void TestOrderInfoCollectionInsertDivideAndCombine()
        {
            var oriObjs = new Collection<OrderInfo>();
            var changedObjs = new Collection<OrderInfo>();

            oriObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(1));
            oriObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(2));

            changedObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(1));
            changedObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(2));

            changedObjs.Insert(1, PetShopModelTestHelper.CreateNewOriOrderInfo(3));

            var changedContext = @"<" + ReflectionUtils.GetTypeFriendlyName(typeof(Collection<OrderInfo>)) + @">
  <OrderInfo Action=""Add"">
    <BillingAddress>
      <Address1>" + changedObjs[1].BillingAddress.Address1 + @"</Address1>
      <Address2 />
      <AddressId>" + changedObjs[1].BillingAddress.AddressId + @"</AddressId>
      <City>" + changedObjs[1].BillingAddress.City + @"</City>
      <Country>" + changedObjs[1].BillingAddress.Country + @"</Country>
      <Email />
      <FirstName>" + changedObjs[1].BillingAddress.FirstName + @"</FirstName>
      <LastName>" + changedObjs[1].BillingAddress.LastName + @"</LastName>
      <Phone>" + changedObjs[1].BillingAddress.Phone + @"</Phone>
      <State />
      <Zip>" + changedObjs[1].BillingAddress.Zip + @"</Zip>
    </BillingAddress>
    <CreditCard>
      <CardExpiration>" + changedObjs[1].CreditCard.CardExpiration + @"</CardExpiration>
      <CardId>" + changedObjs[1].CreditCard.CardId + @"</CardId>
      <CardNumber>" + changedObjs[1].CreditCard.CardNumber + @"</CardNumber>
      <CardType>" + changedObjs[1].CreditCard.CardType + @"</CardType>
    </CreditCard>
    <Date>" + XmlConvert.ToString(changedObjs[1].Date, XmlDateTimeSerializationMode.RoundtripKind) + @"</Date>
    <OrderId>" + changedObjs[1].OrderId + @"</OrderId>
    <OrderTotal>" + changedObjs[1].OrderTotal + @"</OrderTotal>
    <UserId>" + changedObjs[1].UserId + @"</UserId>
  </OrderInfo>
</" + ReflectionUtils.GetTypeFriendlyName(typeof(Collection<OrderInfo>)) + @">";

            DoAssert(typeof(Collection<OrderInfo>), changedContext, oriObjs, changedObjs, true);
            DoAssert(typeof(Collection<OrderInfo>), changedContext, oriObjs, changedObjs, false);
        }

        [Test]
        [Description("测试Collection类型的复杂类型对象删除的增量内容是否产生正确，是否能够正确合并，并且合并后值相等")]
        public void TestOrderInfoCollectionRemoveDivideAndCombine()
        {
            var oriObjs = new Collection<OrderInfo>();
            var changedObjs = new Collection<OrderInfo>();

            oriObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(1));
            oriObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(2));
            oriObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(3));
            oriObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(4));
            oriObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(5));

            changedObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(1));
            changedObjs.Add(PetShopModelTestHelper.CreateNewOriOrderInfo(2));

            var changedContext = @"<" + ReflectionUtils.GetTypeFriendlyName(typeof(Collection<OrderInfo>)) + @">
  <OrderInfo Action=""Remove"" OrderId=""3"" />
  <OrderInfo Action=""Remove"" OrderId=""4"" />
  <OrderInfo Action=""Remove"" OrderId=""5"" />
</" + ReflectionUtils.GetTypeFriendlyName(typeof(Collection<OrderInfo>)) + @">";

            DoAssert(typeof(Collection<OrderInfo>), changedContext, oriObjs, changedObjs, true);
            DoAssert(typeof(Collection<OrderInfo>), changedContext, oriObjs, changedObjs, false);
        }
    }
}