using SalutemBusiness;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Salutem
{
    /// <summary>
    /// Summary description for SalutemService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SalutemService : System.Web.Services.WebService
    {
        #region
            private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            private AppointmentBusiness appointmentBusiness = null;
            private RecipeBusiness recipeBusiness = null;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        [WebMethod]
        public void getAllAppointmentsBusiness()
        {
            this.appointmentBusiness = new AppointmentBusiness(conn);
            List<Appointment> appointmentList = this.appointmentBusiness.getAllAppointmentsBusiness();

            // En la variable se mete los datos necesarios para que se genere el archivo json.
            var resultado = new
            {
                iTotalRecords = appointmentList.Count,
                iTotalDisplayRecords = appointmentList.Count,
                aaData = appointmentList
            };

            //Se utiliza JavaScritp Serializer para poder crear el archivo json con los valores de la lista
            //El tamaño se setea al máximo ya que esto es para consultas que devuelvan miles de tuplas.
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(resultado));
        }


        /// <summary>
        /// 
        /// </summary>
        [WebMethod]
        public void getAllAppointmentsBusinessFilters(string identityCard)
        {
            this.appointmentBusiness = new AppointmentBusiness(conn);
            List<Appointment> appointmentList = this.appointmentBusiness.getAllAppointmentsBusinessFilters(identityCard);

            // En la variable se mete los datos necesarios para que se genere el archivo json.
            var resultado = new
            {
                iTotalRecords = appointmentList.Count,
                iTotalDisplayRecords = appointmentList.Count,
                aaData = appointmentList
            };

            //Se utiliza JavaScritp Serializer para poder crear el archivo json con los valores de la lista
            //El tamaño se setea al máximo ya que esto es para consultas que devuelvan miles de tuplas.
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(resultado));
        }

        /// <summary>
        /// 
        /// </summary>
        [WebMethod]
        public void getAppointmentsBusinessFilters(string identityCard, string date)
        {
            this.appointmentBusiness = new AppointmentBusiness(conn);
            List<Appointment> appointmentList = this.appointmentBusiness.getAppointmentsBusinessFilters(identityCard, date);

            // En la variable se mete los datos necesarios para que se genere el archivo json.
            var resultado = new
            {
                iTotalRecords = appointmentList.Count,
                iTotalDisplayRecords = appointmentList.Count,
                aaData = appointmentList
            };

            //Se utiliza JavaScritp Serializer para poder crear el archivo json con los valores de la lista
            //El tamaño se setea al máximo ya que esto es para consultas que devuelvan miles de tuplas.
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(resultado));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityCard"></param>
        [WebMethod]
        public void getAppointmentByIdentityCardBusiness(string identityCard)
        {
            this.appointmentBusiness = new AppointmentBusiness(conn);
            List<Appointment> appointmentList = this.appointmentBusiness.getAppointmentByIdentityCardBusiness(identityCard);

            // En la variable se mete los datos necesarios para que se genere el archivo json.
            var resultado = new
            {
                iTotalRecords = appointmentList.Count,
                iTotalDisplayRecords = appointmentList.Count,
                aaData = appointmentList
            };

            //Se utiliza JavaScritp Serializer para poder crear el archivo json con los valores de la lista
            //El tamaño se setea al máximo ya que esto es para consultas que devuelvan miles de tuplas.
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(resultado));
        }

        /// <summary>
        /// 
        /// </summary>
        [WebMethod]
        public void getAllRecipesBusiness()
        {
            this.recipeBusiness = new RecipeBusiness(conn);
            List<Recipe> appointmentList = this.recipeBusiness.getAllRecipesData();

            // En la variable se mete los datos necesarios para que se genere el archivo json.
            var resultado = new
            {
                iTotalRecords = appointmentList.Count,
                iTotalDisplayRecords = appointmentList.Count,
                aaData = appointmentList
            };

            //Se utiliza JavaScritp Serializer para poder crear el archivo json con los valores de la lista
            //El tamaño se setea al máximo ya que esto es para consultas que devuelvan miles de tuplas.
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(resultado));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityCard"></param>
        [WebMethod]
        public void getRecipeByIdentityCardBusiness(string identityCard)
        {
            this.recipeBusiness = new RecipeBusiness(conn);
            List<Recipe> appointmentList = this.recipeBusiness.getRecipesDataByIdentityCardData(identityCard);

            // En la variable se mete los datos necesarios para que se genere el archivo json.
            var resultado = new
            {
                iTotalRecords = appointmentList.Count,
                iTotalDisplayRecords = appointmentList.Count,
                aaData = appointmentList
            };

            //Se utiliza JavaScritp Serializer para poder crear el archivo json con los valores de la lista
            //El tamaño se setea al máximo ya que esto es para consultas que devuelvan miles de tuplas.
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;
            Context.Response.Write(js.Serialize(resultado));
        }
    }
}
