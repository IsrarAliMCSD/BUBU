﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms
{
    public partial class DocumentUploadMgmt : BubuBasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("profileMgmt.aspx");
        }
    }
}