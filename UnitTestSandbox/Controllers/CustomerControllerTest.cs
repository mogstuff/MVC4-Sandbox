using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sandbox.Controllers;

namespace UnitTestSandbox.Controllers
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new CustomerController();
            var result = controller.Details(3) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }



    }
}
