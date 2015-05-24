using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITStudio.classTest
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)//增加示例
        {
            EFHelpler<admins> helper = new EFHelpler<admins>();//<>里面填写表的名称
            //BaseContext dbContext = new BaseContext();
            //新增
            List<admins> listUser = new List<admins>();//listUser为自己起的变量名
            admins admin = new admins();
            admin.name = TextBox1.Text;
            admin.password = TextBox2.Text;
            listUser.Add(admin);
            helper.add(listUser.ToArray());
            Response.Write("<script>alert('管理员添加成功!')</script>");
        }
        protected void Button2_Click(object sender, EventArgs e)//删除示例
        {
            EFHelpler<admins> helper = new EFHelpler<admins>();//<>里面填写表的名称
            var query = helper.getSearchList(item => item.id == 0);
            helper.delete(query.ToArray());
            Response.Write("<script>alert('管理员删除成功!')</script>");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            EFHelpler<admins> helper = new EFHelpler<admins>();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("name", "b");
            dic.Add("password", "b");
            helper.update(item => item.id == 0, dic);
            Response.Write("<script>alert('管理员修改成功!')</script>");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            EFHelpler<admins> helper = new EFHelpler<admins>();
            var queryMulti = helper.getSearchListByPage<int>(item => item.id == 0 || item.id == 1 || item.id == 2, order => order.id, 2, 1);//3个参数分别是lambda  每页的条数  第几页
            Repeater1.DataSource = queryMulti.ToList();
            Repeater1.DataBind();
        }
    }
}