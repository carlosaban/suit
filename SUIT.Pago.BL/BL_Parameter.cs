using SUIT.Pago.BE.n;
using SUIT.Pago.DA.n;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BL
{
    public class BL_Parameter
    {

        public MySQLDatabase _database;
        public string connectionString;

        
        public BE_Parameter CreateParameter(BE_Parameter bE_Parameter)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Parameter(_database).CreateParameter(bE_Parameter);

        }

        public List<BE_Parameter> GetParameter(int idParameter)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Parameter(_database).GetParameter(idParameter);

        }

        public List<BE_Parameter> GetParameter()
        {
            return GetParameter(0);
        }


        public BE_Parameter UpdateParameter(BE_Parameter bE_Parameter)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Parameter(_database).UpdateParameter(bE_Parameter);

        }


        public int DeleteParameter(int idParameter)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Parameter(_database).DeleteParameter(idParameter);

        }


        public BE_ParameterDetail CreateParameterDetail(BE_ParameterDetail bE_ParameterDetail)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Parameter(_database).CreateParameterDetail(bE_ParameterDetail);

        }

        public List<BE_ParameterDetail> GetParameterDetail()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Parameter(_database).GetParameterDetail(0,0);

        }

        public List<BE_ParameterDetail> GetParameterDetailByIdParameter(int idParameter)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Parameter(_database).GetParameterDetail(idParameter, 0);
        }

        public List<BE_ParameterDetail> GetParameterDetailById(int idParameterDetail)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Parameter(_database).GetParameterDetail(0, idParameterDetail);
        }

        public BE_ParameterDetail UpdateParameterDetail(BE_ParameterDetail bE_ParameterDetail)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Parameter(_database).UpdateParameterDetail(bE_ParameterDetail);

        }


        public int DeleteParameterDetail(int idParameterDetail)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Parameter(_database).DeleteParameterDetail(idParameterDetail);

        }

    }
}
