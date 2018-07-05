<%@ Page Title="" Language="C#" MasterPageFile="~/Salutem.Master" AutoEventWireup="true" CodeBehind="SearchAppointment.aspx.cs" Inherits="Salutem.Views.User.SearchAppointment" %>

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
                <h3>Buscar cita</h3>
            </center>
            <div class="col-md-offset-4">
                <div class="col-lg-8">
                    <br>
                    <form id="formBuscarCita" runat="server">
                        <div class="form-group">
                            <label for="NumCedula"> Número de cédula </label>
                            <input type="text" class="form-control" placeholder="Número de cédula" id="app_search">
                        </div>
                        <!-- Gif de carga-->
                        <img id="loadData" class="center" src="../../../img/ajax-loader.gif" width="10%" alt="">
                        <br />
                        <br />
                        <br />
                    </form>
                </div>
            </div>
            
            <div class="tablaDatos" id="informationtable"></div>
        </div>
    </div>


    <script>
        $(document).ready(function () {

            $.ajax({
                url: '../../../SalutemService.asmx/getAllAppointmentsBusiness',
                type: 'POST',
                dataType: 'text',
                beforeSend: function () {
                    $('#loadData').show();/*Se muestra el gif de carga antes de
                    solicitar los datos a la bd*/
                }
            })
            .done(function (resp) {
                /*Se transforma los datos que se obtienen en un objeto json*/
                var appointment = JSON.parse(resp);
                var id, name, identityCard, date, hour, status;

                var table =
                    "<table class='table table-bordered table-hover table-responsive'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th scope='col'>Número de registro</th>" +
                    "<th scope='col'>Nombre del cliente</th>" +
                    "<th scope='col'>Número de cédula</th>" +
                    "<th scope='col'>Fecha de la cita</th>" +
                    "<th scope='col'>Hora de la cita</th>" +
                    "<th scope='col'>Estado de la cita</th>" +
                    "<th scope='col'>Eliminar</th>" +
                    "<th scope='col'>Actualizar</th>" +
                    "</tr>" +
                    "</thead>" +
                    "<tbody>";

                for (var i = 0; i < appointment.aaData.length; i++) {

                    id = appointment.aaData[i].id;
                    name = appointment.aaData[i].user.name;
                    identityCard = appointment.aaData[i].user.identityCard;
                    date = appointment.aaData[i].date;
                    hour = appointment.aaData[i].hour;
                    status = appointment.aaData[i].status;

                    table +=
                        "<tr>" +
                        "<th scope='row'>" + appointment.aaData[i].id + "</th>" +
                        "<td>" + appointment.aaData[i].user.name + "</td>" +
                        "<td>" + appointment.aaData[i].user.identityCard + "</td>" +
                        "<td>" + appointment.aaData[i].date + "</td>" +
                        "<td>" + appointment.aaData[i].hour + "</td>" +
                        "<td>" + appointment.aaData[i].status + "</td>" +
                        "<td> <a href='CancelAppointmentSpecialist.aspx?id=" + id + "&name=" + name + "&identityCard=" + identityCard + "&date=" + date + "&hour=" + hour +"&status=" + status + "'>Cancelar </a> </td>" +
                        "<td> <a href='UpdateAppointmentSpecialist.aspx?id=" + id + "&name=" + name + "&identityCard=" + identityCard + "&date=" + date + "&hour=" + hour +"&status=" + status + "'>Actualizar </a> </td>" +
                        "</tr>";
                }

                table +=
                "</tbody>" +
                    "</table>";
                //Se asignan la tabla al div
                $("#informationtable").html(table);

                /*Se oculta el gif de carga para mostrar los datos*/
                $('#loadData').hide();

                //alert(appointment.aaData[i].user.identityCard)
            }).fail(function (error, textStatus, errorThrown) {
                console.log(error.status); //Check console for output
                //$("#loadIMg").hide();//#datos es un div
            });


            /*Se hace la busqueda de la aplicación de acuerdo a lo que ingreso el usuario*/
            $('#app_search').keyup(function () {
                var identityCard = $(this).val();

                $.ajax({
                    url: '../../../SalutemService.asmx/getAppointmentByIdentityCardBusiness',
                    type: 'POST',
                    dataType: 'text',
                    data: { identityCard: identityCard },
                    beforeSend: function () {
                    }
                })
                .done(function (resp) {
                    /*Se transforma los datos que se obtienen en un objeto json*/
                    var appointment = JSON.parse(resp);
                    var id, name, identityCard, date, hour, status;

                    var table =
                        "<table class='table table-bordered table-hover table-responsive'>" +
                        "<thead>" +
                        "<tr>" +
                        "<th scope='col'>Número de registro</th>" +
                        "<th scope='col'>Nombre del cliente</th>" +
                        "<th scope='col'>Número de cédula</th>" +
                        "<th scope='col'>Fecha de la cita</th>" +
                        "<th scope='col'>Hora de la cita</th>" +
                        "<th scope='col'>Estado de la cita</th>" +
                        "<th scope='col'>Eliminar</th>" +
                        "<th scope='col'>Actualizar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (var i = 0; i < appointment.aaData.length; i++) {

                        id = appointment.aaData[i].id;
                        name = appointment.aaData[i].user.name;
                        identityCard = appointment.aaData[i].user.identityCard;
                        date = appointment.aaData[i].date;
                        hour = appointment.aaData[i].hour;
                        status = appointment.aaData[i].status;

                        table +=
                            "<tr>" +
                            "<th scope='row'>" + appointment.aaData[i].id + "</th>" +
                            "<td>" + appointment.aaData[i].user.name + "</td>" +
                            "<td>" + appointment.aaData[i].user.identityCard + "</td>" +
                            "<td>" + appointment.aaData[i].date + "</td>" +
                            "<td>" + appointment.aaData[i].hour + "</td>" +
                            "<td>" + appointment.aaData[i].status + "</td>" +
                            "<td> <a href='CancelAppointmentSpecialist.aspx?id=" + id + "&name=" + name + "&identityCard=" + identityCard + "&date=" + date + "&hour=" + hour +"&status=" + status + "'>Cancelar </a> </td>" +
                            "<td> <a href='UpdateAppointmentSpecialist.aspx?id=" + id + "&name=" + name + "&identityCard=" + identityCard + "&date=" + date + "&hour=" + hour +"&status=" + status + "'>Actualizar </a> </td>" +
                            "</tr>";
                    }

                    table +=
                    "</tbody>" +
                        "</table>";
                    //Se asignan la tabla al div
                    $("#informationtable").html(table);

                    /*Se oculta el gif de carga para mostrar los datos*/
                    $('#loadData').hide();

                    $("#informationtable").html(table);

                }).fail(function (error, textStatus, errorThrown) {
                    console.log(error.status); //Check console for output
                    //$("#loadIMg").hide();//#datos es un div
                });
            });
        })
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
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <a class="navbar-brand" href='<%=Page.ResolveUrl("~/DefaultSpecialist.aspx") %>'>Salutem</a>
</asp:Content>
