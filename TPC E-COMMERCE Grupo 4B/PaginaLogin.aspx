<%@ Page Title="Ingresar" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeBehind="PaginaLogin.aspx.cs"
    Inherits="TPC_E_COMMERCE_Grupo_4B.PaginaLogin" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Ingresar
</asp:Content>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <style>
        .login-container {
            max-width: 400px;
            margin: 50px auto;
        }
    </style>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="login-container">
        <div class="card shadow-sm border-0">
            <div class="card-body">
                <h2 class="h4 mb-3 text-center">Iniciar sesión</h2>
                <p class="text-center text-muted mb-4">
                    Iniciá sesión para continuar comprando en <strong>Muñeco.store</strong>.
                </p>

                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Correo electrónico</label>
                    <asp:TextBox ID="txtEmail" runat="server"
                        CssClass="form-control"
                        TextMode="Email"
                        placeholder="Ingresá tu correo" />
                </div>

                <div class="mb-3">
                    <label for="txtPassword" class="form-label">Contraseña</label>
                    <asp:TextBox ID="txtPassword" runat="server"
                        CssClass="form-control"
                        TextMode="Password"
                        placeholder="Ingresá tu contraseña" />
                </div>

                <asp:Button ID="btnLogin" runat="server" Text="Ingresar"
                    CssClass="btn btn-primary w-100 mb-3"
                    OnClick="btnLogin_Click" />

                <p class="text-center small text-muted mb-0">
                    ¿No tenés cuenta?
                    <a href="AltaUsuario.aspx" class="text-primary text-decoration-none">Registrate acá</a>.
                </p>
            </div>
        </div>
    </div>

</asp:Content>