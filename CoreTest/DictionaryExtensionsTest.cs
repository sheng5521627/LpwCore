using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Collections.Extensions;

namespace CoreTest
{
    [TestClass]
    public class DictionaryExtensionsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>()
            {
                { "name1","lpw1"}
            };

            object value;
            Assert.AreEqual(dictionary.GetOrAdd("name", k => "lpw"), "lpw");
        }
    }
}
