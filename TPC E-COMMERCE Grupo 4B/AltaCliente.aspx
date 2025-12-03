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
                <form>
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <input type="text" class="form-control" id="txtNombre" placeholder="Tu nombre">
                        </div>
                        <div class="col-md-6">
                            <label for="txtApellido" class="form-label">Apellido</label>
                            <input type="text" class="form-control" id="txtApellido" placeholder="Tu apellido">
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="txtEmail" class="form-label">Email</label>
                            <input type="email" class="form-control" id="txtEmail" placeholder="nombre@ejemplo.com">
                        </div>
                        <div class="col-md-6">
                            <label for="txtPassword" class="form-label">Password</label>
                            <input type="password" class="form-control" id="txtPassword" placeholder="******">
                        </div>
                    </div>

                    <div class="mb-3">
                        <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento</label>
                        <input type="date" class="form-control" id="txtFechaNacimiento">
                    </div>

                    <hr />

                    <div class="row mb-3 align-items-center">
                        <div class="col-md-8">
                            <label for="inputImagen" class="form-label">Imagen de Perfil</label>
                            <input class="form-control" type="file" id="inputImagen" accept="image/*">
                        </div>

                        <div class="col-md-4 text-center">
                            <label class="form-label d-block">Vista Previa</label>
                            <img id="imagenView"
                                src="https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png"
                                class="img-thumbnail rounded-circle"
                                style="width: 150px; height: 150px; object-fit: cover;"
                                alt="Foto de perfil">
                        </div>
                    </div>

                    <div class="d-grid gap-2">
                        <button type="submit" class="btn btn-success btn-lg">Guardar cambios</button>
                    </div>
                </form>
            </div>
        </div>
    </div>

</asp:Content>
