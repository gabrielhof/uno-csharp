<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aguardando.aspx.cs" Inherits="Uno.Aguardando" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=320, initial-scale=1.0, maximum-scale=1.0, minimum-scale:1.0, user-scalable=no" />
    <title>Uno - Aguardando Jogadores...</title>
    
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <link href="assets/css/style.css" rel="stylesheet" media="screen" />
</head>
<body>
    <div class="container">
        <form id="form1" runat="server" class="form">
            <asp:Table ID="Tabela" runat="server" CssClass="table">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                    <asp:TableHeaderCell>Jogador</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>

            <hr />

            <asp:Button ID="Pronto" runat="server" Text="Estou Pronto!" OnClick="Pronto_Click" CssClass="btn btn-lg btn-success btn-block" />
            <asp:Button ID="AguardandoButton" runat="server" Text="Aguardando os outros jogadores..." CssClass="btn btn-lg btn-default btn-block" Enabled="false"/>
            <asp:LinkButton ID="PararDeJogar" runat="server" CssClass="btn btn-lg btn-danger btn-block" OnClick="PararDeJogar_Click">
                <span style="padding-right: 5px;">Não quero mais jogar</span>
                <span class="glyphicon glyphicon-log-out"></span>
            </asp:LinkButton>
        </form>
    </div>

    <script type="text/javascript" src="assets/js/jquery-2.0.3.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="assets/js/application.js"></script>
    <script type="text/javascript">
        atualizacaoAutomatica(1000, function () {
            window.location = "Aguardando.aspx";
        });
    </script>
</body>
</html>
