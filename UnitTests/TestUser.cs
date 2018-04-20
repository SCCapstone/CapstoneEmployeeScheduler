using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapstoneEmployeeScheduler.Views;
using CapstoneEmployeeScheduler;

namespace UnitTests
{
    [TestClass]
    public class TestUser
    {
        TestingBackend tb = new TestingBackend();

        [TestMethod]
        public void TestCreateGetDeleteUser()
        {
            string test = null;
            //try
            //{
                test = tb.CreateGetDeleteUser();
            //}
            //catch
            //{
            //    Assert.IsFalse(true);
            //}
    Assert.AreEqual("Success", test);
        }

        [TestMethod]
        public void TestEditUser()
        {
            string test = null;
            try
            {
                test = tb.EditUser();
            }
            catch
            {
                Assert.IsFalse(true);
            }
            Assert.AreEqual("Success", test);
        }
    }
}
