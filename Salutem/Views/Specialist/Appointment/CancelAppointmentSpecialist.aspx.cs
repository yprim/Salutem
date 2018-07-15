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
    public partial class CancelAppointmentSpecialist : System.Web.UI.Page
    {
        #region
        private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        private AppointmentBusiness appointmentBusiness = null;
        private SalutemDomain.Appointment appo = null;
        private Userr user = null;
        private static string finalDate = "";
        private string operationMessage = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtIdentityCard.Text = Request["identityCard"];
                txtActualDate.Text = Request["date"];
                txtActualHour.Text = Request["hour"];
            }

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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            string date = txtActualDate.Text;

            finalDate = date;

            this.appointmentBusiness = new AppointmentBusiness(this.conn);

            this.appo = new SalutemDomain.Appointment(Convert.ToInt32(txtHour.Text), finalDate);
            this.user = new Userr(txtIdentityCard.Text);

            //Se guarda un mensaje basado en la operación que se realizo
            operationMessage = this.appointmentBusiness.cancelAppointmentWithoutAppointmentIdBusiness(this.appo, this.user);

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

    }
}