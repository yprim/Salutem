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
            //Cita
            menuAppointmentInsert.HRef = "~/Views/Specialist/Appointment/InsertAppointmentSpecialist.aspx";
            menuAppointmentCancel.HRef = "~/Views/Specialist/Appointment/SearchAppointmentSpecialistCancel.aspx";
            menuAppointmentUpdate.HRef = "~/Views/Specialist/Appointment/SearchAppointmentSpecialistUpdate.aspx";
            menuAppointmentGet.HRef = "~/Views/Specialist/Appointment/SearchAppointmentSpecialistGeneral.aspx";

            //Receta
            menuAppointmentInsertRecipe.HRef = "~/Views/Specialist/Recipe/InsertRecipeSpecialist.aspx";
            menuAppointmentCancelRecipe.HRef = "~/Views/Specialist/Recipe/SearchRecipeSpecialistCancel.aspx";
            menuAppointmentUpdateRecipe.HRef = "~/Views/Specialist/Recipe/SearchRecipeSpecialistUpdate.aspx";
            menuAppointmentGetRecipe.HRef = "~/Views/Specialist/Recipe/SearchRecipeSpecialistGeneral.aspx";
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
                        menuAppointmentInsert.Visible = true;
                        menuAppointmentCancel.Visible = true;
                        menuAppointmentUpdate.Visible = true;
                        menuAppointmentGet.Visible = true;
                        menuAppointmentInsertRecipe.Visible = true;
                        menuAppointmentCancelRecipe.Visible = true;
                        menuAppointmentUpdateRecipe.Visible = true;
                        menuAppointmentGetRecipe.Visible = true;
                        break;
                    case "Assistant":
                        Response.Redirect("../../CredentialsError.aspx");
                        break;
                    case "Collaborator":
                        Response.Redirect("../../CredentialsError.aspx");
                        break;
                    default:
                        Response.Redirect("../../UrlError.aspx");
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

                this.appo = new SalutemDomain.Appointment(Convert.ToInt32(txtHour.Text), finalDate);
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

            this.appo = new SalutemDomain.Appointment(Convert.ToInt32(txtId.Text), Convert.ToInt32(txtHour.Text), finalDate);

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