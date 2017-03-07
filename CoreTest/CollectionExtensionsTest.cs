using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Collections.Extensions;

namespace CoreTest
{
    [TestClass]
    public class CollectionExtensionsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ICollection<int> list = new List<int>();
            list.Add(1);

            Assert.IsTrue(list.IsNullOrEmpty());
        }
    }
}
