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
using SUIT.Security.DA;

namespace SUIT.Pago.DA
{
    public class DA_Bank
    {
        public MySQLDatabase _database { get; set; }// = new MySQLDatabase("pagosapp");


        /// <summary>
        /// Constructor that takes a MySQLDatabase instance 
        /// </summary>
        /// <param name="database"></param>
        public DA_Bank(MySQLDatabase database)
        {
            _database = database;
        }

        public List<VE_Bank> getCompanyBankBalance(string companyCode)
        {
            VE_Bank _veBank = null;
            List <VE_Bank> _lstBank = new List<VE_Bank>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_companyCode", companyCode } };

            var rows = _database.QuerySP("sps_obtenerBalanceBanco", parameters);
            foreach (var row in rows)
            {
                _veBank = new VE_Bank();
                _veBank.bankId = string.IsNullOrEmpty(row["id"]) ? 0 : int.Parse(row["id"]);
                _veBank.bankShortName = row["BankShortName"];
                _veBank.currency = row["Currency"];
                _veBank.balance = row["Balance"];
                _veBank.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                _veBank.accountNumber = row["AccountNumber"];
                _lstBank.Add(_veBank);
            }

            return _lstBank;
        }

        public List<VE_Bank> getCompanyBankBalanceDetail(string companyCode)
        {
            VE_Bank _veBank = null;
            List<VE_Bank> _lstBank = new List<VE_Bank>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_companyCode", companyCode } };

            var rows = _database.QuerySP("sps_obtenerBalanceBanco", parameters);
            foreach (var row in rows)
            {
                _veBank = new VE_Bank();
                _veBank.bankId = string.IsNullOrEmpty(row["id"]) ? 0 : int.Parse(row["id"]);
                _veBank.bankInterCode = row["BankInterCode"];
                _veBank.bankName = row["BankName"];
                _veBank.bankShortName = row["BankShortName"];
                _veBank.accountNumber = row["AccountNumber"];
                _veBank.currency = row["Currency"];
                _veBank.status = row["Status"];
                _veBank.balance = row["Balance"];
                _veBank.accounting = row["Accounting"];
                _veBank.cash = row["Cash"];
                _lstBank.Add(_veBank);
            }

            return _lstBank;
        }

        public BE_Bank getBankById(int bankId)
        {
            BE_Bank _veBank = null;
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_bankId", bankId } };

            var rows = _database.QuerySP("sps_getBankById", parameters);
            foreach (var row in rows)
            {
                _veBank = new BE_Bank();
                _veBank.bankId = string.IsNullOrEmpty(row["Id"]) ? 0 : int.Parse(row["Id"]);
                _veBank.bankInterCode = row["BankInterCode"];
                _veBank.bankShortName = row["BankShortName"];
                _veBank.bankName = row["BankName"];
                _veBank.bankMasterId = row["BankMasterId"];
            }

            return _veBank;
        }

        public BE_BankAccount getBankAccountById(int bankAccountId)
        {
            BE_BankAccount _veBank = null;
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_bankAccountId", bankAccountId } };

            var rows = _database.QuerySP("sps_getBankAccountById", parameters);
            foreach (var row in rows)
            {
                _veBank = new BE_BankAccount();
                _veBank.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                _veBank.bankId = string.IsNullOrEmpty(row["Id"]) ? 0 : int.Parse(row["Id"]);
                _veBank.accountNumber = row["AccountNumber"];
                _veBank.currency = row["Currency"];
                _veBank.status = row["Status"] == bool.TrueString ? true : false;
                _veBank.balance = string.IsNullOrEmpty(row["Balance"]) ? 0 : Decimal.Parse(row["Balance"]);
                _veBank.companyCode = row["CompanyCode"];
                _veBank.AccountNumberCCI = row["AccountNumberCCI"];
                _veBank.AccountType = row["AccountType"];
            }

            return _veBank;
        }

        public List<VE_Bank> getBankAccountByAuthId(int paymentAuthId)
        {
            VE_Bank _beBank = null;
            List<VE_Bank> _lstBankAccount = new List<VE_Bank>();
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "_paymentAuthId", paymentAuthId } };

            var rows = _database.QuerySP("sps_getBankAccountByAuthId", parameters);
            foreach (var row in rows)
            {
                _beBank = new VE_Bank();
                _beBank.bankId = string.IsNullOrEmpty(row["BankId"]) ? 0 : int.Parse(row["BankId"]);
                _beBank.paymentAuthId = string.IsNullOrEmpty(row["PaymentAuthId"]) ? 0 : int.Parse(row["PaymentAuthId"]);
                //  _beBank.companyCode = row["CompanyCode"];
                _beBank.bankShortName = row["BankShortName"];
                //   _beBank.currency = row["Currency"];
                //  _beBank.balance = row["Balance"];
                _beBank.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                _beBank.accountNumber = row["BankAccountNumber"];
                _lstBankAccount.Add(_beBank);
 
            }

            return _lstBankAccount;
        }

        public VE_BankAccount updateBankAccount(VE_BankAccount _VeBankAccount)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_idBankAccount", _VeBankAccount.bankAccountId);
            parameters.Add("_acountNumber", _VeBankAccount.accountNumber);
            parameters.Add("_bankId", _VeBankAccount.bankId);
            parameters.Add("_currency", _VeBankAccount.currency);
            parameters.Add("_status", _VeBankAccount.status);
            parameters.Add("_balance", _VeBankAccount.balance);
            parameters.Add("_accounting", _VeBankAccount.accounting);
            parameters.Add("_cash", _VeBankAccount.cash);
            parameters.Add("_userAudit", _VeBankAccount.userAudit);
            parameters.Add("_accountNumberCCI", _VeBankAccount.AccountNumberCCI);
            parameters.Add("_companyCode", _VeBankAccount.companyCode);
            parameters.Add("_accountType", _VeBankAccount.AccountType);

            filasAfectadas = _database.ExecuteSP("spu_updateBankAccount", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                
                return _VeBankAccount;

            }
            return null;
        }

        public List<BE_BankAccount> getBankAccount()
        {
            BE_BankAccount _BeBankAccount = null;
            List<BE_BankAccount> _lstBankAccount = new List<BE_BankAccount>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            var rows = _database.QuerySP("sps_getBankAccount", parameters);
            foreach (var row in rows)

            {
                _BeBankAccount = new BE_BankAccount();
                _BeBankAccount.bankAccountId = string.IsNullOrEmpty(row["Id"]) ? 0 : int.Parse(row["Id"]);
                _BeBankAccount.accountNumber = row["AccountNumber"];
                _BeBankAccount.bankId = string.IsNullOrEmpty(row["BankId"]) ? 0 : int.Parse(row["BankId"]);
                _BeBankAccount.currency = row["Currency"];
                _BeBankAccount.status = row["Status"] == bool.TrueString ? true : false;
                _BeBankAccount.balance = string.IsNullOrEmpty(row["Balance"]) ? 0 : decimal.Parse(row["Balance"]);
                _BeBankAccount.accounting = row["Accounting"];
                _BeBankAccount.cash = row["Cash"];
                _BeBankAccount.companyCode = row["CompanyCode"];
                _BeBankAccount.AccountNumberCCI = row["AccountNumberCCI"];
                _BeBankAccount.AccountType = row["AccountType"];
                _lstBankAccount.Add(_BeBankAccount);
            }
            return _lstBankAccount;
        }

        public List<VE_BankAccount> getBankAccountByCompanyCode(string CompanyCode)
        {
            VE_BankAccount _VeBankAccount = null;
            List<VE_BankAccount> _lstBankAccount = new List<VE_BankAccount>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_companyCode", CompanyCode);


            var rows = _database.QuerySP("sps_getBankAccountByCompanyCode", parameters);
            foreach (var row in rows)

            {
                _VeBankAccount = new VE_BankAccount();
                _VeBankAccount.bankAccountId = string.IsNullOrEmpty(row["BankAccountId"]) ? 0 : int.Parse(row["BankAccountId"]);
                _VeBankAccount.accountNumber = row["AccountNumber"];
                _VeBankAccount.bankId = string.IsNullOrEmpty(row["BankId"]) ? 0 : int.Parse(row["BankId"]);
                _VeBankAccount.currency = row["Currency"];
                _VeBankAccount.status = string.IsNullOrEmpty(row["Status"]) ? false : row["Status"].Equals("1") ? true : false;
                _VeBankAccount.balance = string.IsNullOrEmpty(row["Balance"]) ? 0 : decimal.Parse(row["Balance"]);
                _VeBankAccount.accounting = row["Accounting"];
                _VeBankAccount.cash = row["Cash"];
                _VeBankAccount.companyCode = row["CompanyCode"];
                _VeBankAccount.AccountNumberCCI = row["AccountNumberCCI"];
                _VeBankAccount.AccountType = row["AccountType"];
                _VeBankAccount.bankShortName = row["BankShortName"];
                _VeBankAccount.companyName = row["CompanyName"];
                _lstBankAccount.Add(_VeBankAccount);
            }
            return _lstBankAccount;
        }

        public VE_BankAccount createBankAccount(VE_BankAccount _VeBankAccount)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_acountNumber", _VeBankAccount.accountNumber);
            parameters.Add("_bankId", _VeBankAccount.bankId);
            parameters.Add("_currency", _VeBankAccount.currency);
            parameters.Add("_status", _VeBankAccount.status);
            parameters.Add("_balance", _VeBankAccount.balance);
            parameters.Add("_accounting", _VeBankAccount.accounting);
            parameters.Add("_cash", _VeBankAccount.cash);
            parameters.Add("_userAudit", _VeBankAccount.userAudit);
            parameters.Add("_accountNumberCCI", _VeBankAccount.AccountNumberCCI);
            parameters.Add("_companyCode", _VeBankAccount.companyCode);
            parameters.Add("_accountType", _VeBankAccount.AccountType);

            filasAfectadas = _database.ExecuteSP("spi_insertBankAccount", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _VeBankAccount;

            }
            return null;
        }

        public VE_BankAccount deleteBankAccount(VE_BankAccount _VeBankAccount)
        {
            

            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_idBankAccount", _VeBankAccount.bankAccountId);
            parameters.Add("_userAudit", _VeBankAccount.userAudit);


            filasAfectadas = _database.ExecuteSP("spd_deleteBankAccount", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _VeBankAccount;

            }
            return null;
        }

        public List<BE_Bank> getBank()
        {
            BE_Bank _BeBank = null;
            List<BE_Bank> _lstBank = new List<BE_Bank>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            var rows = _database.QuerySP("sps_getBank", parameters);
            foreach (var row in rows)
            {
                _BeBank = new BE_Bank();
                _BeBank.bankId = string.IsNullOrEmpty(row["Id"]) ? 0 : int.Parse(row["Id"]);
                _BeBank.bankInterCode = row["BankInterCode"];
                _BeBank.bankName = row["BankName"];
                _BeBank.bankShortName = row["BankShortName"];
                _BeBank.bankMasterId = row["BankMasterId"];
                _BeBank.isEnabled = string.IsNullOrEmpty(row["IsEnabled"]) ? false : row["IsEnabled"].Equals("1") ? true : false;
                _lstBank.Add(_BeBank);

            }
            return _lstBank;
        }

        public List<BE_BankMaster> getBankMaster()
        {
            BE_BankMaster _BeBankMaster = null;
            List<BE_BankMaster> _lstBankMaster = new List<BE_BankMaster>();
            Dictionary<string,object> parameters= new Dictionary<string, object>();
            var rows = _database.QuerySP("sps_getBankMaster", parameters);
            foreach(var row in rows)
            {
                _BeBankMaster = new BE_BankMaster();
                _BeBankMaster.bankMasterId = string.IsNullOrEmpty(row["Id"]) ? 0 : int.Parse(row["Id"]);
                _BeBankMaster.description = row["Description"];
                _lstBankMaster.Add(_BeBankMaster);
            }
            return _lstBankMaster;
        }

        public VE_Bank updateBank(VE_Bank _VeBank)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id", _VeBank.bankId);
            parameters.Add("_bankInterCode", _VeBank.bankInterCode);
            parameters.Add("_bankName", _VeBank.bankName);
            parameters.Add("_bankShortName", _VeBank.bankShortName);
            parameters.Add("_bankMasterId", _VeBank.bankMasterId);
            parameters.Add("_isEnabled", _VeBank.isEnabled);
            parameters.Add("_userAudit", _VeBank.userAudit);


            filasAfectadas = _database.ExecuteSP("spu_updateBank", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                
                return _VeBank;

            }
            return null;
        }
        public BE_BankMaster updateBankMaster(BE_BankMaster _BeBankMaster)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id", _BeBankMaster.bankMasterId);
            parameters.Add("_description", _BeBankMaster.description);
            parameters.Add("_userAudit", _BeBankMaster.userAudit);

            filasAfectadas = _database.ExecuteSP("spu_updateBankMaster", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
              
                return _BeBankMaster;

            }
            return null;
        }

        public VE_Bank createBank(VE_Bank _VeBank)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id", _VeBank.bankId);
            parameters.Add("_bankInterCode", _VeBank.bankInterCode);
            parameters.Add("_bankName", _VeBank.bankName);
            parameters.Add("_bankShortName", _VeBank.bankShortName);
            parameters.Add("_bankMasterId", _VeBank.bankMasterId);
            parameters.Add("_isEnabled", _VeBank.isEnabled);
            parameters.Add("_userAudit", _VeBank.userAudit);
            
            filasAfectadas = _database.ExecuteSP("spi_insertBank", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _VeBank;

            }
            return null;
        }

        public BE_BankMaster createBankMaster(BE_BankMaster _BeBankMaster)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id", _BeBankMaster.bankMasterId);
            parameters.Add("_description", _BeBankMaster.description);
            parameters.Add("_userAudit", _BeBankMaster.userAudit);
            
            filasAfectadas = _database.ExecuteSP("spi_insertBankMaster", parameters);

            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _BeBankMaster;

            }
            return null;
        }

        public VE_Bank deleteBank(VE_Bank _VeBank)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id", _VeBank.bankId);
            parameters.Add("_isEnabled", _VeBank.isEnabled);
            parameters.Add("_userAudit", _VeBank.userAudit);
            
            filasAfectadas = _database.ExecuteSP("spd_deleteBank", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                return _VeBank;

            }
            return null;
        }

        public BE_BankMaster deleteBankMaster(BE_BankMaster _BeBankMaster)
        {
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_id", _BeBankMaster.bankMasterId);
            



            filasAfectadas = _database.ExecuteSP("spd_deleteBankMaster", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {
                
                return _BeBankMaster;

            }
            return null;
        }
        public VE_BankAccount updateBalanceBankAccount(int paymentAuthId)
        {
            VE_BankAccount _VeBankAccount = null;
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_PaymentAuthId", paymentAuthId);

            filasAfectadas = _database.ExecuteSP("spu_UpdateBalanceBankAccount", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {

                return _VeBankAccount;

            }
            return null;
        }

        public VE_BankAccount updateBalanceBankAccountByInvoice(int invoiceId, Int64 bankAccount)
        {
            VE_BankAccount _VeBankAccount = null;
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_InvoiceId", invoiceId);
            parameters.Add("_BankAccountId", bankAccount);

            filasAfectadas = _database.ExecuteSP("spu_UpdateBalanceBankAccountByInvoice", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {

                return _VeBankAccount;

            }
            return null;
        }

        public VE_BankAccount updateBalanceBankAccountByPayment(int paymentId, Int64 bankAccount)
        {
            VE_BankAccount _VeBankAccount = null;
            int filasAfectadas = 0;
            string strError_Mensaje = string.Empty;
            bool boResultado = false;
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_PaymentId", paymentId);
            parameters.Add("_BankAccountId", bankAccount);

            filasAfectadas = _database.ExecuteSP("sp_UpdateBalanceBankAccountByPayment", parameters);
            boResultado = (filasAfectadas > 0);
            if (boResultado)
            {

                return _VeBankAccount;

            }
            return null;
        }

        public List<VE_Invoice> GetBankAdjusmentHistory(int bankAccountId)
        {
            VE_Invoice _VeInvoice = null;
            List<VE_Invoice> _lstInvoice = new List<VE_Invoice>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();


            parameters.Add("_bankAccountId", bankAccountId);


            var rows = _database.QuerySP("sp_getBankAdjusmentHistory", parameters);
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
    }
}
