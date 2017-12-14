<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserReferenceControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.UserReferenceControl" %>

<div class="container">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblReferences" runat="server" CssClass="mainHeading" Text="References"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <asp:Label ID="lblUserreferenceId" Visible="false" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label3" runat="server" Text="Reference : "></asp:Label>
        </div>
        <div class="col-4">
            <asp:DropDownList ID="ddlReference" CssClass="ddlWidth260 ddl" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="rfvReference" Display="Dynamic" CssClass="validation"
                ValidationGroup="userReference" runat="server" ControlToValidate="ddlReference"
                ErrorMessage="Please select Reference name "></asp:RequiredFieldValidator>
        </div>

    </div>
    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label2" runat="server" Text="Name: "></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtReferenceName" runat="server" ValidationGroup="userReference" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvReferenceName" Display="Dynamic" CssClass="validation"
                ValidationGroup="userReference" runat="server" ControlToValidate="txtReferenceName"
                ErrorMessage="Please enter reference name"></asp:RequiredFieldValidator>
        </div>
        <div class="col-2">
            <asp:Label ID="Label1" runat="server" Text="Position: "></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtPosition" runat="server" ValidationGroup="userReference" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPosition" Display="Dynamic" CssClass="validation"
                ValidationGroup="userReference" runat="server" ControlToValidate="txtPosition"
                ErrorMessage="Please enter position"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <asp:Label ID="Label4" runat="server" Text="Company: "></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtCompany" runat="server" ValidationGroup="userReference" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCompany" Display="Dynamic" CssClass="validation"
                ValidationGroup="userReference" runat="server" ControlToValidate="txtCompany"
                ErrorMessage="Please enter company"></asp:RequiredFieldValidator>
        </div>
        <div class="col-2">
            <asp:Label ID="Label5" runat="server" Text="Contact: "></asp:Label>
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtContact" runat="server" ValidationGroup="userReference" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvContact" Display="Dynamic" CssClass="validation"
                ValidationGroup="userReference" runat="server" ControlToValidate="txtContact"
                ErrorMessage="Please enter contact"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblError" runat="server" CssClass="validation" Text=""></asp:Label>

        </div>

    </div>
    <div class="row">
        <div class="col-2"></div>
        <div class="col-4">
            <asp:Button ID="btnSave" runat="server" ValidationGroup="userReference" Text="Save" ToolTip="Save" CssClass="button width260 height35" OnClick="btnSave_Click" />
        </div>
        <div class="col-2"></div>
        <div class="col-4">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" CssClass="button width260 height35" OnClick="btnCancel_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CausesValidation="false" CssClass="button width260 height35" OnClick="btnBack_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <hr />
        </div>

    </div>
    <asp:Repeater ID="rptruserreference" runat="server" OnItemCommand="rptruserreference_ItemCommand">
        <ItemTemplate>
            <div class="row">
                <div class="col-8">
                    <asp:Label ID="lblReferenceName" runat="server" CssClass="boldText"
                        Text='<%# Eval("ReferenceName")+" ( "+ Eval("Reference.ReferenceName")+" ) " %>'></asp:Label>
                </div>
                <div class="col-4"></div>
            </div>
            <div class="row">
                <div class="col-8">
                    <asp:Label ID="lblReferencePosition" runat="server" Text='<%# Eval("ReferencePosition") %>'></asp:Label>
                    <span class="italicText">at </span>
                    <asp:Label ID="lblReferenceCompany" runat="server" Text='<%# Eval("ReferenceCompany") %>'></asp:Label>
                </div>
                <div class="col-4"></div>
            </div>
            <div class="row">
                <div class="col-10">
                    <asp:Label ID="lblReferenceContactNumber" runat="server" CssClass="italicText" Text='<%# Eval("ReferenceContactNo") %>'></asp:Label>
                </div>
                <div class="col-2">
                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/Icon/edit.png" CausesValidation="false"
                        CommandArgument='<%# Bind("UserReferenceId") %>' CommandName="USERREFERENCEEDIT"
                        ToolTip="Edit" CssClass="width20" />
                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/Icon/delete.png" CausesValidation="false"
                        CommandArgument='<%# Bind("UserReferenceId") %>' CommandName="USERREFERENCEDELETE"
                        ToolTip="Delete" CssClass="width20" OnClientClick="return confirm('Do you want to delete this record?');" />
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <hr />
                </div>
            </div>

        </ItemTemplate>

    </asp:Repeater>


</div>
