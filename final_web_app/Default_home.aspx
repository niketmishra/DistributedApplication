<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default_home.aspx.cs" Inherits="final_web_app._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <br /><font size ="2em"> <p>Welcome to Recruiter Connect!</p></font><br />
 <p class="lead">  <font size ="2em"> 
            Enter name:
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
   
            </p>
    <font size ="2em"> <asp:RadioButton ID="RadioButton1" runat="server" Text="  I am a staff"/></font><br />

     <img alt="" id="captchaimage" runat="server"/>
     <p class="lead">  <font size ="2em"> 
            Enter the captcha text:
        </font></p>
   <p class="lead">
            <asp:TextBox ID="stringtocheck" runat="server" Width="1404px" Height="46px" OnTextChanged="stringtocheck_TextChanged" ></asp:TextBox>
          </p>
    <p class="lead">
            &nbsp;</p>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
     <font size ="2em"> 
    <br />
    <asp:Button ID="submit" runat="server"  Text="Submit" OnClick="submit_Click" /> 
    <br />
    <asp:Label ID="label1" runat="server" Text=""></asp:Label>
    <br />
    </font></asp:Content>
