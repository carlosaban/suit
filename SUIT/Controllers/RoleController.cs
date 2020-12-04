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
    public class RoleController : ApiController
    {
        [Route("api/Role/GetRoleGeneral/{roleId}")]
        [HttpGet]
        public BE_Json GetRoleGeneral(int roleId)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Roles bL_Roles = new BL_Roles();
                bL_Roles.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Roles.GetRoleGeneral(roleId));

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

        [Route("api/Role/CreateRoleGeneral")]
        [HttpPost]
        public BE_Json CreateRoleGeneral(BE_Roles bE_Roles)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Roles bL_Roles = new BL_Roles();
                bL_Roles.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Roles.CreateRoleGeneral(bE_Roles));

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


        [Route("api/Role/UpdateRoleGeneral")]
        [HttpPost]
        public BE_Json UpdateRoleGeneral(BE_Roles bE_Roles)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Roles bL_Roles = new BL_Roles();
                bL_Roles.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Roles.UpdateRoleGeneral(bE_Roles));

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
