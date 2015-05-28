using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITStudio.App_Code;

namespace ITStudio.admin
{
    public partial class addArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnSubmit.Enabled = false;
                btnSubmit.Text = "请填写完整";
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            using(var db=new ITStudioEntities())
            {
                var not = new notices();
                not.time = DateTime.Now;
                not.title = txtTitle.Text;
                not.content = ueditor.Value;
                db.notices.Add(not);
                db.SaveChanges();
            }
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功');</script>");
            txtTitle.Text = "";
            ueditor.Value = "";
        }

    }
}