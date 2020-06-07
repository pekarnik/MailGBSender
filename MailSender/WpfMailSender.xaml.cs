﻿using System;
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
		}


		private void miClose_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void btnClock_Click(object sender, RoutedEventArgs e)
		{
			tabControl.SelectedItem = tabPlanner;
		}
	}
}
