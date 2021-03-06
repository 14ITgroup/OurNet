﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Master.FindControl("PnlLogout").Visible = false;
    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string name = Login1.UserName;
        string passwordHash = getHash.getSHA1(Login1.Password); // 口令的 Hash
        TextBox TxtCaptcha = (TextBox)Login1.FindControl("TxtCaptcha");
        string captcha = TxtCaptcha.Text.ToLower();
        string captchaAnswer = "";
        if (Session["captcha"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            captchaAnswer = Session["captcha"].ToString();
        }
        if (captcha != captchaAnswer)
        {
            Login1.FailureText = "验证码输入错误";
            e.Authenticated = false;
            return;
        }

        // 开始验证用户名和密码
        if (!EFHelper.isAdminValidated(name, passwordHash))
        {
            e.Authenticated = false; //表示登录失败
        }
        else //登录成功
        {
            if (Request.QueryString["ReturnUrl"] != null && Request.QueryString["ReturnUrl"].Trim() != "")
            {
                Login1.DestinationPageUrl = Request.QueryString["ReturnUrl"];
            }
            e.Authenticated = true;
            sendCookie(name, passwordHash);
        }

    }

    /// <summary>
    /// 生成一个Cookie,其中的token是 sha1(name + sha1(password) + ip + ua)
    /// </summary>
    void sendCookie(string name, string passwordHash)
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

        //发送Cookie
        HttpCookie userInfo = new HttpCookie("admin");
        userInfo.Values["name"] = name;
        userInfo.Values["token"] = getHash.getSHA1(name + passwordHash + ip + ua);
        if (Login1.RememberMeSet)
        {
            userInfo.Expires = DateTime.Now.AddDays(15); // 15天记住我
        }
        Response.Cookies.Add(userInfo);
    }
}