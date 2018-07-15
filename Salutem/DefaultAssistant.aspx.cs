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
            try {
                if (string.IsNullOrEmpty((string)Session["rol"])) {
                    Session["rol"] = "NoRolSet";
                }
                switch (Session["rol"]) {
                    case "Specialist":
                        Response.Redirect("./Views/CredentialsError.aspx");
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
                        Response.Redirect("./Views/CredentialsError.aspx");
                        break;
                    default:
                        Response.Redirect("./Views/UrlError.aspx");
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