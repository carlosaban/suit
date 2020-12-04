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

namespace SUIT.Controllers
{

    public class CompanyController : ApiController
    {

        /*-------------------------------GET CompanyController-----------------------------*/


        //Get Company
        [Route("api/Company/GetCompany")]
        [HttpGet]
        public BE_Json GetCompany()
        {
            //BL_Company _blCompany = new BL_Company();
            //_blCompany.connectionString = AppConfig.DbConnection;
            //return _blCompany.GetCompany();


            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Company _blCompany = new BL_Company();
                _blCompany.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blCompany.GetCompany());

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

        [Route("api/Company/GetCompanyByCompanyTypeId")]
        [HttpPost]
        public BE_Json GetCompanyByCompanyTypeId([FromBody]BECompanyFilter _bECompanyFilter)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Company _blCompany = new BL_Company();
                _blCompany.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blCompany.GetCompanyGeneral(_bECompanyFilter));

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

        [Route("api/Company/GetCompanyGeneral")]
        [HttpPost]
        public BE_Json GetCompanyGeneral([FromBody]BECompanyFilter _bECompanyFilter)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Company _blCompany = new BL_Company();
                _blCompany.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blCompany.GetCompanyGeneral(_bECompanyFilter));

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

        [Route("api/Company/GetClients")]
        [HttpGet]
        public BE_Json GetClients()
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Company _blCompany = new BL_Company();
                _blCompany.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blCompany.GetClients());

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

        [Route("api/Company/GetProviders")]
        [HttpGet]
        public BE_Json GetProviders()
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Company _blCompany = new BL_Company();
                _blCompany.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blCompany.GetProviders());

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


        [Route("api/Company/GetSystemClients/{companyCode}")]
        [HttpGet]
        public BE_Json GetSystemClients(string companyCode)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Company _blCompany = new BL_Company();
                _blCompany.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blCompany.GetSystemClients(companyCode));

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

        [Route("api/Company/GetCompanyType")]
        [HttpGet]
        public BE_Json GetCompanyType()
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Company _blCompany = new BL_Company();
                _blCompany.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blCompany.GetCompanyType());

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

        /*-------------------------------POST CompanyController-----------------------------*/


        //Post Company
        [Route("api/Company/CreateCompany")]
        [HttpPost]
        public BE_Json CreateCompany([FromBody]BE_Company _BeCompany)
        {
            //BL_Company _blCompany = new BL_Company();
            //_blCompany.connectionString = AppConfig.DbConnection;
            //return _blCompany.CreateCompany(_BeCompany);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Company _blCompany = new BL_Company();
                _blCompany.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blCompany.CreateCompany(_BeCompany));

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

        
        /*-------------------------------PUT CompanyController-----------------------------*/


        //Put Company
        [Route("api/Company/UpdateCompany")]
        [HttpPatch]
        public BE_Json UpdateCompany(BE_Company _BeCompany)
        {
            //BL_Company _blCompany = new BL_Company();
            //_blCompany.connectionString = AppConfig.DbConnection;
            //return _blCompany.UpdateCompany(_BeCompany);


            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Company _blCompany = new BL_Company();
                _blCompany.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blCompany.UpdateCompany(_BeCompany));

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

        //Put/Delete Company
        [Route("api/Company/DeleteCompany")]
        [HttpPatch]
        public BE_Json DeleteCompany(BE_Company _BeCompany)
        {
            //BL_Company _blCompany = new BL_Company();
            //_blCompany.connectionString = AppConfig.DbConnection;
            //return _blCompany.DeleteCompany(_BeCompany);


            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Company _blCompany = new BL_Company();
                _blCompany.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blCompany.DeleteCompany(_BeCompany));

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


        /*-------------------------------DELETE CompanyController-----------------------------*/


        //DELETE: api/ApiWithActions/5
        [Route("api/Company/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
