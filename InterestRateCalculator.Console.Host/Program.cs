using System;
using System.Globalization;

namespace InterestRateCalculator.Console.Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            int nPeriods = 6;
            double P = Math.Pow(10.0, 7);
            double r = 0.092;

            var interestEngine = new InterestRateCalculator(nPeriods,
                                                            r);
            var fv = interestEngine.FutureValue(P);

            System.Console.WriteLine("Future Value: {0}",
                              fv.ToString("N", CultureInfo.InvariantCulture));

            int m = 2;
            var fv2 = interestEngine.FutureValue(P, m);

            System.Console.WriteLine("Future Value with {0} compoundings per year {1}", m, fv2);

            // Future value of an ordinary annuity
            double A = 2.0 * Math.Pow(10.0, 6);
            interestEngine.Interest = 0.08;
            interestEngine.NumberOfPeriods = 15; // 15 years
            System.Console.WriteLine("Ordinary Annuity: {0} ",
                   interestEngine.OrdinaryAnnuity(A));
            // Present Value
            double Pn = 5.0 * Math.Pow(10.0, 6);

            interestEngine.Interest = 0.10;
            interestEngine.NumberOfPeriods = 7;
            System.Console.WriteLine("**Present value: {0} ",
                   interestEngine.PresentValue(Pn));

            // Present Value of a series of future values
            interestEngine.Interest = 0.0625;
            interestEngine.NumberOfPeriods = 5;
            int nPeriods2 = interestEngine.NumberOfPeriods;

            double[] futureValues = new double[nPeriods2]; // For five years
            for (long j = 0; j < nPeriods2 - 1; j++)
            { // The first 4 years
                futureValues[j] = 100.0;
            }
            futureValues[nPeriods2 - 1] = 1100.0;
            System.Console.WriteLine("**Present value, series: {0} ",
                   interestEngine.PresentValue(futureValues));
            // Present Value of an ordinary annuity
            A = 100.0;

            interestEngine.Interest = 0.09;
            interestEngine.NumberOfPeriods = 8;

            System.Console.WriteLine("**PV, ordinary annuity: {0}",
                   interestEngine.OrdinaryAnnuity(A));
            // Now test periodic testing with continuous compounding
            double P0 = Math.Pow(10.0, 8);
            r = 0.092;
            nPeriods2 = 6;
            for (int mm = 1; mm <= 100000000; mm *= 12)
            {
                System.Console.WriteLine("Periodic: {0},, {1}", mm,
                       interestEngine.FutureValue(P0, mm));
            }
            System.Console.WriteLine("Continuous Compounding: {0}",
            interestEngine.FutureValueContinuous(P0));
            // Bond pricing
            double coupon = 50;         // Cash coupon, i.e. 10.0% rate semiannual 
                                        // on parValue
            int n = 20 * 2;                 // Number of payments 
            double annualInterest = 11.0;   // Interest rate annualized
            double parValue = 1000.0;
            int paymentPerYear = 2; // Number of payments per year
            Bond myBond = new Bond(n, annualInterest, coupon, paymentPerYear);

            double bondPrice = myBond.Price(parValue);
            System.Console.WriteLine("Bond price: {0}", bondPrice);

        }
    }
}
