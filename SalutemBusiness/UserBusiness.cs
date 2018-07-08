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

        public SalutemDomain.Userr getUserData(string identityCard) {
            return this.userData.getUserData(identityCard);
        }

        public SalutemDomain.Userr getUserData(string email, string password) {
            return this.userData.getUserDataLogin(email, password);
        }

        public string getRoleForUserBusiness(string email, string password)
        {
            string rol = "";

            rol = this.userData.getRoleForUserData(email, password);

            return rol;
        }
    }
}
