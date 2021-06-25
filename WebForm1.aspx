<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebPruebaAccesoSQL.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="js/sweetalert2.all.min.js"></script>
    <link href="Css/sweetalert2.min.css" rel="stylesheet" />
    <script src="js/Micodigo.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Prueba Conexion" Width="321px" />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Width="700px"></asp:TextBox>
        </div>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Consuta DataReader" />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Height="138px" Width="250px"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Consulta DataSeT" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Obtener datos del DataSet" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView1" runat="server" Height="138px" Width="259px">
        </asp:GridView>
    </form>
</body>
</html>
