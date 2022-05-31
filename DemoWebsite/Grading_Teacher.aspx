<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Grading_Teacher.aspx.cs" Inherits="DemoWebsite.Grading_Teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style type="text/css">
        .style1
        {
            width: 37%;
            background-color: lightcyan;
        }
    </style>

    <div>     
 
    </div>
 
    <br />
    <br />
 
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
    <table border="2" class="style1">
        <tr>
            <td>
                Select Class :
            </td>
            <td>
                <asp:DropDownList ID="DDListClass" runat="server"
                    AutoPostBack="true"                   
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                   <%-- <asp:ListItem Text="Programming Fundamentals" Value="CS"></asp:ListItem>
                    <asp:ListItem Text="Calculus 1" Value="CS"></asp:ListItem>
                    <asp:ListItem Text="Physics" Value="CS"></asp:ListItem>
                    <asp:ListItem Text="ICT" Value="CS"></asp:ListItem>
                    <asp:ListItem Text="Pakistan Studies" Value="CS"></asp:ListItem>--%>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
 
    <br />
 
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
        CellPadding="3" CellSpacing="2" >
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <Columns>
            <asp:BoundField DataField="s_email" HeaderText="Roll No."
                SortExpression="s_email" />
            <asp:TemplateField HeaderText="Grades">
                <ItemTemplate>
                    <!-- 
                        Add Text Box for Grade
                        

                    <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="G1"
                        Text="Present" />
                    &nbsp;<asp:RadioButton ID="RadioButton2" runat="server" GroupName="G1"
                        Text="Absent" />

                        -->
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <br />
    <asp:Button ID="BtnSave" runat="server"
        Text="Save Grades" onclick="BtnSave_Click" />
    <br />
    <br />
    <asp:Label ID="LblMsg" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <br />

</asp:Content>
