using LoanCalculator.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoanCalculator.ASP
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var emi = PersonalLoanCalculator.Instance.GetEMI(480000, 5, 11.25);
            txtEMI.InnerHtml = "Monthly EMI : " + String.Format("{0:0.##}", emi);
        }
    }
}