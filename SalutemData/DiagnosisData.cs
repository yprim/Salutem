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
        #region 
        //atributos
        private string connectionString;
        #endregion

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
        public string updateDiagnosisWithoutDiagnosisIdData(Diagnosis diagnosis, Userr user, string oldDate, string oldHour)
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
                cmd.Parameters.Add(new SqlParameter("@oldDate", oldDate));
                cmd.Parameters.Add(new SqlParameter("@oldHour", oldHour));

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

        public List<Diagnosis> getAllDiagnosisData()
        {
            List<Diagnosis> diagnosisList = new List<Diagnosis>();
            string finalDate = "", date = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "[sp_getAllDiagnosis]";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Diagnosis diag = new Diagnosis();

                    date = reader["date"].ToString();

                    string[] dateArray = date.Split(' ');
                    string[] formatDate = dateArray[0].Split('/');

                    finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

                    diag.id = Convert.ToInt32(reader["id"].ToString());
                    diag.date = finalDate;
                    diag.hour = Convert.ToInt32(reader["hour"].ToString());
                    diag.status = reader["status"].ToString();
                    diag.description = reader["description"].ToString();
                    diag.userName = reader["name"].ToString();
                    diag.identityCard = Convert.ToInt32(reader["identityCard"].ToString());

                    diagnosisList.Add(diag);
                }

                connection.Close();
            }
            catch (Exception ex)
            {

                return diagnosisList;
            }

            return diagnosisList;
        }

        public List<Diagnosis> getDiagnosisDataFilters(string identityCard)
        {
            List<Diagnosis> diagnosisList = new List<Diagnosis>();
            string finalDate = "", date = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "[sp_getDiagnosisFilter]";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@identityCard", identityCard));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Diagnosis diag = new Diagnosis();

                    date = reader["date"].ToString();

                    string[] dateArray = date.Split(' ');
                    string[] formatDate = dateArray[0].Split('/');

                    finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

                    diag.id = Convert.ToInt32(reader["id"].ToString());
                    diag.date = finalDate;
                    diag.hour = Convert.ToInt32(reader["hour"].ToString());
                    diag.status = reader["status"].ToString();
                    diag.description = reader["description"].ToString();
                    diag.userName = reader["name"].ToString();
                    diag.identityCard = Convert.ToInt32(reader["identityCard"].ToString());

                    diagnosisList.Add(diag);
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                return diagnosisList;
            }

            return diagnosisList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public string validateDateData(string date, int hour)
        {
            string message = "";

            try
            {
                int quantity = 0;

                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_validateAvailabilityOfTheDateDiagnosis";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@date", date));
                cmd.Parameters.Add(new SqlParameter("@hour", hour));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    quantity = Convert.ToInt32(reader["total"].ToString());

                }

                connection.Close();

                //Valida si la fecha esta o no disponible
                if (quantity > 0)
                {
                    message = "La fecha y hora solicitadas no estan disponibles";
                }
                else
                {
                    message = "Disponible";
                }
            }
            catch (Exception ex)
            {
                message = ex.ToString();
            }

            return message;
        }

    }
}
