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

        public Post() { }
        public Post(string Experience) {
            this.experience = Experience;
        }

        [PrimaryKey]
        [AutoIncrement]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        [MaxLength(255)]
        public string Experience
        {
            get { return this.experience; }
            set { this.experience = value; }
        }

    }
}
