using System;
using System.Collections.Generic;
using System.Text;

namespace SalutemDomain
{
    public class Userr
    {
        public int id { get; set; }
        public string identityCard { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public int age { get; set; }
        public string user_address { get; set; }
        public string position { get; set; }
        public string rol { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public Userr() { }

        public Userr(string identityCard)
        {
            this.identityCard = identityCard;
        }
        public Userr(string identityCard, string name)
        {
            this.identityCard = identityCard;
            this.name = name;
        }
    }
}
