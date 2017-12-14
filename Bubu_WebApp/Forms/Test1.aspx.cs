using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms
{
    public partial class Test1 : BubuBasePage 
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
//                string outputHTML = string.Empty;
//                string pdfUrl = string.Empty;
//                byte[] pdfBytes = null;
//                try
//                {
//                    outputHTML = @"<html> <body><p>Israr Ali</p>
//                               </hr>
//                               <img src='~\\Images\\\Icon\\Join.png' width='100px'/>
//                               </body></html>";

//                    pdfBytes = (new NReco.PdfGenerator.HtmlToPdfConverter()).GeneratePdf(outputHTML);
//                    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
//                    response.ClearContent();
//                    response.Clear();
//                    response.AddHeader("content-length", pdfBytes.Length.ToString());
//                    response.AddHeader("Content-Disposition", "attachment; filename=abc.pdf" );
//                    response.BinaryWrite(pdfBytes);
//                    response.Flush();
//                    response.End();
//                }
//                catch (Exception ex)
//                {
//                }
            }
        }
    }
}