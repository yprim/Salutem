using System;
using System.Collections.Generic;
using System.Text;

namespace SalutemDomain
{
    public class Diagnosis
    {
        public int id { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public int hour { get; set; }

        public Diagnosis() { }

        public Diagnosis(string description, string date, int hour)
        {
            this.description = description;
            this.date = date;
            this.hour = hour;
        }

        public Diagnosis(string date, int hour)
        {
            this.date = date;
            this.hour = hour;
        }
    }
}
