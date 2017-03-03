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
            // Get["/venues"] = _ = {
            //     List<Venue> AllVenues = Venue.GetAll();
            //     return View["venues.cshtml", AllVenues];
            // };
            // Get["/bands"] = _ = {
            //     List<Band> AllBands = Band.GetAll();
            //     return View["bands.cshtml", AllBands];
            // };
        }
    }
}
