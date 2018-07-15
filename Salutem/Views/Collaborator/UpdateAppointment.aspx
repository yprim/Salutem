<%@ Page Title="" Language="C#" MasterPageFile="~/Salutem.Master" AutoEventWireup="true" CodeBehind="UpdateAppointment.aspx.cs" Inherits="Salutem.Views.User.UpdateAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="row">
        <br>
        <div class="col-md-offset-3">
            <div class="col-lg-8 borderRounded">
                <center>
                    <h3>Actualizar cita</h3>
                </center>
                <br>
                <form id="formBuscarCita" runat="server">
                    <div class="form-group">
                        <asp:Label ID="lblIdentityCard" runat="server" Text="Fecha actual"></asp:Label>
                        <asp:TextBox ID="txtIdentityCard" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <asp:TextBox ID="txtOldDate" type="hidden" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtOldHour" type="hidden" runat="server"></asp:TextBox>

                    <div class="form-group">
                        <asp:Label ID="lblDate" runat="server" Text="Nueva fecha"></asp:Label>
                        <asp:Calendar ID="clDate" runat="server"></asp:Calendar>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblActualHour" runat="server" Text="Hora"></asp:Label>
                        <asp:TextBox ID="txtHour" runat="server" CssClass="form-control" placeholder="Hora"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblMensaje" runat="server" Text="Mensaje del sistema"></asp:Label>
                        <asp:TextBox ID="txtMensaje" ReadOnly="true" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnActualizar" class="btn btn-danger" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                    
                    <br />
                    <br />
                </form>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="collapse navbar-collapse navbar-right">
        <ul class="nav navbar-nav">
            <li class="active"><a href='<%=Page.ResolveUrl("~/Default.aspx") %>'>Inicio</a></li>

            <li><a href="#servicios">Servicios</a></li>

            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="badge custom-badge red pull-right"></span>Administrar citas<b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a id="menuAppointmentInsert" runat="server">Agendar cita</a></li>
                    <li><a id="menuAppointmentCancel" runat="server">Cancelar cita</a></li> 
                    <li><a id="menuAppointmentUpdate" runat="server">Actualizar cita</a></li>
                    <li><a id="menuAppointmentGet" runat="server"> Obtener cita</a></li>
                </ul>
            </li>

            <li><a href="#credits">Créditos</a></li>

            <li><a href="../../LogOut.aspx">LogOut</a></li>

            <div class="input-group">
                <input type="text" class="form-control" placeholder="Search...">
                <span class="input-group-btn">
                    <button class="btn btn-info" type="button">Buscar</button>
                </span>
            </div><!-- /input-group -->
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <a class="navbar-brand" href='<%=Page.ResolveUrl("~/DefaultCollaborator.aspx") %>'>Salutem</a>
</asp:Content>