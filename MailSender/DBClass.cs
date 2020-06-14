﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
	public class DBClass
	{
		private EmailsDataContext emails = new EmailsDataContext();
		public IQueryable<Email> Emails
		{
			get
			{
				return from c in emails.Email select c;
			}
		}
	}
}
