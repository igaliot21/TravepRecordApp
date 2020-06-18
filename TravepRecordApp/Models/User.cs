using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravepRecordApp.Models
{
    public class User
    {
        private int id;
        private string email;
        private string password;

        public User() { }
        public User(string Email, string Password) {
            this.email = Email;
            this.password = Password;
        }
        [PrimaryKey]
        [AutoIncrement]
        public int Id{
            get { return this.id; }
            set { this.id = value; }
        }
        [MaxLength(255)]
        public string Email{
            get { return this.email; }
            set { this.email = value; }
        }
        [MaxLength(255)]
        public string Password{
            get { return this.password; }
            set { this.password = value; }
        }
    }
}
