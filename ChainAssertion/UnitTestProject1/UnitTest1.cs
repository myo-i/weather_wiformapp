using ChainAssertion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
//using NUnit.Framework;
using System;
using System.CodeDom;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(3, Class1.Add(1, 2));
            Class1.Add(1, 2).Is(3);

            var ex = AssertEx.Throws<InputException>(() => Class1.Add(-1, 2));
            Assert.AreEqual("負の数は入力できません", ex.Message);
            ex.Message.Is("負の数は入力できません");
        }

        [TestMethod]
        [ExpectedException(typeof(InputException))]
        public void ExceptionTest()
        {
            Assert.AreEqual(3, Class1.Add(-1, 2));
        }


        [TestMethod]
        public void TestMethod2()
        {
            Class1.Add(1, 2).Is(3);

            var ex = AssertEx.Throws<InputException>(() => Class1.Add(-1, 2));
            ex.Message.Is("負の数は入力できません");
        }

    }
}
