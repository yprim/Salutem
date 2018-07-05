using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public class AppointmentData
    {
        //atributos
        private string connectionString;

        public AppointmentData(string conn)
        {
            this.connectionString = conn;
        }

        public string validateDateData(string date) {

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
