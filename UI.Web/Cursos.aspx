<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Theme="" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content4" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<asp:Panel ID="gridPanel" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style1" style="width: 263px">&nbsp;</td>
                <td style="width: 536px">
                    <asp:GridView ID="gdvCursos" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gdvCursos_SelectedIndexChanged" Width="506px"
                        HeaderStyle-HorizontalAlign ="Left">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Materia" HeaderText="Materia" />
                            <asp:BoundField DataField="Comision" HeaderText="Comision" />
                            <asp:BoundField DataField="AnioCalendario" HeaderText="Año Calendario" />
                            <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
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
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 263px">&nbsp;</td>
                <td style="width: 536px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="width: 263px">&nbsp;</td>
                <td style="width: 536px">
                    <asp:Panel ID="formPanelCurso" runat="server" Visible="false">
                        <asp:Label ID="lblMateria" runat="server" Text="Materia: "></asp:Label>
                        <asp:DropDownList ID="ddlMaterias" runat="server" >
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="lblComision" runat="server" Text="Comision: "></asp:Label>
                        <asp:DropDownList ID="ddlComisiones" runat="server" >
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="lblAnioCalendario" runat="server" Text="Año Calendario: "></asp:Label>
                        <asp:DropDownList ID="ddlAnioCalendario" runat="server" ClientIDMode="Static">
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="lblCupo" runat="server" Text="Cupo: "></asp:Label>
                        <asp:DropDownList ID="ddlCupo" runat="server">
                        </asp:DropDownList>
                        <br />
                    </asp:Panel>
                    <asp:Panel ID="gridActionsPanel" runat="server">
                        <asp:LinkButton ID="lnkEditar" runat="server" OnClick="lnkEditar_Click">Editar</asp:LinkButton>
                        <asp:LinkButton ID="lnkEliminar" runat="server" OnClick="lnkEliminar_Click">Eliminar</asp:LinkButton>
                        <asp:LinkButton ID="lnkNuevo" runat="server" OnClick="lnkNuevo_Click">Nuevo</asp:LinkButton>
                    </asp:Panel>
                    <asp:Panel ID="formActionsPanel" runat="server">
                        <asp:LinkButton ID="lnkAceptar" runat="server" OnClick="lnkAceptar_Click">Aceptar</asp:LinkButton>
                        <asp:LinkButton ID="lnkCancelar" runat="server">Cancelar</asp:LinkButton>
                    </asp:Panel>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>