using SUIT.Security.BE;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.DA.n
{
    public class DA_Mail
    {
        public MySQLDatabase _database { get; set; }

        public DA_Mail(MySQLDatabase database)
        {
            _database = database;
        }

        public BE_Mail GetMail(int mailId)
        {
            BE_Mail bE_Mail = null;
            List<BE_Mail> bE_Mails = new List<BE_Mail>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_mailId", mailId);

            var rows = _database.QuerySP("sp_getMail", parameters);

            foreach (var row in rows)
            {
                bE_Mail = new BE_Mail();
                bE_Mail.idMail = string.IsNullOrEmpty(row["IdMail"]) ? 0 : int.Parse(row["IdMail"]); ;
                bE_Mail.subjectMail = row["SubjectMail"];
                bE_Mail.bodyMail = row["BodyMail"];
                bE_Mail.descriptionMail = row["DescriptionMail"];
                bE_Mail.toMail = row["ToMail"];

            }
            return bE_Mail;
        }

        public bool OutBox(BE_Mail bE_Mail)
        {
            
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_mailId", bE_Mail.idMail);
            parameters.Add("_bodyMail", bE_Mail.bodyMail);
            parameters.Add("_descriptionMail", bE_Mail.descriptionMail);
            parameters.Add("_subjectMail", bE_Mail.subjectMail);
            parameters.Add("_toMail", bE_Mail.toMail);

            filasAfectadas = _database.ExecuteSP("sp_addCostCenterToInvoice", parameters);
            boResultado = (filasAfectadas > 0);
            return boResultado;
        }
    }
}
