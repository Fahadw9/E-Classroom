<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About_Student.aspx.cs" Inherits="DemoWebsite.About_Student" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        
            <!--
                Add the retreival query and fill the boxes.
                Then on click run the updation query.
                -->
        
        <div class="jumbotron">
            <br />
            <h3>Edit Profile Here</h3><br><br>

            <asp:Label ID="labelId" runat="server">Full Name</asp:Label>
            <asp:TextBox ID="FullName" runat="server" ToolTip="Enter Full Name"></asp:TextBox>
            <br><br>
            <asp:Label ID="label4" runat="server">Password</asp:Label>
            <asp:TextBox ID="Password"  runat="server" ToolTip="Enter Password"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="label6" runat="server">Permanent Address</asp:Label>
            <asp:TextBox ID="Address" runat="server" ToolTip="Enter your home address"></asp:TextBox>
            <br><br>
            <asp:Label ID="label5" runat="server">Contact Number</asp:Label>
            <asp:TextBox ID="Contact_no" runat="server" ToolTip="Enter your phone number"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="label1" runat="server">Age</asp:Label>
            <asp:TextBox ID="Age" runat="server" ToolTip="Enter your age"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSave" Text="Edit Profile" CssClass="roundbutton" runat="server" OnClick="btnSave_Click" />
            <br />
            <br />
            <asp:Label ID="l7" runat="server">Modify Credentials For Updation</asp:Label>
        </div>
</asp:Content>
