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
    public class MailController : ApiController
    {

        [Route("api/Mail/PruebaMail")]
        [HttpPost]
        public BE_Json PruebaMail([FromBody] MailContent mailContent)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Mail bL_Mail = new BL_Mail();
                bL_Mail.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(bL_Mail.PruebaMail(mailContent));

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
