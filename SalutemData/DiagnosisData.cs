using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SalutemData
{
    public class DiagnosisData
    {
        //atributos
        private string connectionString;

        public DiagnosisData(string conn)
        {
            this.connectionString = conn;
        }

        /**/
        public string insertDiagnosisData(Diagnosis diagnosis, Userr user)
        {
            string message = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_insertDiagnosis";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@identityCard", user.identityCard));
                cmd.Parameters.Add(new SqlParameter("@description", diagnosis.description));
                cmd.Parameters.Add(new SqlParameter("@date", diagnosis.date));
                cmd.Parameters.Add(new SqlParameter("@hour", diagnosis.hour));

                SqlParameter parameterId = new SqlParameter("@getRecipeId", SqlDbType.Int);
                parameterId.Direction = ParameterDirection.Output;

                //Se asignan los parametros
                cmd.Parameters.Add(parameterId);

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                string recipeId = cmd.Parameters["@getRecipeId"].Value.ToString();

                connection.Close();

                message = recipeId;

            }
            catch (Exception ex)
            {
                message = "Error al ejecutar la operación en la base de datos";
            }

            return message;
        }

        /**/
        public string deleteDiagnosisData(int id)
        {
            string message = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_deleteDiagnosis";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@idDiagnostic",id));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                connection.Close();

                message = "La operación se realizo adecuadamente";

            }
            catch (Exception ex)
            {
                message = "Error al ejecutar la operación en la base de datos";
            }

            return message;
        }

        /**/
        public string deleteDiagnosisWithoutDiagnosisIdData(Diagnosis diagnosis, Userr user)
        {
            string message = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_deleteDiagnosisWithoutDiagnosisId";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@date", diagnosis.date));
                cmd.Parameters.Add(new SqlParameter("@hour", diagnosis.hour));
                cmd.Parameters.Add(new SqlParameter("@identityCard", user.identityCard));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                connection.Close();

                message = "La operación se realizo adecuadamente";

            }
            catch (Exception ex)
            {
                message = "Error al ejecutar la operación en la base de datos";
            }

            return message;
        }

        /**/
        public string updateDiagnosisWithoutDiagnosisIdData(Diagnosis diagnosis, Userr user)
        {
            string message = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_updateDiagnosis";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@identityCard", user.identityCard));
                cmd.Parameters.Add(new SqlParameter("@description", diagnosis.description));
                cmd.Parameters.Add(new SqlParameter("@date", diagnosis.date));
                cmd.Parameters.Add(new SqlParameter("@hour", diagnosis.hour));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                connection.Close();

                message = "La operación se realizo adecuadamente";

            }
            catch (Exception ex)
            {
                message = "Error al ejecutar la operación en la base de datos";
            }

            return message;
        }
    }
}
