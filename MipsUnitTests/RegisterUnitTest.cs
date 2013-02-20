using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mips_syntax.utils;

namespace MipsUnitTests
{
    /// <summary>
    /// Summary description for RegisterUnitTest
    /// </summary>
    [TestClass]
    public class RegisterUnitTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TempRegistersAcceptedTest()
        {
            var list = new List<string> { "$t0", "$t1", "$t2", "$t3", "$t4", "$t5", "$t6", "$t7", "$t8", "$t9" };
            foreach (var actual in list.Select(result => result.IsTemporaryRegister(true)))
            {
                Assert.AreEqual(true, actual);
            }
        }

        [TestMethod]
        public void StoreRegistersAcceptedTest()
        {
            var list = new List<string> { "$s0", "$s1", "$s2", "$s3", "$s4", "$s5", "$s6", "$s7", "$s8", "$s9" };
            foreach (var actual in list.Select(result => result.IsStoreRegister(true)))
            {
                Assert.AreEqual(true, actual);
            }
        }

        [TestMethod]
        public void ConstantAcceptedTest()
        {
            var list = new List<string> { "1", "10", "-10", "+10" };
            foreach (var actual in list.Select(result => result.IsMIPSConstant()))
            {
                Assert.AreEqual(true, actual);
            }
        }

        [TestMethod]
        public void NonConstantFailsTest()
        {
            var list = new List<string> { "notaconstant", "s" };
            foreach (var actual in list.Select(result => result.IsMIPSConstant()))
            {
                Assert.AreNotEqual(true, actual);
            }
        }

        [TestMethod]
        public void ZeroRegisterTest()
        {
            const string z = @"$zero";
            var actual = z.IsSpecialRegister(true);
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void IsLabelTest()
        {
            const string z = @"Label:";
            var result = z.IsMIPSLabel();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsMemoryTest()
        {
            const string z = @"248($t2)";
            var result = z.IsMemoryLocation(true);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void OsReservedTest()
        {
            var list = new List<string>{"$k0","$k1"};
            foreach (var item in list)
            {
                var actual = item.IsReserveredRegister(true);
                Assert.AreEqual(true,actual);
            }
        }
    }
}
