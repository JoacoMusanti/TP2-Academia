<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="166px">
        <table style="width:100%;">
            <tr>
                <td style="width: 265px">&nbsp;</td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Usuarios.aspx">Administrar Usuarios</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 265px">&nbsp;</td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Especialidades.aspx">Administrar Especialidades</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 265px; height: 23px;"></td>
                <td style="height: 23px">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Planes.aspx">Administrar Planes</asp:HyperLink>
                    &nbsp;</td>
                <td style="height: 23px"></td>
            </tr>
            <tr>
                <td style="width: 265px; height: 23px;">&nbsp;</td>
                <td style="height: 23px">
                    <asp:HyperLink ID="HyperLink6" runat="server">Administrar Materias</asp:HyperLink>
                </td>
                <td style="height: 23px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 265px">&nbsp;</td>
                <td>
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Comisiones.aspx">Administrar Comisiones</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 265px">&nbsp;</td>
                <td>
                    <asp:HyperLink ID="HyperLink5" runat="server">Administrar Cursos</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
