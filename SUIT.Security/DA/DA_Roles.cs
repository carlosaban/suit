using SUIT.Security.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Security.DA
{
    public class DA_Roles
    {

        public MySQLDatabase _database { get; set; }


        public DA_Roles(MySQLDatabase database)
        {
            _database = database;
        }


        public List<BE_Roles> getRoleGeneral(int roleId)
        {
            BE_Roles bE_Roles = null;
            List<BE_Roles> _lstRoles = new List<BE_Roles>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_roleId", roleId);

            var rows = _database.QuerySP("sp_getRoleGeneral", parameters);

            foreach (var row in rows)

            {
                bE_Roles = new BE_Roles();
                bE_Roles.roleId = row["Id"];
                bE_Roles.concurrencyStamp = row["ConcurrencyStamp"];
                bE_Roles.description = row["Description"];
                bE_Roles.limitAmount = string.IsNullOrEmpty(row["LimitAmount"]) ? 0 : decimal.Parse(row["LimitAmount"]);
                bE_Roles.name = row["Name"];
                bE_Roles.normalizedName = row["NormalizedName"];
                _lstRoles.Add(bE_Roles);
            }
            return _lstRoles;
        }


        public BE_Roles CreateRoleGeneral(BE_Roles bE_Roles)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_concurrencyStamp", bE_Roles.concurrencyStamp);
            parameters.Add("_createdBy", bE_Roles.createdBy);
            parameters.Add("_description", bE_Roles.description);
            parameters.Add("_limitAmount", bE_Roles.limitAmount);
            parameters.Add("_name", bE_Roles.name);
            parameters.Add("_normalizedName", bE_Roles.normalizedName);

            filasAfectadas = _database.ExecuteSP("sp_createRoleGeneral", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return bE_Roles;

            }
            return null;
        }


        public BE_Roles updateRoleGeneral(BE_Roles bE_Roles)
        {

            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_roleId", bE_Roles.roleId);
            parameters.Add("_concurrencyStamp", bE_Roles.concurrencyStamp);
            parameters.Add("_description", bE_Roles.description);
            parameters.Add("_limitAmount", bE_Roles.limitAmount);
            parameters.Add("_name", bE_Roles.name);
            parameters.Add("_normalizedName", bE_Roles.normalizedName);
            parameters.Add("_updatedBy", bE_Roles.updatedBy);

            filasAfectadas = _database.ExecuteSP("sp_updateRoleGeneral", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return bE_Roles;

            }
            return null;
        }

        public int deleteOptionGeneral(int RoleId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_roleId", RoleId);


            filasAfectadas = _database.ExecuteSP("sp_deleteRoleGeneral", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return filasAfectadas;

            }
            return 0;
        }
    }
}
