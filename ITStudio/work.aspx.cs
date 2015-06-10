using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["pageNum"]=1;
        int currentPage = Convert.ToInt16(Session["pageNum"]);
        //ArticlesBind(currentPage);
        using (var db = new ITStudioEntities())
        {
            PagedDataSource pd = new PagedDataSource();
            pd.DataSource = (from items in db.works
                            orderby items.id descending
                            select items).ToList();
            pd.AllowPaging = true;
            if (pd.DataSourceCount > AspNetPager.PageSize)
            {
                this.AspNetPager.AlwaysShow = true;
            }
            this.AspNetPager.RecordCount = pd.DataSourceCount;
            pd.PageSize = this.AspNetPager.PageSize;
            pd.CurrentPageIndex = 1;
            rptWorks.DataSource = pd;
            rptWorks.DataBind();
        }
    }
    void ArticlesBind(int CurrentPage) //文章绑定
    {
        using (var db = new ITStudioEntities())
        {
            var dataSource = from items in db.works
                             orderby items.id descending
                             select items;
            int totalAmount = dataSource.Count();
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = (from items in db.works
                              orderby items.id descending
                             select items).ToList();
            pds.AllowPaging = true; //开启分页
            pds.PageSize = 6;   //设置每页的行数
            pds.CurrentPageIndex = CurrentPage - 1; //设置当前页数
            rptWorks.DataSource = pds;
            rptWorks.DataBind();
        }
    }
    protected void rptWorks_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName=="imgWork")
        {
            using (var db = new ITStudioEntities())
            {
                int id =Convert.ToInt32(e.CommandArgument);
                works work = db.works.SingleOrDefault(a => a.id == id);
                string site = work.link;
                System.Diagnostics.Process.Start(site);
            }
        }
    }
    protected void AspNetPager_PageChanged(object sender, EventArgs e)
    {
        using (var db = new ITStudioEntities())
        {
            PagedDataSource pd = new PagedDataSource();
            pd.DataSource = (from items in db.works
                             orderby items.id descending
                             select items).ToList();
            pd.AllowPaging = true;
            if (pd.DataSourceCount > AspNetPager.PageSize)
            {
                this.AspNetPager.AlwaysShow = true;
            }
            this.AspNetPager.RecordCount = pd.DataSourceCount;
            pd.PageSize = this.AspNetPager.PageSize;
            pd.CurrentPageIndex = this.AspNetPager.CurrentPageIndex - 1;
            rptWorks.DataSource = pd;
            rptWorks.DataBind();
        }
    }


}