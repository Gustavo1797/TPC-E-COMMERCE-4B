<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="TPC_E_COMMERCE_Grupo_4B.AltaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-12 col-md-6 col-lg-5">
                    
                    <div class="card shadow-sm rounded-3">
                        <div class="card-header p-4">
                            <h3 class="mb-0 text-center">Crear Cuenta</h3>
                        </div>
                        <div class="card-body p-4">
                            
                            <div class="mb-3">
                                <asp:Label ID="lblEmail" runat="server" Text="Email" For="txtEmail" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                            </div>
                            
                            <div class="mb-3">
                                <asp:Label ID="lblPassword" runat="server" Text="Contraseña" For="txtPassword" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirmar Contraseña" For="txtConfirmPassword" CssClass="form-label"></asp:Label>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                            
                            <div class="d-grid">
                                <asp:Button ID="btnRegister" runat="server" Text="Registrar" CssClass="btn btn-primary btn-lg" OnClick="btnRegister_Click" />
                            </div>
                            
                            <asp:Literal ID="litMensaje" runat="server"></asp:Literal>

                        </div>
                        
                        <div class="card-footer p-4 text-center bg-light">
                            <p class="mb-0">
                                ¿Ya tienes una cuenta? 
                                <a href="Login.aspx">Inicia sesión aquí</a>
                            </p>
                        </div>
                    </div>

                </div>
            </div>
        </div>

</asp:Content>
