<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompanyAboutUsControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.CompanyAboutUsControl" %>

<div class="container">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblAboutUs" runat="server" CssClass="mainHeading"
                Text="About Us"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <asp:Label ID="lblCompanyAboutUsId" Visible="false" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblCompanyId" Visible="false" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label1" runat="server" CssClass="boldText"
                Text="Heading: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtHeading" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvHeading" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGCompanyAbout" runat="server" ControlToValidate="txtHeading"
                ErrorMessage="Please enter Heading"></asp:RequiredFieldValidator>

        </div>
    </div>


    <div class="row">
        <div class="col-3">
            <asp:Label ID="Label2" runat="server" CssClass="boldText"
                Text="Detail: "></asp:Label>
        </div>
        <div class="col-9">
            <asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Rows="5" Columns="80" ClientIDMode="Static"
                CssClass="width100pc" MaxLength="500"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" CssClass="validation"
                ValidationGroup="VGCompanyAbout" runat="server" ControlToValidate="txtDetail"
                ErrorMessage="Please enter Detail"></asp:RequiredFieldValidator>


        </div>
    </div>
    <div class="row">
        <div class="col-3"></div>
        <div class="col-9">
            <asp:TextBox ID="txtURL" runat="server" TextMode="SingleLine" ClientIDMode="Static"
                CssClass="width450"></asp:TextBox>
            <img id="img_loadImage" src="../../Images/url.png" class="widthHeight50" onclick="loadURL(this)" fetchUrlId="txtURL" /><br />
           



        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <br />
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
            <asp:Button ID="btnSave" runat="server" ValidationGroup="VGCompanyAbout" Text="Save" ToolTip="Save" CssClass="button width260 height35" OnClick="btnSave_Click" />
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
    <asp:Repeater ID="rptrAboutUs" runat="server" OnItemCommand="rptrAboutUs_ItemCommand">
        <ItemTemplate>
            <div class="row">
                <div class="col-12">
                    <asp:Label ID="lblHeading" runat="server" CssClass="boldText" Text='<%# Bind("Heading") %>'></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-10">
                    <asp:Label ID="lblDetail" runat="server" Text='<%# Bind("Detail") %>'></asp:Label>
                </div>
                <div class="col-2">
                    <asp:ImageButton ID="ibtnEdit" runat="server" ImageUrl="~/Images/Icon/edit.png" CausesValidation="false"
                        CommandArgument='<%# Bind("CompanyAboutUsId") %>' CommandName="ABOUTUSEDIT"
                        ToolTip="Edit" CssClass="width20" />
                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="~/Images/Icon/delete.png" CausesValidation="false"
                        CommandArgument='<%# Bind("CompanyAboutUsId") %>' CommandName="ABOUTUSDELETE"
                        ToolTip="Delete" CssClass="width20" OnClientClick="return confirm('Do you want to delete this record?');" />
                </div>

            </div>
            <div class="row">
                <div class="col-2"></div>
                <div class="col-8">
                    <hr />
                </div>
                <div class="col-2"></div>
            </div>

        </ItemTemplate>
    </asp:Repeater>



</div>
