using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker
{
    public class Venue
    {
        private int _id;
        private string _name;

        public Venue(string Name, int Id = 0)
        {
            _id = Id;
            _name = Name;
        }

        public override bool Equals(System.Object otherVenue)
        {
            if (!(otherVenue is Venue))
            {
                return false;
            }
            else {
                Venue newVenue = (Venue) otherVenue;
                bool idEquality = this.GetId() == newVenue.GetId();
                bool nameEquality = this.GetName() == newVenue.GetName();
                return (idEquality && nameEquality);
            }
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public static List<Venue> GetAll()
        {
            List<Venue> AllVenues = new List<Venue>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int venueId = rdr.GetInt32(0);
                string venueName = rdr.GetString(1);
                Venue newVenue = new Venue(venueName, venueId);
                AllVenues.Add(newVenue);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return AllVenues;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO venues (name) OUTPUT INSERTED.id VALUES (@VenueName);", conn);

            SqlParameter nameParameter = new SqlParameter();
            nameParameter.ParameterName = "@VenueName";
            nameParameter.Value = this.GetName();
            cmd.Parameters.Add(nameParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public static Venue Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM venues WHERE id = @VenueId;", conn);

            SqlParameter venueIdParameter = new SqlParameter();
            venueIdParameter.ParameterName = "@VenueId";
            venueIdParameter.Value = id.ToString();
            cmd.Parameters.Add(venueIdParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            int foundVenueId = 0;
            string foundVenueName = null;

            while(rdr.Read())
            {
                foundVenueId = rdr.GetInt32(0);
                foundVenueName = rdr.GetString(1);
            }
            Venue foundVenue = new Venue(foundVenueName, foundVenueId);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return foundVenue;
        }

        public void AddBand(Band newBand)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO bands_venues (venue_id, band_id) VALUES (@VenueId, @BandId);", conn);
            SqlParameter venueIdParameter = new SqlParameter();
            venueIdParameter.ParameterName = "@VenueId";
            venueIdParameter.Value = this.GetId();
            cmd.Parameters.Add(venueIdParameter);

            SqlParameter bandIdParameter = new SqlParameter();
            bandIdParameter.ParameterName = "@BandId";
            bandIdParameter.Value = newBand.GetId();
            cmd.Parameters.Add(bandIdParameter);

            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }

        public List<Band> GetBands()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT band_id FROM bands_venues WHERE venue_id = @VenueId;", conn);
            SqlParameter venueIdParameter = new SqlParameter();
            venueIdParameter.ParameterName = "@VenueId";
            venueIdParameter.Value = this.GetId();
            cmd.Parameters.Add(venueIdParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            List<int> bandIds = new List<int> {};
            while(rdr.Read())
            {
                int bandId = rdr.GetInt32(0);
                bandIds.Add(bandId);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            List<Band> bands = new List<Band> {};
            foreach (int bandId in bandIds)
            {
                SqlCommand bandQuery = new SqlCommand("SELECT * FROM bands WHERE id = @BandId;", conn);

                SqlParameter bandIdParameter = new SqlParameter();
                bandIdParameter.ParameterName = "@BandId";
                bandIdParameter.Value = bandId;
                bandQuery.Parameters.Add(bandIdParameter);

                SqlDataReader queryReader = bandQuery.ExecuteReader();
                while(queryReader.Read())
                {
                    int thisBandId = queryReader.GetInt32(0);
                    string bandName = queryReader.GetString(1);
                    Band foundBand = new Band(bandName, thisBandId);
                    bands.Add(foundBand);
                }
                if (queryReader != null)
                {
                    queryReader.Close();
                }
            }
            if (conn != null)
            {
                conn.Close();
            }
            return bands;
        }

        public void Update(string newName)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE venues SET name = @NewName OUTPUT INSERTED.name WHERE id = @VenueId;", conn);

            SqlParameter newNameParameter = new SqlParameter();
            newNameParameter.ParameterName = "@NewName";
            newNameParameter.Value = newName;
            cmd.Parameters.Add(newNameParameter);

            SqlParameter idParameter = new SqlParameter();
            idParameter.ParameterName = "@VenueId";
            idParameter.Value = this.GetId();
            cmd.Parameters.Add(idParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                this._name = rdr.GetString(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public void Delete()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM venues WHERE id = @VenueId; DELETE FROM bands_venues WHERE venue_id = @VenueId;", conn);

            SqlParameter venueIdParameter = new SqlParameter();
            venueIdParameter.ParameterName = "@VenueId";
            venueIdParameter.Value = this.GetId();

            cmd.Parameters.Add(venueIdParameter);
            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM venues;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
