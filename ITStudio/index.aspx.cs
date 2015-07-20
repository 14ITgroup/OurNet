using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ITStudio_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void Application1(object sender, EventArgs e)
    {
        try
        {
            using (var db = new ITStudioEntities())
            {
                applications ap = new applications();
                ap.name = takeMaxChar(HttpUtility.HtmlEncode(TxtName.Text.Trim()));
                ap.major = takeMaxChar(HttpUtility.HtmlEncode(TxtMajor.Text.Trim()));
                ap.time = DateTime.Now;
                ap.gender = Convert.ToBoolean(DdlGender.SelectedValue);
                ap.tel = takeMaxChar(HttpUtility.HtmlEncode(TxtTel.Text.Trim())); //####ToDo:验证格式
                ap.job = takeMaxChar(HttpUtility.HtmlEncode(DdlJob.SelectedItem.Text));
                ap.introduction = HttpUtility.HtmlEncode(TxtIntroduction.Value.Trim());
                db.applications.Add(ap);
                db.SaveChanges();
            }
            Response.Write("<script>alert('恭喜您，报名成功');window.window.location.href='index.aspx';</script> ");
        }
        catch
        {
            Response.Write("<script>alert('报名失败，请重试');window.window.location.href='index.aspx';</script> ");
        }
        finally
        { 
        }
    }

    string takeMaxChar(string raw)
    {
        int maxLength = 50;
        if (raw.Length > maxLength)
        {
            raw = raw.Substring(0, maxLength);
        }
        return raw;
    }
}