using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Person : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using(var db = new ITStudioEntities())
        {
            var search = from it in db.members
                         where it.grade == 2010
                         orderby it.id
                         select it;
            RptMember1.DataSource = search.Take(3).ToList();
            RptMember1.DataBind();
            RptMember2.DataSource = search.Skip(3).Take(3).ToList();
            RptMember2.DataBind();
            RptMember0.DataSource = search.ToList();
            RptMember0.DataBind();
        }
    }
}