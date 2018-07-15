using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views
{
    public partial class CredentialsError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGotoPage_Click(object sender, EventArgs e)
        {
            //================================================================
            //Roles
            //================================================================
            try
            {
                switch (Session["rol"])
                {
                    case "Specialist":
                        Response.Redirect("../DefaulSpecialist.aspx");
                        break;
                    case "Assistant":
                        Response.Redirect("../DefaultAssistant.aspx");
                        break;
                    case "Collaborator":
                        Response.Redirect("../DefaultCollaborator.aspx");
                        break;
                    default:
                        Response.Redirect("../Login.aspx");
                        break;
                }
            }
            catch
            {
            }
            //================================================================
        }
    }
}