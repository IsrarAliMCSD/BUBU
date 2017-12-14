<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VacancyApplicantList.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.VacancyApplicantList" %>
<div class="container">
    <div class="row">
        <div class="col-2">
            <asp:Label ID="lblVacancyID" CssClass="mainHeading" runat="server" Visible="false"></asp:Label>
            <asp:Image ID="img_document" runat="server" ClientIDMode="Static" CssClass="width100 borderRadious" />
            <br />
            <asp:Label ID="lblCOMPANYNAME" runat="server"></asp:Label>

        </div>
        <div class="col-4">
            <asp:Label ID="Label1" runat="server" CssClass="boldText" Text="Sector: "></asp:Label>
            <asp:Label ID="lblCompanySector" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label11" runat="server" CssClass="boldText" Text="Function: "></asp:Label>
            <asp:Label ID="lblJobFunction" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" CssClass="boldText" Text="Region: "></asp:Label>
            <asp:Label ID="lblRegion" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" CssClass="boldText" Text="Job Type: "></asp:Label>
            <asp:Label ID="lblJobType" runat="server"></asp:Label>

        </div>
        <div class="col-4">
            <asp:Label ID="Label112" runat="server" CssClass="boldText" Text="Job Title: "></asp:Label>
            <asp:Label ID="lblJobTitle" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label21" runat="server" CssClass="boldText" Text="Job Detail: "></asp:Label>
            <asp:Label ID="lblJobDetail" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblIsPrivate" runat="server" CssClass="boldText"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <center><asp:Button ID="btnBack" runat="server"  Text="Back"   CssClass="button width260 height35" OnClick="btnBack_Click" /></center>

        </div>

    </div>

    <div class="row">
        <div class="col-12">
            <hr />
        </div>


    </div>

    <div class="row">
        <div class="col-12">

            <asp:GridView ID="gvApplicant" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No vacancy application exists." GridLines="Horizontal" OnRowCommand="gvApplicant_RowCommand">
                 <AlternatingRowStyle BackColor="#999966" />
                <Columns>
                    <asp:TemplateField>

                        <ItemTemplate>
                            <asp:Image ID="img_ProfilePicture" runat="server" ClientIDMode="Static" CssClass="width50 borderRadious"
                                ImageUrl='<%# GetImage(Eval("User.ContentData"),Eval("User.FORMAT").ToString() ) %>' /><br />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" CssClass="boldText" Text="Name: "></asp:Label>
                            <asp:Label ID="lblEmployeeName" runat="server"
                                Text='<%# Eval("User.FirstName")+" "+Eval("User.LastName") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label2" runat="server" CssClass="boldText" Text="Birth Date: "></asp:Label>
                            <asp:Label ID="lblBirthDate" runat="server" Text='<%# Eval("User.DateOfBirth", "{0:MM/dd/yy}") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label4" runat="server" CssClass="boldText" Text="Domicile: "></asp:Label>
                            <asp:Label ID="lblDomicile" runat="server" Text='<%# Eval("User.Domicile.DomicileName") %>'></asp:Label>
                            <br />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" CssClass="boldText" Text="Company: "></asp:Label>
                            <asp:Label ID="lblCompany" runat="server" Text='<%# Eval("UserWorkExperienceLatest.Company") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label6" runat="server" CssClass="boldText" Text="Function: "></asp:Label>
                            <asp:Label ID="lblFunction" runat="server" Text='<%# Eval("UserWorkExperienceLatest.JobFunction") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label8" runat="server" CssClass="boldText" Text="Position: "></asp:Label>
                            <asp:Label ID="lblPosition" runat="server" Text='<%# Eval("UserWorkExperienceLatest.Position") %>'></asp:Label>
                            <br />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" CssClass="boldText" Text="Education: "></asp:Label>
                            <asp:Label ID="lblEducation" runat="server" Text='<%# Eval("UserQualificationLatest.Qualification.QualificationName") %>'></asp:Label>
                            <br />
                            <asp:Label ID="Label9" runat="server" CssClass="boldText" Text="Year Completed: "></asp:Label>

                            <asp:Label ID="Label12" runat="server" Text='<%#
                             Eval("UserQualificationLatest.CompletedYear")!=null &&  Eval("UserQualificationLatest.CompletedYear").ToString() == "true" ? 
                             Eval("UserQualificationLatest.CompletedYear") :
                             Eval("UserQualificationLatest.CompletedYear")!=null &&  Eval("UserQualificationLatest.CompletedYear").ToString() == "false" ? 
                              "In Progress":"" %>'></asp:Label>


                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnContact" runat="server" CommandName="SENDMESSAGE" CausesValidation="false" Text="ContactCandidate" ToolTip="ContactCandidate" />

                            <asp:ImageButton ID="lbtnCancel" runat="server" ImageUrl="~/Images/Icon/delete.png" CausesValidation="false"
                                CommandArgument='<%# Bind("vacancyApply.VacancyApplyId") %>' CommandName="EMPLOYEECANCEL"
                                ToolTip="Cancel Applicant" CssClass="width20" OnClientClick="return confirm('Do you want to delete this record?');" />
                            <br />
                            <asp:LinkButton ID="lbtnDownloadFile" runat="server"
                                CommandArgument='<%# Bind("User.UserId") %>' CommandName="CVDOWNLOAD" CausesValidation="false" Text="Download" ToolTip="Download Profile" />
                            <%--  <br />
                            <asp:LinkButton ID="lbtnletterOfrefuse" runat="server" CausesValidation="false" Text="Letter of Refuse" ToolTip="Letter of Refuse" />--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Panel ID="pnlContact" runat="server" Visible="false">
                                <tr>
                                    <td colspan="100%">
                                        <asp:Label ID="Label75" runat="server" CssClass="boldText" Text="Message: "></asp:Label>
                                        <asp:TextBox ID="txtEmployeeContact" Width="100%" MaxLength="250" TextMode="MultiLine"
                                            CssClass="motivationletter width100Pc" runat="server"></asp:TextBox>
                                        <br />
                                        <div class="col-12">
                                            <asp:RequiredFieldValidator ID="rfvEmployeeContact" runat="server" CssClass="validation"
                                                ErrorMessage="Please enter Content" ControlToValidate="txtEmployeeContact" ValidationGroup="VGEmployeeContact"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblError" runat="server" CssClass="validation" Text=""></asp:Label>
                                        </div>
                                        <br />
                                        <center>
                                            <asp:Button ID="btnSend" runat="server"  ValidationGroup="VGEmployeeContact"
                                                  CommandName="SEND" CommandArgument='<%# Bind("User.Userid") %>'  CssClass="button width260 height35" Text="SEND"  />
                                              <asp:Button ID="btnCancel" runat="server" 
                                                  CommandName="SENDCANCEL" CommandArgument='<%# Bind("User.Userid") %>' CssClass="button width260 height35" Text="Cancel"  />
                                    </center>
                            </asp:Panel>
                            </td>
                        </tr>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>

    <div class="row">

        <div class="col-4">
        </div>
        <div class="col-3">
        </div>

    </div>

</div>
