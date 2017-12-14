<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Emp_Master.Master" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="Bubu_WebApp.Forms.Test1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $("#btn").click(function () {
                var divContents = $("#SelectorToPrint3").html();
                printDiv(divContents);
            });

            //var availableTags = [
            //  "ActionScript",
            //  "AppleScript",
            //  "Asp",
            //  "BASIC",
            //  "C",
            //  "C++",
            //  "Clojure",
            //  "COBOL",
            //  "ColdFusion",
            //  "Erlang",
            //  "Fortran",
            //  "Groovy",
            //  "Haskell",
            //  "Java",
            //  "JavaScript",
            //  "Lisp",
            //  "Perl",
            //  "PHP",
            //  "Python",
            //  "Ruby",
            //  "Scala",
            //  "Scheme"
            //];
            //$("#txtUserName").autocomplete({
            //    source: availableTags
            //});

        });
        function printDiv(divContents)
        {
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(divContents);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.print();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type='button' id='btn' value='Print'>
    <div id="SelectorToPrint">
        <br />
        Israr
        <br />
        Rehan
        <br />
        Ahmed
        <br />
    </div>
    <div id="SelectorToPrint2">
        <br />
        Israr2
        <br />
        Rehan2
        <br />
        Ahmed2
        <br />
    </div>
    <div id='printarea'>
        <p>This is a sample text for printing purpose.</p>

    </div>
    <p>Do not print.</p>
    <div id="SelectorToPrint3">
        <div style="background-color: lightpink;">
            <p>This is a sample text for printing purpose.</p>
            <br />
            Israr3
        <br />
            <p>This is a sample text for printing purpose.</p>
            <br />
            Rehan3
        <br />
            <p>This is a sample text for printing purpose.</p>
            <br />
            Ahmed3
        <br />
        </div>
    </div>
    <div id="SelectorToPrint4">
        <br />
        Israr4
        <br />
        Rehan4
        <br />
        Ahmed4
        <br />
    </div>
    <div id="SelectorToPrint5">
        <br />
        Israr5
        <br />
        Rehan5
        <br />
        Ahmed5
        <br />
    </div>


    <%-- <asp:TextBox ID="txtUserName" runat="server" ClientIDMode="Static"></asp:TextBox>--%>
</asp:Content>
