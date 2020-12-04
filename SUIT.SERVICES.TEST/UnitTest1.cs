using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUIT.Pago.BE.n.Filters;
using System.Net.Http;
using SUIT.Controllers;
using SUIT.BE;

namespace SUIT.SERVICES.TEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new InvoiceController();
            BEInvoiceFilter bEInvoiceFilter = new BEInvoiceFilter();
            bEInvoiceFilter.invoiceIdList = "1";
            bEInvoiceFilter.statusList = "P";
            var result = controller.GetInvoiceGeneral(bEInvoiceFilter);
            BE_Json a = new BE_Json();
            Assert.AreEqual("","");
        }
    }
}
