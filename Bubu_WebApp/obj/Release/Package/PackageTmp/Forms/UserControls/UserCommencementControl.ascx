<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserCommencementControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.UserCommencementControl" %>

<div class="container">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblCommencement" runat="server" CssClass="mainHeading" Text="Commencement Of Job"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:DropDownList ID="ddlCommencementOfJob" runat="server" CssClass="ddlWidth260 ddl" >
            </asp:DropDownList>
             <asp:RequiredFieldValidator InitialValue="-1" ID="rfvCommencementOfJob" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGCommencementOfJob" runat="server" ControlToValidate="ddlCommencementOfJob"
                ErrorMessage="Please select commencement"></asp:RequiredFieldValidator>
        </div>
    </div>

   <div class="row">
            <div class="col-12">
                <hr />
            </div>
        </div>

    <div class="row">

        <div class="col-6">
            <asp:Button ID="btnUpdate" runat="server" ValidationGroup="VGCommencementOfJob" Text="Update" ToolTip="Save"  CssClass="button width260 height35" OnClick="btnUpdate_Click" />
        </div>
        <div class="col-6">
            <asp:Button ID="btnBack" runat="server" Text="Back" CausesValidation="false"  CssClass="button width260 height35" OnClick="btnBack_Click" />
        </div>
    </div>
</div>
