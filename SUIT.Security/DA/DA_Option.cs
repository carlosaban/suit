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
    public class DA_Option
    {

        public MySQLDatabase _database { get; set; }


        public DA_Option(MySQLDatabase database)
        {
            _database = database;
        }
        
        public List<BE_Option> GetOptionGeneral(BE_Option bE_Option)
        {
            BE_Option _bE_Option = null;
            List<BE_Option> _lstOption = new List<BE_Option>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_idoption", bE_Option.idOption);
            parameters.Add("_idoptionparent", bE_Option.idOptionParent);
            var rows = _database.QuerySP("sp_getOptionGeneral", parameters);

            foreach (var row in rows)

            {
                _bE_Option = new BE_Option();
                _bE_Option.idOption = string.IsNullOrEmpty(row["idoption"]) ? 0 : int.Parse(row["idoption"]);
                _bE_Option.title = row["title"];
                _bE_Option.ismenu = string.IsNullOrEmpty(row["ismenu"]) ? 0 : int.Parse(row["ismenu"]);
                _bE_Option.url = row["url"];
                _bE_Option.idOptionParent = string.IsNullOrEmpty(row["Idoptionparent"]) ? 0 : int.Parse(row["Idoptionparent"]);
                _bE_Option.order = string.IsNullOrEmpty(row["order"]) ? 0 : int.Parse(row["order"]);
                _bE_Option.description = row["description"];


                _lstOption.Add(_bE_Option);
            }
            return _lstOption;
        }

        public BE_Option CreateOptionGeneral(BE_Option bE_Option)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_title", bE_Option.title);
            parameters.Add("_ismenu", bE_Option.ismenu);
            parameters.Add("_url", bE_Option.url);
            parameters.Add("_idoptionparent", bE_Option.idOptionParent);
            parameters.Add("_order", bE_Option.order);
            parameters.Add("_description", bE_Option.description);

            filasAfectadas = _database.ExecuteSP("sp_createOptionGeneral", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return bE_Option;

            }
            return null;
        }


        public BE_Option UpdateOptionGeneral(BE_Option bE_Option)
        {

            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_idoption", bE_Option.idOption);
            parameters.Add("_title", bE_Option.title);
            parameters.Add("_ismenu", bE_Option.ismenu);
            parameters.Add("_url", bE_Option.url);
            parameters.Add("_idoptionparent", bE_Option.idOptionParent);
            parameters.Add("_order", bE_Option.order);
            parameters.Add("_description", bE_Option.description);

            filasAfectadas = _database.ExecuteSP("sp_updateOptionGeneral", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return bE_Option;

            }
            return null;
        }


        public int DeleteOptionGeneral(int optionId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_optionId", optionId);


            filasAfectadas = _database.ExecuteSP("sp_deleteOptionGeneral", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return filasAfectadas;

            }
            return 0;
        }


        public int ValidateOption(int optionId, string userName)
        {
            string strError_Mensaje = string.Empty;
            int cont=0;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_optionId", optionId);
            parameters.Add("_userName", userName);


            var rows = _database.QuerySP("sp_validateOption", parameters);
            foreach (var row in rows)

            {
                cont = string.IsNullOrEmpty(row["validated"]) ? 0 : int.Parse(row["validated"]);
                
            }
            return cont;
        }


        public List<BE_Option> GetOptionMenuByUserName(string userName)
        {
            return this.GetOptionMenuByUserName(userName, true);

        }
        public List<BE_Option> GetOptionMenuByUserName(string userName, bool isMenu)
        {
            BE_Option _bE_Option = null;
            List<BE_Option> _lstOption = new List<BE_Option>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_userName", userName);
            parameters.Add("_isMenu", isMenu);

            var rows = _database.QuerySP("sp_getOptionMenuByUserName", parameters);

            foreach (var row in rows)

            {
                _bE_Option = new BE_Option();
                _bE_Option.idOption = string.IsNullOrEmpty(row["idoption"]) ? 0 : int.Parse(row["idoption"]);
                _bE_Option.title = row["title"];
                _bE_Option.ismenu = string.IsNullOrEmpty(row["ismenu"]) ? 0 : int.Parse(row["ismenu"]);
                _bE_Option.url = row["url"];
                _bE_Option.idOptionParent = string.IsNullOrEmpty(row["Idoptionparent"]) ? 0 : int.Parse(row["Idoptionparent"]);
                _bE_Option.order = string.IsNullOrEmpty(row["order"]) ? 0 : int.Parse(row["order"]);
                _bE_Option.description = row["description"];


                _lstOption.Add(_bE_Option);
            }
            return _lstOption;
        }

    }
}