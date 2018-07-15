using SalutemBusiness;
using SalutemDomain;
using System;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views.Assistant
{
    public partial class DeleteAppointment : System.Web.UI.Page
    {
        #region
        private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        private AppointmentBusiness appointmentBusiness = null;
        private UserBusiness userBusiness = null;
        private SalutemDomain.Appointment appo = null;
        private Userr user = null;
        private static string finalDate = "";
        private string validateMessage = "", operationMessage = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtActualDate.Text = Request["date"];
                txtHour.Text = Request["hour"];
            }

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
            try
            {
                if (string.IsNullOrEmpty((string)Session["rol"]))
                {
                    Session["rol"] = "NoRolSet";
                }
                switch (Session["rol"])
                {
                    case "Specialist":
                        //No tiene los credenciales requeridos
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
                        //No tiene los credenciales requeridos
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            finalDate = txtActualDate.Text;

            this.appointmentBusiness = new AppointmentBusiness(this.conn);

            this.appo = new Appointment(Convert.ToInt32(txtHour.Text), finalDate);
            this.user = new Userr(Request["identityCard"].ToString());

            //Se guarda un mensaje basado en la operación que se realizo
            operationMessage = this.appointmentBusiness.cancelAppointmentWithoutAppointmentIdBusiness(this.appo, this.user);

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

    }
}