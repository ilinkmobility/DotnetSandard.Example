using LoanCalculator.Standard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanCalculator.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(textBox1.Text);
            int period = Convert.ToInt32(textBox2.Text);
            double rate = Convert.ToDouble(textBox3.Text);

            var emi = PersonalLoanCalculator.Instance.GetEMI(amount, period, rate);
            var totalInterestPaid = PersonalLoanCalculator.Instance.GetTotalInterestPaid(amount, period, rate);

            label4.Text = "Monthly EMI : " + String.Format("{0:0.##}", emi);
            label5.Text = "Total interest paid : " + String.Format("{0:0.##}", totalInterestPaid);
        }
    }
}
