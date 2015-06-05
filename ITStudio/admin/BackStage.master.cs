using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_BackStage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.FilePath.EndsWith("login.aspx"))
        {
            validateWhenLogin();
        }
        else
        {
            validate();
        }
    }

    private void validate()
    {
        // 验证Cookie
        if (Request.Cookies["admin"] != null &&
                Request.Cookies["admin"]["name"] != null &&
                Request.Cookies["admin"]["token"] != null)
        {
            string name = Request.Cookies["admin"]["name"].ToString();
            string token = Request.Cookies["admin"]["token"].ToString();
            if (validateCookie.isCookieValidated(name, token))
            {
                LblAdminName.Text = name;
            }
            else
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
                }
                Response.Redirect("login.aspx?ReturnUrl=" + Request.FilePath);
            }
        }
        else
        {
            Response.Redirect("login.aspx?ReturnUrl="+Request.FilePath);
        }

        // ####最终完成时，此处可以尝试删除，反复测试登录时是否可以一次成功。
        // 在getCaptcha中使用Session["captcha"]=xxxx后，服务器有时不会自动response Cookie：sessionid，
        //导致下一次request的访问session为NULL
        if (Session["captcha"] == null)
        {
            Session["captcha"] = "";
        }
    }

    private void validateWhenLogin()
    {
        // 验证Cookie
        if (Request.Cookies["admin"] != null &&
                Request.Cookies["admin"]["name"] != null &&
                Request.Cookies["admin"]["token"] != null)
        {
            string name = Request.Cookies["admin"]["name"].ToString();
            string token = Request.Cookies["admin"]["token"].ToString();
            if (validateCookie.isCookieValidated(name, token))
            {
                Response.Redirect("index.aspx");
            }
        }

        // 在getCaptcha中使用Session["captcha"]=xxxx后，服务器有时不会自动response Cookie：sessionid，
        //导致下一次request的访问session为NULL
        if (Session["captcha"] == null)
        {
            Session["captcha"] = "";
        }
    }
}
