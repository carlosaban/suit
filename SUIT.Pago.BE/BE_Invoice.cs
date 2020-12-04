using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class BE_Invoice
    {
        public string invoiceId { get; set; }
        public decimal amountBalance { get; set; }
        public decimal amountDetraction { get; set; }
        public decimal amountPayment { get; set; }
        public decimal amountPaymentDetraction { get; set; }
        public decimal amountPaymentFromBank { get; set; }
        public decimal amountPaymentPen { get; set; }
        public decimal amountTotal { get; set; }
        public int bankAccountId { get; set; }
        public string bankAccountNumber { get; set; }
        public int bankId { get; set; }
        public string budgetFile { get; set; }
        public string companyCode { get; set; }
        public string currency { get; set; }
        public string currencyPayment { get; set; }
        public string customerBankAccountPen { get; set; }
        public string customerBankAccountUsd { get; set; }
        public string customerName { get; set; }
        public string customerRuc { get; set; }
        public DateTime customerDate { get; set; }
        public string customerId { get; set; }
        public DateTime dueDate { get; set; }
        public string exchangeRate { get; set; }
        public string invoiceFile { get; set; }
        public string ocrFile { get; set; }
        public string customerEmail { get; set; }
        public string documentType { get; set; }
        public DateTime documentDate { get; set; }
        public string documentId { get; set; }
        public string customerBankAccountDetraction { get; set; }
        public string nroComprobante { get; set; }
        public string nroSerie { get; set; }
        public string tipoServicio { get; set; }
        public string customerDocType { get; set; }
        public string accounting { get; set; }
        public string customerDateFormat { get; set; }
        public string dueDateFormat { get; set; }
        public string documentDateFormat { get; set; }
        public decimal amountDetraccionUS { get; set; }
        public string status { get; set; }
        public string invoiceType { get; set; }
        public int invoiceStatusId { get; set; }
        public string reference { get; set; }
        public string comments { get; set; }

    }
}
