<%@ Page Title="Query" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Query.aspx.cs" Inherits="DemoWebsite.Query" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>Grading</p>
      <style>
        .list{ border-radius: 5px;
                  border: 2px solid #0000FF;
                box-shadow: 0 0 5px #0000FF;
          }
    </style>
    <p>
    <br>
  <asp:Label ID="labelId" runat="server">Max Grade</asp:Label>
            <asp:TextBox ID="G1" runat="server" ToolTip="Enter the upper grade range"></asp:TextBox>
            <br><br>
            <asp:Label ID="label3" runat="server">Min Grade</asp:Label>
            <asp:TextBox ID="G2" runat="server" ToolTip="Enter the lower grade range"></asp:TextBox>
    &nbsp;&nbsp;
        <br />
        <br />        
    <asp:DropDownList ID="list1" runat="server" CssClass ="list">
    <asp:ListItem Text="Select Course" Value ="0"></asp:ListItem>
    <asp:ListItem Text="Programming Fundamentals" Value = "1"></asp:ListItem>
    <asp:ListItem Text="Calculus 1" Value="2"></asp:ListItem>
    <asp:ListItem Text="Physics" Value ="3"></asp:ListItem>
    <asp:ListItem Text="Pakistan Studies" Value ="4"></asp:ListItem>
    <asp:ListItem Text="ICT" Value="5"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp; 
    <asp:Button ID="btnSave" Text="Enter" CssClass="roundbutton" runat="server" OnClick="btn_Grade_Click" />
    </p>
    <br />
     <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
        CellPadding="3" CellSpacing="2" >
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
         <Columns>
              <asp:BoundField DataField="Email" HeaderText="Email"
                 />
              <asp:BoundField DataField="Course" HeaderText="Course"
                 />
            <asp:BoundField DataField="Grade" HeaderText="Grade"
                 />
             </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
</asp:Content>