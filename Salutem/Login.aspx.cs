using SalutemBusiness;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem
{
    public partial class Login : System.Web.UI.Page
    {
        #region
            private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            private UserBusiness userBusiness = null;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtMensaje.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string information = "";

            this.userBusiness = new UserBusiness(this.conn);

            information = this.userBusiness.getRoleForUserBusiness(txtEmail.Text, txtPassword.Text);

            switch (information)
            {
                case "Specialist":
                    Session["rol"] = "Specialist";
                    Response.Redirect("~/DefaulSpecialist.aspx");
                    break;
                case "Assistant":
                    Session["rol"] = "Assistant";
                    Response.Redirect("~/Default.aspx");
                    break;
                case "Collaborator":
                    Session["rol"] = "Collaborator";
                    break; 
                default:
                    txtMensaje.Text = "Error !! el usuario con los credenciales suministrados no esta en el sistema.";
                    txtMensaje.Visible = true;
                    break;
            }
        }
    }
}