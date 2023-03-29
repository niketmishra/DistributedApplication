<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="final_web_app.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
            <asp:TextBox ID="password" runat="server" Width="1404px" Height="46px" OnTextChanged="password_TextChanged"></asp:TextBox>
        </p>

    <p class="lead">  <font size ="2em"> 
            Enter emailid:
        </font></p>
        <p class="lead">
            <asp:TextBox ID="email" runat="server" Width="1404px" Height="46px" OnTextChanged="email_TextChanged"></asp:TextBox>
        </p><br />
 
    <p class="lead">  <font size ="2em"> 
            Enter phone number:
        </font></p>
        <p class="lead">
            <asp:TextBox ID="phoneNumber" runat="server" Width="1404px" Height="46px" OnTextChanged="phoneNumber_TextChanged"></asp:TextBox>
        </p>
   
    <br /><br />
    <p class="lead">  <font size ="2em"> 
            Enter location details:
        </font></p>
    <p class="lead">  <font size ="2em"> 
            Enter zip code (required):
        </font></p>
    <p class="lead">
            <asp:TextBox ID="zip" runat="server" Width="1404px" Height="46px" OnTextChanged="zip_TextChanged"></asp:TextBox>
        </p>
    <p class="lead">  <font size ="2em"> 
            Enter city:
        </font></p>
        <p class="lead">
            <asp:TextBox ID="city" runat="server" Width="1404px" Height="46px" OnTextChanged="city_TextChanged"></asp:TextBox>
        </p>
    <p class="lead">  <font size ="2em"> 
            Enter state:
        </font></p>
        <p class="lead">
            <asp:TextBox ID="state" runat="server" Width="1404px" Height="46px" OnTextChanged="state_TextChanged"></asp:TextBox>
        </p>
    <p class="lead">  <font size ="2em"> 
            Enter job profile:
        </font></p>
        <p class="lead">
            <asp:TextBox ID="jobProfile" runat="server" Width="1404px" Height="46px" OnTextChanged="jobProfile_TextChanged"></asp:TextBox>
        </p>

    <p class="lead">  <font size ="2em"> 
            Enter skills:
        </font></p>
        <p class="lead">
            <asp:TextBox ID="skills" runat="server" Width="1404px" Height="46px" OnTextChanged="skills_TextChanged"></asp:TextBox>
        </p>

    <p class="lead">  <font size ="2em"> 
            Enter work experience:
        </font></p>
        <p class="lead">
            <asp:TextBox ID="workExperience" runat="server" Width="1404px" Height="46px" OnTextChanged="workExperience_TextChanged"></asp:TextBox>
        </p>

    <p class="lead">  <font size ="2em"> 
            Enter university name:
        </font></p>
        <p class="lead">
            <asp:TextBox ID="universityName" runat="server" Width="1404px" Height="46px" OnTextChanged="universityName_TextChanged"></asp:TextBox>
        </p>

    <p class="lead">  <font size ="2em"> 
            Enter cgpa:
        </font></p>
        <p class="lead">
            <asp:TextBox ID="cgpa" runat="server" Width="1404px" Height="46px" OnTextChanged="cgpa_TextChanged"></asp:TextBox>
        </p>

    <p class="lead">  <font size ="2em"> 
            Enter your degree:
        </font></p>
        <p class="lead">
            <asp:TextBox ID="degreeName" runat="server" Width="1404px" Height="46px" OnTextChanged="degreeName_TextChanged"></asp:TextBox>
        </p>

    </font>
        </p>
    <img alt="" id="captchaimage" runat="server"/>
     <p class="lead">  <font size ="2em"> 
            Enter the captcha text:
        </font></p>
   <p class="lead">
            <asp:TextBox ID="stringtocheck" runat="server" Width="1404px" Height="46px" OnTextChanged="stringtocheck_TextChanged" ></asp:TextBox>
          </p>
    <font size ="2em"> <asp:Button ID="submit" runat="server"  Text="Submit" OnClick="submit_Click" /> 
   
    </font>

</asp:Content>
