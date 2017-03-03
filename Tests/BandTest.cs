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

        [Fact]
        public void Test_Save_SavesToDatabase()
        {
            //Arrange
            Band testBand = new Band("John Mayer");

            //Act
            testBand.Save();
            List<Band> result = Band.GetAll();
            List<Band> testList = new List<Band>{testBand};

            //Assert
            Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_Save_AssignsIdToObject()
        {
            //Arrange
            Band testBand = new Band("Brittany Spears");

            //Act
            testBand.Save();
            Band savedBand = Band.GetAll()[0];

            int result = savedBand.GetId();
            int testId = testBand.GetId();

            //Assert
            Assert.Equal(testId, result);
        }

        [Fact]
        public void Test_Find_FindsBandInDatabase()
        {
            //Arrange
            Band testBand = new Band("Brittany Spears");
            testBand.Save();

            //Act
            Band foundBand = Band.Find(testBand.GetId());

            //Assert
            Assert.Equal(testBand, foundBand);
        }

        [Fact]
        public void Test_AddVenue_AddsVenueToBand()
        {
            //Arrange
            Band testBand = new Band("Beyonce");
            testBand.Save();

            Venue testVenue = new Venue("Key Arena");
            testVenue.Save();

            //Act
            testBand.AddVenue(testVenue);

            List<Venue> result = testBand.GetVenues();
            List<Venue> testList = new List<Venue>{testVenue};

            //Assert
            Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_GetVenues_ReturnsAllBandVenues()
        {
            //Arrange
            Band testBand = new Band("Beyonce");
            testBand.Save();

            Venue testVenue1 = new Venue("Key Arena");
            testVenue1.Save();

            Venue testVenue2 = new Venue("The Gorge");
            testVenue2.Save();

            //Act
            testBand.AddVenue(testVenue1);
            List<Venue> result = testBand.GetVenues();
            List<Venue> testList = new List<Venue> {testVenue1};

            //Assert
            Assert.Equal(testList, result);
        }

        public void Dispose()
        {
            Band.DeleteAll();
            Venue.DeleteAll();
        }
    }
}
