using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SalutemData
{
    public class UserData
    {
        private string connectionString;

        public UserData(string conn)
        {
            this.connectionString = conn;
        }

        /// <summary>
        /// Validates if an identityCard already exists
        /// </summary>
        /// <param name="identityCard"></param>
        /// <returns>True or False</returns>
        public SalutemDomain.Userr getUserData(string identityCard) {
            String sql = "sp_getUserr";
            SqlConnection connection = new SqlConnection(this.connectionString);
            SalutemDomain.Userr userInfo = new SalutemDomain.Userr(identityCard);

            try {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@identityCard", identityCard));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    userInfo.id = Convert.ToInt32(reader["id"].ToString());
                    userInfo.name = reader["name"].ToString();
                    userInfo.lastname = reader["lastname"].ToString();
                    userInfo.age = Convert.ToInt32(reader["age"].ToString());
                    userInfo.user_address = reader["user_address"].ToString();
                    userInfo.position = reader["position"].ToString();
                    userInfo.rol = reader["rol"].ToString();
                    userInfo.email = reader["email"].ToString();
                }
            } catch (Exception ex) {
                userInfo.errorMessage = ex.Message;
            } finally {
                connection.Close();
            }

            return userInfo;
        }

        public string getRoleForUserData(string email, string password)
        {
            string message = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_getRoleForUser";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@password", password));

                SqlParameter parameterId = new SqlParameter("@rol", SqlDbType.NVarChar, 50);
                parameterId.Direction = ParameterDirection.Output;

                //Se asignan los parametros
                cmd.Parameters.Add(parameterId);

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                string recipeRole = cmd.Parameters["@rol"].Value.ToString();

                connection.Close();

                message = recipeRole;

            }
            catch (Exception ex)
            {
                message = "Error al ejecutar la operación en la base de datos";
            }

            return message;
        }
    }
}
