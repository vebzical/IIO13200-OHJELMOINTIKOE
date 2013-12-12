<%@ Page Language="C#" AutoEventWireup="true" CodeFile="g2456_teht4.aspx.cs" Inherits="Tehtava_4_g2456_teht4" MasterPageFile="~/Tehtava 4/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">form1" runat="server">
    <div>
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Ilmot %>" 
            SelectCommand="SELECT * FROM [lasnaolot]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Ilmot %>" 
            SelectCommand="SELECT DISTINCT [asioid], [lastname], [firstname] FROM [lasnaolot]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Ilmot %>" 
            SelectCommand="SELECT DISTINCT [course] FROM [lasnaolot]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Ilmot %>" 
            SelectCommand="SELECT DISTINCT [lastname] FROM [lasnaolot]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Ilmot %>" 
            SelectCommand="SELECT DISTINCT [asioid], [lastname], [firstname] FROM [lasnaolot] WHERE ([course] = @course) ORDER BY [lastname]">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="course" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Ilmot %>" 
            SelectCommand="SELECT * FROM [lasnaolot] WHERE ([lastname] = @lastname)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList2" Name="lastname" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="course" DataValueField="course" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource6" DataTextField="lastname" DataValueField="lastname" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" AllowSorting="true">
        </asp:GridView>
    </div>
</asp:Content>