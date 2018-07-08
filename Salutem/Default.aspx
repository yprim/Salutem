<%@ Page Title="" Language="C#" MasterPageFile="~/Salutem.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Salutem.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="slider">
        <div id="about-slider">
            <div id="carousel-slider" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators visible-xs">
                    <li data-target="#carousel-slider" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel-slider" data-slide-to="1"></li>
                    <li data-target="#carousel-slider" data-slide-to="2"></li>
                </ol>

                <div class="carousel-inner">
                    <div class="item active">
                        <img src='<%=Page.ResolveUrl("~/img/Convergente.jpeg") %>' class="img-responsive" alt="">
                        <div class="carousel-caption">
                            <div class="content"> <!-- Div con color y borde redondeado-->
                                <br>
                                <div class="wow fadeInUp" data-wow-offset="0" data-wow-delay="0.3s">
                                    <h2><span>Convergente</span></h2>
                                </div>
                                <div class="wow fadeInUp" data-wow-offset="0" data-wow-delay="0.6s">
                                    <p>El aprendizaje convergente combina la conceptualización abstracta y la experimentación activa.</p>
                                </div>
                                <div class="wow fadeInUp" data-wow-offset="0" data-wow-delay="0.9s">
                                    <form class="form-inline">
                                        <div class="form-group">
                                            <button type="button" name="Live Demo"
                                            class="btn btn-info btn-lg" data-toggle="modal"
                                            data-target="#ModalConvergenteInfo">
                                            <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
                                            Más información</button>
                                        </div>
                                        <!-- <div class="form-group">
                                            <button type="getnow" name="Get Now" class="btn btn-primary btn-lg" required="required">Get Now</button>
                                        </div> -->
                                    </form>
                                </div>
                                <br>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <img src='<%=Page.ResolveUrl("~/img/Asimilador.jpeg") %>' class="img-responsive" alt="">
                        <div class="carousel-caption">
                            <div class="content"> <!-- Div con color y borde redondeado-->
                                <br>
                                <div class="wow fadeInUp" data-wow-offset="0" data-wow-delay="0.3s">
                                    <h2><span>Asimilador</span></h2>
                                </div>
                                <div class="wow fadeInUp" data-wow-offset="0" data-wow-delay="0.6s">
                                    <p>El aprendizaje asimilador combina la conceptualización abstracta y la observación reflexiva.</p>
                                </div>

                                <div class="wow fadeInUp" data-wow-offset="0" data-wow-delay="0.9s">
                                    <form class="form-inline">
                                        <div class="form-group">
                                            <button type="button" name="purchase"
                                            class="btn btn-info btn-lg" data-toggle="modal"
                                            data-target="#ModalAsimiladorInfo">
                                            <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
                                            Más información</button>
                                        </div>
                                        <!-- <div class="form-group">
                                            <button type="getnow" name="subscribe" class="btn btn-primary btn-lg" required="required">Get Now</button>
                                        </div>-->
                                    </form>
                                </div>
                                <br>
                            </div>
                        </div>
                    </div>

                    <div class="item">
                        <img src='<%=Page.ResolveUrl("~/img/Divergente.jpeg") %>' class="img-responsive" alt="">
                        <div class="carousel-caption">
                            <div class="content"> <!-- Div con color y borde redondeado-->
                                <br>
                                <div class="wow fadeInUp" data-wow-offset="0" data-wow-delay="1.0s">
                                    <h2>Divergente</h2>
                                </div>
                                <div class="wow fadeInUp" data-wow-offset="0" data-wow-delay="1.3s">
                                    <p>El aprendizaje divergente combina la experiencia concreta y la observación reflexiva.</p>
                                </div>
                                <div class="wow fadeInUp" data-wow-offset="0" data-wow-delay="1.6s">
                                    <form class="form-inline">
                                        <div class="form-group">
                                            <button type="button" name="purchase"
                                            class="btn btn-info btn-lg" data-toggle="modal"
                                            data-target="#ModalDivergenteInfo">
                                            <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
                                            Más información</button>
                                        </div>
                                        <!-- <div class="form-group">
                                            <button type="getnow" name="subscribe" class="btn btn-primary btn-lg" required="required">Get Now</button>
                                        </div>-->
                                    </form>
                                </div>
                                <br>
                            </div>
                        </div>
                    </div>
                    <div class="item">
                        <img src='<%=Page.ResolveUrl("~/img/Acomodador.jpeg") %>' class="img-responsive" alt="">
                        <div class="carousel-caption">
                            <div class="content"> <!-- Div con color y borde redondeado-->
                                <br>
                                <div class="wow fadeInUp" data-wow-offset="0" data-wow-delay="0.3s">
                                    <h2>Acomodador</h2>
                                </div>
                                <div class="wow fadeInUp" data-wow-offset="0" data-wow-delay="0.6s">
                                    <p>El aprendizaje acomodador combina la experiencia concreta y la experimentación activa</p>
                                </div>
                                <div class="wow fadeInUp" data-wow-offset="0" data-wow-delay="0.9s">
                                    <form class="form-inline">
                                        <div class="form-group">
                                            <button type="button" name="purchase"
                                            class="btn btn-info btn-lg" data-toggle="modal"
                                            data-target="#ModalAcomodadorInfo">
                                            <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
                                            Más información</button>
                                        </div>
                                        <!-- <div class="form-group">
                                            <button type="getnow" name="subscribe" class="btn btn-primary btn-lg" required="required">Get Now</button>
                                        </div> -->
                                    </form>
                                </div>
                                <br>
                            </div>
                        </div>
                    </div>
                </div>

                <a class="left carousel-control hidden-xs" href="#carousel-slider" data-slide="prev">
                    <i class="fa fa-angle-left"></i>
                </a>

                <a class=" right carousel-control hidden-xs" href="#carousel-slider" data-slide="next">
                    <i class="fa fa-angle-right"></i>
                </a>
            </div>
            <!--/#carousel-slider-->
        </div>
        <!--/#about-slider-->
    </div>

    <div id="servicios">
        <div class="container">
            <div class="text-center">
                <h3>Servicios que ofrecemos</h3>
                <p class="p-style">En esta sección se presentan los diferentes servicios que ofrecemos a nuestros clientes.</p>
            </div>
            <div class="row">
                <figure class="effect-chico">
                    <div class="col-md-3 wow fadeInUp" data-wow-offset="0" data-wow-delay="0.3s">
                        <a data-toggle="modal" data-target="#ModalConvergenteVideo">
                            <img src='<%=Page.ResolveUrl("~/img/work/Convergente.jpeg") %>' class="img-responsive" alt="">
                            <div class="middle">
                                <div class="text">Convergente</div>
                            </div>
                        </a>
                    </div>
                </figure>
                <figure class="effect-chico">
                    <div class="col-md-3 wow fadeInUp" data-wow-offset="0" data-wow-delay="0.3s">
                        <a data-toggle="modal" data-target="#ModalAsimiladorVideo">
                            <img src='<%=Page.ResolveUrl("~/img/work/Asimilador.jpeg") %>' class="img-responsive" alt="">
                            <div class="middle">
                                <div class="text">Asimilador</div>
                            </div>
                        </a>
                    </div>
                </figure>
                <figure class="effect-chico">
                    <div class="col-md-3 wow fadeInDown" data-wow-offset="0" data-wow-delay="0.3s">
                        <a data-toggle="modal" data-target="#ModalDivergenteVideo">
                            <img src='<%=Page.ResolveUrl("~/img/work/Divergente.png") %>' class="img-responsive" alt="">
                            <div class="middle">
                                <div class="text">Divergente</div>
                            </div>
                        </a>
                    </div>
                </figure>
                <figure class="effect-chico">
                    <div class="col-md-3 wow fadeInDown" data-wow-offset="0" data-wow-delay="0.3s">
                        <a data-toggle="modal" data-target="#ModalAcomodadorVideo">
                            <img src='<%=Page.ResolveUrl("~/img/work/Acomodador.jpeg") %>' class="img-responsive" alt="">
                            <div class="middle">
                                <div class="text">Acomodador</div>
                            </div>
                        </a>
                    </div>
                </figure>
            </div>
        </div>
    </div>
    <!--/#gallery-->
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
                </ul>
            </li>

            <li><a href="#credits">Créditos</a></li>

            <li><a data-placement="bottom" data-toggle="popover" data-title="Iniciar Sesión" data-container="body" type="button" data-html="true" id="login">Iniciar Sesión</a></li>
			<div id="popover-content" class="hide">
				<form id="form1" runat="server">
					<div class="form-group">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
                    </div>
					<div class="form-group">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>		
                    </div>

                    

                    <asp:Button ID="btnLogin" CssClass="btn btn-primary" runat="server"  Text="Login" OnClick="btnLogin_Click"/>
				</form>
			</div>

            <div class="input-group">
                <input type="text" class="form-control" placeholder="Buscar...">
                <span class="input-group-btn">
                    <button class="btn btn-info" type="button">Buscar</button>
                </span>
            </div><!-- /input-group -->
        </ul>
    </div>

   

</asp:Content>