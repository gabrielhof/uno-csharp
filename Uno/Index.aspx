<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Uno.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=320, initial-scale=1.0, maximum-scale=1.0, minimum-scale:1.0, user-scalable=no" />
    <title>Uno!</title>

    <link href="assets/css/bootstrap.min.css" rel="stylesheet" media="screen" />
    <link href="assets/css/style.css" rel="stylesheet" media="screen" />
</head>
<body>
    <div class="container">
        <form id="form1" runat="server" class="form">
            <h1 class="form-heading">Vamos jogar <span>Uno</span>?</h1>
            <br />

            <asp:TextBox ID="Nome" runat="server" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button ID="Iniciar" runat="server" Text="Quero Jogar" OnClick="Iniciar_Click" CssClass="btn btn-lg btn-primary btn-block" />
        </form>
    </div>

    <script type="text/javascript" src="assets/js/jquery-2.0.3.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#Nome").attr("placeholder", "Digite seu Nome");
        });
    </script>
</body>
</html>
