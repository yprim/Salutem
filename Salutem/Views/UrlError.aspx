<%@ Page Title="" Language="C#" MasterPageFile="~/Salutem.Master" AutoEventWireup="true" CodeBehind="UrlError.aspx.cs" Inherits="Salutem.Views.Urlerror" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div style="width:100%; height:150px"></div>
        <div class="col-lg-12 borderRounded">
            <br />
            <br />
            <center>
                <asp:Label ID="lblError" CssClass="errorColor" runat="server" Text="Error !! usted esta intento acceder de manera fraudulenta a elemetos restrictivos del sistema.
                    Por favor ingrese los credenciales apropiados para acceder a los elementos solictados"></asp:Label>
            </center>

            <br>
            <center>  
                <form id="form1" runat="server">   
                    <!-- Se usa para evitar ataques de peticiones POST de sitios maliciosos-->
                    <asp:Button ID="btnGotoLogin" runat="server" CssClass="btn btn-info" Text="Ir a login" OnClick="btnGotoLogin_Click" /> &nbsp;
                    <br>
                    <br>
                </form>
            </center>
        </div>
    </div>
    <br><br>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <a class="navbar-brand" href='<%=Page.ResolveUrl("~/DefaulSpecialist.aspx") %>'>Salutem</a>
</asp:Content>
