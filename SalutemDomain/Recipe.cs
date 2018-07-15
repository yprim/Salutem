using System;
using System.Collections.Generic;
using System.Text;

namespace SalutemDomain
{
    public class Recipe
    {
        public int id { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public int hour { get; set; }
        public string status { get; set; }
        public Userr user { get; set; }

        public Recipe() { }

        public Recipe(string description, string date, int hour)
        {
            this.description = description;
            this.date = date;
            this.hour = hour;
        }

        public Recipe(string description)
        {
            this.description = description;
        }

        public Recipe(int id, int hour, string date)
        {
            this.id = id;
            this.hour = hour;
            this.date = date;
        }
    }
}
