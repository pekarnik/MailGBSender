using System;
using System.Windows;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
namespace WpfTestMailSender
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class WpfMailSender : Window
	{
		public WpfMailSender()
		{
			InitializeComponent();
		}

		private void btnSendEmail_Click(object sender, RoutedEventArgs e)
		{
			string mail = "sh5@inbox.ru";
			string strPassword = passwordBox.Password;
			strPassword = passwordBox.Password;
			//using (MailMessage mm = new MailMessage(StaticVariableClass.senderMail, mail))
			//{
			//	mm.Subject = "Привет из C#";
			//	mm.Body = "Hello, world!";
			//	mm.IsBodyHtml = false;

			//	using (SmtpClient sc = new SmtpClient(StaticVariableClass.SmtpServer, 
			//		StaticVariableClass.SmtpPort))
			//	{
			//		sc.EnableSsl = true;
			//		sc.Credentials = new NetworkCredential(StaticVariableClass.senderMail,
			//			strPassword);
			//		try
			//		{
			//			sc.Send(mm);
			//		}
			//		catch(Exception ex)
			//		{
			//			MessageBox.Show("Невозможно отправить письмо " +
			//				ex.ToString());
			//		}
			//	}
			//}

			EmailSendServiceClass emailSender = new EmailSendServiceClass(StaticVariableClass.senderMail, strPassword, mail,
				"Привет из C#", "Hello, world!", false, StaticVariableClass.SmtpServer, StaticVariableClass.SmtpPort,
				true, new SendEndWindow(), new SendEndWindow());
			emailSender.Send();
		}
	}
}
