using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapstoneEmployeeScheduler.Views;
using CapstoneEmployeeScheduler;
using System.Windows;
using System.Windows.Controls;

namespace UnitTests
{
    [TestClass]
    public class CESTests
    {
        [TestMethod]
        public void TestCreateRole1()
        {
            Assert.IsTrue(true);

            Console.WriteLine("Here 1");
            
            TestingBackend tb = new TestingBackend();
            object sender = null;
            RoutedEventArgs e = null;
            tb.UserDAO_Click(sender, e);
            string name = tb.TestGet();
            if(name.Equals("Testing Role"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Console.WriteLine("made it here");
                Assert.IsFalse(true);
            }
        }
    }
}
