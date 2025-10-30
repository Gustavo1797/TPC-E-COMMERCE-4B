<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeBehind="Default.aspx.cs" Inherits="TPC_E_COMMERCE_Grupo_4B.WebForm1" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Inicio
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-3xl font-bold mb-3">BIENVENIDO A MUÑECO STORE, LA PAGINA DE MEJORES PERFUMES DEL MUNDO </h1>
    <p class="text-slate-600 dark:text-slate-400">
        Esta es la página principal. La MasterPage ya funciona correctamente.
    </p>

    <div class="row">
    <%
        foreach (dominio.Producto prd in listProductos)
        {
%>
    <div class='col-md-4 mb-4'>
        <div class="card h-100">

            <div id="carouselExampleFade<%=prd.IdProducto%>" class="carousel slide carousel-fade">

                <div class="carousel-inner">
                    <%
                        for (int i = 0; i < prd.ListImagen.Count ; i++)
                        {
                            if (i == 0)
                            {
                    %>
                    <div class="carousel-item active">
                        <img src="<% = prd.ListImagen[i].ImagenUrl%>" class="d-block w-100" alt="...">
                    </div>
                    <%
                        }
                        else
                        {
                    %>
                    <div class="carousel-item">
                        <img src="<% =prd.ListImagen[i].ImagenUrl %>" class="d-block w-100" alt="...">
                    </div>
                    <%
                            }
                        }
                    %>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleFade<%=prd.IdProducto %>" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleFade<%=prd.IdProducto %>" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>

            </div>
            <div class="card-body">
                <h5 class="card-title"><%= prd.Nombre %></h5>
                <p class="card-text"><%= prd.Descripcion %></p>
                <a href="VerProducto.aspx?id=<%=prd.IdProducto %>" class="btn btn-primary">Elegir</a>
            </div>
        </div>
    </div>
    <%
        }
%>
</div>

</asp:Content>