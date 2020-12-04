using SUIT.Pago.BE;
using SUIT.Pago.DA;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BL
{
    public class BL_CostCenter
    {

        public MySQLDatabase _database;
        public string connectionString;

        public List<BE_CostCenter> GetCostCenterGeneral(string costCenterId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_CostCenter(_database).getCostCenterGeneral(costCenterId);
        }


        public Boolean AddCostCenterToInvoice(ref string mensaje, string costCenterId, string invoiceId, string userName)
        {

            BL_WorkFlow _blWorkFlow = new BL_WorkFlow();


            _blWorkFlow.connectionString = connectionString;

            bool bOk = _blWorkFlow.NextWorkFlowStep(ref mensaje, 1, int.Parse(invoiceId), userName, false);

            if (bOk)
            {
                _database = new MySQLDatabase(connectionString);
                return new DA_CostCenter(_database).AddCostCenterToInvoice(costCenterId, invoiceId);
            }
            else
            {
                return false;
            }

            
        }

        public Boolean AddDetractionToInvoice(ref string mensaje, decimal amountDetraction, string invoiceId, string userName)
        {

            BL_WorkFlow _blWorkFlow = new BL_WorkFlow();


            _blWorkFlow.connectionString = connectionString;

            bool bOk = _blWorkFlow.NextWorkFlowStep(ref mensaje, 1, int.Parse(invoiceId), userName, false);

            if (bOk)
            {
                _database = new MySQLDatabase(connectionString);
                return new DA_CostCenter(_database).AddDetractionToInvoice(amountDetraction, invoiceId);
            }
            else
            {
                return false;
            }


        }
    }
}
