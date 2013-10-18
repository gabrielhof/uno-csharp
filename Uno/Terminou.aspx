<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Terminou.aspx.cs" Inherits="Uno.Terminou" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Label ID="Resultado" runat="server" Text=""></asp:Label>
        <asp:Button ID="NovoJogo" runat="server" Text="Novo Jogo" OnClick="NovoJogo_Click" />
    </form>
</body>
</html>
