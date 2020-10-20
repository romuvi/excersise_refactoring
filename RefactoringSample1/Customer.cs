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

		public double GetTotalCharge()
		{
			double result = 0;

			foreach (Rental rental in _rentals)
			{
				result += Rental.GetCharge(rental);
			}

			return result;
		}

		public int GetFrequentPoints()
		{
			int result = 0;

			foreach (Rental rental in _rentals)
			{
				result += Rental.GetFrequentPoints(rental);
			}

			return result;
		}

		public string Statement()
		{
			var result = $"Rental Record for {GetName()}\n";

			foreach (Rental rental in _rentals) 
			{ 
				//show figures for this rental
				result += $"\t{rental.GetMovie().GetTitle()}\t{Rental.GetCharge(rental)}\n";
            }

            //add footer lines
            result += $"Amount owed is {GetTotalCharge()}\n";
			result += $"You earned {GetFrequentPoints()} frequent renter points";
			return result;
		}

		public string HtmlStatement()
		{
			var result = $"<h1>Rental Record for {GetName()}</h1>";

			foreach (Rental rental in _rentals)
			{
				//show figures for this rental
				result += $"<p>{rental.GetMovie().GetTitle()}\t{Rental.GetCharge(rental)}</p>";
			}

			//add footer lines
			result += $"<p>Amount owed is {GetTotalCharge()}</p>";
			result += $"<p>ou earned {GetFrequentPoints()} frequent renter points</p>";
			return result;
		}
	}
}
