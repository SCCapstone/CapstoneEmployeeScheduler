using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapstoneEmployeeScheduler.Views;
using CapstoneEmployeeScheduler;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        TestingBackend tb = new TestingBackend();

        [TestMethod]
        public void TestCreateGetDeleteRole()
        {
            string test = null;
            try
            {
                test = tb.CreateGetDeleteRole();
            }
            catch
            {
                Assert.IsFalse(true);
            }
            Assert.AreEqual("Success", test);
        }
    }
}
