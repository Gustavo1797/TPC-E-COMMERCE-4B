<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaModObj.aspx.cs" Inherits="TPC_E_COMMERCE_Grupo_4B.AltaModObj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex justify-content-center align-items-center" style="min-height: 60vh;">
        
        <div class="text-center p-5 bg-white border rounded-3 shadow-lg">
            
            <!-- Icono Grande de Éxito (Verde) -->
            <span class="material-symbols-outlined text-success" style="font-size: 8rem;">
                check_circle
            </span>
            
            <!-- Título Principal -->
            <h1 class="text-success mt-4">¡Operación Exitosa!</h1>
            
            <!-- Mensaje de Confirmación Dinámico -->
            <p class="lead text-muted mb-4">
                <asp:Label ID="lblMensajeConfirmacion" runat="server" 
                           Text="El registro se ha procesado correctamente."></asp:Label>
            </p>
            
        </div>
        
    </div>

</asp:Content>
