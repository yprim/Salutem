using SalutemBusiness;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views.User
{
    public partial class CancelAppointment : System.Web.UI.Page
    {
        #region
        private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        private AppointmentBusiness appointmentBusiness = null;
        private Appointment appo = null;
        private Userr user = null;
        private static string finalDate = "";
        private string operationMessage = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtActualDate.Text = Request["date"];
                txtActualHour.Text = Request["hour"];
                txtIdentityCard.Text = Request["identityCard"]; 
            }

            //================================================================
            //Navigation
            //================================================================
            menuAppointmentInsert.HRef = "~/Views/Collaborator/InsertAppointment.aspx";
            menuAppointmentCancel.HRef = "~/Views/Collaborator/SearchAppointmentCancel.aspx";
            menuAppointmentUpdate.HRef = "~/Views/Collaborator/SearchAppointmentUpdate.aspx";
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
                        Response.Redirect("../CredentialsError.aspx");
                        break;
                    case "Assistant":
                        Response.Redirect("../CredentialsError.aspx");
                        break;
                    case "Collaborator":
                        menuAppointmentInsert.Visible = true;
                        menuAppointmentCancel.Visible = true;
                        menuAppointmentUpdate.Visible = true;
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            finalDate = txtActualDate.Text;

            this.appointmentBusiness = new AppointmentBusiness(this.conn);

            this.appo = new Appointment(Convert.ToInt32(txtActualHour.Text), finalDate);
            this.user = new Userr(txtIdentityCard.Text);

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