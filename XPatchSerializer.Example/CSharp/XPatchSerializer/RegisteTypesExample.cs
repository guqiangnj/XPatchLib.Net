﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using XPatchLib;

namespace XPatchSerializerExample
{
    public class RegisteTypesExample
    {
        #region Public Methods

        public static void Main(string[] args)
        {
            RegisteTypesExample t = new RegisteTypesExample();

            t.Divide("patch.xml");
        }

        #endregion Public Methods

        #region Private Methods

        private void Divide(string filename)
        {
            Console.WriteLine("Writing With XmlWriter");

            List<OrderedItem> oldItems = new List<OrderedItem>();
            List<OrderedItem> newItems = new List<OrderedItem>();

            oldItems.Add(new OrderedItem() { ItemName = "Item A", Quantity = 10 });
            oldItems.Add(new OrderedItem() { ItemName = "Item B", Quantity = 10 });

            newItems.Add(new OrderedItem() { ItemName = "Item A", Quantity = 5 });
            newItems.Add(new OrderedItem() { ItemName = "Item C", Quantity = 20 });

            XPatchSerializer serializer = new XPatchSerializer(typeof(List<OrderedItem>));
            //当OrderItem类型上未标记PrimaryKeyAttribute时，可以通过RegisterTypes方法向系统注册类型与主键的关系
            Dictionary<Type, string[]> types = new Dictionary<Type, string[]>();
            types.Add(typeof(OrderedItem), new string[] { "ItemName" });
            serializer.RegisterTypes(types);

            FileStream fs = new FileStream(filename, FileMode.Create);
            XmlWriter writer = new XmlTextWriter(fs, Encoding.UTF8);
            serializer.Divide(writer, oldItems, newItems);
            writer.Close();
        }

        #endregion Private Methods

        #region Public Classes

        public class OrderedItem
        {
            #region Public Fields

            public string Description;
            public string ItemName;
            public decimal LineTotal;
            public int Quantity;
            public decimal UnitPrice;

            #endregion Public Fields

            #region Public Methods

            public void Calculate()
            {
                LineTotal = UnitPrice * Quantity;
            }

            #endregion Public Methods
        }

        #endregion Public Classes
    }
}