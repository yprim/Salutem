<%@ Page Title="" Language="C#" MasterPageFile="~/Salutem.Master" AutoEventWireup="true" CodeBehind="DefaulSpecialist.aspx.cs" Inherits="Salutem.DefaulAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="container borderRounded">
        <h2> 
        <p class="textJustify">Usted se encuentra en la sección de los especialistas, en dicha sección encontrará 
           opciones para realizar diversos tipos de operaciones reservadas para personal autorizado.
        </p>
        </h2>
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
                </ul>
            </li>

            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="badge custom-badge red pull-right"></span>Administrar receta <b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Recipe/InsertRecipeSpecialist.aspx") %>'> Generar receta</a></li>
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Recipe/SearchRecipeSpecialist.aspx") %>'> Cancela receta</a></li> 
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Recipe/SearchRecipeSpecialist.aspx") %>'> Actualizar receta</a></li>
                </ul>
            </li>

            <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Recipe/SearchRecipeSpecialist.aspx") %>'>Obtener receta</a></li>

            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="badge custom-badge red pull-right"></span>Administrar diagnóstico <b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Diagnosis/InsertDiagnosis.aspx") %>'> Generar diagnóstico</a></li>
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Diagnosis/SearchDiagnosis.aspx") %>'> Eliminar diagnóstico</a></li> 
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
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <a class="navbar-brand" href='<%=Page.ResolveUrl("~/DefaulSpecialist.aspx") %>'>Salutem</a>
</asp:Content>
