using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SandboxTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestCustomerRepository repository = new TestCustomerRepository();
            CustomerController controller = new CustomerController(repository);
            var result = (ViewResult)controller.Index();
            List<Customer> data = (List<Customer>)result.ViewData.Model;
            Assert.IsFalse(data.Count <= 0);
        }

    }
}
