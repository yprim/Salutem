<%@ Page Title="" Language="C#" MasterPageFile="~/Salutem.Master" AutoEventWireup="true" CodeBehind="CancelAppointmentSpecialist.aspx.cs" Inherits="Salutem.Views.Specialist.CancelAppointmentSpecialist" %>


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
                    <h3>Cancelar cita</h3>
                </center>
                <br>
                <form id="formBuscarCita" runat="server">
                    <div class="form-group">
                        <asp:Label ID="lblIdentityCard" runat="server" Text="Número de cédula"></asp:Label>
                        <asp:TextBox ID="txtIdentityCard" ReadOnly="true" runat="server" CssClass="form-control" placeholder="Número de cédula"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblActualDate" runat="server" Text="Fecha actual"></asp:Label>
                        <asp:TextBox ID="txtActualDate" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblDate" runat="server" Text="Nueva fecha"></asp:Label>
                        <asp:Calendar ID="clDate" runat="server"></asp:Calendar>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblActualHour" runat="server" Text="Hora actual"></asp:Label>
                        <asp:TextBox ID="txtActualHour" ReadOnly="true" runat="server" CssClass="form-control" placeholder="Hora"></asp:TextBox>
                    </div>
                      
                    <div class="form-group">
                        <asp:Label ID="lblMensaje" runat="server" Text="Mensaje del sistema"></asp:Label>
                        <asp:TextBox ID="txtMensaje" ReadOnly="true" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>

                    <asp:Button ID="btnCancelar" class="btn btn-warning" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"/>
                        
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

            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="badge custom-badge red pull-right"></span>Administrar cita <b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a id="menuAppointmentInsert" runat="server"> Agendar cita</a></li>
                    <li><a id="menuAppointmentCancel" runat="server"> Cancelar cita</a></li> 
                    <li><a id="menuAppointmentUpdate" runat="server"> Actualizar cita</a></li>
                    <li><a id="menuAppointmentGet" runat="server"> Obtener cita</a></li>
                </ul>
            </li>

            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="badge custom-badge red pull-right"></span>Administrar receta <b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a id="menuAppointmentInsertRecipe" runat="server"> Generar receta</a></li>
                    <li><a id="menuAppointmentCancelRecipe" runat="server"> Cancela receta</a></li> 
                    <li><a id="menuAppointmentUpdateRecipe" runat="server"> Actualizar receta</a></li>
                    <li><a id="menuAppointmentGetRecipe" runat="server"> Obtener receta</a></li>
                </ul>
            </li>

            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="badge custom-badge red pull-right"></span>Administrar diagnóstico <b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Diagnosis/InsertDiagnosis.aspx") %>'> Generar diagnóstico</a></li>
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Diagnosis/SearchDiagnosis.apsx") %>'> Eliminar diagnóstico</a></li> 
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Diagnosis/SearchDiagnosis.aspx") %>'> Actualizar diagnóstico</a></li>
                </ul>
            </li>

            <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Diagnosis/SearchDiagnosis.aspx") %>'>Obtener diagnóstico</a></li>

            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="badge custom-badge red pull-right"></span>Reportes <b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Resports/ReportNumberUsersPerDay.aspx") %>'> Clientes atendidos por día</a></li>
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Resports/ScheduleReportWithTheMostvisits.aspx") %>'> Horario con mayor cantidad de visitas</a></li> 
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Resports/ScheduleReportWithTheSmallestNumberOfVisits.aspx") %>'> Horario con menor cantidad de visitas</a></li>
                </ul>
            </li>

            <li><a href="#credits">Créditos</a></li>

            <li><a href="../../../LogOut.aspx">LogOut</a></li>

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
    <a class="navbar-brand" href='<%=Page.ResolveUrl("~/DefaulSpecialist.aspx") %>'>Salutem</a>
</asp:Content>