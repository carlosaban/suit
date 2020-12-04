using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT.BE;
using SUIT.Pago.BE;
using SUIT.Pago.BE.n.Filters;
using SUIT.Pago.DA;
using SUIT.Security.DA;

namespace SUIT.Pago.BL
{
    public class BL_WorkFlow
    {
        public MySQLDatabase _database;
        public string connectionString;

        public bool NextWorkFlowStep(ref string mensaje, int workFlowId, int IdInvoice, string userName, bool refuse,string comment)
        {
            try
            {
                _database = new MySQLDatabase(connectionString);
                var result = new DA_WorkFlow(_database).NextWorkFlowStep(ref mensaje, workFlowId, IdInvoice, userName, refuse);

                if (!string.IsNullOrEmpty(comment) && refuse)
                {
                    BEInvoiceFilter filter = new BEInvoiceFilter();
                    filter.invoiceIdList = IdInvoice.ToString();
                    filter.statusList = "";
                    filter.invoiceType = "";

                    BL_Invoice bL_Invoice = new BL_Invoice();
                    bL_Invoice.connectionString = connectionString;
                    var invoice = bL_Invoice.GetInvoiceGeneral(filter);
                    if (invoice.Count > 0)
                    {
                        invoice[0].userName = userName;
                        invoice[0].comments += comment;
                        bL_Invoice.updateInvoiceGeneral(invoice[0]);
                    }
                    else {
                        mensaje = "No existe una factura que concuerde con la informacion proporcionada";
                    }
                    
                }
                
               
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool NextWorkFlowStep(ref string mensaje, int workFlowId, int IdInvoice, string userName, bool refuse)
        {
           return NextWorkFlowStep(ref mensaje, workFlowId, IdInvoice, userName, refuse,"");
            
        }


        public bool ValidatedNextWorkFlowStep(int workFlowId, int IdInvoice, string userName)
        {
            try
            {
                _database = new MySQLDatabase(connectionString);
                var result = new DA_WorkFlow(_database).ValidatedNextWorkFlowStep (workFlowId, IdInvoice, userName);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
