<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aguardando.aspx.cs" Inherits="Uno.Aguardando" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Tabela" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Jogador</asp:TableHeaderCell>
                <asp:TableHeaderCell>Pronto</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <asp:Button ID="Pronto" runat="server" Text="Pronto!" OnClick="Pronto_Click" />
    </div>
    </form>

    <script type="text/javascript" src="application.js"></script>
    <script type="text/javascript">
        atualizacaoAutomatica(1000, function () {
            window.location = "Aguardando.aspx";
        });
    </script>
</body>
</html>
