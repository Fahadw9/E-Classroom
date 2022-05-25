<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoWebsite.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link rel="shortcut icon" type="image/png" href="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcReyig-ETasjeEyho6HO3mXsO2E9jIFryCcjQ&usqp=CAU" />
    <title>E-Learning Classroom</title>
    <style>
        .center {
            margin: auto;
            text-align: center;
            width: 50%;
            border: 10px solid purple;
            padding: 10px;
            background-color: whitesmoke;
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif
        }
        div {
            color: darkmagenta;
        }
        .roundbutton {
            border-radius: 15px;
            border: 2px solid purple;
            box-shadow: 0 0 10px #9ecaed;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="center">
            <asp:Image ID="Image2" ImageUrl="https://www.catchupkids.co.za/wp-content/uploads/2018/05/E-Classroom-Logo.jpg" AlternateText="E-Classroom Logo" runat="server" />
            <br />
            <p><asp:Label ID="l1" runat="server">Sign In</asp:Label></p>
            <asp:Label ID="label3" runat="server">Email Address</asp:Label>
            <asp:TextBox ID="txtUserName" runat="server" ToolTip="Enter User Name"></asp:TextBox>
            <br />
            <br />           
            <asp:Label ID="label4" runat="server">Password</asp:Label>
            <asp:TextBox ID="txtPassword" TextMode="password" runat="server" ToolTip="Enter Password"></asp:TextBox>
            <br />
            <br />            
            <asp:Label ID="Label7" runat="server">Sign In As</asp:Label>
            <asp:RadioButton ID="rdTeacher" Text="Teacher" GroupName="Sign In As" runat="server" />
            <asp:RadioButton ID="rdStudent" Text="Student" GroupName="Sign In As" runat="server" />
            <br />
            <br />
            <asp:Button ID="btnSave" Text="Sign In" CssClass="roundbutton" runat="server" OnClick="btnSave_Click"/>
            <br />
            <br />
            <a href="SignUp.aspx">Sign Up Instead?
            <br />
        </div>
    </form>
</body>
</html>