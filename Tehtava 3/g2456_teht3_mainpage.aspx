<%@ Page Language="C#" AutoEventWireup="true" CodeFile="g2456_teht3_mainpage.aspx.cs" Inherits="Tehtava_3_g2456_teht3_mainpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Code Revolution</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <img src="../App_Data/kovaa koodia.jpg"/>
    <asp:DropDownList ID="lstUsers" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstUsers_SelectedIndexChanged"></asp:DropDownList>
    <asp:GridView ID="autoNakyma" runat="server" 
        AllowSorting="True" 
        AllowPaging="True" 

        OnSorting="autoNakyma_Sorting" 
        OnPageIndexChanging="autoNakyma_PageIndexChanging" 
        OnRowCancelingEdit="autoNakyma_RowCancelingEdit" 
        OnRowDeleting="autoNakyma_RowDeleting" 
        OnRowEditing="autoNakyma_RowEditing" 
        OnRowUpdating="autoNakyma_RowUpdating" >
    </asp:GridView>

    <asp:Button ID="addNew" runat="server" OnClick="addNew_Click" Text="Lisää uusi" />
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Tallenna" />

    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
    <asp:Label ID="lblInfo" runat="server"></asp:Label>
    <asp:Label ID="lblTiedot" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
