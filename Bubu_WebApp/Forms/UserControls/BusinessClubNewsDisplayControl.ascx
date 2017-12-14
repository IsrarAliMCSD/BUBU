<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BusinessClubNewsDisplayControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.BusinessClubNewsDisplayControl" %>
<div class="container">
    <div class="row">
        <div class="col-12">
            <asp:Label ID="lblNewsHeading" runat="server" CssClass="mainHeading" Text="NEWS"></asp:Label>
        </div>
    </div>
    <div>


        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gvNews" runat="server" ShowHeader="false" GridLines="Horizontal" AutoGenerateColumns="false" Width="100%"
                    EmptyDataText="No News found.">
                    <AlternatingRowStyle BackColor="#97a969" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="col-3">
                                    <asp:Image ID="Image1" runat="server" ClientIDMode="Static" CssClass="widthHeight50 borderRadious"
                                        ImageUrl='<%# GetImage(Eval("BusinessClub.CONTENTDATA"),Eval("BusinessClub.FORMAT").ToString() ) %>' /><br />
                                    <asp:Label ID="Label1" runat="server"   Text='<%# Eval("BusinessClub.BusinessClubName")%>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="col-9">
                                    <asp:Label ID="lblNewsDetail" Font-Bold="true" Font-Italic="true"  runat="server" Text='<%# Eval("NEWSDETAIL") %>'></asp:Label>

                                    <br />
                                    <asp:Label ID="Label2" runat="server" Font-Bold="true" Text='<%# Eval("CreatedDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </div>
</div>
