using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringSample1
{
	public class Rental
	{
		private Movie _movie;
		private int _daysRented;

		public Rental(Movie movie, int daysRented)
		{
			_movie = movie;
			_daysRented = daysRented;
		}
		public int GetDaysRented()
		{
			return _daysRented;
		}
		public Movie GetMovie()
		{
			return _movie;
		}

        public static double GetCharge(Rental rental)
        {
            double thisAmount = 0;
            //determine amounts for each line
            switch (rental.GetMovie().GetPriceCode())
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (rental.GetDaysRented() > 2)
                        thisAmount += (rental.GetDaysRented() - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += rental.GetDaysRented() * 3;
                    break;
                case Movie.CHILDRENS:
                    thisAmount += 1.5;
                    if (rental.GetDaysRented() > 3)
                        thisAmount += (rental.GetDaysRented() - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }

        public static int GetFrequentPoints(Rental rental)
        {
            // add frequent renter points
            var frequentRenterPoints=1;
            // add bonus for a two day new release rental
            if ((rental.GetMovie().GetPriceCode() == Movie.NEW_RELEASE) && rental.GetDaysRented() > 1)
                frequentRenterPoints++;
            return frequentRenterPoints;
        }
    }
}
