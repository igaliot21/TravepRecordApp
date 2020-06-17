using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravepRecordApp.Models
{
    public class Post
    {
        private int id;
        private string experience;
        private string venue_name;
        private string venue_address;
        private double venue_latitude;
        private double venue_longitude;
        private string venue_categoryid;
        private string venue_categoryname;

        public Post() { }
        public Post(string Experience) {
            this.experience = Experience;
        }
        public Post(string Experience, string VenueName, string VenueAddress, double VenueLatitude, double VenueLongitude, string VenueCategoryId, string VenueCategoryName){
            this.experience         = Experience;
            this.venue_name         = VenueName;
            this.venue_address      = VenueAddress;
            this.venue_latitude     = VenueLatitude;
            this.venue_longitude    = VenueLongitude;
            this.venue_categoryid   = VenueCategoryId;
            this.venue_categoryname = VenueCategoryName;
        }

        [PrimaryKey]
        [AutoIncrement]
        public int Id{
            get { return this.id; }
            set { this.id = value; }
        }
        [MaxLength(255)]
        public string Experience{
            get { return this.experience; }
            set { this.experience = value; }
        }
        [MaxLength(255)]
        public string VenueName {
            get { return this.venue_name; }
            set { this.venue_name = value; }
        }
        [MaxLength(255)]
        public string VenueAddress{
            get { return this.venue_address; }
            set { this.venue_address = value; }
        }
        public double VenueLatitude{
            get { return this.venue_latitude; }
            set { this.venue_latitude = value; }
        }
        public double VenueLongitude{
            get { return this.venue_longitude; }
            set { this.venue_longitude = value; }
        }
        [MaxLength(255)]
        public string VenueCategoryId{
            get { return this.venue_categoryid; }
            set { this.venue_categoryid = value; }
        }
        [MaxLength(255)]
        public string VenueCategoryName{
            get { return this.venue_categoryname; }
            set { this.venue_categoryname = value; }
        }
    }
}
