using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hay sesión activa ??
            if (Session["rol"] != null)
            {
                Session["rol"] = null;
                Session["id"] = null;
                Session["identityCard"] = null;
                Session["name"] = null;
                Session["lastname"] = null;
                Session["fullName"] = null;
            }

            Response.Redirect("~/Login.aspx");
        }
    }
}