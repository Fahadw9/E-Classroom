<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="DemoWebsite.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Course Registration is Open Now</h1>
        <br>

        <h3>Each semester you can register upto 5 courses from the list shown below</h3>
        <br>

        <asp:CheckBox ID="CheckBox1" runat="server" />
        <asp:Label ID="Label1" runat="server" Text="Programming Fundamentals"></asp:Label>
        <br><br>
        <asp:CheckBox ID="CheckBox2" runat="server" />
        <asp:Label ID="Label2" runat="server" Text="Calculus 1"></asp:Label>
        <br><br>
        <asp:CheckBox ID="CheckBox3" runat="server" />
        <asp:Label ID="Label3" runat="server" Text="Physics"></asp:Label>
        <br><br>
        <asp:CheckBox ID="CheckBox4" runat="server" />
        <asp:Label ID="Label4" runat="server" Text="Information Technology"></asp:Label>
        <br><br>
        <asp:CheckBox ID="CheckBox6" runat="server" />
        <asp:Label ID="Label5" runat="server" Text="Pakistan Studies"></asp:Label>
        <br><br>
        <asp:Button ID="Button1" runat="server" Text="Enroll Now" />
    </div>

</asp:Content>
