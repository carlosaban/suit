using SUIT.Pago.BE;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.DA
{
    public class DA_CostCenter
    {

        public MySQLDatabase _database { get; set; }

        public DA_CostCenter(MySQLDatabase database)
        {
            _database = database;
        }


        public List<BE_CostCenter> getCostCenterGeneral(string costCenterId)
        {
            BE_CostCenter bE_CostCenter = null;
            List<BE_CostCenter> bE_CostCenters = new List<BE_CostCenter>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_costCenterId", costCenterId);

            var rows = _database.QuerySP("sp_getCostCenterGeneral", parameters);

            foreach (var row in rows)

            {
               
                bE_CostCenter = new BE_CostCenter();
                bE_CostCenter.costCenterId = row["costcenterId"];
                bE_CostCenter.description = row["description"];

                bE_CostCenters.Add(bE_CostCenter);
            }
            return bE_CostCenters;
        }
        
        public Boolean AddCostCenterToInvoice(string costCenterId, string invoiceId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_costCenterId", costCenterId);
            parameters.Add("_invoiceId", invoiceId);

           

            filasAfectadas = _database.ExecuteSP("sp_addCostCenterToInvoice", parameters);
            boResultado = (filasAfectadas > 0);
            return boResultado;
        }


        public Boolean AddDetractionToInvoice(decimal amountDetraction, string invoiceId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_amountDetraction", amountDetraction);
            parameters.Add("_invoiceId", invoiceId);



            filasAfectadas = _database.ExecuteSP("sp_addDetractionToInvoice", parameters);
            boResultado = (filasAfectadas > 0);
            return boResultado;
        }
    }
}
