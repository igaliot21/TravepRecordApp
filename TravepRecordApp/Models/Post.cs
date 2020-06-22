using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravepRecordApp.Models
{
	public class Post : INotifyPropertyChanged
	{
		private int id;
		private string email;
		private string experience;
		private DateTimeOffset experiencdedate;
		private string venue_name;
		private string venue_address;
		private double venue_latitude;
		private double venue_longitude;
		private string venue_categoryid;
		private string venue_categoryname;

        public event PropertyChangedEventHandler PropertyChanged;

        public Post() { }
		public Post(string Experience) {
			this.experience = Experience;
		}
		public Post(string Experience, DateTimeOffset ExperienceDate)
		{
			this.experience = Experience;
			this.experiencdedate = ExperienceDate;
		}
		public Post(string Experience, string Email, string VenueName, string VenueAddress, double VenueLatitude, double VenueLongitude, string VenueCategoryId, string VenueCategoryName){
			this.experience         = Experience;
			this.email              = Email;
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
			set { 
				this.id = value;
				OnPropertyChanged("Id");
			}
		}
		[MaxLength(255)]
		public string Experience{
			get { return this.experience; }
			set { 
				this.experience = value;
				OnPropertyChanged("Experience");
			}
		}
		public DateTimeOffset ExperienceDate
		{
			get { return this.experiencdedate; }
			set{
				this.experiencdedate = value;
				OnPropertyChanged("ExperienceDate");
			}
		}
		[MaxLength(255)]
		public string Email
		{
			get { return this.email; }
			set { 
				this.email = value;
				OnPropertyChanged("Email");
			}
		}
		[MaxLength(255)]
		public string VenueName {
			get { return this.venue_name; }
			set { 
				this.venue_name = value;
				OnPropertyChanged("VenueName");
			}
		}
		[MaxLength(255)]
		public string VenueAddress{
			get { return this.venue_address; }
			set { 
				this.venue_address = value;
				OnPropertyChanged("VenueAddress");
			}
		}
		public double VenueLatitude{
			get { return this.venue_latitude; }
			set { 
				this.venue_latitude = value;
				OnPropertyChanged("VenueLatitude");
			}
		}
		public double VenueLongitude{
			get { return this.venue_longitude; }
			set {
				this.venue_longitude = value;
				OnPropertyChanged("VenueLongitude");
			}
		}
		[MaxLength(255)]
		public string VenueCategoryId{
			get { return this.venue_categoryid; }
			set { 
				this.venue_categoryid = value;
				OnPropertyChanged("VenueCategoryId");
			}
		}
		[MaxLength(255)]
		public string VenueCategoryName{
			get { return this.venue_categoryname; }
			set { 
				this.venue_categoryname = value;
				OnPropertyChanged("VenueCategoryName");
			}
		}
		public static int Insert(SQLiteConnection Connection, Post PostToInsert){
			Connection.CreateTable<Post>();
			int rows = Connection.Insert(PostToInsert); //this returns the number of rows inserted
			return rows;
		}
		public static int Delete(SQLiteConnection Connection, Post PostToDelete){
			Connection.CreateTable<Post>();
			int rows = Connection.Delete(PostToDelete); //this returns the number of rows deleted
			return rows;
		}
		public static List<Post> RetrievePost(SQLiteConnection Connection, string UserEmail) {
			Connection.CreateTable<Post>();
			List<Post> posts = Connection.Table<Post>().Where(p => p.Email == UserEmail).ToList();
			return posts;
		}
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
