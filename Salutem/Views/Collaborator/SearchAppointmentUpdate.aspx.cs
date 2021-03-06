﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem.Views.Collaborator
{
    public partial class SearchAppointmentUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}