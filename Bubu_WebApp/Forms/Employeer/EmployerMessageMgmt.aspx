<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Employeer/Employeer_Master.Master" AutoEventWireup="true" CodeBehind="EmployerMessageMgmt.aspx.cs" Inherits="Bubu_WebApp.Forms.Employeer.EmployerMessageMgmt" %>

<%@ Register Src="~/Forms/UserControls/BusinessClubMessageControl.ascx" TagPrefix="uc1" TagName="BusinessClubMessageControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row">
        <div class="col-12">
            <asp:Button ID="btnSendMEssage" runat="server" CssClass="button width260 height35" Text="send Message" OnClick="btnSendMEssage_Click" 
                />
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <hr />
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <uc1:BusinessClubMessageControl runat="server" ID="BusinessClubMessageControl" />

        </div>
    </div>

</asp:Content>
