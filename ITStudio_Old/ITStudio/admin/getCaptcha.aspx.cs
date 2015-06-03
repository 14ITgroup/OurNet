using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITStudio.admin
{
    public partial class getCaptcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            captcha cap = new captcha();

            Session["captcha"] = cap.VerifyCodeText.ToLower();

            cap.OutputImage();
        }
    }
}