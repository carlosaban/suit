using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SUIT.Pago.BE
{
    public class BE_Payment
    {
        public Int64 paymentId { get; set; }
        public decimal amountBalance { get; set; }
        public decimal amountDetraction { get; set; }
        public decimal amountPayment { get; set; }
        public decimal amountPaymentDetraction { get; set; }
        public decimal amountPaymentFromBank { get; set; }
        public decimal amountPaymentPen { get; set; }
        public decimal amountTotal { get; set; }
        public Int64 bankAccountId { get; set; }
        public string bankAccountNumber { get; set; }
        public Int64 bankId { get; set; }
        public string companyCode { get; set; }
        public string currency { get; set; }
        public string currencyPayment { get; set; }
        public string customerBankAccountPen { get; set; }
        public string customerBankAccountUsd { get; set; }
        public string customerName { get; set; }
        public string customerRuc { get; set; }
        public DateTime customerDate { get; set; }
        public string customerDateFormat { get; set; }
        public string customerId { get; set; }
        public DateTime dueDate { get; set; }
        public string dueDateFormat { get; set; }
        public string exchangeRate { get; set; }
        public string id { get; set; }
        public Int64 paymentAuthId { get; set; }
        public string customerEmail { get; set; }
        public string documentType { get; set; }
        public DateTime documentDate { get; set; }
        public string documentDateFormat { get; set; }
        public string documentId { get; set; }
        public string customerBankAccountDetraction { get; set; }
        public string nroComprobante { get; set; }
        public string nroSerie { get; set; }
        public string tipoServicio { get; set; }
        public string customerDocType { get; set; }
        public string accounting { get; set; }
        public decimal amountDetractionUS { get; set; }
        public DateTime payDate { get; set; }
        public string payDateFormat { get; set; }
        public string userName { get; set; }
        public string reference { get; set; }
        public int paymentStatusId { get; set; }
        public int paymentMethodId { get; set; }
        public string createdBy { get; set; }

        public BE_PaymentDetail[] PaymentDetail { get; set; }

    }
}
