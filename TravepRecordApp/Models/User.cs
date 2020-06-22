using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TravepRecordApp.Models
{
    public class User : INotifyPropertyChanged
    {
        private int id;
        private string email;
        private string password;
        private string confirmpassword;

        public event PropertyChangedEventHandler PropertyChanged;

        public User() { }
        public User(string Email, string Password){
            this.email = Email;
            this.password = Password;
        }
        public User(string Email, string Password, string ConfirmPassword) {
            this.email = Email;
            this.password = Password;
            this.confirmpassword = ConfirmPassword;
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
        public string Email{
            get { return this.email; }
            set { 
                this.email = value;
                OnPropertyChanged("Email");
            }
        }
        [MaxLength(255)]
        public string Password{
            get { return this.password; }
            set { 
                this.password = value;
                OnPropertyChanged("Password");
            }
        }
        [MaxLength(255)]
        public string ConfirmPassword{
            get { return this.confirmpassword; }
            set{
                this.confirmpassword = value;
                OnPropertyChanged("ConfirmPassword");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
        public static int Insert(SQLiteConnection Connection, User UserToInsert) {
            Connection.CreateTable<User>();
            int rows = Connection.Insert(UserToInsert); //this returns the number of rows inserted
            return rows;
        }
    }
}
