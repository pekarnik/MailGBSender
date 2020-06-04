using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace WpfTestMailSender
{
	public class EmailSendServiceClass
	{
		private string _emailFrom;
		private string _emailTo;
		private string _password;
		private string _subject;
		private string _body;
		private bool _isBodyHtml;
		private string _smtpServer;
		private int _smtpPort;
		private bool _enableSSL;
		private Window _success;
		private Window _error;
		public EmailSendServiceClass(string emailFrom, string password, string emailTo, string subject, string body, bool isBodyHtml,
			string smtpServer, int smtpPort, bool enableSSL, Window success, Window error)
		{
			_emailFrom = emailFrom;
			_emailTo = emailTo;
			_password = password;
			_subject = subject;
			_body = body;
			_isBodyHtml = isBodyHtml;
			_smtpServer = smtpServer;
			_smtpPort = smtpPort;
			_enableSSL = enableSSL;
			_success = success;
			_error = error;
		}
		public void Send()
		{
			using (MailMessage mm = new MailMessage(_emailFrom, _emailTo))
			{
				mm.Subject = _subject;
				mm.Body = _body;
				mm.IsBodyHtml = _isBodyHtml;

				using (SmtpClient sc = new SmtpClient(_smtpServer,
					_smtpPort))
				{
					sc.EnableSsl = _enableSSL;
					sc.Credentials = new NetworkCredential(_emailFrom,
						_password);
					try
					{
						sc.Send(mm);
						_success.Show();
					}
					catch (Exception ex)
					{
						_error.Show();
					}
				}
			}
		}
	}
}
