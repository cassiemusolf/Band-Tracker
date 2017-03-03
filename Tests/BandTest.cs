using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
    public class BandTest : IDisposable
    {
        public BandTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_EmptyAtFirst()
        {
            //Arrange, Act
            int result = Band.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_Equal_ReturnsTrueIfBandsAreTheSame()
        {
            //Arrange, Act
            Band firstBand = new Band("John Mayer");
            Band secondBand = new Band("John Mayer");

            //Assert
            Assert.Equal(firstBand, secondBand);
        }

        public void Dispose()
        {
          Band.DeleteAll();
          Venue.DeleteAll();
        }
    }
}
