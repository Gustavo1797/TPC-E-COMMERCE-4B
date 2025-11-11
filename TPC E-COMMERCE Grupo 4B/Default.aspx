<%@ Page Language="C#" AutoEventWireup="true"
    MasterPageFile="~/MasterPage.master"
    CodeBehind="Default.aspx.cs"
    Inherits="TPC_E_COMMERCE_Grupo_4B.WebForm1" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Inicio
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="h3 mb-3">Bienvenido a Muñeco.store</h1>
    <p class="text-muted mb-4">
        Descubrí nuestros perfumes destacados.
    </p>

    <!-- 🔽 SECCIÓN DE PRODUCTOS (ancla para el botón "Productos" del menú) -->
    <div id="productos">
        <div class="row">
            <% foreach (dominio.Producto prd in listProductos) { %>
                <div class="col-md-4 mb-4">
                    <div class="card h-100 shadow-sm">
                        <!-- Imagen principal -->
                        <img src="<%= prd.ListImagen[0].ImagenUrl %>"
                             class="card-img-top"
                             alt="<%= prd.Nombre %>" />

                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title"><%= prd.Nombre %></h5>
                            <p class="card-text small text-muted"><%= prd.Descripcion %></p>
                            <p class="fw-bold mb-2 text-primary">
                                $ <%= prd.Precio.ToString("N2") %>
                            </p>

                            <div class="mt-auto d-flex gap-2">
                                <a href="VerProducto.aspx?id=<%= prd.IdProducto %>"
                                   class="btn btn-outline-primary btn-sm">
                                    Ver detalle
                                </a>
                                <a href="Carrito.aspx?add=<%= prd.IdProducto %>"
                                   class="btn btn-primary btn-sm">
                                    Agregar al carrito
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            <% } %>
        </div>
    </div>

</asp:Content>
