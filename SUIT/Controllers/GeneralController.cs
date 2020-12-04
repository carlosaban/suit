using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SUIT.BL;
using SUIT.Pago.BL;
using SUIT.BE;
using Newtonsoft.Json;

namespace SUIT.Controllers.APIController
{
    public class GeneralController : ApiController
    {
  

        //Get ExchangeRate
        [Route("api/General/GetExchangeRate")]
        [HttpGet]
        public BE_Json GetExchangeRate()
        {
            //BL_Exchange _blExchange = new BL_Exchange();
            //return _blExchange.GetExchangeRate();


            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Exchange _blExchange = new BL_Exchange();
                //_blCompany.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blExchange.GetExchangeRate());

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


        [Route("api/General/GetSystemDate")]
        [HttpGet]
        public BE_Json GetSystemDate()
        {
            //BL_System _blSystem = new BL_System();
            //return _blSystem.GetSystemDate();
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_System _blSystem = new BL_System();
                //_blCompany.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blSystem.GetSystemDate());

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



    }
}
