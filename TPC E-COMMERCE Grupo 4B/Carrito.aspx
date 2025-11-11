<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeBehind="Carrito.aspx.cs"
    Inherits="TPC_E_COMMERCE_Grupo_4B.Carrito" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Carrito
</asp:Content>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <style>
        .cart-container {
            max-width: 900px;
            margin: 0 auto;
        }
    </style>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="cart-container">
        <h2 class="h3 mb-3">Carrito de compras</h2>
        <p class="text-muted mb-4">
            Revisá los productos antes de confirmar tu compra.
        </p>

  
        <asp:GridView ID="gvCarrito" runat="server"
            CssClass="table table-striped table-bordered align-middle"
            AutoGenerateColumns="False"
            EmptyDataText="Tu carrito está vacío.">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>

    
        <div class="d-flex justify-content-between align-items-center mt-3">
            <div>
                <a href="Productos.aspx" class="btn btn-outline-secondary">
                    ← Seguir comprando
                </a>
            </div>

            <div class="text-end">
                <p class="mb-1 fw-semibold">
                    Total:
                    <asp:Label ID="lblTotal" runat="server" Text="$ 0,00"></asp:Label>
                </p>
                <asp:Button ID="btnConfirmar" runat="server"
                    Text="Confirmar compra"
                    CssClass="btn btn-primary"
                    OnClick="btnConfirmar_Click" />
            </div>
        </div>
    </div>

</asp:Content>