using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAutomation.Common;

namespace TestAutomation
{
    [TestClass]
    public class UnitTest1:Configuration
    {
        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl("http://www.tutorialspoint.com/sqoop/");



        }
    }
}
