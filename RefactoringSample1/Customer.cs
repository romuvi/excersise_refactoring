using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringSample1
{
	public class Customer
	{
		private string _name;
		private List<Rental> _rentals = new List<Rental>();
		public Customer(string name)
		{
			_name = name;
		}
		public void AddRental(Rental rent)
		{
			_rentals.Add(rent);
		}
		public string GetName()
		{
			return _name;
		}

		public string Statement()
		{
			double totalAmount = 0;
			int frequentRenterPoints = 0;
			var result = $"Rental Record for {GetName()}\n";

			foreach (Rental rental in _rentals)
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
				// add frequent renter points
				frequentRenterPoints++;
				// add bonus for a two day new release rental
				if ((rental.GetMovie().GetPriceCode() == Movie.NEW_RELEASE) &&	rental.GetDaysRented() > 1)
					frequentRenterPoints++;
				//show figures for this rental
				result += $"\t{rental.GetMovie().GetTitle()}\t{thisAmount}\n";
				totalAmount += thisAmount;
			}

			//add footer lines
			result += $"Amount owed is {totalAmount}\n";
			result += $"You earned {frequentRenterPoints} frequent renter points";
			return result;
		}
	}
}
