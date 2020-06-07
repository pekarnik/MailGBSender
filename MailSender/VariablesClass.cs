using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
	public static class VariablesClass
	{
		public static Dictionary<string, string> Senders
		{
			get { return _dicSenders; }
		}
		private static Dictionary<string, string> _dicSenders;
	}

}

