using SalutemBusiness;
using SalutemDomain;
using System;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views.Assistant
{
    public partial class InsertAppointment : System.Web.UI.Page
    {
        #region
        private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        private AppointmentBusiness appointmentBusiness = null;
        private UserBusiness userBusiness = null;
        private SalutemDomain.Appointment appo = null;
        private Userr user = null;
        private static string finalDate = "";
        private string validateMessage = "", operationMessage = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //================================================================
            //Navigation
            //================================================================
            menuAppointmentInsert.HRef = "~/Views/Assistant/InsertAppointment.aspx";
            menuAppointmentCancel.HRef = "~/Views/Assistant/SearchAppointmentCancel.aspx";
            menuAppointmentUpdate.HRef = "~/Views/Assistant/SearchAppointmentUpdate.aspx";
            menuAppointmentGetRecipes.HRef = "~/Views/Assistant/SearchRecipesGeneral.aspx";
            menuClient.HRef = "~/Views/Assistant/Reports/ReportNumberUsersPerDay.aspx";
            menuSchedule1.HRef = "~/Views/Assistant/Reports/ScheduleReportWithTheMostvisits.aspx";
            menuSchedule2.HRef = "~/Views/Assistant/Reports/ScheduleReportWithTheSmallestNumberOfVisits.aspx";
            menuAppointmentGet.HRef = "~/Views/Assistant/SearchAppointmentGeneral.aspx";
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

                string m = Session["rol"].ToString();
                switch (Session["rol"])
                {
                    case "Specialist":
                        Response.Redirect("../CredentialsError.aspx");
                        break;
                    case "Assistant":
                        menuAppointmentInsert.Visible = true;
                        menuAppointmentCancel.Visible = true;
                        menuAppointmentUpdate.Visible = true;
                        menuAppointmentGetRecipes.Visible = true;
                        menuClient.Visible = true;
                        menuSchedule1.Visible = true;
                        menuSchedule2.Visible = true;
                        menuAppointmentGet.Visible = true;
                        break;
                    case "Collaborator":
                        Response.Redirect("../CredentialsError.aspx");
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
                this.user = this.userBusiness.getUserData(Session["identityCard"].ToString());

                if (this.user.errorMessage != null && this.user.errorMessage != "")
                {
                    //txtMensaje.Text = this.user.errorMessage;
                    return;
                }
                if (this.user.name == null || this.user.name == "")
                {
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

            this.appo = new SalutemDomain.Appointment(Convert.ToInt32(txtId.Text), Convert.ToInt32(txtHour.Text), finalDate);
            this.user = new Userr(Session["identityCard"].ToString());

            //Se guarda un mensaje basado en la operación que se realizo
            operationMessage = this.appointmentBusiness.cancelAppointmentBusiness(this.appo);

            //Se valida que la operación sea exitosa
            if (operationMessage != "Error al ejecutar la operación en la base de datos")
            {
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