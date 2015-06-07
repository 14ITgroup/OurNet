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
    public void Application_Click(object sender, EventArgs e)
    {
        using (var db = new ITStudioEntities())
        {
 
                applications ap = new applications();
                ap.name = TxtName.Text;
                ap.major = TxtMajor.Text;
                ap.time = DateTime.Now;
                ap.gender = false;
                ap.job = DdlJob.SelectedValue;
                ap.introduction = TxtIntroduction.InnerText;
                db.applications.Add(ap);
                db.SaveChanges();
        }
    }
}