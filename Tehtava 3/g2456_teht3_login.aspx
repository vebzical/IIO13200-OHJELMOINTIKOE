<%@ Page Language="C#" AutoEventWireup="true" CodeFile="g2456_teht3_login.aspx.cs" Inherits="Tehtava_3_g2456_teht3_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:Login ID="LoginWindow" runat="server" 
        OnAuthenticate="LoginWindow_Authenticate" 
        OnLoginError="LoginWindow_LoginError" 
        OnLoggedIn="LoginWindow_LoggedIn"
        RememberMeText="Remember me.">
    </asp:Login>
    
    </div>
    </form>
</body>
</html>
