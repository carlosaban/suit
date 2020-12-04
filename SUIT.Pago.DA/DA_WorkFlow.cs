using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.DA
{
    public class DA_WorkFlow
    {
        private MySQLDatabase _database;

        public DA_WorkFlow(MySQLDatabase database)
        {
            _database = database;
        }

        public bool NextWorkFlowStep(ref string mensaje, int WorkFlowId, int InvoiceId, string userName, bool refuse)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_WorkFlowId", WorkFlowId);
            parameters.Add("_InvoiceId", InvoiceId);
            parameters.Add("_userName", userName);
            parameters.Add("_refuse", refuse);


            //filasAfectadas = _database.ExecuteSP("spu_updateWorkFlowNextStep", parameters);
            var rows = _database.QuerySP("spu_updateWorkFlowNextStep", parameters);
            bool bOk = false;

            bOk = rows[0]["MESSAGE"].Equals( "");

            
            mensaje = rows[0]["MESSAGE"];
            
            
            
            return bOk;
        }

        public bool ValidatedNextWorkFlowStep( int WorkFlowId, int InvoiceId, string userName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_WorkFlowId", WorkFlowId);
            parameters.Add("_InvoiceId", InvoiceId);
            parameters.Add("_userName", userName);


            //filasAfectadas = _database.ExecuteSP("sp_validatedNextWorkFlowStep", parameters);
            var rows = _database.QuerySP("sp_validatedNextWorkFlowStep", parameters);
            bool bOk = false;

            bOk = rows[0]["bOK"].Equals("1")?true:false;

            return bOk;
        }
    }
}
