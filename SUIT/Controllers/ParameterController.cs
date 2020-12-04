using Newtonsoft.Json;
using SUIT.BE;
using SUIT.Pago.BE.n;
using SUIT.Pago.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SUIT.Controllers
{
    public class ParameterController : ApiController
    {

        [Route("api/Parameter/GetParameter")]
        [HttpGet]
        public BE_Json GetParameter()
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Parameter bL_Parameter = new BL_Parameter();
                bL_Parameter.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Parameter.GetParameter());

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

        [Route("api/Parameter/GetParameter/{idParameter}")]
        [HttpGet]
        public BE_Json GetParameter(int idParameter)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Parameter bL_Parameter = new BL_Parameter();
                bL_Parameter.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Parameter.GetParameter(idParameter));

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


        [Route("api/Parameter/CreateParameter")]
        [HttpPost]
        public BE_Json CreateParameter([FromBody]BE_Parameter bE_Parameter)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Parameter bL_Parameter = new BL_Parameter();
                bL_Parameter.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Parameter.CreateParameter(bE_Parameter));

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


        [Route("api/Parameter/UpdateParameter")]
        [HttpPut]
        public BE_Json UpdateParameter([FromBody]BE_Parameter bE_Parameter)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Parameter bL_Parameter = new BL_Parameter();
                bL_Parameter.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Parameter.UpdateParameter(bE_Parameter));

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


        [Route("api/Parameter/DeleteParameter/{idParameter}")]
        [HttpDelete]
        public BE_Json DeleteParameter(int idParameter)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Parameter bL_Parameter = new BL_Parameter();
                bL_Parameter.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Parameter.DeleteParameter(idParameter));

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



        [Route("api/Parameter/GetParameterDetail")]
        [HttpGet]
        public BE_Json GetParameterDetail()
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Parameter bL_Parameter = new BL_Parameter();
                bL_Parameter.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Parameter.GetParameterDetail());

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

        [Route("api/Parameter/GetParameterDetailByIdParameter/{idParameter}")]
        [HttpGet]
        public BE_Json GetParameterDetailByIdParameter(int idParameter)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Parameter bL_Parameter = new BL_Parameter();
                bL_Parameter.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Parameter.GetParameterDetailByIdParameter(idParameter));

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

        [Route("api/Parameter/GetParameterDetailById/{idParameterDetail}")]
        [HttpGet]
        public BE_Json GetParameterDetailByIdParameterDetail(int idParameterDetail)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Parameter bL_Parameter = new BL_Parameter();
                bL_Parameter.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Parameter.GetParameterDetailById(idParameterDetail));

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

        [Route("api/Parameter/CreateParameterDetail")]
        [HttpPost]
        public BE_Json CreateParameterDetail([FromBody]BE_ParameterDetail bE_ParameterDetail)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Parameter bL_Parameter = new BL_Parameter();
                bL_Parameter.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Parameter.CreateParameterDetail(bE_ParameterDetail));

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


        [Route("api/Parameter/UpdateParameterDetail")]
        [HttpPut]
        public BE_Json UpdateParameterDetail([FromBody]BE_ParameterDetail bE_ParameterDetail)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Parameter bL_Parameter = new BL_Parameter();
                bL_Parameter.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Parameter.UpdateParameterDetail(bE_ParameterDetail));

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


        [Route("api/Parameter/DeleteParameterDetail/{idParameterDetail}")]
        [HttpDelete]
        public BE_Json DeleteParameterDetail(int idParameterDetail)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Parameter bL_Parameter = new BL_Parameter();
                bL_Parameter.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Parameter.DeleteParameterDetail(idParameterDetail));

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
