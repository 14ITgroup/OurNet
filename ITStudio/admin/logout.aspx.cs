using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.FindControl("PnlLogout").Visible = false;

        Session.Abandon();

        if (Request.Cookies["admin"] != null)
        {
            //检索所有Cookie，创建新Cookie，但Expires（有效期）为昨天，已过期。从而删除Cookie。
            HttpCookie deleteCookie;
            string cookieName;
            int limit = Request.Cookies.Count;

            if (limit > 0)//若有Cookie
            {
                for (int i = 0; i < limit; i++)
                {
                    cookieName = Request.Cookies[i].Name;
                    deleteCookie = new HttpCookie(cookieName);
                    deleteCookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(deleteCookie);
                }
                LblStatus.Text = "您已成功注销。为保护信息安全，请关闭所有网页浏览器的窗口。";
                LblLoginTxt.Text = "重新登录";
            }
        }
        else
        {
            LblStatus.Text = "您未登录，可以点击以下链接登录。";
            LblLoginTxt.Text = "登录";
        }
    }
}