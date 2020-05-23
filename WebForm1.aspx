<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AshokaRehab.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="TextBox1" runat="server"  ValidationGroup="d">   </asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox1"  ValidationGroup="d"></asp:RequiredFieldValidator>

 <asp:Button ID="Button1" runat="server" Text="Button" CausesValidation="true" ValidationGroup="d" />
    </div>
    </form>
</body>
</html>
