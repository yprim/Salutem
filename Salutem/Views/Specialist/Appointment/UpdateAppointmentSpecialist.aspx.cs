using SalutemBusiness;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views.Specialist
{
    public partial class UpdateAppointmentSpecialist : System.Web.UI.Page
    {
        #region
        private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        private AppointmentBusiness appointmentBusiness = null;
        private Appointment appo = null;
        private Userr user = null;
        private static string finalDate = "";
        private string validateMessage = "", operationMessage = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtIdentityCard.Text = Request["identityCard"];
                txtActualHour.Text = Request["hour"];

                clRecipeDate.TodaysDate = Convert.ToDateTime(Request["date"]);
                clRecipeDate.SelectedDate = clRecipeDate.TodaysDate;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string date = clRecipeDate.SelectedDate.ToShortDateString();
            string[] dateArray = date.Split(' ');
            string[] formatDate = dateArray[0].Split('/');

            finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

            //Se valida la fecha
            validateMessage = validateDate(finalDate, Convert.ToInt32(txtActualHour.Text));

            if (validateMessage == "Disponible")
            {

                this.appointmentBusiness = new AppointmentBusiness(this.conn);

                this.appo = new Appointment(Convert.ToInt32(txtActualHour.Text), finalDate);
                this.user = new Userr(txtIdentityCard.Text);

                //Se guarda un mensaje basado en la operación que se realizo
                operationMessage = this.appointmentBusiness.updateAppointmentBusiness(this.appo, this.user);

                txtMensaje.Text = operationMessage;
            }
            else
            {
                txtMensaje.Text = validateMessage;
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