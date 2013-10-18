<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JogoUno.aspx.cs" Inherits="Uno.JogoUno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="UltimaCarta" runat="server" Text="Última Carta Descartada:"></asp:Label>

        <asp:Table ID="Table" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Jogador</asp:TableHeaderCell>
                <asp:TableHeaderCell>Nº Cartas</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

        <asp:Table ID="Cartas" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell ID="CartasHeader">Cartas</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <asp:Button ID="ComprarCarta" runat="server" Text="Comprar Carta" OnClick="ComprarCarta_Click" />
        <asp:Button ID="PassarVez" runat="server" Text="Passar a Vez" OnClick="PassarVez_Click" />
    </div>
    </form>
</body>
</html>
