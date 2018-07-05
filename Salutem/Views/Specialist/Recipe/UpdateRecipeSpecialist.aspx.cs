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
    public partial class UpdateRecipeSpecialist : System.Web.UI.Page
    {
        #region
            private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            private RecipeBusiness recipeBusiness = null;
            private SalutemDomain.Recipe recipe = null;
            private Userr user = null;
            private string finalDate = "", operationMessage = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNumCedula.Text = Request["identityCard"];
                txtActualHour.Text = Request["hour"];
                txtDescripcion.Text = Request["description"];

                clRecipeDate.TodaysDate = Convert.ToDateTime(Request["date"]);
                clRecipeDate.SelectedDate = clRecipeDate.TodaysDate;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string date = clRecipeDate.SelectedDate.ToShortDateString();
            string[] dateArray = date.Split(' ');
            string[] formatDate = dateArray[0].Split('/');

            finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

            this.recipeBusiness = new RecipeBusiness(this.conn);
            this.recipe = new SalutemDomain.Recipe(txtDescripcion.Text, finalDate, Convert.ToInt32(txtActualHour.Text));
            this.user = new Userr(txtNumCedula.Text);

            operationMessage = this.recipeBusiness.updateRecipeWithoutDiagnosisIdBusiness(this.recipe, this.user);

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