<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="width: 394px; height: 7px;"></td>
            <td style="height: 7px">
    <asp:Panel ID="Panel1" runat="server" CssClass="panelCss" Height="230px" Width="209px" BorderStyle="None">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Usuarios.aspx">Administrar Usuarios</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Especialidades.aspx">Administrar Especialidades</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Planes.aspx">Administrar Planes</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink6" runat="server">Administrar Materias</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Comisiones.aspx">Administrar Comisiones</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink5" runat="server">Administrar Cursos</asp:HyperLink>
        <br />
        
    </asp:Panel>
            </td>
            <td style="height: 7px"></td>
        </tr>
        </table>
</asp:Content>
