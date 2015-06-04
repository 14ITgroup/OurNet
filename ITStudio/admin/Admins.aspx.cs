using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Admins : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        adminsBind();
    }
    protected void RptAdmins_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void Btn_change_Click(object sender, EventArgs e)
    {

    }
    protected void add_Click(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 绑定管理员列表
    /// </summary>
    void adminsBind()
    {
        using (var db = new ITStudioEntities())
        {
            var dataSource = from a in db.admins
                             orderby a.id
                             select new { a.id, a.name };
            RptAdmins.DataSource = dataSource.ToList();
            RptAdmins.DataBind();
        }
    }
}