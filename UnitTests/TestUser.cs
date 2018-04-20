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
            try
            {
                //Sets test equal to whatever this method returns
                test = tb.CreateGetDeleteUser();
            }
            catch
            {
                //If any exception is caught the test fails
                Assert.IsFalse(true);
            }
            //If the method returns success then the test passes
            Assert.AreEqual("Success", test);
        }

        [TestMethod]
        public void TestEditUser()
        {
            string test = null;
            try
            {
                //Sets test equal to whatever this method returns
                test = tb.EditUser();
            }
            catch
            {
                //If any exception is caught the test fails
                Assert.IsFalse(true);
            }
            //If the method returns success then the test passes
            Assert.AreEqual("Success", test);
        }
    }
}
