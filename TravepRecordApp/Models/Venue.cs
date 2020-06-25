﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravepRecordApp.Helpers;

namespace TravepRecordApp.Models
{
    public class VenueRoot{
        public Response response { get; set; }
        public static string GenerateURL(string API_Url, string APICLientId, string APIClientSecret, double latitude, double longitude) {
            return string.Format(API_Url, latitude.ToString().Replace(",","."),longitude.ToString().Replace(",", "."), APICLientId, APIClientSecret, DateTime.Now.ToString("yyyyMMdd"));
        }
    }
    public class Response{
        public IList<Venue> venues { get; set; }
    }
    public class Venue{
        public string id { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public IList<Category> categories { get; set; }
        public async static Task<List<Venue>> GetVenues(double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();
            string url = VenueRoot.GenerateURL(Constants.FQ_VENUE_SEARCH,Constants.FQ_CLIENT_ID,Constants.FQ_CLIENT_SECRET, latitude, longitude);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(json);

                venues = venueRoot.response.venues as List<Venue>;
            }
            return venues;
        }
    }
    public class Location{
        public string address { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public int distance { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public IList<string> formattedAddress { get; set; }
        public string neighborhood { get; set; }
        public string crossStreet { get; set; }
    }
    public class Category{
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public bool primary { get; set; }
    }
}
