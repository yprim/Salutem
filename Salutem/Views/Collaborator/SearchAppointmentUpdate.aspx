<%@ Page Title="" Language="C#" MasterPageFile="~/Salutem.Master" AutoEventWireup="true" CodeBehind="SearchAppointmentUpdate.aspx.cs" Inherits="Salutem.Views.Collaborator.SearchAppointmentUpdate" %>

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
                        "<td> <a href='UpdateAppointment.aspx?id=" + id + "&name=" + name + "&identityCard=" + identityCard + "&date=" + date + "&hour=" + hour +"&status=" + status + "'>Actualizar </a> </td>" +
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
                            "<td> <a href='UpdateAppointment.aspx?id=" + id + "&name=" + name + "&identityCard=" + identityCard + "&date=" + date + "&hour=" + hour +"&status=" + status + "'>Actualizar </a> </td>" +
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
            <li class="active"><a href='<%=Page.ResolveUrl("~/Default.aspx") %>'>Inicio</a></li>

            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="badge custom-badge red pull-right"></span>Administrar citas<b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a id="menuAppointmentInsert" runat="server">Agendar cita</a></li>
                    <li><a id="menuAppointmentCancel" runat="server">Cancelar cita</a></li> 
                    <li><a id="menuAppointmentUpdate" runat="server">Actualizar cita</a></li>
                </ul>
            </li>

            <li><a href="#credits">Créditos</a></li>

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