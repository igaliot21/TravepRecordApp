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
        public static User RetrieveUser(SQLiteConnection Connection, string UserEmail, string Password) {
            Connection.CreateTable<User>();
            User user = Connection.Table<User>().ToList().Find(u => u.Email == UserEmail && u.Password == Password);
            return user;         
        }
        public static User RetrieveUser(SQLiteConnection Connection, string UserEmail)
        {
            Connection.CreateTable<User>();
            User user = Connection.Table<User>().ToList().Find(u => u.Email == UserEmail);
            return user;
        }
        public static int Insert(SQLiteConnection Connection, string UserEmail, string Password) {
            User user = new User(UserEmail, Password);
            Connection.CreateTable<User>();
            int rows = Connection.Insert(user); //this returns the number of rows inserted
            return rows;
        }
    }
}
