﻿using SalutemBusiness;
using SalutemDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salutem
{
    public partial class Login : System.Web.UI.Page
    {
        #region
            private string conn = WebConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            private UserBusiness userBusiness = null;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtMensaje.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try {
                //RSG
                //================================================================================
                if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Text)) {
                    userBusiness = new UserBusiness(this.conn);
                    Userr userSession = this.userBusiness.getUserData(txtEmail.Text, txtPassword.Text);

                    if (string.IsNullOrEmpty(userSession.rol)) {
                        txtMensaje.Text = "Datos incorrectos.";
                        txtMensaje.Visible = true;
                        return;
                    }

                    Session["rol"] = userSession.rol;
                    Session["id"] = userSession.id;
                    Session["identityCard"] = userSession.identityCard;
                    Session["name"] = userSession.name;
                    Session["lastname"] = userSession.lastname;
                    Session["fullName"] = userSession.lastname + " " + userSession.name;

                    ((Label)Master.FindControl("SessionName")).Text = Session["fullName"].ToString();
                }else{
                    txtMensaje.Text = "Por favor ingrese su correo y contraseña.";
                    txtMensaje.Visible = true;
                    return;
                }
                //================================================================================

                //string information = "";
                //this.userBusiness = new UserBusiness(this.conn);
                //information = this.userBusiness.getRoleForUserBusiness(txtEmail.Text, txtPassword.Text);

                switch (Session["rol"]) {
                    case "Specialist":
                        Response.Redirect("~/DefaulSpecialist.aspx");
                        break;
                    case "Assistant":
                        Response.Redirect("~/DefaultSpecialist.aspx");
                        break;
                    case "Collaborator":
                        Response.Redirect("~/Default.aspx");
                        break;
                    default:
                        txtMensaje.Text = "Error !! el usuario con los credenciales suministrados no esta en el sistema.";
                        txtMensaje.Visible = true;
                        break;
                }
            } catch {

            }
        }
    }
}