using Newtonsoft.Json;
using SUIT.BE;
using SUIT.Security.BE;
using SUIT.Security.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SUIT.Controllers
{
    public class OptionController : ApiController
    {
        [Route("api/Option/GetOptionGeneral")]
        [HttpPost]
        public BE_Json GetOptionGeneral([FromBody]BE_Option bE_Option)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Option bL_Option = new BL_Option(AppConfig.DbConnection);
                //bL_Option.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Option.GetOptionGeneral(bE_Option));

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

        [Route("api/Option/CreateOptionGeneral")]
        [HttpPost]
        public BE_Json CreateOptionGeneral([FromBody]BE_Option bE_Option)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Option bL_Option = new BL_Option(AppConfig.DbConnection);
                //bL_Option.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Option.CreateOptionGeneral(bE_Option));

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

        [Route("api/Option/UpdateOptionGeneral")]
        [HttpPost]
        public BE_Json UpdateOptionGeneral([FromBody]BE_Option bE_Option)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Option bL_Option = new BL_Option(AppConfig.DbConnection);
               // bL_Option.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Option.UpdateOptionGeneral(bE_Option));

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

        [Route("api/Option/DeleteOptionGeneral/{optionId}")]
        [HttpPut]
        public BE_Json DeleteOptionGeneral(int optionId)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Option bL_Option = new BL_Option(AppConfig.DbConnection);
                //bL_Option.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Option.DeleteOptionGeneral(optionId));

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

        [Route("api/Option/GetOptionMenuByUserName/{userName}/{isMenu?}")]
        [HttpGet]
        public BE_Json GetOptionMenuByUserName(string userName, bool? isMenu)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Option bL_Option = new BL_Option(AppConfig.DbConnection);
                //bL_Option.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Option.GetOptionMenuByUserName(userName, (isMenu == null)? false: (bool)isMenu));

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
