<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Login ID="loginAcademia" runat="server" BackColor="#FFFF99" LoginButtonText="Iniciar sesión" OnAuthenticate="Login1_Authenticate" PasswordRecoveryText="Recuperar Contraseña" Width="315px">
        </asp:Login>
    </form>
</body>
</html>
