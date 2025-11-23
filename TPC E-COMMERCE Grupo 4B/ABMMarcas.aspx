<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ABMMarcas.aspx.cs" Inherits="TPC_E_COMMERCE_Grupo_4B.ABMMarcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-12">
            <h2 class="mb-4">Administración de Marcas</h2>
        </div>
    </div>

    <div class="row mb-3">
        <div class="col-md-6">
            <label for="txtBuscador" class="form-label">Buscar Marca</label>
            <asp:TextBox ID="txtBuscador" runat="server" CssClass="form-control" 
                         AutoPostBack="true" OnTextChanged="txtBuscador_TextChanged" 
                         placeholder="Escribe un nombre o descripción..."></asp:TextBox>
        </div>
    </div>

    <div class="table-responsive">
        <asp:GridView ID="dgvMarcas" runat="server" 
            AutoGenerateColumns="False" 
            ShowHeaderWhenEmpty="True"
            CssClass="table table-striped table-hover table-bordered align-middle"
            
            AllowPaging="True" 
            PageSize="5" 
            OnPageIndexChanging="dgvMarcas_PageIndexChanging"
            
            DataKeyNames="IdMarca" 
            OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged">        
            
            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />

            <Columns>
                
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
    
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
    
                <asp:CheckBoxField DataField="Estado" HeaderText="Activo" 
                    ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />

                <asp:CommandField ShowSelectButton="True" SelectText="✏️" ControlStyle-CssClass="btn btn-sm btn-warning" HeaderText="Editar" />
    
            </Columns>
    
        </asp:GridView>
    </div>

    <div class="card">
        <div class="card-header bg-primary text-white">
            <asp:Label ID="lblTituloCard" runat="server" Text="Alta de Marca"></asp:Label>            
        </div>

        <div class="card-body">
    
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ej: Mi Marca"></asp:TextBox>
            </div>
    
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" placeholder="Ingresa una descripción..."></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:CheckBox ID="chkEstado" runat="server" Text="Marca Activa" Checked="true" CssClass="form-check-input" Enabled="false"/>
            </div>
    
            <div class="d-grid gap-2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnClick"/>
                
                <a href="AdminDashboard.aspx" class="btn btn-link">Cancelar</a>
            </div>
    
        </div>
    </div>

</asp:Content>
