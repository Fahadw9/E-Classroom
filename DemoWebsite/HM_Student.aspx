<%@ Page Title="Helping Material" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HM_Student.aspx.cs" Inherits="DemoWebsite.HM_Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
    <p>BOOKS HERE</p>
            <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="None" Width = "100%">  
     <AlternatingRowStyle BackColor="White" />  
     <columns>
         <asp:TemplateField HeaderStyle-Width="1%" ItemStyle-Width="1%">
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Number" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb1" runat="server" Text='<%#Bind("materialid") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Type" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb2" runat="server" Text='<%#Bind("materialtype") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Name" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb3" runat="server" Text='<%#Bind("materialname") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Course" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb4" runat="server" Text='<%#Bind("course_name") %>'></asp:Label>
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Link/ Info" HeaderStyle-Width="1%" ItemStyle-Width="1%">
             <ItemTemplate>  
                 <asp:Label ID="lb5" runat="server" Text='<%#Bind("ref_link") %>'></asp:Label>
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


    <div class="jumbotron">
    <h2><%: Title %></h2>
    <br>
    <p>PRACTICE QUESTIONS HERE</p>
        <asp:GridView ID="grid2" runat="server" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="None" Width = "100%">  
     <AlternatingRowStyle BackColor="White" />  
     <columns>
         <asp:TemplateField HeaderStyle-Width="1%" ItemStyle-Width="1%">
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Number" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb1" runat="server" Text='<%#Bind("materialid") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Type" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb2" runat="server" Text='<%#Bind("materialtype") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Name" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb3" runat="server" Text='<%#Bind("materialname") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Course" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb4" runat="server" Text='<%#Bind("course_name") %>'></asp:Label>
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Link/ Info" HeaderStyle-Width="1%" ItemStyle-Width="1%">
             <ItemTemplate>  
                 <asp:Label ID="lb5" runat="server" Text='<%#Bind("ref_link") %>'></asp:Label>
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

    <div class="jumbotron">
    <h2><%: Title %></h2>
    <br>
    <p>NOTES HERE</p>
        <asp:GridView ID="grid3" runat="server" AutoGenerateColumns="False" CellPadding="10" ForeColor="#333333" GridLines="None" Width = "100%">  
     <AlternatingRowStyle BackColor="White" />  
     <columns>
         <asp:TemplateField HeaderStyle-Width="1%" ItemStyle-Width="1%">
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Number" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb1" runat="server" Text='<%#Bind("materialid") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Type" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb2" runat="server" Text='<%#Bind("materialtype") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Name" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb3" runat="server" Text='<%#Bind("materialname") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Course" HeaderStyle-Width="10%" ItemStyle-Width="10%">
             <ItemTemplate>  
                 <asp:Label ID="lb4" runat="server" Text='<%#Bind("course_name") %>'></asp:Label>
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Link/ Info" HeaderStyle-Width="1%" ItemStyle-Width="1%">
             <ItemTemplate>  
                 <asp:Label ID="lb5" runat="server" Text='<%#Bind("ref_link") %>'></asp:Label>
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
