using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 认证Cookie是否合法
/// </summary>
public class validateCookie
{
    public static bool isCookieValidated(string name, string token)
    {
        /*
         * 说明：cookie 中的 token 是 SHA-1(name + SHA-1(password) + ip + ua)
         * 数据库中，password储存为 SHA-1(password)
        */

        // #### 此处可以考虑使用封装的函数etc
        using (var db = new ITStudioEntities())
        {
            admins admin = db.admins.SingleOrDefault(a => a.name == name);
            if (admin == null)
            {
                return false;
            }
            string passwordHash = admin.password;

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

            if (token != getHash.getSHA1(name + passwordHash + ip + ua))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}