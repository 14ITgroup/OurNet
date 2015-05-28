using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITStudio.App_Code;

namespace ITStudio.admin
{
    public class validateCookie
    {
        public static bool isCookieValidated(string name, string token)
        {
            /*
             * 说明：cookie 中的 token 是 SHA-1(name + SHA-1(password))
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
                if (token != getHash.getSHA1(name + passwordHash))
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
}