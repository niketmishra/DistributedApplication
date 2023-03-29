<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplicantView.aspx.cs" Inherits="final_web_app.ApplicantView" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div>
        <h1>Applicant Profile TryIt Page</h1>
    </div>

    <p>
              <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/NearestStore.aspx">Find Nearest Employer Office</asp:HyperLink>
            </p>

     <p>
              <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="/ViewJobs.aspx">See Jobs</asp:HyperLink>
            </p>

</asp:Content>
