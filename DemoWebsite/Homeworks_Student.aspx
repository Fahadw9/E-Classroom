<%@ Page Title="Homeworks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Homeworks_Student.aspx.cs" Inherits="DemoWebsite.Homeworks_Student" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .list{ border-radius: 5px;
                  border: 2px solid #0000FF;
                box-shadow: 0 0 5px #0000FF;
          }
    </style>
    <p>
    <br>
    <asp:DropDownList ID="list1" runat="server" CssClass ="list">
    <asp:ListItem Text="Select Course"></asp:ListItem>
    <asp:ListItem Text="Programming Fundamentals" Value = "Programming Fundamentals"></asp:ListItem>
    <asp:ListItem Text="Calculus 1" Value="Calculus 1"></asp:ListItem>
    <asp:ListItem Text="Physics" Value ="Physics"></asp:ListItem>
    <asp:ListItem Text="Pakistan Studies" Value ="Pakistan Studies"></asp:ListItem>
    <asp:ListItem Text="ICT" Value="ICT"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;
    <asp:Button ID="btnSave" Text="Enter" CssClass="roundbutton" runat="server" OnClick="btnSave_Click" />
    </p>

    <div class="jumbotron">
    <h2><%: Title %></h2>
    <br>
    <p></p>
        <asp:GridView ID="grid2" runat="server" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="None" Width = "100%">  
     <AlternatingRowStyle BackColor="White" />  
     <columns>
         <asp:TemplateField HeaderStyle-Width="1%" ItemStyle-Width="1%">
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Homework ID" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb1" runat="server" Text='<%#Bind("id") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Email" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb2" runat="server" Text='<%#Bind("email") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Homework #" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb8" runat="server" Text='<%#Bind("assesment_name") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField> 
         <asp:TemplateField HeaderText="Date" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb3" runat="server" Text='<%#Bind("taken_date") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Obtained Marks" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb4" runat="server" Text='<%#Bind("marks") %>'></asp:Label>
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Total" HeaderStyle-Width="1%" ItemStyle-Width="1%">
             <ItemTemplate>  
                 <asp:Label ID="lb5" runat="server" Text='<%#Bind("total") %>'></asp:Label>
             </ItemTemplate>  
         </asp:TemplateField>  
     </columns>  
     <EditRowStyle BackColor="#2461BF" />
     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
     <RowStyle BackColor="#EFF3FB" />
     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
     <SortedAscendingCellStyle BackColor="#F5F7FB" />
     <SortedAscendingHeaderStyle BackColor="#6D95E1" />
     <SortedDescendingCellStyle BackColor="#E9EBEF" /> 
     <SortedDescendingHeaderStyle BackColor="#4870BE" />
 </asp:GridView>
    </div>
</asp:Content>
