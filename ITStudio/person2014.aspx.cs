using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class person2014 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var db = new ITStudioEntities())
        {
            var search = from it in db.members
                         where it.grade == 2014
                         orderby it.id
                         select it;
            RptMember11.DataSource = search.Take(4).ToList();
            RptMember11.DataBind();
            RptMember12.DataSource = search.Skip(4).Take(4).ToList();
            RptMember12.DataBind();
            RptMember2.DataSource = search.ToList();
            RptMember2.DataBind();
        }
    }
}