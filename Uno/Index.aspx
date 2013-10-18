<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Uno.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Bem vindo ao Uno!</h1>
        <label>Digite seu nome:</label>
        <asp:TextBox ID="Nome" runat="server"></asp:TextBox>
        <asp:Button ID="Iniciar" runat="server" Text="Iniciar Jogo" OnClick="Iniciar_Click" />
    </div>
    </form>
</body>
</html>
