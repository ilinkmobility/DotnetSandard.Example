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

            var txtEMI = FindViewById<TextView>(Resource.Id.txtEMI);

            var emi = PersonalLoanCalculator.Instance.GetEMI(480000, 5, 11.25);

            txtEMI.Text = "Monthly EMI : " + string.Format("{0:0.##}", emi);
        }
    }
}

