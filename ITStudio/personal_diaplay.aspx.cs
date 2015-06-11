using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class personal_diaplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ID = Convert.ToInt32(Request.QueryString["id"]);
        using (var db = new ITStudioEntities())
        {
            var dataSource = from u in db.members
                             where (u.id == 1)
                             select new
                             {
                                 u.name,
                                 u.introduction,
                                 u.photo,
                                 u.grade,
                             };
            RptMenber.DataSource = dataSource.ToList();
            RptMenber.DataBind();
        }
        using (var db = new ITStudioEntities())
        {

        }
    }
}