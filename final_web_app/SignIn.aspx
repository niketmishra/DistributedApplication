<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SignIn.aspx.cs" Inherits="final_web_app.SignIn" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
          
            <h4>
                Checks if the email id is already registered, if the password is correct then it will let you login</h4>
            <p class="absolute">
                URL of Service : http://localhost:51024/Service1.svc?wsdl <br />
                Method Name: SignIn()<br />
                Input parameters: Email Id, Password, IsEmployer<br />
                Return type: boolean(Success)</p> <h4>Account Credentials</h4>
            <br /> 
            <p class="absolute">
                Email Id:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="textBox2" runat="server"></asp:TextBox>
            </p>
            <p class="absolute">
                Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="textBox1" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<asp:Button ID="button1" runat="server" OnClick="button1_Click" Text="Sign In" />
            </p>
    <asp:RadioButton ID="RadioButton1" runat="server" Text="  I am an employer"/>
            
            
     <h3>
                <asp:Label ID="label1" runat="server" Text=""></asp:Label>
            </h3>
        
</asp:Content>