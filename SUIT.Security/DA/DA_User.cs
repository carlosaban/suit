using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT.DA;
using SUIT.BE;
using SUIT.Security.BE;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using SUIT.Security.BE.Filters;

namespace SUIT.Security.DA
{
    public class DA_User
    {

        public MySQLDatabase _database { get; set; }// = new MySQLDatabase("pagosapp");


        /// <summary>
        /// Constructor that takes a MySQLDatabase instance 
        /// </summary>
        /// <param name="database"></param>
        public DA_User(MySQLDatabase database)
        {
            _database = database;
        }

        public List<VE_UserRoles> getUserRole(string userId)
        {
            VE_UserRoles role = null;
            List<VE_UserRoles> listRoles = new List<VE_UserRoles>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_userId", userId } };

            var rows = _database.QuerySP("sps_getUserRole", parameters);
            foreach (var row in rows)

            {
                role = new VE_UserRoles();
                role.userId = row["UserId"];
                role.RoleName = row["RoleName"];
                role.roleId = row["RoleId"];
                role.UserName = row["UserName"];
                listRoles.Add(role);
            }
            return listRoles;
        }

        public VE_User getUserInfo(string userName)
        {
            VE_User _veUser = null;
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_userName", userName } };

            var rows = _database.QuerySP("sps_obtenerDataUsuario", parameters);
            foreach (var row in rows)
            {
                _veUser = new VE_User();
                _veUser.firstName = row["FirstName"];
                _veUser.lastName = row["LastName"];
                _veUser.email = row["Email"];
                _veUser.id = row["Id"];
                _veUser.companyName = row["CompanyName"];
                _veUser.companyDocumento = row["CompanyRUC"];
                _veUser.companyCode = row["CompanyCode"];
            }

            return _veUser;
        }

        public List<VE_UserCompany> getUserCompanies(string userName)
        {
            VE_UserCompany _veUserCompany = null;
            List<VE_UserCompany> _lstUserCompanies = new List<VE_UserCompany>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_userName", userName } };

            var rows = _database.QuerySP("sps_getUserCompanies", parameters);
            foreach (var row in rows)
            {
                _veUserCompany = new VE_UserCompany();
                _veUserCompany.email = row["Email"];
                _veUserCompany.companyName = row["CompanyName"];
                _veUserCompany.companyCode = row["CompanyCode"];
                _veUserCompany.companyRuc = row["CompanyRuc"];
                _veUserCompany.quantityAuth = string.IsNullOrEmpty(row["quantityAuth"]) ? 0 : int.Parse(row["quantityAuth"]);
                _veUserCompany.authorize = string.IsNullOrEmpty(row["Authorize"]) ? 0 : int.Parse(row["Authorize"]);

                _lstUserCompanies.Add(_veUserCompany);
            }

            return _lstUserCompanies;
        }

        /// <summary>
        /// Returns the user's name given a user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GeBE_UserName(string userId)
        {
            string commandText = "Select Name from Users where Id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@id", userId } };

            return _database.GetStrValue(commandText, parameters);
        }

        /// <summary>
        /// Returns a User ID given a user name
        /// </summary>
        /// <param name="userName">The user's name</param>
        /// <returns></returns>
        public string GeBE_UserId(string userName)
        {
            string commandText = "Select Id from Users where UserName = @name";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@name", userName } };

            return _database.GetStrValue(commandText, parameters);
        }

        /// <summary>
        /// Returns an BE_User given the user's id
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public BE_User GeBE_UserById(string userId)
        {
            BE_User user = null;
            string commandText = "Select * from Users where Id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@id", userId } };

            var rows = _database.Query(commandText, parameters);
            if (rows != null && rows.Count == 1)
            {
                var row = rows[0];
                user = (BE_User)Activator.CreateInstance(typeof(BE_User));
                user.id = row["Id"];
                user.userName = row["UserName"];
                user.passwordHash = string.IsNullOrEmpty(row["PasswordHash"]) ? null : row["PasswordHash"];
                user.securityStamp = string.IsNullOrEmpty(row["SecurityStamp"]) ? null : row["SecurityStamp"];
                user.email = string.IsNullOrEmpty(row["Email"]) ? null : row["Email"];
                user.emailConfirmed = row["EmailConfirmed"] == "1" ? true : false;
                user.phoneNumber = string.IsNullOrEmpty(row["PhoneNumber"]) ? null : row["PhoneNumber"];
                user.phoneNumberConfirmed = row["PhoneNumberConfirmed"] == "1" ? true : false;
                user.lockoutEnabled = row["LockoutEnabled"] == "1" ? true : false;
                user.lockoutEnd = string.IsNullOrEmpty(row["LockoutEndDateUtc"]) ? DateTime.Now : DateTime.Parse(row["LockoutEndDateUtc"]);
                user.lockoutEndFormat = user.lockoutEnd.ToShortDateString();
                user.accessFailedCount = string.IsNullOrEmpty(row["AccessFailedCount"]) ? 0 : int.Parse(row["AccessFailedCount"]);
            }

            return user;
        }

        public VE_User createUser(Guid guid, VE_User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a list of BE_User instances given a user name
        /// </summary>
        /// <param name="userName">User's name</param>
        /// <returns></returns>
        public List<BE_User> GeBE_UserByName(string userName)
        {
            List<BE_User> users = new List<BE_User>();
            string commandText = "Select * from Users where UserName = @name";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@name", userName } };

            var rows = _database.Query(commandText, parameters);
            foreach (var row in rows)
            {
                BE_User user = (BE_User)Activator.CreateInstance(typeof(BE_User));
                user.id = row["Id"];
                user.userName = row["UserName"];
                user.passwordHash = string.IsNullOrEmpty(row["PasswordHash"]) ? null : row["PasswordHash"];
                user.securityStamp = string.IsNullOrEmpty(row["SecurityStamp"]) ? null : row["SecurityStamp"];
                user.email = string.IsNullOrEmpty(row["Email"]) ? null : row["Email"];
                user.emailConfirmed = row["EmailConfirmed"] == "1" ? true : false;
                user.phoneNumber = string.IsNullOrEmpty(row["PhoneNumber"]) ? null : row["PhoneNumber"];
                user.phoneNumberConfirmed = row["PhoneNumberConfirmed"] == "1" ? true : false;
                user.lockoutEnabled = row["LockoutEnabled"] == "1" ? true : false;
                user.twoFactorEnabled = row["TwoFactorEnabled"] == "1" ? true : false;
                user.lockoutEnd = string.IsNullOrEmpty(row["LockoutEndDateUtc"]) ? DateTime.Now : DateTime.Parse(row["LockoutEndDateUtc"]);
                user.lockoutEndFormat = user.lockoutEnd.ToShortDateString();
                user.accessFailedCount = string.IsNullOrEmpty(row["AccessFailedCount"]) ? 0 : int.Parse(row["AccessFailedCount"]);
                users.Add(user);
            }

            return users;
        }

        public List<BE_User> GeBE_UserByEmail(string email)
        {
            return null;
        }

        /// <summary>
        /// Return the user's password hash
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public VE_User loginValidation(string userName, string passwordHash)
        {
            VE_User _usuario = null;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userName", userName);
            parameters.Add("_passwordHash", passwordHash);
            var rows = _database.QuerySP("sp_validarLoginUsuarios", parameters);



            foreach (var row in rows)
            {

                _usuario = new VE_User();
                _usuario.id = row["Id"];
                _usuario.accessFailedCount = string.IsNullOrEmpty(row["AccessFailedCount"]) ? 0 : int.Parse(row["AccessFailedCount"]);
                _usuario.concurrencyStamp = row["ConcurrencyStamp"];
                _usuario.configuration = row["Configuration"];
                _usuario.email = row["Email"];
                _usuario.emailConfirmed = string.IsNullOrEmpty(row["EmailConfirmed"]) ? false : row["EmailConfirmed"].Equals("1") ? true : false;
                _usuario.firstName = row["FirstName"];
                _usuario.isEnabled = string.IsNullOrEmpty(row["IsEnabled"]) ? false : row["IsEnabled"].Equals("1") ? true : false;
                _usuario.lastName = row["LastName"];
                _usuario.lockoutEnabled = string.IsNullOrEmpty(row["LockoutEnabled"]) ? false : row["LockoutEnabled"].Equals("1") ? true : false;
                _usuario.lockoutEnd = string.IsNullOrEmpty(row["LockoutEnd"]) ? DateTime.MinValue : DateTime.Parse(row["LockoutEnd"]);
                _usuario.lockoutEndFormat = _usuario.lockoutEnd.ToShortDateString();
                _usuario.normalizedEmail = row["NormalizedEmail"];
                _usuario.normalizedUserName = row["NormalizedUserName"];
                _usuario.passwordHash = row["PasswordHash"];
                _usuario.phoneNumber = row["PhoneNumber"];
                _usuario.phoneNumberConfirmed = string.IsNullOrEmpty(row["PhoneNumberConfirmed"]) ? false : row["PhoneNumberConfirmed"].Equals("1") ? true : false;
                _usuario.securityStamp = row["SecurityStamp"];
                _usuario.twoFactorEnabled = string.IsNullOrEmpty(row["TwoFactorEnabled"]) ? false : row["TwoFactorEnabled"].Equals("1") ? true : false;
                _usuario.userName = row["UserName"];
                _usuario.companyName = row["CompanyName"];
                _usuario.companyDocumento = row["CompanyRUC"];
                _usuario.companyCode = row["CompanyCode"];
                _usuario.roleId = row["RoleId"];
                _usuario.rolaName = row["RoleName"];
                _usuario.quantityAuth = row["quantityAuth"];

            }
            return _usuario;

        }

        /// <summary>
        /// Sets the user's password hash
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public int SetPasswordHash(string userId, string passwordHash)
        {
            string commandText = "Update Users set PasswordHash = @pwdHash where Id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@pwdHash", passwordHash);
            parameters.Add("@id", userId);

            return _database.Execute(commandText, parameters);
        }

        /// <summary>
        /// Returns the user's security stamp
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetSecurityStamp(string userId)
        {
            string commandText = "Select SecurityStamp from Users where Id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@id", userId } };
            var result = _database.GetStrValue(commandText, parameters);

            return result;
        }

        /// <summary>
        /// Inserts a new user in the Users table
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Insert(BE_User user)
        {
            string commandText = @"Insert into Users (UserName, Id, PasswordHash, SecurityStamp,Email,EmailConfirmed,PhoneNumber,PhoneNumberConfirmed, AccessFailedCount,LockoutEnabled,LockoutEndDateUtc,TwoFactorEnabled)
                values (@name, @id, @pwdHash, @SecStamp,@email,@emailconfirmed,@phonenumber,@phonenumberconfirmed,@accesscount,@lockoutenabled,@lockoutenddate,@twofactorenabled)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", user.userName);
            parameters.Add("@id", user.id);
            parameters.Add("@pwdHash", user.passwordHash);
            parameters.Add("@SecStamp", user.securityStamp);
            parameters.Add("@email", user.email);
            parameters.Add("@emailconfirmed", user.emailConfirmed);
            parameters.Add("@phonenumber", user.phoneNumber);
            parameters.Add("@phonenumberconfirmed", user.phoneNumberConfirmed);
            parameters.Add("@accesscount", user.accessFailedCount);
            parameters.Add("@lockoutenabled", user.lockoutEnabled);
            parameters.Add("@lockoutenddate", user.lockoutEnd);
            parameters.Add("@twofactorenabled", user.twoFactorEnabled);

            return _database.Execute(commandText, parameters);
        }

        /// <summary>
        /// Deletes a user from the Users table
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        private int Delete(string userId)
        {
            string commandText = "Delete from Users where Id = @userId";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@userId", userId);

            return _database.Execute(commandText, parameters);
        }

        /// <summary>
        /// Deletes a user from the Users table
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Delete(BE_User user)
        {
            return Delete(user.id);
        }

        /// <summary>
        /// Updates a user in the Users table
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Update(BE_User user)
        {
            string commandText = @"Update Users set UserName = @userName, PasswordHash = @pswHash, SecurityStamp = @secStamp, 
                Email=@email, EmailConfirmed=@emailconfirmed, PhoneNumber=@phonenumber, PhoneNumberConfirmed=@phonenumberconfirmed,
                AccessFailedCount=@accesscount, LockoutEnabled=@lockoutenabled, LockoutEndDateUtc=@lockoutenddate, TwoFactorEnabled=@twofactorenabled  
                WHERE Id = @userId";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@userName", user.userName);
            parameters.Add("@pswHash", user.passwordHash);
            parameters.Add("@secStamp", user.securityStamp);
            parameters.Add("@userId", user.id);
            parameters.Add("@email", user.email);
            parameters.Add("@emailconfirmed", user.emailConfirmed);
            parameters.Add("@phonenumber", user.phoneNumber);
            parameters.Add("@phonenumberconfirmed", user.phoneNumberConfirmed);
            parameters.Add("@accesscount", user.accessFailedCount);
            parameters.Add("@lockoutenabled", user.lockoutEnabled);
            parameters.Add("@lockoutenddate", user.lockoutEnd);
            parameters.Add("@twofactorenabled", user.twoFactorEnabled);

            return _database.Execute(commandText, parameters);
        }
        public VE_User setNewPassword(VE_User _VeUser)
        {

            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userName", _VeUser.userName);
            parameters.Add("_passwordHash", _VeUser.passwordHash);
            parameters.Add("_userAudit", _VeUser.userAudit);
            filasAfectadas = _database.ExecuteSP("spu_updatePassword", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {

                return _VeUser;

            }
            return null;
        }
        public VE_User setPasswordRecovery(VE_User _VeUser)
        {

            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userName", _VeUser.userName);
            parameters.Add("_userAudit", _VeUser.userAudit);
            filasAfectadas = _database.ExecuteSP("spu_updateLockoutEnabled", parameters);
            boResultado = (filasAfectadas > 0);

            if (boResultado)
            {



                return _VeUser;

            }
            return null;
        }
        public BE_Mail getMailInfo(int idMail)
        {
            BE_Mail _BeMail = null;
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_idMail", idMail } };

            var rows = _database.QuerySP("sps_getMailInfo", parameters);
            foreach (var row in rows)

            {
                _BeMail = new BE_Mail();
                _BeMail.idMail = string.IsNullOrEmpty(row["IdMail"]) ? 0 : int.Parse(row["IdMail"]);
                _BeMail.subjectMail = row["SubjectMail"];
                _BeMail.bodyMail = row["BodyMail"];
                _BeMail.descriptionMail = row["DescriptionMail"];
                _BeMail.toMail = row["ToMail"];
            }
            return _BeMail;
        }
        public VE_UserRoles updateUserRole(VE_UserRoles _VeUserRoles)
        {

            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userId", _VeUserRoles.userId);
            parameters.Add("_roleId", _VeUserRoles.roleId);
            parameters.Add("_userAudit", _VeUserRoles.userAudit);



            filasAfectadas = _database.ExecuteSP("spu_updateAspnetuserrole", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {


                return _VeUserRoles;

            }
            return null;

        }
        public VE_User updateUser(VE_User _VeUser)
        {

            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id",_VeUser.id);
            parameters.Add("_accessFailedCount", _VeUser.accessFailedCount);
            parameters.Add("_concurrencyStamp", _VeUser.concurrencyStamp);
            parameters.Add("_configuration", _VeUser.configuration);
            parameters.Add("_email", _VeUser.email);
            parameters.Add("_emailConfirmed", _VeUser.emailConfirmed);
            parameters.Add("_firstName", _VeUser.firstName);
            parameters.Add("_isEnabled", _VeUser.isEnabled);
            parameters.Add("_lastName", _VeUser.lastName);
            parameters.Add("_lockoutEnabled", _VeUser.lockoutEnabled);
            parameters.Add("_lockoutEnd", _VeUser.lockoutEnd);
            parameters.Add("_normalizedEmail", _VeUser.normalizedEmail);
            parameters.Add("_normalizedUserName", _VeUser.normalizedUserName);
            parameters.Add("_passwordHash", _VeUser.passwordHash);
            parameters.Add("_phoneNumber", _VeUser.phoneNumber);
            parameters.Add("_phoneNumberConfirmed", _VeUser.phoneNumberConfirmed);
            parameters.Add("_securityStamp", _VeUser.securityStamp);
            parameters.Add("_twoFactorEnabled", _VeUser.twoFactorEnabled);
            parameters.Add("_userName", _VeUser.userName);
            parameters.Add("_userAudit", _VeUser.userAudit);


            filasAfectadas = _database.ExecuteSP("spu_updateAspnetuser", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _VeUser;

            }
            return null;
        }
        public List<BE_UserRoles> getUserRoleId()
        {
            BE_UserRoles _BeUserRoles = null;
            List<BE_UserRoles> _lstUserRoles = new List<BE_UserRoles>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            var rows = _database.QuerySP("sps_getAspnetuserrole", parameters);
            foreach (var row in rows)

            {
                _BeUserRoles = new BE_UserRoles();
                _BeUserRoles.userId = row["UserId"];
                _BeUserRoles.roleId = row["RoleId"];
                _lstUserRoles.Add(_BeUserRoles);
            }
            return _lstUserRoles;
        }
        public List<VE_User> getUser()
        {
            VE_User _VeUser = null;
            List<VE_User> _lstUser = new List<VE_User>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            var rows = _database.QuerySP("sps_getAspnetuser", parameters);
            foreach (var row in rows)

            {
                _VeUser = new VE_User();
                _VeUser.id = row["Id"];
                _VeUser.accessFailedCount = string.IsNullOrEmpty(row["AccessFailedCount"]) ? 0 : int.Parse(row["AccessFailedCount"]);
                _VeUser.concurrencyStamp = row["ConcurrencyStamp"];
                _VeUser.configuration = row["Configuration"];
                _VeUser.email = row["Email"];
                _VeUser.emailConfirmed = string.IsNullOrEmpty(row["EmailConfirmed"]) ? false : row["EmailConfirmed"].Equals("1") ? true : false;
                _VeUser.firstName = row["FirstName"];
                _VeUser.isEnabled = string.IsNullOrEmpty(row["IsEnabled"]) ? false : row["IsEnabled"].Equals("1") ? true : false;
                _VeUser.lastName = row["LastName"];
                _VeUser.lockoutEnabled = string.IsNullOrEmpty(row["LockoutEnabled"]) ? false : row["LockoutEnabled"].Equals("1") ? true : false;
                _VeUser.lockoutEnd = string.IsNullOrEmpty(row["LockoutEnd"]) ? DateTime.MinValue : DateTime.Parse(row["LockoutEnd"]);
                _VeUser.lockoutEndFormat = _VeUser.lockoutEnd.ToShortDateString();
                _VeUser.normalizedEmail = row["NormalizedEmail"];
                _VeUser.normalizedUserName = row["NormalizedUserName"];
                _VeUser.passwordHash = row["PasswordHash"];
                _VeUser.phoneNumber = row["PhoneNumber"];
                _VeUser.phoneNumberConfirmed = string.IsNullOrEmpty(row["PhoneNumberConfirmed"]) ? false : row["PhoneNumberConfirmed"].Equals("1") ? true : false;
                _VeUser.securityStamp = row["SecurityStamp"];
                _VeUser.twoFactorEnabled = string.IsNullOrEmpty(row["TwoFactorEnabled"]) ? false : row["TwoFactorEnabled"].Equals("1") ? true : false;
                _VeUser.userName = row["UserName"];

                _lstUser.Add(_VeUser);
            }
            return _lstUser;
        }
        public VE_UserRoles createUserRole(VE_UserRoles _VeUserRoles)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userId", _VeUserRoles.userId);
            parameters.Add("_roleId", _VeUserRoles.roleId);
            parameters.Add("_userAudit", _VeUserRoles.userAudit);


            filasAfectadas = _database.ExecuteSP("spi_insertAspnetuserrole", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _VeUserRoles;

            }
            return null;
        }
        public VE_User createUser(VE_User _VeUser)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id", _VeUser.id);
            parameters.Add("_accessFailedCount", _VeUser.accessFailedCount);
            parameters.Add("_concurrencyStamp", _VeUser.concurrencyStamp);
            parameters.Add("_configuration", _VeUser.configuration);
            parameters.Add("_email", _VeUser.email);
            parameters.Add("_emailConfirmed", _VeUser.emailConfirmed);
            parameters.Add("_firstName", _VeUser.firstName);
            parameters.Add("_isEnabled", _VeUser.isEnabled);
            parameters.Add("_lastName", _VeUser.lastName);
            parameters.Add("_lockoutEnabled", _VeUser.lockoutEnabled);
            parameters.Add("_lockoutEnd", _VeUser.lockoutEnd);
            parameters.Add("_normalizedEmail", _VeUser.normalizedEmail);
            parameters.Add("_normalizedUserName", _VeUser.normalizedUserName);
            parameters.Add("_passwordHash", _VeUser.passwordHash);
            parameters.Add("_phoneNumber", _VeUser.phoneNumber);
            parameters.Add("_phoneNumberConfirmed", _VeUser.phoneNumberConfirmed);
            parameters.Add("_securityStamp", _VeUser.securityStamp);
            parameters.Add("_twoFactorEnabled", _VeUser.twoFactorEnabled);
            parameters.Add("_userName", _VeUser.userName);
            parameters.Add("_userAudit", _VeUser.userAudit);

            filasAfectadas = _database.ExecuteSP("spi_insertAspnetuser", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _VeUser;

            }
            return null;
        }
        public VE_UserRoles deleteUserRole(VE_UserRoles _VeUserRole)
        {

            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userId", _VeUserRole.userId);
            parameters.Add("_roleId", _VeUserRole.roleId);


            filasAfectadas = _database.ExecuteSP("spd_deleteAspnetuserrole", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                _VeUserRole = new VE_UserRoles();
                _VeUserRole.userId = _VeUserRole.userId;
                _VeUserRole.roleId = _VeUserRole.roleId;

                return _VeUserRole;

            }
            return null;
        }
        public VE_User deleteUser(VE_User user)
        {


            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id", user.id);
            parameters.Add("_username", user.userName);
            parameters.Add("_userAudit", user.userAudit);


            filasAfectadas = _database.ExecuteSP("spd_deleteAspnetuser", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return user;

            }
            return null;
        }

        public List<BE_UserCompany> getUserCompany()
        {
            BE_UserCompany _VeUserCompany = null;
            List<BE_UserCompany> _lstUserCompany = new List<BE_UserCompany>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            var rows = _database.QuerySP("sps_getUserCompany", parameters);
            foreach (var row in rows)

            {
                _VeUserCompany = new VE_UserCompany();
                _VeUserCompany.userId = row["UserId"];
                _VeUserCompany.companyCode = row["CompanyCode"];
                _lstUserCompany.Add(_VeUserCompany);
            }
            return _lstUserCompany;


        }



        public VE_UserCompany createUserCompany(VE_UserCompany _VeUserCompany)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userId", _VeUserCompany.userId);
            parameters.Add("_companyCode", _VeUserCompany.companyCode);
            parameters.Add("_userAudit", _VeUserCompany.userAudit);

            filasAfectadas = _database.ExecuteSP("spi_insertUserCompany", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _VeUserCompany;

            }
            return null;
        }

        public VE_UserCompany updateUserCompany(VE_UserCompany _VeUserCompany)
        {
            int filasAfectadas = 0;

            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userId", _VeUserCompany.userId);
            parameters.Add("_companyCode", _VeUserCompany.companyCode);
            parameters.Add("_userAudit", _VeUserCompany.userAudit);


            filasAfectadas = _database.ExecuteSP("spu_updateUserCompany", parameters);


            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _VeUserCompany;
            }
            return null;
        }
        public VE_UserCompany deleteUserCompany(VE_UserCompany _VeUserCompany)
        {
            int filasAfectadas = 0;

            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userId", _VeUserCompany.userId);
            parameters.Add("_companyCode", _VeUserCompany.companyCode);

            filasAfectadas = _database.ExecuteSP("spd_deleteUserCompany", parameters);


            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _VeUserCompany;
            }
            return null;
        }
        public BE_Roles getRoleIdbyRoleName(string roleName)
        {
            BE_Roles _BeRoles = null;
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_name", roleName } };

            var rows = _database.QuerySP("sp_getRoleIdbyRoleName", parameters);
            foreach (var row in rows)

            {
                _BeRoles = new BE_Roles();
                _BeRoles.roleId = row["Id"];

            }
            return _BeRoles;
        }
        public List<BE_Roles> getRoleName()
        {
            BE_Roles _BeRoles = null;
            List<BE_Roles> _lstRoles = new List<BE_Roles>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            var rows = _database.QuerySP("sp_getRoleName", parameters);
            foreach (var row in rows)

            {
                _BeRoles = new BE_Roles();
                _BeRoles.name = row["Name"];
                _lstRoles.Add(_BeRoles);
            }
            return _lstRoles;
        }
        public List<BE_Roles> getRoles()
        {
            BE_Roles _BeRoles = null;
            List<BE_Roles> _lstRoles = new List<BE_Roles>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            var rows = _database.QuerySP("sp_getRoles", parameters);
            foreach (var row in rows)

            {
                _BeRoles = new BE_Roles();
                _BeRoles.roleId = row["Id"];
                _BeRoles.name = row["Name"];
                _lstRoles.Add(_BeRoles);
            }
            return _lstRoles;
        }

        public List<VE_UserCompany> getUserNameByCompanyCode(string CompanyCode,int paymentAuthId)
        {
            VE_UserCompany _veUserCompany = null;
            List<VE_UserCompany> _lstUserCompanies = new List<VE_UserCompany>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_CompanyCode", CompanyCode);
            parameters.Add("_PaymentAuthId", paymentAuthId);

            var rows = _database.QuerySP("sps_getUserNameByCompanyCode", parameters);
            foreach (var row in rows)
            {
                _veUserCompany = new VE_UserCompany();
                _veUserCompany.userName = row["UserName"];
                _veUserCompany.email = row["Email"];
                _veUserCompany.firstName = row["FirstName"];
                _veUserCompany.lastName = row["LastName"];
                _veUserCompany.authorize = string.IsNullOrEmpty(row["Authorize"]) ? 0 : int.Parse(row["Authorize"]);
                _veUserCompany.amountTotal =string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _veUserCompany.quantityAuth= string.IsNullOrEmpty(row["quantityAuth"]) ? 0 : int.Parse(row["quantityAuth"]);
                _lstUserCompanies.Add(_veUserCompany);
            }

            return _lstUserCompanies;
        }


        public List<BE_User> getUserGeneral(BE_UserFilter bE_UserFilter)
        {
            BE_User _BeUser = null;
            List<BE_User> _lstUser = new List<BE_User>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userId", bE_UserFilter.id);
            parameters.Add("_userEmailList", bE_UserFilter.UserEmailList);
            parameters.Add("_userNameList", bE_UserFilter.UserNameList);
            parameters.Add("_searchFilter", bE_UserFilter.SearchFilter);

            var rows = _database.QuerySP("sp_getUserGeneral", parameters);
            

            foreach (var row in rows)

            {
                _BeUser = new BE_User();
                _BeUser.id = row["Id"];
                _BeUser.accessFailedCount = string.IsNullOrEmpty(row["AccessFailedCount"]) ? 0 : int.Parse(row["AccessFailedCount"]);
                _BeUser.concurrencyStamp = row["ConcurrencyStamp"];
                _BeUser.configuration = row["Configuration"];
                _BeUser.email = row["Email"];
                _BeUser.emailConfirmed = string.IsNullOrEmpty(row["EmailConfirmed"]) ? false : row["EmailConfirmed"].Equals("1") ? true : false;
                _BeUser.firstName = row["FirstName"];
                _BeUser.isEnabled = string.IsNullOrEmpty(row["IsEnabled"]) ? false : row["IsEnabled"].Equals("1") ? true : false;
                _BeUser.lastName = row["LastName"];
                _BeUser.lockoutEnabled = string.IsNullOrEmpty(row["LockoutEnabled"]) ? false : row["LockoutEnabled"].Equals("1") ? true : false;
                _BeUser.lockoutEnd = string.IsNullOrEmpty(row["LockoutEnd"]) ? DateTime.MinValue : DateTime.Parse(row["LockoutEnd"]);
                _BeUser.lockoutEndFormat = _BeUser.lockoutEnd.ToShortDateString();
                _BeUser.normalizedEmail = row["NormalizedEmail"];
                _BeUser.normalizedUserName = row["NormalizedUserName"];
                _BeUser.passwordHash = row["PasswordHash"];
                _BeUser.phoneNumber = row["PhoneNumber"];
                _BeUser.phoneNumberConfirmed = string.IsNullOrEmpty(row["PhoneNumberConfirmed"]) ? false : row["PhoneNumberConfirmed"].Equals("1") ? true : false;
                _BeUser.twoFactorEnabled = string.IsNullOrEmpty(row["TwoFactorEnabled"]) ? false : row["TwoFactorEnabled"].Equals("1") ? true : false;
                _BeUser.userName = row["UserName"];

                _lstUser.Add(_BeUser);
            }
            return _lstUser;
        }


        public VE_User CreateUserGeneral(VE_User veUser)
        {
            string strError_Mensaje = string.Empty;
            object UserId = new object();

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_createdBy", veUser.userAudit);
            parameters.Add("_email", veUser.email);
            parameters.Add("_emailConfirmed", false );
            parameters.Add("_firstName", veUser.firstName);
            parameters.Add("_lastName", veUser.lastName);
            parameters.Add("_normalizedEmail", veUser.email.ToUpper());
            parameters.Add("_normalizedUserName", veUser.userName.ToUpper());
            parameters.Add("_passwordHash", BE.Security.Encriptar(veUser.passwordHash));
            parameters.Add("_phoneNumber", veUser.phoneNumber);
            parameters.Add("_phoneNumberConfirmed", false);
            parameters.Add("_twoFactorEnabled", false);
            parameters.Add("_userName", veUser.userName);

            UserId = _database.ExecuteSPGetId("sp_createUserGeneral", parameters);
            veUser.id = UserId.ToString();

            return veUser;

        }


        public VE_User updateUserGeneral(VE_User veUser)
        {

            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id", veUser.id);
            parameters.Add("_accessFailedCount", veUser.accessFailedCount);
            parameters.Add("_concurrencyStamp", veUser.concurrencyStamp);
            parameters.Add("_configuration", veUser.configuration);
            parameters.Add("_email", veUser.email);
            parameters.Add("_emailConfirmed", veUser.emailConfirmed);
            parameters.Add("_firstName", veUser.firstName);
            parameters.Add("_isEnabled", veUser.isEnabled);
            parameters.Add("_lastName", veUser.lastName);
            parameters.Add("_lockoutEnabled", veUser.lockoutEnabled);
            parameters.Add("_lockoutEnd", veUser.lockoutEnd);
            parameters.Add("_normalizedEmail", veUser.normalizedEmail);
            parameters.Add("_normalizedUserName", veUser.normalizedUserName);
            parameters.Add("_passwordHash", string.IsNullOrEmpty(veUser.passwordHash)?DBNull.Value:(object) BE.Security.Encriptar(veUser.passwordHash));
            parameters.Add("_phoneNumber", veUser.phoneNumber);
            parameters.Add("_phoneNumberConfirmed", veUser.phoneNumberConfirmed);
            parameters.Add("_securityStamp", veUser.securityStamp);
            parameters.Add("_twoFactorEnabled", veUser.twoFactorEnabled);
            parameters.Add("_userName", veUser.userName);
            parameters.Add("_updatedby", veUser.userAudit);


            filasAfectadas = _database.ExecuteSP("sp_updateUserGeneral", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return veUser;

            }
            return null;
        }


        public int deleteUserGeneral(VE_User vE_User)
        {

            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id", vE_User.id);
            parameters.Add("_updatedby", vE_User.userAudit);


            filasAfectadas = _database.ExecuteSP("sp_deleteUserGeneral", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return filasAfectadas;

            }
            return 0;
        }

        public int CreateUserRole(string userId, string roleId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userId", userId);
            parameters.Add("_roleId", roleId);


            filasAfectadas = _database.ExecuteSP("sp_createUserRole", parameters);

            
            return filasAfectadas;
        }



        public int CreateUserCompany(string userId, string companyCode,bool authorize)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userId", userId);
            parameters.Add("_companyCode", companyCode);
            parameters.Add("_authorize", authorize);

            filasAfectadas = _database.ExecuteSP("sp_createUserCompany", parameters);

            return filasAfectadas;
        }
       
        public List<VE_UserRoles> GetUserRoles(string userId)
        {

            List<VE_UserRoles> vE_Users = new List<VE_UserRoles>();
            VE_UserRoles vE_User = null;
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_userId", userId } };

            var rows = _database.QuerySP("sp_getUserRole", parameters);
            foreach (var row in rows)

            {
                vE_User = new VE_UserRoles();
                vE_User.userId = row["UserId"];
                vE_User.RoleName = row["RoleName"];
                vE_User.roleId = row["RoleId"];
                vE_User.UserName = row["UserName"];
                vE_Users.Add(vE_User);
            }
            return vE_Users;
        }


        public int DeleteUserRoles(string userId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userId", userId);


            filasAfectadas = _database.ExecuteSP("sp_deleteUserRole", parameters);
            
            return filasAfectadas;
        }

        public int DeleteUserCompanys(string userId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_userId", userId);


            filasAfectadas = _database.ExecuteSP("sp_deleteUserCompany", parameters);

            return filasAfectadas;
        }
    }
}