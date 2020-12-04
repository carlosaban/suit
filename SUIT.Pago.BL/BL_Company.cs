using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT.BE;
using SUIT.Pago.BE;
using SUIT.Pago.BE.n;
using SUIT.Pago.BE.n.Filters;
using SUIT.Pago.DA;
using SUIT.Security.DA;

namespace SUIT.Pago.BL
{
    public class BL_Company
    {
        //private MySQLDatabase _database = new MySQLDatabase("pagosapp");
        public MySQLDatabase _database;
        public string connectionString;

        public BE_Company UpdateCompany(BE_Company _BeCompany)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Company(_database).UpdateCompany(_BeCompany);
        }

        public List<BE_Company> GetCompany()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Company(_database).GetCompany();
        }

        public BE_Company CreateCompany(BE_Company _BeCompany)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Company(_database).CreateCompany(_BeCompany);
        }

        public BE_Company DeleteCompany(BE_Company _BeCompany)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Company(_database).DeleteCompany(_BeCompany);
        }

        public List<BE_Company> GetProviders()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Company(_database).GetCompanyByTypeId(2);
        }

        public List<BE_Company> GetClients()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Company(_database).GetCompanyByTypeId(1);
        }

        public List<BE_Company> GetSystemClients(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Company(_database).GetCompanyByTypeId(3);
        }


        public List<BE_Company> GetCompanyGeneral(BECompanyFilter _bECompanyFilter)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Company(_database).GetCompanyGeneral(_bECompanyFilter);
        }

        public List<BE_CompanyType> GetCompanyType()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Company(_database).GetCompanyType();
        }
    }
}
