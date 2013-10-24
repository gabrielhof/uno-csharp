<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JogoUno.aspx.cs" Inherits="Uno.JogoUno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=320, initial-scale=1.0, maximum-scale=1.0, minimum-scale:1.0, user-scalable=no" />
    <title>Uno!</title>

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <link href="assets/css/style.css" rel="stylesheet" media="screen" />
    <style type="text/css">
        #form1 {
            max-width: 700px;
        }
    </style>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server" class="form">
            <asp:Panel ID="SuaVezPanel" runat="server" Visible="false"></asp:Panel>

            <asp:Table ID="Table" runat="server" CssClass="table">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                    <asp:TableHeaderCell>Jogador</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Cartas</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>

            <asp:Label ID="UltimaCarta" runat="server" Text="Última Carta Descartada:"></asp:Label>

            <div style="float: right; padding-top: 9%;">
                <asp:LinkButton ID="ComprarCarta" runat="server" OnClick="ComprarCarta_Click" CssClass="btn btn-default">
                    <span style="padding-right: 5px;">Comprar Carta</span>
                    <span class="glyphicon glyphicon-plus-sign"></span>
                </asp:LinkButton>

                <asp:LinkButton ID="PassarVez" runat="server" OnClick="PassarVez_Click" CssClass="btn btn-primary">
                    <span class="glyphicon glyphicon-refresh"></span>
                    <span style="padding-left: 5px;">Passar a Vez</span>
                </asp:LinkButton>
            </div>
            
            <div style="padding-top: 10px; clear: both;"></div>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2 class="panel-title"><asp:Label ID="SuasCartas" runat="server" Text=""></asp:Label></h2>
                </div>
                <asp:Panel ID="Cartas" runat="server"></asp:Panel>
            </div>

            <asp:Button runat="server" ID="Sair" CssClass="btn btn-danger" Text="Não quero mais jogar :(" OnClick="Sair_Click" OnClientClick="return confirm('Tem certeza?');"/>
        </form>
    </div>

    <script type="text/javascript" src="assets/js/jquery-2.0.3.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="assets/js/application.js"></script>
    <script type="text/javascript">
        unloaded = false;

        atualizacaoAutomatica(1000, function () {
            window.location = "/JogoUno.aspx";
        });
    </script>
</body>
</html>
