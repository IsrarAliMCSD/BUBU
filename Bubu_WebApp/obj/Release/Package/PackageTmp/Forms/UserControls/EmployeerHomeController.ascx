<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeerHomeController.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.EmployeerHomeController" %>
   <div class="container">
        <div class="row">
            <div class="col-12">
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-8">
                <asp:Label ID="lblCompanyInformation" runat="server" CssClass="mainHeading" Text="Company Information"></asp:Label>
            </div>

            <div class="col-4">
                <asp:Button ID="btnEdit" runat="server" Text="Edit" Visible="false"  CssClass="button width260 height35" OnClick="btnEdit_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-8">
                <div class="row">

                    <div class="col-4">
                        <asp:Label ID="lblCompanyId" Visible="false" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblCompanyNameHeading" runat="server" CssClass="boldText" Text="Company Name: "></asp:Label>
                    </div>
                    <div class="col-8">
                        <asp:Label ID="lblCompanyName" runat="server"></asp:Label>

                    </div>
                </div>

                <div class="row">
                    <div class="col-4">
                        <asp:Label ID="lblCompanyAddressHeading" runat="server" CssClass="boldText" Text="Company Address: "></asp:Label>
                    </div>
                    <div class="col-8">
                        <asp:Label ID="lblCompanyAddress" runat="server" CssClass="width200"></asp:Label>

                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <asp:Label ID="Label1" runat="server" CssClass="boldText" Text="Contact No: "></asp:Label>
                    </div>
                    <div class="col-8">
                        <asp:Label ID="lblContactNo" runat="server" CssClass="width200"></asp:Label>
                    </div>
                </div>
            </div>

            <div class="col-4">
                <div class="row">
                    <div class="col-12">
                        <asp:Image ID="imgFileUpload" runat="server" ClientIDMode="Static" CssClass="width200 borderRadious" />
                    </div>

                </div>
            </div>
        </div>


    </div>