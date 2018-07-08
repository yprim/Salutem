<%@ Page Title="" Language="C#" MasterPageFile="~/Salutem.Master" AutoEventWireup="true" CodeBehind="InsertAppointment.aspx.cs" Inherits="Salutem.Views.User.InsertAppointment" %>
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
        <div class="col-md-offset-4">
                <div class="col-lg-8 borderRounded">
                    <center>
                        <h3>Agendar cita</h3>
                    </center>
                    <br>
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <asp:Label ID="lblNumCedula" runat="server" Text="Número de cedula del cliente"></asp:Label>
                            <asp:TextBox ID="txtNumCedula" runat="server" class="form-control" placeholder="Número de cédula"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblNombreCliente" runat="server" Text="Nombre cliente"></asp:Label>
                            <asp:TextBox ID="txtNombreCliente" runat="server" class="form-control" placeholder="Nombre del cliente"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha de la cita"></asp:Label>
                            <asp:Calendar ID="clFechaCita" runat="server"></asp:Calendar>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblHora" runat="server" Text="Hora de la cita"></asp:Label>
                            <asp:TextBox ID="txtHour" runat="server" class="form-control" placeholder="Hora de la cita"></asp:TextBox>
                        </div>
                                
                        <!-- Se usa para evitar ataques de peticiones POST de sitios maliciosos-->
                        <asp:Button ID="btnAgendar" runat="server" CssClass="btn btn-info" Text="Agendar" OnClick="btnAgendar_Click" /> &nbsp;
                        <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-danger" Text="Actualizar" OnClick="btnActualizar_Click" /> &nbsp;
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-warning" Text="Cancelar" OnClick="btnCancelar_Click" />
                        <br>
                        <br>
                    </form>
                </div>
            </div>
    </div>
    <br><br>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="collapse navbar-collapse navbar-right">
        <ul class="nav navbar-nav">
            <li class="active"><a href='<%=Page.ResolveUrl("~/Default.aspx") %>'>Inicio</a></li>

            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="badge custom-badge red pull-right"></span>Administrar citas<b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a href='<%=Page.ResolveUrl("~/Views/User/InsertAppointment.aspx") %>'>Agendar cita</a></li>
                    <li><a href='<%=Page.ResolveUrl("~/Views/User/SearchAppointment.aspx") %>'>Cancelar cita</a></li> 
                    <li><a href='<%=Page.ResolveUrl("~/Views/User/SearchAppointment.aspx") %>'>Actualizar cita</a></li>
                </ul>
            </li>

            <li><a href="#credits">Créditos</a></li>

            <li><a data-placement="bottom" data-toggle="popover" data-title="Iniciar Sesión" data-container="body" type="button" data-html="true" id="login">Iniciar Sesión</a></li>
			<div id="popover-content" class="hide">
				<form>
					<div class="form-group">
					    <label for="exampleInputEmail1">Correo</label>
					    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Correo">
					    <small id="emailHelp" class="form-text text-muted"></small>
					</div>
					<div class="form-group">
					    <label for="exampleInputPassword1">Contraseña</label>
					    <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Contraseña">
					</div>
					<button type="submit" class="btn btn-primary">Submit</button>
				</form>
			</div>

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
    <a class="navbar-brand" href='<%=Page.ResolveUrl("~/DefaulSpecialist.aspx") %>'>Salutem</a>
</asp:Content>