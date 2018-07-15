using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SalutemData
{
    public class AppointmentData
    {
        //atributos
        private string connectionString;

        public AppointmentData(string conn)
        {
            this.connectionString = conn;
        }

        /**/
        public string validateDateData(string date, int hour)
        {
            string message = "";

            try
            {
                int quantity = 0;

                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_validateAvailabilityOfTheDate";

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

        /**/
        public string insertAppointmentData(Appointment appointment, Userr user)
        {
            string message = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_insertAppoinment";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@date", appointment.date));
                cmd.Parameters.Add(new SqlParameter("@hour", appointment.hour));
                cmd.Parameters.Add(new SqlParameter("@identityCard", user.identityCard));

                SqlParameter parameterId = new SqlParameter("@id", SqlDbType.Int);
                parameterId.Direction = ParameterDirection.Output;

                //Se asignan los parametros
                cmd.Parameters.Add(parameterId);

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                string appointmentId = cmd.Parameters["@id"].Value.ToString();

                connection.Close();

                message = appointmentId;

            }
            catch (Exception ex)
            {
                message = "Error al ejecutar la operación en la base de datos";
            }

            return message;
        }

        /**/
        public string updateAppointmentData(Appointment appointment, Userr user, string oldDate, string oldHour)
        {
            string message = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_updateAppoinment"; 

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@identityCard", user.identityCard));
                cmd.Parameters.Add(new SqlParameter("@date", appointment.date));
                cmd.Parameters.Add(new SqlParameter("@hour", appointment.hour));
                cmd.Parameters.Add(new SqlParameter("@oldDate", oldDate));
                cmd.Parameters.Add(new SqlParameter("@oldHour", oldHour));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                connection.Close();

                message = "La operación se realizo satisfactoriamente";
            }
            catch (Exception ex)
            {
                message = "Error al ejecutar la operación en la base de datos";
            }

            return message;
        }

        /**/
        public string cancelAppointmentData(Appointment appointment)
        {
            string message = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_cancelAppoinment";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@appointment_id", appointment.id));
                cmd.Parameters.Add(new SqlParameter("@date", appointment.date));
                cmd.Parameters.Add(new SqlParameter("@hour", appointment.hour));

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
        public string cancelAppointmentWithoutAppointmentIdData(Appointment appointment, Userr user)
        {
            string message = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_cancelAppoinmentWithoutAppointmentId";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@identityCard", user.identityCard));
                cmd.Parameters.Add(new SqlParameter("@date", appointment.date));
                cmd.Parameters.Add(new SqlParameter("@hour", appointment.hour));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                connection.Close();

                message = "La operación se realizo satisfactoriamente";

            }
            catch (Exception ex)
            {
                message = "Error al ejecutar la operación en la base de datos";
            }

            return message;
        }

        public List<Appointment> getAllAppointmentsData()
        {
            List<Appointment> appointmentList = new List<Appointment>();
            string finalDate = "", date = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_getAllAppointments";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Appointment appo = new Appointment();

                    date = reader["date"].ToString();

                    string[] dateArray = date.Split(' ');
                    string[] formatDate = dateArray[0].Split('/');

                    finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

                    appo.id = Convert.ToInt32(reader["id"].ToString());
                    appo.date = finalDate;
                    appo.hour = Convert.ToInt32(reader["hour"].ToString());
                    appo.status = reader["status"].ToString();
                    appo.user = new Userr(reader["identityCard"].ToString(), reader["name"].ToString());

                    appointmentList.Add(appo);
                }

                connection.Close();
            }
            catch (Exception ex)
            {

                return appointmentList;
            }
           
            return appointmentList;
        }

        public List<Appointment> getAllAppointmentsDataFilters(string identityCard)
        {
            List<Appointment> appointmentList = new List<Appointment>();
            string finalDate = "", date = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "[sp_getAllAppointmentsFilters]";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@identityCard", identityCard));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Appointment appo = new Appointment();

                    date = reader["date"].ToString();

                    string[] dateArray = date.Split(' ');
                    string[] formatDate = dateArray[0].Split('/');

                    finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

                    appo.id = Convert.ToInt32(reader["id"].ToString());
                    appo.date = finalDate;
                    appo.hour = Convert.ToInt32(reader["hour"].ToString());
                    appo.status = reader["status"].ToString();
                    appo.user = new Userr(reader["identityCard"].ToString(), reader["name"].ToString());

                    appointmentList.Add(appo);
                }

                connection.Close();
            }
            catch (Exception ex)
            {

                return appointmentList;
            }

            return appointmentList;
        }

        public List<Appointment> getAppointmentByIdentityCardData(string identityCard)
        {
            List<Appointment> appointmentList = new List<Appointment>();
            string finalDate = "", date = "";

            try
            {
                //establecemos la conexion
                SqlConnection connection = new SqlConnection(this.connectionString);

                String sql = "";

                sql = "sp_getAppointmentByIdentityCard";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@identityCard", identityCard));

                SqlDataReader reader;
                connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Appointment appo = new Appointment();

                    date = reader["date"].ToString();

                    string[] dateArray = date.Split(' ');
                    string[] formatDate = dateArray[0].Split('/');

                    finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

                    appo.id = Convert.ToInt32(reader["id"].ToString());
                    appo.date = finalDate;
                    appo.hour = Convert.ToInt32(reader["hour"].ToString());
                    appo.status = reader["status"].ToString();
                    appo.user = new Userr(reader["identityCard"].ToString(), reader["name"].ToString());

                    appointmentList.Add(appo);
                }

                connection.Close();
            }
            catch (Exception ex)
            {

                return appointmentList;
            }

            return appointmentList;
        }
    }
}
