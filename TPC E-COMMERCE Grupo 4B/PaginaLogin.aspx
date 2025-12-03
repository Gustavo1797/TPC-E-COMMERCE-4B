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

    <script>
        function validar() {

            let bandera = true;

            const emailRegex = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/;

            const txtEmail = document.getElementById("txtEmail");
            const txtPassword = document.getElementById("txtPassword");

            txtEmail.classList.remove("is-invalid");
            txtEmail.classList.remove("is-valid");
            txtPassword.classList.remove("is-invalid");
            txtPassword.classList.remove("is-valid");

            if (txtEmail.value.trim() === "" || !txtEmail.checkValidity() || !emailRegex.test(txtEmail.value)) {
                txtEmail.classList.add("is-invalid");
                bandera = false;
            }
            else {
                txtEmail.classList.add("is-valid");
            }

            if (txtPassword.value.trim() === "" || !txtPassword.checkValidity()) {
                txtPassword.classList.add("is-invalid");
                bandera = false;
            }
            else {
                txtPassword.classList.add("is-valid");
            }

            return bandera;
        }
    </script>
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
                        ClientIDMode="Static"
                        CssClass="form-control"
                        TextMode="Email"
                        placeholder="Ingresá tu correo" />
                    <asp:RegularExpressionValidator ErrorMessage="No se ingreso un formato valido de email"
                        ControlToValidate="txtEmail"
                        ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"
                        runat="server" />
                </div>

                <div class="mb-3">
                    <label for="txtPassword" class="form-label">Contraseña</label>
                    <asp:TextBox ID="txtPassword" runat="server"                        
                        ClientIDMode="Static"
                        CssClass="form-control"
                        TextMode="Password"
                        placeholder="Ingresá tu contraseña" />
                </div>

                <asp:Button ID="btnLogin" runat="server" Text="Ingresar"
                    CssClass="btn btn-primary w-100 mb-3"
                    OnClientClick="return validar()"
                    OnClick="btnLogin_Click" />

                <p class="text-center small text-muted mb-0">
                    ¿No tenés cuenta?
                    <a href="AltaUsuario.aspx" class="text-primary text-decoration-none">Registrate acá</a>.
                </p>
            </div>
        </div>
    </div>

</asp:Content>
