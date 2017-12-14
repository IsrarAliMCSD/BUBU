<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BusinessClubActivityListControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.BusinessClubActivityListControl" %>
 
<div class="row">
    <div class="col-12">
        <asp:Label ID="lblEvent" runat="server" CssClass="mainHeading" Text="Business Club Events"></asp:Label>
    </div>
</div>
<asp:GridView ID="gvBCActivityList" runat="server" ShowHeader="false" BackColor="#999966" AutoGenerateColumns="false"
     Width="100%" EmptyDataText="No Busines club activity found." GridLines="Horizontal"  OnRowCommand="gvBCActivityList_RowCommand">
    
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
                <asp:Label ID="Label6" runat="server" Text='<%# Bind("ActivityDate") %>'></asp:Label>
                <br />
                <asp:Label ID="Label7" runat="server" CssClass="boldText" Text="Description: "></asp:Label>
                <asp:Label ID="Label8" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                <asp:Label ID="lblBusinessClubActivityId" runat="server" Visible="false" Text='<%# Bind("BusinesClubActivityId") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>


        <asp:TemplateField >
            <ItemTemplate >
                <tr style="background-color:white" >
                        <td style="min-width:20%; background-color:#ded5d5" ></td>
                    <td colspan="80%">
                        <asp:Panel ID="pnlApply" runat="server">
                            
                            <asp:GridView ID="gvMessage" runat="server" ShowHeader="false" ShowFooter="true" GridLines="Horizontal"
                                DataSource='<%#(Eval("BusinessClubActivityComments")) %>'
                                AutoGenerateColumns="false" Width="100%">
                                 <AlternatingRowStyle BackColor="gray" />
                                <Columns>
                                    

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Image ID="img_User" runat="server" ClientIDMode="Static" CssClass="width25 borderRadious"
                                                ToolTip='<%# "" + Eval("USER.FirstName") + " " + Eval("USER.LastName")%>'
                                                ImageUrl='<%# GetImage(Eval("User.CONTENTDATA"),Eval("user.FORMAT").ToString() ) %>' />
                                            <asp:Label ID="lblComments" runat="server" Text='<%# Bind("Message") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtComments" runat="server" ClientIDMode="Static" CssClass="textBox width400"  Text=""></asp:TextBox>
                                            <asp:Button ID="btnCommentSubmit" runat="server"  CssClass="button width260 height35" 
                                                 OnClientClick="return IsEmptyData(this);" Text="Comment" CommandName="SAVECOMMENT" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                </Columns>

                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
