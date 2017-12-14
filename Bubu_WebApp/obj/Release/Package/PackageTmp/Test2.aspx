<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test2.aspx.cs" Inherits="Bubu_WebApp.Test2" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <%-- <link href="Style/bubu.css" rel="stylesheet" />--%>


    <%--<script src="Framework/JQuery/jquery-ui-1.12.1/jquery-ui.js"></script>
    <link href="Framework/JQuery/jquery-ui-1.12.1/jquery-ui.css" rel="stylesheet" />
    <link href="Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/css/bootstrap.min.css" rel="stylesheet" />
    <%--<link href="Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/css/bootstrap.css" rel="stylesheet" />--%>
   <%-- <script src="Framework/JQuery/jquery-ui-1.12.1/external/jquery/jquery.js"></script>
    <script src="Framework/BootStrap/bootstrap-4.0.0-alpha.6-dist/js/bootstrap.min.js"></script>
    <script src="Framework/JS/bubu.js"></script>--%> 
    <%--<script src="../Framework/JS/Login.js"></script>--%>

    <style>
      

        a {
            text-decoration: none;
            background-color: transparent;
            color: #404040;
        }



        .topics {
            position: relative;
            z-index: 300;
            overflow: hidden;
            padding: .5rem 0 .375rem;
            background: #f5f5f5;
            box-shadow: 0 0 4px rgba(0,0,0,.08),0 2px 8px rgba(0,0,0,.05);
        }

            .topics:after {
                content: "";
                position: absolute;
                z-index: 400;
                top: 0;
                right: 0;
                width: 5.75em;
                height: 100%;
                background-image: -webkit-linear-gradient(left,rgba(245,245,245,0) 0,#f5f5f5 10%);
                background-image: linear-gradient(to right,rgba(245,245,245,0) 0,#f5f5f5 10%);
            }

            .topics h3, .sa {
                font-family: 'guardian-text-oreilly', Arial, Verdana, Helvetica, sans-serif;
                font-weight: bold;
                font-size: .8125rem;
                letter-spacing: .05em;
                float: left;
                padding-left: .625rem;
                text-transform: uppercase;
                line-height: 1;
                color: #404040;
            }

            .topics h3 {
                margin: .275rem 0 0;
                width: 11.7125rem;
            }

        .topics-list {
            white-space: nowrap;
        }

            .topics-list li {
                display: inline-block;
                background: #fff;
                margin-bottom: 10px;
                margin-right: 1.25rem;
                position: relative;
                overflow: hidden;
                z-index: 5;
            }

                .topics-list li a {
                    text-decoration: none;
                    cursor: pointer;
                    outline: 0;
                    font: 100%/1.4 'guardian-text-oreilly',open-sans,Helvetica,Arial,sans-serif;
                    font-size: .6875rem;
                    letter-spacing: .1em;
                    text-transform: uppercase;
                    font-weight: 400;
                    padding: .2875rem .5rem .4rem 1.125rem;
                    display: block;
                }

         

        .sa {
            position: absolute;
            z-index: 500;
            right: .3125rem;
            top: .5rem;
            padding: .3125rem .5rem .5rem;
        }

            .sa:hover, .sa:active, .sa:focus {
                color: #fff;
                background-color: #b9002d;
            }

        .ai-bg--before:before {
            background-color: #d3002d;
        }

        .business-bg--before:before {
            background-color: #007935;
        }

        .data-bg--before:before {
            background-color: #d3002d;
        }

        .design-bg--before:before {
            background-color: #7473a9;
        }

       

        .operations-bg--before:before {
            background-color: #008a96;
        }

        .security-bg--before:before {
            background-color: #001689;
        }

        .software-engineering-bg--before:before {
            background-color: #510c76;
        }

        .web-programming-bg--before:before {
            background-color: #00b7b7;
        }

        .economy-bg--before:before {
            background-color: #570e51;
        }

        .flag {
            display: inline-block;
            position: relative;
            text-decoration: none;
            background-color: #f5f5f5;
            font-size: .875rem;
            letter-spacing: .1em;
            text-transform: uppercase;
            font-weight: 400;
        }

            .flag a {
                position: relative;
                z-index: 5;
                -webkit-transition: color .25s cubic-bezier(.86,0,.07,1), background-color .25s cubic-bezier(.86,0,.07,1);
                -ms-transition: color .25s cubic-bezier(.86,0,.07,1), background-color .25s cubic-bezier(.86,0,.07,1);
                transition: color .25s cubic-bezier(.86,0,.07,1), background-color .25s cubic-bezier(.86,0,.07,1);
            }

            .flag:before {
                content: "";
                height: 100%;
                left: 0;
                overflow: hidden;
                position: absolute;
                top: 0;
                width: .5625rem;
                z-index: 0;
                -webkit-transition: width .25s cubic-bezier(.86,0,.07,1);
                -ms-transition: width .25s cubic-bezier(.86,0,.07,1);
                transition: width .25s cubic-bezier(.86,0,.07,1);
            }

            .flag:hover:before, .flag:active:before {
                width: 102%;
            }

            .flag:hover a, .flag:active a, .flag a:focus {
                color: #fff;
            }

        .ai-bg--before.flag a:focus {
            background-color: #d3002d;
        }

        .business-bg--before.flag a:focus {
            background-color: #007935;
        }

        .data-bg--before.flag a:focus {
            background-color: #d3002d;
        }

        .design-bg--before.flag a:focus {
            background-color: #7473a9;
        }

       

        .operations-bg--before.flag a:focus {
            background-color: #008a96;
        }

        .security-bg--before.flag a:focus {
            background-color: #001689;
        }

        .software-engineering-bg--before.flag a:focus {
            background-color: #510c76;
        }

        .web-programming-bg--before.flag a:focus {
            background-color: #00b7b7;
        }

        .economy-bg--before.flag a:focus {
            background-color: #570e51;
        }

      

         
        
       
    </style>
    <script>

        $(document).ready(function () {
            Accordian(".accordian");
            DatePicker(".calendar");
            Tab(".tab");

        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        
     <div class="topics" role="navigation" aria-label="site topics">
        <div class="scrollable">
          <h3>On Our Radar</h3>

          <ul role="menu" class="topics-list">
            <li role="menuitem" class="flag ai-bg--before">
              <a href="/topics/ai">AI</a>
            </li>
            <li role="menuitem" class="flag business-bg--before">
              <a href="/topics/business">Business</a>
            </li>
            <li role="menuitem" class="flag data-bg--before">
              <a href="/topics/data">Data</a>
            </li>
            <li role="menuitem" class="flag design-bg--before">
              <a href="/topics/design">Design</a>
            </li>
            <li role="menuitem" class="flag economy-bg--before">
              <a href="/topics/economy">Economy</a>
            </li>
            <li role="menuitem" class="flag operations-bg--before">
              <a href="/topics/operations">Operations</a>
            </li>
            <li role="menuitem" class="flag security-bg--before">
              <a href="/topics/security">Security</a>
            </li>
            <li role="menuitem" class="flag software-engineering-bg--before">
              <a href="/topics/software-architecture">Software Architecture</a>
            </li>
            <li role="menuitem" class="flag software-engineering-bg--before">
              <a href="/topics/software-engineering">Software Engineering</a>
            </li>
            <li role="menuitem" class="flag web-programming-bg--before">
              <a href="/topics/web-programming">Web Programming</a>
            </li>
          </ul>
          
        </div><!-- div.scrollable -->
        <a href="https://www.oreilly.com/topics" class="sa">See all</a>
      </div>
        </div>
    </form>
</body>
</html>
