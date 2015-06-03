using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_addNotice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSubmit.Enabled = false;
            btnSubmit.Text = "请填写完整";
        }
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        //避免js失效，后端验证
        string title = txtTitle.Text;
        if (txtTitle.Text == null || txtTitle.Text.Trim() == "")
        {
            LblStatus.Text = "请填写标题";
            LblStatus.Visible = true;
            return;
        }
        string content = ueditor.Value;
        if (content == null || content.Trim() == "")
        {
            LblStatus.Text = "请填写内容";
            LblStatus.Visible = true;
            return;
        }
        using (var db = new ITStudioEntities())
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