﻿using System.Windows.Threading;
using System.Windows.Forms;
using System;
using System.Linq;

namespace MailSender
{
	class SchedulerClass
	{
		DispatcherTimer timer = new DispatcherTimer();
		EmailSendServiceClass emailSender;
		DateTime dtSend;
		IQueryable<Email> emails;
		public TimeSpan GetSendTime(string strSendTime)
		{
			TimeSpan tsSendTime = new TimeSpan();
			try
			{
				tsSendTime = TimeSpan.Parse(strSendTime);
			}
			catch { }
			return tsSendTime;
		}
		public void SendEmails(DateTime dtSend, EmailSendServiceClass emailSender, IQueryable<Email> emails)
		{
			this.emailSender = emailSender;
			this.dtSend = dtSend;
			this.emails = emails;
			timer.Tick += Timer_Tick;
			timer.Interval = new TimeSpan(0, 0, 1);
			timer.Start();
		}
		private void Timer_Tick(object sender, EventArgs e)
		{
			if(dtSend.ToShortTimeString() ==DateTime.Now.ToShortTimeString())
			{
				emailSender.SendMails(emails);
				timer.Stop();
				MessageBox.Show("Письма отправлены.");
			}
		}
		
	}
}
