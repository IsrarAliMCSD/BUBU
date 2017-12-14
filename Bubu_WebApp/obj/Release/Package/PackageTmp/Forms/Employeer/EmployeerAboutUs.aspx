<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Employeer/Employeer_Master.Master"
    AutoEventWireup="true" CodeBehind="EmployeerAboutUs.aspx.cs" Inherits="Bubu_WebApp.Forms.Employeer.EmployeerAboutUs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="row">
            <div class="col-8">
                <asp:Label ID="Label3" runat="server" CssClass="mainHeading" Text="Abous Us"></asp:Label>
            </div>
            <div class="col-4">
                <asp:Button ID="btnEditCompanyAboutUs" runat="server" Text="Edit" CssClass="button width260 height35" OnClick="btnEditCompanyAboutUs_Click" />
            </div>
        </div>
        <br />
        <br />
        <asp:Repeater ID="rptrAboutUs" runat="server">
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
                    <div class="col-12">
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

</asp:Content>
