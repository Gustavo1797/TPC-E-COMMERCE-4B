<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ItemSeleccionado.aspx.cs" Inherits="TPC_E_COMMERCE_Grupo_4B.ItemSeleccionado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

   <!-- Contenedor principal de la página (TU CÓDIGO PEGADO) -->
        <div class="container">
            <div class="card card-producto p-4 p-md-5">
                <div class="row">

                    <!-- ============================================= -->
                    <!-- Columna Izquierda: GALERÍA DE IMÁGENES        -->
                    <!-- ============================================= -->
                    <div class="col-lg-6">
                        <!-- Imagen Principal -->
                        <div class="mb-3">
                            <!-- 
                            ==================================================================
                             CORRECCIÓN: 
                             Añadí ClientIDMode="Static" para que el JavaScript 
                             de abajo pueda encontrar "imgPrincipal".
                            ==================================================================
                            -->
                            <asp:Image ID="imgPrincipal" runat="server" CssClass="img-fluid w-100 rounded" Style="max-height: 500px; object-fit: cover;" ClientIDMode="Static" />
                        </div>
                        
                        <!-- Galería de Miniaturas (Thumbnails) -->
                        <!-- Esta es tu galería estática -->
                        <div class="row gx-2">
                        <% 
                            for (int i = 0; i < producto.ListImagen.Count; i++)
                            {
                                if (i == 0)
                                {%>
                                    <div class="col-3">
                                        <img src="<% =producto.ListImagen[i].ImagenUrl%>" class="img-thumbnail img-thumbnail-gallery active" />
                                    </div>
                                <%
                                }
                                else
                                {%>
                                    <div class="col-3">
                                        <img src="<% =producto.ListImagen[i].ImagenUrl %>" class="img-thumbnail img-thumbnail-gallery" />
                                    </div><%
                                }
                            }
                        %>
                        </div>                        
                    </div>

                    <!-- ============================================= -->
                    <!-- Columna Derecha: INFORMACIÓN DEL PRODUCTO     -->
                    <!-- ============================================= -->
                    <div class="col-lg-6 ps-lg-5 mt-4 mt-lg-0">
                        
                        <!-- Categoría -->
                        <div class="mb-2">
                            <asp:Label ID="lblCategoria" runat="server" Text="Categoría" CssClass="text-muted" />
                        </div>

                        <!-- Nombre del Item -->
                        <h1 class="display-5 fw-bold mb-3">
                            <asp:Label ID="lblNombreItem" runat="server" Text="Nombre del Item" />
                        </h1>

                        <!-- Precio -->
                        <p class="display-4 fw-light my-3">
                            <asp:Label ID="lblPrecio" runat="server" Text="$0.00" />
                        </p>

                        <!-- Stock -->
                        <div class="mb-3">
                            <span class="badge bg-success fs-6">
                                <i class="bi bi-check-circle"></i> En Stock
                            </span>
                            <span class="ms-2 text-muted">
                                (<asp:Label ID="lblStock" runat="server" Text="0" /> disponibles)
                            </span>
                        </div>
                        
                        <!-- Botón de Compra -->
                        <div class="d-grid gap-2 my-4">
                            <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al Carrito" CssClass="btn btn-primary btn-lg" OnClick="btnAgregarCarrito_Click" />
                        </div>

                        <!-- Lista de Especificaciones -->
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item px-0 py-2">
                                <span class="text-muted" style="width: 100px; display: inline-block;">Vendedor:</span>
                                <strong><asp:Label ID="lblVendedor" runat="server" Text="-" /></strong>
                            </li>
                            <li class="list-group-item px-0 py-2">
                                <span class="text-muted" style="width: 100px; display: inline-block;">Marca:</span>
                                <strong><asp:Label ID="lblMarca" runat="server" Text="-" /></strong>
                            </li>
                            <li class="list-group-item px-0 py-2">
                                <span class="text-muted" style="width: 100px; display: inline-block;">Peso:</span>
                                <strong><asp:Label ID="lblPeso" runat="server" Text="-" /> kg</strong>
                            </li>
                        </ul>
                    </div>
                </div>

                <!-- ============================================= -->
                <!-- Fila Inferior: DESCRIPCIÓN DETALLADA          -->
                <!-- ============================================= -->
                <div class="row mt-5">
                    <div class="col-12">
                        <hr />
                        <h2 class="h4">Descripción del Producto</h2>
                        <p class="lead text-muted">
                            <asp:Literal ID="litDescripcion" runat="server" Text="Descripción larga del producto..." />
                        </p>
                    </div>
                </div>

            </div>
        </div>

</asp:Content>
