using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace stringTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly string0813.Program p1 = new string0813.Program();
        [TestMethod]
        public void TestZero()
        {
            p1.setSt1("0");
            p1.setSt2("0");

            p1.solve();
            Assert.IsTrue(p1.getRestring() == "0");

        }

        [TestMethod]
        public void TestZero1()
        {
            p1.setSt1("0");
            p1.setSt2("12345678901234567890");

            p1.solve();
            Assert.IsTrue(p1.getRestring() == "-12345678901234567890");

        }


        [TestMethod]
        public void TestZero2()
        {
            p1.setSt1("12345678901234567890");
            p1.setSt2("0");

            p1.solve();
            Assert.IsTrue(p1.getRestring() == "12345678901234567890");

        }

        [TestMethod]
        public void TestLarge()
        {
            p1.setSt1("11112");
            p1.setSt2( "11111");

            p1.solve();
            Assert.IsTrue(p1.getRestring() == "1");

        }
    }
}
