using SalutemData;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalutemBusiness
{
    public class UserBusiness
    {
        //atributos
        private string connectionString;
        UserData userData;

        public UserBusiness(string conn)
        {
            this.connectionString = conn;
            userData = new UserData(this.connectionString);
        }

        public string getRoleForUserBusiness(string email, string password)
        {
            string rol = "";

            rol = this.userData.getRoleForUserData(email, password);

            return rol;
        }
    }
}
