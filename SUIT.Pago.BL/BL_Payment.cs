using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT.BE;
using SUIT.Pago.BE;
using SUIT.Pago.DA;
using System.IO;
using System.Globalization;
using SUIT.BL;
using SUIT.Pago.BE.n.Filters;
using SUIT.Security.DA;
using SUIT.Security.BE;
using SUIT.Security.BL;

namespace SUIT.Pago.BL
{
    public class BL_Payment
    {
        public MySQLDatabase _database;
        public string connectionString;
        

        public List<VE_Payment> GetCompanyPaymentsByPeriod(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).getCompanyPaymentsByPeriod(companyCode);
        }
            
        public List<VE_PaymentAuth> getPaymentsAuthByCompanyCode(string companyCode)
        {
            _database = new MySQLDatabase(connectionString);
            List < VE_PaymentAuth > _lstPaymentAuth = new DA_Payment(_database).getPaymentsAuthByCompanyCode(companyCode);
            foreach (VE_PaymentAuth paymentAuth in _lstPaymentAuth)
            {
                paymentAuth.paymentAuthDetail = new DA_Payment(_database).getAuthorizedUserByPAID(paymentAuth.paymentAuthId);
            }

            return _lstPaymentAuth;
        }

        public List<VE_PaymentAuth> getPaymentsAuthById(int paymentAuthId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).getPaymentsAuthById(paymentAuthId);
        }

        public List<VE_PaymentAuth> getPaymentsAuthByCompanyCode(string companyCode, string startDate, string endDate)
        {
            _database = new MySQLDatabase(connectionString);
            List<VE_PaymentAuth> _lstPaymentAuth = new DA_Payment(_database).getPaymentsAuthByCompanyCode(companyCode, startDate, endDate);
            foreach (VE_PaymentAuth paymentAuth in _lstPaymentAuth)
            {
                paymentAuth.paymentAuthDetail = new DA_Payment(_database).getAuthorizedUserByPAID(paymentAuth.paymentAuthId);
            }

            return _lstPaymentAuth;

            //return new DA_Payment(_database).getPaymentsAuthByCompanyCode(companyCode, startDate, endDate);
        }

        public List<VE_Payment> getPaymentsByAuthId(int paymentAuthId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).getPaymentsByAuthId(paymentAuthId);
        }

        public List<VE_Payment> getPaymentsAuthBankAccountById(int paymentAuthId, int bankAccountId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).getPaymentsAuthBankAccountById(paymentAuthId, bankAccountId);
        }

        public BE_PaymentAuth reversePayment(BE_PaymentAuth bePaymentAuth)
        {

            _database = new MySQLDatabase(connectionString);
            //new DA_Payment(_database).reversePaymentAuth(bePaymentAuth);
            return new DA_Payment(_database).reversePayment(bePaymentAuth);
        }

        public BE_Mail GetMailInfo(int idMail)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_User(_database).getMailInfo(idMail);
        }
        public List<VE_PaymentAuthDetail> GetValueUserByPaymentAuthId(int PaymentAuthId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).getValueUserByPaymentAuthId(PaymentAuthId);
        }

        public VE_PaymentAuthDetail GetCompanyCodeByPAD(int paymentAuthDetailID)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).getCompanyCodeByPAD(paymentAuthDetailID);
        }
        public VE_PaymentAuthDetail getQuantityAuthorizeByPAD(int PaymentAuthId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).getQuantityAuthorizeByPAD(PaymentAuthId);
        }
        public VE_PaymentAuthDetail GetUserAuditByPaymentAuthId(int PaymentAuthId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).getUserAuditByPaymentAuthId(PaymentAuthId);
        }
        public BE_PaymentAuthDetail CreatePaymentAuthDetail(BE_PaymentAuthDetail _BePaymentAuthDetail)
        {

            _database = new MySQLDatabase(connectionString);
        


            BE_PaymentAuthDetail _BePAD = new DA_Payment(_database).createPaymentAuthDetail(_BePaymentAuthDetail);
            List<VE_PaymentAuth> _lstVePaymentAuth = getPaymentsAuthById(_BePAD.paymentAuthId);
            List<VE_PaymentAuthDetail> _lstVePaymentAuthDetail = GetValueUserByPaymentAuthId(_BePAD.paymentAuthId);
            
            
            
            BL_Usuario _blUsuario = new BL_Usuario();
            _blUsuario.connectionString = connectionString;
            List<VE_UserCompany> _lstVeUserCompany = _blUsuario.GetUserNameByCompanyCode(_lstVePaymentAuth[0].companyCode, _lstVePaymentAuth[0].paymentAuthId);
            if (_lstVeUserCompany.Count > 0)
            {
                if (_lstVePaymentAuthDetail.Count == _lstVeUserCompany[0].quantityAuth)
                {
                    UpdatePaymentAuthStatus(2, _lstVePaymentAuth[0].paymentAuthId);
                }
                else
                {
                    UpdatePaymentAuthStatus(1, _lstVePaymentAuth[0].paymentAuthId);
                }
            }
            List<VE_Payment> _lstVePayments = getPaymentsByAuthId(_BePAD.paymentAuthId);
            VE_PaymentAuthDetail _VePADUserAudit = GetUserAuditByPaymentAuthId(_BePAD.paymentAuthId);
            /*
            int idMail = 4;
            BE_Mail _BeMail = GetMailInfo(idMail);*/


            foreach (VE_UserCompany _veUserCompany in _lstVeUserCompany)
            {
                foreach (VE_PaymentAuthDetail _vePaymentAuthDetail in _lstVePaymentAuthDetail)
                {

                    if(_veUserCompany.quantityAuth!= _lstVePaymentAuthDetail.Count)
                    {

                   
            
                        if (_veUserCompany.userName != _vePaymentAuthDetail.userAudit)
                        {
                           

                            string amounttotal = (_veUserCompany.amountTotal).ToString();
                            string paymentsQ = (_lstVePayments.Count).ToString();
                            string paid = (_BePAD.paymentAuthId).ToString();
                            //string paydate = (_lstVePaymentAuth[0].payDate).ToString();

                            /*
                            string body = _BeMail.bodyMail;
                            body = body.Replace("@FirstName", _veUserCompany.firstName);
                            body = body.Replace("@LastName", _veUserCompany.lastName);
                            body = body.Replace("@AmountTotal", amounttotal);
                            body = body.Replace("@PayDate", _lstVePaymentAuth[0].payDateFormat);
                            body = body.Replace("@PaymentsQ", paymentsQ);
                            body = body.Replace("@Generator", _vePaymentAuthDetail.userAudit);
                            body = body.Replace("@PAID", paid);
                            body = body.Replace("@Banco", _lstVePaymentAuth[0].bankName);
                            body = body.Replace("@shortBank", _lstVePaymentAuth[0].bankShortName);
                            body = body.Replace("@tipoMoneda", _lstVePaymentAuth[0].currency);
                            */

                            //body = body.Replace("@n", "<br>");
                            //string body = "<em> HRTDASDASDASD!!</em>";

                            /*
                            if (_veUserCompany.authorize==1){

                                
                                         BL_Mail _BlMail = new BL_Mail();
                                            try
                                            {

                                                _BlMail.SendEmail("erp@poloandsons.com", _veUserCompany.email, _BeMail.subjectMail, body);
                                            } catch                                { }
                                      }*/

                        }

                    }
                    else
                    {
                        BL_Bank _blBank = new BL_Bank();
                        _blBank.connectionString = connectionString;
                        VE_BankAccount _updateBalaceBankAccount = _blBank.UpdateBalanceBankAccount(_lstVePaymentAuth[0].paymentAuthId);
                        return _BePaymentAuthDetail;
                    }



                }
            }
            return  _BePaymentAuthDetail;

        }

        public string UpdatePaymentAuthStatus(int status,int paymentAuthId)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).UpdatePaymentAuthStatus(status,paymentAuthId);
        }

        public BE_PaymentAuthDetail CreateFirstPAD(BE_PaymentAuthDetail _BePaymentAuthDetail)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).createFirstPAD(_BePaymentAuthDetail);
        }

        public Stream getTxtPaymentAuth(int paymentAuthId, int _bankAccountId, ref string filename)
        {
            BL_Bank _blBank = new BL_Bank();
            _blBank.connectionString = connectionString;
            BE_BankAccount _bankAccount = _blBank.GetBankAccountById(_bankAccountId);
            BE_Bank _bank = _blBank.GetBankById(_bankAccount.bankId);
            filename = _bank.bankShortName + "_" + _bankAccount.accountNumber;

            if (_bank.bankShortName == "INTERB")
                return getIBK(paymentAuthId, _bank.bankId, _bankAccountId, 0);
            else if (_bank.bankShortName == "BBVA")
                return getBBVA(paymentAuthId, _bank.bankId, _bankAccountId, 0);
            else if (_bank.bankShortName == "BCP")
                return getBCP(paymentAuthId, _bank.bankId, _bankAccountId, 0);
            else if (_bank.bankShortName == "BCSCTB")
                return getSCOTIA(paymentAuthId, _bank.bankId, _bankAccountId, 0);

            throw new ApplicationException("UNKNOWN_ERROR");


          //  return GetMDFile(vePaymentAuth.paymentAuthId, _bankAccountId);
        }

        private Stream getIBK(int paymentAuthId, int bankId, int bankAccountId, int detraction)
        {
           
            string someString = "";
            string codregistro = "02"; //Código de registro 02**(02)
            string codbenef = ""; //Código de beneficiario(RUC)**(20)
            string tipoperacion = "F"; //Tipo de operacion(Facturas)**(1)
            string docnumero = ""; //Nro de factura**(20)
            string fecvctodoc = "";//Fecha de vencimiento del documento a pagar Fecha en formato "aaaammdd"(8)*/
            string monoperacion = "";//Tipo de moneda soles 01, dolares 10**(2)
            string impoperacion = ""; //Importe mayor a 0, hasta 13 enteros y 2 decimales**(15)
            string indbanco = "0"; //Indicador de cuenta bancaria, Interbank 0**(1)
            string tipoabono = "";//Tipo abono efectivo 00, abono en cuenta ibk 09, cheque gerencia 11, interbankario 99(2)
            string producto = "001";//productos cuenta corriente 001, cuenta ahorros 002, cts  007(3)
            string moneda = "";//Tipo de moneda soles 01, dolares 10**(2)
            string oficina = "";//Código de la oficina a usar en el pago según el producto(3)
            string ctanumero = ""; //Número de la cuenta a usar en el pago según el producto IB: 10 posiciones, CCI: 20 posiciones(20)
            string tipopersona = "";//Persona natural P, persona jurídica o comercial C(1)
            string bendocidetip = "";//Tipo de documento beneficiario DNI 01, RUC 02, Carnet de extranjería 03, cédula de identidad 04, pasaporte 05(2)
            string bendocidenro = "";//Nro documento del beneficiario, si Tipo Persona = P, longitud DNI debe ser igual a 8 posiciones(15)
            string bennombre = "";//Natural "P" Nombre Beneficiario ApPaterno(20)+ApMaterno(20)+Nombres(20),Juridica "C" Razon Social del Beneficiario(60) campo Alfanumérico hasta 60 caracteres(60)

           

            VE_Payment auth = getPaymentsByAuthId(paymentAuthId)[0];
            BL_Bank _blBank = new BL_Bank();
            _blBank.connectionString = connectionString;
            BE_Bank bank = _blBank.GetBankById(bankId);
            
           var bankaccount = _blBank.GetBankAccountById(bankAccountId);
            

            var mimeType = "text/plain";
            var FileBanco = "TMP" + paymentAuthId;
            var date_pay = Convert.ToDateTime(auth.payDate.ToString()).ToString("yyyyMMdd");
            FileBanco = FileBanco + "-" + date_pay + ".TXT";

            var source = "";

            List<VE_Payment> payments = getPaymentsAuthBankAccountById(paymentAuthId, bankAccountId);
            //var payments = context.Payment.Where(p => (p.PaymentAuthId == Id && p.BankAccountId == BankAccountId)).ToList();


            foreach (var payment in payments)
            {
                 someString = "";
                 codregistro = "02";
                 codbenef = ""; 
                 tipoperacion = "F"; 
                 docnumero = "";
                
                 monoperacion = "";
                 impoperacion = ""; 
                 indbanco = "0"; 
                 tipoabono = "";
                 producto = "001";
                 moneda = "";
                 oficina = "";
                 ctanumero = "";
                 tipopersona = "";
                 bendocidetip = "";
                 bendocidenro = "";
                 bennombre = "";

                ctanumero = bankaccount.accountNumber + someString.PadLeft(20, ' ');
                ctanumero = ctanumero.Substring(0, 20);

                codbenef = auth.customerRuc + someString.PadRight(20, ' ');
                codbenef = codbenef.Substring(0, 20);

                docnumero = auth.documentId + someString.PadLeft(20, ' ');
                docnumero = docnumero.Substring(0,20);


                 fecvctodoc = auth.dueDate.ToString();

                DateTime payDate = DateTime.Parse(fecvctodoc);
                // String.Format("{0:yyyyMM/dd/yyyy}", payDate);
                fecvctodoc = String.Format("{0:yyyyMMdd}", payDate);


                if (bankaccount.currency == "USD")
                {
                    monoperacion = "10";
                    moneda = "10";
                }
                // Moneda de operacion dolares 10, soles 01
                else
                {
                    monoperacion = "01";
                    moneda = "01";
                }
                var _BankMasterId = "";
                if (bank.bankMasterId == _BankMasterId)
                    tipoabono = "09";
                else
                    tipoabono = "99";



                

                decimal _tmphimportotal = Decimal.ToInt32(Math.Round(payment.amountPaymentFromBank, 2));
                impoperacion = LeadingZeros(_tmphimportotal.ToString(), 15);

                var _oficina = string.Empty;
                oficina = LeadingRSpaces(_oficina, 3);

                if (auth.documentType == "01") { 
                    bendocidetip = "DNI";
                    tipopersona = "P";
                }
                else { 
                    bendocidetip = "RUC";
                    tipopersona = "C";
                }
               

                var _bendocidenro = paymentAuthId.ToString();
                var _bennombre = paymentAuthId.ToString();
                if (tipopersona == "P")
                {
                    bendocidenro = LeadingRSpaces(_bendocidenro, 8);
                    bennombre = LeadingRSpaces(_bennombre, 62);
                }

                    
                else
                    bennombre = LeadingRSpaces(_bennombre, 60);
               
                

                    
                

                source = source +
                codregistro +
                codbenef +
                tipoperacion +
                docnumero + 
                fecvctodoc +
                monoperacion +
                impoperacion +
                indbanco +
                tipoabono +
                producto +
                moneda +
                oficina  +
                ctanumero +
                tipopersona +
                bendocidetip +
                bendocidenro +
                bennombre 
                + "\r\n";

            }
            return ToStream(source);
        }

        private Stream getBCP(int paymentAuthId, int bankId, int bankAccountId, int detraction)
        {

            DateTime hoy = DateTime.Now;
            string htipreg = "1"; // Tipo de registro	1	1	1
            string hnroabonos = ""; // Cantidad de abonos de la planilla	6	2	000006
            string hfechproc = hoy.ToString("yyyyMMdd"); //Fecha de proceso	8	8	20070712
            string htipctacargo = "C"; //Tipo de la cuenta de cargo	1	16	C
            string hmonctacargo = ""; // Moneda de la cuenta de cargo	4	17	0001
            string hnroctacargo = ""; //Número de la cuenta de cargo	20	21	1910695055056       
            string hmtoplanilla = ""; //Monto total de la planilla	17	41	00000000001200.00
            string hrefplanilla = "PAGOSAPP"; //Referencia de la planilla	40	58	Referencia de la planilla Dividendos
            hrefplanilla = hrefplanilla.PadRight(40, ' ');
            string hflagexonera = "N"; //Flag de exoneración ITF	1	98	S
            string hctrolcheck = ""; //Total de control (checksum)	15	99	000001100000000

            string dtipreg = "2"; //Tipo de registro	1	1	2
            string dtipctabono = ""; //Tipo de la cuenta de abono	1	2	C
            string dnroctaabono = ""; //Número de la cuenta de abono	20	3	1910695055056       
            string dmodpago = "1"; //Modalidad de pago	1	23	1
            string dtipdocprov = "6"; //Tipo de documento del proveedor	1	24	1
            string dnrodocprov = ""; //Número de documento del proveedor	12	25	123456789012
            string dcordocprov = "   "; //Correlativo de documento del proveedor	3	37	1
            string dnomprov = ""; //Nombre del proveedor	75	40	Flávio Millioli
            string drefbenefic = ""; //Referencia para el beneficiario	40	115	Referencia para el beneficiario CTS
            drefbenefic = drefbenefic.PadRight(40, ' ');
            string drefparaemp = ""; //Referencia para la empresa	20	155	Ref para la empresa
            drefparaemp = drefparaemp.PadRight(20, ' ');
            string dmonabono = ""; //Moneda del importe a abonar	4	175	1001
            string dimpabono = ""; //Importe a abonar	17	179	00000000001200.00
            string dflagvalidar = "S"; //Flag validar IDC	1	196	S


            string dbtipreg = "3"; //Tipo de registro	1	1	3
            string dbtipdocpagar = "F"; //Tipo de documento a pagar	1	2	F
            string dbnrodocpagar = ""; //Número de documento a pagar	15	3	000000000000001
            string dbimpdocpagar = ""; //Importe del documento a pagar	17	18	00000000001200.00

            List<VE_Payment> auth = getPaymentsByAuthId(paymentAuthId); //context.PaymentAuth.Where(i => i.Id == Id).FirstOrDefault();

            BL_Bank _blBank = new BL_Bank();
            _blBank.connectionString = connectionString;

            BE_Bank bank = _blBank.GetBankById(bankId);  //context.Bank.SingleOrDefault(b => b.Id == BankId);

            var bankaccount = _blBank.GetBankAccountById(bankAccountId); // context.BankAccount.SingleOrDefault(ba => ba.Id == BankAccountId);

            //var payments = context.Payment.Where(p => (p.PaymentAuthId == Id && p.BankId == BankId)).ToList();

            int _hnroabonos = auth.Count();
            hnroabonos = LeadingZeros(_hnroabonos.ToString(), 6); //Total de Registros  6, zero left

            if (bankaccount.currency == "USD")
                hmonctacargo = "1001"; // Moneda de la cuenta de cargo	4	17	0001
            else
                hmonctacargo = "0001"; // Moneda de la cuenta de cargo	4	17	0001

            hnroctacargo = bankaccount.accountNumber.PadRight(20, ' '); //Número de la cuenta de cargo	20	21	1910695055056       

            decimal _hmtoplanilla = 0;

            foreach (VE_Payment _vePayment in getPaymentsAuthBankAccountById(paymentAuthId, bankAccountId))
            {
                _hmtoplanilla += _vePayment.amountPaymentFromBank;
            }
            
            decimal _tmphmtoplanilla = Math.Round(_hmtoplanilla, 2);
            hmtoplanilla = LeadingZeros(_tmphmtoplanilla.ToString(), 17);

            //hctrolcheck = "000001100000000"; //por verificar //Total de control (checksum)	15	99	000001100000000

            var BankAccountParts = bankaccount.accountNumber.Split('-');
            var newBankAccount = "";
            foreach (var part in BankAccountParts)
            {
                newBankAccount += part;
            }
            //verificar con alvaro
            long hctrolcheck_tmp = Int64.Parse(newBankAccount);
            //string hctrolcheck_tmp = bankaccount.accountNumber;
            var mimeType = "text/plain";
            var FileBanco = "TMP" + paymentAuthId;
            var date_pay = Convert.ToDateTime(auth[0].payDate.ToString()).ToString("yyyyMMdd");
            FileBanco = FileBanco + "-" + date_pay + ".TXT";

            var source = "";
            var payments = getPaymentsAuthBankAccountById(paymentAuthId, bankAccountId); // context.Payment.Where(p => (p.PaymentAuthId == Id && p.BankAccountId == BankAccountId)).ToList();

            foreach (var payment in payments) // query executed and data obtained from database
            {

                List<string> CustomerAccount = new List<string>();

                var _BankMasterId = "";
                var _TipoCta = "";
                var _CtaCargo = "";
                var _CtaCargoInter = "";

                if (bankaccount.currency == "USD")
                    CustomerAccount = payment.customerBankAccountUsd.Split('|').ToList();
                else
                    CustomerAccount = payment.customerBankAccountPen.Split('|').ToList();

                var CtaCargoParts = CustomerAccount[2].Split('-');
                var newCtaCargo = "";
                foreach (var part in CtaCargoParts)
                {
                    newCtaCargo += part;
                }
                var CtaCargoInterParts = CustomerAccount[3].Split('-');
                var newCtaCargoInter = "";
                foreach (var part in CtaCargoInterParts)
                {
                    newCtaCargoInter += part;
                }

                try { _BankMasterId = CustomerAccount[0]; } catch { _BankMasterId = ""; }
                try { _TipoCta = CustomerAccount[1]; } catch { _TipoCta = ""; }
                try { _CtaCargo = newCtaCargo; } catch { _CtaCargo = "0"; }
                try { _CtaCargoInter = newCtaCargoInter; } catch { _CtaCargoInter = "0"; }

                dtipctabono = "B"; //Interbancario

                if (bank.bankMasterId == _BankMasterId)
                    dtipctabono = _TipoCta;

                if (dtipctabono == "B")
                {
                    dnroctaabono = LeadingRSpaces(_CtaCargoInter, 20);
                    hctrolcheck_tmp = hctrolcheck_tmp + Int64.Parse(_CtaCargoInter.PadLeft(15, '0'));
                }
                else
                {
                    dnroctaabono = LeadingRSpaces(_CtaCargo, 20);
                    hctrolcheck_tmp = hctrolcheck_tmp + Int64.Parse(_CtaCargo.PadLeft(15, '0'));
                }

                dnrodocprov = payment.customerRuc.PadRight(12, ' ').Substring(0, 12); //Número de documento del proveedor	12	25	123456789012
                dnomprov = RemoveAccents(payment.customerName).PadRight(75, ' ').Substring(0, 75); //Nombre del proveedor	75	40	Flávio Millioli
                dmonabono = hmonctacargo; //Moneda del importe a abonar	4	175	1001 (same as header)

                decimal _dimpabono = Math.Round(payment.amountPaymentFromBank, 2);

                dimpabono = LeadingZeros(_dimpabono.ToString(), 17);  //Importe a Cargar //string 15, zeros left, no decimales (x100)

                source = source + dtipreg + dtipctabono + dnroctaabono + dmodpago + dtipdocprov + dnrodocprov
                 + dcordocprov + dnomprov + drefbenefic + drefparaemp + dmonabono + dimpabono + dflagvalidar + "\r\n";

                // Detalle - Documentos de los Beneficiarios
                //dbnrodocpagar = payment.NroComprobante.PadRight(15, ' ');

                dbnrodocpagar = GetLast(payment.documentType.PadLeft(2, ' '), 2) + GetLast(payment.nroSerie.PadLeft(4, ' '), 4) + GetLast(payment.nroComprobante.PadRight(9, '0'), 9);
                dbimpdocpagar = dimpabono; //Importe del documento a pagar	17	18	00000000001200.00

                source = source + dbtipreg + dbtipdocpagar + dbnrodocpagar + dbimpdocpagar + "\r\n";

            }

            hctrolcheck = hctrolcheck_tmp.ToString().PadLeft(15, '0').Substring(0, 15);

            var hsource = htipreg + hnroabonos + hfechproc + htipctacargo + hmonctacargo + hnroctacargo
            + hmtoplanilla + hrefplanilla + hflagexonera + hctrolcheck + "\r\n";

            source = hsource + source;

            return ToStream(source);
            
        }

        private Stream getBBVA(int paymentAuthId, int bankId, int bankAccountId, int detraction)
        {

            string someString = ""; //someString.PadLeft(8, '0');
            string hregtype = "750"; //Tipo de Registro
            string hctacargo = "";  //Cuenta de Cargo //string Max 20;
            string hmdacargo = "";  //Moneda de Cuenta de Cargo  //string 3
            string htamount = "";  //Importe a Cargar //string 15, zeros left, no decimales (x100)
            string hproctype = "A";  //Tipo de Proceso // string 1
            string hdateproc = someString.PadLeft(8, ' '); //Fecha de Proceso // string 8 //vacio
            string htimeproc = someString.PadLeft(1, ' '); //Hora de proceso //string 1 //vacio
            string hid = ""; //Referencia //string 25
            string hnroregs = ""; //Total de Registros  6, zero left
            string hvalidat = "S"; //Validación de Pertenencia 
            string hcontrol = someString.PadLeft(15, ' '); //Valor de Control //string 15  //vacio
            string hindprod = someString.PadLeft(3, ' '); //Indicador de Proceso // string 3 //vacio
            string hdescrip = someString.PadLeft(30, ' '); //Descripción string 30 //vacio
            string hfiller = someString.PadLeft(20, ' '); //Descripción string 20 //vacio


            string dregtype = "002";//Tipo de Registro	3
            string ddoctype = "R"; //DOI - Tipo	1 //RUC
            string ddocnumb = "";//DOI - Número	12
            string dtipabono = "";//Tipo de abono	1 // ???
            string dctabono = "";//Número de cuenta de abono	20 // ???
            string drazonsoc = "";//Nombre de Beneficiario	40
            string dmtopagar = "";//Importe a Abonar	15
            string dtipdoc = "";//Tipo de Documento	1
            string dnrodoc = "";//Número de Documento	12
            string daboagrup = "N";//Abono Agrupado	1
            string dreferen = someString.PadLeft(40, ' '); //Referencia	40 //vacio
            string dindaviso = "E";//Indicador de Aviso	1
            string dmedaviso = someString.PadLeft(50, ' '); //Medio de Aviso	50 //vacio
            string dcontacto = someString.PadLeft(30, ' '); //Persona de Contacto	30
            string dindicont = someString.PadLeft(2, ' ');//Indicador de Proceso	2
            string ddescrip = someString.PadLeft(30, ' ');//Descripción	30
            string dfiller = someString.PadLeft(18, ' '); ;//Filler	18

            VE_Payment auth = getPaymentsByAuthId(paymentAuthId)[0]; //context.PaymentAuth.Where(i => i.Id == Id).FirstOrDefault();

            BL_Bank _blBank = new BL_Bank();
            _blBank.connectionString = connectionString;

            BE_Bank bank = _blBank.GetBankById(bankId);  //context.Bank.SingleOrDefault(b => b.Id == BankId);

            var bankaccount = _blBank.GetBankAccountById(bankAccountId); // context.BankAccount.SingleOrDefault(ba => ba.Id == BankAccountId);

            //Filling out header variables
            hctacargo = bankaccount.accountNumber + someString.PadLeft(20, ' ');
            hctacargo = hctacargo.Substring(0, 20);


            hmdacargo = bankaccount.currency;  //Moneda de Cuenta de Cargo  //string 3

            decimal _htamount = 0;
            //context.Payment.Where(p => (p.PaymentAuthId == Id && p.BankAccountId == BankAccountId)).Sum(p => p.AmountPaymentFromBank);
            foreach (VE_Payment _vePayment in getPaymentsAuthBankAccountById(paymentAuthId, bankAccountId))
            {
                _htamount += _vePayment.amountPaymentFromBank;
            }

            int _tmphtamount = Decimal.ToInt32(Math.Round(_htamount, 2) * 100);

            htamount = LeadingZeros(_tmphtamount.ToString(), 15);  //Importe a Cargar //string 15, zeros left, no decimales (x100)

            var _hid = paymentAuthId.ToString();
            hid = LeadingRSpaces(_hid, 25); //Referencia //string 25

            List<VE_Payment> _lstPayment = getPaymentsAuthBankAccountById(paymentAuthId, bankAccountId);

            int _hnroregs = _lstPayment.Count();
            hnroregs = LeadingZeros(_hnroregs.ToString(), 6); //Total de Registros  6, zero left


            var mimeType = "text/plain";
            var FileBanco = "TMP" + paymentAuthId;
            var date_pay = Convert.ToDateTime(auth.payDate.ToString()).ToString("yyyyMMdd");
            FileBanco = FileBanco + "-" + date_pay + ".TXT";

            var payments = _lstPayment;
            var source = hregtype + hctacargo + hmdacargo + htamount + hproctype + hdateproc + htimeproc + hid + hnroregs + hvalidat + hcontrol + hindprod + hdescrip + hfiller + "\r\n";

            foreach (var payment in payments) // query executed and data obtained from database
            {

                var _ddocnumb = payment.customerRuc;
                ddocnumb = LeadingRSpaces(_ddocnumb, 12);


                List<string> CustomerAccount = new List<string>();

                if (bankaccount.currency == "USD")
                    CustomerAccount = payment.customerBankAccountUsd.Split('|').ToList();
                else
                    CustomerAccount = payment.customerBankAccountPen.Split('|').ToList();

                var _BankMasterId = "";
                var _TipoCta = "";
                var _CtaCargo = "";
                var _CtaCargoInter = "";

                try { _BankMasterId = CustomerAccount[0]; } catch { _BankMasterId = ""; }
                try { _TipoCta = CustomerAccount[1]; } catch { _TipoCta = ""; }
                try { _CtaCargo = CustomerAccount[2]; } catch { _CtaCargo = ""; }
                try { _CtaCargoInter = CustomerAccount[3]; } catch { _CtaCargoInter = ""; }

                dtipabono = "I"; //Interbancario

                if (bank.bankMasterId == _BankMasterId)
                    dtipabono = "P"; //Interbancario

                if (dtipabono == "P")
                {
                    //dctabono = "0011" + 
                    dctabono = LeadingRSpaces(_CtaCargo, 20);
                }
                else
                {
                    dctabono = LeadingRSpaces(_CtaCargoInter, 20);
                }

                drazonsoc = LeadingRSpaces(RemoveAccents(payment.customerName), 40);


                int _dmtopagar = Decimal.ToInt32(Math.Round(payment.amountPaymentFromBank, 2) * 100);

                dmtopagar = LeadingZeros(_dmtopagar.ToString(), 15);  //Importe a Cargar //string 15, zeros left, no decimales (x100)

                dtipdoc = "F"; //Fact
                if (payment.documentType == "01")
                    dtipdoc = "F"; //Fact
                else if (payment.documentType == "03")
                    dtipdoc = "B"; //Bol
                else if (payment.documentType == "07")
                    dtipdoc = "N"; //Nota de credito

                dnrodoc = LeadingRSpaces(payment.documentId, 12);//Número de Documento	12

                source = source + dregtype + ddoctype + ddocnumb + dtipabono + dctabono + drazonsoc + dmtopagar
                + dtipdoc + dnrodoc + daboagrup + dreferen + dindaviso + dmedaviso + dcontacto + dindicont + ddescrip + dfiller
                + "\r\n";

            }

            return ToStream(source);

        }
        
        private Stream getSCOTIA(int paymentAuthId, int bankId, int bankAccountId, int detraction)
        {

            DateTime hoy = DateTime.Now;
            string someString = "";

            string druc = ""; //Ruc proveedor 11
            string drsocial = ""; //Razon Social 60
            string dnrofact = ""; //nro de factura 14       
            string dfecfact = ""; //Fech. fact. 8 YYYYMMDD
            string dmtopago = ""; //MOnto de pago 11 (2 decimales sin separador decimal)
            string dformapago = ""; //form de pago 1 (2 abono cta cte. / 3 cta ahorros, / 4 cta otro bco )
            string dbcocodofi = ""; //Codigo de oficina 3 (obligatorio si forma de pago 2/3)
            string dbcocuenta = ""; //Cta de banco scotia 7 ( si es banco scotia obligatorio 2/3 , blanco si es 1/4)
            string dsinglepay = " "; //  1
            string demail = someString.PadRight(30, ' '); // 30
            string dcci = ""; // 20
            string dfactoring = " "; // 1 (F)
            string dfecVctoFactoring = someString.PadRight(8, ' '); // 8
            string dtransExte = " "; //1 


            VE_Payment auth = getPaymentsByAuthId(paymentAuthId)[0]; //context.PaymentAuth.Where(i => i.Id == Id).FirstOrDefault();

            BL_Bank _blBank = new BL_Bank();
            _blBank.connectionString = connectionString;

            BE_Bank bank = _blBank.GetBankById(bankId);  //context.Bank.SingleOrDefault(b => b.Id == BankId);

            var bankaccount = _blBank.GetBankAccountById(bankAccountId); // context.BankAccount.SingleOrDefault(ba => ba.Id == BankAccountId);

            long hctrolcheck_tmp = Int64.Parse(bankaccount.accountNumber);

            var mimeType = "text/plain";
            var FileBanco = "TMP" + paymentAuthId;
            var date_pay = Convert.ToDateTime(auth.payDate.ToString()).ToString("yyyyMMdd");
            FileBanco = FileBanco + "-" + date_pay + ".TXT";

            var source = "";

            List<VE_Payment> payments = getPaymentsAuthBankAccountById(paymentAuthId, bankAccountId);
            //var payments = context.Payment.Where(p => (p.PaymentAuthId == Id && p.BankAccountId == BankAccountId)).ToList();


            foreach (var payment in payments) // query executed and data obtained from database
            {


                druc = ""; //Ruc proveedor 11
                drsocial = ""; //Razon Social 60
                dnrofact = ""; //nro de factura 14       
                dfecfact = ""; //Fech. fact. 8 YYYYMMDD
                dmtopago = ""; //MOnto de pago 11 (2 decimales sin separador decimal)
                dformapago = ""; //form de pago 1 (2 abono cta cte. / 3 cta ahorros, / 4 cta otro bco )
                dbcocodofi = ""; //Codigo de oficina 3 (obligatorio si forma de pago 2/3)
                dbcocuenta = ""; //Cta de banco scotia 7 ( si es banco scotia obligatorio 2/3 , blanco si es 1/4)
                dsinglepay = " "; //  1
                demail = someString.PadRight(30, ' '); // 30
                dcci = someString.PadRight(20, ' '); // 20
                dfactoring = " "; // 1 (F)
                dfecVctoFactoring = someString.PadRight(8, ' '); // 8
                dtransExte = " "; //1 


                druc = payment.customerRuc.PadRight(11, ' ').Substring(0, 11); //Número de documento del proveedor	12	25	123456789012
                drsocial = RemoveAccents(payment.customerName).PadRight(60, ' ').Substring(0, 60); //Nombre del proveedor	75	40	Flávio Millioli
                //dnrofact = payment.NroComprobante.PadLeft(14,' '); //nro de factura 14
                dnrofact = GetLast(payment.documentType.PadLeft(2, ' '), 2) + GetLast(payment.nroSerie.PadLeft(4, ' '), 4) + GetLast(payment.nroComprobante.PadRight(8, '0'), 8);


                dfecfact = payment.documentDate.ToString("yyyyMMdd");


                List<string> CustomerAccount = new List<string>();

                var _BankMasterId = "";
                var _TipoCta = "";
                var _CtaCargo = "";
                var _CtaCargoInter = "";


                int _tmphimportotal = Decimal.ToInt32(Math.Round(payment.amountPaymentFromBank, 2) * 100);
                dmtopago = LeadingZeros(_tmphimportotal.ToString(), 11);

                if (bankaccount.currency == "USD")
                {
                    CustomerAccount = payment.customerBankAccountUsd.Split('|').ToList();
                }
                else
                {
                    CustomerAccount = payment.customerBankAccountPen.Split('|').ToList();
                }

                try { _BankMasterId = CustomerAccount[0]; } catch { _BankMasterId = ""; }
                try { _TipoCta = CustomerAccount[1]; } catch { _TipoCta = ""; } //A ahorro, C corriente, M Maestra
                try { _CtaCargo = CustomerAccount[2]; } catch { _CtaCargo = ""; }
                try { _CtaCargoInter = CustomerAccount[3]; } catch { _CtaCargoInter = ""; }


                dformapago = "4";
                //2 abono cta cte. / 3 cta ahorros, / 4 cta otro bco

                if (_TipoCta == "C") //
                    dformapago = "2";
                else if (_TipoCta == "A")
                    dformapago = "3";

                if (dformapago == "4") //if interbancario
                {
                    dcci = LeadingRSpaces(_CtaCargoInter, 20);
                }
                else
                {
                    dbcocodofi = _CtaCargo.Substring(0, 3); //Codigo de oficina 3 (obligatorio si forma de pago 2/3)
                    dbcocuenta = GetLast(_CtaCargo, 7); //Cta de banco scotia 7 ( si es banco scotia obligatorio 2/3 , blanco si es 1/4)
                }


                source = source +
                druc +
                drsocial +
                dnrofact +
                dfecfact +
                dmtopago +
                dformapago +
                dbcocodofi +
                dbcocuenta +
                dsinglepay +
                demail +
                dcci +
                dfactoring +
                dfecVctoFactoring +
                dtransExte + "\r\n";

            }

            return ToStream(source);
        }

        private string LeadingZeros(string amount, int spaces)
        {
            amount = amount.PadLeft(spaces, '0');
            return amount;
        }

        private string LeadingRSpaces(string value, int spaces)
        {
            value = value.PadRight(spaces, ' ');
            return value;
        }

        private string GetLast(string source, int last)
        {
            return last >= source.Length ? source : source.Substring(source.Length - last);
        }

        private string RemoveAccents(string str)
        {
            /*byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(source);
            return System.Text.Encoding.ASCII.GetString(bytes);*/

            var chars =
                from c in str.Normalize(NormalizationForm.FormD).ToCharArray()
                let uc = CharUnicodeInfo.GetUnicodeCategory(c)
                where uc != UnicodeCategory.NonSpacingMark
                select c;

            var cleanStr = new string(chars.ToArray()).Normalize(NormalizationForm.FormC);

            return cleanStr;
        }

        private Stream ToStream(string str)
        {
            MemoryStream stream = new MemoryStream();

            StreamWriter writer = new StreamWriter(stream);
        
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }


        // second user
        public BE_PaymentAuth updateUserAuth(BE_PaymentAuth _paymentAuth, string userId)
        {
            _database = new MySQLDatabase(connectionString);
            if (!string.IsNullOrEmpty(_paymentAuth.thirdUserId))
            {

            }

            return new DA_Payment(_database).updateUserAuth(_paymentAuth, userId);
        }

        public BE_PaymentAuth updatePaymentAuthPayDate(VE_PaymentAuth _paymentAuth, string userId)
        {
            _database = new MySQLDatabase(connectionString);
            string payDateStr = _paymentAuth.payDateStr;
            
            DateTime payDate = DateTime.Parse(payDateStr);
           // String.Format("{0:yyyyMM/dd/yyyy}", payDate);
            _paymentAuth.payDateStr = String.Format("{0:yyyy-MM-dd}", payDate);


            return new DA_Payment(_database).updatePaymentAuthPayDate(_paymentAuth, userId);
        }

        public List<BE_PaymentMethod> GetPaymentMethod()
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).getPaymentMethod();
        }

        public BE_Payment RegisterClientPayment(BE_Payment _bePayment)
        {
            _database = new MySQLDatabase(connectionString);

            var mensaje = "";
            

            BL_WorkFlow bL_WorkFlow = new BL_WorkFlow();
            bL_WorkFlow.connectionString = connectionString;
            var bOK = bL_WorkFlow.NextWorkFlowStep(ref mensaje, 2, int.Parse(_bePayment.id), _bePayment.userName, false);

            if (bOK)
            {
                BE_Payment bE_Payment = new DA_Payment(_database).createPaymentSales(_bePayment);

                BL_Bank bL_Bank = new BL_Bank();
                bL_Bank.connectionString = connectionString;
                BE_BankAccount bE_BankAccountAux = bL_Bank.updateBalanceBankAccountByInvoice(int.Parse(_bePayment.id), _bePayment.bankAccountId);

                return bE_Payment;
            }
            else
            {
                throw new ApplicationException("Ud. no cuenta con los privilegios necesarios");
            }

        }


        public List<VE_Payment> GetPaymentGeneral(BEPaymentFilter _bEPaymentFilter)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).getPaymentGeneral(_bEPaymentFilter);
        }

        public VE_Payment updatePaymentGeneral(VE_Payment _vE_Payment)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).updatePaymentGeneral(_vE_Payment);
        }


        public BE_Payment createPaymentGeneral(BE_Payment bE_Payment)
        {
            _database = new MySQLDatabase(connectionString);
            var aux = new DA_Payment(_database).createPaymentGeneral(bE_Payment);
            if (bE_Payment.PaymentDetail != null)
            {
                foreach (var pd in bE_Payment.PaymentDetail)
                {
                    pd.idPayment = int.Parse(aux.paymentId.ToString());
                    CreatePaymentDetail(pd);
                }
            }

            return aux;
        }


        public bool CreatePaymentDetail(BE_PaymentDetail bE_PaymentDetail)
        {
            _database = new MySQLDatabase(connectionString);
            return new DA_Payment(_database).CreatePaymentDetail(bE_PaymentDetail);
        }

        public BE_Payment CreateAdvance(BE_Payment _BePayment)
        {
            _database = new MySQLDatabase(connectionString);
            BE_PaymentAuth _PaymentAuth = new BE_PaymentAuth();
            BE_PaymentAuthDetail _paymentAuthDetail = new BE_PaymentAuthDetail();
        
            _PaymentAuth = new BE_PaymentAuth();
            _PaymentAuth.bankAccountId = (int)_BePayment.bankAccountId;
            _PaymentAuth.companyCode = _BePayment.companyCode;
            _PaymentAuth.userName = _BePayment.userName;
            _PaymentAuth.exchangeRate = _BePayment.exchangeRate == null ? 0 : decimal.Parse(_BePayment.exchangeRate);
        
            var aux = new DA_Payment(_database).createPaymentAuth(_PaymentAuth);
                       
            _BePayment.paymentAuthId= aux.paymentAuthId;
            var aux2 = new DA_Payment(_database).createPaymentGeneral(_BePayment);
            _BePayment.paymentId = aux2.paymentId;

            BE_PaymentDetail bE_PaymentDetail = new BE_PaymentDetail();
            bE_PaymentDetail.idPayment = int.Parse(_BePayment.paymentId.ToString());
            bE_PaymentDetail.amount = _BePayment.amountTotal;
            
            new DA_Payment(_database).CreatePaymentDetail(bE_PaymentDetail);
            new DA_Bank(_database).updateBalanceBankAccountByPayment((int)_BePayment.paymentId, _BePayment.bankAccountId);

            _paymentAuthDetail = new BE_PaymentAuthDetail();
            _paymentAuthDetail.paymentAuthId = (int)_BePayment.paymentAuthId;
            _paymentAuthDetail.userAudit = _BePayment.userName;
            _paymentAuthDetail = new DA_Payment(_database).createFirstPAD(_paymentAuthDetail);             
        
            if (aux != null&& aux2 != null)
                return _BePayment;
            else
                throw new Exception("Ocurrió un error al realizar la transacción");
    
        }

    }
}
