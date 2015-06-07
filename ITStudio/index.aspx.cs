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
        using (var db = new ITStudioEntities())
        {
 
                applications ap = new applications();
                ap.name = TxtName.Text.Trim();
                ap.major = TxtMajor.Text.Trim();
                ap.time = DateTime.Now;
                ap.gender = false;
                ap.job = DdlJob.SelectedItem.Text;
                ap.introduction = TxtIntroduction.Value.Trim();
                db.applications.Add(ap);
                db.SaveChanges();
        }
    }
}