using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.Configuration;

namespace SUIT.BL
{
    public class BL_Mail
    {
        public static readonly string smtpServer = ConfigurationManager.ConnectionStrings["smtpServer"].ConnectionString; /*Config["ConnectionStrings:DefaultConnection"];*/


        public void SendEmail(string strFrom
                            , string strTo
                            , string strSubject
                            , string strBody)
        {
            /// Author, Md. Marufuzzaman
            /// Created,
            /// Local dependency, Microsoft .Net framework
            /// Description, Send an email using (SMTP).

            MailMessage objMailMessage = new MailMessage();
            System.Net.NetworkCredential objSMTPUserInfo = new System.Net.NetworkCredential();
            SmtpClient objSmtpClient = new SmtpClient();

            try
            {
                objMailMessage.From = new MailAddress(strFrom);
                objMailMessage.To.Add(new MailAddress(strTo));
                objMailMessage.Subject = strSubject;
                objMailMessage.IsBodyHtml = true;
                objMailMessage.Body = strBody;
                
                
                objSmtpClient = new SmtpClient(smtpServer); /// Server IP
                //objSMTPUserInfo = new System.Net.NetworkCredential("atolentino@suit.pe", "SuitAndre2018", "");
                objSmtpClient.Credentials = objSMTPUserInfo;
                objSmtpClient.UseDefaultCredentials = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            { throw ex; }

            finally
            {
                objMailMessage = null;
                objSMTPUserInfo = null;
                objSmtpClient = null;
            }
        }
    }
}
