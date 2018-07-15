using SalutemBusiness;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views.Specialist
{
    public partial class CancelAppointmentSpecialist : System.Web.UI.Page
    {
        #region
        private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        private AppointmentBusiness appointmentBusiness = null;
        private SalutemDomain.Appointment appo = null;
        private Userr user = null;
        private static string finalDate = "";
        private string operationMessage = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtIdentityCard.Text = Request["identityCard"];
                txtActualDate.Text = Request["date"];
                txtActualHour.Text = Request["hour"];
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            string date = txtActualDate.Text;

            finalDate = date;

            this.appointmentBusiness = new AppointmentBusiness(this.conn);

            this.appo = new SalutemDomain.Appointment(Convert.ToInt32(txtHour.Text), finalDate);
            this.user = new Userr(txtIdentityCard.Text);

            //Se guarda un mensaje basado en la operación que se realizo
            operationMessage = this.appointmentBusiness.cancelAppointmentWithoutAppointmentIdBusiness(this.appo, this.user);
            
            txtMensaje.Text = operationMessage;
        }
    }
}