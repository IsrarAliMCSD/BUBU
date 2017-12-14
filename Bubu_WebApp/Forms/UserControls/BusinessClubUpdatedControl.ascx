<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BusinessClubUpdatedControl.ascx.cs" Inherits="Bubu_WebApp.Forms.UserControls.BusinessClubUpdatedControl" %>
<script>
    $(function () {
        $('.myServe').on('click', function () {
            console.log('sdfsdf');
        })
    })
</script>
<div class="container">
    <div class="row">

        <div class="col-8">
            <asp:Label ID="lblError" runat="server" CssClass="validation" Text=""></asp:Label>
        </div>

        <div class="col-4 text-right">
            <br />
            <asp:Button ID="btnAddBusinessCub" CssClass="form-btn " runat="server" Text="+ Business Club" OnClick="btnAddBusinessCub_Click" />
            <br />
        </div>
    </div>
    <br />
    <asp:Repeater ID="rptrBusinessClub" runat="server" OnItemCommand="rptrBusinessClub_OnItemCommande">
        <ItemTemplate>
            <div class="row ">

               
                <div  
                     class="col-6 businessClubColor1" style="border-right: 2px solid #ccc;">
                    <asp:LinkButton ID="lbtnMonitor" runat="server"  ClientIDMode="Static" ToolTip='<%# Bind("BUSINESSCLUBID") %>'
                          OnClick="BusinessClubDetail_Click"  CssClass="store-name"></asp:LinkButton>
                    <asp:Image ID="img_Club" runat="server" ClientIDMode="Static" CssClass="widthHeight150 borderRadious"
                          
                        ImageUrl='<%# GetImage(Eval("CONTENTDATA"),Eval("FORMAT") ) %>' />
                </div>

                <div class="col-6  businessClubColor2 divCenter store-box">
                      <asp:LinkButton ID="LinkButton1" runat="server"  ClientIDMode="Static" ToolTip='<%# Bind("BUSINESSCLUBID") %>'
                          OnClick="BusinessClubDetail_Click"  CssClass="store-name"></asp:LinkButton>
                    <asp:Label ID="lblCOMPANYNAME" runat="server" CssClass="boldText" style="z-index:-1" Text='<%# Eval("BUSINESSCLUBNAME")%>'></asp:Label>

                    <asp:LinkButton ID="IbtnJoin" runat="server" CausesValidation="false"  
                        CommandArgument='<%# Bind("BUSINESSCLUBID") %>' CommandName="GRIDJOIN" OnClientClick="return confirm('Do you want to Join the Club?');"
                        Visible='<%# Convert.ToBoolean(Eval("ISACTIVE"))== true? true:false %>' ToolTip="Join Club" CssClass="btn btn-primary join-now " >Join Now</asp:LinkButton>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                    <br />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>

