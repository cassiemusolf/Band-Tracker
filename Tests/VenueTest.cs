using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
    public class VenueTest : IDisposable
    {
        public VenueTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_EmptyAtFirst()
        {
            //Arrange, Act
            int result = Venue.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_Equal_ReturnsTrueIfVenuesAreTheSame()
        {
            //Arrange, Act
            Venue firstVenue = new Venue("The Gorge");
            Venue secondVenue = new Venue("The Gorge");

            //Assert
            Assert.Equal(firstVenue, secondVenue);
        }

        public void Dispose()
        {
          Band.DeleteAll();
          Venue.DeleteAll();
        }
    }
}
