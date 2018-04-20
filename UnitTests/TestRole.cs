using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapstoneEmployeeScheduler.Views;
using CapstoneEmployeeScheduler;

namespace UnitTests
{
    [TestClass]
    public class TestRole
    {
        TestingBackend tb = new TestingBackend();

        [TestMethod]
        public void TestCreateGetDeleteRole()
        {
            string test = null;
            try
            {
                //Sets test equal to whatever this method returns
                test = tb.CreateGetDeleteRole();
            }
            catch
            {
                //If any exception is caught the test fails
                Assert.IsFalse(true);
            }
            //If the method returns success then the test passes
            Assert.AreEqual("Success", test);
        }

        //Tests Editing a Role
        [TestMethod]
        public void TestEditRole()
        {
            string test = null;
            try
            {
                //Sets test equal to whatever this method returns
                test = tb.EditRole();
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
