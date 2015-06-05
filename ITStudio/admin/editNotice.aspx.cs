using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_editNotice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {  
        if (!Filter.IsNumeric(Request.QueryString["id"]))
        {
            Response.Redirect("error.aspx");
        }
        using(var db=new ITStudioEntities())
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            if(db.notices.SingleOrDefault(a => a.id == id)==null)
            {
                Response.Redirect("error.aspx");
            }
        }
        btnSubmit.Enabled = true;
        if (!IsPostBack)
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            using (var db = new ITStudioEntities())
            {
                notices not = db.notices.SingleOrDefault(a => a.id == id);
                txtTitle.Text = not.title;
                ueditor.Value = not.content;
            }
        }
      

    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt16(Request.QueryString["id"]);
        using (var db = new ITStudioEntities())
        {
            notices not = db.notices.SingleOrDefault(a => a.id == id);
            not.time = DateTime.Now;
            not.title = txtTitle.Text;
            not.content = ueditor.Value;
            db.SaveChanges();
        }
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
    }
}