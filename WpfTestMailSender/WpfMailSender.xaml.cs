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

			EmailSendServiceClass emailSender = new EmailSendServiceClass(StaticVariableClass.senderMail, strPassword, mail,
				subjectBox.Text, mailBox.Text, false, StaticVariableClass.SmtpServer, StaticVariableClass.SmtpPort,
				true, new SendEndWindow(), new SendErrorWindow());
			emailSender.Send();
		}
	}
}
