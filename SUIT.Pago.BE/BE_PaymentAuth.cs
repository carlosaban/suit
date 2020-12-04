using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SUIT.Pago.BE
{
    public class BE_PaymentAuth
    {
        public int paymentAuthId { get; set; }
        public decimal amountDetractionPaid { get; set; }
        public decimal amountPaid { get; set; }
        public decimal amountPaidPen { get; set; }
        public decimal amountPaidUsd { get; set; }
        public DateTime authDateFirstUser { get; set; }
        public string authDateFirstUserFormat { get; set; }
        public DateTime authDateSecondUser { get; set; }
        public string authDateSecondUserFormat { get; set; }
        public DateTime authDateThirdUser { get; set; }
        public string authDateThirdUserFormat { get; set; }
        public int bankAccountId { get; set; }
        public string companyCode { get; set; }
        public decimal exchangeRate { get; set; }
        public string firstUserId { get; set; }
        public DateTime payDate { get; set; }
        public string payDateFormat { get; set; }
        public string secondUserId { get; set; }
        public string status { get; set; }
        public string thirdUserId { get; set; }
        public Int64 loteDetraccion { get; set; }
        public DateTime accountPayDate { get; set; }
        public string accountPayDateFormat { get; set; }
        public int paymentId { get; set; }
        public string userName { get; set; }
        public string memoryRuc { get; set; }

    }
}
