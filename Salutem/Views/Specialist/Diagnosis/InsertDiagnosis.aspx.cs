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
    public partial class InsertDiagnosis : System.Web.UI.Page
    {
        #region
            private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            private DiagnosisBusiness diagnosisBusiness = null;
            private SalutemDomain.Diagnosis diagnosis = null;
            private Userr user = null;
            private string operationMessage = "", finalDate = "";
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresarDiagnostico_Click(object sender, EventArgs e)
        {
            string date = clDiagnosticDate.SelectedDate.ToShortDateString();
            string[] dateArray = date.Split(' ');
            string[] formatDate = dateArray[0].Split('/');

            finalDate = formatDate[2] + "-" + formatDate[0] + "-" + formatDate[1];

            this.diagnosisBusiness = new DiagnosisBusiness(this.conn);

            this.diagnosis = new SalutemDomain.Diagnosis(txtDescripcion.Text, finalDate, Convert.ToInt32(txtHour.Text));
            this.user = new Userr(txtNumCedula.Text);

            //Se guarda un mensaje basado en la operación que se realizo
            operationMessage = this.diagnosisBusiness.insertDiagnosisBusiness(this.diagnosis, this.user);

            //Se valida que la operación sea exitosa
            if (operationMessage != "Error al ejecutar la operación en la base de datos")
            {
                txtId.Text = operationMessage;

                txtMensaje.Text = "La operación se realizó satisfactoriamente";
            }
            else
            {
                txtMensaje.Text = operationMessage;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            this.diagnosisBusiness = new DiagnosisBusiness(this.conn);

            //Se guarda un mensaje basado en la operación que se realizo
            operationMessage = this.diagnosisBusiness.deleteDiagnosisBusiness(Convert.ToInt32(txtId.Text));

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