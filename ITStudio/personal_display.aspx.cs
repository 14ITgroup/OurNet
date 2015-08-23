using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class personal_display : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if((Request.QueryString == null) ||
            (!Filter.IsNumeric(Request.QueryString["id"])) || 
            (Request.QueryString["id"].Length > 9))
        {
            Response.Write("<script>alert(\x22请勿乱搞！\x22);</script>");
            return;
        }
        int ID = Convert.ToInt32(Request.QueryString["id"]); // member id
        
        using (var db = new ITStudioEntities())
        {
            var dataSource = from u in db.members
                             where (u.id == ID)
                             select new
                             {
                                 u.name,
                                 u.introduction,
                                 u.photo,
                                 u.grade,
                                 u.direction,
                             };

            if (dataSource.Count() == 0)
            {
                Response.Write("<script>alert(\x22不存在该成员\x22);</script>");
                return;
            }

            RptMenber.DataSource = dataSource.ToList();
            RptMenber.DataBind();
            RptMember2.DataSource = dataSource.ToList();
            RptMember2.DataBind();

            var dataSource1 = from u in db.outWorks
                              where (u.memberId == ID)
                              orderby u.time descending
                              select new
                              {
                                  u.picture,
                                  u.introduction,
                                  u.title,
                                  u.time,
                              };
            RptWorks.DataSource = dataSource1.Take(3).ToList();
            RptWorks.DataBind();
            RptWorks2.DataSource = dataSource1.Take(2).ToList();
            RptWorks3.DataSource = dataSource1.Skip(2).Take(2).ToList();
        }
    }
}