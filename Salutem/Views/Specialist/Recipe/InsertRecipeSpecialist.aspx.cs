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
            private Recipe recipe = null;
            private Userr user = null;
            private string finalDate = "", operationMessage = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresarDiagnostico_Click(object sender, EventArgs e)
        {
            string date = clRecipeDate.SelectedDate.ToShortDateString();
            string[] dateArray = date.Split(' ');
            string[] formatDate = dateArray[0].Split('/');

            finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

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

        protected void Delete_Click(object sender, EventArgs e)
        {
            this.recipeBusiness = new RecipeBusiness(this.conn);

            operationMessage = this.recipeBusiness.deleteRecipeBusiness(Convert.ToInt32(txtId.Text));

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