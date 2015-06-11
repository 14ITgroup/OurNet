using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class person : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var db = new ITStudioEntities())
        {
            var he = from it in db.members where it.grade == 2010 orderby it.id select it;
            RptMember.DataSource = he.ToList();
            RptMember.DataBind();
            RptMember1.DataSource = he.Take(3).ToList();
            RptMember2.DataSource = he.Skip(3).Take(3).ToList();
            RptMember1.DataBind();
            RptMember2.DataBind();
        }
    }
}