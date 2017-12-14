<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentListDisplayControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.DocumentListDisplayControl" %>


<div>
    <div class="container">
        <div class="row">
            <asp:Label ID="lblHeading" runat="server" CssClass="mainHeading" Text=""></asp:Label>
        </div>
        <div class="row">
            <asp:Repeater ID="rptDocumentDisplay" runat="server">
                <ItemTemplate>
                    <div class="col-3">
                        <asp:Image ID="img_document" runat="server" ClientIDMode="Static" CssClass="width100 pointer"
                            ImageUrl='<%# GetImage(Eval("CONTENTDATA"),Eval("FORMAT").ToString() ) %>' /><br />
                        <asp:Label ID="lbldescription" runat="server" Text='<%# Eval("Description")%>'></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>

