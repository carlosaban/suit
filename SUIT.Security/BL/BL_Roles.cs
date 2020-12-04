using SUIT.Security.BE;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Security.BL
{
    public class BL_Roles
    {

        public MySQLDatabase _database;
        public string connectionString;

        public List<BE_Roles> GetRoleGeneral(int roleId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Roles(_database).getRoleGeneral( roleId);
        }

        public BE_Roles CreateRoleGeneral(BE_Roles bE_Roles)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Roles(_database).CreateRoleGeneral(bE_Roles);
        }

        public BE_Roles UpdateRoleGeneral(BE_Roles bE_Roles)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Roles(_database).updateRoleGeneral(bE_Roles);
        }
    }
}
