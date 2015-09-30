<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Theme="" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <script type="text/javascript">
        function llenar_anio() {
            var anios = document.getElementById("ddlAnio");
            var anioActual = new Date().getFullYear();

            for (var i; i < 2015; i++) {
                var el = document.createElement("opt");
                el.textContent = i;
                anios.appendChild(el);
            }
        }
    </script>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        DataKeyNames="ID" CellPadding="4" GridLines="None" Width="541px" OnSelectedIndexChanged="gridView_SelectedIndexChanged" ForeColor="#333333">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
            <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
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
    </asp:Panel>

<asp:Panel ID="formPanel" Visible="true" runat="server">
    <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
    <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblDireccion" runat="server" Text="Direccion: "></asp:Label>
    <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblLegajo" runat="server" Text="Legajo: "></asp:Label>
    <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblDia" runat="server" Text="Dia: : "></asp:Label>
    <asp:DropDownList ID="ddlDia" runat="server" ></asp:DropDownList>
    <asp:Label ID="lblMes" runat="server" Text="Mes: "></asp:Label>
    <asp:DropDownList ID="ddlMes" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
    <asp:Label ID="lblAnio" runat="server" Text="Año: "></asp:Label>
    <asp:DropDownList ID="ddlAnio" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged" AutoPostBack="true" runat="server" ></asp:DropDownList>
    <br />
    <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad: "></asp:Label>
    <asp:DropDownList ID="ddlEspecialidad" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="lblIdPlan" runat="server" Text="Plan: "></asp:Label>
    <asp:DropDownList ID="ddlIdPlan" runat="server"></asp:DropDownList>
    <br />
     <asp:Label ID="lblTipoPersona" runat="server" Text="Tipo Persona: "></asp:Label>
    <asp:DropDownList ID="ddlTipoPersona" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="lblTelefono" runat="server" Text="Telefono: "></asp:Label>
    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado: "></asp:Label>
    <asp:CheckBox ID="chkHabilitado" runat="server"></asp:CheckBox>
    <br />
    <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario: "></asp:Label>
    <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
    <asp:TextBox ID="txtClave" TextMode="Password" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
    <asp:TextBox ID="txtRepetirClave" TextMode="Password" runat="server"></asp:TextBox>
    <br />
</asp:Panel>
<asp:Panel ID="gridActionsPanel" runat="server">
    <asp:LinkButton ID="lnkEditar" runat="server" OnClick="lnkEditar_Click">Editar</asp:LinkButton>
    <asp:LinkButton ID="lnkEliminar" runat="server">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="lnkNuevo" runat="server">Nuevo</asp:LinkButton>
</asp:Panel>
<asp:Panel ID="formActionsPanel" runat="server">
    <asp:LinkButton ID="lnkAceptar" runat="server" OnClick="lnkAceptar_Click">Aceptar</asp:LinkButton>
    <asp:LinkButton ID="lnkCancelar" runat="server">Cancelar</asp:LinkButton>
</asp:Panel>
</asp:Content>

