using SalutemBusiness;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views.Admin
{
    public partial class insertRecipe : System.Web.UI.Page
    {
        #region
        private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        private RecipeBusiness recipeBusiness = null;
        private SalutemDomain.Recipe appo = null;
        private Recipe recipe = null;
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

        protected void btnIngresarDiagnostico_Click(object sender, EventArgs e)
        {
            string date = clRecipeDate.SelectedDate.ToShortDateString();
            string[] dateArray = date.Split(' ');
            string[] formatDate = dateArray[0].Split('/');

            finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

            //Se valida la fecha
            validateMessage = validateDate(finalDate, Convert.ToInt32(txtHour.Text));

            if (validateMessage == "Disponible")
            {
                this.recipeBusiness = new RecipeBusiness(this.conn);
                this.recipe = new Recipe(txtDescripcion.Text, finalDate, Convert.ToInt32(txtHour.Text));
                this.user = new Userr(txtNumCedula.Text);

                operationMessage = this.recipeBusiness.insertRecipeBusiness(this.recipe, this.user);

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

        protected void Delete_Click(object sender, EventArgs e)
        {
            this.recipeBusiness = new RecipeBusiness(this.conn);

            this.appo = new SalutemDomain.Recipe(Convert.ToInt32(txtId.Text), Convert.ToInt32(txtHour.Text), finalDate);

            operationMessage = this.recipeBusiness.deleteRecipeBusiness(this.appo);

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

        private string validateDate(string date, int hour)
        {
            string message = "";

            this.recipeBusiness = new RecipeBusiness(this.conn);

            message = recipeBusiness.validateDateBusiness(date, hour);

            return message;
        }

    }
}