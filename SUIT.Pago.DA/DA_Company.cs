using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT.DA;
using SUIT.BE;
using SUIT.Pago.BE;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using SUIT.Pago.BE.n.Filters;
using SUIT.Security.DA;
using SUIT.Pago.BE.n;

namespace SUIT.Pago.DA
{
    public class DA_Company
    {
        public MySQLDatabase _database { get; set; }// = new MySQLDatabase("pagosapp");


        /// <summary>
        /// Constructor that takes a MySQLDatabase instance 
        /// </summary>
        /// <param name="database"></param>
        public DA_Company(MySQLDatabase database)
        {
            _database = database;
        }

        public BE_Company UpdateCompany(BE_Company _BeCompany)
        {

            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", _BeCompany.companyCode);
            parameters.Add("_companyLimit", (_BeCompany.companyLimit == 0) ? DBNull.Value : (object)_BeCompany.companyLimit);
            parameters.Add("_companyName", _BeCompany.companyName);
            parameters.Add("_companyRUC", _BeCompany.companyRUC);
            parameters.Add("_companySys", _BeCompany.companySys);
            parameters.Add("_userAudit", _BeCompany.userAudit);
            parameters.Add("_companyType", _BeCompany.companyType);
            parameters.Add("_districtId", _BeCompany.districtId);
            parameters.Add("_quantityAuth", _BeCompany.quantityAuth);


            filasAfectadas = _database.ExecuteSP("spu_updateCompany", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _BeCompany;

            }
            return null;
        }
        public List<BE_Company> GetCompany()
        {
            BE_Company _BeCompany = null;
            List<BE_Company> _lstCompany = new List<BE_Company>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            var rows = _database.QuerySP("sps_getCompany", parameters);
            foreach (var row in rows)

            {
                _BeCompany = new BE_Company();
                _BeCompany.companyCode = row["CompanyCode"];
                _BeCompany.companyLimit = string.IsNullOrEmpty(row["CompanyLimit"]) ? 0 : decimal.Parse(row["CompanyLimit"]);
                _BeCompany.companyName = row["CompanyName"];
                _BeCompany.companyRUC = row["CompanyRUC"];
                _BeCompany.companySys = row["CompanySys"];
                _BeCompany.isEnabled = string.IsNullOrEmpty(row["IsEnabled"]) ? false : row["IsEnabled"].Equals("1") ? true : false;
                _lstCompany.Add(_BeCompany);
            }
            return _lstCompany;
        }
        public BE_Company CreateCompany(BE_Company _BeCompany)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", _BeCompany.companyCode);
            parameters.Add("_companyLimit", _BeCompany.companyLimit);
            parameters.Add("_companyName", _BeCompany.companyName);
            parameters.Add("_companyRUC", _BeCompany.companyRUC);
            parameters.Add("_userAudit", _BeCompany.userAudit);
            parameters.Add("_companyType", _BeCompany.companyType);
            parameters.Add("_districtId", _BeCompany.districtId);
            parameters.Add("_quantityAuth", _BeCompany.quantityAuth);

            filasAfectadas = _database.ExecuteSP("spi_insertCompany", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _BeCompany;

            }
            return null;
        }
        public BE_Company DeleteCompany(BE_Company _BeCompany)
        {
          
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", _BeCompany.companyCode);
            parameters.Add("_userAudit", _BeCompany.userAudit);


            filasAfectadas = _database.ExecuteSP("spd_deleteCompany", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                
                return _BeCompany;

            }
            return null;
        }

        public List<BE_Company> GetCompanyByTypeId(int companyTypeId)
        {
            BE_Company _BeCompany = null;
            List<BE_Company> _lstCompany = new List<BE_Company>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyTypeId", companyTypeId);

            var rows = _database.QuerySP("sps_getCompanyByTypeId", parameters);
            foreach (var row in rows)

            {
                _BeCompany = new BE_Company();
                _BeCompany.companyCode = row["CompanyCode"];
                _BeCompany.companyLimit = string.IsNullOrEmpty(row["CompanyLimit"]) ? 0 : decimal.Parse(row["CompanyLimit"]);
                _BeCompany.companyName = row["CompanyName"];
                _BeCompany.companyRUC = row["CompanyRUC"];
                _BeCompany.companySys = row["CompanySys"];
                _BeCompany.isEnabled = string.IsNullOrEmpty(row["IsEnabled"]) ? false : row["IsEnabled"].Equals("1") ? true : false;
                _BeCompany.companyType = row["companyType"];
                _BeCompany.districtId = row["districtId"];
                _BeCompany.quantityAuth = row["quantityAuth"];
                _lstCompany.Add(_BeCompany);
            }
            return _lstCompany;
        }


        public List<BE_Company> GetCompanyGeneral(BECompanyFilter _bECompanyFilter)
        {
            

            BE_Company _BeCompany = null;
            List<BE_Company> _lstCompany = new List<BE_Company>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", _bECompanyFilter.companyCode);//Eliminar en la proxima version
            parameters.Add("_companyTypeList", _bECompanyFilter.CompanyTypeList);
            parameters.Add("_searchFilter", (string.IsNullOrEmpty(_bECompanyFilter.SearchFilter))?"": _bECompanyFilter.SearchFilter);
            parameters.Add("_companyRuc", _bECompanyFilter.companyRUC);
            parameters.Add("_userName", _bECompanyFilter.userName);
            var rows = _database.QuerySP("sps_getCompanyGeneral", parameters);


            foreach (var row in rows)

            {
                _BeCompany = new BE_Company();
                _BeCompany.companyCode = row["CompanyCode"];
                _BeCompany.companyLimit = string.IsNullOrEmpty(row["CompanyLimit"]) ? 0 : decimal.Parse(row["CompanyLimit"]);
                _BeCompany.companyName = row["CompanyName"];
                _BeCompany.companyRUC = row["CompanyRUC"];
                _BeCompany.companySys = row["CompanySys"];
                _BeCompany.isEnabled = string.IsNullOrEmpty(row["IsEnabled"]) ? false : row["IsEnabled"].Equals("1") ? true : false;
                _BeCompany.companyType = row["companyType"];
                _BeCompany.districtId = row["districtId"];
                _BeCompany.quantityAuth = row["quantityAuth"];
                _lstCompany.Add(_BeCompany);
            }
            return _lstCompany;
        }

        public List<BE_CompanyType> GetCompanyType()
        {
            BE_CompanyType _BeCompanyType = null;
            List<BE_CompanyType> _lstCompanyType = new List<BE_CompanyType>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
          
            var rows = _database.QuerySP("sps_getCompanyType", parameters);
            
            foreach (var row in rows)
            {
                _BeCompanyType = new BE_CompanyType();
                _BeCompanyType.companyTypeId = row["companyTypeId"];
                _BeCompanyType.name = row["name"];
                _lstCompanyType.Add(_BeCompanyType);
            }
            return _lstCompanyType;
        }
    }
}
