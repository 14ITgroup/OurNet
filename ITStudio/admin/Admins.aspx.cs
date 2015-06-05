using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// 管理员名称长度：16位以内
/// 管理员密码长度：6-16位
/// </summary>
public partial class admin_Admins : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            adminsBind();
            TblChangePassword.Visible = false;
        }
    }

    /// <summary>
    /// Admin 列表操作项目
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void RptAdmins_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //删除操作
        if (e.CommandName == "delete_admin")
        {
            int ID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
            using (var db = new ITStudioEntities())
            {
                admins c1 = db.admins.SingleOrDefault(a => a.id == ID);
                db.admins.Remove(c1);
                db.SaveChanges();
                adminsBind();
                Response.Write("<script>alert('管理员删除成功!')</script>");
            }
        }
        else //修改操作
        {
            TblChangePassword.Visible = true;
            BtnChange.Visible = true;
            int ID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
            TxtIdToChange.Text = ID.ToString();
        }
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

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnChange_Click(object sender, EventArgs e)
    {
        int ID = 0;
        if (TxtIdToChange.Text != null && TxtIdToChange.Text.Trim() != "" && Filter.IsNumeric(TxtIdToChange.Text))
        {
            ID = Convert.ToInt32(TxtIdToChange.Text.Trim());
        }
        else
        {
            return;
        }

        string oldPassword = TxtOldPassword.Text;
        string newPassword = TxtNewPassword.Text;
        if (newPassword.Length < 6 || newPassword.Length > 16)
        {
            Response.Write("<script>alert('密码位数应在6到16位')</script>");
            return;
        }
        string oldPasswordHash = getHash.getSHA1(oldPassword);
        string newPasswordHash = getHash.getSHA1(newPassword);
        using (var db = new ITStudioEntities())
        {
            admins c2 = db.admins.SingleOrDefault(c => c.id == ID);
            if (c2 == null)
            {
                return;
            }
            if (newPassword != "" && oldPassword != "")
            {
                if (c2.password.ToString() == oldPasswordHash)
                {
                    c2.password = newPasswordHash;
                    db.SaveChanges();
                    adminsBind();
                    Response.Write("<script>alert('密码修改成功！')</script>");
                    TblChangePassword.Visible = false;
                    BtnChange.Visible = false;
                }
                else
                    Response.Write("<script>alert('原密码错误！')</script>");
            }
            else
                Response.Write("<script>alert('请完整输入！')</script>");
        }
    }

    /// <summary>
    /// 增加管理员
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnAddAdmin_Click(object sender, EventArgs e)
    {
        if (TxtNewAdminName.Text == "" || TxtNewAdminPassword.Text == "" || TxtNewAdminPasswordAgain.Text == "")
        {
            Response.Write("<script>alert('管理员名和密码不能为空！')</script>");
            return;
        }
        string newName = TxtNewAdminName.Text;
        if (newName.Length > 16)
        {
            Response.Write("<script>alert('新管理员登录名长度应小于16位')</script>");
            return;
        }
        if (TxtNewAdminPassword.Text != TxtNewAdminPasswordAgain.Text)
        {
            Response.Write("<script>alert('两次密码不一致！')</script>");
            return;
        }
        else if (TxtNewAdminPassword.Text.Length < 6 || TxtNewAdminPassword.Text.Length > 16)
        {
            Response.Write("<script>alert('密码位数应在6到16位！')</script>");
            return;
        }

        using (var db = new ITStudioEntities()) //检验是否已存在此登录名
        {
            admins admin = db.admins.SingleOrDefault(a => a.name == newName);
            if (admin != null)
            {
                Response.Write("<script>alert('此管理员已存在!')</script>");
                return;
            }
        }

        string sha = getHash.getSHA1(TxtNewAdminPassword.Text);
        using (var db = new ITStudioEntities())
        {
            var a = new admins();
            a.name = TxtNewAdminName.Text;
            a.password = sha;
            db.admins.Add(a);
            db.SaveChanges();
        }

        adminsBind();
        TxtNewAdminName.Text = "";
        Response.Write("<script>alert('管理员添加成功!')</script>");
    }
}