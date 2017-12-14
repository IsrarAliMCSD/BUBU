<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentUploadControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.DocumentUploadControl" %>

<script>
    $(document).ready(function () {
        $("#fuplDocument").change(function () {
            ShowImageReadURL(this, "imgFileUpload");
        });
    });

</script>
<div>
    <asp:Label ID="lblDocumentUploadId" runat="server" Visible="false"></asp:Label>
    <div class="container">
        <div class="row">
            <div class="col-12 ">
                <asp:Label ID="lblhBasicinformation" runat="server" CssClass="mainHeading " Text="Upload Document"></asp:Label>
                <%-- <asp:Label ID="lblMode" runat="server" Text="ADD"></asp:Label>--%>
                <asp:Label ID="lblUploadDocumentId" runat="server" Text="" Visible="false"></asp:Label>
            </div>
        </div>

        <div class="row">
            <div class="col-3">
                <asp:Label ID="Label1" runat="server" Text="Document Category:"></asp:Label>
            </div>
            <div class="col-9">
                <asp:DropDownList ID="ddldocumentCategory" CssClass="ddlWidth260 ddl " runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="-1" ID="Req_ddlDocumentType" Display="Dynamic" CssClass="validation"
                    ValidationGroup="docUpload" runat="server" ControlToValidate="ddldocumentCategory"
                    ErrorMessage="Please select document type"></asp:RequiredFieldValidator>

            </div>
        </div>

        <div class="row">
            <div class="col-3">
                <asp:Label ID="Label2" runat="server" Text="Upload Document:"></asp:Label>
            </div>
            <div class="col-9">
                <asp:FileUpload ID="fuplDocument" runat="server" ClientIDMode="Static" />
                <asp:Image ID="imgFileUpload" runat="server" ClientIDMode="Static" CssClass="width100" />
            </div>
        </div>

        <div class="row">
            <div class="col-3">
                <asp:Label ID="Label3" runat="server" Text="Description:"></asp:Label>
            </div>
            <div class="col-9">
                <asp:TextBox ID="txtDescription" runat="server" CssClass="textBox" Text=""></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvdescription" runat="server" CssClass="validation"
                    ErrorMessage="Please enter description" ControlToValidate="txtDescription" ValidationGroup="docUpload" Display="Dynamic"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <asp:Label ID="lblMessage" runat="server" CssClass="validation" Text=""></asp:Label>
                <br />
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-1">
            </div>
            <div class="col-4">
                <asp:Button ID="btnSave" runat="server" CssClass="button width260 height35" Text="Save" ValidationGroup="docUpload" OnClick="btnSave_Click" />


            </div>
            <div class="col-2">
            </div>
            <div class="col-4">
                <asp:Button ID="btnCancel" runat="server" CssClass="button width260 height35" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <div class="col-1">
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="gvDocumentList" runat="server" AutoGenerateColumns="false" Width="100%" GridLines="Horizontal"
                     EmptyDataText="No document Founds." OnRowCommand="gvDocumentList_RowCommand" OnRowDataBound="gvDocumentList_RowDataBound">
                    <AlternatingRowStyle BackColor="#999966" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label1" runat="server" Text="Document Category"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDocumentType" runat="server" Text='<%# Bind("DocumentCategory.DocumentCategoryName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label3" runat="server" Text="Created Date"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCreatedDate" runat="server" Text='<%# Eval("CreatedDate", "{0:MM/dd/yy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Image ID="imgfile" runat="server" CssClass="width25 borderRadious" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnedit" runat="server" Text="Edit" CommandName="GRIDEDIT" CommandArgument='<%# Eval("UploadDocumentId")%>'></asp:LinkButton>
                                |
                                <asp:LinkButton ID="lbtnDownload" runat="server" Text="Download" CommandName="GRIDDOWNLOAD" CommandArgument='<%# Eval("UploadDocumentId")%>'></asp:LinkButton>
                                |
                                <asp:LinkButton ID="lbtnDelete" runat="server" Text="Delete" CommandName="GRIDDELETE" CommandArgument='<%# Eval("UploadDocumentId")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>

