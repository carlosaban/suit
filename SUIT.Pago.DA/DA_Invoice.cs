using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT.DA;
using SUIT.BE;
using SUIT.Pago.BE;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using SUIT.Pago.BE.n.Filters;
using SUIT.Security.DA;

namespace SUIT.Pago.DA
{
    public class DA_Invoice
    {
        public MySQLDatabase _database { get; set; }

        public DA_Invoice(MySQLDatabase database)
        {
            _database = database;
        }

        public List<VE_Invoice> getUnpaidCompanyInvoicesBalance(string companyCode)
        {
            VE_Invoice _veInvoice = null;
            List<VE_Invoice> _lstInvoice = new List<VE_Invoice>();

            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_companyCode", companyCode } };

            var rows = _database.QuerySP("sps_obtenerDeudaPorCompania", parameters);
            foreach (var row in rows)
            {
                _veInvoice = new VE_Invoice();
                _veInvoice.amountBalance = decimal.Parse(row["AmountBalance"]);
                _veInvoice.currency = row["Currency"];
                _veInvoice.cantidad = row["Cantidad"];
                _lstInvoice.Add(_veInvoice);
            }

            return _lstInvoice;
        }

        public List<BE_Invoice> getUnpaidCompanyInvoices(string companyCode)
        {
            BE_Invoice beInvoice = null;
            List<BE_Invoice> _lstInvoice = new List<BE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_companyCode", companyCode } };


            var rows = _database.QuerySP("sps_obtenerFacturasPorCompania", parameters);
            string invoiceUrl = System.Configuration.ConfigurationManager.AppSettings["InvoiceUrl"];
            foreach (var row in rows)
            {
                //user.lockoutEnd = string.IsNullOrEmpty(row["LockoutEndDateUtc"]) ? DateTime.Now : DateTime.Parse(row["LockoutEndDateUtc"]);
                //user.accessFailedCount = string.IsNullOrEmpty(row["AccessFailedCount"]) ? 0 : int.Parse(row["AccessFailedCount"]);
                beInvoice = new VE_Invoice();
                beInvoice.invoiceId = row["Id"];
                beInvoice.amountBalance = string.IsNullOrEmpty(row["AmountBalance"]) ? 0 : decimal.Parse(row["AmountBalance"]);
                beInvoice.amountDetraction = string.IsNullOrEmpty(row["AmountDetraction"]) ? 0 : decimal.Parse(row["AmountDetraction"]);
                beInvoice.amountPayment = string.IsNullOrEmpty(row["AmountPayment"]) ? 0 : decimal.Parse(row["AmountPayment"]);
                beInvoice.amountPaymentDetraction = string.IsNullOrEmpty(row["AmountPaymentDetraction"]) ? 0 : decimal.Parse(row["AmountPaymentDetraction"]);
                beInvoice.amountPaymentFromBank = string.IsNullOrEmpty(row["AmountPaymentFromBank"]) ? 0 : decimal.Parse(row["AmountPaymentFromBank"]);
                beInvoice.amountPaymentPen = string.IsNullOrEmpty(row["AmountPaymentPen"]) ? 0 : decimal.Parse(row["AmountPaymentPen"]);
                beInvoice.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                beInvoice.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                beInvoice.bankAccountNumber = row["BankAccountNumber"];
                beInvoice.bankId = string.IsNullOrEmpty(row["BankId"]) ? 0 : int.Parse(row["BankId"]);
                beInvoice.budgetFile = invoiceUrl + row["BudgetFile"];
                beInvoice.companyCode = row["CompanyCode"];
                beInvoice.currency = row["Currency"];
                beInvoice.currencyPayment = row["CurrencyPayment"];
                beInvoice.customerBankAccountPen = row["CustomerBankAccountPen"];
                beInvoice.customerBankAccountUsd = row["CustomerBankAccountUsd"];
                beInvoice.customerName = row["CustomerName"];
                beInvoice.customerRuc = row["CustomerRuc"];
                beInvoice.documentDate = string.IsNullOrEmpty(row["DocumentDate"]) ? DateTime.Now : DateTime.Parse(row["DocumentDate"]);
                beInvoice.documentDateFormat = beInvoice.documentDate.ToShortDateString();
                beInvoice.documentId = row["DocumentId"];
                beInvoice.dueDate = string.IsNullOrEmpty(row["DueDate"]) ? DateTime.Now : DateTime.Parse(row["DueDate"]);
                beInvoice.dueDateFormat = beInvoice.dueDate.ToShortDateString();
                beInvoice.exchangeRate = row["ExchangeRate"];
                beInvoice.invoiceFile = invoiceUrl + row["InvoiceFile"];
                beInvoice.ocrFile = invoiceUrl + row["OCRFile"];
                beInvoice.customerEmail = row["CustomerEmail"];
                beInvoice.documentType = row["DocumentType"];
                beInvoice.customerBankAccountDetraction = row["CustomerBankAccountDetraction"];
                beInvoice.nroComprobante = row["NroComprobante"];
                beInvoice.nroSerie = row["NroSerie"];
                beInvoice.tipoServicio = row["TipoServicio"];
                beInvoice.customerDocType = row["CustomerDocType"];
                beInvoice.accounting = row["Accounting"];
                beInvoice.status = row["Status"];
                _lstInvoice.Add(beInvoice);
            }

            return _lstInvoice;
        }

        public List<VE_Invoice> getUnpaidCompanyInvoicesResume(string companyCode)
        {
            VE_Invoice _veInvoice = null;
            List<VE_Invoice> _lstInvoices = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_companyCode", companyCode } };

            var rows = _database.QuerySP("sps_obtenerFacturasResumen", parameters);
            foreach (var row in rows)
            {
                _veInvoice = new VE_Invoice();
                _veInvoice.currency = row["Currency"];
                _veInvoice.amountBalance = string.IsNullOrEmpty(row["AmountBalance"]) ? 0 : decimal.Parse(row["AmountBalance"]);
                //_veInvoice.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _veInvoice.cantidad = row["Cantidad"];
                _lstInvoices.Add(_veInvoice);
            }

            return _lstInvoices;
        }

        public List<VE_Invoice> getUnpaidCompanyInvoicesResumeDetail(string companyCode)
        {
            VE_Invoice _veInvoice = null;
            List<VE_Invoice> _lstInvoices = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_companyCode", companyCode } };

            var rows = _database.QuerySP("sp_getInvoiceResumeDetail", parameters);
            foreach (var row in rows)
            {
                _veInvoice = new VE_Invoice();
                _veInvoice.customerRuc = row["CompanyRuc"];//modificar para proximo entregable
                _veInvoice.customerName = row["CompanyName"];
                _veInvoice.currency = row["Currency"];
                _veInvoice.amountBalance = string.IsNullOrEmpty(row["AmountBalance"]) ? 0 : decimal.Parse(row["AmountBalance"]);
                _veInvoice.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _veInvoice.amountDetraction = string.IsNullOrEmpty(row["AmountDetraction"]) ? 0 : decimal.Parse(row["AmountDetraction"]);
                _veInvoice.cantidad = row["Cantidad"];
                _lstInvoices.Add(_veInvoice);
            }

            return _lstInvoices;
        }

        public BE_Invoice payInvovice(BE_Invoice _beInvoice)
        {
            //BE_Invoice _beInvoice = new BE_Invoice();
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", _beInvoice.companyCode);
            parameters.Add("_currency", _beInvoice.currency);
            parameters.Add("_customerRuc", _beInvoice.customerRuc);
            parameters.Add("_bankAccountId", _beInvoice.bankAccountId);
            parameters.Add("_bankAccountNumber", _beInvoice.bankAccountNumber);
            parameters.Add("_bankId", _beInvoice.bankId);
            parameters.Add("_invoiceId", _beInvoice.invoiceId);

            filasAfectadas = _database.ExecuteSP("spi_makePayment", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _beInvoice;
            }
            return null;

        }

        public BE_Invoice payInvoviceDetail(VE_Invoice _beInvoice)
        {
            //BE_Invoice _beInvoice = new BE_Invoice();
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", _beInvoice.companyCode);
            parameters.Add("_currency", _beInvoice.currency);
            parameters.Add("_customerRuc", _beInvoice.customerRuc);
            parameters.Add("_bankAccountId", _beInvoice.bankAccountId);
            parameters.Add("_bankAccountNumber", _beInvoice.bankAccountNumber);
            parameters.Add("_bankId", _beInvoice.bankId);
            parameters.Add("_invoiceId", _beInvoice.invoiceId);

            filasAfectadas = _database.ExecuteSP("spi_makePayment", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _beInvoice;
            }
            return null;

        }

        public BE_Invoice makePaymentsDetails(VE_Invoice _veInvoice)
        {
            //string companyCode, string currency, string customerRuc, int bankAccountId, string bankAccountNumber, int bankId, string invoiceId
            BE_Invoice _beInvoice = null;
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", _veInvoice.companyCode);
            parameters.Add("_currency", _veInvoice.currency);
            parameters.Add("_customerRuc", _veInvoice.customerRuc);
            parameters.Add("_bankAccountId", _veInvoice.bankAccountId);
            parameters.Add("_bankAccountNumber", _veInvoice.bankAccountNumber);
            parameters.Add("_bankId", _veInvoice.bankId);
            parameters.Add("_invoiceId", _veInvoice.invoiceId);


            filasAfectadas = _database.ExecuteSP("spi_makePaymentByInvoiceId", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                _beInvoice = new BE_Invoice();
                _beInvoice.invoiceId = _veInvoice.invoiceId;
                _beInvoice.customerRuc = _veInvoice.customerRuc;
                _beInvoice.currency = _veInvoice.currency;
                _beInvoice.bankAccountId = _veInvoice.bankAccountId;
                _beInvoice.bankAccountNumber = _veInvoice.bankAccountNumber;
                return _beInvoice;

            }
            return null;







        }

        public List<BE_Invoice> getInvoiceToPayBySum(VE_Invoice _veInvoice)
        {
            BE_Invoice _beInvoice = null;
            List<BE_Invoice> _lstInvoices = new List<BE_Invoice>();
            string strError_Mensaje = string.Empty;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", _veInvoice.companyCode);
            parameters.Add("_currency", _veInvoice.currency);
            parameters.Add("_customerRuc", _veInvoice.customerRuc);
            parameters.Add("_bankAccountId", _veInvoice.bankAccountId);
            parameters.Add("_bankAccountNumber", _veInvoice.bankAccountNumber);
            parameters.Add("_bankId", _veInvoice.bankId);



            var rows = _database.QuerySP("sps_getInvoiceToPayBySum", parameters);
            foreach (var row in rows)
            {
                _beInvoice = new BE_Invoice();
                _beInvoice.customerRuc = row["CustomerRuc"];
                _beInvoice.customerName = row["CustomerName"];
                _beInvoice.currency = row["Currency"];
                _beInvoice.amountBalance = string.IsNullOrEmpty(row["AmountBalance"]) ? 0 : decimal.Parse(row["AmountBalance"]);
                _beInvoice.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                _beInvoice.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _beInvoice.amountDetraction = string.IsNullOrEmpty(row["AmountDetraction"]) ? 0 : decimal.Parse(row["AmountDetraction"]);
                _beInvoice.invoiceId = row["Id"];

                _lstInvoices.Add(_beInvoice);
            }


            return _lstInvoices;
        }

        public BE_Invoice getInvoiceById(string _invoiceId)
        {
            BE_Invoice _beInvoice = null;
            List<BE_Invoice> _lstInvoices = new List<BE_Invoice>();
            string strError_Mensaje = string.Empty;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_invoiceId", _invoiceId);

            var rows = _database.QuerySP("sps_getInvoiceById", parameters);
            foreach (var row in rows)
            {
                _beInvoice = new BE_Invoice();
                _beInvoice.companyCode = row["CompanyCode"];
                _beInvoice.customerRuc = row["CustomerRuc"];
                _beInvoice.customerName = row["CustomerName"];
                _beInvoice.currency = row["Currency"];
                _beInvoice.amountBalance = string.IsNullOrEmpty(row["AmountBalance"]) ? 0 : decimal.Parse(row["AmountBalance"]);
                _beInvoice.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _beInvoice.amountDetraction = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _beInvoice.invoiceId = row["Id"];

                //_lstInvoices.Add(_beInvoice);
            }


            return _beInvoice;
        }

        public List<VE_Invoice> getInvoicesSummaryDetail(string companyCode, string providerRuc)
        {
            VE_Invoice _veInvoice = new VE_Invoice();
            List<VE_Invoice> _lstInvoices = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", companyCode);
            parameters.Add("_providerRuc", providerRuc);

            var rows = _database.QuerySP("sp_getInvoicesSummaryDetail", parameters);
            foreach (var row in rows)
            {
                _veInvoice = new VE_Invoice();
                _veInvoice.customerRuc = row["CustomerRuc"];
                _veInvoice.customerName = row["CustomerName"];
                _veInvoice.companyName = row["companyName"];
                _veInvoice.companyRuc = row["companyRuc"];
                _veInvoice.documentId = row["DocumentId"];
                _veInvoice.currency = row["Currency"];
                _veInvoice.amountBalance = string.IsNullOrEmpty(row["AmountBalance"]) ? 0 : decimal.Parse(row["AmountBalance"]);
                _veInvoice.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _veInvoice.amountDetraction = string.IsNullOrEmpty(row["AmountDetraction"]) ? 0 : decimal.Parse(row["AmountDetraction"]);
                _veInvoice.invoiceId = row["InvoiceId"];
                _lstInvoices.Add(_veInvoice);
            }

            return _lstInvoices;
        }

        public List<VE_Invoice> getInvoice()
        {
            VE_Invoice _VeInvoice = null;
            List<VE_Invoice> _lstInvoice = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            

            var rows = _database.QuerySP("sps_getInvoice", parameters);
            foreach (var row in rows)
            {
                _VeInvoice = new VE_Invoice();
                _VeInvoice.invoiceId = row["Id"];
                _VeInvoice.amountBalance = string.IsNullOrEmpty(row["AmountBalance"]) ? 0 : decimal.Parse(row["AmountBalance"]);
                _VeInvoice.amountDetraction = string.IsNullOrEmpty(row["AmountDetraction"]) ? 0 : decimal.Parse(row["AmountDetraction"]);
                _VeInvoice.amountPayment = string.IsNullOrEmpty(row["AmountPayment"]) ? 0 : decimal.Parse(row["AmountPayment"]);
                _VeInvoice.amountPaymentDetraction = string.IsNullOrEmpty(row["AmountPaymentDetraction"]) ? 0 : decimal.Parse(row["AmountPaymentDetraction"]);
                _VeInvoice.amountPaymentFromBank = string.IsNullOrEmpty(row["AmountPaymentFromBank"]) ? 0 : decimal.Parse(row["AmountPaymentFromBank"]);
                _VeInvoice.amountPaymentPen = string.IsNullOrEmpty(row["AmountPaymentPen"]) ? 0 : decimal.Parse(row["AmountPaymentPen"]);
                _VeInvoice.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _VeInvoice.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                _VeInvoice.bankAccountNumber = row["BankAccountNumber"];
                _VeInvoice.bankId = string.IsNullOrEmpty(row["BankId"]) ? 0 : int.Parse(row["BankId"]);
                _VeInvoice.budgetFile = row["BudgetFile"];
                _VeInvoice.companyCode = row["CompanyCode"];
                _VeInvoice.currency = row["Currency"];
                _VeInvoice.currencyPayment = row["CurrencyPayment"];
                _VeInvoice.customerBankAccountPen = row["CustomerBankAccountPen"];
                _VeInvoice.customerBankAccountUsd = row["CustomerBankAccountUsd"];
                _VeInvoice.customerName = row["CustomerName"];
                _VeInvoice.customerRuc = row["CustomerRuc"];
                _VeInvoice.documentDate = string.IsNullOrEmpty(row["DocumentDate"]) ? DateTime.Now : DateTime.Parse(row["DocumentDate"]);
                _VeInvoice.documentDateFormat = _VeInvoice.documentDate.ToShortDateString();
                _VeInvoice.documentId = row["DocumentId"];
                _VeInvoice.dueDate = string.IsNullOrEmpty(row["DueDate"]) ? DateTime.Now : DateTime.Parse(row["DueDate"]);
                _VeInvoice.dueDateFormat = _VeInvoice.dueDate.ToShortDateString();
                _VeInvoice.exchangeRate = row["ExchangeRate"];
                _VeInvoice.invoiceFile = row["InvoiceFile"];
                _VeInvoice.ocrFile = row["OCRFile"];
                _VeInvoice.customerEmail = row["CustomerEmail"];
                _VeInvoice.documentType = row["DocumentType"];
                _VeInvoice.customerBankAccountDetraction = row["CustomerBankAccountDetraction"];
                _VeInvoice.nroComprobante = row["NroComprobante"];
                _VeInvoice.nroSerie = row["NroSerie"];
                _VeInvoice.tipoServicio = row["TipoServicio"];
                _VeInvoice.customerDocType = row["CustomerDocType"];
                _VeInvoice.accounting = row["Accounting"];
                _VeInvoice.amountDetraccionUS = string.IsNullOrEmpty(row["AmountDetractionUS"]) ? 0 : decimal.Parse(row["AmountDetractionUS"]);
                _VeInvoice.status = row["Status"];
                _lstInvoice.Add(_VeInvoice);
            }


            return _lstInvoice;
        }

        public VE_Invoice updateInvoice(VE_Invoice _VeInvoice)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id", _VeInvoice.invoiceId);
            parameters.Add("_amountBalance", _VeInvoice.amountBalance);
            parameters.Add("_amountDetraction", _VeInvoice.amountDetraction);
            parameters.Add("_amountPayment", _VeInvoice.amountPayment);
            parameters.Add("_amountPaymentDetraction", _VeInvoice.amountPaymentDetraction);
            parameters.Add("_amountPaymentFromBank", _VeInvoice.amountPaymentFromBank);
            parameters.Add("_amountPaymentPen", _VeInvoice.amountPaymentPen);
            parameters.Add("_amountTotal", _VeInvoice.amountTotal);
            parameters.Add("_bankAccountId", _VeInvoice.bankAccountId);
            parameters.Add("_bankAccountNumber", _VeInvoice.bankAccountNumber);
            parameters.Add("_bankId", _VeInvoice.bankId);
            parameters.Add("_budgetFile", _VeInvoice.budgetFile);
            parameters.Add("_companyCode", _VeInvoice.companyCode);
            parameters.Add("_currency", _VeInvoice.currency);
            parameters.Add("_currencyPayment", _VeInvoice.currencyPayment);
            parameters.Add("_customerBankAccountPen", _VeInvoice.customerBankAccountPen);
            parameters.Add("_customerBankAccountUsd", _VeInvoice.customerBankAccountUsd);
            parameters.Add("_customerName", _VeInvoice.customerName);
            parameters.Add("_customerRuc", _VeInvoice.customerRuc);
            parameters.Add("_documentDate", _VeInvoice.documentDate);
            parameters.Add("_documentId", _VeInvoice.documentId);
            parameters.Add("_dueDate", _VeInvoice.dueDate);
            parameters.Add("_exchangeRate", _VeInvoice.exchangeRate);
            parameters.Add("_invoiceFile", _VeInvoice.invoiceFile);
            parameters.Add("_oCRFile", _VeInvoice.ocrFile);
            parameters.Add("_customerEmail", _VeInvoice.customerEmail);
            parameters.Add("_documentType", _VeInvoice.documentType);
            parameters.Add("_customerBankAccountDetraction", _VeInvoice.customerBankAccountDetraction);
            parameters.Add("_nroComprobante", _VeInvoice.nroComprobante);
            parameters.Add("_nroSerie", _VeInvoice.nroSerie);
            parameters.Add("_tipoServicio", _VeInvoice.tipoServicio);
            parameters.Add("_customerDocType", _VeInvoice.customerDocType);
            parameters.Add("_accounting", _VeInvoice.accounting);
            parameters.Add("_amountDetractionUS", _VeInvoice.amountDetraccionUS);
            parameters.Add("_status", _VeInvoice.status);
            parameters.Add("_userAudit", _VeInvoice.userAudit);
            



            filasAfectadas = _database.ExecuteSP("spu_updateInvoice", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                _VeInvoice.documentDateFormat = _VeInvoice.documentDate.ToShortDateString();
                _VeInvoice.dueDateFormat = _VeInvoice.dueDate.ToShortDateString();
                _VeInvoice.customerDateFormat = _VeInvoice.customerDate.ToShortDateString();
                return _VeInvoice;

            }
            return null;
        }

        public VE_Invoice createInvoice(VE_Invoice _VeInvoice)
        {
            string invoiceId = string.Empty;
            object id = null;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_amountTotal", _VeInvoice.amountTotal);
            parameters.Add("_bankAccountId", _VeInvoice.bankAccountId == 0 ? DBNull.Value : (object)_VeInvoice.bankAccountId);
            parameters.Add("_bankAccountNumber", _VeInvoice.bankAccountNumber );
            parameters.Add("_companyCode", _VeInvoice.companyCode);
            parameters.Add("_currency", _VeInvoice.currency);
            parameters.Add("_customerName", _VeInvoice.customerName);
            parameters.Add("_customerRuc", _VeInvoice.customerRuc);
            parameters.Add("_documentDate", _VeInvoice.documentDate);
            parameters.Add("_documentId", _VeInvoice.documentId);
            parameters.Add("_dueDate", _VeInvoice.dueDate);
            parameters.Add("_exchangeRate", _VeInvoice.exchangeRate);
            parameters.Add("_customerEmail", _VeInvoice.customerEmail);
            parameters.Add("_documentType", _VeInvoice.documentType);
            parameters.Add("_nroComprobante", _VeInvoice.nroComprobante);
            parameters.Add("_nroSerie", _VeInvoice.nroSerie);
            parameters.Add("_tipoServicio", _VeInvoice.tipoServicio);
            parameters.Add("_customerDocType", _VeInvoice.customerDocType);
            parameters.Add("_invoiceStatusId", _VeInvoice.invoiceStatusId);
            parameters.Add("_invoiceType", _VeInvoice.invoiceType);
            parameters.Add("_createdBy", _VeInvoice.userName);
            parameters.Add("_reference", _VeInvoice.reference);
            parameters.Add("_comments", _VeInvoice.comments);

            id = _database.ExecuteSPGetId("spi_createInvoice", parameters);
            invoiceId = id.ToString(); // int.Parse(id.ToString());

            boResultado = (int.Parse(invoiceId) > 0);
            if (boResultado)
            {
                _VeInvoice.invoiceId = invoiceId;
                _VeInvoice.documentDateFormat = _VeInvoice.documentDate.ToShortDateString();
                _VeInvoice.dueDateFormat = _VeInvoice.dueDate.ToShortDateString();
                _VeInvoice.customerDateFormat = _VeInvoice.customerDate.ToShortDateString();
                return _VeInvoice;

            }

            return null;
        }

        public VE_InvoiceDetail createInvoiceDetail(VE_InvoiceDetail _veInvoiceDetail)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_invoiceId", _veInvoiceDetail.invoiceId);
            parameters.Add("_invoiceItemId", _veInvoiceDetail.invoiceItemId);
            parameters.Add("_quantity", _veInvoiceDetail.quantity);
            parameters.Add("_unitPrice", _veInvoiceDetail.unitprice);
            parameters.Add("_price", _veInvoiceDetail.price);
            parameters.Add("_createdBy", _veInvoiceDetail.createdBy);
            parameters.Add("_igvAmount", _veInvoiceDetail.igvAmount);
            


            filasAfectadas = _database.ExecuteSP("spi_insertInvoiceDetail", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _veInvoiceDetail;

            }
            return null;
        }

        public VE_Invoice deleteInvoice(VE_Invoice _VeInvoice)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id", _VeInvoice.invoiceId);
            filasAfectadas = _database.ExecuteSP("spd_deleteInvoice", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _VeInvoice;

            }
            return null;
        }

        public VE_Invoice updateInvoiceStatus(VE_Invoice _VeInvoice)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_invoiceId", _VeInvoice.invoiceId);
            parameters.Add("_invoiceStatusId", _VeInvoice.invoiceStatusId);
            parameters.Add("_createdBy", _VeInvoice.userName);
            
            filasAfectadas = _database.ExecuteSP("spu_updateInvoiceStatus", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _VeInvoice;
            }   
            return null;
        }
        //cag 20190113

        public List<VE_Invoice> GetInvoiceSummary(string companyCode, string invoiceType)
        {
            return this.GetInvoiceSummary(companyCode, invoiceType, string.Empty,string.Empty);
        }


        public List<VE_Invoice> GetInvoiceSummary(string companyCode, string invoiceType , string _invoiceStatusIdList , string _companyCodeTarget)
        {
            VE_Invoice _veInvoice = null;
            List<VE_Invoice> _lstInvoices = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            
            parameters.Add("_companyCodeSource", (string.IsNullOrWhiteSpace(companyCode) ? DBNull.Value : (object)companyCode));

            parameters.Add("_invoiceType", (string.IsNullOrWhiteSpace(invoiceType) ? DBNull.Value : (object)invoiceType));

            parameters.Add("_invoiceStatusIdList", (string.IsNullOrWhiteSpace(_invoiceStatusIdList)?DBNull.Value :(object) _invoiceStatusIdList));
            parameters.Add("_companyCodeTarget", (string.IsNullOrWhiteSpace(_companyCodeTarget) ? DBNull.Value : (object)_companyCodeTarget));

            
            var rows = _database.QuerySP("sps_getInvoiceSummary", parameters);
            foreach (var row in rows)
            {
                _veInvoice = new VE_Invoice();
                _veInvoice.status = row["status"];
                _veInvoice.invoiceStatusId = string.IsNullOrEmpty(row["invoiceStatusId"]) ? 0 : int.Parse(row["invoiceStatusId"]);
                _veInvoice.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _lstInvoices.Add(_veInvoice);
            }

            return _lstInvoices;
        }

        public List<VE_Invoice> GetInvoiceByCompanyCode(string companyCode)
        {
            VE_Invoice _veInvoice = null;
            List<VE_Invoice> _lstInvoices = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_companyCode", companyCode } };

            var rows = _database.QuerySP("sps_getInvoiceByCompanyCode", parameters);
            foreach (var row in rows)
            {
                _veInvoice = new VE_Invoice();
                _veInvoice.invoiceId = row["InvoiceId"];
                _veInvoice.amountBalance = string.IsNullOrEmpty(row["AmountBalance"]) ? 0 : decimal.Parse(row["AmountBalance"]);
                _veInvoice.amountDetraction = string.IsNullOrEmpty(row["AmountDetraction"]) ? 0 : decimal.Parse(row["AmountDetraction"]);
                _veInvoice.amountPayment = string.IsNullOrEmpty(row["AmountPayment"]) ? 0 : decimal.Parse(row["AmountPayment"]);
                _veInvoice.amountPaymentDetraction = string.IsNullOrEmpty(row["AmountPaymentDetraction"]) ? 0 : decimal.Parse(row["AmountPaymentDetraction"]);
                _veInvoice.amountPaymentFromBank = string.IsNullOrEmpty(row["AmountPaymentFromBank"]) ? 0 : decimal.Parse(row["AmountPaymentFromBank"]);
                _veInvoice.amountPaymentPen = string.IsNullOrEmpty(row["AmountPaymentPen"]) ? 0 : decimal.Parse(row["AmountPaymentPen"]);
                _veInvoice.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _veInvoice.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                _veInvoice.bankAccountNumber = row["BankAccountNumber"];
                _veInvoice.bankId = string.IsNullOrEmpty(row["BankId"]) ? 0 : int.Parse(row["BankId"]);
                _veInvoice.budgetFile = row["BudgetFile"];
                _veInvoice.companyCode = row["CompanyCode"];
                _veInvoice.currency = row["Currency"];
                _veInvoice.currencyPayment = row["CurrencyPayment"];
                _veInvoice.customerBankAccountPen = row["CustomerBankAccountPen"];
                _veInvoice.customerBankAccountUsd = row["CustomerBankAccountUsd"];
                _veInvoice.customerName = row["CustomerName"];
                _veInvoice.customerRuc = row["CustomerRuc"];
                _veInvoice.documentDate = string.IsNullOrEmpty(row["DocumentDate"]) ? DateTime.MinValue : DateTime.Parse(row["DocumentDate"]);
                _veInvoice.documentDateFormat = _veInvoice.documentDate.ToShortDateString();
                _veInvoice.customerDate = string.IsNullOrEmpty(row["DocumentDate"]) ? DateTime.MinValue : DateTime.Parse(row["DocumentDate"]);
                _veInvoice.customerDateFormat = _veInvoice.customerDate.ToShortDateString();
                _veInvoice.documentId = row["DocumentId"];
                _veInvoice.dueDate = string.IsNullOrEmpty(row["DueDate"]) ? DateTime.MinValue : DateTime.Parse(row["DueDate"]);
                _veInvoice.dueDateFormat = _veInvoice.dueDate.ToShortDateString();
                _veInvoice.exchangeRate = row["ExchangeRate"];
                _veInvoice.invoiceFile = row["InvoiceFile"];
                _veInvoice.ocrFile = row["OCRFile"];
                _veInvoice.customerEmail = row["CustomerEmail"];
                _veInvoice.documentType = row["DocumentType"];
                _veInvoice.customerBankAccountDetraction = row["CustomerBankAccountDetraction"];
                _veInvoice.nroComprobante = row["NroComprobante"];
                _veInvoice.nroSerie = row["NroSerie"];
                _veInvoice.tipoServicio = row["TipoServicio"];
                _veInvoice.customerDocType = row["CustomerDocType"];
                _veInvoice.accounting = row["Accounting"];
                _veInvoice.amountDetraccionUS = string.IsNullOrEmpty(row["AmountDetractionUS"]) ? 0 : decimal.Parse(row["AmountDetractionUS"]);
                _veInvoice.status = row["Status"];
                _veInvoice.invoiceStatusId = string.IsNullOrEmpty(row["InvoiceStatusId"]) ? 0 : int.Parse(row["InvoiceStatusId"]);
                _veInvoice.invoiceType = row["InvoiceType"];
                _veInvoice.reference = row["reference"];
                _veInvoice.comments = row["comments"];

                
                _veInvoice.dueDateFormat = _veInvoice.dueDate.ToShortDateString();
                _veInvoice.due = string.IsNullOrEmpty(row["Due"]) ? 0 : int.Parse(row["Due"]);
                _lstInvoices.Add(_veInvoice);
            }

            return _lstInvoices;
        }

        public List<VE_Invoice> GetInvoiceByCompanyCode(string companyCode, string invoiceType)
        {
            VE_Invoice _veInvoice = null;
            List<VE_Invoice> _lstInvoices = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", companyCode);
            parameters.Add("_invoiceType", invoiceType);

            var rows = _database.QuerySP("sps_getInvoiceByCompanyCodeInvoiceType", parameters);
            foreach (var row in rows)
            {
                _veInvoice = new VE_Invoice();
                _veInvoice.invoiceId = row["InvoiceId"];
                _veInvoice.amountBalance = string.IsNullOrEmpty(row["AmountBalance"]) ? 0 : decimal.Parse(row["AmountBalance"]);
                _veInvoice.amountDetraction = string.IsNullOrEmpty(row["AmountDetraction"]) ? 0 : decimal.Parse(row["AmountDetraction"]);
                _veInvoice.amountPayment = string.IsNullOrEmpty(row["AmountPayment"]) ? 0 : decimal.Parse(row["AmountPayment"]);
                _veInvoice.amountPaymentDetraction = string.IsNullOrEmpty(row["AmountPaymentDetraction"]) ? 0 : decimal.Parse(row["AmountPaymentDetraction"]);
                _veInvoice.amountPaymentFromBank = string.IsNullOrEmpty(row["AmountPaymentFromBank"]) ? 0 : decimal.Parse(row["AmountPaymentFromBank"]);
                _veInvoice.amountPaymentPen = string.IsNullOrEmpty(row["AmountPaymentPen"]) ? 0 : decimal.Parse(row["AmountPaymentPen"]);
                _veInvoice.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _veInvoice.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                _veInvoice.bankAccountNumber = row["BankAccountNumber"];
                _veInvoice.bankId = string.IsNullOrEmpty(row["BankId"]) ? 0 : int.Parse(row["BankId"]);
                _veInvoice.budgetFile = row["BudgetFile"];
                _veInvoice.companyCode = row["CompanyCode"];
                _veInvoice.currency = row["Currency"];
                _veInvoice.currencyPayment = row["CurrencyPayment"];
                _veInvoice.customerBankAccountPen = row["CustomerBankAccountPen"];
                _veInvoice.customerBankAccountUsd = row["CustomerBankAccountUsd"];
                _veInvoice.customerName = row["CustomerName"];
                _veInvoice.customerRuc = row["CustomerRuc"];
                _veInvoice.documentDate = string.IsNullOrEmpty(row["DocumentDate"]) ? DateTime.Now : DateTime.Parse(row["DocumentDate"]);
                _veInvoice.documentDateFormat = _veInvoice.documentDate.ToShortDateString();
                _veInvoice.documentId = row["DocumentId"];
                _veInvoice.dueDate = string.IsNullOrEmpty(row["DueDate"]) ? DateTime.Now : DateTime.Parse(row["DueDate"]);
                _veInvoice.exchangeRate = row["ExchangeRate"];
                _veInvoice.invoiceFile = row["InvoiceFile"];
                _veInvoice.ocrFile = row["OCRFile"];
                _veInvoice.customerEmail = row["CustomerEmail"];
                _veInvoice.documentType = row["DocumentType"];
                _veInvoice.customerBankAccountDetraction = row["CustomerBankAccountDetraction"];
                _veInvoice.nroComprobante = row["NroComprobante"];
                _veInvoice.nroSerie = row["NroSerie"];
                _veInvoice.tipoServicio = row["TipoServicio"];
                _veInvoice.customerDocType = row["CustomerDocType"];
                _veInvoice.accounting = row["Accounting"];
                _veInvoice.amountDetraccionUS = string.IsNullOrEmpty(row["AmountDetractionUS"]) ? 0 : decimal.Parse(row["AmountDetractionUS"]);
                _veInvoice.status = row["Status"];
                _veInvoice.invoiceStatusId = string.IsNullOrEmpty(row["InvoiceStatusId"]) ? 0 : int.Parse(row["InvoiceStatusId"]);
                _veInvoice.invoiceType = row["InvoiceType"];
                _veInvoice.reference = row["reference"];
                _veInvoice.comments = row["comments"];

                _veInvoice.dueDateFormat = _veInvoice.dueDate.ToShortDateString();
                _veInvoice.due = string.IsNullOrEmpty(row["Due"]) ? 0 : int.Parse(row["Due"]);
                _lstInvoices.Add(_veInvoice);
            }

            return _lstInvoices;
        }

        public List<VE_Invoice> GetInvoiceByFilter(string companyCode, int invoiceStatusId, DateTime dateFrom, DateTime dateTo)
        {
            VE_Invoice _veInvoice = null;
            List<VE_Invoice> _lstInvoices = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", companyCode);
            parameters.Add("_invoiceStatusId", invoiceStatusId);
            parameters.Add("_dateFrom", dateFrom);
            parameters.Add("_dateTo", dateTo);

            var rows = _database.QuerySP("sps_getInvoiceByFilter", parameters);
            foreach (var row in rows)
            {
                _veInvoice = new VE_Invoice();
                _veInvoice.invoiceId = row["InvoiceId"];
                _veInvoice.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _veInvoice.companyCode = row["CompanyCode"];
                _veInvoice.currency = row["Currency"];
                _veInvoice.customerName = row["CustomerName"];
                _veInvoice.customerRuc = row["CustomerRuc"];
                _veInvoice.documentDate = string.IsNullOrEmpty(row["DocumentDate"]) ? DateTime.MinValue : DateTime.Parse(row["DocumentDate"]);
                _veInvoice.documentDateFormat = _veInvoice.documentDate.ToShortDateString();
                _veInvoice.documentId = row["DocumentId"];
                _veInvoice.dueDate = string.IsNullOrEmpty(row["DueDate"]) ? DateTime.MinValue : DateTime.Parse(row["DueDate"]);
                _veInvoice.dueDateFormat = _veInvoice.dueDate.ToShortDateString();
                _veInvoice.customerDate = string.IsNullOrEmpty(row["DocumentDate"]) ? DateTime.MinValue : DateTime.Parse(row["DocumentDate"]);
                _veInvoice.customerDateFormat = _veInvoice.customerDate.ToShortDateString();
                _veInvoice.due = string.IsNullOrEmpty(row["Due"]) ? 0 : int.Parse(row["Due"]);
                _veInvoice.exchangeRate = row["ExchangeRate"];
                _veInvoice.customerEmail = row["CustomerEmail"];
                _veInvoice.documentType = row["DocumentType"];
                _veInvoice.nroComprobante = row["NroComprobante"];
                _veInvoice.nroSerie = row["NroSerie"];
                _veInvoice.tipoServicio = row["TipoServicio"];
                _veInvoice.customerDocType = row["CustomerDocType"];
                _veInvoice.accounting = row["Accounting"];
                _veInvoice.invoiceStatusId = string.IsNullOrEmpty(row["InvoiceStatusId"]) ? 0 : int.Parse(row["InvoiceStatusId"]);
                _veInvoice.status = row["Status"];
                _veInvoice.invoiceType = row["InvoiceType"];
                _veInvoice.reference = row["reference"];
                _veInvoice.comments = row["comments"];
                _lstInvoices.Add(_veInvoice);
            }

            return _lstInvoices;
        }


        public List<VE_Invoice> GetInvoiceByCompanyCodeAndType(string companyCode,string invoiceType, int invoiceStatusId, DateTime dateFrom, DateTime dateTo)
        {
            VE_Invoice _veInvoice = null;
            List<VE_Invoice> _lstInvoices = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", companyCode);
            parameters.Add("_invoiceType", invoiceType);
            parameters.Add("_invoiceStatusId", invoiceStatusId);
            parameters.Add("_dateFrom", dateFrom);
            parameters.Add("_dateTo", dateTo);

            var rows = _database.QuerySP("sps_getInvoiceByCompanyCodeAndType", parameters);
            foreach (var row in rows)
            {
                _veInvoice = new VE_Invoice();
                _veInvoice.invoiceId = row["InvoiceId"];
                _veInvoice.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _veInvoice.companyCode = row["CompanyCode"];
                _veInvoice.companyName = row["CompanyName"];
                _veInvoice.companyRuc = row["CompanyRuc"];
                _veInvoice.currency = row["Currency"];
                _veInvoice.customerName = row["CustomerName"];
                _veInvoice.customerRuc = row["CustomerRuc"];
                _veInvoice.documentDate = string.IsNullOrEmpty(row["DocumentDate"]) ? DateTime.Now : DateTime.Parse(row["DocumentDate"]);
                _veInvoice.documentDateFormat = _veInvoice.documentDate.ToShortDateString();
                _veInvoice.documentId = row["DocumentId"];
                _veInvoice.dueDate = string.IsNullOrEmpty(row["DueDate"]) ? DateTime.Now : DateTime.Parse(row["DueDate"]);
                _veInvoice.dueDateFormat = _veInvoice.dueDate.ToShortDateString();
                _veInvoice.due = string.IsNullOrEmpty(row["Due"]) ? 0 : int.Parse(row["Due"]);
                _veInvoice.exchangeRate = row["ExchangeRate"];
                _veInvoice.customerEmail = row["CustomerEmail"];
                _veInvoice.documentType = row["DocumentType"];
                _veInvoice.nroComprobante = row["NroComprobante"];
                _veInvoice.nroSerie = row["NroSerie"];
                _veInvoice.tipoServicio = row["TipoServicio"];
                _veInvoice.customerDocType = row["CustomerDocType"];
                _veInvoice.accounting = row["Accounting"];
                _veInvoice.invoiceStatusId = string.IsNullOrEmpty(row["InvoiceStatusId"]) ? 0 : int.Parse(row["InvoiceStatusId"]);
                _veInvoice.status = row["Status"];
                _veInvoice.invoiceType = row["InvoiceType"];
                _veInvoice.reference = row["reference"];
                _veInvoice.comments = row["comments"];
                _lstInvoices.Add(_veInvoice);
            }

            return _lstInvoices;
        }

        public List<VE_InvoiceDetail> GetInvoiceDetailByInvoiceId(int invoiceId)
        {
            VE_InvoiceDetail _veInvoiceDetail = null;
            List<VE_InvoiceDetail> _lstInvoiceDetail = new List<VE_InvoiceDetail>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_invoiceId", invoiceId } };

            var rows = _database.QuerySP("sps_getInvoiceDetailByInvoiceId", parameters);
            foreach (var row in rows)
            {
                _veInvoiceDetail = new VE_InvoiceDetail();
                _veInvoiceDetail.invoiceDetailId = string.IsNullOrEmpty(row["invoiceDetailId"]) ? 0 : int.Parse(row["invoiceDetailId"]);
                _veInvoiceDetail.invoiceId = string.IsNullOrEmpty(row["invoiceId"]) ? 0 : int.Parse(row["invoiceId"]);
                _veInvoiceDetail.invoiceItemId = string.IsNullOrEmpty(row["invoiceItemId"]) ? 0 : int.Parse(row["invoiceItemId"]);
                _veInvoiceDetail.invoiceItem = row["invoiceItem"];
                _veInvoiceDetail.quantity = string.IsNullOrEmpty(row["quantity"]) ? 0 : decimal.Parse(row["quantity"]);
                _veInvoiceDetail.unitprice = string.IsNullOrEmpty(row["unitprice"]) ? 0 : decimal.Parse(row["unitprice"]);
                _veInvoiceDetail.price = string.IsNullOrEmpty(row["price"]) ? 0 : decimal.Parse(row["price"]);
                _veInvoiceDetail.igvAmount = string.IsNullOrEmpty(row["igvAmount"]) ? 0 : decimal.Parse(row["igvAmount"]);
                _veInvoiceDetail.isEnabled = string.IsNullOrEmpty(row["isEnabled"]) ? false : row["isEnabled"].Equals("1") ? true : false;

                _lstInvoiceDetail.Add(_veInvoiceDetail);
            }

            return _lstInvoiceDetail;
        }

        public List<VE_Invoice> GetInvoiceResumeByCompanyCode(string companyCode, string invoiceType)
        {
            VE_Invoice _veInvoice = null;
            List<VE_Invoice> _lstInvoices = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", companyCode);
            parameters.Add("_invoiceType", invoiceType);
            

            var rows = _database.QuerySP("sps_getInvoiceResumeByCompanyCode", parameters);
            foreach (var row in rows)
            {
                _veInvoice = new VE_Invoice();
                _veInvoice.currency = row["Currency"];
                _veInvoice.amountBalance = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _veInvoice.cantidad = row["Cantidad"];
                _lstInvoices.Add(_veInvoice);
            }

            return _lstInvoices;
        }

        public List<BE_InvoiceItem> GetInvoiceItem(string companyCode)
        {
            BE_InvoiceItem __beInvoiceItem = null;
            List<BE_InvoiceItem> _lstInvoiceItem = new List<BE_InvoiceItem>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_companyCode", companyCode } };

            var rows = _database.QuerySP("sps_getInvoiceItem", parameters);
            foreach (var row in rows)
            {
                __beInvoiceItem = new BE_InvoiceItem();
                __beInvoiceItem.invoiceItemId = string.IsNullOrEmpty(row["invoiceItemId"]) ? 0 : int.Parse(row["invoiceItemId"]);
                __beInvoiceItem.name = row["name"];
                __beInvoiceItem.companyCode = row["companyCode"];
                __beInvoiceItem.suggestedPrice = string.IsNullOrEmpty(row["suggestedPrice"]) ? 0 : decimal.Parse(row["suggestedPrice"]);
                __beInvoiceItem.invoiceItemType = row["invoiceItemType"];
                __beInvoiceItem.createdBy = row["createdBy"];
                __beInvoiceItem.igvAffected = string.IsNullOrEmpty(row["igvAffected"]) ? false: row["igvAffected"].Equals("1") ? true : false;
                _lstInvoiceItem.Add(__beInvoiceItem);
            }

            return _lstInvoiceItem;
        }

        public BE_InvoiceItem AddInvoiceItem(BE_InvoiceItem _beInvoiceItem)
        {
            string invoiceItemId = string.Empty;
            object id = null;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_name", _beInvoiceItem.name);
            parameters.Add("_companyCode", _beInvoiceItem.companyCode);
            parameters.Add("_suggestedPrice", _beInvoiceItem.suggestedPrice);
            parameters.Add("_invoiceItemType", _beInvoiceItem.invoiceItemType);
            parameters.Add("_createdBy", _beInvoiceItem.createdBy);
            parameters.Add("_igvAffected", _beInvoiceItem.igvAffected);

            id = _database.ExecuteSPGetId("spi_insertInvoiceItem", parameters);
            invoiceItemId = id.ToString();

            boResultado = (int.Parse(invoiceItemId) > 0);
            if (boResultado)
            {
                _beInvoiceItem.invoiceItemId = int.Parse(invoiceItemId);
                return _beInvoiceItem;
            }

            return null;
        }


        public List<VE_Invoice> getInvoiceGeneral(BEInvoiceFilter _bEInvoiceFilter)
        {
            VE_Invoice _VeInvoice = null;
            List<VE_Invoice> _lstInvoice = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();


            parameters.Add("_invoiceIdList", _bEInvoiceFilter.invoiceIdList);
            parameters.Add("_statusList", _bEInvoiceFilter.statusList);
            parameters.Add("_invoiceType", _bEInvoiceFilter.invoiceType);


            var rows = _database.QuerySP("sps_getInvoiceGeneral", parameters);
            foreach (var row in rows)
            {
                _VeInvoice = new VE_Invoice();
                _VeInvoice.invoiceId = row["Id"];
                _VeInvoice.amountBalance = string.IsNullOrEmpty(row["AmountBalance"]) ? 0 : decimal.Parse(row["AmountBalance"]);
                _VeInvoice.amountDetraction = string.IsNullOrEmpty(row["AmountDetraction"]) ? 0 : decimal.Parse(row["AmountDetraction"]);
                _VeInvoice.amountPayment = string.IsNullOrEmpty(row["AmountPayment"]) ? 0 : decimal.Parse(row["AmountPayment"]);
                _VeInvoice.amountPaymentDetraction = string.IsNullOrEmpty(row["AmountPaymentDetraction"]) ? 0 : decimal.Parse(row["AmountPaymentDetraction"]);
                _VeInvoice.amountPaymentFromBank = string.IsNullOrEmpty(row["AmountPaymentFromBank"]) ? 0 : decimal.Parse(row["AmountPaymentFromBank"]);
                _VeInvoice.amountPaymentPen = string.IsNullOrEmpty(row["AmountPaymentPen"]) ? 0 : decimal.Parse(row["AmountPaymentPen"]);
                _VeInvoice.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _VeInvoice.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                _VeInvoice.bankAccountNumber = row["BankAccountNumber"];
                _VeInvoice.bankId = string.IsNullOrEmpty(row["BankId"]) ? 0 : int.Parse(row["BankId"]);
                _VeInvoice.budgetFile = row["BudgetFile"];
                _VeInvoice.companyCode = row["CompanyCode"];
                _VeInvoice.currency = row["Currency"];
                _VeInvoice.currencyPayment = row["CurrencyPayment"];
                _VeInvoice.customerBankAccountPen = row["CustomerBankAccountPen"];
                _VeInvoice.customerBankAccountUsd = row["CustomerBankAccountUsd"];
                _VeInvoice.customerName = row["CustomerName"];
                _VeInvoice.customerRuc = row["CustomerRuc"];
                _VeInvoice.documentDate = string.IsNullOrEmpty(row["DocumentDate"]) ? DateTime.Now : DateTime.Parse(row["DocumentDate"]);
                _VeInvoice.documentId = row["DocumentId"];
                _VeInvoice.dueDate = string.IsNullOrEmpty(row["DueDate"]) ? DateTime.Now : DateTime.Parse(row["DueDate"]);
                _VeInvoice.exchangeRate = row["ExchangeRate"];
                _VeInvoice.invoiceFile = row["InvoiceFile"];
                _VeInvoice.ocrFile = row["OCRFile"];
                _VeInvoice.customerEmail = row["CustomerEmail"];
                _VeInvoice.documentType = row["DocumentType"];
                _VeInvoice.customerBankAccountDetraction = row["CustomerBankAccountDetraction"];
                _VeInvoice.nroComprobante = row["NroComprobante"];
                _VeInvoice.nroSerie = row["NroSerie"];
                _VeInvoice.tipoServicio = row["TipoServicio"];
                _VeInvoice.customerDocType = row["CustomerDocType"];
                _VeInvoice.accounting = row["Accounting"];
                _VeInvoice.amountDetraccionUS = string.IsNullOrEmpty(row["AmountDetractionUS"]) ? 0 : decimal.Parse(row["AmountDetractionUS"]);
                _VeInvoice.status = row["Status"];
                _VeInvoice.invoiceStatusId = string.IsNullOrEmpty(row["InvoiceStatusId"]) ? 0 : int.Parse(row["InvoiceStatusId"]);
                _VeInvoice.invoiceType = row["InvoiceType"];
                _VeInvoice.reference = row["reference"];
                _VeInvoice.comments = row["comments"];
                _lstInvoice.Add(_VeInvoice);
            }


            return _lstInvoice;
        }


        public VE_Invoice updateInvoiceGeneral(VE_Invoice _VeInvoice)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id", _VeInvoice.invoiceId);
            parameters.Add("_amountBalance", (_VeInvoice.amountBalance == 0) ? DBNull.Value : (object)_VeInvoice.amountBalance);
            parameters.Add("_amountDetraction", (_VeInvoice.amountDetraction == 0) ? DBNull.Value : (object)_VeInvoice.amountDetraction);
            parameters.Add("_amountPayment", (_VeInvoice.amountPayment == 0) ? DBNull.Value : (object)_VeInvoice.amountPayment);
            parameters.Add("_amountPaymentDetraction", (_VeInvoice.amountPaymentDetraction == 0) ? DBNull.Value : (object)_VeInvoice.amountPaymentDetraction);
            parameters.Add("_amountPaymentFromBank", (_VeInvoice.amountPaymentFromBank == 0) ? DBNull.Value : (object)_VeInvoice.amountPaymentFromBank);
            parameters.Add("_amountPaymentPen", (_VeInvoice.amountPaymentPen == 0) ? DBNull.Value : (object)_VeInvoice.amountPaymentPen);
            parameters.Add("_amountTotal", (_VeInvoice.amountTotal == 0) ? DBNull.Value : (object)_VeInvoice.amountTotal);
            parameters.Add("_bankAccountId", (_VeInvoice.bankAccountId == 0) ? DBNull.Value : (object)_VeInvoice.bankAccountId);
            parameters.Add("_bankAccountNumber", _VeInvoice.bankAccountNumber);
            parameters.Add("_bankId", ((_VeInvoice.bankId==0)?DBNull.Value:(object)_VeInvoice.bankId) );
            parameters.Add("_budgetFile", _VeInvoice.budgetFile);
            parameters.Add("_companyCode", _VeInvoice.companyCode);
            parameters.Add("_currency", _VeInvoice.currency);
            parameters.Add("_currencyPayment", _VeInvoice.currencyPayment);
            parameters.Add("_customerBankAccountPen", _VeInvoice.customerBankAccountPen);
            parameters.Add("_customerBankAccountUsd", _VeInvoice.customerBankAccountUsd);
            parameters.Add("_customerName", _VeInvoice.customerName);
            parameters.Add("_customerRuc", _VeInvoice.customerRuc);
            parameters.Add("_documentDate", _VeInvoice.documentDate);
            parameters.Add("_documentId", _VeInvoice.documentId);
            parameters.Add("_dueDate", _VeInvoice.dueDate);
            parameters.Add("_exchangeRate", _VeInvoice.exchangeRate);
            parameters.Add("_invoiceFile", _VeInvoice.invoiceFile);
            parameters.Add("_oCRFile", _VeInvoice.ocrFile);
            parameters.Add("_customerEmail", _VeInvoice.customerEmail);
            parameters.Add("_documentType", _VeInvoice.documentType);
            parameters.Add("_customerBankAccountDetraction", _VeInvoice.customerBankAccountDetraction);
            parameters.Add("_nroComprobante", _VeInvoice.nroComprobante);
            parameters.Add("_nroSerie", _VeInvoice.nroSerie);
            parameters.Add("_tipoServicio", _VeInvoice.tipoServicio);
            parameters.Add("_customerDocType", _VeInvoice.customerDocType);
            parameters.Add("_accounting", _VeInvoice.accounting);
            parameters.Add("_amountDetractionUS", _VeInvoice.amountDetraccionUS);
            parameters.Add("_status", _VeInvoice.status);
            parameters.Add("_userAudit", _VeInvoice.userAudit);
            parameters.Add("_invoiceType", _VeInvoice.invoiceType);
            parameters.Add("_reference", _VeInvoice.reference);
            parameters.Add("_comments", _VeInvoice.comments);




            filasAfectadas = _database.ExecuteSP("spu_updateInvoiceGeneral", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                _VeInvoice.documentDateFormat = _VeInvoice.documentDate.ToShortDateString();
                _VeInvoice.dueDateFormat = _VeInvoice.dueDate.ToShortDateString();
                _VeInvoice.customerDateFormat = _VeInvoice.customerDate.ToShortDateString();
                return _VeInvoice;

            }
            return null;
        }



        public int DeleteInvoiceDetailByInvoiceId(string invoiceId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_invoiceId", invoiceId);

            filasAfectadas = _database.ExecuteSP("sp_deleteInvoiceDetailByInvoiceId", parameters);
            
            return filasAfectadas;
        }

        public List<BE_DocumentType> GetDocumentTypeGeneral(BE_DocumentType bE_DocumentType)
        {
            BE_DocumentType _DocumentType = null;
            List<BE_DocumentType> _DocumentTypes = new List<BE_DocumentType>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();


            parameters.Add("_documentTypeId", bE_DocumentType.documentTypeId);


            var rows = _database.QuerySP("sp_getDocumentTypeGeneral", parameters);
            foreach (var row in rows)
            {
                _DocumentType = new BE_DocumentType();
                _DocumentType.documentTypeId = row["idDocumentType"];
                _DocumentType.description = row["description"];
                _DocumentTypes.Add(_DocumentType);
            }


            return _DocumentTypes;
        }

        public BE_DocumentType CreateDocumentTypeGeneral(BE_DocumentType bE_DocumentType)
        {
            int filasAfectadas = 0;
            bool boResultado = false;
            List<BE_DocumentType> _DocumentTypes = new List<BE_DocumentType>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_documentTypeId", bE_DocumentType.documentTypeId);
            parameters.Add("_description", bE_DocumentType.description);


            filasAfectadas = _database.ExecuteSP("sp_createDocumentTypeGeneral", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return bE_DocumentType;

            }
            return null;

        }

        public BE_DocumentType UpdateDocumentTypeGeneral(BE_DocumentType bE_DocumentType)
        {
            int filasAfectadas = 0;
            bool boResultado = false;
            List<BE_DocumentType> _DocumentTypes = new List<BE_DocumentType>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_documentTypeId", bE_DocumentType.documentTypeId);
            parameters.Add("_updatedDocumentTypeId", bE_DocumentType.UpdatedDocumentTypeId);
            parameters.Add("_description", bE_DocumentType.description);


            filasAfectadas = _database.ExecuteSP("sp_updateDocumentTypeGeneral", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return bE_DocumentType;

            }
            return null;

        }
    }
}

