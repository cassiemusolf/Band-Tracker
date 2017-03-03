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
        }
    }
}
