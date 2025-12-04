<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="TPC_E_COMMERCE_Grupo_4B.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-12">
            <h2 class="mb-4">Estado de las ventas</h2>
        </div>
    </div>

    <div class="table-responsive">
        <asp:GridView runat="server" ID="dgvCompras" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" CssClass="table table-striped table-hover table-bordered align-middle" AllowPaging="true" PageSize="10" OnPageIndexChanging="dgvCompras_PageIndexChanging"
            DataKeyNames="IdCompra" OnSelectedIndexChanged="dgvCompras_SelectedIndexChanged">

            <EmptyDataTemplate>
                <div class="alert alert-info mt-2" role="alert">
                    <h5 class="alert-heading">¡Aún no hay datos!</h5>
                    No se han registrado ventas.   
                </div>
            </EmptyDataTemplate>

            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />

            <Columns>
                
                <asp:BoundField DataField="Cliente.Usuario.Email" HeaderText="Usuario" />

                <asp:BoundField DataField="Total" HeaderText="Total" />

                <asp:BoundField DataField="FechaCompra" HeaderText="Fecha" />

                <asp:BoundField DataField="EstadoCompra.Nombre" HeaderText="Estado" />

                <asp:CommandField ShowSelectButton="True" SelectText="✏️" ControlStyle-CssClass="btn btn-sm btn-warning" HeaderText="Editar" />

            </Columns>

        </asp:GridView>
    </div>
    

</asp:Content>
