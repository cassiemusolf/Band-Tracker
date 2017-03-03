using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace BandTracker
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                return View["index.cshtml"];
            };
            Get["/bands"] = _ => {
              List<Band> AllBands = Band.GetAll();
              return View["bands.cshtml", AllBands];
            };
            Get["/venues"] = _ => {
              List<Venue> AllVenues = Venue.GetAll();
              return View["venues.cshtml", AllVenues];
            };
            Get["/bands/new"] = _ => {
                List<Venue> AllVenues = Venue.GetAll();
                return View["bands_form.cshtml", AllVenues];
            };
            Post["/bands"] = _ => {
                Band newBand = new Band(Request.Form["band-name"]);
                newBand.Save();
                newBand.AddVenue(Venue.Find(Request.Form["venue-id"]));
                List<Band> AllBands = Band.GetAll();
                return View["bands.cshtml", AllBands];
            };
            Get["/venues/new"] = _ => {
                List<Band> AllBands = Band.GetAll();
                return View["venues_form.cshtml", AllBands];
            };
            Post["/venues"] = _ => {
                Venue newVenue = new Venue(Request.Form["venue-name"]);
                newVenue.Save();
                newVenue.AddBand(Band.Find(Request.Form["band-id"]));
                List<Venue> AllVenues = Venue.GetAll();
                return View["venues.cshtml", AllVenues];
            };

            Get["/bands/{id}"] = parameters => {
              Dictionary<string, object> model = new Dictionary<string, object>();
              var SelectedBand = Band.Find(parameters.id);
              var VenueBand = SelectedBand.GetVenues();
              model.Add("bands", SelectedBand);
              model.Add("venues", VenueBand);
              return View["band.cshtml", model];
            };

            Get["/venues/{id}"] = parameters => {
              Dictionary<string, object> model = new Dictionary<string, object>();
              var SelectedVenue = Venue.Find(parameters.id);
              var VenueBand = SelectedVenue.GetBands();
              model.Add("venues", SelectedVenue);
              model.Add("bands", VenueBand);
              return View["venue.cshtml", model];
            };

            Get["/venue/edit/{id}"] = parameters => {
                Venue SelectedVenue = Venue.Find(parameters.id);
                return View["venue_edit.cshtml", SelectedVenue];
            };

            Patch["/venue/edit/{id}"] = parameters => {
                Venue SelectedVenue = Venue.Find(parameters.id);
                 SelectedVenue.Update(Request.Form["venue-name"]);
                List<Venue> AllVenues = Venue.GetAll();
                return View["venues.cshtml", AllVenues];
            };

            Post["/venues/delete"] = _ => {
                Venue.DeleteAll();
                List<Venue> AllVenues = Venue.GetAll();
                return View["venues.cshtml", AllVenues];
            };
            Post["/bands/delete"] = _ => {
                Band.DeleteAll();
                List<Band> AllBands = Band.GetAll();
                return View["bands.cshtml", AllBands];
            };
            Get["venue/delete/{id}"] = parameters => {
               Venue SelectedVenue = Venue.Find(parameters.id);
               return View["venue_delete.cshtml", SelectedVenue];
           };
           Delete["venue/delete/{id}"] = parameters => {
               Venue SelectedVenue = Venue.Find(parameters.id);
               SelectedVenue.Delete();
               List<Venue> AllVenues = Venue.GetAll();
               return View["venues.cshtml", AllVenues];
           };

        }
    }
}
