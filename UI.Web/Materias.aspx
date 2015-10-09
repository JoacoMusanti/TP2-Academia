<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridMateriasPanel" runat="server">
        <asp:GridView ID="gridMaterias" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="HorasSemanales" HeaderText="Horas Semanales" />
                <asp:BoundField DataField="HorasTotales" HeaderText="Horas Totales" />
                <asp:BoundField HeaderText="Plan" DataField="DPlan" />
                <asp:BoundField HeaderText="Especialidad" DataField="DEspecialidad" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="materiasPanel" runat="server">
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblHS" runat="server" Text="Horas semanales: "></asp:Label>
        <asp:TextBox ID="txtHorasSemanales" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblHT" runat="server" Text="Horas totales: "></asp:Label>
        <asp:TextBox ID="txtHorasTotales" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
        <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="true">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblPlan" runat="server" Text="Plan: "></asp:Label>
        <asp:DropDownList ID="ddlPlan" runat="server" AutoPostBack="true">
        </asp:DropDownList>
    </asp:Panel>
    <asp:Panel ID="gridMateriasActionPanel" runat="server"></asp:Panel>
    <asp:Panel ID="formActionPanel" runat="server">
    </asp:Panel>
</asp:Content>
