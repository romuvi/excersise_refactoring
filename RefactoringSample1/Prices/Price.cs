namespace RefactoringSample1
{
    abstract class Price
    {
        abstract public int GetPriceCode();

        abstract public double GetCharge(int daysRented);

        public virtual int GetFrequentPoints(int daysRented)
        {
            return 1;
        }
    }
}
