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
    public class DA_Payment
    {
        public MySQLDatabase _database { get; set; }// = new MySQLDatabase("pagosapp");


        /// <summary>
        /// Constructor that takes a MySQLDatabase instance 
        /// </summary>
        /// <param name="database"></param>
        public DA_Payment(MySQLDatabase database)
        {
            _database = database;
        }

        public List<VE_Payment> getCompanyPaymentsByPeriod(string companyCode)
        {
            VE_Payment _vePayment  = null;
            List<VE_Payment> _lstPayments = new List<VE_Payment>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_companyCode", companyCode } };

            var rows = _database.QuerySP("sps_obtenerPagosPorMes", parameters);
            foreach (var row in rows)
            {
                _vePayment = new VE_Payment();
                _vePayment.periodo = row["Periodo"];
                _vePayment.mes = row["Mes"];
                _vePayment.currency = row["Currency"];
                _vePayment.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _lstPayments.Add(_vePayment);
            }

            return _lstPayments;
        }

        public BE_PaymentAuth createPaymentAuth(BE_PaymentAuth _bePaymentAuth)
        {
            int paymentAuthId = 0;
            object id = null;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_amountDetracionPaid", _bePaymentAuth.amountDetractionPaid);
            parameters.Add("_amountPaid", _bePaymentAuth.amountPaid);
            parameters.Add("_amountPaidPen", _bePaymentAuth.amountPaidPen);
            parameters.Add("_amountPaidUsd", _bePaymentAuth.amountPaidUsd);
            parameters.Add("_bankAccountId", _bePaymentAuth.bankAccountId);
            parameters.Add("_companyCode", _bePaymentAuth.companyCode);
            parameters.Add("_createdBy", _bePaymentAuth.userName);
            parameters.Add("_exchangeRate", _bePaymentAuth.exchangeRate);
           //parameters.Add("_firstUserId", _bePaymentAuth.firstUserId);
            parameters.Add("_payDate", _bePaymentAuth.payDate);
            parameters.Add("_loteDetraccion", _bePaymentAuth.loteDetraccion);
            parameters.Add("_accountPayDate", _bePaymentAuth.accountPayDate);
            id = _database.ExecuteSPGetId("spi_createPaymentAuth", parameters);
            paymentAuthId = int.Parse(id.ToString());

            boResultado = (paymentAuthId > 0);
            if (boResultado)
            {
                _bePaymentAuth.paymentAuthId = paymentAuthId;
                return _bePaymentAuth;

            }
            return null;

        }
        public BE_PaymentAuth updatePaymentAuth(BE_PaymentAuth _bePaymentAuth)
        {
            int filasAfectadas = 0;
            object id = null;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_paymentAuthId", _bePaymentAuth.paymentAuthId);
            parameters.Add("_amountDetracionPaid", _bePaymentAuth.amountDetractionPaid);
            parameters.Add("_amountPaid", _bePaymentAuth.amountPaid);
            parameters.Add("_amountPaidPen", _bePaymentAuth.amountPaidPen);
            parameters.Add("_amountPaidUsd", _bePaymentAuth.amountPaidUsd);
            parameters.Add("_bankAccountId", _bePaymentAuth.bankAccountId);
            parameters.Add("_companyCode", _bePaymentAuth.companyCode);
            parameters.Add("_exchangeRate", _bePaymentAuth.exchangeRate);
            //parameters.Add("_payDate", _bePaymentAuth.payDate);
            parameters.Add("_loteDetraccion", _bePaymentAuth.loteDetraccion);
            parameters.Add("_accountPayDate", _bePaymentAuth.accountPayDate);
            filasAfectadas = _database.ExecuteSP("spu_updatePaymentAuth", parameters);
            

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _bePaymentAuth;
            }
            return null;

        }

        public BE_PaymentAuth updatePaymentAuthPayDate(VE_PaymentAuth _bePaymentAuth, string userId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_paymentAuthId", _bePaymentAuth.paymentAuthId);
            parameters.Add("_payDate", _bePaymentAuth.payDateStr);
            filasAfectadas = _database.ExecuteSP("spu_updatePaymentAuthPayDate", parameters);


            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _bePaymentAuth;
            }
            return null;

        }

        /*
        public BE_Payment createPayment(BE_Payment _bePayment)
        {
            string strError_Mensaje = string.Empty;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_invoiceId", _bePayment.id);
            parameters.Add("_paymentAuthId", _bePayment.paymentAuthId);
            parameters.Add("_userName", "admin");
            var id = _database.ExecuteSPGetId("spi_createPayment", parameters);

            if (id!=null)
            {
                _bePayment.paymentId = int.Parse(id.ToString());
                return _bePayment;
            }
            return null;

        }
        */

        public BE_Payment createPayment(BE_Payment _bePayment)
        {
            string strError_Mensaje = string.Empty;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_invoiceId", _bePayment.id);
            parameters.Add("_paymentAuthId", _bePayment.paymentAuthId);
            parameters.Add("_userName", _bePayment.userName);
            var id = _database.ExecuteSPGetId("spi_createPayment", parameters);

            if (id != null)
            {
                _bePayment.paymentId = int.Parse(id.ToString());
                return _bePayment;
            }
            return null;

        }

        public BE_Payment createPaymentGeneral(BE_Payment _bePayment)
        {
            string strError_Mensaje = string.Empty;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_AmountBalance", _bePayment.amountBalance);
            parameters.Add("_AmountDetraction", _bePayment.amountDetraction);
            parameters.Add("_AmountPayment", _bePayment.amountPayment);
            parameters.Add("_AmountPaymentDetraction", _bePayment.amountPaymentDetraction);
            parameters.Add("_AmountPaymentFromBank", _bePayment.amountPaymentFromBank);
            parameters.Add("_AmountPaymentPen", _bePayment.amountPaymentPen);
            parameters.Add("_AmountTotal", _bePayment.amountTotal);
            parameters.Add("_CompanyCode", _bePayment.companyCode);
            parameters.Add("_CreatedBy", _bePayment.userName);
            parameters.Add("_Currency", _bePayment.currency);
            parameters.Add("_CurrencyPayment", _bePayment.currencyPayment);
            parameters.Add("_CustomerName", _bePayment.customerName);
            parameters.Add("_CustomerRuc", _bePayment.customerRuc);
            parameters.Add("_DocumentId", _bePayment.documentId);
            parameters.Add("_ExchangeRate", _bePayment.exchangeRate);
            parameters.Add("_InvoiceId", _bePayment.id);
            parameters.Add("_PaymentAuthId", _bePayment.paymentAuthId);
            parameters.Add("_CustomerEmail", _bePayment.customerEmail);
            parameters.Add("_DocumentType", _bePayment.documentType);
            parameters.Add("_CustomerBankAccountDetraction", _bePayment.customerBankAccountDetraction);
            parameters.Add("_NroComprobante", _bePayment.nroComprobante);
            parameters.Add("_NroSerie", _bePayment.nroSerie);
            parameters.Add("_TipoServicio", _bePayment.tipoServicio);
            parameters.Add("_CustomerDocType", _bePayment.customerDocType);
            parameters.Add("_Accounting", _bePayment.accounting);
            parameters.Add("_AmountDetractionUS", _bePayment.amountDetractionUS);
            parameters.Add("_Reference", _bePayment.reference);
            parameters.Add("_PaymentStatusId", _bePayment.paymentStatusId);
            parameters.Add("_PaymentMethodId", _bePayment.paymentMethodId);

            var id = _database.ExecuteSPGetId("sp_createPaymentGeneral", parameters);

            if (id != null)
            {
                _bePayment.paymentId = int.Parse(id.ToString());
                return _bePayment;
            }
            return null;

        }

        public BE_Payment createPaymentSales(BE_Payment _bePayment)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_invoiceId", _bePayment.id);
            parameters.Add("_bankId", _bePayment.bankId);
            parameters.Add("_paymentDate", _bePayment.payDate);
            parameters.Add("_reference", _bePayment.reference);
            parameters.Add("_paymentStatusId", _bePayment.paymentStatusId);
            parameters.Add("_paymentMethodId", _bePayment.paymentMethodId);
            parameters.Add("_createdBy", _bePayment.createdBy);
            parameters.Add("_BankAccountId", _bePayment.bankAccountId);
            filasAfectadas = _database.ExecuteSP("spi_createPaymentSales", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _bePayment;

            }
            return null;

            // _invoiceId VARCHAR(20), IN _paymentAuthId

        }

        //6
        public List<VE_Payment> getPaymentsByAuthId(int paymentAuthId)
        {
            VE_Payment _vePayment = null;
            List<VE_Payment> _lstPayments = new List<VE_Payment>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_paymentAuthId", paymentAuthId } };

            var rows = _database.QuerySP("sps_getPaymentByAuthId", parameters);
            foreach (var row in rows)
            {
                _vePayment = new VE_Payment();
                _vePayment.paymentId = string.IsNullOrEmpty(row["PaymentId"]) ? 0 : Int64.Parse(row["PaymentId"]); 
                _vePayment.id = row["invoiceId"];
                _vePayment.amountBalance = string.IsNullOrEmpty(row["AmountBalance"]) ? 0 : decimal.Parse(row["AmountBalance"]);
                _vePayment.amountDetraction = string.IsNullOrEmpty(row["AmountDetraction"]) ? 0 : decimal.Parse(row["AmountDetraction"]);
                _vePayment.amountPayment = string.IsNullOrEmpty(row["AmountPayment"]) ? 0 : decimal.Parse(row["AmountPayment"]);
                _vePayment.amountPaymentDetraction = string.IsNullOrEmpty(row["AmountPaymentDetraction"]) ? 0 : decimal.Parse(row["AmountPaymentDetraction"]);
                _vePayment.amountPaymentFromBank = string.IsNullOrEmpty(row["AmountPaymentFromBank"]) ? 0 : decimal.Parse(row["AmountPaymentFromBank"]);
                _vePayment.amountPaymentPen = string.IsNullOrEmpty(row["AmountPaymentPen"]) ? 0 : decimal.Parse(row["AmountPaymentPen"]);
                _vePayment.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _vePayment.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : Int64.Parse(row["BankAccountId"]);
                _vePayment.bankAccountNumber = row["BankAccountNumber"];
                _vePayment.bankId = string.IsNullOrEmpty(row["BankId"]) ? 0 : Int64.Parse(row["BankId"]);
                _vePayment.bankShortName = string.IsNullOrEmpty(row["BankShortName"]) ? string.Empty : row["BankShortName"];
                _vePayment.companyCode = row["CompanyCode"];
                _vePayment.currency = row["Currency"];
                _vePayment.currencyPayment = row["CurrencyPayment"];
                _vePayment.customerBankAccountPen = row["CustomerBankAccountPen"];
                _vePayment.customerBankAccountUsd = row["CustomerBankAccountUsd"];
                _vePayment.customerName = row["CustomerName"];
                _vePayment.customerRuc = row["CustomerRuc"];
                _vePayment.documentDate = string.IsNullOrEmpty(row["DocumentDate"]) ? DateTime.MinValue : DateTime.Parse(row["DocumentDate"]);
                _vePayment.documentDateFormat = _vePayment.documentDate.ToShortDateString();
                _vePayment.documentId = row["DocumentId"];
                _vePayment.dueDate = string.IsNullOrEmpty(row["DueDate"]) ? DateTime.MinValue : DateTime.Parse(row["DueDate"]);
                _vePayment.dueDateFormat = _vePayment.dueDate.ToShortDateString();
                _vePayment.exchangeRate = row["ExchangeRate"];
                _vePayment.paymentAuthId = string.IsNullOrEmpty(row["PaymentAuthId"]) ? 0 : Int64.Parse(row["PaymentAuthId"]);
                _vePayment.customerEmail = row["CustomerEmail"];
                _vePayment.documentType = row["DocumentType"];
                _vePayment.customerBankAccountDetraction = row["CustomerBankAccountDetraction"];
                _vePayment.nroComprobante = row["NroComprobante"];
                _vePayment.nroSerie = row["NroSerie"];
                _vePayment.tipoServicio = row["TipoServicio"];
                _vePayment.customerDocType = row["CustomerDocType"];
                _vePayment.accounting = row["Accounting"];
                _vePayment.amountDetractionUS = string.IsNullOrEmpty(row["AmountDetractionUS"]) ? 0 : decimal.Parse(row["AmountDetractionUS"]); 
                _lstPayments.Add(_vePayment);
            }

            return _lstPayments;
        }

        public List<VE_Payment> getPaymentsAuthBankAccountById(int paymentAuthId, int bankAccountId)
        {
            VE_Payment _vePayment = null;
            List<VE_Payment> _lstPayments = new List<VE_Payment>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_paymentAuthId", paymentAuthId);
            parameters.Add("_bankAccountId", bankAccountId);
        

            var rows = _database.QuerySP("sps_getPaymentsAuthBankAccountById", parameters);
            foreach (var row in rows)
            {
                _vePayment = new VE_Payment();
                _vePayment.paymentId = string.IsNullOrEmpty(row["PaymentId"]) ? 0 : Int64.Parse(row["PaymentId"]);
                _vePayment.id = row["invoiceId"];
                _vePayment.amountBalance = string.IsNullOrEmpty(row["AmountBalance"]) ? 0 : decimal.Parse(row["AmountBalance"]);
                _vePayment.amountDetraction = string.IsNullOrEmpty(row["AmountDetraction"]) ? 0 : decimal.Parse(row["AmountDetraction"]);
                _vePayment.amountPayment = string.IsNullOrEmpty(row["AmountPayment"]) ? 0 : decimal.Parse(row["AmountPayment"]);
                _vePayment.amountPaymentDetraction = string.IsNullOrEmpty(row["AmountPaymentDetraction"]) ? 0 : decimal.Parse(row["AmountPaymentDetraction"]);
                _vePayment.amountPaymentFromBank = string.IsNullOrEmpty(row["AmountPaymentFromBank"]) ? 0 : decimal.Parse(row["AmountPaymentFromBank"]);
                _vePayment.amountPaymentPen = string.IsNullOrEmpty(row["AmountPaymentPen"]) ? 0 : decimal.Parse(row["AmountPaymentPen"]);
                _vePayment.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _vePayment.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : Int64.Parse(row["BankAccountId"]);
                _vePayment.bankAccountNumber = row["BankAccountNumber"];
                _vePayment.bankId = string.IsNullOrEmpty(row["BankId"]) ? 0 : Int64.Parse(row["BankId"]);
                _vePayment.bankShortName = string.IsNullOrEmpty(row["BankShortName"]) ? string.Empty : row["BankShortName"];
                _vePayment.companyCode = row["CompanyCode"];
                _vePayment.currency = row["Currency"];
                _vePayment.currencyPayment = row["CurrencyPayment"];
                _vePayment.customerBankAccountPen = row["CustomerBankAccountPen"];
                _vePayment.customerBankAccountUsd = row["CustomerBankAccountUsd"];
                _vePayment.customerName = row["CustomerName"];
                _vePayment.customerRuc = row["CustomerRuc"];
                _vePayment.documentDate = string.IsNullOrEmpty(row["DocumentDate"]) ? DateTime.Now : DateTime.Parse(row["DocumentDate"]);
                _vePayment.documentDateFormat = _vePayment.documentDate.ToShortDateString();
                _vePayment.documentId = row["DocumentId"];
                _vePayment.dueDate = string.IsNullOrEmpty(row["DueDate"]) ? DateTime.Now : DateTime.Parse(row["DueDate"]);
                _vePayment.dueDateFormat = _vePayment.dueDate.ToShortDateString();
                _vePayment.exchangeRate = row["ExchangeRate"];
                _vePayment.paymentAuthId = string.IsNullOrEmpty(row["PaymentAuthId"]) ? 0 : Int64.Parse(row["PaymentAuthId"]);
                _vePayment.customerEmail = row["CustomerEmail"];
                _vePayment.documentType = row["DocumentType"];
                _vePayment.customerBankAccountDetraction = row["CustomerBankAccountDetraction"];
                _vePayment.nroComprobante = row["NroComprobante"];
                _vePayment.nroSerie = row["NroSerie"];
                _vePayment.tipoServicio = row["TipoServicio"];
                _vePayment.customerDocType = row["CustomerDocType"];
                _vePayment.accounting = row["Accounting"];
                _vePayment.amountDetractionUS = string.IsNullOrEmpty(row["AmountDetractionUS"]) ? 0 : decimal.Parse(row["AmountDetractionUS"]);
                _lstPayments.Add(_vePayment);
            }

            return _lstPayments;
        }
        //7
        public List<VE_PaymentAuth> getPaymentsAuthByCompanyCode(string companyCode)
        {
            VE_PaymentAuth _vePaymentAuth = null;
            List<VE_PaymentAuth> _lstPaymentsAuth = new List<VE_PaymentAuth>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_companyCode", companyCode } };

            var rows = _database.QuerySP("sps_getPaymentAuthByCompany", parameters);
            foreach (var row in rows)
            {
                _vePaymentAuth = new VE_PaymentAuth();
                _vePaymentAuth.paymentAuthId = string.IsNullOrEmpty(row["Id"]) ? 0 : int.Parse(row["Id"]); 
                _vePaymentAuth.amountDetractionPaid = string.IsNullOrEmpty(row["AmountDetractionPaid"]) ? 0 : decimal.Parse(row["AmountDetractionPaid"]);
                _vePaymentAuth.amountPaid = string.IsNullOrEmpty(row["AmountPaid"]) ? 0 : decimal.Parse(row["AmountPaid"]);
                _vePaymentAuth.amountPaidPen = string.IsNullOrEmpty(row["AmountPaidPen"]) ? 0 : decimal.Parse(row["AmountPaidPen"]);
                _vePaymentAuth.amountPaidUsd = string.IsNullOrEmpty(row["AmountPaidUsd"]) ? 0 : decimal.Parse(row["AmountPaidUsd"]);
                //_vePaymentAuth.authDateFirstUser = string.IsNullOrEmpty(row["AuthDateFirstUser"]) ? DateTime.Now : DateTime.Parse(row["AuthDateFirstUser"]);
                //_vePaymentAuth.authDateFirstUserFormat = _vePaymentAuth.authDateFirstUser.ToShortDateString();
                //_vePaymentAuth.authDateSecondUser = string.IsNullOrEmpty(row["AuthDateSecondUser"]) ? DateTime.Now : DateTime.Parse(row["AuthDateSecondUser"]);
                //_vePaymentAuth.authDateSecondUserFormat = _vePaymentAuth.authDateSecondUser.ToShortDateString();
                _vePaymentAuth.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                _vePaymentAuth.accountNumber = string.IsNullOrEmpty(row["AccountNumber"]) ? string.Empty : row["AccountNumber"].ToString();
                _vePaymentAuth.bankShortName = string.IsNullOrEmpty(row["BankShortName"]) ? string.Empty : row["BankShortName"].ToString();
                _vePaymentAuth.companyCode = string.IsNullOrEmpty(row["CompanyCode"]) ? string.Empty : row["CompanyCode"].ToString();
                _vePaymentAuth.exchangeRate = string.IsNullOrEmpty(row["ExchangeRate"]) ? 0 : decimal.Parse(row["ExchangeRate"]);
                //_vePaymentAuth.firstUserId = string.IsNullOrEmpty(row["FirstUserId"]) ? string.Empty : row["FirstUserId"].ToString();
                //_vePaymentAuth.firstUserName = string.IsNullOrEmpty(row["FirstUserName"]) ? string.Empty : row["FirstUserName"].ToString();
                _vePaymentAuth.payDate = string.IsNullOrEmpty(row["PayDate"]) ? DateTime.Now : DateTime.Parse(row["PayDate"]);
                _vePaymentAuth.payDateFormat = _vePaymentAuth.payDate.ToShortDateString();
                //_vePaymentAuth.secondUserId = string.IsNullOrEmpty(row["SecondUserId"]) ? string.Empty : row["SecondUserId"].ToString();
                //_vePaymentAuth.secondUserName = string.IsNullOrEmpty(row["SecondUserName"]) ? string.Empty : row["SecondUserName"].ToString();
                //_vePaymentAuth.status = string.IsNullOrEmpty(row["Status"]) ? string.Empty : (row["Status"].ToString() =="0"?"Pendiente": row["Status"].ToString() == "1" ? "En proceso":"Autorizado");
                _vePaymentAuth.loteDetraccion = string.IsNullOrEmpty(row["LoteDetraccion"]) ? 0 : int.Parse(row["LoteDetraccion"]);
                _vePaymentAuth.accountPayDate = string.IsNullOrEmpty(row["AccountPayDate"]) ? DateTime.Now : DateTime.Parse(row["AccountPayDate"]);
                _vePaymentAuth.accountPayDateFormat = _vePaymentAuth.accountPayDate.ToShortDateString();
                _lstPaymentsAuth.Add(_vePaymentAuth);
            }
  
            return _lstPaymentsAuth;
        }

        public List<VE_PaymentAuth> getPaymentsAuthById(int paymentAuthId)
        {
            VE_PaymentAuth _vePaymentAuth = null;
            List<VE_PaymentAuth> _lstPaymentsAuth = new List<VE_PaymentAuth>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_paymentAuthId", paymentAuthId } };

            var rows = _database.QuerySP("sps_getPaymentAuthById", parameters);
            foreach (var row in rows)
            {
                _vePaymentAuth = new VE_PaymentAuth();
                _vePaymentAuth.paymentAuthId = string.IsNullOrEmpty(row["Id"]) ? 0 : int.Parse(row["Id"]); 
                _vePaymentAuth.amountDetractionPaid = string.IsNullOrEmpty(row["AmountDetractionPaid"]) ? 0 : decimal.Parse(row["AmountDetractionPaid"]);
                _vePaymentAuth.amountPaid = string.IsNullOrEmpty(row["AmountPaid"]) ? 0 : decimal.Parse(row["AmountPaid"]);
                _vePaymentAuth.amountPaidPen = string.IsNullOrEmpty(row["AmountPaidPen"]) ? 0 : decimal.Parse(row["AmountPaidPen"]);
                _vePaymentAuth.amountPaidUsd = string.IsNullOrEmpty(row["AmountPaidUsd"]) ? 0 : decimal.Parse(row["AmountPaidUsd"]);
                //_vePaymentAuth.authDateFirstUser = string.IsNullOrEmpty(row["AuthDateFirstUser"]) ? DateTime.Now : DateTime.Parse(row["AuthDateFirstUser"]);
                //_vePaymentAuth.authDateFirstUserFormat = _vePaymentAuth.authDateFirstUser.ToShortDateString();
                //_vePaymentAuth.authDateSecondUser = string.IsNullOrEmpty(row["AuthDateSecondUser"]) ? DateTime.Now : DateTime.Parse(row["AuthDateSecondUser"]);
                //_vePaymentAuth.authDateSecondUserFormat = _vePaymentAuth.authDateSecondUser.ToShortDateString();
                _vePaymentAuth.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                _vePaymentAuth.accountNumber = string.IsNullOrEmpty(row["AccountNumber"]) ? string.Empty : row["AccountNumber"].ToString();
                _vePaymentAuth.bankShortName = string.IsNullOrEmpty(row["BankShortName"]) ? string.Empty : row["BankShortName"].ToString();
                _vePaymentAuth.bankName = string.IsNullOrEmpty(row["BankName"]) ? string.Empty : row["BankName"].ToString();
                _vePaymentAuth.currency =  string.IsNullOrEmpty(row["Currency"]) ? string.Empty : row["Currency"].ToString();
                _vePaymentAuth.companyCode = string.IsNullOrEmpty(row["CompanyCode"]) ? string.Empty : row["CompanyCode"].ToString();
                _vePaymentAuth.exchangeRate = string.IsNullOrEmpty(row["ExchangeRate"]) ? 0 : decimal.Parse(row["ExchangeRate"]);
               // _vePaymentAuth.firstUserId = string.IsNullOrEmpty(row["FirstUserId"]) ? string.Empty : row["FirstUserId"].ToString();
                //_vePaymentAuth.firstUserName = string.IsNullOrEmpty(row["FirstUserName"]) ? string.Empty : row["FirstUserName"].ToString();
                _vePaymentAuth.payDate = string.IsNullOrEmpty(row["PayDate"]) ? DateTime.Now : DateTime.Parse(row["PayDate"]);
                _vePaymentAuth.payDateFormat = _vePaymentAuth.payDate.ToShortDateString();
                //_vePaymentAuth.secondUserId = string.IsNullOrEmpty(row["SecondUserId"]) ? string.Empty : row["SecondUserId"].ToString();
                //_vePaymentAuth.secondUserName = string.IsNullOrEmpty(row["SecondUserName"]) ? string.Empty : row["SecondUserName"].ToString();
                //_vePaymentAuth.status = string.IsNullOrEmpty(row["Status"]) ? string.Empty : row["Status"].ToString();
                _vePaymentAuth.loteDetraccion = string.IsNullOrEmpty(row["LoteDetraccion"]) ? 0 : int.Parse(row["LoteDetraccion"]);
                _vePaymentAuth.accountPayDate = string.IsNullOrEmpty(row["AccountPayDate"]) ? DateTime.Now : DateTime.Parse(row["AccountPayDate"]);
                _vePaymentAuth.accountPayDateFormat = _vePaymentAuth.accountPayDate.ToShortDateString();
               // _vePaymentAuth.authorize=string.IsNullOrEmpty(row["Authorize"]) ? 0 : int.Parse(row["Authorize"]);
                _lstPaymentsAuth.Add(_vePaymentAuth);
            }

            return _lstPaymentsAuth;
        }

        //5
        public List<VE_PaymentAuth> getPaymentsAuthByCompanyCode(string companyCode, string startDate, string endDate)
        {
            VE_PaymentAuth _vePaymentAuth = null;
            List<VE_PaymentAuth> _lstPaymentsAuth = new List<VE_PaymentAuth>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", companyCode);
            parameters.Add("_startDate", startDate);
            parameters.Add("_endDate", endDate);


            var rows = _database.QuerySP("sps_getPayAuthCompanyDate", parameters);
            foreach (var row in rows)
            {
                _vePaymentAuth = new VE_PaymentAuth();
                _vePaymentAuth.paymentAuthId = string.IsNullOrEmpty(row["Id"]) ? 0 : int.Parse(row["Id"]); 
                _vePaymentAuth.amountDetractionPaid = string.IsNullOrEmpty(row["AmountDetractionPaid"]) ? 0 : decimal.Parse(row["AmountDetractionPaid"]);
                _vePaymentAuth.amountPaid = string.IsNullOrEmpty(row["AmountPaid"]) ? 0 : decimal.Parse(row["AmountPaid"]);
                _vePaymentAuth.amountPaidPen = string.IsNullOrEmpty(row["AmountPaidPen"]) ? 0 : decimal.Parse(row["AmountPaidPen"]);
                _vePaymentAuth.amountPaidUsd = string.IsNullOrEmpty(row["AmountPaidUsd"]) ? 0 : decimal.Parse(row["AmountPaidUsd"]);
               // _vePaymentAuth.authDateFirstUser = string.IsNullOrEmpty(row["AuthDateFirstUser"]) ? DateTime.Now : DateTime.Parse(row["AuthDateFirstUser"]);
                //_vePaymentAuth.authDateFirstUserFormat = _vePaymentAuth.authDateFirstUser.ToShortDateString();
                //_vePaymentAuth.authDateSecondUser = string.IsNullOrEmpty(row["AuthDateSecondUser"]) ? DateTime.Now : DateTime.Parse(row["AuthDateSecondUser"]);
                //_vePaymentAuth.authDateSecondUserFormat = _vePaymentAuth.authDateSecondUser.ToShortDateString();
                //_vePaymentAuth.authDateThirdUser = string.IsNullOrEmpty(row["AuthDateThirdUser"]) ? DateTime.Now : DateTime.Parse(row["AuthDateThirdUser"]);
                //_vePaymentAuth.authDateThirdUserFormat = _vePaymentAuth.authDateThirdUser.ToShortDateString();
                _vePaymentAuth.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                _vePaymentAuth.accountNumber = string.IsNullOrEmpty(row["AccountNumber"]) ? string.Empty : row["AccountNumber"].ToString();
                _vePaymentAuth.bankShortName = string.IsNullOrEmpty(row["BankShortName"]) ? string.Empty : row["BankShortName"].ToString();
                _vePaymentAuth.companyCode = string.IsNullOrEmpty(row["CompanyCode"]) ? string.Empty : row["CompanyCode"].ToString();
                _vePaymentAuth.exchangeRate = string.IsNullOrEmpty(row["ExchangeRate"]) ? 0 : decimal.Parse(row["ExchangeRate"]);
                //_vePaymentAuth.firstUserId = string.IsNullOrEmpty(row["FirstUserId"]) ? string.Empty : row["FirstUserId"].ToString();
                //_vePaymentAuth.firstUserName = string.IsNullOrEmpty(row["FirstUserName"]) ? string.Empty : row["FirstUserName"].ToString();
                _vePaymentAuth.payDate = string.IsNullOrEmpty(row["PayDate"]) ? DateTime.Now : DateTime.Parse(row["PayDate"]);
                _vePaymentAuth.payDateFormat = _vePaymentAuth.payDate.ToShortDateString();
                //_vePaymentAuth.secondUserId = string.IsNullOrEmpty(row["SecondUserId"]) ? string.Empty : row["SecondUserId"].ToString();
                //_vePaymentAuth.secondUserName = string.IsNullOrEmpty(row["SecondUserName"]) ? string.Empty : row["SecondUserName"].ToString();
                //_vePaymentAuth.thirdUserId = string.IsNullOrEmpty(row["ThirdUserId"]) ? string.Empty : row["ThirdUserId"].ToString();
                //_vePaymentAuth.thirdUserName = string.IsNullOrEmpty(row["ThirdUserName"]) ? string.Empty : row["ThirdUserName"].ToString();
                _vePaymentAuth.statusCode = row["Status"].ToString();
                _vePaymentAuth.status = string.IsNullOrEmpty(row["Status"]) ? string.Empty : (row["Status"].ToString() == "0" ? "Pendiente" : row["Status"].ToString() == "1" ? "En proceso" : "Autorizado");
                _vePaymentAuth.loteDetraccion = string.IsNullOrEmpty(row["LoteDetraccion"]) ? 0 : int.Parse(row["LoteDetraccion"]);
                _vePaymentAuth.accountPayDate = string.IsNullOrEmpty(row["AccountPayDate"]) ? DateTime.MinValue : DateTime.Parse(row["AccountPayDate"]);
                _vePaymentAuth.accountPayDateFormat = _vePaymentAuth.accountPayDate.ToShortDateString();
                _lstPaymentsAuth.Add(_vePaymentAuth);
            }



            return _lstPaymentsAuth;
        }


        public BE_PaymentAuth authorizePayment(BE_PaymentAuth _bePaymentAuth)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            //parameters.Add("_amountDetracionPaid", _bePaymentAuth.amountDetractionPaid);
            parameters.Add("_secondUserId", _bePaymentAuth.amountPaid);
            //parameters.Add("_amountPaidPen", _bePaymentAuth.amountPaidPen);
            //parameters.Add("_amountPaidUsd", _bePaymentAuth.amountPaidUsd);
            //parameters.Add("_bankAccountId", _bePaymentAuth.bankAccountId);
            //parameters.Add("_companyCode", _bePaymentAuth.companyCode);
            //parameters.Add("_createdBy", _bePaymentAuth.firstUserId);
            //parameters.Add("_exchangeRate", _bePaymentAuth.exchangeRate);
            //parameters.Add("_firstUserId", _bePaymentAuth.firstUserId);
            parameters.Add("_payDate", _bePaymentAuth.payDate);
            //parameters.Add("_loteDetraccion", _bePaymentAuth.loteDetraccion);
            //parameters.Add("_accountPayDate", _bePaymentAuth.accountPayDate);
            filasAfectadas = _database.ExecuteSP("spu_authorizePayment", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _bePaymentAuth;

            }
            return null;

        }

        //4
        public BE_PaymentAuth reversePayment(BE_PaymentAuth _bePayment)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            //parameters.Add("_amountDetracionPaid", _bePaymentAuth.amountDetractionPaid);
            parameters.Add("_paymentAuthId", _bePayment.paymentAuthId);
            //parameters.Add("_amountPaidPen", _bePaymentAuth.amountPaidPen);
            //parameters.Add("_amountPaidUsd", _bePaymentAuth.amountPaidUsd);
            //parameters.Add("_bankAccountId", _bePaymentAuth.bankAccountId);
            //parameters.Add("_companyCode", _bePaymentAuth.companyCode);
            //parameters.Add("_createdBy", _bePaymentAuth.firstUserId);
            //parameters.Add("_exchangeRate", _bePaymentAuth.exchangeRate);
            //parameters.Add("_firstUserId", _bePaymentAuth.firstUserId);
            parameters.Add("_userName", _bePayment.userName);
            //parameters.Add("_loteDetraccion", _bePaymentAuth.loteDetraccion);
            //parameters.Add("_accountPayDate", _bePaymentAuth.accountPayDate);
            filasAfectadas = _database.ExecuteSP("spu_reversePayment", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _bePayment;

            }
            return null;

        }

        //4
        public BE_PaymentAuth reversePaymentAuth(BE_PaymentAuth _bePaymentAuth)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            //parameters.Add("_amountDetracionPaid", _bePaymentAuth.amountDetractionPaid);
            parameters.Add("_paymentAuthId", _bePaymentAuth.paymentAuthId);
            //parameters.Add("_amountPaidPen", _bePaymentAuth.amountPaidPen);
            //parameters.Add("_amountPaidUsd", _bePaymentAuth.amountPaidUsd);
            //parameters.Add("_bankAccountId", _bePaymentAuth.bankAccountId);
            //parameters.Add("_companyCode", _bePaymentAuth.companyCode);
            //parameters.Add("_createdBy", _bePaymentAuth.firstUserId);
            //parameters.Add("_exchangeRate", _bePaymentAuth.exchangeRate);
            //parameters.Add("_firstUserId", _bePaymentAuth.firstUserId);
            //parameters.Add("_userName", userName);
            //parameters.Add("_loteDetraccion", _bePaymentAuth.loteDetraccion);
            //parameters.Add("_accountPayDate", _bePaymentAuth.accountPayDate);
            filasAfectadas = _database.ExecuteSP("spd_reversePaymentAuth", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _bePaymentAuth;

            }
            return null;

        }

        //update second user 
        public BE_PaymentAuth updateUserAuth(BE_PaymentAuth _paymentAuth,string userId) {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_Id", _paymentAuth.paymentAuthId);
            parameters.Add("_firstUserd", _paymentAuth.firstUserId);
            parameters.Add("_secondUserd", _paymentAuth.secondUserId);
            parameters.Add("_thirdUserd", _paymentAuth.thirdUserId);

            filasAfectadas = _database.ExecuteSP("spu_updateUserAuth", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _paymentAuth;

            }
            return null;
        }

        public BE_PaymentAuth UpdateSecondUserNew(BE_PaymentAuth _Payment, string secondUserId)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_paymentAuthId", _Payment.paymentAuthId);
            parameters.Add("_paymentAuthSecond", _Payment.secondUserId);

            filasAfectadas = _database.ExecuteSP("spu_updateSecondUser", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _Payment;

            }
            return null;
        }


        public BE_PaymentAuthDetail createPaymentAuthDetail(BE_PaymentAuthDetail _BePaymentAuthDetail)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_paymentAuthId", _BePaymentAuthDetail.paymentAuthId);
            parameters.Add("_Value", _BePaymentAuthDetail.value);
            parameters.Add("_Type", _BePaymentAuthDetail.type);
            parameters.Add("_UserAudit", _BePaymentAuthDetail.userAudit);


            filasAfectadas = _database.ExecuteSP("spi_createPaymentAuthDetail", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _BePaymentAuthDetail;

            }
            return null;
        }

        public List<VE_PaymentAuthDetail> getValueUserByPaymentAuthId(int PaymentAuthId)
        {
            VE_PaymentAuthDetail _vePaymentAuthDetail = null;
            List<VE_PaymentAuthDetail> _lstAuthDetail = new List<VE_PaymentAuthDetail>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_PaymentAuthId", PaymentAuthId } };

            var rows = _database.QuerySP("sps_getValueUserByPaymentAuthId", parameters);
            foreach (var row in rows)
            {
                _vePaymentAuthDetail = new VE_PaymentAuthDetail();
                _vePaymentAuthDetail.paymentAuthDetailID =string.IsNullOrEmpty(row["PaymentAuthDetailId"]) ? 0 : int.Parse(row["PaymentAuthDetailId"]);
                _vePaymentAuthDetail.paymentAuthId = string.IsNullOrEmpty(row["PaymentAuthId"]) ? 0 : int.Parse(row["PaymentAuthId"]);
                _vePaymentAuthDetail.value = row["Value"];
                _vePaymentAuthDetail.dateAuth =string.IsNullOrEmpty(row["AuthDate"]) ? DateTime.MinValue : DateTime.Parse(row["AuthDate"]);
                _vePaymentAuthDetail.dateAuthFormat = _vePaymentAuthDetail.dateAuth.ToShortDateString();
                _vePaymentAuthDetail.userAudit = row["UserAudit"];
                _vePaymentAuthDetail.type = row["Type"];


                //p., p.,p.AuthDate, p.Type,p.Value,p.UserAudit
                _lstAuthDetail.Add(_vePaymentAuthDetail);
            }

            return _lstAuthDetail;
        }

       public VE_PaymentAuthDetail getCompanyCodeByPAD(int paymentAuthDetailID)
        {
            VE_PaymentAuthDetail _vePaymentAuthDetail = null;
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_PaymentAuthDetailId", paymentAuthDetailID } };
            var rows = _database.QuerySP("sps_getCompanyCodeByPAD", parameters);
            foreach (var row in rows)
            {
                _vePaymentAuthDetail = new VE_PaymentAuthDetail();
                _vePaymentAuthDetail.companyCode = row["CompanyCode"];

            }
            return _vePaymentAuthDetail;
        }
        public VE_PaymentAuthDetail getQuantityAuthorizeByPAD(int PaymentAuthId)
        {
            VE_PaymentAuthDetail _vePaymentAuthDetail = null;
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_PaymentAuthId", PaymentAuthId } };
            var rows = _database.QuerySP("sp_quantityAuth", parameters);
            foreach (var row in rows)
            {
                _vePaymentAuthDetail = new VE_PaymentAuthDetail();
                _vePaymentAuthDetail.paymentAuthDetailID = string.IsNullOrEmpty(row["PaymentAuthId"]) ? 0 : int.Parse(row["PaymentAuthId"]);
                _vePaymentAuthDetail.canAuthorize = string.IsNullOrEmpty(row["Authorize"]) ? 0 : int.Parse(row["Authorize"]);


            }
            return _vePaymentAuthDetail;
        }

        public BE_PaymentAuthDetail createFirstPAD(BE_PaymentAuthDetail _BePaymentAuthDetail)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_paymentAuthId", _BePaymentAuthDetail.paymentAuthId);
            parameters.Add("_UserAudit", _BePaymentAuthDetail.userAudit);


            filasAfectadas = _database.ExecuteSP("spi_createFirstPAD", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _BePaymentAuthDetail;

            }
            return null;
        }

        //EXPLICAR xq devuelve solo una entidad
        public VE_PaymentAuthDetail getUserAuditByPaymentAuthId(int PaymentAuthId)
        {
            VE_PaymentAuthDetail _vePaymentAuthDetail = null;
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_PaymentAuthId", PaymentAuthId } };
            var rows = _database.QuerySP("sps_getUserAuditByPaymentAuthId", parameters);
            foreach (var row in rows)
            {
                _vePaymentAuthDetail = new VE_PaymentAuthDetail();
                _vePaymentAuthDetail.userAudit = row["UserAudit"];


            }
            return _vePaymentAuthDetail;
        }

        public List<VE_PaymentAuthDetail> getAuthorizedUserByPAID(int PaymentAuthId)
        {
            List<VE_PaymentAuthDetail> lstPaymentAuthDetail = new List<VE_PaymentAuthDetail>();
            VE_PaymentAuthDetail _vePaymentAuthDetail = null;
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_PaymentAuthId", PaymentAuthId } };
            var rows = _database.QuerySP("sps_getAuthorizeUserByPAID", parameters);
            foreach (var row in rows)
            {
                _vePaymentAuthDetail = new VE_PaymentAuthDetail();
                _vePaymentAuthDetail.paymentAuthDetailID = string.IsNullOrEmpty(row["PaymentAuthDetailId"]) ? 0 : int.Parse(row["PaymentAuthDetailId"]);
                _vePaymentAuthDetail.paymentAuthId = string.IsNullOrEmpty(row["PaymentAuthId"]) ? 0 : int.Parse(row["PaymentAuthId"]);  
                _vePaymentAuthDetail.value = row["Value"];
                _vePaymentAuthDetail.dateAuth = string.IsNullOrEmpty(row["AuthDate"]) ? DateTime.MinValue : DateTime.Parse(row["AuthDate"]);
                _vePaymentAuthDetail.dateAuthFormat = _vePaymentAuthDetail.dateAuth.ToShortDateString();
                _vePaymentAuthDetail.type = row["Type"];
                _vePaymentAuthDetail.userAudit = row["UserAudit"];
                lstPaymentAuthDetail.Add(_vePaymentAuthDetail);
            }

            return lstPaymentAuthDetail;

        }

        public List<BE_PaymentMethod> getPaymentMethod()
        {
            BE_PaymentMethod _bePaymentMethod = null;
            List<BE_PaymentMethod> _lstPaymentMethod = new List<BE_PaymentMethod>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() {  };

            var rows = _database.QuerySP("sps_paymentMethod", parameters);
            foreach (var row in rows)
            {
                _bePaymentMethod = new BE_PaymentMethod();
                _bePaymentMethod.paymentMethodId = string.IsNullOrEmpty(row["paymentMethodId"]) ? 0 : int.Parse(row["paymentMethodId"]);
                _bePaymentMethod.name = row["name"];
                _lstPaymentMethod.Add(_bePaymentMethod);
            }

            return _lstPaymentMethod;
        }

        public List<VE_Payment> getPaymentGeneral(BEPaymentFilter _bEPaymentFilter)
        {
            VE_Payment _vE_Payment = null;
            List<VE_Payment> _lstPayment = new List<VE_Payment>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();


            parameters.Add("_paymentIdList", _bEPaymentFilter.paymentIdList);
            parameters.Add("_invoiceIdList", _bEPaymentFilter.invoiceIdList);
            parameters.Add("_paymentStatusIdList", _bEPaymentFilter.paymentStatusIdList);
            parameters.Add("_companyCodeList", _bEPaymentFilter.companyCodeList);
            parameters.Add("_paymentMethodIdList", _bEPaymentFilter.paymentMethodIdList);
        

            var rows = _database.QuerySP("sps_getPaymentGeneral", parameters);
            foreach (var row in rows)
            {
                _vE_Payment = new VE_Payment();
                _vE_Payment.paymentId = string.IsNullOrEmpty(row["PaymentId"]) ? 0 : long.Parse(row["PaymentId"]) ;
                _vE_Payment.amountBalance = string.IsNullOrEmpty(row["AmountBalance"]) ? 0 : decimal.Parse(row["AmountBalance"]);
                _vE_Payment.amountDetraction = string.IsNullOrEmpty(row["AmountDetraction"]) ? 0 : decimal.Parse(row["AmountDetraction"]);
                _vE_Payment.amountPayment = string.IsNullOrEmpty(row["AmountPayment"]) ? 0 : decimal.Parse(row["AmountPayment"]);
                _vE_Payment.amountPaymentDetraction = string.IsNullOrEmpty(row["AmountPaymentDetraction"]) ? 0 : decimal.Parse(row["AmountPaymentDetraction"]);
                _vE_Payment.amountPaymentFromBank = string.IsNullOrEmpty(row["AmountPaymentFromBank"]) ? 0 : decimal.Parse(row["AmountPaymentFromBank"]);
                _vE_Payment.amountPaymentPen = string.IsNullOrEmpty(row["AmountPaymentPen"]) ? 0 : decimal.Parse(row["AmountPaymentPen"]);
                _vE_Payment.amountTotal = string.IsNullOrEmpty(row["AmountTotal"]) ? 0 : decimal.Parse(row["AmountTotal"]);
                _vE_Payment.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                _vE_Payment.bankAccountNumber = row["BankAccountNumber"];
                _vE_Payment.bankId = string.IsNullOrEmpty(row["BankId"]) ? 0 : int.Parse(row["BankId"]);
                _vE_Payment.companyCode = row["CompanyCode"];
                _vE_Payment.createdBy = row["CreatedBy"];
                _vE_Payment.currency = row["Currency"];
                _vE_Payment.currencyPayment = row["CurrencyPayment"];
                _vE_Payment.customerBankAccountPen = row["CustomerBankAccountPen"];
                _vE_Payment.customerBankAccountUsd = row["CustomerBankAccountUsd"];
                _vE_Payment.customerName = row["CustomerName"];
                _vE_Payment.customerRuc = row["CustomerRuc"];
                _vE_Payment.documentDate = string.IsNullOrEmpty(row["DocumentDate"]) ? DateTime.MinValue : DateTime.Parse(row["DocumentDate"]);
                _vE_Payment.documentDateFormat = _vE_Payment.documentDate.ToShortDateString();
                _vE_Payment.documentId = row["DocumentId"];
                _vE_Payment.dueDate = string.IsNullOrEmpty(row["DueDate"]) ? DateTime.MinValue : DateTime.Parse(row["DueDate"]);
                _vE_Payment.dueDateFormat = _vE_Payment.dueDate.ToShortDateString();
                _vE_Payment.exchangeRate = row["ExchangeRate"];
                _vE_Payment.id = row["InvoiceId"];
                _vE_Payment.paymentAuthId = string.IsNullOrEmpty(row["PaymentAuthId"]) ? 0 : long.Parse(row["PaymentAuthId"]);
                _vE_Payment.customerEmail = row["CustomerEmail"];
                _vE_Payment.documentType = row["DocumentType"];
                _vE_Payment.customerBankAccountDetraction = row["CustomerBankAccountDetraction"];
                _vE_Payment.nroComprobante = row["NroComprobante"];
                _vE_Payment.nroSerie = row["NroSerie"];
                _vE_Payment.tipoServicio = row["TipoServicio"];
                _vE_Payment.customerDocType = row["CustomerDocType"];
                _vE_Payment.accounting = row["Accounting"];
                _vE_Payment.amountDetractionUS = string.IsNullOrEmpty(row["AmountDetractionUS"]) ? 0 : decimal.Parse(row["AmountDetractionUS"]);
                _vE_Payment.reference = row["Reference"];
                _vE_Payment.paymentStatusId = string.IsNullOrEmpty(row["PaymentStatusId"]) ? 0 : int.Parse(row["PaymentStatusId"]) ;
                _vE_Payment.paymentMethodId = string.IsNullOrEmpty(row["PaymentMethodId"]) ? 0 : int.Parse(row["PaymentMethodId"]) ;
                _lstPayment.Add(_vE_Payment);
            }


            return _lstPayment;
        }


        public VE_Payment updatePaymentGeneral(VE_Payment _vE_Payment)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_paymentId", _vE_Payment.paymentId);
            parameters.Add("_amountBalance", _vE_Payment.amountBalance);
            parameters.Add("_amountDetraction", _vE_Payment.amountDetraction);
            parameters.Add("_amountPayment", _vE_Payment.amountPayment);
            parameters.Add("_amountPaymentDetraction", _vE_Payment.amountPaymentDetraction);
            parameters.Add("_amountPaymentFromBank", _vE_Payment.amountPaymentFromBank);
            parameters.Add("_amountPaymentPen", _vE_Payment.amountPaymentPen);
            parameters.Add("_amountTotal", _vE_Payment.amountTotal);
            parameters.Add("_bankAccountId", (_vE_Payment.bankAccountId == 0) ? DBNull.Value : (object)_vE_Payment.bankAccountId);
            parameters.Add("_bankAccountNumber", _vE_Payment.bankAccountNumber);
            parameters.Add("_bankId", ((_vE_Payment.bankId == 0) ? DBNull.Value : (object)_vE_Payment.bankId));
            parameters.Add("_companyCode", _vE_Payment.companyCode);
            parameters.Add("_currency", _vE_Payment.currency);
            parameters.Add("_currencyPayment", _vE_Payment.currencyPayment);
            parameters.Add("_customerBankAccountPen", _vE_Payment.customerBankAccountPen);
            parameters.Add("_customerBankAccountUsd", _vE_Payment.customerBankAccountUsd);
            parameters.Add("_customerName", _vE_Payment.customerName);
            parameters.Add("_customerRuc", _vE_Payment.customerRuc);
            parameters.Add("_documentDate", _vE_Payment.documentDate);
            parameters.Add("_documentId", _vE_Payment.documentId);
            parameters.Add("_dueDate", _vE_Payment.dueDate);
            parameters.Add("_exchangeRate", _vE_Payment.exchangeRate);
            parameters.Add("_invoiceId", _vE_Payment.id);
            parameters.Add("_paymentAuthId", ((_vE_Payment.paymentAuthId == 0) ? DBNull.Value : (object)_vE_Payment.paymentAuthId));
            parameters.Add("_customerEmail", _vE_Payment.customerEmail);
            parameters.Add("_documentType", _vE_Payment.documentType);
            parameters.Add("_customerBankAccountDetraction", _vE_Payment.customerBankAccountDetraction);
            parameters.Add("_nroComprobante", _vE_Payment.nroComprobante);
            parameters.Add("_nroSerie", _vE_Payment.nroSerie);
            parameters.Add("_tipoServicio", _vE_Payment.tipoServicio);
            parameters.Add("_customerDocType", _vE_Payment.customerDocType);
            parameters.Add("_accounting", _vE_Payment.accounting);
            parameters.Add("_amountDetractionUS", _vE_Payment.amountDetractionUS);
            parameters.Add("_reference", _vE_Payment.reference);
            parameters.Add("_paymentStatusId", ((_vE_Payment.paymentStatusId == 0) ? DBNull.Value : (object)_vE_Payment.paymentStatusId));
            parameters.Add("_paymentMethodId", ((_vE_Payment.paymentMethodId == 0) ? DBNull.Value : (object)_vE_Payment.paymentMethodId));




            filasAfectadas = _database.ExecuteSP("spu_updatePaymentGeneral", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _vE_Payment;

            }
            return null;
        }

        public string UpdatePaymentAuthStatus(int _status, int paymentAuthId )
        {
            List<VE_Invoice> _lstInvoices = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_status", _status);
            parameters.Add("_paymentAuthId", paymentAuthId);

            try
            {
                var response = _database.QuerySP("sp_updatePaymentAuthStatus", parameters);
                return "Transacción exitosa";
            }
            catch
            {
                return "Error en la transacción";
            }
            
        }

        /*
        public List<VE_Invoice> GetInvoiceSummary(string companyCode, string invoiceType, string _invoiceStatusIdList, string _companyCodeTarget)
        {
            VE_Invoice _veInvoice = null;
            List<VE_Invoice> _lstInvoices = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_companyCode", (string.IsNullOrWhiteSpace(companyCode) ? DBNull.Value : (object)companyCode));
            parameters.Add("_paymentAuthStatusIdList", (string.IsNullOrWhiteSpace(_invoiceStatusIdList) ? DBNull.Value : (object)_invoiceStatusIdList));


            var rows = _database.QuerySP("sp_getPaymentAuthSummary", parameters);
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
        */


        public bool CreatePaymentDetail(BE_PaymentDetail bE_PaymentDetail)
        {
            List<VE_Invoice> _lstInvoices = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("_idPayment", bE_PaymentDetail.idPayment);
            parameters.Add("_idInvoice", bE_PaymentDetail.idInvoice);
            parameters.Add("_Amount", bE_PaymentDetail.amount);

            var response = _database.ExecuteSP("sp_createPaymentDetail", parameters);
            if (response > 0)
            {
                return true;
            }
            return false;
            
        }
    }
}
