using LoanCalculator.Standard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace LoanCalculator.UWP
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;
            storage = value;
            this.OnPropertyChaned(propertyName);
            return true;
        }

        private void OnPropertyChaned(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }

        int amount;
        public int Amount
        {
            get { return amount; }
            set
            {
                this.SetProperty(ref this.amount, value);
            }
        }

        int period;
        public int Period
        {
            get { return period; }
            set
            {
                this.SetProperty(ref this.period, value);
            }
        }

        double rate;
        public double Rate
        {
            get { return rate; }
            set
            {
                this.SetProperty(ref this.rate, value);
            }
        }

        string emi;
        public string EMI
        {
            get { return emi; }
            set
            {
                this.SetProperty(ref this.emi, value);
            }
        }

        string interest;
        public string Interest
        {
            get { return interest; }
            set
            {
                this.SetProperty(ref this.interest, value);
            }
        }

        public ICommand CalculateCommand
        {
            get
            {
                return new CommandHandler(() => this.Calculate());
            }
        }

        public MainViewModel()
        {
            EMI = "EMI : ";
            Interest = "Total paid interest : ";
        }

        public void Calculate()
        {
            EMI = "EMI : " + PersonalLoanCalculator.Instance.GetEMI(Amount, Period, Rate);
            Interest = "Total paid interest : " + PersonalLoanCalculator.Instance.GetTotalInterestPaid(Amount, Period, Rate);
        }
    }
}
