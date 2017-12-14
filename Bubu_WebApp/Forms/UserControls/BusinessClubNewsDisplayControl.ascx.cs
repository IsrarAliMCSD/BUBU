using AppController;
using DAOClassLib.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubu_WebApp.Forms.UserControls
{
    public partial class BusinessClubNewsDisplayControl : System.Web.UI.UserControl
    {
        public AppManager appmanager;
        public string returnMessage = "";
        public List<BusienssClubNewsInfo> busienssClubNewsInfos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    FormLoad();
            }

        }
        private void FormLoad()
        {
            FillBusinessClubNews();
        }
        public void FillBusinessClubNews()
        {
            appmanager = new AppManager();
            busienssClubNewsInfos= appmanager.GetBusinessClubNewsInfo();
            gvNews.DataSource = busienssClubNewsInfos;
            gvNews.DataBind();
 
        }
        public string GetImage(object img, object format)
        {
            if (img == null)
            {
                return "";
            }
            if (!MisOp.GetImageTypeList().Contains(format.ToString().ToUpper()))
            {
                return MisOp.GetImageURL(format.ToString().ToUpper());
            }
            else
            {
                return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
            }


        }
    }
}