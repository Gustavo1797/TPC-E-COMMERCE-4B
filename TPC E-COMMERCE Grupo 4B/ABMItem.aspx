<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ABMItem.aspx.cs" Inherits="TPC_E_COMMERCE_Grupo_4B.ABMItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

        <h2 class="mb-4">Administración de Productos</h2>

    <asp:Label ID="lblProductoStatus" runat="server" CssClass="text-danger small mt-2"></asp:Label>

    <div class="row">
        <!-- COLUMNA IZQUIERDA: FORMULARIO DE DATOS DEL PRODUCTO -->
        <div class="col-md-6">
            <div class="card mb-4">
                <div class="card-header bg-primary text-white">
                    <asp:Label ID="sTituloCard" runat="server" Text="Alta de Producto"></asp:Label>
                </div>
                <div class="card-body">                    

                    <!-- Nombre y Descripción -->
                    <div class="mb-3">
                        <label class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ej: Nombre del producto" OnTextChanged="borrarMensajeStatus"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Descripción</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" placeholder="Detalle técnico y características..." OnTextChanged="borrarMensajeStatus"></asp:TextBox>
                    </div>

                    <!-- Precio y Stock (en línea) -->
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label class="form-label">Precio ($)</label>
                            <!-- TextMode="Number" es útil para forzar la entrada numérica -->
                            <asp:TextBox ID="txtPrecio" runat="server" TextMode="Number" CssClass="form-control" placeholder="0.00" OnTextChanged="borrarMensajeStatus"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label class="form-label">Stock</label>
                            <asp:TextBox ID="txtStock" runat="server" TextMode="Number" CssClass="form-control" placeholder="0" OnTextChanged="borrarMensajeStatus"></asp:TextBox>
                        </div>
                    </div>
                    
                    <!-- Categoria y Marca (en línea) -->
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label class="form-label">Categoría</label>
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                                <asp:ListItem Text="-- Seleccione Categoria --" Value="0" />
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label class="form-label">Marca</label>
                            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                                <asp:ListItem Text="-- Seleccione Marca --" Value="0" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <!-- Peso y País de Origen (en línea) -->
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label class="form-label">Peso (kg)</label>
                            <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control" placeholder="0.00" OnTextChanged="borrarMensajeStatus"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label class="form-label">País de Origen</label>
                            <asp:TextBox ID="txtPaisOrigen" runat="server" CssClass="form-control" placeholder="Ej: Argentina" OnTextChanged="borrarMensajeStatus"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Estado (Checkbox) -->
                    <div class="mb-4">
                        <asp:CheckBox ID="chkEstado" runat="server" Text="Producto Activo" Checked="true" CssClass="form-check-input" />
                    </div>

                    <!-- Botones -->
                    <div class="d-grid gap-2">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Producto" CssClass="btn btn-success btn-lg" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar / Nuevo" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" CausesValidation="false" />
                    </div>
                </div>
            </div>
        </div>

        <!-- COLUMNA DERECHA: GESTIÓN DE IMÁGENES -->
        <div class="col-md-6">
            <div class="card mb-4">
                <div class="card-header">
                    <h5 class="card-title mb-0">Gestión de Imágenes (URLs)</h5>
                </div>
                <div class="card-body">

                    <!-- SECCIÓN DE CARGA DE IMAGEN -->
                    <div class="mb-3 p-3 border rounded-3 bg-light">
                        <div class="d-flex justify-content-between align-items-center mb-3">
                            <asp:Image ID="imgPreview" runat="server" ImageUrl="https://placehold.co/100x100/A0A0A0/FFFFFF?text=Preview" 
                            Height="250px" Width="250px" CssClass="rounded border me-3" 
                            AlternateText="Vista Previa" ToolTip="Vista previa de la URL ingresada" 
                            Visible="true"/> 
                        </div>

                        <asp:Label ID="lblImagenStatus" runat="server" CssClass="text-danger small mt-2"></asp:Label>

                        <div class="mb-2">
                            <label class="form-label">URL de la Imagen</label>
                            <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control" placeholder="https://ejemplo.com/imagen.jpg" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged"/>
                        </div>                        
                        
                        <div class="d-grid gap-2">
                            <asp:Button ID="btnAgregarImagen" runat="server" Text="+ Agregar a la lista" CssClass="btn btn-sm btn-primary" OnClick="btnAgregarImagen_Click" CausesValidation="false" />
                        </div>

                    </div>

                    <!-- GRIDVIEW PARA LA LISTA DE IMÁGENES -->
                    <div class="grid-imagenes">
                         <h6 class="mb-3">Imágenes Cargadas:</h6>
                         <asp:GridView ID="dgvImagenes" runat="server" 
                            AutoGenerateColumns="False" 
                            ShowHeaderWhenEmpty="False"
                            DataKeyNames="Id"
                            OnSelectedIndexChanged="dgvImagenes_SelectedIndexChanged"
                            OnRowDeleting="dgvImagenes_DeleteUrlImage"
                            CssClass="table table-sm table-bordered table-hover">
                            
                            <Columns>  
                                <asp:CommandField ShowSelectButton="True" SelectText="📋" ControlStyle-CssClass="btn btn-sm btn-info" HeaderText="Pegar URL"/>
                                <asp:BoundField HeaderText="URL Imagen" DataField="ImagenUrl" />
                                <asp:CommandField ShowDeleteButton="True" DeleteText="❌" ControlStyle-CssClass="btn btn-sm btn-danger" HeaderText="Borrar"/>
                            </Columns>

                        </asp:GridView>
                        
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
