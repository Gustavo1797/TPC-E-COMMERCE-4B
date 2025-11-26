<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaItem.aspx.cs" Inherits="TPC_E_COMMERCE_Grupo_4B.ListaItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-12">
            <h2 class="mb-4">Listado de productos</h2>
        </div>
    </div>

    <div class="table-responsive">
        <asp:GridView ID="dgvProductos" runat="server" 
            AutoGenerateColumns="False" 
            ShowHeaderWhenEmpty="True"
            CssClass="table table-striped table-hover table-bordered align-middle"
            
            AllowPaging="True" 
            PageSize="5" 
            OnPageIndexChanging="dgvProductos_PageIndexChanging"
            
            DataKeyNames="IdProducto" 
            OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged"> 
            
            <EmptyDataTemplate>
                <div class="alert alert-info mt-2" role="alert">
                    <h5 class="alert-heading">¡Aún no hay datos!</h5>
                    No se ha registrado ninguna marca en el sistema.
                </div>
            </EmptyDataTemplate>
            
            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
    
            <Columns>
                
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
    
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />

                <asp:BoundField DataField="Precio" HeaderText="Precio" />
    
                <asp:BoundField DataField="Stock" HeaderText="Stock" />

                <asp:BoundField DataField="Categoria.Nombre" HeaderText="Categoria" />
    
                <asp:BoundField DataField="Marca.Nombre" HeaderText="Marca" />

                <asp:BoundField DataField="Peso" HeaderText="Peso" />
    
                <asp:CheckBoxField DataField="Estado" HeaderText="Activo" 
                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
    
                <asp:CommandField ShowSelectButton="True" SelectText="✏️" ControlStyle-CssClass="btn btn-sm btn-warning" HeaderText="Editar" />
    
            </Columns>
    
        </asp:GridView>
    </div>

</asp:Content>
