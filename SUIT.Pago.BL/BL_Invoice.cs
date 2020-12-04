using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT.BE;
using SUIT.Pago.BE;
using SUIT.Pago.BE.n.Filters;
using SUIT.Pago.DA;
using SUIT.Security.BE;
using SUIT.Security.BE.Filters;
using SUIT.Security.BL;
using SUIT.Security.DA;

namespace SUIT.Pago.BL
{
    public class BL_Invoice
    {
        public MySQLDatabase _database;
        public string connectionString;


        public List<BE_Invoice> GetUnpaidCompanyInvoices(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).getUnpaidCompanyInvoices(companyCode);
        }

        public List<VE_Invoice> GetUnpaidCompanyInvoicesBalance(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).getUnpaidCompanyInvoicesBalance(companyCode);
        }

        public List<VE_Invoice> GetUnpaidCompanyInvoicesResume(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).getUnpaidCompanyInvoicesResume(companyCode);
        }

        public List<VE_Invoice> GetUnpaidCompanyInvoicesResumeDetail(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).getUnpaidCompanyInvoicesResumeDetail(companyCode);
        }

        /*public List<BE_Invoice> MakePayments(List<VE_Invoice> _lstVeInvoice)
        {
            _database = new MySQLDatabase(connectionString);
            if (_lstVeInvoice.Count == 0)
            {
                throw new Exception("La lista enviada no contiene elementos");
            }

            List<BE_Invoice> _lstBeInvoice = new List<BE_Invoice>();
            BE_PaymentAuth _paymentAuth = new BE_PaymentAuth();
            BE_Payment _payment = new BE_Payment();
            BE_PaymentAuthDetail _paymentAuthDetail = new BE_PaymentAuthDetail();
            BL_WorkFlow _blWorkFlow = new BL_WorkFlow();
            BL_Usuario bL_Usuario = new BL_Usuario();
            bL_Usuario.connectionString = connectionString;
            List<BE_User> bE_Users = new List<BE_User>();

            foreach (VE_Invoice _veInvoice in _lstVeInvoice)
            {
                _lstBeInvoice.AddRange(new DA_Invoice(_database).getInvoiceToPayBySum(_veInvoice));
                bE_Users.AddRange(bL_Usuario.GetUserGeneral(new BE_UserFilter { id = _veInvoice.userId }));
            }

            if (_lstBeInvoice.Count > 0)
            {
                foreach (BE_Invoice _beInvoice in _lstBeInvoice)
                {
                    _blWorkFlow = new BL_WorkFlow();
                    _blWorkFlow.connectionString = connectionString;
                    var mensaje = "";
                    bool bOk = _blWorkFlow.NextWorkFlowStep(ref mensaje, 2, int.Parse(_beInvoice.invoiceId), bE_Users[0].userName, false);

                    if (!bOk)
                    {
                        throw new Exception(mensaje);

                    }
                }

                foreach (BE_Invoice _beInvoice in _lstBeInvoice)
                {
                    _paymentAuth.amountPaid += _beInvoice.amountBalance;
                    _paymentAuth.amountPaidPen += _beInvoice.amountPaymentPen;
                    _paymentAuth.amountDetractionPaid += _beInvoice.amountPaymentDetraction;
                }

                _paymentAuth.bankAccountId = _lstVeInvoice[0].bankAccountId;
                _paymentAuth.companyCode = _lstVeInvoice[0].companyCode;
                _paymentAuth.exchangeRate = _lstBeInvoice[0].exchangeRate == null ? 0 : decimal.Parse(_lstBeInvoice[0].exchangeRate);
                _paymentAuth = new DA_Payment(_database).createPaymentAuth(_paymentAuth);

                foreach (BE_Invoice _beInvoice in _lstBeInvoice)
                {
                    _beInvoice.bankId = _lstVeInvoice[0].bankId;
                    _beInvoice.bankAccountId = _lstVeInvoice[0].bankAccountId;
                    _beInvoice.bankAccountNumber = _lstVeInvoice[0].bankAccountNumber;
                    new DA_Invoice(_database).payInvovice(_beInvoice);

                    _payment = new BE_Payment();
                    _payment.paymentAuthId = _paymentAuth.paymentAuthId;
                    _payment.id = _beInvoice.invoiceId;
                    _payment.bankId = _lstVeInvoice[0].bankId;
                    _payment.bankAccountId = _lstVeInvoice[0].bankAccountId;
                    _payment.bankAccountNumber = _lstVeInvoice[0].bankAccountNumber;

                    _payment = new DA_Payment(_database).createPayment(_payment);

                    new DA_Bank(_database).updateBalanceBankAccountAmountTotal(int.Parse(_beInvoice.invoiceId), _lstVeInvoice[0].bankAccountId);

                }

            }
            if (_lstBeInvoice.Count > 0 && _payment != null && _paymentAuth != null)
                    return _lstBeInvoice;
                else
                    throw new Exception("Ocurrió un error al realizar la transacción");
                
            
        }*/

        public List<BE_Invoice> MakePayments(List<VE_Invoice> _lstVeInvoice)
        {
            _database = new MySQLDatabase(connectionString);
            if (_lstVeInvoice.Count == 0)
            {
                throw new Exception("La lista enviada no contiene elementos");
            }

            List<BE_Invoice> _lstBeInvoice = new List<BE_Invoice>();

            List<BE_PaymentAuth> _lstPaymentAuth = new List<BE_PaymentAuth>();
            List<BE_PaymentAuth> _lstPaymentAuthAux = new List<BE_PaymentAuth>();
            BE_Payment _payment = new BE_Payment();
            BE_PaymentAuthDetail _paymentAuthDetail = new BE_PaymentAuthDetail();
            BL_WorkFlow _blWorkFlow = new BL_WorkFlow();
            BL_Usuario bL_Usuario = new BL_Usuario();
            bL_Usuario.connectionString = connectionString;
            List<BE_User> bE_Users = new List<BE_User>();

            foreach (VE_Invoice _veInvoice in _lstVeInvoice)
            {
                _lstBeInvoice.AddRange(new DA_Invoice(_database).getInvoiceToPayBySum(_veInvoice));
                bE_Users.AddRange(bL_Usuario.GetUserGeneral(new BE_UserFilter { id = _veInvoice.userId }));
            }

            if (_lstBeInvoice.Count > 0)
            {
                foreach (BE_Invoice _beInvoice in _lstBeInvoice)
                {
                    _blWorkFlow = new BL_WorkFlow();
                    _blWorkFlow.connectionString = connectionString;
                    var mensaje = "";
                    bool bOk = _blWorkFlow.NextWorkFlowStep(ref mensaje, 2, int.Parse(_beInvoice.invoiceId), bE_Users[0].userName, false);

                    if (!bOk)
                    {
                        throw new Exception(mensaje);

                    }
                }
                foreach (VE_Invoice _veInvoice in _lstVeInvoice)
                {
                    if (_lstPaymentAuth.Count() == 0)
                    {
                        BE_PaymentAuth _PaymentAuth = new BE_PaymentAuth();
                        _PaymentAuth.bankAccountId = _veInvoice.bankAccountId;
                        _PaymentAuth.companyCode = _veInvoice.companyCode;
                        //_PaymentAuth.userName = _veInvoice.userName;
                        _PaymentAuth.userName = "";
                        _PaymentAuth.memoryRuc = _veInvoice.customerRuc;
                        _PaymentAuth.exchangeRate = _veInvoice.exchangeRate == null ? 0 : decimal.Parse(_lstVeInvoice[0].exchangeRate);
                        _lstPaymentAuthAux.Add(_PaymentAuth);
                        _lstPaymentAuth.AddRange(_lstPaymentAuthAux);
                    }
                    else
                    {
                        var cont = 0;
                        foreach (BE_PaymentAuth bE_PaymentAuth in _lstPaymentAuth)
                        {
                            cont++;
                            if ((bE_PaymentAuth.bankAccountId != _veInvoice.bankAccountId || !bE_PaymentAuth.memoryRuc.Equals(_veInvoice.customerRuc)) && cont == _lstPaymentAuth.Count())
                            {
                                BE_PaymentAuth _PaymentAuth = new BE_PaymentAuth();
                                _PaymentAuth.bankAccountId = _veInvoice.bankAccountId;
                                _PaymentAuth.companyCode = _veInvoice.companyCode;
                                //_PaymentAuth.userName = _veInvoice.userName;
                                _PaymentAuth.userName = "";
                                _PaymentAuth.memoryRuc = _veInvoice.customerRuc;
                                _PaymentAuth.exchangeRate = _veInvoice.exchangeRate == null ? 0 : decimal.Parse(_lstVeInvoice[0].exchangeRate);
                                _lstPaymentAuthAux.Add(_PaymentAuth);
                            }
                        }
                        _lstPaymentAuth = new List<BE_PaymentAuth>();
                        _lstPaymentAuth.AddRange(_lstPaymentAuthAux);
                    }

                }


                _lstPaymentAuthAux = new List<BE_PaymentAuth>();
                foreach (BE_PaymentAuth bE_PaymentAuth in _lstPaymentAuth)
                {
                    var aux = new DA_Payment(_database).createPaymentAuth(bE_PaymentAuth);

                    _lstPaymentAuthAux.Add(aux);

                }
                _lstPaymentAuth = new List<BE_PaymentAuth>();
                _lstPaymentAuth.AddRange(_lstPaymentAuthAux);

                foreach (BE_Invoice _beInvoice in _lstBeInvoice)
                {
                    foreach (BE_PaymentAuth bE_PaymentAuth in _lstPaymentAuth)
                    {
                        if (bE_PaymentAuth.bankAccountId == _beInvoice.bankAccountId)
                        {


                            _beInvoice.bankId = _lstVeInvoice[0].bankId;
                            _beInvoice.bankAccountId = _lstVeInvoice[0].bankAccountId;
                            _beInvoice.bankAccountNumber = _lstVeInvoice[0].bankAccountNumber;
                            new DA_Invoice(_database).payInvovice(_beInvoice);

                            _payment = new BE_Payment();
                            _payment.paymentAuthId = bE_PaymentAuth.paymentAuthId;
                            _payment.id = _beInvoice.invoiceId;
                            _payment.bankId = _lstVeInvoice[0].bankId;
                            _payment.bankAccountId = _lstVeInvoice[0].bankAccountId;
                            _payment.bankAccountNumber = _lstVeInvoice[0].bankAccountNumber;

                            _payment = new DA_Payment(_database).createPayment(_payment);

                            

                            new DA_Bank(_database).updateBalanceBankAccountByInvoice(int.Parse(_beInvoice.invoiceId), _lstVeInvoice[0].bankAccountId);

                            _paymentAuthDetail = new BE_PaymentAuthDetail();
                            _paymentAuthDetail.paymentAuthId = bE_PaymentAuth.paymentAuthId;
                            //_paymentAuthDetail.userAudit = _veInvoice.userName;
                            _paymentAuthDetail.userAudit = "";
                            _paymentAuthDetail = new DA_Payment(_database).createFirstPAD(_paymentAuthDetail);
                        }
                    }
                }

            }
            if (_lstBeInvoice.Count > 0 && _payment != null && _lstPaymentAuth != null)
                return _lstBeInvoice;
            else
                throw new Exception("Ocurrió un error al realizar la transacción");


        }

        public List<BE_Invoice> MakePaymentsDetails(List<VE_Invoice> _lstVeInvoice)
        {
            _database = new MySQLDatabase(connectionString);
            List<BE_Invoice> _lstBeInvoice = new List<BE_Invoice>();
            List<BE_PaymentAuth> _lstPaymentAuth = new List<BE_PaymentAuth>();
            List<BE_PaymentAuth> _lstPaymentAuthAux = new List<BE_PaymentAuth>();
            BE_Payment _payment = new BE_Payment();
            BE_Invoice _beInvoice = new BE_Invoice();
            BE_PaymentAuthDetail _paymentAuthDetail = new BE_PaymentAuthDetail();

            BL_WorkFlow _blWorkFlow = new BL_WorkFlow();
            _blWorkFlow.connectionString = connectionString;


            foreach (VE_Invoice _veInvoice in _lstVeInvoice)
            {
                _blWorkFlow = new BL_WorkFlow();
                _blWorkFlow.connectionString = connectionString;
                var mensaje = "";
                bool bOk = _blWorkFlow.NextWorkFlowStep(ref mensaje, 2, int.Parse(_veInvoice.invoiceId), _veInvoice.userName, false);
                //bool bOk = _blWorkFlow.NextWorkFlowStep(ref mensaje, 2, int.Parse(_veInvoice.invoiceId), "marko.polo", false);

                if (!bOk)
                {
                    throw new Exception(mensaje);

                }
            }

            foreach (VE_Invoice _veInvoice in _lstVeInvoice)
            {
                if (_lstPaymentAuth.Count() == 0)
                {
                    BE_PaymentAuth _PaymentAuth = new BE_PaymentAuth();
                    _PaymentAuth.bankAccountId = _veInvoice.bankAccountId;
                    _PaymentAuth.companyCode = _veInvoice.companyCode;
                    _PaymentAuth.userName = _veInvoice.userName;
                    //_PaymentAuth.userName = "";
                    _PaymentAuth.exchangeRate = _veInvoice.exchangeRate == null ? 0 : decimal.Parse(_lstVeInvoice[0].exchangeRate);
                    _lstPaymentAuthAux.Add(_PaymentAuth);
                    _lstPaymentAuth.AddRange(_lstPaymentAuthAux);
                }
                else
                {
                    var cont = 0;
                    foreach (BE_PaymentAuth bE_PaymentAuth in _lstPaymentAuth)
                    {
                        cont++;
                        if (bE_PaymentAuth.bankAccountId != _veInvoice.bankAccountId && cont == _lstPaymentAuth.Count())
                        {
                            BE_PaymentAuth _PaymentAuth = new BE_PaymentAuth();
                            _PaymentAuth.bankAccountId = _veInvoice.bankAccountId;
                            _PaymentAuth.companyCode = _veInvoice.companyCode;
                            _PaymentAuth.userName = _veInvoice.userName;
                            //_PaymentAuth.userName = "";
                            _PaymentAuth.exchangeRate = _veInvoice.exchangeRate == null ? 0 : decimal.Parse(_lstVeInvoice[0].exchangeRate);
                            _lstPaymentAuthAux.Add(_PaymentAuth);
                        }
                    }
                    _lstPaymentAuth = new List<BE_PaymentAuth>();
                    _lstPaymentAuth.AddRange(_lstPaymentAuthAux);
                }
                
            }
            _lstPaymentAuthAux = new List<BE_PaymentAuth>();
            foreach (BE_PaymentAuth bE_PaymentAuth in _lstPaymentAuth)
            {
                var aux = new DA_Payment(_database).createPaymentAuth(bE_PaymentAuth);
                
                _lstPaymentAuthAux.Add(aux);

            }
            _lstPaymentAuth = new List<BE_PaymentAuth>();
            _lstPaymentAuth.AddRange(_lstPaymentAuthAux);

            foreach (VE_Invoice _veInvoice in _lstVeInvoice)
            {
                _beInvoice = GetInvoiceById(_veInvoice.invoiceId);
                _lstBeInvoice.Add(new DA_Invoice(_database).payInvoviceDetail(_veInvoice));

                var cont = 0;
                foreach (BE_PaymentAuth bE_PaymentAuth in _lstPaymentAuth)
                {   cont++;
                    if (bE_PaymentAuth.bankAccountId == _veInvoice.bankAccountId)
                    {
                        bE_PaymentAuth.amountPaid += _beInvoice.amountBalance;
                        bE_PaymentAuth.amountPaidPen += _beInvoice.amountPaymentPen;
                        bE_PaymentAuth.amountDetractionPaid += _beInvoice.amountPaymentDetraction;

                        _payment = new BE_Payment();
                        _payment.paymentAuthId = bE_PaymentAuth.paymentAuthId;
                        _payment.id = _veInvoice.invoiceId;
                        _payment.bankId = _veInvoice.bankId;
                        _payment.bankAccountId = _veInvoice.bankAccountId;
                        _payment.bankAccountNumber = _veInvoice.bankAccountNumber;
                        _payment.userName = _veInvoice.userName;
                        //_payment.userName = "";
                        _payment = new DA_Payment(_database).createPayment(_payment);


                        BE_PaymentDetail bE_PaymentDetail = new BE_PaymentDetail();
                        bE_PaymentDetail.idPayment = int.Parse(_payment.paymentId.ToString());
                        bE_PaymentDetail.idInvoice = int.Parse(_payment.id);
                        bE_PaymentDetail.amount = _beInvoice.amountTotal;

                        new DA_Payment(_database).CreatePaymentDetail(bE_PaymentDetail);
                        new DA_Bank(_database).updateBalanceBankAccountByInvoice(int.Parse(_beInvoice.invoiceId), _veInvoice.bankAccountId);

                        _paymentAuthDetail = new BE_PaymentAuthDetail();
                        _paymentAuthDetail.paymentAuthId = bE_PaymentAuth.paymentAuthId;
                        _paymentAuthDetail.userAudit = _veInvoice.userName;
                        //_paymentAuthDetail.userAudit = "";
                        _paymentAuthDetail = new DA_Payment(_database).createFirstPAD(_paymentAuthDetail);
                    }
                }

            }

            foreach (BE_PaymentAuth bE_PaymentAuth in _lstPaymentAuth)
            {
                var aux = new DA_Payment(_database).updatePaymentAuth(bE_PaymentAuth);
                _lstPaymentAuthAux = new List<BE_PaymentAuth>();
                _lstPaymentAuthAux.Add(aux);
            }
            _lstPaymentAuth = _lstPaymentAuthAux;
            if (_lstBeInvoice.Count > 0 && _payment != null && _lstPaymentAuth != null)
                return _lstBeInvoice;
            else
                throw new Exception("Ocurrió un error al realizar la transacción");


        }

        public BE_Invoice GetInvoiceById(string _invoiceId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).getInvoiceById(_invoiceId);
        }

        public List<VE_Invoice> GetInvoicesSummaryDetail(string companyCode, string providerRuc)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).getInvoicesSummaryDetail( companyCode,  providerRuc);
        }

        public List<VE_Invoice> GetInvoice()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).getInvoice();
        }

        public VE_Invoice CreateInvoice(VE_Invoice _VeInvoice)
        {
            string invoiceId;
            _database = new MySQLDatabase(connectionString);

            var companysSystem = (new BL_Company() { connectionString = connectionString }).GetCompanyGeneral(new BECompanyFilter() { companyCode = _VeInvoice.companyCode });

            BE_Company _companySystem = null;

            if (companysSystem.Count > 0)
            {
                _companySystem = companysSystem[0];
            }
            else
            {
                throw new Exception("codigo Invalido");
            }

            if (_VeInvoice.invoiceType.Equals("O") && _companySystem.companyType.Equals("3"))// del sistema
            {
                var companysEmisor = (new BL_Company() { connectionString = connectionString }).GetCompanyGeneral(new BECompanyFilter() { companyRUC = _VeInvoice.customerRuc });
                BE_Company _companyEmisor = null;
                if (companysEmisor.Count > 0)
                {
                    _companyEmisor = companysEmisor[0];
                }
                else
                {
                    throw new Exception("codigo Invalido");
                }
                _VeInvoice.companyCode = _companyEmisor.companyCode;
                _VeInvoice.customerRuc = _companySystem.companyRUC;
                _VeInvoice.customerName = _companySystem.companyName;


            }

            if (_VeInvoice.documentId != null)
            {

                var numbers = _VeInvoice.documentId.Split('-');
                if (numbers.Count() < 2)
                {
                    throw new Exception("Ingrese una factura válida");

                }
                _VeInvoice.nroSerie = numbers[0];
                _VeInvoice.nroComprobante = numbers[1];
            }
            invoiceId = new DA_Invoice(_database).createInvoice(_VeInvoice).invoiceId;

            foreach (VE_InvoiceDetail _veInvoiceDetail in _VeInvoice.invoiceDetail)
            {
                _veInvoiceDetail.invoiceId = int.Parse(invoiceId);
                new DA_Invoice(_database).createInvoiceDetail(_veInvoiceDetail);
            }



            return _VeInvoice;
        }

        public VE_Invoice UpdateInvoice(VE_Invoice _VeInvoice)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).updateInvoice(_VeInvoice);
        }

        public VE_Invoice UpdateInvoiceStatus(VE_Invoice _VeInvoice)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).updateInvoiceStatus(_VeInvoice);
        }

        public VE_Invoice DeleteInvoice(VE_Invoice _VeInvoice)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).deleteInvoice(_VeInvoice);
        }

        public List<VE_Invoice> GetSalesInvoiceSummary(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).GetInvoiceSummary(companyCode, "S");
        }

        public List<VE_Invoice> GetOrderInvoiceSummary(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).GetInvoiceSummary(string.Empty, "O", string.Empty, companyCode);
        }

        public List<VE_Invoice> GetInvoiceByCompanyCode(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).GetInvoiceByCompanyCode(companyCode);
        }

        public List<VE_Invoice> GetInvoiceByFilter(string companyCode, int invoiceStatusId)
        {
            _database = new MySQLDatabase(connectionString);
            if (invoiceStatusId == 0)
                return new DA_Invoice(_database).GetInvoiceByCompanyCode(companyCode);
            else
                return new DA_Invoice(_database).GetInvoiceByFilter(companyCode, invoiceStatusId, DateTime.Now, DateTime.Now);
        }

        public List<VE_Invoice> GetInvoiceByCompanyCodeAndType(string companyCode, string invoiceType, int invoiceStatusId)
        {
            _database = new MySQLDatabase(connectionString);

            return new DA_Invoice(_database).GetInvoiceByCompanyCodeAndType(companyCode, invoiceType, invoiceStatusId, DateTime.Now, DateTime.Now);
        }


        public List<VE_InvoiceDetail> GetInvoiceDetailByInvoiceId(int invoiceId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).GetInvoiceDetailByInvoiceId(invoiceId);
        }

        public List<VE_Invoice> GetSalesInvoiceByCompany(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).GetInvoiceResumeByCompanyCode(companyCode, "S");
        }

        public List<VE_Invoice> GetOrderInvoiceByCompany(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).GetInvoiceResumeByCompanyCode(companyCode, "O");
        }

        public List<BE_InvoiceItem> GetInvoiceItem(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).GetInvoiceItem(companyCode);
        }

        public BE_InvoiceItem AddInvoiceItem(BE_InvoiceItem _beInvoiceItem)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).AddInvoiceItem(_beInvoiceItem);
        }

        //public VE_Invoice UpdateInvoiceStatus(VE_Invoice _veInvoice)
        //{
        //    _database = new MySQLDatabase(connectionString);
        //    return new DA_Invoice(_database).UpdateInvoiceStatus(_veInvoice);
        //}

        public List<VE_Invoice> GetInvoiceGeneral(BEInvoiceFilter _bEInvoiceFilter)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).getInvoiceGeneral(_bEInvoiceFilter);
        }
        /*
        public VE_Invoice updateInvoiceGeneral(VE_Invoice _vE_Invoice)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).updateInvoiceGeneral(_vE_Invoice);
        }*/

        public VE_Invoice updateInvoiceGeneral(VE_Invoice _VeInvoice)
        {
            _database = new MySQLDatabase(connectionString);

            BL_Option bL_Option = new BL_Option(this.connectionString);
            //bL_Option.connectionString = connectionString;
            var ok = bL_Option.ValidateOption(9,_VeInvoice.userName);
            if (ok == 0)
            {
                throw new ApplicationException("Ud. no cuenta con los permisos necesarios");
            }

            if (_VeInvoice.documentId != null)
            {

                var numbers = _VeInvoice.documentId.Split('-');
                if (numbers.Count() < 2)
                {
                    throw new ApplicationException("Ingrese una factura válida");

                }
                _VeInvoice.nroSerie = numbers[0];
                _VeInvoice.nroComprobante = numbers[1];
            }


            new DA_Invoice(_database).updateInvoiceGeneral(_VeInvoice);

            var invoice = new DA_Invoice(_database).getInvoiceGeneral(new BEInvoiceFilter { invoiceIdList = _VeInvoice.invoiceId });

            if (_VeInvoice.invoiceStatusId != invoice[0].invoiceStatusId)
            {
                BL_WorkFlow _blWorkFlow = new BL_WorkFlow();
                _blWorkFlow.connectionString = connectionString;
                var mensaje = "";
                bool bOk=false;
                if (_VeInvoice.invoiceStatusId == 2)
                {
                    bOk = _blWorkFlow.NextWorkFlowStep(ref mensaje, 9, int.Parse(_VeInvoice.invoiceId), _VeInvoice.userName, false);

                }
                else
                {
                    bOk = _blWorkFlow.NextWorkFlowStep(ref mensaje, 1, int.Parse(_VeInvoice.invoiceId), _VeInvoice.userName, false);

                }

                if (!bOk)
                {
                    throw new ApplicationException(mensaje);

                }
            }
            new DA_Invoice(_database).DeleteInvoiceDetailByInvoiceId(_VeInvoice.invoiceId);

            if (_VeInvoice.invoiceDetail != null)
            {
                foreach (VE_InvoiceDetail _veInvoiceDetail in _VeInvoice.invoiceDetail)
                {
                    _veInvoiceDetail.invoiceId = int.Parse(_VeInvoice.invoiceId);
                    new DA_Invoice(_database).createInvoiceDetail(_veInvoiceDetail);
                }
            }
            return _VeInvoice;
        }

        public List<BE_DocumentType> GetDocumentTypeGeneral(BE_DocumentType _DocumentType)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).GetDocumentTypeGeneral(_DocumentType);
        }

        public BE_DocumentType CreateDocumentTypeGeneral(BE_DocumentType _DocumentType)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).CreateDocumentTypeGeneral(_DocumentType);
        }

        public BE_DocumentType UpdateDocumentTypeGeneral(BE_DocumentType _DocumentType)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Invoice(_database).UpdateDocumentTypeGeneral(_DocumentType);
        }



        public List<VE_Invoice> MakePaymentsDetailsPartials(List<VE_Invoice> _lstVeInvoice, BE_Payment _BePayment)
        {
            _database = new MySQLDatabase(connectionString);

            BE_PaymentAuthDetail _paymentAuthDetail = new BE_PaymentAuthDetail();

            BE_PaymentAuth _PaymentAuth = new BE_PaymentAuth();


            BL_WorkFlow _blWorkFlow = new BL_WorkFlow();
            _blWorkFlow.connectionString = connectionString;

            /*
            foreach (VE_Invoice _veInvoice in _lstVeInvoice)
            {
                _blWorkFlow = new BL_WorkFlow();
                _blWorkFlow.connectionString = connectionString;
                var mensaje = "";
                bool bOk = _blWorkFlow.NextWorkFlowStep(ref mensaje, 2, int.Parse(_veInvoice.invoiceId), _veInvoice.userName, false);
                //bool bOk = _blWorkFlow.NextWorkFlowStep(ref mensaje, 2, int.Parse(_veInvoice.invoiceId), "marko.polo", false);

                if (!bOk)
                {
                    throw new Exception(mensaje);

                }
            }
            */
            _PaymentAuth = new BE_PaymentAuth();
            _PaymentAuth.bankAccountId = (int)_BePayment.bankAccountId;
            _PaymentAuth.companyCode = _BePayment.companyCode;
            _PaymentAuth.userName = _BePayment.userName;
            _PaymentAuth.exchangeRate = _BePayment.exchangeRate == null ? 0 : decimal.Parse(_BePayment.exchangeRate);

            var aux = new DA_Payment(_database).createPaymentAuth(_PaymentAuth);

            _BePayment.paymentAuthId = aux.paymentAuthId;
            var aux2 = new DA_Payment(_database).createPaymentGeneral(_BePayment);
            _BePayment.paymentId = aux2.paymentId;


            foreach (VE_Invoice _veInvoice in _lstVeInvoice)
            {
                BE_PaymentDetail bE_PaymentDetail = new BE_PaymentDetail();
                bE_PaymentDetail.idPayment = int.Parse(_BePayment.paymentId.ToString());
                bE_PaymentDetail.idInvoice = int.Parse(_veInvoice.invoiceId);
                bE_PaymentDetail.amount = _veInvoice.amountPayment;

                new DA_Payment(_database).CreatePaymentDetail(bE_PaymentDetail);
                new DA_Bank(_database).updateBalanceBankAccountByPayment((int)_BePayment.paymentId, _BePayment.bankAccountId);

                _paymentAuthDetail = new BE_PaymentAuthDetail();
                _paymentAuthDetail.paymentAuthId = (int)_BePayment.paymentAuthId;
                _paymentAuthDetail.userAudit = _BePayment.userName;
                _paymentAuthDetail = new DA_Payment(_database).createFirstPAD(_paymentAuthDetail);
            
            }

            if (aux != null)
                return _lstVeInvoice;
            else
                throw new Exception("Ocurrió un error al realizar la transacción");


        }
    }
}
