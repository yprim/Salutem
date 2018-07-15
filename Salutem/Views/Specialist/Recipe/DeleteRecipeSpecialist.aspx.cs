using SalutemBusiness;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views.Specialist.Recipe
{
    public partial class DeleteRecipeSpecialist : System.Web.UI.Page
    {
        #region
            private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            private RecipeBusiness recipeBusiness = null;
            private SalutemDomain.Recipe recipe = null;
            private Userr user = null;
            private string operationMessage = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNumCedula.Text = Request["identityCard"];
                txtActualDate.Text = Request["date"];
                txtActualHour.Text = Request["hour"];
                txtActualDescription.Text = Request["description"];
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            this.recipeBusiness = new RecipeBusiness(this.conn);
            this.recipe = new SalutemDomain.Recipe(txtActualDescription.Text, txtActualDate.Text, Convert.ToInt32(txtActualHour.Text));
            this.user = new Userr(txtNumCedula.Text);


            operationMessage = this.recipeBusiness.deleteRecipeWithoutDiagnosisIdBusiness(this.recipe, this.user);

            //Se valida que la operación sea exitosa
            if (operationMessage != "Error al ejecutar la operación en la base de datos")
            {
                txtMensaje.Text = "La operación se realizó satisfactoriamente";
            }
            else
            {
                txtMensaje.Text = operationMessage;
            }
        }
    }
}