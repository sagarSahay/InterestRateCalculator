using System;
namespace InterestRateCalculator
{
    public class InterestRateCalculator
    {
        private double r;
        private int nPeriods;

        public int NumberOfPeriods
        {
            get { return nPeriods; }
            set { nPeriods = value; }
        }

        public double Interest
        {
            get { return r; }
            set { r = value; }
        }

        public InterestRateCalculator(int numberPeriods, double interest)
        {
            if (numberPeriods <= 0) throw new ArgumentException("Illegal value for number periods.");
            nPeriods = numberPeriods;
            if (interest <= 0) throw new ArgumentException("Illegal value for rate.");
            r = interest;
        }

        public double FutureValue(double PO)
        {
            double factor = 1.0 * r;
            return PO * Math.Pow(factor, nPeriods);
        }

        public double FutureValue(double PO, int m)
        {
            double R = r / m;
            int newPeriods = m * nPeriods;

            var myBond = new InterestRateCalculator(newPeriods, R);

            return myBond.FutureValue(PO);
        }

        public double FutureValueContinuous(double P0)
        {

            double growthFactor = Math.Exp(r * nPeriods);
            return P0 * growthFactor;
        }

        public double OrdinaryAnnuity(double A)
        {
            double factor = 1.0 + r;
            return A * ((Math.Pow(factor, nPeriods) - 1.0) / r);
        }

        public double PresentValue(double Pn)
        {
            double factor = 1.0 + r;
            return Pn * (1.0 / Math.Pow(factor, nPeriods));
        }

        public double PresentValue(double[] futureValues)
        {
            double factor = 1.0 + r;
            double PV = 0.0;

            for (int t = 0; t < nPeriods; t++)
            {
                PV += futureValues[t] / Math.Pow(factor, t + 1);
            }

            return PV;
        }

        public double PresentValueConstant(double coupon)
        {
            var factor = 1.0 + r;
            var PV = 0.0;

            for (var t = 0; t < nPeriods; t++)
            {
                PV += 1.0 / Math.Pow(factor, t + 1);
            }
            return PV * coupon;
        }
    }
}
