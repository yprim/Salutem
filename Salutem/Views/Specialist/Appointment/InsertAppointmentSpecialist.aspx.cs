using SalutemBusiness;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views.Specialist
{
    public partial class InsertAppointmentSpecialist : System.Web.UI.Page
    {
        #region
        private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        private AppointmentBusiness appointmentBusiness = null;
        private UserBusiness userBusiness = null;
        private Appointment appo = null;
        private Userr user = null;
        private static string finalDate = "";
        private string validateMessage = "", operationMessage = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgendar_Click(object sender, EventArgs e)
        {
            string date = clFechaCita.SelectedDate.ToShortDateString();
            string[] dateArray = date.Split(' ');
            string[] formatDate = dateArray[0].Split('/');

            finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

            //Se valida la fecha
            validateMessage = validateDate(finalDate, Convert.ToInt32(txtHour.Text));

            if (validateMessage == "Disponible")
            {
                this.appointmentBusiness = new AppointmentBusiness(this.conn);

                this.appo = new Appointment(Convert.ToInt32(txtHour.Text), finalDate);
                //this.user = new Userr(txtNumCedula.Text);
                //RSG
                this.userBusiness = new UserBusiness(this.conn);
                this.user = this.userBusiness.getUserData(txtNumCedula.Text);
                if (this.user.errorMessage != null && this.user.errorMessage != "") {
                    txtMensaje.Text = this.user.errorMessage;
                    return;
                }
                if (this.user.name == null || this.user.name == "") {
                    txtMensaje.Text = "El cliente no existe en la base de datos.";
                    return;
                }

                //Se guarda un mensaje basado en la operación que se realizo
                operationMessage = this.appointmentBusiness.insertAppointmentBusiness(this.appo, this.user);

                //Se valida que la operación sea exitosa
                if (operationMessage != "Error al ejecutar la operación en la base de datos")
                {
                    txtId.Text = operationMessage;

                    txtMensaje.Text = "La operación se realizó satisfactoriamente";
                }
                else
                {
                    txtMensaje.Text = operationMessage;
                }
            }
            else
            {
                txtMensaje.Text = validateMessage;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.appointmentBusiness = new AppointmentBusiness(this.conn);

            this.appo = new Appointment(Convert.ToInt32(txtId.Text), Convert.ToInt32(txtHour.Text), finalDate);
            this.user = new Userr(txtNumCedula.Text);

            //Se guarda un mensaje basado en la operación que se realizo
            operationMessage = this.appointmentBusiness.cancelAppointmentBusiness(this.appo);

            //Se valida que la operación sea exitosa
            if (operationMessage != "Error al ejecutar la operación en la base de datos")
            {
                txtId.Text = operationMessage;

                txtMensaje.Text = "La operación se realizo satisfactoriamente";
            }
            else
            {
                txtMensaje.Text = operationMessage;
            }
        }

        private string validateDate(string date, int hour)
        {
            string message = "";

            this.appointmentBusiness = new AppointmentBusiness(this.conn);

            message = appointmentBusiness.validateDateBusiness(date, hour);

            return message;
        }
    }
}