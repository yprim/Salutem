using Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class AppointmentBusiness
    {
        //atributos
        private string connectionString;
        private AppointmentData appointmentData;

        public AppointmentBusiness(string conn)
        {
            this.connectionString = conn;
            appointmentData = new AppointmentData(this.connectionString);
        }

        /*public void validateDateBusiness(string date)
        {
            appointmentData.validateDateData(date);
        }*/

        public string validateDateBusiness(string date)
        {

            //conexion con la bd
            SqlConnection sqlConn = new SqlConnection(this.connectionString);

            //string sql
            string sqlSelect = "Select *From Appointment";

            //establecer la conexion con el adaptador
            SqlDataAdapter sqlDataAdapterGender = new SqlDataAdapter();

            //configurar el adaptador
            sqlDataAdapterGender.SelectCommand = new SqlCommand();
            sqlDataAdapterGender.SelectCommand.CommandText = sqlSelect;
            sqlDataAdapterGender.SelectCommand.Connection = sqlConn;

            //definir el data set
            DataSet datasetGenders = new DataSet();

            //dataset para guardar los resultados de la consulta
            sqlDataAdapterGender.Fill(datasetGenders, "EVENTT");

            //cerrar la conexion con el adaptador
            sqlDataAdapterGender.SelectCommand.Connection.Close();

            return "";
        }
    }
}
