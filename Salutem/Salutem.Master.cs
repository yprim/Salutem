﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem
{
    public partial class Salutem : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                if (!string.IsNullOrEmpty((string)Session["fullName"])) {
                    SessionName.Text = Session["fullName"].ToString();
                }
            } catch {

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}