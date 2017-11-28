using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using CoreGraphics;
using LoanCalculator.Standard;

namespace LoanCalculator.XamariniOS
{
    [Register("UniversalView")]
    public class UniversalView : UIView
    {
        UILabel label_amount;
        UITextField textentry_amount;

        UILabel label_period;
        UITextField textentry_period;

        UILabel label_rate;
        UITextField textentry_rate;

        UIButton buton;

        UILabel label_emi { get; set; }
        UILabel label_interest { get; set; }

        public UniversalView()
        {
            Initialize();
        }

        public UniversalView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.White;

            //AMOUNT
            label_amount = new UILabel
            {
                Text = "AMOUNT",
                TextColor = UIColor.Black,
                Frame = new CGRect(30, 20, 300, 30)
            };
            textentry_amount = new UITextField
            {
                TextColor = UIColor.Blue,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Frame = new CGRect(30, 50, 300, 30)
            };

            //PERIOD
            label_period = new UILabel
            {
                Text = "PERIOD",
                TextColor = UIColor.Black,
                Frame = new CGRect(30, 90, 300, 30)
            };
            textentry_period = new UITextField
            {
                TextColor = UIColor.Blue,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Frame = new CGRect(30, 120, 300, 30)
            };

            //RATE
            label_rate = new UILabel
            {
                Text = "RATE",
                TextColor = UIColor.Black,
                Frame = new CGRect(30, 160, 300, 30)
            };
            textentry_rate = new UITextField
            {
                TextColor = UIColor.Blue,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Frame = new CGRect(30, 190, 300, 30)
            };

            this.AddSubview(label_amount);
            this.AddSubview(textentry_amount);
            this.AddSubview(label_period);
            this.AddSubview(textentry_period);
            this.AddSubview(label_rate);
            this.AddSubview(textentry_rate);

            //CALCULATE
            buton = new UIButton(new CGRect(30, 240, 300, 30));
            buton.BackgroundColor = UIColor.Green;
            buton.SetTitle("CALCULATE", UIControlState.Normal);
            buton.SetTitleColor(UIColor.White, UIControlState.Normal);
            buton.TouchUpInside += Buton_TouchUpInside;

            this.AddSubview(buton);

            //EMI
            label_emi = new UILabel
            {
                Text = "",
                TextColor = UIColor.Black,
                Frame = new CGRect(30, 270, 300, 30)
            };
            //INTEREST
            label_interest = new UILabel
            {
                Text = "",
                TextColor = UIColor.Black,
                Frame = new CGRect(30, 300, 300, 30)
            };

            this.AddSubview(label_emi);
            this.AddSubview(label_interest);
        }

        private void Buton_TouchUpInside(object sender, EventArgs e)
        {
            Console.WriteLine("Details : " + textentry_amount.Text + textentry_period.Text + textentry_rate.Text);
            var emi = PersonalLoanCalculator.Instance.GetEMI(int.Parse(textentry_amount.Text), int.Parse(textentry_period.Text), double.Parse(textentry_rate.Text));
            var interest = PersonalLoanCalculator.Instance.GetTotalInterestPaid(int.Parse(textentry_amount.Text), int.Parse(textentry_period.Text), double.Parse(textentry_rate.Text));

            label_emi.Text = "Monthly EMI : " + string.Format("{0:0.##}", emi);
            label_interest.Text = "Interest : " + string.Format("{0:0.##}", interest);
        }
    }

    [Register("MyViewController")]
    public class MyViewController : UIViewController
    {
        public MyViewController()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            View = new UniversalView();

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
        }
    }
}