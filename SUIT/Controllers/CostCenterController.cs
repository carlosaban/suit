using Newtonsoft.Json;
using SUIT.BE;
using SUIT.Pago.BE;
using SUIT.Pago.BL;
using SUIT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SUIT.Controllers
{
    public class CostCenterController : ApiController
    {
        [Route("api/CostCenter/GetCostCenterGeneral")]
        [HttpPost]
        public BE_Json GetCostCenterGeneral([FromBody]BE_CostCenter bE_CostCenter)
        {   BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_CostCenter bL_CostCenter = new BL_CostCenter();
                bL_CostCenter.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_CostCenter.GetCostCenterGeneral(bE_CostCenter.costCenterId));

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



        
        [Route("api/CostCenter/AddCostCenterToInvoice")]
        [HttpPost]
        public BE_Json AddCostCenterToInvoice([FromBody]AddCostCenterToInvoiceViewModel ViewModel)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_CostCenter bL_CostCenter = new BL_CostCenter();


                bL_CostCenter.connectionString = AppConfig.DbConnection;
                string mensaje = string.Empty;
                bool bOk = bL_CostCenter.AddCostCenterToInvoice(ref mensaje,ViewModel.CostCenterId, ViewModel.invoiceId, ViewModel.Username);


                bL_CostCenter.connectionString = AppConfig.DbConnection;
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


        [Route("api/CostCenter/AddDetractionToInvoice")]
        [HttpPost]
        public BE_Json AddDetractionToInvoice([FromBody]AddDetractionToInvoiceViewModel ViewModel)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_CostCenter bL_CostCenter = new BL_CostCenter();


                bL_CostCenter.connectionString = AppConfig.DbConnection;
                string mensaje = string.Empty;
                bool bOk = bL_CostCenter.AddDetractionToInvoice(ref mensaje, ViewModel.AmountDetraction, ViewModel.invoiceId, ViewModel.Username);


                bL_CostCenter.connectionString = AppConfig.DbConnection;
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
    }
}
