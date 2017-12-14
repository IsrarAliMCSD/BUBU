<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BusinessClubActivityListUpdate.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.BusinessClubActivityListUpdate" %>

<div class="container">
    <div class="row">
        <div class="col-8">   
            <asp:Label ID="lblEvent" runat="server" CssClass="mainHeading" Text="Business Club Events"></asp:Label>  <br />
        </div>
        <div class="col-4 text-right">
            <asp:Button ID="btnAddBusinessClubActivity" CssClass="form-btn " runat="server" Text="+ Business Club Event" OnClick="btnAddBusinessClubActivity_Click" />
        </div>
    </div>
      <br />
    <asp:GridView ID="gvBCActivityList" runat="server" ShowHeader="false" BackColor="#d0d0d9" AutoGenerateColumns="false"
        Width="100%" EmptyDataText="No Busines club Event found." GridLines="Horizontal">
        <AlternatingRowStyle BackColor="#e8e8ec" />
        <Columns>
            <asp:TemplateField ItemStyle-Width="150px">

                <ItemTemplate>
                    <asp:Image ID="img_Club" runat="server" ClientIDMode="Static" CssClass="width50 borderRadious"
                        ImageUrl='<%# GetImage(Eval("BusinessClub.CONTENTDATA"),Eval("BusinessClub.FORMAT").ToString() ) %>' /><br />
                    <asp:Label ID="lblCLUBNAME" runat="server" Text='<%# Eval("BusinessClub.BusinessClubName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="img_CreatedBy" runat="server" ClientIDMode="Static" CssClass="width50 borderRadious"
                        ImageUrl='<%# GetImage(Eval("USER.CONTENTDATA"),Eval("USER.FORMAT").ToString() ) %>' /><br />
                    <asp:Label ID="lblUSERNAME" runat="server" Text='<%# Eval("USER.FIRSTNAME")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" CssClass="boldText" Text="Subject: "></asp:Label>
                    <asp:Label ID="lblJobTitle" runat="server" Text='<%# Bind("Subject") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Label11" runat="server" CssClass="boldText" Text="Message Type: "></asp:Label>
                    <asp:Label ID="lblJobFunction" runat="server" Text='<%# Bind("BusinessActivityMessageType.BusinessActivityMessageTypeName") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Label5" runat="server" CssClass="boldText" Text="ActivityDate: "></asp:Label>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("ActivityDate", "{0:MM/dd/yy}") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" CssClass="boldText" Text="Description: "></asp:Label>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    <asp:Label ID="lblBusinessClubActivityId" runat="server" Visible="false" Text='<%# Bind("BusinesClubActivityId") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" CssClass="boldText" Text="Dead Line: "></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("DeadLine", "{0:MM/dd/yy}") %>'></asp:Label>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
