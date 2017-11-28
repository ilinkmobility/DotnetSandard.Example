using LoanCalculator.Standard;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LoanCalculator.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private string _amount;
        public string amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                RaisePropertyChanged("amount");
            }
        }

        private string _period;
        public string period
        {
            get { return _period; }
            set
            {
                _period = value;
                RaisePropertyChanged("period");
            }
        }

        private string _rate;
        public string rate
        {
            get { return _rate; }
            set
            {
                _rate = value;
                RaisePropertyChanged("rate");
            }
        }

        private string _emi;
        public string emi
        {
            get { return _emi; }
            set
            {
                _emi = value;
                RaisePropertyChanged("emi");
            }
        }

        private string _interest;
        public string interest
        {
            get { return _interest; }
            set
            {
                _interest = value;
                RaisePropertyChanged("interest");
            }
        }

        private string _Result;
        public string Result
        {
            get { return _Result; }
            set
            {
                _Result = value;
                RaisePropertyChanged("Result");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = this;
            Result = "Collapsed";
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            amount = period = rate = emi = interest = "";
        }

        private void Button_Click_Calculate(object sender, RoutedEventArgs e)
        {
            Result = "Visible";

            emi = "Monthly EMI : " + string.Format("{0:0.##}", PersonalLoanCalculator.Instance.GetEMI(int.Parse(amount), int.Parse(period), double.Parse(rate)));
            interest = "Interest : " + string.Format("{0:0.##}", PersonalLoanCalculator.Instance.GetTotalInterestPaid(int.Parse(amount), int.Parse(period), double.Parse(rate)));
        }
    }
}
