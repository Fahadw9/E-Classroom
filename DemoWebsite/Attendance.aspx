﻿<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="DemoWebsite.Attendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 37%;
            background-color: lightcyan;
        }
    </style>

    <div>
 
        <h1 >
            Mark Attendance</h1>
     
 
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
                    <asp:ListItem Text="Programming Fundamentals" Value="CS"></asp:ListItem>
                    <asp:ListItem Text="Calculus 1" Value="CS"></asp:ListItem>
                    <asp:ListItem Text="Physics" Value="CS"></asp:ListItem>
                    <asp:ListItem Text="Information Technology" Value="CS"></asp:ListItem>
                    <asp:ListItem Text="Pakistan Studies" Value="CS"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
 
    <br />
 
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
        CellPadding="3" CellSpacing="2" >
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <Columns>
            <asp:BoundField DataField="rollno" HeaderText="Roll No."
                SortExpression="rollno" />
            <asp:BoundField DataField="studentname" HeaderText="Student Name"
                SortExpression="studentname" />
            <asp:TemplateField HeaderText="Mark Attendance">
                <ItemTemplate>
                    <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="G1"
                        Text="Present" />
                    &nbsp;<asp:RadioButton ID="RadioButton2" runat="server" GroupName="G1"
                        Text="Absent" />
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
        Text="Save Attendance" onclick="BtnSave_Click" />
    <br />
    <br />
    <asp:Label ID="LblMsg" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <br />

</asp:Content>
