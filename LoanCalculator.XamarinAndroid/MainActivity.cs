using Android.App;
using Android.Widget;
using Android.OS;

using LoanCalculator.Standard;

namespace LoanCalculator.XamarinAndroid
{
    [Activity(Label = "LoanCalculator.XamarinAndroid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var editAmount = FindViewById<TextView>(Resource.Id.EditAmount);
            var editPeriod = FindViewById<TextView>(Resource.Id.EditPeriod);
            var editRate = FindViewById<TextView>(Resource.Id.EditRate);

            Button calculatebutton = FindViewById<Button>(Resource.Id.CalculateButton);

            var txtEMI = FindViewById<TextView>(Resource.Id.txtEMI);
            var txtInterest = FindViewById<TextView>(Resource.Id.txtInterest);

            calculatebutton.Click += delegate {
                var emi = PersonalLoanCalculator.Instance.GetEMI(int.Parse(editAmount.Text), int.Parse(editPeriod.Text), double.Parse(editRate.Text));
                var interest = PersonalLoanCalculator.Instance.GetTotalInterestPaid(int.Parse(editAmount.Text), int.Parse(editPeriod.Text), double.Parse(editRate.Text));
                txtEMI.Text = "Monthly EMI : " + string.Format("{0:0.##}", emi);
                txtInterest.Text = "Interest : " + string.Format("{0:0.##}", interest);
            };
        }
    }
}

