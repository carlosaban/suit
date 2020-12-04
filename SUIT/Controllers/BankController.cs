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
using SUIT.ViewModel;

namespace SUIT.Controllers.APIController
{

    public class BankController : ApiController
    {

        /*-------------------------------GET BankController-----------------------------*/


        //Get CompanyBankBalance
        [Route("api/Bank/GetCompanyBankBalance/{companyCode}")]
        [HttpGet]
        public BE_Json GetCompanyBankBalance(string companyCode)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                //return _blBank.GetCompanyBankBalance(companyCode);
                objListaAux = JsonConvert.SerializeObject(_blBank.GetCompanyBankBalance(companyCode));

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

        //Get BankById
        [Route("api/Bank/GetBankById/{bankId}")]
        [HttpGet]
        public BE_Json GetBankById(int bankId)
        {
            //BL_Bank _blBank = new BL_Bank();
            //_blBank.connectionString = AppConfig.DbConnection;
            //return _blBank.GetBankById(bankId);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                //return _blBank.GetCompanyBankBalance(companyCode);
                objListaAux = JsonConvert.SerializeObject(_blBank.GetBankById(bankId));

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

        //Get BankAccountById
        [Route("api/Bank/GetBankAccountById/{bankAccountId}")]
        [HttpGet]
        public BE_Json GetBankAccountById(int bankAccountId)
        {
            //BL_Bank _blBank = new BL_Bank();
            //_blBank.connectionString = AppConfig.DbConnection;
            //return _blBank.GetBankAccountById(bankAccountId);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                //return _blBank.GetCompanyBankBalance(companyCode);
                objListaAux = JsonConvert.SerializeObject(_blBank.GetBankAccountById(bankAccountId));

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

        //Get BankAccountByPaymentAuthId
        [Route("api/Bank/GetBankAccountByPaymentAuthId/{bankAccountId}")]
        [HttpGet]
        public BE_Json GetBankAccountByPaymentAuthId(int bankAccountId)
        {
            //BL_Bank _blBank = new BL_Bank();
            //_blBank.connectionString = AppConfig.DbConnection;
            //return _blBank.GetBankAccountByPaymentAuthId(bankAccountId);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                //return _blBank.GetCompanyBankBalance(companyCode);
                objListaAux = JsonConvert.SerializeObject(_blBank.GetBankAccountByPaymentAuthId(bankAccountId));

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

        //Get BankAccount
        [Route("api/Bank/GetBankAccount")]
        [HttpGet]
        public BE_Json GetBankAccount()
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blBank.GetBankAccount());

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
    

        [Route("api/Bank/GetBankAccountByCompanyCode/{CompanyCode}")]
        [HttpGet]
        public BE_Json getBankAccountByCompanyCode(string CompanyCode)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blBank.getBankAccountByCompanyCode(CompanyCode));

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

        //Get BankAccount
        [Route("api/Bank/GetBank")]
        [HttpGet]
        public BE_Json GetBank()
        {
            //BL_Bank _blBank = new BL_Bank();
            //_blBank.connectionString = AppConfig.DbConnection;
            //return _blBank.GetBank();

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                //return _blBank.GetCompanyBankBalance(companyCode);
                objListaAux = JsonConvert.SerializeObject(_blBank.GetBank());

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

        //Get BankMaster
        [Route("api/Bank/GetBankMaster")]
        [HttpGet]
        public BE_Json GetBankMaster()
        {
            //BL_Bank _blBank = new BL_Bank();
            //_blBank.connectionString = AppConfig.DbConnection;
            //return _blBank.GetBankMaster();

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                //return _blBank.GetCompanyBankBalance(companyCode);
                objListaAux = JsonConvert.SerializeObject(_blBank.GetBankMaster());

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

        [Route("api/Bank/GetBankAdjusmentHistory/{bankAccountId}")]
        [HttpGet]
        public BE_Json GetBankAdjusmentHistory(int bankAccountId)
        {
            
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blBank.GetBankAdjusmentHistory(bankAccountId));

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

        /*-------------------------------POST BankController-----------------------------*/


        //Post BankAccount
        [Route("api/Bank/CreateBankAccount")]
        [HttpPost]
        public BE_Json CreateBankAccount([FromBody]VE_BankAccount _VeBankAccount)
        {
            //BL_Bank _blBank = new BL_Bank();
            //_blBank.connectionString = AppConfig.DbConnection;
            //return _blBank.CreateBankAccount(_VeBankAccount);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                //return _blBank.GetCompanyBankBalance(companyCode);
                objListaAux = JsonConvert.SerializeObject(_blBank.CreateBankAccount(_VeBankAccount));

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

        //Post Bank
        [Route("api/Bank/CreateBank")]
        [HttpPost]
        public BE_Json CreateBank([FromBody]VE_Bank _VeBank)
        {
            //BL_Bank _blBank = new BL_Bank();
            //_blBank.connectionString = AppConfig.DbConnection;
            //return _blBank.CreateBank(_VeBank);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                //return _blBank.GetCompanyBankBalance(companyCode);
                objListaAux = JsonConvert.SerializeObject(_blBank.CreateBank(_VeBank));

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

        //Post BankMaster
        [Route("api/Bank/CreateBankMaster")]
        [HttpPost]
        public BE_Json CreateBankMaster([FromBody]BE_BankMaster _BeBankMaster)
        {
            //BL_Bank _blBank = new BL_Bank();
            //_blBank.connectionString = AppConfig.DbConnection;
            //return _blBank.CreateBankMaster(_BeBankMaster);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                //return _blBank.GetCompanyBankBalance(companyCode);
                objListaAux = JsonConvert.SerializeObject(_blBank.CreateBankMaster(_BeBankMaster));

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
        [Route("api/Bank/BankAdjustment")]
        [HttpPost]
        public BE_Json BankAdjustment([FromBody]VE_Invoice vE_Invoice)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blBank.BankAdjustment(vE_Invoice));

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


        /*-------------------------------PUT BankController-----------------------------*/


        //Put BankAccount
        [Route("api/Bank/UpdateBankAccount")]
        [HttpPatch]
        public BE_Json UpdateBankAccount([FromBody]VE_BankAccount _VeBankAccount)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blBank.UpdateBankAccount(_VeBankAccount));

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

        //Put UpdateBank
        [Route("api/Bank/UpdateBank")]
        [HttpPatch]
        public BE_Json UpdateBank([FromBody]VE_Bank _VeBank)
        {
            //BL_Bank _blBank = new BL_Bank();
            //_blBank.connectionString = AppConfig.DbConnection;
            //return _blBank.UpdateBank(_VeBank);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                //return _blBank.GetCompanyBankBalance(companyCode);
                objListaAux = JsonConvert.SerializeObject(_blBank.UpdateBank(_VeBank));

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

        //Put BankMaster
        [Route("api/Bank/UpdateBankMaster")]
        [HttpPatch]
        public BE_Json UpdateBankMaster([FromBody]BE_BankMaster _BeBankMaster)
        {
            //BL_Bank _blBank = new BL_Bank();
            //_blBank.connectionString = AppConfig.DbConnection;
            //return _blBank.UpdateBankMaster(_BeBankMaster);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                //return _blBank.GetCompanyBankBalance(companyCode);
                objListaAux = JsonConvert.SerializeObject(_blBank.UpdateBankMaster(_BeBankMaster));

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

        //Put/Delete BankAccount
        [Route("api/Bank/DeleteBankAccount")]
        [HttpPatch]
        public BE_Json DeleteBankAccount([FromBody]VE_BankAccount _VeBankAccount)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blBank.DeleteBankAccount(_VeBankAccount));

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

        //Put UpdateBank
        [Route("api/Bank/DeleteBank")]
        [HttpPatch]
        public BE_Json DeleteBank([FromBody]VE_Bank _VeBank)
        {
            //BL_Bank _blBank = new BL_Bank();
            //_blBank.connectionString = AppConfig.DbConnection;
            //return _blBank.DeleteBank(_VeBank);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                //return _blBank.GetCompanyBankBalance(companyCode);
                objListaAux = JsonConvert.SerializeObject(_blBank.DeleteBank(_VeBank));

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

        /*-------------------------------DELETE BankController-----------------------------*/


        //Delete BankMaster
        [Route("api/Bank/DeleteBankMaster")]
        [HttpDelete]
        public BE_Json DeleteBankMaster(BE_BankMaster _BeBankMaster)
        {
            //BL_Bank _blBank = new BL_Bank();
            //_blBank.connectionString = AppConfig.DbConnection;
            //return _blBank.DeleteBankMaster(_BeBankMaster);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Bank _blBank = new BL_Bank();
                _blBank.connectionString = AppConfig.DbConnection;
                //return _blBank.GetCompanyBankBalance(companyCode);
                objListaAux = JsonConvert.SerializeObject(_blBank.DeleteBankMaster(_BeBankMaster));

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
