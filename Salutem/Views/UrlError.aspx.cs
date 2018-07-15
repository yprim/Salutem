using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views
{
    public partial class Urlerror : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGotoLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx");
        }
    }
}