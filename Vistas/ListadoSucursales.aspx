<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursales.aspx.cs" Inherits="Vistas.ListadoSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 225px;
        }
        .auto-style3 {
            width: 380px;
        }
        .auto-style4 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
                    </td>
                    <td class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ListadoSucursales.aspx">Listado de Sucursales</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/EliminarSucursales.aspx">Eliminar Sucursal</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <br />
                        <strong><span class="auto-style4">Listado de sucursales</span></strong></td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <br />
                        Búsqueda ingrese Id sucursal:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtSucursal" runat="server" Width="359px"></asp:TextBox>
                    </td>
                    <td>&nbsp;&nbsp; &nbsp;<asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
&nbsp;&nbsp;
                        <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar todos" OnClick="btnMostrarTodos_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="grdSucursales" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
