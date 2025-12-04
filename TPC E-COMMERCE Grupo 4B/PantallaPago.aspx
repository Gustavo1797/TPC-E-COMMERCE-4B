<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaPago.aspx.cs" Inherits="TPC_E_COMMERCE_Grupo_4B.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .grid-container {
            display: grid;
            grid-template-columns: 2fr 1fr;
            gap: 20px;
            padding: 20px;
        }

        .box {
            background: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
        }

        .carrito {
            position: sticky;
            top: 20px;
        }

            .carrito h3 {
                text-align: center;
                margin-top: 0;
            }

        .item-linea {
            display: flex;
            justify-content: space-between;
            margin: 8px 0;
        }

        .total {
            border-top: 2px solid #ddd;
            padding-top: 10px;
            margin-top: 10px;
            font-size: 1.2em;
            font-weight: bold;
        }
    </style>

    <div class="grid-container">

        <div>
            <h2 class="mb-4">MEDIO DE PAGO</h2>

            <asp:Label ID="Label1" runat="server" Text="Favor de seleccionar un medio de pago." />

            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger d-block mb-3"></asp:Label>

            <div class="box">
                <asp:RadioButton ID="rbMercadoPago" runat="server"
                    GroupName="GrupoPagoGeneral"
                    Text="Mercado Pago"
                    AutoPostBack="true"
                    OnCheckedChanged="MetodoPago_CheckedChanged" />
            </div>

            <div class="box">
                <h4>Mis Tarjetas Guardadas</h4>

                <asp:Repeater ID="rptTarjetas" runat="server">
                    <ItemTemplate>
                        <div class="item-tarjeta">

                            <asp:HiddenField ID="hfIdTarjeta" runat="server" Value='<%# Eval("IdTarjeta") %>' />

                            <div class="info-tarjeta">
                                <div>
                                    <asp:RadioButton
                                        ID="rbTarjeta"
                                        runat="server"
                                        AutoPostBack="true"
                                        OnCheckedChanged="rbTarjeta_CheckedChanged" />
                                    <img src='<%# Eval("ImagenUrlTarj") %>' alt="Icono" width="30" />
                                    <strong><%# Eval("Nombre") %></strong>
                                </div>
                                <div>
                                    <small>Termina en: **** <%# Eval("UltimosCuatro") %></small>
                                </div>
                            </div>


                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Label ID="lblSinTarjetas" runat="server" Text="No tienes tarjetas guardadas." Visible="false" CssClass="text-muted"></asp:Label>
            </div>

            <div class="box">
                <asp:RadioButton ID="rbEfectivo" runat="server"
                    GroupName="GrupoPagoGeneral"
                    Text="Efectivo"
                    AutoPostBack="true"
                    OnCheckedChanged="MetodoPago_CheckedChanged" />
            </div>

            <div class="box">
                <h2>PAGO</h2>                
                <asp:Button ID="btnPagar" runat="server" Text="Realizar pago" CssClass="btn btn-primary" OnClick="btnPagar_Click" />
            </div>

        </div>

        <!-- COLUMNA CHICA (Carrito) -->
        <div class="box carrito">
            <h3>🛒 Carrito</h3>

            <div class="item-linea">
                <span>Cantidad: </span>
                <span>
                    <asp:Label ID="lblCantidad" runat="server" Text="1"></asp:Label></span>
            </div>

            <div class="total">
                Total: $<asp:Label ID="lblTotal" runat="server"></asp:Label>
            </div>
        </div>

    </div>

</asp:Content>

