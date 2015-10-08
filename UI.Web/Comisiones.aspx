<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="content4" runat="server" ContentPlaceHolderID="bodyContentPlaceHolder">

    <asp:Panel ID="panelGridComisiones" runat="server">
        <asp:GridView ID="gridComisiones" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">

            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año de Especialidad" />
                <asp:BoundField DataField="idPlan" HeaderText="Plan" />
            </Columns>

        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="panelFormComisiones" runat="server" Visible="false">
        <asp:Label ID="lblDescCom" runat="server" Text="Descripción"></asp:Label>
        <asp:TextBox ID="txtDescCom" runat="server"></asp:TextBox>

    </asp:Panel>

</asp:Content>
