using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SUIT.BL;
using SUIT.Pago.BL;
using SUIT.Pago.BE;
using SUIT.BE;
using Newtonsoft.Json;
using SUIT.Pago.BE.n.Filters;
using SUIT.ViewModel;

namespace SUIT.Controllers
{

    public class InvoiceController : ApiController
    {
        //private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();


        /*-------------------------------GET UserController-----------------------------*/


        //Get UnpaidCompanyInvoices
        [Route("api/Invoice/GetUnpaidCompanyInvoices/{companyCode}")]
        [HttpGet]
        public BE_Json GetUnpaidCompanyInvoices(string companyCode)
        {
            //logger.Debug("hello world");
            //BL_Invoice BL_Invoice = new BL_Invoice();
            //_blInvoice.connectionString = AppConfig.DbConnection;
            //return _blInvoice.GetUnpaidCompanyInvoices(companyCode);


            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetUnpaidCompanyInvoices(companyCode));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Get UnpaidCompanyInvoicesBalance
        [Route("api/Invoice/GetUnpaidCompanyInvoicesBalance/{companyCode}")]
        [HttpGet]
        public BE_Json GetUnpaidCompanyInvoicesBalance(string companyCode)
        {
            //BL_Invoice _blInvoice = new BL_Invoice();
            //_blInvoice.connectionString = AppConfig.DbConnection;
            //return _blInvoice.GetUnpaidCompanyInvoicesBalance(companyCode);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetUnpaidCompanyInvoicesBalance(companyCode));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Get UnpaidCompanyInvoicesResume
        [Route("api/Invoice/GetUnpaidCompanyInvoicesResume/{companyCode}")]
        [HttpGet]
        public BE_Json GetUnpaidCompanyInvoicesResume(string companyCode)
        {
            //BL_Invoice _blInvoice = new BL_Invoice();
            //_blInvoice.connectionString = AppConfig.DbConnection;
            //return _blInvoice.GetUnpaidCompanyInvoicesResume(companyCode);
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetUnpaidCompanyInvoicesResume(companyCode));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Get UnpaidCompanyInvoicesResumeDetail
        [Route("api/Invoice/GetUnpaidCompanyInvoicesResumeDetail/{companyCode}")]
        [HttpGet]
        public BE_Json GetUnpaidCompanyInvoicesResumeDetail(string companyCode)
        {
            //BL_Invoice _blInvoice = new BL_Invoice();
            //_blInvoice.connectionString = AppConfig.DbConnection;
            //return _blInvoice.GetUnpaidCompanyInvoicesResumeDetail(companyCode);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetUnpaidCompanyInvoicesResumeDetail(companyCode));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Get InvoiceById
        [Route("api/Invoice/GetInvoiceById/{_invoiceId}")]
        [HttpGet]
        public BE_Json GetInvoiceById(string _invoiceId)
        {
            //BL_Invoice _blInvoice = new BL_Invoice();
            //_blInvoice.connectionString = AppConfig.DbConnection;
            //return _blInvoice.GetInvoiceById(_invoiceId);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetInvoiceById(_invoiceId));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }


        //Get InvoiceById
        [Route("api/Invoice/GetInvoiceExpByCompany/{companyCode}/{searchField}")]
        [HttpGet]
        public BE_Json GetInvoiceExpByCompany(string companyCode, string searchField)
        {
            //BL_Invoice _blInvoice = new BL_Invoice();
            //_blInvoice.connectionString = AppConfig.DbConnection;
            //return _blInvoice.GetInvoiceById(_invoiceId);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                List<VE_Invoice> a = new List<VE_Invoice>();
                VE_Invoice b = new VE_Invoice();
                a.Add(b);
                objListaAux = JsonConvert.SerializeObject(a);

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }


        //Get InvoicesSummaryDetail
        [Route("api/Invoice/GetInvoicesSummaryDetail/{companyCode}/{providerRuc}")]
        [HttpGet]
        public BE_Json GetInvoicesSummaryDetail(string companyCode, string providerRuc)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetInvoicesSummaryDetail(companyCode, providerRuc));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }


        //Get Invoice
        [Route("api/Invoice/GetInvoice")]
        [HttpGet]
        public BE_Json GetInvoice()
        {
            //logger.Info("hello world GetInvoice");

            //BL_Invoice _blInvoice = new BL_Invoice();
            //_blInvoice.connectionString = AppConfig.DbConnection;
            //return _blInvoice.GetInvoice();

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetInvoice());

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }


        /*-------------------------------POST UserController-----------------------------*/


        //Post Invoice
        [Route("api/Invoice/CreateInvoice")]
        [HttpPost]
        public BE_Json CreateInvoice([FromBody]VE_Invoice _VeInvoice)
        {
            //BL_Invoice _blInvoice = new BL_Invoice();
            //_blInvoice.connectionString = AppConfig.DbConnection;
            //return _blInvoice.CreateInvoice(_VeInvoice);

            BE_Json objJson = null;
            var objListaAux = string.Empty;

            if (_VeInvoice == null)
                return objJson;

            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.CreateInvoice(_VeInvoice));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        [Route("api/Invoice/UpdateInvoiceGeneral")]
        [HttpPost]
        public BE_Json UpdateInvoiceGeneral([FromBody]VE_Invoice _VeInvoice)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;

            if (_VeInvoice == null)
                return objJson;

            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.updateInvoiceGeneral(_VeInvoice));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (ApplicationException ex)
            {
                objJson = new BE_Json();
                objJson.data = ex.Message;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Post MakePayments
        [Route("api/Invoice/MakePayments")]
        [HttpPost]
        public BE_Json MakePayments(List<VE_Invoice> _lstVeInvoice)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.MakePayments(_lstVeInvoice));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        /*
    //Post MakePayments
    [Route("api/Invoice/MakePayments")]
    [HttpPost]
    public string MakePayments(List<VE_Invoice> _lstVeInvoice)
    {
        BL_Invoice _blInvoice = new BL_Invoice();
        _blInvoice.connectionString = AppConfig.DbConnection;
        return _blInvoice.MakePayments(_lstVeInvoice);

    }*/



        //Post MakePaymentsDetails
        [Route("api/Invoice/MakePaymentsDetails")]
        [HttpPost]
        public BE_Json MakePaymentsDetails(List<VE_Invoice> _lstVeInvoice)
        {
            //BL_Invoice _blInvoice = new BL_Invoice();
            //_blInvoice.connectionString = AppConfig.DbConnection;
            //return _blInvoice.MakePaymentsDetails(_lstVeInvoice);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.MakePaymentsDetails(_lstVeInvoice));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Post MakePaymentsDetails
        [Route("api/Invoice/MakePaymentsDetailsPartials")]
        [HttpPost]
        public BE_Json MakePaymentsDetailsPartials(MakePaymentsDetailsPartialsViewModel ViewModel)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.MakePaymentsDetailsPartials(ViewModel.lstInvoices,ViewModel.payment));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }
        /*-------------------------------PUT UserController-----------------------------*/


        //Put Invoice
        [Route("api/Invoice/UpdateInvoice")]
        [HttpPost]
        public BE_Json UpdateInvoice([FromBody]VE_Invoice _VeInvoice)
        {
            //BL_Invoice _blInvoice = new BL_Invoice();
            //_blInvoice.connectionString = AppConfig.DbConnection;
            //return _blInvoice.UpdateInvoice(_VeInvoice);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.UpdateInvoice(_VeInvoice));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Put StatusInvoice
        [Route("api/Invoice/UpdateStatusInvoice")]
        [HttpPost]
        public BE_Json UpdateInvoiceStatus([FromBody]VE_Invoice _VeInvoice)
        {
            //BL_Invoice _blInvoice = new BL_Invoice();
            //_blInvoice.connectionString = AppConfig.DbConnection;
            //return _blInvoice.UpdateStatusInvoice(_VeInvoice);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.UpdateInvoiceStatus(_VeInvoice));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }


        [Route("api/Invoice/GetInvoiceGeneral")]
        [HttpPost]
        public BE_Json GetInvoiceGeneral([FromBody]BEInvoiceFilter _bEInvoiceFilter)
        {
                       
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetInvoiceGeneral(_bEInvoiceFilter));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        [Route("api/Invoice/GetDocumentTypeGeneral")]
        [HttpPost]
        public BE_Json GetDocumentTypeGeneral([FromBody]BE_DocumentType _DocumentType)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetDocumentTypeGeneral(_DocumentType));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }


        [Route("api/Invoice/CreateDocumentTypeGeneral")]
        [HttpPost]
        public BE_Json CreateDocumentTypeGeneral([FromBody]BE_DocumentType _DocumentType)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.CreateDocumentTypeGeneral(_DocumentType));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }


        [Route("api/Invoice/UpdateDocumentTypeGeneral")]
        [HttpPost]
        public BE_Json UpdateDocumentTypeGeneral([FromBody]BE_DocumentType _DocumentType)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.UpdateDocumentTypeGeneral(_DocumentType));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        /*-------------------------------DELETE UserController-----------------------------*/


        //Delete Invoice
        [Route("api/Invoice/DeleteInvoice")]
        [HttpDelete]
        public BE_Json DeleteInvoice(VE_Invoice _VeInvoice)
        {
            //BL_Invoice _blInvoice = new BL_Invoice();
            //_blInvoice.connectionString = AppConfig.DbConnection;
            //return _blInvoice.DeleteInvoice(_VeInvoice);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.DeleteInvoice(_VeInvoice));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Get GetSalesInvoceByCompany
        [Route("api/Invoice/GetSalesInvoiceByCompany/{companyCode}")]
        [HttpGet]
        public BE_Json GetSalesInvoiceByCompany(string companyCode)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetSalesInvoiceByCompany(companyCode));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Get GetOrderInvoiceByCompany
        [Route("api/Invoice/GetOrderInvoiceByCompany/{companyCode}")]
        [HttpGet]
        public BE_Json GetOrderInvoiceByCompany(string companyCode)
        {
            
            return GetOrderInvoiceByCompany(companyCode,string.Empty);
        }


        //Get GetOrderInvoiceByCompany
        [Route("api/Invoice/GetOrderInvoiceByCompany/{companyCode}/{searchField}")]
        [HttpGet]
        public BE_Json GetOrderInvoiceByCompany(string companyCode,string searchField)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetOrderInvoiceByCompany(companyCode));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }


        //Get GetOrderInvoiceSummaryByCompany
        [Route("api/Invoice/GetOrderInvoiceSummaryByCompany/{companyCode}")]
        [HttpGet]
        public BE_Json GetOrderInvoiceSummaryByCompany(string companyCode)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetOrderInvoiceSummary(companyCode));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Get GetSalesInvoceByCompany
        [Route("api/Invoice/GetSalesInvoiceSummaryByCompany/{companyCode}")]
        [HttpGet]
        public BE_Json GetSalesInvoiceSummaryByCompany(string companyCode)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetSalesInvoiceSummary(companyCode));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Get GetSalesInvoceByCompany
        [Route("api/Invoice/GetInvoiceByCompany/{companyCode}")]
        [HttpGet]
        public BE_Json GetInvoiceByCompany(string companyCode)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetInvoiceByCompanyCode(companyCode));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }


        //Get GetSalesInvoceByCompany
        [Route("api/Invoice/GetInvoiceByFilter/{companyCode}/{invoiceStatusId}")]
        [HttpGet]
        public BE_Json GetInvoiceByFilter(string companyCode, string invoiceStatusId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetInvoiceByFilter(companyCode, int.Parse(invoiceStatusId)));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        [Route("api/Invoice/GetInvoiceByCompanyCodeAndType/{companyCode}/{invoiceType}/{invoiceStatusId}")]
        [HttpGet]
        public BE_Json GetInvoiceByCompanyCodeAndType(string companyCode,string invoiceType, string invoiceStatusId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetInvoiceByCompanyCodeAndType(companyCode,invoiceType, int.Parse(invoiceStatusId)));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Get GetSalesInvoceByCompany
        [Route("api/Invoice/GetInvoiceDetailByInvoiceId/{invoiceId}")]
        [HttpGet]
        public BE_Json GetInvoiceDetailByInvoiceId(string invoiceId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetInvoiceDetailByInvoiceId(int.Parse(invoiceId)));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Get GetSalesInvoceByCompany
        [Route("api/Invoice/GetInvoiceItem/{companyCode}")]
        [HttpGet]
        public BE_Json GetInvoiceItem(string companyCode)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetInvoiceItem(companyCode));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Get GetSalesInvoceByCompany
        [Route("api/Invoice/AddInvoiceItem")]
        [HttpPost]
        public BE_Json AddInvoiceItem([FromBody] BE_InvoiceItem _beInvoiceItem)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.AddInvoiceItem(_beInvoiceItem));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //Get GetSummaryInvoiceExpByCompany
        [Route("api/Invoice/GetSummaryInvoiceExpByCompany/{companyCode}")]
        [HttpGet]
        public BE_Json GetSummaryInvoiceExpByCompany(string companyCode)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Invoice _blInvoice = new BL_Invoice();
                _blInvoice.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blInvoice.GetSalesInvoiceSummary(companyCode));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }


        //Refuse/InvoiceId/comment

        [Route("api/Invoice/Refuse/{username}/{invoiceId}/{comment}")]
        [HttpGet]
        public BE_Json Refuse(string username, int invoiceId , string comment )
        {
         
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_WorkFlow _blWorkFlow = new BL_WorkFlow();

                _blWorkFlow.connectionString = AppConfig.DbConnection;
                string mensaje = string.Empty;
                bool bOk = _blWorkFlow.NextWorkFlowStep(ref mensaje, 5, invoiceId, username, true,comment);


                _blWorkFlow.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(mensaje);

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = (bOk) ? CManager.RESULTADO_WCF.OK : CManager.RESULTADO_WCF.ERROR;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //NextStatusInvoice/InvoiceId
        [Route("api/Invoice/NextStatusInvoice/{username}/{invoiceId}")]
        [HttpGet]
        public BE_Json NextStatusInvoice(string username ,int invoiceId)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_WorkFlow _blWorkFlow = new BL_WorkFlow();


                _blWorkFlow.connectionString = AppConfig.DbConnection;
                string mensaje = string.Empty;
                bool bOk =_blWorkFlow.NextWorkFlowStep(ref mensaje, 1, invoiceId,username,false);


                _blWorkFlow.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(mensaje);

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = (bOk)?CManager.RESULTADO_WCF.OK: CManager.RESULTADO_WCF.ERROR;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }


        //NextStatusInvoice/InvoiceId
        [Route("api/Invoice/ValidatedNextWorkFlowStep/{workflowId}/{username}/{invoiceId}")]
        [HttpGet]
        public BE_Json ValidatedNextWorkFlowStep(int workflowId, string username, int invoiceId)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_WorkFlow _blWorkFlow = new BL_WorkFlow();


                _blWorkFlow.connectionString = AppConfig.DbConnection;
                bool bOk = _blWorkFlow.ValidatedNextWorkFlowStep(workflowId, invoiceId, username);

               
                objListaAux = JsonConvert.SerializeObject(bOk);

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = CManager.RESULTADO_WCF.OK;
            }
            catch (Exception ex)
            {
                objJson = new BE_Json();
                objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
                objJson.status = CManager.RESULTADO_WCF.ERROR;
                objJson.status = CManager.RESULTADO_WCF.ERROR;
            }
            finally
            {
                objListaAux = null;
            }
            return objJson;
        }

        //GetSummaryInvoiceExpByCompany003

        //NextStatus/InvoiceId
        //MakeAuthorization AccountDate InvoiceId
    }
}
