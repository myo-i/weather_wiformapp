using DDD.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DDDTest.Tests
{
    [TestClass]
    public class TemperatureTest
    {
        [TestMethod]
        public void 小数点2桁にして表示()
        {
            var t = new Temperature(12.3f);
            Assert.AreEqual(12.3f, t.Value);

            Assert.AreEqual("12.30", t.DisplayValue);
            Assert.AreEqual("12.30℃", t.DisplayValueWithUnit);
            Assert.AreEqual("12.30 ℃", t.DisplayValueWithUnitSpace);

        }

        [TestMethod]
        public void 温度インスタンスチェック()
        {
            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);
            Assert.AreEqual(true, t1.Equals(t2));

        }
        [TestMethod]
        public void 温度イコールチェック()
        {
            var t1 = new Temperature(12.3f);
            var t2 = new Temperature(12.3f);
            Assert.AreEqual(true, t1 == t2);

        }
        [TestMethod]
        public void 温度値チェック()
        {
            float tem1 = 12.3f;
            float tem2 = 12.3f;
            Assert.AreEqual(true, tem1.Equals(tem2));
        }
    }

}
