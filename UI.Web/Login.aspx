<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Login ID="loginAcademia" style="vertical-align: middle; text-align: center; width: 400px; margin-left: auto; margin-right:auto;" runat="server" BackColor="#F7F7DE" LoginButtonText="Iniciar sesión" OnAuthenticate="Login1_Authenticate" PasswordRecoveryText="Recuperar Contraseña" Width="400px" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt">
            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
        </asp:Login>
    </form>
</body>
</html>
