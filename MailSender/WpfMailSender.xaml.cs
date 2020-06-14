using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class WpfMailSender : Window
	{
		public WpfMailSender()
		{
			InitializeComponent();
			cbSenderSelect.ItemsSource = VariablesClass.Senders;
			cbSenderSelect.DisplayMemberPath = "Key";
			cbSenderSelect.SelectedValuePath = "Value";

			DBClass db = new DBClass();
			dgEmails.ItemsSource = db.Emails;
			tscTabSwitcher.btnNextClick += TscTabSwitcher_btnNextClick;
		}


		private void miClose_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnClock_Click(object sender, RoutedEventArgs e)
		{
			tabControl.SelectedItem = tabPlanner;
		}

		private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
		{
			string strLogin = cbSenderSelect.Text;
			string strPassword = cbSenderSelect.SelectedValue.ToString();
			if(string.IsNullOrEmpty(strLogin))
			{
				MessageBox.Show("Выберите отправителя");
				return;
			}
			if(string.IsNullOrEmpty(strPassword))
			{
				MessageBox.Show("Укажите пароль отправителя");
				return;
			}
			EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin, strPassword);
			emailSender.SendMails((IQueryable<Email>)dgEmails.ItemsSource);
		}

		private void btnSend_Click(object sender, RoutedEventArgs e)
		{
			SchedulerClass sc = new SchedulerClass();
			TimeSpan tsSendTime = sc.GetSendTime(tbTimePicker.Text);
			if(tsSendTime == new TimeSpan())
			{
				MessageBox.Show("Некорректный формат даты");
				return;
			}
			DateTime dtSendDateTime = (cldSchedulDateTimes.SelectedDate ??
				DateTime.Today).Add(tsSendTime);
			if(dtSendDateTime<DateTime.Now)
			{
				MessageBox.Show("Дата и время отправки писем не могут быть раньше, чем настоящее время");
				return;
			}
			EmailSendServiceClass emailSender = new
				EmailSendServiceClass(cbSenderSelect.Text,
				cbSenderSelect.SelectedValue.ToString());
			sc.SendEmails(dtSendDateTime, emailSender,
				(IQueryable<Email>)dgEmails.ItemsSource);
		}
		private void TscTabSwitcher_btnNextClick(object sender, RoutedEventArgs e)
		{
			tabControl.SelectedIndex = 1;
		}

	}
}
 