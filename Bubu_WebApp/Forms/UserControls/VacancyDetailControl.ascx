<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VacancyDetailControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.VacancyDetailControl" %>
 
<div class="row">
    <div class="col-2">
        <asp:Label ID="lblVacancyID" CssClass="mainHeading" runat="server" Visible="false"></asp:Label>
        <asp:Image ID="img_document" runat="server" ClientIDMode="Static" CssClass="width100 borderRadious" />
        <br />
        <asp:Label ID="lblCOMPANYNAME" runat="server"></asp:Label>

    </div>
    <div class="col-4">
        <asp:Label ID="Label1" runat="server" CssClass="boldText" Text="Sector: "></asp:Label>
        <asp:Label ID="lblCompanySector" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label11" runat="server" CssClass="boldText" Text="Function: "></asp:Label>
        <asp:Label ID="lblJobFunction" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" CssClass="boldText" Text="Region: "></asp:Label>
        <asp:Label ID="lblRegion" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server" CssClass="boldText" Text="Job Type: "></asp:Label>
        <asp:Label ID="lblJobType" runat="server"></asp:Label>

    </div>
    <div class="col-4">
        <asp:Label ID="Label112" runat="server" CssClass="boldText" Text="Job Title: "></asp:Label>
        <asp:Label ID="lblJobTitle" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label21" runat="server" CssClass="boldText" Text="Job Detail: "></asp:Label>
        <asp:Label ID="lblJobDetail" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblIsPrivate" runat="server" CssClass="boldText"></asp:Label>
    </div>
</div>
