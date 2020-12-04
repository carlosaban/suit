using SUIT.Pago.BE.n;
using SUIT.Pago.DA.n;
using SUIT.Security.BE;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BL
{
    public class BL_Mail
    {
        public MySQLDatabase _database;
        public string connectionString;



        public string SelectMail(MailContent mailContent)
        {
            if (mailContent.mailId == 5)
                return PruebaMail(mailContent);
            else
                return "Código no encontrado";
        }


        public string PruebaMail(MailContent mailContent)
        {
            _database = new MySQLDatabase(connectionString);
            var mail =  new DA_Mail(_database).GetMail(mailContent.mailId);

            var newMailBody = mail.bodyMail.Replace("@prueba",mailContent.prueba);
            return newMailBody;
        }


        public bool OutBox(BE_Mail bE_Mail)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Mail(_database).OutBox(bE_Mail);
            
        }
    }
}
