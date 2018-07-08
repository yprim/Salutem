using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //================================================================
            //Navigation
            //================================================================
            menuAppointmentInsert.HRef = "~/Views/User/InsertAppointment.aspx";
            menuAppointmentCancel.HRef = "~/Views/User/SearchAppointment.aspx";
            menuAppointmentUpdate.HRef = "~/Views/User/SearchAppointment.aspx";
            //================================================================

            //================================================================
            //Roles
            //================================================================
            try {
                if (string.IsNullOrEmpty((string)Session["rol"])) {
                    Session["rol"] = "NoRolSet";
                }
                switch (Session["rol"]) {
                    case "Specialist":
                        menuAppointmentInsert.Visible = true;
                        menuAppointmentCancel.Visible = true;
                        menuAppointmentUpdate.Visible = true;
                        break;
                    case "Assistant":
                        menuAppointmentInsert.Visible = true;
                        menuAppointmentCancel.Visible = false;
                        menuAppointmentUpdate.Visible = false;
                        break;
                    case "Collaborator":
                        menuAppointmentInsert.Visible = true;
                        menuAppointmentCancel.Visible = false;
                        menuAppointmentUpdate.Visible = false;
                        break;
                    default:
                        break;
                }
            } catch {
            }
            //================================================================
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
        }
    }
}