<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Employeer/Employeer_Master.Master" AutoEventWireup="true" CodeBehind="CreateMessage.aspx.cs" Inherits="Bubu_WebApp.Forms.Employeer.CreateMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="Label1" runat="server" CssClass="mainHeading" Text="Messages:"></asp:Label>

        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblError" runat="server" CssClass="validation" Text=""></asp:Label>
        </div>
    </div>


    <div class="row">
        <div class="col-12">
            <asp:DropDownList ID="ddlUserList" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="rfvCategory" Display="Dynamic" CssClass="validation"
                ValidationGroup="a" runat="server" ControlToValidate="ddlUserList"
                ErrorMessage="Please select user"></asp:RequiredFieldValidator>
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <asp:TextBox ID="txtMessage" runat="server" Text="" ValidationGroup="a" TextMode="MultiLine" Width="635px" Height="73px"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Button ID="btnSave" runat="server" ValidationGroup="a" Text="Save" ToolTip="Save" CssClass="button width260 height35" OnClick="btnSave_Click"  />
            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Save" ToolTip="Save" CssClass="button width260 height35" OnClick="btnCancel_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <hr />
        </div>
    </div>


    



</asp:Content>
