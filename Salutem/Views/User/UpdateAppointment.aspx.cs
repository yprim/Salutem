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
    public partial class UpdateAppointment : System.Web.UI.Page
    {
        #region
            private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            private AppointmentBusiness appointmentBusiness = null;
            private Appointment appo = null;
            private Userr user = null;
            private string finalDate = "", operationMessage = "";
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

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string date = clDate.SelectedDate.ToShortDateString();
            string[] dateArray = date.Split(' ');
            string[] formatDate = dateArray[0].Split('/');

            finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

            this.appointmentBusiness = new AppointmentBusiness(this.conn);

            this.appo = new Appointment(Convert.ToInt32(txtHour.Text), finalDate);
            this.user = new Userr(txtIdentityCard.Text);

            //Se guarda un mensaje basado en la operación que se realizo
            operationMessage = this.appointmentBusiness.updateAppointmentBusiness(this.appo, this.user);

            txtMensaje.Text = operationMessage;
        }
    }
}