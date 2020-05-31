using System;
using System.Windows;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using MailSender;

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
			List<string> listStrMails = new List<string> { "sh5@inbox.ru" };
			string strPassword = passwordBox.Password;
			strPassword = passwordBox.Password;
			foreach (string mail in listStrMails)
			{
				using (MailMessage mm = new MailMessage("pekarnik11@yandex.ru", mail))
				{
					mm.Subject = "Привет из C#";
					mm.Body = "Hello, world!";
					mm.IsBodyHtml = false;

					using (SmtpClient sc = new SmtpClient(StaticVariableClass.SmtpServer, 
						StaticVariableClass.SmtpPort))
					{
						sc.EnableSsl = true;
						sc.Credentials = new NetworkCredential(StaticVariableClass.senderMail,
							strPassword);
						try
						{
							sc.Send(mm);
						}
						catch(Exception ex)
						{
							MessageBox.Show("Невозможно отправить письмо " +
								ex.ToString());
						}
					}
				}
			}
			SendEndWindow sew = new SendEndWindow();
			sew.ShowDialog();
		}
	}
}
