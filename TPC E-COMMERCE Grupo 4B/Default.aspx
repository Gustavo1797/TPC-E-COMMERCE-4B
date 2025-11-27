<div id="productos">
    <div class="row">

        <% if (listProductos != null && listProductos.Count > 0)
        {
            foreach (dominio.Producto prd in listProductos)
            { %>

                <div class="col-md-4 mb-4">
                    <div class="card h-100 shadow-sm">

                        <img src="<%= prd.ListImagen[0].ImagenUrl %>"
                             class="card-img-top"
                             alt="<%= prd.Nombre %>" />

                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title"><%= prd.Nombre %></h5>
                            <p class="fw-bold mb-2 text-primary">
                                $ <%= prd.Precio.ToString("N2") %>
                            </p>

                            <div class="mt-auto d-flex gap-2">
                                <a href="Default.aspx?id=<%= prd.IdProducto %>"
                                   class="btn btn-outline-primary btn-sm">
                                   Ver detalle
                                </a>

                                <a href="Carrito.aspx?add=<%= prd.IdProducto %>"
                                   class="btn btn-primary btn-sm mt-auto">
                                   Agregar al carrito
                                </a>
                            </div>
                        </div>

                    </div>
                </div>  <!-- ✔️ Cierre correcto -->

        <%  }
        }
        else
        { %>

            <div class="col-12">
                <p class="text-muted">No hay productos para mostrar.</p>
            </div>

        <% } %>

    </div>
</div>

