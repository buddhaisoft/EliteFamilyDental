<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="AshokaRehab.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
    <div>
    TEST6
        <asp:textbox ID="Textbox1" runat="server" ></asp:textbox>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Textbox1" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    </div>
    </form>
</body>
</html>
