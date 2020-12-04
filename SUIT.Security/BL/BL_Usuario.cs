
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT.BE;
using SUIT.Security.BE;
using SUIT.Security.DA;
using SUIT.BL;
using SUIT.Security.BE.Filters;

namespace SUIT.Security.BL
{
    public class BL_Usuario
    {
        public static Guid NewGuid;

        public MySQLDatabase _database;
        public string connectionString;

        //private MySQLDatabase _database = new MySQLDatabase("DefaultConnection");
        // public MySQLDatabase _database = new MySQLDatabase("DefaultConnection");

        public BE_User LoginValidation(string userName, string passwordHash, BE_LoginType loginType )
        {
            _database = new MySQLDatabase(connectionString);
            DA_User objDA_USer = new DA_User(_database);
            BE_User resultBe_User;

            switch (loginType)
            {
                
                case BE_LoginType.FacebookLogin:
                    resultBe_User = null;
                    break;
                case BE_LoginType.GoogleLogin:
                    resultBe_User = null;
                    break;
                default:
                    resultBe_User = objDA_USer.loginValidation(userName, BE.Security.Encriptar(passwordHash));
                    break;
            }
            resultBe_User.Options = (new BL_Option(this.connectionString)).GetOptionMenuByUserName(userName);
            resultBe_User.OptionsMenu = resultBe_User.Options.FindAll(x => x.ismenu==1 );


            return resultBe_User;

        }
        public BE_User LoginValidation(string userName, string passwordHash)
        {
            return LoginValidation(userName, passwordHash, BE_LoginType.Normal);
        }

        public VE_User GetUserInfo(string userName)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).getUserInfo(userName);
        }

        public BE_Mail GetMailInfo(int idMail)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).getMailInfo(idMail);
        }

        public List<VE_UserCompany> GetUserCompanies(string userName)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).getUserCompanies(userName);
        }

        public List<VE_UserRoles> GetUserRole(string userId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).getUserRole(userId);
        }

        public  BE_User SetNewPassword(VE_User _VeUser)
        {
            _database = new MySQLDatabase(connectionString);
            int idMail= 2;
            
            BE_Mail _BeMail = GetMailInfo(idMail);
            _VeUser.passwordHash= BE.Security.Encriptar(_VeUser.passwordHash);
           BE_User _BeUser=  new DA_User(_database).setNewPassword(_VeUser);

            string body = _BeMail.bodyMail;

            body = body.Replace("@FirstName", _VeUser.firstName);
            body = body.Replace("@LastName", _VeUser.lastName);
            if (_BeUser != null)
            {
                BL_Mail _BlMail = new BL_Mail();
                _BlMail.SendEmail("testMail@suit.pe", _BeUser.userName, _BeMail.subjectMail, body);
                return _BeUser;
            }
            else
            {
                throw new ApplicationException("Ususario incorrecto o inexistente");
            }
        }

        public BE_User SetPasswordRecovery( VE_User _VeUser)
        {
            _database = new MySQLDatabase(connectionString);
            int idMail = 1;
             
             BE_Mail _BeMail = GetMailInfo(idMail);

            BE_User _BeUser = new DA_User(_database).setPasswordRecovery(_VeUser);

            string body = _BeMail.bodyMail;

            body =body.Replace("@FirstName", _VeUser.firstName);
            body =body.Replace("@LastName", _VeUser.lastName);

            if (_BeUser != null) {
                BL_Mail _BlMail = new BL_Mail();
                _BlMail.SendEmail("testMail@suit.pe", _VeUser.userName, _BeMail.subjectMail, body);
                return _BeUser;
            }
            else
            {
                throw new ApplicationException("Ususario incorrecto o inexistente");
            }
            
        }

        public VE_UserRoles UpdateUserRole(VE_UserRoles _VeUserRoles)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).updateUserRole(_VeUserRoles);
        }

        public VE_User UpdateUser(VE_User _VeUser)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).updateUser(_VeUser);
        }

        public List<BE_UserRoles> GetUserRoleId()
        {
            _database = new MySQLDatabase(connectionString);
            
            return new DA_User(_database).getUserRoleId();
        }

        public List<VE_User> GetUser()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).getUser();
        }

        public VE_UserRoles CreateUserRole(VE_UserRoles _VeUSerRoles)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).createUserRole(_VeUSerRoles);
        }

        public VE_User CreateUser(VE_User user)
        {

            Guid g;
            // Create and display the value of two GUIDs.
            g = Guid.NewGuid();
            user.id=Guid.NewGuid().ToString();
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).createUser(user);
        }

        public VE_UserRoles DeleteUserRole(VE_UserRoles _VeUserRoles)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).deleteUserRole(_VeUserRoles);
        }

        public VE_User DeleteUser(VE_User _VeUser)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).deleteUser(_VeUser);
        }
        
        public List<BE_UserCompany> GetUserCompany()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).getUserCompany();
        }

        public VE_UserCompany CreateUserCompany(VE_UserCompany _VeUserCompany)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).createUserCompany(_VeUserCompany);
        }

        public VE_UserCompany UpdateUserCompany(VE_UserCompany _VeUserCompany)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).updateUserCompany(_VeUserCompany);
        }

        public VE_UserCompany DeleteUserCompany(VE_UserCompany _VeUserCompany)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).deleteUserCompany(_VeUserCompany);
        }

        public BE_Roles GetRoleIdbyRoleName(string roleName)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).getRoleIdbyRoleName(roleName);
        }
        public List<BE_Roles> GetRoleName()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).getRoleName();
        }
        public List<BE_Roles> GetRoles()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).getRoles();
        }
        public List<VE_UserCompany> GetUserNameByCompanyCode(string CompanyCode,int paymentAuthId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).getUserNameByCompanyCode(CompanyCode, paymentAuthId);
        }

        public List<BE_User> GetUserGeneral(BE_UserFilter bE_UserFilter)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).getUserGeneral(bE_UserFilter);
        }

        

        public VE_User CreateUserGeneral(VE_User vE_User, List<string> CompanyCodeList, List<string> RoleIdList,bool authorize)
        {
            _database = new MySQLDatabase(connectionString);
            var user = new DA_User(_database).CreateUserGeneral(vE_User);
            foreach(var ri in RoleIdList)
            {
                CreateUserRole(user.id, ri);
            }
            foreach (var cc in CompanyCodeList)
            {
                CreateUserCompany(user.id, cc,authorize );
            }
            return user;
        }

        public int DeleteUserGeneral(VE_User vE_User)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).deleteUserGeneral(vE_User);
        }

        public int CreateUserRole(string userId, string roleId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).CreateUserRole(userId, roleId);
        }

        public int CreateUserCompany(string userId, string companyCode,bool authorize)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).CreateUserCompany(userId, companyCode,authorize);
        }

        public int DeleteUserRoles(string userId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).DeleteUserRoles(userId);
        }

        public int DeleteUserCompanys(string userId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).DeleteUserCompanys(userId);
        }


        public List<VE_UserRoles> GetUserRoles(string userId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).GetUserRoles(userId);
        }

        public VE_User UpdateUserGeneral(VE_User vE_User, List<string> CompanyCodeList, List<string> RoleIdList, bool authorize)
        {
            _database = new MySQLDatabase(connectionString);
            var user = new DA_User(_database).updateUserGeneral(vE_User);
            DeleteUserRoles(user.id);
            DeleteUserCompanys(user.id);
            foreach (var ri in RoleIdList)
            {
                CreateUserRole(user.id, ri);
            }
            foreach (var cc in CompanyCodeList)
            {
                CreateUserCompany(user.id, cc, authorize);
            }
            return user;
        }
    }

}