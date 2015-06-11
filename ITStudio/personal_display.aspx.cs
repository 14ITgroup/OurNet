﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class personal_display : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ID = Convert.ToInt32(Request.QueryString["id"]);
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
            RptMenber.DataSource = dataSource.ToList();
            RptMenber.DataBind();

            var dataSource1 = from u in db.outWorks
                              where (u.id == ID)
                              select new
                              {
                                  u.picture,
                                  u.introduction,
                                  u.title,
                                  u.time,
                              };
            RptMenber.DataSource = dataSource1.ToList();
            RptMenber.DataBind();
        }
    }
}