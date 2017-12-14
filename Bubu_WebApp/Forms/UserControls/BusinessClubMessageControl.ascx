<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BusinessClubMessageControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.BusinessClubMessageControl" %>
<div class="container">

    <div class="row">
        <div class="cl-12">
            <asp:Label ID="Label1" runat="server" CssClass="mainHeading" Text="Job News Club :"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <hr />
        </div>
    </div>

    <div class="row">
        <div class="col-12">
            <asp:GridView ID="gvNEws" ShowHeader="false" GridLines="Horizontal" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Founds.">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Image ID="img_CreatedBy" runat="server" ClientIDMode="Static" CssClass="width50 borderRadious"
                                ImageUrl='<%# GetImage(Eval("USER1.CONTENTDATA"),Eval("USER1.FORMAT").ToString() ) %>' /><br />
                            <asp:Label ID="lblUSERNAME" runat="server" Text='<%# Eval("USER1.FIRSTNAME")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="img_CreatedBy" runat="server" ClientIDMode="Static" CssClass="width50 borderRadious"
                                ImageUrl='<%# GetImage(Eval("USER.CONTENTDATA"),Eval("USER.FORMAT").ToString() ) %>' /><br />
                            <asp:Label ID="lblUSERNAME" runat="server" Text='<%# Eval("USER.FIRSTNAME")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField ItemStyle-Width="60%">
                        <ItemTemplate>
                            <asp:Label ID="lblVacancy" runat="server" Text='<%# Bind("Message") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField ItemStyle-Width="60%">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("CreatedDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </div>



    <div class="row">
        <div class="cl-12">
            <asp:Label ID="lblMessageType" runat="server" CssClass="mainHeading" Text="Business Club Message:"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <hr />
        </div>

    </div>

    <div class="row">
        <div class="col-12">
            <asp:GridView ID="gvAllBusinessClubMessage" ShowHeader="false" GridLines="Horizontal" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Founds.">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Image ID="img_Club" runat="server" ClientIDMode="Static" CssClass="width50 borderRadious"
                                ImageUrl='<%# GetImage(Eval("BusinessClubActivity.BusinessClub.CONTENTDATA"),Eval("BusinessClubActivity.BusinessClub.FORMAT").ToString() ) %>' /><br />
                            <asp:Label ID="lblCLUBNAME" runat="server" Text='<%# Eval("BusinessClubActivity.BusinessClub.BusinessClubName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="img_CreatedBy" runat="server" ClientIDMode="Static" CssClass="width50 borderRadious"
                                ImageUrl='<%# GetImage(Eval("USER.CONTENTDATA"),Eval("USER.FORMAT").ToString() ) %>' /><br />
                            <asp:Label ID="lblUSERNAME" runat="server" Text='<%# Eval("USER.FIRSTNAME")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="60%">
                        <ItemTemplate>
                            <%--<asp:Label ID="Label1" runat="server" CssClass="boldText" Text="Event Name: "></asp:Label>--%>
                            <asp:Label ID="lblJobTitle" runat="server" Text='<%# Bind("BusinessClubActivity.Subject") %>'></asp:Label>
                            <br />
                            <%--<asp:Label ID="Label11" runat="server" CssClass="boldText" Text="Message Type: "></asp:Label>--%>
                            <asp:Label ID="lblJobFunction" runat="server" Text='<%# Bind("BusinessClubActivity.BusinessActivityMessageType.BusinessActivityMessageTypeName") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label5" runat="server" CssClass="boldText" Text="ActivityDate: "></asp:Label>
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("BusinessClubActivity.ActivityDate") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label7" runat="server" CssClass="boldText" Text="Location: "></asp:Label>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("BusinessClubActivity.Description") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label2" runat="server" CssClass="boldText" Text="DeadLine: "></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("BusinessClubActivity.Deadline") %>'></asp:Label>
                            <br />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>

                            <asp:Button ID="btnAceepting" runat="server" Visible='<%# Eval("BusinessClubActivity.BusinessClubMessageTypeId").ToString()=="1" %>' Text="Accepting" CssClass="button width150 height35" CommandName="MEETINGACCEPT" OnClientClick="return confirm('Accepting Meeting');" CommandArgument='<%#  Bind("BusinesClubActivityDetailId") %>' />
                            <asp:Button ID="Button2" runat="server" Visible='<%# Eval("BusinessClubActivity.BusinessClubMessageTypeId").ToString()=="4" %>' Text="Cancel" CssClass="button width150 height35" CommandName="VOTEREJECT" OnClientClick="return confirm('Voting in favour');" CommandArgument='<%#  Bind("BusinesClubActivityDetailId") %>' />
                            <br />
                            <asp:Button ID="btnReject" runat="server" Visible='<%# Eval("BusinessClubActivity.BusinessClubMessageTypeId").ToString()=="1" %>' Text="Rejecting " CssClass="button width150 height35" CommandName="MEETINGREJECT" OnClientClick="return confirm('Rejecting Meeting');" CommandArgument='<%#  Bind("BusinesClubActivityDetailId") %>' />
                            <asp:Button ID="Button1" runat="server" Visible='<%# Eval("BusinessClubActivity.BusinessClubMessageTypeId").ToString()=="4" %>' Text="Accepting" CssClass="button width150 height35" CommandName="VOTEACCEPT" OnClientClick="return confirm('Voting in against');" CommandArgument='<%#  Bind("BusinesClubActivityDetailId") %>' />

                            <br />
                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("BusinessClubActivity.CreatedDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>

       <div class="row">
        <div class="cl-12">
            <asp:Label ID="Label4" runat="server" CssClass="mainHeading" Text="User Message:"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
             <asp:GridView ID="gvUserMaeesge" ShowHeader="false" GridLines="Horizontal" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Founds.">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Image ID="img_CreatedBy" runat="server" ClientIDMode="Static" CssClass="width50 borderRadious"
                                ImageUrl='<%# GetImage(Eval("USER1.CONTENTDATA"),Eval("USER1.FORMAT").ToString() ) %>' /><br />
                            <asp:Label ID="lblUSERNAME" runat="server" Text='<%# Eval("USER1.FIRSTNAME")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="img_CreatedBy" runat="server" ClientIDMode="Static" CssClass="width50 borderRadious"
                                ImageUrl='<%# GetImage(Eval("USER.CONTENTDATA"),Eval("USER.FORMAT").ToString() ) %>' /><br />
                            <asp:Label ID="lblUSERNAME" runat="server" Text='<%# Eval("USER.FIRSTNAME")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField ItemStyle-Width="60%">
                        <ItemTemplate>
                            <asp:Label ID="lblVacancy" runat="server" Text='<%# Bind("MessageText") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                 
                </Columns>

            </asp:GridView>
        </div>

    </div>


</div>
