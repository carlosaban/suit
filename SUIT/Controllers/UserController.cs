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
using SUIT.Security.BE;
using SUIT.Security.BL;
using SUIT.Security.BE.Filters;
using SUIT.ViewModel;

namespace SUIT.Controllers.APIController
{
    //[Route("api/[controller]")]

    public class UserController : ApiController
    {

        /*-------------------------------GET UserController-----------------------------*/



        //Get User
        [Route("api/User/GetUser")]
        [HttpGet]
        public BE_Json GetUser()
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.GetUser();

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.GetUser());

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

        //public BE_Json GetUser()
        //{
        //    BL_Usuario _blUsuario = new BL_Usuario();
        //    _blUsuario.connectionString = AppConfig.DbConnection;
        //    BE_Json objJson = null;
        //    var objListaAux = string.Empty;
        //    try
        //    {

        //        objListaAux = JsonConvert.SerializeObject(_blUsuario.GetUser());

        //        objJson = new BE_Json();
        //        objJson.data = objListaAux;
        //        objJson.status = CManager.RESULTADO_WCF.OK;
        //    }
        //    catch (Exception ex)
        //    {
        //        objJson = new BE_Json();
        //        objJson.data = "Hubo en error en servidor:" + ex.Message + ";" + ex.StackTrace + ";" + ex.ToString();
        //        objJson.status = CManager.RESULTADO_WCF.ERROR;
        //    }
        //    finally
        //    {
        //        objListaAux = null;
        //    }
        //    return objJson;
        //}



        //Get UserRole


        [Route("api/User/GetUserRoleId")]
        [HttpGet]
        public BE_Json GetUserRoleId()
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.GetUserRoleId();

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.GetUserRoleId());

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

        //Get RoleName
        [Route("api/User/GetRoleName")]
        [HttpGet]
        public BE_Json GetRoleName()
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.GetRoleName();

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.GetRoleName());

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

        //Get Roles
        [Route("api/User/GetRoles")]
        [HttpGet]
        public BE_Json GetRoles()
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.GetRoles();

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.GetRoles());

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


        //Get UserInfoById
        [Route("api/User/GetUserInfo/{userName}")]
        [HttpGet]
        public BE_Json GetUserInfo(string userName)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.GetUserInfo(userName);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.GetUserInfo(userName));

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

        //Get RoleIdbyRoleName
        [Route("api/User/GetRoleIdbyRoleName/{roleName}")]
        [HttpGet]
        public BE_Json GetRoleIdbyRoleName(string roleName)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.GetRoleIdbyRoleName(roleName);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.GetRoleIdbyRoleName(roleName));

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

        //Get UserCompanyByEmail
        [Route("api/User/GetUserCompanies/{userName}")]
        [HttpGet]
        public BE_Json GetUserCompanies(string userName)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.GetUserCompanies(userName);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.GetUserCompanies(userName));

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

        //Get UserCompany
        [Route("api/User/GetUserCompany")]
        [HttpGet]
        public BE_Json GetUserCompany()
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.GetUserCompany();

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.GetUserCompany());

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

        //Get UserRoleById
        [Route("api/User/GetUserRole/{userId}")]
        [HttpGet]
        public BE_Json GetUserRole(string userId)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.GetUserRole(userId);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.GetUserRole(userId));

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

        //Get LoginValidation
        [Route("api/User/LoginValidation/{userName}/{passwordHash}/{LoginType?}")]
        [HttpGet]
        public BE_Json LoginValidation(string userName, string passwordHash , int LoginType = 0)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.LoginValidation(userName, passwordHash);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            BE_LoginType bE_LoginType = (BE_LoginType)LoginType;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.LoginValidation(userName, passwordHash, bE_LoginType));

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
        //Get MailInfo
        [Route("api/User/GetMailInfo/{idMail}")]
        [HttpGet]
        public BE_Json GetMailInfo(int idMail)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.GetMailInfo(idMail);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.GetMailInfo(idMail));

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


        //Post UserRole
        [Route("api/User/CreateUserRole")]
        [HttpPost]
        public BE_Json CreateUserRole([FromBody]VE_UserRoles _VeUserRoles)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.CreateUserRole(_VeUserRoles);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.CreateUserRole(_VeUserRoles));

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

        //Post User
        [Route("api/User/CreateUser")]
        [HttpPost]
        public BE_Json CreateUser([FromBody]VE_User _VeUser)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.CreateUser(_VeUser);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.CreateUser(_VeUser));

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

        //Post UserCompany
        [Route("api/User/CreateUserCompany")]
        [HttpPost]
        public BE_Json CreateUserCompany([FromBody]VE_UserCompany _VeUserCompany)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.CreateUserCompany(_VeUserCompany);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.CreateUserCompany(_VeUserCompany));

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

        //Get User
        [Route("api/User/GetUserGeneral")]
        [HttpPost]
        public BE_Json GetUserGeneral(BE_UserFilter bE_UserFilter)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.GetUserGeneral(bE_UserFilter));

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

        //Post User
        [Route("api/User/CreateUserGeneral")]
        [HttpPost]
        public BE_Json CreateUserGeneral([FromBody]CreateUserGeneralViewModel viewModel)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.CreateUserGeneral(viewModel.user,viewModel.CompanyCodeList,viewModel.RoleIdList,viewModel.authorize));

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


        //Put UserRole
        [Route("api/User/UpdateUserRole")]
        [HttpPatch]
        public BE_Json UpdateUserRole([FromBody]VE_UserRoles _VeUserRoles)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.UpdateUserRole(_VeUserRoles);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.UpdateUserRole(_VeUserRoles));

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

        //Put User
        [Route("api/User/UpdateUser")]
        [HttpPatch]
        public BE_Json UpdateUser(VE_User _VeUser)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.UpdateUser(_VeUser);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.UpdateUser(_VeUser));

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

        //Put UserCompany
        [Route("api/User/UpdateUserCompany")]
        [HttpPatch]
        public BE_Json UpdateUserCompany([FromBody]VE_UserCompany _VeUserCompany)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.UpdateUserCompany(_VeUserCompany);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.UpdateUserCompany(_VeUserCompany));

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

        //Put/Delete User
        [Route("api/User/DeleteUser")]
        [HttpPatch]
        public BE_Json DeleteUser([FromBody]VE_User _VeUser)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.DeleteUser(_VeUser);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.DeleteUser(_VeUser));

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

        //Put SetNewPassword
        [Route("api/User/SetNewPassword")]
        [HttpPatch]
        public BE_Json SetNewPassword([FromBody]VE_User _VeUser)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.SetNewPassword(_VeUser);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.SetNewPassword(_VeUser));

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
        //Put SetPasswordRecovery
        [Route("api/User/SetPasswordRecovery")]
        [HttpPatch]
        public BE_Json SetPasswordRecovery([FromBody]VE_User _VeUser)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.SetPasswordRecovery(_VeUser);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.SetPasswordRecovery(_VeUser));

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

        //Put User
        [Route("api/User/UpdateUserGeneral")]
        [HttpPost]
        public BE_Json UpdateUserGeneral([FromBody]CreateUserGeneralViewModel viewModel)
        {
            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.UpdateUserGeneral(viewModel.user,viewModel.CompanyCodeList,viewModel.RoleIdList,viewModel.authorize));

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

        //Put/Delete User
        [Route("api/User/DeleteUserGeneral")]
        [HttpPost]
        public BE_Json DeleteUserGeneral([FromBody]VE_User vE_User)
        {

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.DeleteUserGeneral(vE_User));

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


        //Delete UserRole
        [Route("api/User/DeleteUserRole")]
        [HttpDelete]
        public BE_Json DeleteUserRole(VE_UserRoles _VeUserRoles)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.DeleteUserRole(_VeUserRoles);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.DeleteUserRole(_VeUserRoles));

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

        //Delete UserCompany
        [Route("api/User/DeleteUserCompany")]
        [HttpDelete]
        public BE_Json DeleteUserCompany(VE_UserCompany _VeUserCompany)
        {
            //BL_Usuario _blUsuario = new BL_Usuario();
            //_blUsuario.connectionString = AppConfig.DbConnection;
            //return _blUsuario.DeleteUserCompany(_VeUserCompany);

            BE_Json objJson = null;
            var objListaAux = string.Empty;
            try
            {
                BL_Usuario _blUsuario = new BL_Usuario();
                _blUsuario.connectionString = AppConfig.DbConnection;
                objListaAux = JsonConvert.SerializeObject(_blUsuario.DeleteUserCompany(_VeUserCompany));

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
