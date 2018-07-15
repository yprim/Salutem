<%@ Page Title="" Language="C#" MasterPageFile="~/Salutem.Master" AutoEventWireup="true" CodeBehind="InsertAppointment.aspx.cs" Inherits="Salutem.Views.Assistant.InsertAppointment" %>

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
                            <asp:TextBox ID="txtId" type="hidden" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha de la cita"></asp:Label>
                            <asp:Calendar ID="clFechaCita" runat="server"></asp:Calendar>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblHora" runat="server" Text="Hora de la cita"></asp:Label>
                            <asp:TextBox ID="txtHour" runat="server" class="form-control" placeholder="Hora de la cita"></asp:TextBox>
                        </div>
                        
                        <div class="form-group">
                            <asp:Label ID="lblMensaje" runat="server" Text="Mensaje del sistema"></asp:Label>
                            <asp:TextBox ID="txtMensaje" ReadOnly="true" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>

                        <!-- Se usa para evitar ataques de peticiones POST de sitios maliciosos-->
                        <asp:Button ID="btnAgendar" runat="server" CssClass="btn btn-info" Text="Agendar" OnClick="btnAgendar_Click" /> &nbsp;
                        &nbsp;
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
            <li class="active"><a href="#header">Inicio</a></li>
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

            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="badge custom-badge red pull-right"></span>Reportes <b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a id="menuClient" runat="server"> Clientes atendidos por día</a></li>
                    <li><a id="menuSchedule1" runat="server"> Horario con mayor cantidad de visitas</a></li> 
                    <li><a id="menuSchedule2" runat="server"> Horario con menor cantidad de visitas</a></li>
                </ul>
            </li>

            <li class="dropdown">
                <a id="menuAppointmentGetRecipes" runat="server"> Obtener receta</a>
            </li>

            <li><a href="#credits">Créditos</a></li>

            <li><a href="../../LogOut.aspx">LogOut</a></li>

            <div class="input-group">
                <input type="text" class="form-control" placeholder="Buscar...">
                <span class="input-group-btn">
                    <button class="btn btn-info" type="button">Buscar</button>
                </span>
            </div><!-- /input-group -->
        </ul>
    </div>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <a class="navbar-brand" href='<%=Page.ResolveUrl("~/DefaultAssistant.aspx") %>'>Salutem</a>
</asp:Content>