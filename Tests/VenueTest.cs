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

        [Fact]
        public void Test_Save_SavesToDatabase()
        {
            //Arrange
            Venue testVenue = new Venue("The Gorge");

            //Act
            testVenue.Save();
            List<Venue> result = Venue.GetAll();
            List<Venue> testList = new List<Venue>{testVenue};

            //Assert
            Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_Save_AssignsIdToObject()
        {
            //Arrange
            Venue testVenue = new Venue("The Gorge");

            //Act
            testVenue.Save();
            Venue savedVenue = Venue.GetAll()[0];

            int result = savedVenue.GetId();
            int testId = testVenue.GetId();

            //Assert
            Assert.Equal(testId, result);
        }

        [Fact]
        public void Test_Find_FindsVenueInDatabase()
        {
            //Arrange
            Venue testVenue = new Venue("The Gorge");
            testVenue.Save();

            //Act
            Venue foundVenue = Venue.Find(testVenue.GetId());

            //Assert
            Assert.Equal(testVenue, foundVenue);
        }

        [Fact]
        public void Test_AddBand_AddsBandToVenue()
        {
          //Arrange
          Venue testVenue = new Venue("The Gorge");
          testVenue.Save();

          Band testBand = new Band("Keith Urban");
          testBand.Save();

          Band testBand2 = new Band("Rascal Flatts");
          testBand2.Save();

          //Act
          testVenue.AddBand(testBand);
          testVenue.AddBand(testBand2);

          List<Band> result = testVenue.GetBands();
          List<Band> testList = new List<Band>{testBand, testBand2};

          //Assert
          Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_GetBands_ReturnsAllVenueBands()
        {
          //Arrange
          Venue testVenue = new Venue("The Gorge");
          testVenue.Save();

          Band testBand1 = new Band("Keith Urban");
          testBand1.Save();

          Band testBand2 = new Band("Rascal Flatts");
          testBand2.Save();

          //Act
          testVenue.AddBand(testBand1);
          List<Band> savedBands = testVenue.GetBands();
          List<Band> testList = new List<Band> {testBand1};

          //Assert
          Assert.Equal(testList, savedBands);
        }

        [Fact]
        public void Test_Delete_DeletesVenueFromDatabase()
        {
          //Arrange
          string name1 = "The Gorge";
          Venue testVenue1 = new Venue(name1);
          testVenue1.Save();

          string name2 = "White River Ampitheater";
          Venue testVenue2 = new Venue(name2);
          testVenue2.Save();

          //Act
          testVenue1.Delete();
          List<Venue> resultVenues = Venue.GetAll();
          List<Venue> testVenueList = new List<Venue> {testVenue2};

          //Assert
          Assert.Equal(testVenueList, resultVenues);
        }

        public void Dispose()
        {
          Band.DeleteAll();
          Venue.DeleteAll();
        }
    }
}
