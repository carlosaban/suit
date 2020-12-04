using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SUIT.Pago.BE
{
    public class BE_BankAccount
    {
        public int bankAccountId { get; set; }
        public int bankId { get; set; }
        public string accountNumber { get; set; }
        public string currency { get; set; }
        public Boolean status { get; set; }
        public decimal balance { get; set; }
        public string accounting { get; set; }
        public string cash { get; set; }
        public string companyCode { get; set; }
        public string AccountNumberCCI { get; set; }
        public string AccountType { get; set; }


    }
}
