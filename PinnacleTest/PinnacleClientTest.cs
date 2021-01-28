using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PinnacleSample;

namespace PinnacleTest
{
    [TestClass]

 
    public class PinnacleClientTest
    {

        public ICustomerRepositoryDB customerRepositoryDB { get; set; }

        public IPartInvoiceRepositoryDB partInvoiceRepositoryDB { get; set; }

        [TestMethod]
        public void CreatePartInvoiceTest()
        {

            //Arrange
            PinnacleClient pinnacleClient = new PinnacleClient();
            pinnacleClient.CreatePartInvoice("a", 2, "bhargavi");

            //Act

            //Assert

        }
    }
}
