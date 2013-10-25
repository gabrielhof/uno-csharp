<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Terminou.aspx.cs" Inherits="Uno.Terminou" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=320, initial-scale=1.0, maximum-scale=1.0, minimum-scale:1.0, user-scalable=no" />
    <title>Fim :D</title>

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <link href="assets/css/style.css" rel="stylesheet" media="screen" />
    <style type="text/css">
        form.form {
            max-width: 60%;
            padding-left: 10%;
        }
    </style>
</head>
<body>
    <div class="content">
        <form id="form1" runat="server" class="form">
            <asp:HiddenField runat="server" ID="appPath" Value=""/>
            <h2><asp:Label ID="Resultado" runat="server" Text="Parabéns blablabla, você venceu o jogo!"></asp:Label></h2>
            
            <br />

            <asp:Button ID="NovoJogo" runat="server" Text="Novo Jogo" OnClick="NovoJogo_Click" CssClass="btn btn-primary"/>
        </form>
    </div>

     <script type="text/javascript" src="assets/js/jquery-2.0.3.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="assets/js/application.js"></script>
    <script type="text/javascript" src="application.js"></script>
    <script type="text/javascript">
        atualizacaoAutomatica(1000, function () {
            window.location = appPath + "Terminou.aspx";
        });
    </script>
</body>
</html>
