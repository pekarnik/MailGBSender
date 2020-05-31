using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			MailMessage mm = new MailMessage("pekarnik11@yandex.ru",
				"sh5@inbox.ru");
			mm.Subject = "Заголовок письма";
			mm.Body = "Содержимое письма";

			mm.IsBodyHtml = false;

			SmtpClient sc = new SmtpClient("smtp.yandex.ru", 25);
			sc.EnableSsl = true;
			sc.DeliveryMethod = SmtpDeliveryMethod.Network;
			sc.UseDefaultCredentials = false;
			Console.WriteLine("Введите пароль:");
			string password = Console.ReadLine();
			sc.Credentials = new NetworkCredential("pekarnik11@yandex.ru", password);
			
			try
			{
				sc.Send(mm);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
			}

		}
	}
}
