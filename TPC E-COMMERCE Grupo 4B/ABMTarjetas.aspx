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
            >

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

                <asp:BoundField HeaderText="Modificar" DataField="Nombre" />

                <asp:TemplateField HeaderText="Compania" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnModificar" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEliminar" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
    </div>

    <div class="card">
        <div class="card-header bg-primary text-white">
            <asp:Label ID="lblTituloCard" runat="server" Text="Alta de Categoria"></asp:Label>
        </div>

        <div class="card-body">

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ej: Mi Categoria"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" placeholder="Ingresa una descripción..."></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:CheckBox ID="chkEstado" runat="server" Text="Categoria Activa" Checked="true" CssClass="form-check-input" Enabled="false" />
            </div>

            <div class="d-grid gap-2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnClick" />

                <a href="AdminDashboard.aspx" class="btn btn-link">Cancelar</a>
            </div>

        </div>
    </div>

</asp:Content>
