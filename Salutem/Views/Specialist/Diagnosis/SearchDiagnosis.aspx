<%@ Page Title="" Language="C#" MasterPageFile="~/Salutem.Master" AutoEventWireup="true" CodeBehind="SearchDiagnosis.aspx.cs" Inherits="Salutem.Views.Specialist.Diagnosis.SearchDiagnosis" %>

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
        <div class="container borderRounded">
            <center>
                <h3>Buscar dianóstico</h3>
            </center>
            <div class="col-md-offset-4">
                <div class="col-lg-8">
                    <br>
                    <form id="formBuscarDiagnostico" runat="server">
                        <div class="form-group">
                            <asp:Label ID="lblNumCedula" runat="server" Text="Número de cédula"></asp:Label>
                            <asp:TextBox ID="txtnumCedula" runat="server" CssClass="form-control" placeholder="Número de cédula"></asp:TextBox>
                        </div>
                                
                        <asp:Button ID="btnBuscar" class="btn btn-info" runat="server"  Text="Buscar" OnClick="btnBuscar_Click" />
                        
                        <br />
                        <br />
                        <br />
                    </form>
                </div>
            </div>
            
            <div class="tablaDatos">
                <table class="table table-bordered table-hover table-responsive">
                <thead>
                    <tr>
                        <th scope="col">Número de registro</th>
                        <th scope="col">Nombre del cliente</th>
                        <th scope="col">Número de cédula</th>
                        <th scope="col">Descripción</th>
                        <th scope="col">Eliminar</th>
                        <th scope="col">Actualizar</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row">1</th>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                        <td> <a href="CancelAppointmentSpecialist.aspx?id=1">Cancelar </a> </td>
                        <td> <a href="UpdateAppointmentSpecialist.aspx?id=2">Actualizar </a> </td>
                    </tr>
                    <tr>
                        <th scope="row">2</th>
                        <td>Jacob</td>
                        <td>Thornton</td>
                        <td>@fat</td>
                        <td> <a href="url">Cancelar </a> </td>
                        <td> <a href="url">Actualizar </a> </td>
                    </tr>
                    <tr>
                        <th scope="row">3</th>
                        <td> Larry the Bird</td>
                        <td>@twitter</td>
                        <td>@fat</td>
                        <td> <a href="url">Cancelar </td>
                        <td> <a href="url">Actualizar </td>
                    </tr>
                </tbody>
            </table>
            </div>
        </div>
    </div>


    <script>

        $('#<%= btnBuscar.ClientID %>').click(function () {
            
        })//end #btnSeeAction

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="collapse navbar-collapse navbar-right">
        <ul class="nav navbar-nav">

            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="badge custom-badge red pull-right"></span>Administrar cita <b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Appointment/InsertAppointmentSpecialist.aspx") %>'> Agendar cita</a></li>
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Appointment/SearchAppointmentSpecialist.aspx") %>'> Cancelar cita</a></li> 
                    <li><a href='<%=Page.ResolveUrl("~/Views/Specialist/Appointment/SearchAppointmentSpecialist.aspx") %>'> Actualizar cita</a></li>
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
