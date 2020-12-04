using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT.BE;
using SUIT.Pago.BE;
using SUIT.Pago.DA;
using SUIT.Security.DA;

namespace SUIT.Pago.BL
{
    public class BL_Bank
    {
        public MySQLDatabase _database;
        public string connectionString;

        public List<VE_Bank> GetCompanyBankBalance(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).getCompanyBankBalance(companyCode);
        }

        public BE_Bank GetBankById(int bankId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).getBankById(bankId);
        }

        public BE_BankAccount GetBankAccountById(int bankAccountId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).getBankAccountById(bankAccountId);
        }

        public List<VE_Bank> GetBankAccountByPaymentAuthId(int bankAccountId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).getBankAccountByAuthId(bankAccountId);
        }

        public VE_BankAccount UpdateBankAccount(VE_BankAccount _VeBankAccount)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).updateBankAccount(_VeBankAccount);
        }

        public VE_Bank UpdateBank(VE_Bank _VeBank)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).updateBank(_VeBank);
        }

        public BE_BankMaster UpdateBankMaster(BE_BankMaster _BeBankMaster)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).updateBankMaster(_BeBankMaster);
        }

        public List<BE_BankAccount> GetBankAccount()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).getBankAccount();
        }

        public List<VE_BankAccount> getBankAccountByCompanyCode(string CompanyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).getBankAccountByCompanyCode(CompanyCode);
        }

        public List<BE_Bank> GetBank()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).getBank();
        }

        public List<BE_BankMaster> GetBankMaster()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).getBankMaster();
        }

        public VE_BankAccount CreateBankAccount(VE_BankAccount _VeBankAccount)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).createBankAccount(_VeBankAccount);
        }

        public VE_Bank CreateBank(VE_Bank _VeBank)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).createBank(_VeBank);
        }

        public BE_BankMaster CreateBankMaster(BE_BankMaster _BeBankMaster)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).createBankMaster(_BeBankMaster);
        }

        public VE_BankAccount DeleteBankAccount(VE_BankAccount _VeBankAccount)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).deleteBankAccount(_VeBankAccount);
        }

        public VE_Bank DeleteBank(VE_Bank _VeBank)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).deleteBank(_VeBank);
        }

        public BE_BankMaster DeleteBankMaster(BE_BankMaster _BeBankMaster)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).deleteBankMaster(_BeBankMaster);
        }
        public VE_BankAccount UpdateBalanceBankAccount(int paymentAuthId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).updateBalanceBankAccount(paymentAuthId);
        }

        public VE_BankAccount updateBalanceBankAccountByInvoice(int invoiceId, Int64 bankAccount)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).updateBalanceBankAccountByInvoice(invoiceId, bankAccount);
        }

        public VE_BankAccount updateBalanceBankAccountByPayment(int paymentId, Int64 bankAccount)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).updateBalanceBankAccountByPayment(paymentId,bankAccount);
        }

        public VE_BankAccount BankAdjustment(VE_Invoice vE_Invoice)
        {
            vE_Invoice.invoiceDetail = new List<VE_InvoiceDetail>();
            if (vE_Invoice.amountTotal < 0)
            {
                vE_Invoice.amountTotal = vE_Invoice.amountTotal * -1;
                vE_Invoice.invoiceType = "O";
            }
            else
            {
                vE_Invoice.invoiceType = "S";
            }
            BL_Invoice bL_Invoice = new BL_Invoice();
            bL_Invoice.connectionString = connectionString;
            var invoice = bL_Invoice.CreateInvoice(vE_Invoice);

            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).updateBalanceBankAccountByInvoice(int.Parse(invoice.invoiceId), invoice.bankAccountId);
        }


        public List<VE_Invoice> GetBankAdjusmentHistory(int bankAccountId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Bank(_database).GetBankAdjusmentHistory(bankAccountId);
        }
    }
}
