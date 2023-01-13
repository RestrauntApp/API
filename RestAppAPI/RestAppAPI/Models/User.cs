﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAppAPI.Models
{
    public class User
    {
        [Key, Column("UserId")]
        public int id { get; set; }

        [Column("UserName")]
        public string name { get; set; }

        [Column("UserEmail")]
        public string email { get; set; }

        [Column("UserPass")]   
        public string password { get; set; }

        public User() { }

        public User (string email,string password)
        {
            this.email = email; 
            this.password = password;   
        }

        public User ( string name, string email, string password)
        {
           
            this.name = name;
            this.email = email;
            this.password = password;
        }

        public User (int id, string name, string email, string password)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
        }
    }
}
