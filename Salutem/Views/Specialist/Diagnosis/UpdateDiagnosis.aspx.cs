using SalutemBusiness;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views.Specialist.Diagnosis
{
    public partial class UpdateDiagnosis : System.Web.UI.Page
    {
        #region
        private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        private DiagnosisBusiness diagnosisBusiness = null;
        private SalutemDomain.Diagnosis diagnosis = null;
        private Userr user = null;
        private static string finalDate = "";
        private string validateMessage = "", operationMessage = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNumCedula.Text = Request["identityCard"];
                txtHour.Text = Request["hour"];
                txtDescripcion.Text = Request["description"];

                txtOldDate.Text = Request["date"];
                txtOldHour.Text = Request["description"];

                clDiagnosticDate.TodaysDate = Convert.ToDateTime(Request["date"]);
                clDiagnosticDate.SelectedDate = clDiagnosticDate.TodaysDate;
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

        protected void btnUpdateDiagnosis_Click(object sender, EventArgs e)
        {
            string date = clDiagnosticDate.SelectedDate.ToShortDateString();
            string[] dateArray = date.Split(' ');
            string[] formatDate = dateArray[0].Split('/');

            finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

            //Se valida la fecha
            validateMessage = validateDate(finalDate, Convert.ToInt32(txtHour.Text));

            if (validateMessage == "Disponible")
            {
                this.diagnosisBusiness = new DiagnosisBusiness(this.conn);
                this.diagnosis = new SalutemDomain.Diagnosis(txtDescripcion.Text ,finalDate, Convert.ToInt32(txtHour.Text));
                this.user = new Userr(txtNumCedula.Text);

                //Se guarda un mensaje basado en la operación que se realizo
                operationMessage = this.diagnosisBusiness.updateDiagnosisWithoutDiagnosisIdBusiness(this.diagnosis, this.user, txtOldDate.Text, txtOldHour.Text);

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
            else
            {
                txtMensaje.Text = validateMessage;
            }
        }

        private string validateDate(string date, int hour)
        {
            string message = "";

            this.diagnosisBusiness = new DiagnosisBusiness(this.conn);

            message = diagnosisBusiness.validateDateBusiness(date, hour);

            return message;
        }

    }
}