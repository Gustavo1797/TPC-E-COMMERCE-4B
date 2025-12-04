<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ABMTarjetas.aspx.cs" Inherits="TPC_E_COMMERCE_Grupo_4B.ABMTarjetas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-12">
            <h2 class="mb-4">Administración de Tarjetas</h2>
        </div>
    </div>

    <div class="table-responsive">
        <asp:GridView ID="dgvTarjetas" runat="server"
            AutoGenerateColumns="False"
            ShowHeaderWhenEmpty="True"
            CssClass="table table-striped table-hover table-bordered align-middle"
            DataKeyNames="IdTarjeta"
            OnRowCommand="dgvTarjetas_RowCommand">

            <EmptyDataTemplate>
                <div class="alert alert-info mt-2" role="alert">
                    <h5 class="alert-heading">¡Aún no hay tarjetas!</h5>
                    No se ha registrado ninguna tarjeta en el sistema.
                </div>
            </EmptyDataTemplate>

            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />

            <Columns>

                <asp:TemplateField HeaderText="Compania" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Image ID="imgTarjeta"
                            ImageUrl='<% # Eval("ImagenUrlTarj") %>'
                            runat="server"
                            Width="30px" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />

                <asp:BoundField HeaderText="N° Serie" DataField="NumeroDeSerie" />

                <asp:TemplateField HeaderText="Modificar" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnModificar" runat="server" Text="Modificar"
                            CssClass="btn btn-sm btn-danger"
                            CommandName="Modificar" CommandArgument='<%# Eval("IdTarjeta") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
    </div>

    <div class="card">
        <div class="card-header bg-primary text-white">
            <asp:Label ID="lblTituloCard" runat="server" Text="Alta de tarjeta"></asp:Label>
        </div>

        <div class="card-body">

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ej: Visa Debito Banco Nacion" />
                <asp:RequiredFieldValidator ErrorMessage="Es necesario ingresar un nombre" ControlToValidate="txtNumeroSerie" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtNumeroSerie" class="form-label">N° Serie</label>
                <asp:TextBox ID="txtNumeroSerie" runat="server" CssClass="form-control" placeholder="Ingrese solo los numeros de la tarjeta" />
                <asp:RequiredFieldValidator 
                    ErrorMessage="Es necesario que ingrese un numero de serie" 
                    ControlToValidate="txtNumeroSerie" 
                    runat="server" />
                <asp:RegularExpressionValidator
                    ErrorMessage="El número de serie debe ser unicamente numerico entre 15 a 16 dígitos."
                    ControlToValidate="txtNumeroSerie"
                    ValidationExpression="^\d{15,16}$"
                    ForeColor="Red"
                    Display="Dynamic"
                    runat="server" />
            </div>

            <div class="d-grid gap-2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" />

                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" Visible="false" OnClick="btnEliminar_Click" />
            </div>

        </div>
    </div>

</asp:Content>
