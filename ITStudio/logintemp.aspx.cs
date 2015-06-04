using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logintemp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ua = HttpContext.Current.Request.UserAgent;
        if (ua == null)
        {
            ua = String.Empty;
        }

        // 如果用户通过代理服务器访问，获取到的将是代理服务器的ip。此ip不可随意伪造。
        string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        if (ip == null) //我想一般不会有这种情况。
        {
            ip = String.Empty;
        }

        LblIP.Text = ip;
        LblUA.Text = ua;

        LblRequestFilePath.Text = Request.FilePath;
    }
}