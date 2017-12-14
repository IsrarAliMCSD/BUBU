<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Employeer/Employeer_Master.Master" AutoEventWireup="true" CodeBehind="VacancySearchCandidate.aspx.cs" Inherits="Bubu_WebApp.Forms.Employeer.VacancySearchCandidate" %>

<%@ Register Src="~/Forms/UserControls/VacancyDetailControl.ascx" TagPrefix="uc1" TagName="VacancyDetailControl" %>
<%@ Register Src="~/Forms/UserControls/CandidateSearchControl.ascx" TagPrefix="uc1" TagName="CandidateSearchControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <uc1:VacancyDetailControl runat="server" id="VacancyDetailControl1" />
     <div class="row">
        <div class="col-12">
            <center><asp:Button ID="btnBack" runat="server"  Text="Back"   CssClass="button width260 height35" OnClick="btnBack_Click" /></center>

        </div>

    </div>

    <div class="row">
        <div class="col-12">
            <hr />
        </div>


    </div>

    <uc1:CandidateSearchControl runat="server" ID="CandidateSearchControl1" />
</asp:Content>
   