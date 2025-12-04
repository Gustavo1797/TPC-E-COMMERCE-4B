<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ABMCompra.aspx.cs" Inherits="TPC_E_COMMERCE_Grupo_4B.ABMCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
            <div class="card">
                <div class="card-header bg-primary text-white">
                    <h3>Administrar Venta #<asp:Label ID="lblIdVenta" runat="server" Text=""></asp:Label></h3>
                </div>
                <div class="card-body">                    
                    
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label class="form-label">Usuario:</label>
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label class="form-label">Fecha de Venta:</label>
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label class="form-label">Total ($):</label>
                            <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>

                        <div class="col-md-6">
                            <label class="form-label fw-bold text-primary">Estado del Pedido:</label>
                            
                            <asp:DropDownList ID="ddlEstados" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="mt-4 d-flex justify-content-between">
                        <asp:Button ID="btnVolver" runat="server" Text="Volver al Listado" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
                    </div>
                                        
                    <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Green" Visible="false"></asp:Label>

                </div>
            </div>
        </div>

</asp:Content>
