using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUIT.Pago.BL;

namespace SUIT.SERVICES.TEST
{
    [TestClass]
    public class BL_CompanyTest
    {
        //clase a testear
        BL_Company negocios;
        //clases para el constructor
        string DbConection="";

        [TestInitialize]
        public void Init()
        {
            negocios = new BL_Company();
            DbConection = ConfigurationManager.ConnectionStrings["pagosapp"].ConnectionString;
        }

        [TestCleanup]
        public void Clean()
        {
            negocios = null;
        }

        [TestMethod]
        public void TestGetCompanyGeneral()
        {
            negocios.connectionString = DbConection;
            var resultado = negocios.GetCompanyGeneral(new Pago.BE.n.Filters.BECompanyFilter { CompanyTypeList = "30"});
            Assert.AreEqual("","");
        }
    }
}
