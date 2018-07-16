using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views.Specialist.Diagnosis
{
    public partial class SearchDiagnosisCancel : System.Web.UI.Page
    {
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

            //Diágnostico
            menuDiagnosisCreateDiagnosis.HRef = "~/Views/Specialist/Diagnosis/InsertDiagnosis.aspx";
            menuDiagnosisDeleteDiagnosis.HRef = "~/Views/Specialist/Diagnosis/SearchDiagnosisCancel.aspx";
            menuDiagnosisUpdateDiagnosis.HRef = "~/Views/Specialist/Diagnosis/SearchDiagnosisUpdate.aspx";
            menuDiagnosisGetDiagnosis.HRef = "~/Views/Specialist/Diagnosis/SearchDiagnosis.aspx";

            //Reportes
            menuCli.HRef = "~/Views/Specialist/Resports/ReportNumberUsersPerDay.aspx";
            menuCh1.HRef = "~/Views/Specialist/Resports/ScheduleReportWithTheMostvisits.aspx";
            menuCh2.HRef = "~/Views/Specialist/Resports/ScheduleReportWithTheSmallestNumberOfVisits.aspx";
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
                        Response.Redirect("../CredentialsError.aspx");
                        break;
                    case "Collaborator":
                        Response.Redirect("../CredentialsError.aspx");
                        break;
                    default:
                        Response.Redirect("../UrlError.aspx");
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