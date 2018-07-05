using System;

namespace SalutemDomain
{
    public class Appointment
    {
        public int id { get; set; }
        public string date { get; set; }
        public int hour { get; set; }

        public string status { get; set; }
        public Userr user { get; set; }

        public Appointment() { }

        public Appointment(int hour, string date)
        {
            this.hour = hour;
            this.date = date;
        }

        public Appointment(int id, int hour, string date)
        {
            this.id = id;
            this.hour = hour;
            this.date = date;
        }
    }
}
