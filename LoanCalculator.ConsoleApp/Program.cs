using LoanCalculator.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Personal Loan Calculator");

            Console.Write("Enter principal amount : ");
            int amount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter no. of tenure in year : ");
            int period = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter interest percentage : ");
            double rate = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n\n");
            Console.WriteLine("Monthly EMI : " + string.Format("{0:0.00}", PersonalLoanCalculator.Instance.GetEMI(amount, period, rate)));
            Console.WriteLine("Total interest paid : " + PersonalLoanCalculator.Instance.GetTotalInterestPaid(amount, period, rate));

            Console.Read();
        }
    }
}
