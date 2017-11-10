using System;

namespace LoanCalculator.Standard
{
    public class PersonalLoanCalculator
    {
        private double emiAmount;
        private double totalPaidInterest;

        //Private Constructor.
        private PersonalLoanCalculator()
        {
        }

        private static PersonalLoanCalculator instance = null;
        public static PersonalLoanCalculator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PersonalLoanCalculator();
                }
                return instance;
            }
        }

        public void Calculate(int amount, int period, double rate)
        {
            //Principale amount.
            var A = amount;

            //Number of Periodic Payments(N) = Payments per year times number of years.
            var N = period * 12;

            //Periodic Interest Rate(I) = Annual rate divided by number of payments per year.
            var I = ((float)rate / 100) / 12;

            //X = {[(1 + i) ^n] - 1}.
            var X = Math.Pow(1 + I, N) - 1;
            //Y = [i(1 + i)^n].
            var Y = Math.Pow(1 + I, N) * I;

            //Discount Factor (D) = {[(1 + i) ^n] - 1} / [i(1 + i)^n].
            var D = X / Y;

            //Loan Payment = Amount (A)/ Discount Factor(D).
            var P = A / D;

            //SI [Interest] = (Principle(A) x Time(period)× Rate ) / 100.
            var Q = A * period * ((float)rate / 100);

            emiAmount = P;
            totalPaidInterest = Q;
        }

        public double GetEMI(int amount, int period, double rate)
        {
            Calculate(amount, period, rate);

            return emiAmount;
        }

        public double GetTotalInterestPaid(int amount, int period, double rate)
        {
            Calculate(amount, period, rate);

            return totalPaidInterest;
        }
    }
}
