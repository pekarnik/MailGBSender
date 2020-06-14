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

namespace TabSwitcher
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class TabSwitcherControl : UserControl
    {
		#region properties
		private bool bHideBtnPrevious = false;
        private bool bHideBtnNext = false;
        public bool IsHideBtnPrevious
		{
			get { return bHideBtnPrevious; }
			set
			{
                bHideBtnPrevious = value;
                SetButtons();
			}
		}
        public bool IsHideBtnNext
		{
            get { return bHideBtnNext; }
            set
			{
                bHideBtnNext = value;
                SetButtons();
			}
		}
        private void BtnNextTrueBtnPreviousFalse()
		{
            btnNext.Visibility = Visibility.Hidden;
            btnPrevious.Visibility = Visibility.Visible;
            btnPrevious.Width = 229;
            btnNext.Width = 0;
            btnPrevious.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
        private void BtnPreviousTrueBtnNextFalse()
		{
            btnPrevious.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Visible;
            btnNext.Width = 229;
            btnPrevious.Width = 0;
            btnNext.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
        private void BtnPreviousFalseBtnNextFalse()
        {
            btnNext.Visibility = Visibility.Visible;
            btnPrevious.Visibility = Visibility.Visible;
            btnNext.Width = 115;
            btnPrevious.Width = 114;
        }
        private void BtnPreviousTrueBtnNextTrue()
        {
            btnPrevious.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Hidden;
        }
        private void SetButtons()
        {
            if (bHideBtnPrevious && bHideBtnNext) BtnPreviousTrueBtnNextTrue();
            else if (!bHideBtnNext && !bHideBtnPrevious) BtnPreviousFalseBtnNextFalse();
            else if (bHideBtnNext && !bHideBtnPrevious) BtnNextTrueBtnPreviousFalse();
            else if (!bHideBtnNext && bHideBtnPrevious) BtnPreviousTrueBtnNextFalse();
        }
        #endregion

        public event RoutedEventHandler btnNextClick;
        public event RoutedEventHandler btnPreviousClick;
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            btnNextClick?.Invoke(sender, e);
        }
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            btnPreviousClick?.Invoke(sender, e);
        }

        public TabSwitcherControl() 
        {
            InitializeComponent();
        }
    }
}
