﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Salutem.Master" AutoEventWireup="true" CodeBehind="SearchDiagnosisCancel.aspx.cs" Inherits="Salutem.Views.Specialist.Diagnosis.SearchDiagnosisCancel" %>

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
                <h3>Buscar diágnostico</h3>
            </center>
            <div class="col-md-offset-4">
                <div class="col-lg-8">
                    <br>
                    <form id="formBuscarCita" runat="server">
                        <div class="form-group">
                            <label for="NumCedula"> Número de cédula</label>
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

            var identityCard = $(this).val();

            $.ajax({
                url: '../../../SalutemService.asmx/getAllDiagnosisBusiness',
                type: 'POST',
                dataType: 'text',
                data: { identityCard: identityCard },
                beforeSend: function () {
                    $('#loadData').show();/*Se muestra el gif de carga antes de
                    solicitar los datos a la bd*/
                }
            })
            .done(function (resp) {
                /*Se transforma los datos que se obtienen en un objeto json*/
                var appointment = JSON.parse(resp);
                var id, name, identityCard, date, hour, status, description = "";

                var table =
                    "<table class='table table-bordered table-hover table-responsive'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th scope='col'>Número de registro</th>" +
                    "<th scope='col'>Nombre del cliente</th>" +
                    "<th scope='col'>Número de cédula</th>" +
                    "<th scope='col'>Fecha del diagnóstico</th>" +
                    "<th scope='col'>Hora del diagnóstico</th>" +
                    "<th scope='col'>Descripción</th>" +
                    "<th scope='col'>Estado del diagnóstico</th>" +
                    "<th scope='col'>Eliminar</th>" +
                    "</tr>" +
                    "</thead>" +
                    "<tbody>";

                for (var i = 0; i < appointment.aaData.length; i++) {

                    id = appointment.aaData[i].id;
                    name = appointment.aaData[i].userName;
                    identityCard = appointment.aaData[i].identityCard;
                    date = appointment.aaData[i].date;
                    hour = appointment.aaData[i].hour;
                    status = appointment.aaData[i].status;
                    description = appointment.aaData[i].description;

                    table +=
                        "<tr>" +
                        "<th scope='row'>" + appointment.aaData[i].id + "</th>" +
                        "<td>" + appointment.aaData[i].userName + "</td>" +
                        "<td>" + appointment.aaData[i].identityCard + "</td>" +
                        "<td>" + appointment.aaData[i].date + "</td>" +
                        "<td>" + appointment.aaData[i].hour + "</td>" +
                        "<td>" + appointment.aaData[i].description + "</td>" +
                        "<td>" + appointment.aaData[i].status + "</td>" +
                        "<td> <a href='DeleteDiagnosis.aspx?id=" + id + "&name=" + name + "&identityCard=" + identityCard + "&date=" + date + "&hour=" + hour +"&status=" + status + "&description=" + description + "'>Eliminar </a> </td>" +
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
                    url: '../../../SalutemService.asmx/getDiagnosisFilter',
                    type: 'POST',
                    dataType: 'text',
                    data: { identityCard: identityCard},
                    beforeSend: function () {
                        $('#loadData').show();/*Se muestra el gif de carga antes de
                        solicitar los datos a la bd*/
                    }
                })
                    .done(function (resp) {
                    /*Se transforma los datos que se obtienen en un objeto json*/
                    var appointment = JSON.parse(resp);
                    var id, name, identityCard, date, hour, status, description;

                    var table =
                        "<table class='table table-bordered table-hover table-responsive'>" +
                        "<thead>" +
                        "<tr>" +
                        "<th scope='col'>Número de registro</th>" +
                        "<th scope='col'>Nombre del cliente</th>" +
                        "<th scope='col'>Número de cédula</th>" +
                        "<th scope='col'>Fecha del diagnóstico</th>" +
                        "<th scope='col'>Hora del diagnóstico</th>" +
                        "<th scope='col'>Descripción</th>" +
                        "<th scope='col'>Estado del diagnóstico</th>" +
                        "<th scope='col'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (var i = 0; i < appointment.aaData.length; i++) {

                        id = appointment.aaData[i].id;
                        name = appointment.aaData[i].userName;
                        identityCard = appointment.aaData[i].identityCard;
                        date = appointment.aaData[i].date;
                        hour = appointment.aaData[i].hour;
                        status = appointment.aaData[i].status;
                        description = appointment.aaData[i].description;

                        table +=
                            "<tr>" +
                            "<th scope='row'>" + appointment.aaData[i].id + "</th>" +
                            "<td>" + appointment.aaData[i].userName + "</td>" +
                            "<td>" + appointment.aaData[i].identityCard + "</td>" +
                            "<td>" + appointment.aaData[i].date + "</td>" +
                            "<td>" + appointment.aaData[i].hour + "</td>" +
                            "<td>" + appointment.aaData[i].hour + "</td>" +
                            "<td>" + appointment.aaData[i].description + "</td>" +
                            "<td> <a href='DeleteDiagnosis.aspx?id=" + id + "&name=" + name + "&identityCard=" + identityCard + "&date=" + date + "&hour=" + hour +"&status=" + status + "&description=" + description + "'>Eliminar </a> </td>" +
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
                    <li><a id="menuDiagnosisCreateDiagnosis" runat="server"> Generar diagnóstico</a></li>
                    <li><a id="menuDiagnosisDeleteDiagnosis" runat="server"> Eliminar diagnóstico</a></li> 
                    <li><a id="menuDiagnosisUpdateDiagnosis" runat="server"> Actualizar diagnóstico</a></li>
                    <li><a id="menuDiagnosisGetDiagnosis" runat="server">Obtener diagnóstico</a></li>
                </ul>
            </li>

            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="badge custom-badge red pull-right"></span>Reportes <b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a id="menuCli" runat="server"> Clientes atendidos por día</a></li>
                    <li><a id="menuCh1" runat="server"> Horario con mayor cantidad de visitas</a></li> 
                    <li><a id="menuCh2" runat="server"> Horario con menor cantidad de visitas</a></li>
                </ul>
            </li>

            <li><a href="#credits">Créditos</a></li>

            <li><a href="./LogOut.aspx">LogOut</a></li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <a class="navbar-brand" href='<%=Page.ResolveUrl("~/DefaulSpecialist.aspx") %>'>Salutem</a>
</asp:Content>
