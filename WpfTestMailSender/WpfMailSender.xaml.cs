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

					using (SmtpClient sc = new SmtpClient("smtp.yandex.ru", 25))
					{
						sc.EnableSsl = true;
						sc.Credentials = new NetworkCredential("pekarnik11@yandex.ru",
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
			MessageBox.Show("Работа завершена.");
		}
	}
}
