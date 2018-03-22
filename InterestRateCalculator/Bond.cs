namespace InterestRateCalculator
{
    public class Bond
    {
        InterestRateCalculator eng;

        private double r;
        private int nPeriods;
        private double c;

        public Bond(int numberPeriods,
                   double interest,
                   double coupon,
                   int paymentPerYear)
        {
            nPeriods = numberPeriods;
            r = interest / (double)paymentPerYear;
            c = coupon;

            eng = new InterestRateCalculator(numberPeriods, r);
        }

        public Bond(InterestRateCalculator interestRateCalculator,
                   double coupon,
                   int paymentPerYear)
        {
            eng = interestRateCalculator;
            c = coupon;

            nPeriods = eng.NumberOfPeriods;
            r = eng.Interest / (double)paymentPerYear;
        }

        public double Price(double redemptionValue)
        {
            var pvCoupon = eng.PresentValueConstant(c);

            var pvPar = eng.PresentValue(redemptionValue);

            return pvCoupon + pvPar;
        }
    }
}
