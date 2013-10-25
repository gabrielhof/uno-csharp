<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AguardarNovoJogo.aspx.cs" Inherits="Uno.AguardarNovoJogo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=320, initial-scale=1.0, maximum-scale=1.0, minimum-scale:1.0, user-scalable=no" />
    <title>Aguardando um novo jogo...</title>

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <link href="assets/css/style.css" rel="stylesheet" media="screen" />
    <style type="text/css">
        form.form {
            max-width: 100%;
            padding-left: 30%;
        }

        img {
            padding-left: 10%;
        }
    </style>
</head>
<body>
    <div class="content">
        <form id="form1" runat="server" class="form">
            <img src="assets/image/sad_octocat.png"/>
            <h2>Desculpe, mas o jogo já começou.</h2>
            <h3>Aguarde a próxima rodada...</h3>
        </form>
    </div>

    <script type="text/javascript" src="assets/js/jquery-2.0.3.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="assets/js/application.js"></script>
    <script type="text/javascript">
        atualizacaoAutomatica(2000, function () {
            window.location = appPath + "Index.aspx";
        }, "WebService.asmx/JogoTerminou");
    </script>
</body>
</html>
