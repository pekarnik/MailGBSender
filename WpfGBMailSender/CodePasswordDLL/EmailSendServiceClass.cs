using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
	class EmailSendServiceClass
	{
		#region vars
		private string _strLogin;
		private string _strPassword;
		private string _strSmtp;
		private int _iSmtpPort;
		private string _strBody;
		private string _strSubject;
		#endregion
		public EmailSendServiceClass(string sLogin, string sPassword, string strSmtp, int iSmtpPort)
		{
			_strLogin = sLogin;
			_strPassword = sPassword;
			_strSmtp = strSmtp;
			_iSmtpPort = iSmtpPort;
		}
		private void SendMail(string mail, string name)
		{
			using (MailMessage mm = new MailMessage(_strLogin, mail))
			{
				mm.Subject = _strSubject;
				mm.Body = "Hello world!";
				mm.IsBodyHtml = false;
				SmtpClient sc = new SmtpClient(_strSmtp, _iSmtpPort);
				sc.EnableSsl = true;
				sc.DeliveryMethod = SmtpDeliveryMethod.Network;
				sc.UseDefaultCredentials = false;
				sc.Credentials = new NetworkCredential(_strLogin, _strPassword);
				try
				{
					sc.Send(mm);
				}
				catch(Exception ex)
				{
					System.Windows.Forms.MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
				}
			}
		}
		public void SendMails(IQueryable<Email> emails)
		{
			foreach(Email email in emails)
			{
				SendMail(email.Value, email.Name);
			}
		}
	}
}
