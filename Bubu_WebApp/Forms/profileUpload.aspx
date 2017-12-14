<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="profileUpload.aspx.cs" Inherits="Bubu_WebApp.Forms.profileUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $("#fuplProfile").change(function () {
                ShowImageReadURL(this, "imgFileUpload");
            });
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="container">
            <div class="row">
                <div class="col-6">
                    <asp:FileUpload ID="fuplProfile" runat="server" ClientIDMode="Static" />
                </div>
                <div class="col-6"><br />
                    <asp:Image ID="imgFileUpload" runat="server" ClientIDMode="Static"  CssClass="borderRadious width300"   />
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <hr />
                </div>
                </div>
            <div class="row">
                <div class="col-2">
                </div>
                <div class="col-10">
                    <asp:Label ID="lblMessage" runat="server" CssClass="validation" Text=""></asp:Label>
                </div>

            </div>
            <div class="row">
                <div class="col-6">
                    <asp:Button ID="btnSave" runat="server" CssClass="button width260 height35" Text="Save" OnClick="btnSave_Click" />
                </div>
                <div class="col-6">
                    <asp:Button ID="btnCancel" runat="server" CssClass="button width260 height35" Text="Cancel" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
