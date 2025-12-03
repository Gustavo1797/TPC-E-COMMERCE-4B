<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="TPC_E_COMMERCE_Grupo_4B.AltaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <div class="card" style="max-width: 700px; margin: auto;">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">Perfil de Usuario</h4>
            </div>
            <div class="card-body">

                <div class="row mb-3">
                    <div class="col-md-6">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" type="text" class="form-control" ID="txtNombre" placeholder="Tu nombre" />

                    </div>
                    <div class="col-md-6">
                        <label for="txtApellido" class="form-label">Apellido</label>
                        <asp:TextBox runat="server" type="text" class="form-control" ID="txtApellido" placeholder="Tu apellido" />
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <label for="txtEmail" class="form-label">Email</label>
                        <asp:TextBox runat="server" type="email" class="form-control" ID="txtEmail" placeholder="nombre@ejemplo.com" />
                    </div>
                    <div class="col-md-6">
                        <label for="txtPassword" class="form-label">Password</label>
                        <asp:TextBox runat="server" type="password" class="form-control" ID="txtPassword" placeholder="******" />
                    </div>
                </div>

                <div class="mb-3">
                    <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento</label>
                    <asp:TextBox runat="server" type="date" class="form-control" ID="txtFechaNacimiento" />
                </div>

                <div class="row mb-3 align-items-center">
                    <div class="col-md-8">
                        <label for="txtImagen" class="form-label">Imagen de Perfil</label>
                        <input class="form-control" type="file" id="txtImagen" runat="server" onchange="cargarImagen(this)">
                    </div>

                    <div class="col-md-4 text-center">
                        <asp:Image ImageUrl="https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png"
                            runat="server"
                            ID="imagenView"
                            class="img-thumbnail rounded-circle"
                            Style="width: 150px; height: 150px; object-fit: contain; " />
                    </div>
                </div>

                <div class="d-grid gap-2">
                    <asp:Button ID="btnGuardar" Text="Guardar cambios" runat="server" class="btn btn-success btn-lg" OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
