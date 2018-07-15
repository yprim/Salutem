using SalutemBusiness;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views.User
{
    public partial class UpdateAppointment : System.Web.UI.Page
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
                txtHour.Text = Request["hour"];
                txtIdentityCard.Text = Request["identityCard"];

                clDate.TodaysDate = Convert.ToDateTime(Request["date"]);
                clDate.SelectedDate = clDate.TodaysDate;
            }

            //================================================================
            //Navigation
            //================================================================
            menuAppointmentInsert.HRef = "~/Views/Collaborator/InsertAppointment.aspx";
            menuAppointmentCancel.HRef = "~/Views/Collaborator/SearchAppointmentCancel.aspx";
            menuAppointmentUpdate.HRef = "~/Views/Collaborator/SearchAppointmentUpdate.aspx";
            menuAppointmentGet.HRef = "~/Views/Collaborator/SearchAppointmentGeneral.aspx";
            //================================================================

            //================================================================
            //Roles
            //================================================================
            try
            {
                if (string.IsNullOrEmpty((string)Session["rol"]))
                {
                    Session["rol"] = "NoRolSet";
                }
                switch (Session["rol"])
                {
                    case "Specialist":
                        Response.Redirect("../CredentialsError.aspx");
                        break;
                    case "Assistant":
                        Response.Redirect("../CredentialsError.aspx");
                        break;
                    case "Collaborator":
                        menuAppointmentInsert.Visible = true;
                        menuAppointmentCancel.Visible = true;
                        menuAppointmentUpdate.Visible = true;
                        break;
                    default:
                        Response.Redirect("../UrlError.aspx");
                        break;
                }
            }
            catch
            {
            }
            //================================================================
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string date = clDate.SelectedDate.ToShortDateString();
            string[] dateArray = date.Split(' ');
            string[] formatDate = dateArray[0].Split('/');

            finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

            //Se valida la fecha
            validateMessage = validateDate(finalDate, Convert.ToInt32(txtHour.Text));

            if (validateMessage == "Disponible")
            {
                this.appointmentBusiness = new AppointmentBusiness(this.conn);

                this.appo = new Appointment(Convert.ToInt32(txtHour.Text), finalDate);
                this.user = new Userr(txtIdentityCard.Text);

                //Se guarda un mensaje basado en la operación que se realizo
                operationMessage = this.appointmentBusiness.updateAppointmentBusiness(this.appo, this.user, txtOldDate.Text, txtOldHour.Text);

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