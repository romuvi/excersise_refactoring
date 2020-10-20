using System;
using Xunit;
using System.Collections.Generic;

namespace RefactoringSample1.Tests
{
    public class RentalTest
    {
        private static List<Movie> _movies = new List<Movie>
            {
                new Movie("The Lion King", Movie.CHILDRENS),
                new Movie("Joker", Movie.NEW_RELEASE),
                new Movie("Avengers: Endgame", Movie.REGULAR)
            };

        [Theory]
        [MemberData(nameof(FrequentPointsTestData))]
        public void GetFrequentPoints(Rental rental, int points)
        {
            Assert.Equal(Rental.GetFrequentPoints(rental), points);
        }

        [Theory]
        [MemberData(nameof(GetChargeRentalTestData))]
        public void GetCharge(Rental rental, double charge)
        {
            Assert.Equal(Rental.GetCharge(rental), charge);
        }

        public static TheoryData<Rental, int> FrequentPointsTestData()
        {
            return new TheoryData<Rental, int>
            {
                { new Rental(_movies[0],1),1 },
                { new Rental(_movies[0],2),1 },
                { new Rental(_movies[0],3),1 },
                { new Rental(_movies[1],1),1 },
                { new Rental(_movies[1],2),2 },
                { new Rental(_movies[1],3),2 }
            };
        }

        public static TheoryData<Rental, double> GetChargeRentalTestData()
        {
            return new TheoryData<Rental, double>
            {
                { new Rental(_movies[2], 1),2 },
                { new Rental(_movies[2], 2),2 },
                { new Rental(_movies[2], 3),3.5 },
                { new Rental(_movies[2], 4),5 },
                { new Rental(_movies[0], 3),1.5 },
                { new Rental(_movies[0], 4),3 },
                { new Rental(_movies[1], 2),6 },
                { new Rental(_movies[1], 3),9 },
            };
        }
    }
}
