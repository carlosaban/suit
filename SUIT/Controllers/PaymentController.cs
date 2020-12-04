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
using System.IO;
using System.ServiceModel;
using SUIT.BE;
using Newtonsoft.Json;
using SUIT.ViewModel;
using SUIT.Pago.BE.n.Filters;

namespace SUIT.Controllers.APIController
{

    public class PaymentController : ApiController
    {

        /*-------------------------------GET UserController-----------------------------*/


        //[Route("api/Payment/GetValueUserByPaymentAuthId/{paymentAuthDetailID}")]
        //[HttpGet]
        //public IEnumerable<VE_PaymentAuthDetail> GetValueUserByPaymentAuthId(int paymentAuthDetailID)
        //{
        //    BL_Payment _blPayment = new BL_Payment();
        //    _blPayment.connectionString = AppConfig.DbConnection;
        //    return _blPayment.GetValueUserByPaymentAuthId(paymentAuthDetailID);
        //}


        //Get CompanyPaymentsByPeriod
        [Route("api/Payment/GetCompanyPaymentsByPeriod/{companyCode}")]
        [HttpGet]
        public BE_Json GetCompanyPaymentsByPeriod(string companyCode)
        {
            //BL_Payment _blPayment = new BL_Payment();
            //_blPayment.connectionString = AppConfig.DbConnection;
            //return _blPayment.GetCompanyPaymentsByPeriod(companyCode);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.GetCompanyPaymentsByPeriod(companyCode));

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

        //Get PaymentsAuthByCompanyCode
        [Route("api/Payment/getPaymentsAuthByCompanyCode/{companyCode}")]
        [HttpGet]
        public BE_Json getPaymentsAuthByCompanyCode(string companyCode)
        {
            //BL_Payment _blPayment = new BL_Payment();
            //_blPayment.connectionString = AppConfig.DbConnection;
            //return _blPayment.getPaymentsAuthByCompanyCode(companyCode);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.getPaymentsAuthByCompanyCode(companyCode));

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

        //Get PaymentsAuthById
        [Route("api/Payment/getPaymentsAuthById/{paymentAuthId}")]
        [HttpGet]
        public BE_Json getPaymentsAuthById(int paymentAuthId)
        {
            //BL_Payment _blPayment = new BL_Payment();
            //_blPayment.connectionString = AppConfig.DbConnection;
            //return _blPayment.getPaymentsAuthById(paymentAuthId);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.getPaymentsAuthById(paymentAuthId));

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

        //Get PaymentsAuthByCompanyCode
        [Route("api/Payment/getPaymentsAuthByCompanyCode/{companyCode}/{startDate}/{endDate}")]
        [HttpGet]
        public BE_Json getPaymentsAuthByCompanyCode(string companyCode, string startDate, string endDate)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.getPaymentsAuthByCompanyCode(companyCode, startDate, endDate));

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

        //Get PaymentsByAuthId
        [Route("api/Payment/getPaymentsByAuthId/{paymentAuthId}")]
        [HttpGet]
        public BE_Json getPaymentsByAuthId(int paymentAuthId)
        {
            //BL_Payment _blPayment = new BL_Payment();
            //_blPayment.connectionString = AppConfig.DbConnection;
            //return _blPayment.getPaymentsByAuthId(paymentAuthId);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.getPaymentsByAuthId(paymentAuthId));

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

        //Get PaymentsAuthBankAccountById
        [Route("api/Payment/getPaymentsAuthBankAccountById/{paymentAuthId}/{bankAccountId}")]
        [HttpGet]
        public BE_Json getPaymentsAuthBankAccountById(int paymentAuthId, int bankAccountId)
        {
            //BL_Payment _blPayment = new BL_Payment();
            //_blPayment.connectionString = AppConfig.DbConnection;
            //return _blPayment.getPaymentsAuthBankAccountById(paymentAuthId, bankAccountId);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.getPaymentsAuthBankAccountById(paymentAuthId, bankAccountId));

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

        [Route("api/Payment/GetTxtBankByAuthId/{paymentAuthId}/{bankAccountId}")]
        [HttpGet]
        public HttpResponseMessage getTxtBank(int paymentAuthId, int bankAccountId)
        {
            BL_Payment _blPayment = new BL_Payment();
            _blPayment.connectionString = AppConfig.DbConnection;
            //return _blPayment.getTxtPaymentAuth(paymentAuthId, bankAccountId);

            string _filename = string.Empty;
            Stream _filecontent = _blPayment.getTxtPaymentAuth(paymentAuthId, bankAccountId, ref _filename);
            //String headerInfo = "attachment; filename=" + _filename + ".txt";
            //System.ServiceModel.Web.WebOperationContext.Current.OutgoingResponse.Headers["Content-Disposition"] = headerInfo;
            //System.ServiceModel.Web.WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            response.Content = new StreamContent(_filecontent);
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = _filename + ".txt"
            };

            return response;
        }


        /*-------------------------------POST PaymentController-----------------------------*/


        // POST: api/Payment
        [Route("api/Payment/CreatePaymentAuthDetail")]
        [HttpPost]
        public BE_Json CreatePaymentAuthDetail([FromBody]VE_PaymentAuthDetail _VePaymentAuthDetail)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.CreatePaymentAuthDetail(_VePaymentAuthDetail));

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

        //----------------------------------------cambios A.M.-INICIO

        [Route("api/Payment/GetPaymentGeneral")]
        [HttpPost]
        public BE_Json GetPaymentGeneral([FromBody]BEPaymentFilter _bEPaymentFilter)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _bL_Payment = new BL_Payment();
                _bL_Payment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_bL_Payment.GetPaymentGeneral(_bEPaymentFilter));

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


        [Route("api/Payment/CreateAdvance")]
        [HttpPost]
        public BE_Json CreateAdvance([FromBody]BE_Payment _BePayment)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.CreateAdvance(_BePayment));

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


        //----------------------------------------cambios A.M.-FIN
        /*-------------------------------PUT PaymentController-----------------------------*/


        //Put UserAuth
        [Route("api/Payment/UpdateUserAuth")]
        [HttpPost]
        public BE_Json updateUserAuth([FromBody]BE_PaymentAuth _paymentAuth)
        {
            //BL_Payment _blPayment = new BL_Payment();
            //_blPayment.connectionString = AppConfig.DbConnection;
            //return _blPayment.updateUserAuth(_paymentAuth, _paymentAuth.userName);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.updateUserAuth(_paymentAuth, _paymentAuth.userName));

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

        //Put PaymentAuthPayDate
        [Route("api/Payment/updatePaymentAuthPayDate")]
        [HttpPost]
        public BE_Json updatePaymentAuthPayDate(VE_PaymentAuth _paymentAuth)
        {
            //BL_Payment _blPayment = new BL_Payment();
            //_blPayment.connectionString = AppConfig.DbConnection;
            //return _blPayment.updatePaymentAuthPayDate(_paymentAuth, _paymentAuth.userName);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.updatePaymentAuthPayDate(_paymentAuth, _paymentAuth.userName));

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

        //Cambios Adrian - Inicio
        //Put WorkFlowDetail
        [Route("api/Payment/WorkFlowDetail")]
        [HttpPost]
        public BE_Json WorkFlowDetail([FromBody]WorkFlowNextStepViewModel _WorkFlowNextStep)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_WorkFlow _blWorkFlow = new BL_WorkFlow();
                _blWorkFlow.connectionString = AppConfig.DbConnection;
                var mensaje = "";
                bool bOk = _blWorkFlow.NextWorkFlowStep(ref mensaje, _WorkFlowNextStep.WorkFlowId, _WorkFlowNextStep.InvoiceId, _WorkFlowNextStep.userName, _WorkFlowNextStep.refuse);
                
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
        //Cambios Adrian - Fin


        /*-------------------------------DELETE PaymentController-----------------------------*/


        //Delete ResversePayment
        [Route("api/Payment/ReversePayment")]
        [HttpPost]
        public BE_Json reversePayment(BE_PaymentAuth bePaymentAuth)
        {
            //BL_Payment _blPayment = new BL_Payment();
            //_blPayment.connectionString = AppConfig.DbConnection;
            //return _blPayment.reversePayment(bePaymentAuth, bePaymentAuth.userName);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.reversePayment(bePaymentAuth));

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

        [Route("api/Payment/GetPaymentMethod")]
        [HttpGet]
        public BE_Json GetPaymentMethod()
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.GetPaymentMethod());

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

        //Delete ResversePayment
        [Route("api/Payment/ClientPayment")]
        [HttpPost]
        public BE_Json ClientPayment(BE_Payment bePayment)
        {
            //BL_Payment _blPayment = new BL_Payment();
            //_blPayment.connectionString = AppConfig.DbConnection;
            //return _blPayment.reversePayment(bePaymentAuth, bePaymentAuth.userName);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.RegisterClientPayment(bePayment));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = (!String.IsNullOrEmpty(objListaAux))? CManager.RESULTADO_WCF.OK: CManager.RESULTADO_WCF.ERROR;
            }
            catch (ApplicationException ae)
            {
                objJson = new BE_Json();
                objJson.data = "\"" + ae.Message + "\"";
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


        [Route("api/Payment/createPaymentGeneral")]
        [HttpPost]
        public BE_Json CreatePayment(BE_Payment bePayment)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Payment _blPayment = new BL_Payment();
                _blPayment.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blPayment.createPaymentGeneral(bePayment));

                objJson = new BE_Json();
                objJson.data = objListaAux;
                objJson.status = (!String.IsNullOrEmpty(objListaAux)) ? CManager.RESULTADO_WCF.OK : CManager.RESULTADO_WCF.ERROR;
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

    }
}
