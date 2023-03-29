<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="staff_login.aspx.cs" Inherits="final_web_app.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <br /><font size ="2em"> <p>Enter the details below to authorize.</p></font><br />
 <p class="lead">  <font size ="2em"> 
            Enter ID:
        </font></p>
        <p class="lead">
            <asp:TextBox ID="name" runat="server" Width="1404px" Height="46px" OnTextChanged="name_TextChanged"></asp:TextBox>
        </p>
     <p class="lead">  <font size ="2em"> 
            Enter password:
        </font></p>
        <p class="lead">
            <asp:TextBox ID="password" runat="server" Width="1404px" Height="46px" OnTextChanged="password_Entered"></asp:TextBox>
        </p>
     <font size ="2em"> <asp:Button ID="submit" runat="server"  Text="Submit" OnClick="submit_Click" /> 
</asp:Content>
