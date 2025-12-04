<%@ Page Language="C#" AutoEventWireup="true"
    MaintainScrollPositionOnPostback="true"
    MasterPageFile="~/MasterPage.master"
    CodeBehind="Default.aspx.cs"
    Inherits="TPC_E_COMMERCE_Grupo_4B.WebForm1" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    Inicio
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="h3 mb-3">Bienvenido a Muñeco.store</h1>
    <p class="text-muted mb-4">Descubrí nuestros productos.</p>

    <asp:Label Text="Filtrar por nombre" runat="server" />

    <asp:TextBox runat="server" ID="txtFiltro" CssClass="Form-Control" AutoPostBack="True" OnTextChanged="filtro_TextChanged" />

    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end">
        <div class="mb-3">
            <asp:CheckBox Text="Filtro avanzado"
                CssClass="" ID="chkBoxAvanzado" runat="server"
                AutoPostBack="true" OnCheckedChanged="chkBoxAvanzado_CheckedChanged"/>
        </div>
    </div>

    <% if(FiltroAvanzado) 
    { %>
    <div class="row" >
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" ID="lblCampo" runat="server"/>

                <asp:DropDownList ID="ddlCampo" runat="server" 
                    CssClass="form-control" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    
                    <asp:ListItem text="Marca" value="Marca"/>
                    <asp:ListItem text="Categoria" value="Categoria"/>
                    <asp:ListItem text="Precio" value="Precio"/>

                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Valor" runat="server"/>
                <asp:DropDownList runat="server" ID="ddlValor" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Estado" runat="server" />
                <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                    <asp:ListItem text="Todos"/>
                    <asp:ListItem text="Activo"/>
                    <asp:ListItem text="Inactivo"/>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:button ID="btnBuscar" Text="Buscar" runat="server" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
            </div>
        </div>
    </div>
    <% } %>


    ﻿<div id="productos">
        <div class="row">

            <% if (listProductos != null && listProductos.Count > 0)
                {
                    foreach (dominio.Producto prd in listProductos)
                    { %>

            <div class="col-md-4 mb-4">
                <div class="card h-100 shadow-sm">
                    <div class="ratio ratio-1x1">
                        <div id="carouselExampleFade<%=prd.IdProducto %>" class="carousel slide carousel-fade">
                            <div class="carousel-inner h-100">
                                <%
                                    for (int i = 0; i < prd.ListImagen.Count; i++)
                                    {
                                        if (i == 0)
                                        {
                                %>

                                <div class="carousel-item active h-100">
                                    <img src="<% =prd.ListImagen[i].ImagenUrl %>" class="d-block w-100 h-100" style="object-fit: contain;"  alt="...">
                                </div>
                                <%

                                    }
                                    else
                                    {
                                %>

                                <div class="carousel-item h-100">
                                    <img src="<% =prd.ListImagen[i].ImagenUrl %>" class="d-block w-100 h-100" style="object-fit: contain;"  alt="...">
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
                    </div>

                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title"><%= prd.Nombre %></h5>
                        <p class="fw-bold mb-2 text-primary">
                            $ <%= prd.Precio.ToString("N2") %>
                        </p>

                        <div class="mt-auto d-flex gap-2">
                            <a href="Default.aspx?id=<%= prd.IdProducto %>"
                                class="btn btn-outline-primary btn-sm">Ver detalle
                            </a>

                            <a href="Carrito.aspx?add=<%= prd.IdProducto %>"
                                class="btn btn-primary btn-sm mt-auto">Agregar al carrito
                            </a>
                        </div>
                    </div>

                </div>
            </div>
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

</asp:Content>
