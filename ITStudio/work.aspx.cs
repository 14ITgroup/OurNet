using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    int pageSize = 6; //页面项目数

    protected void Page_Load(object sender, EventArgs e)
    {
        int currentPage = getPageNum();
        int typeId = getWorkTypeId();
        worksBind(currentPage, pageSize, typeId);
        pageNumsBind();

        using (var db = new ITStudioEntities())
        {
            var dataSource = from u in db.works
                             select new
                             {
                                 u.time,
                                 u.id,
                                 u.title,
                                 u.introduction,
                                 u.picture,
                             };
            RptWorkOnMobile.DataSource = dataSource.ToList();
            RptWorkOnMobile.DataBind();
        }
    }

    
    /// <summary>
    /// 绑定作品，可指定作品类型（默认为0表示没有所有类型）
    /// </summary>
    /// <param name="CurrentPage">页码</param>
    /// <param name="pageSize">页面项目数</param>
    /// <param name="typeId">作品类型</param>
    void worksBind(int CurrentPage,int pageSize, int typeId=0)
    {
        using (var db = new ITStudioEntities())
        {
            var dataSource = from items in db.works
                             orderby items.time descending
                             where(typeId != 0? (items.typeId == typeId):(1==1)) //判断是否有类型限制
                             select new
                             {
                                 items.id,
                                 items.typeId,
                                 items.title,
                                 items.time,
                                 items.picture,
                                 items.link,
                                 items.introduction
                             };
            dataSource = dataSource.Skip(pageSize * (CurrentPage - 1)).Take(pageSize); // 分页
            //if (dataSource.Count() == 0)
            //{
            //    Response.Redirect("error.html");
            //}
            rptWorks.DataSource = dataSource.ToList();
            rptWorks.DataBind();
        }
    }

    void pageNumsBind()
    {
        List<string> pages = new List<string>();
        int offset = 2; //从当前页码向前后各扩展页数
        int pageCount = getPageCount(pageSize, getWorkTypeId());
        int currentPage = getPageNum();
        for (int index = -offset; index <= offset; index++) //最多从 current - offset 开始，current + Offset 结束
        {
            if ((1 < currentPage + index) && (currentPage + index) < pageCount) //不包含首页和尾页
            {
                pages.Add((currentPage + index).ToString());
            }
        }
        RptPageNums.DataSource = pages;
        RptPageNums.DataBind();

        
        int workTypeId = getWorkTypeId();
        //最后一页
        if (pageCount > 1)
        {
            HlLastPage.NavigateUrl = "work.aspx?page=" + pageCount.ToString() + "&type=" + workTypeId.ToString();
            HlLastPage.Text = pageCount.ToString();
        }
        else
        {
            LiLastPage.Visible = false; //如果只有1页，尾页不显示（去重）
        }

        //前一页
        string previousPage = "1";
        if (currentPage > 1)
        {
            previousPage = (currentPage - 1).ToString();
        }
        HlPreviousPage.NavigateUrl = "work.aspx?page=" + previousPage +"&type=" + workTypeId.ToString();

        //后一页
        string nextPage = pageCount.ToString();
        if (currentPage < pageCount)
        {
            nextPage = (currentPage + 1).ToString();
        }
        HlNextPage.NavigateUrl = "work.aspx?page=" + nextPage + "&type=" + workTypeId.ToString();

        //前后省略号的显示
        if (currentPage - offset > 2)
        {
            LiDots1.Visible = true;
        }
        if (currentPage + offset < pageCount - 1)
        {
            LiDots2.Visible = true;
        }
    }
    //protected void rptWorks_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    if(e.CommandName=="imgWork")
    //    {
    //        using (var db = new ITStudioEntities())
    //        {
    //            int id =Convert.ToInt32(e.CommandArgument);
    //            works work = db.works.SingleOrDefault(a => a.id == id);
    //            string site = work.link;
    //            System.Diagnostics.Process.Start(site);
    //        }
    //    }
    //}

    //protected void AspNetPager_PageChanged(object sender, EventArgs e)
    //{
    //    using (var db = new ITStudioEntities())
    //    {
    //        PagedDataSource pd = new PagedDataSource();
    //        pd.DataSource = (from items in db.works
    //                         orderby items.id descending
    //                         select items).ToList();
    //        pd.AllowPaging = true;
    //        if (pd.DataSourceCount > AspNetPager.PageSize)
    //        {
    //            this.AspNetPager.AlwaysShow = true;
    //        }
    //        this.AspNetPager.RecordCount = pd.DataSourceCount;
    //        pd.PageSize = this.AspNetPager.PageSize;
    //        pd.CurrentPageIndex = this.AspNetPager.CurrentPageIndex - 1;
    //        rptWorks.DataSource = pd;
    //        rptWorks.DataBind();
    //    }
    //}

    /// <summary>
    /// 获得作品的总页数
    /// </summary>
    /// <param name="pageSize">每页项目数量</param>
    /// <param name="typeId">项目类型，默认值为0表示所有类型</param>
    /// <returns>总页数</returns>
    int getPageCount(int pageSize, int typeId = 0)
    {
        int pageCount = 1;
        using (var db = new ITStudioEntities())
        {
            var dataSource = from items in db.works
                             where (typeId != 0 ? (items.typeId == typeId) : (1 == 1)) //判断是否有类型限制
                                select new { items };
            int totalAmount = dataSource.Count();
            pageCount = (int)Math.Ceiling((double)totalAmount / (double)pageSize); //总页数，向上取整
        }
        return pageCount;
    }

    //int getPageSize() //获得页面项目数目
    //{
    //    int pageSize = 6;
    //    //if (DdlPageSize.SelectedValue != null)
    //    //{
    //    //    if (Filter.IsNumeric(DdlPageSize.SelectedValue))
    //    //    {
    //    //        pageSize = Convert.ToInt32(DdlPageSize.SelectedValue);
    //    //    }
    //    //}

    //    return pageSize;
    //}

    /// <summary>
    /// 获取queryString指定的页码
    /// </summary>
    /// <returns>如果不合法或未指定或等于0，返回1。</returns>
    int getPageNum()
    {
        int pageNum = 1;
        string pageStr = Request.QueryString["page"];

        // 32位无符号二进制最大为 4294967295，共10位。int32 不能超出位数限制。
        if (pageStr != null && pageStr.Trim() != "" && pageStr.Length < 10)
        {
            if (Filter.IsNumeric(pageStr))
            {
                pageNum = Convert.ToInt32(pageStr);
                if (pageNum == 0)
                {
                    pageNum = 1;
                }
            }
        }

        return pageNum;
    }

    /// <summary>
    /// 从QueryString的 type中获取work的类型Id
    /// </summary>
    /// <returns>如果不合法或未指定，返回0（在linq查询中表示不限类型）</returns>
    int getWorkTypeId()
    {
        int workType = 0; // 联系绑定函数，0表示不限类型
        string typeStr = Request.QueryString["type"];

        // 32位无符号二进制最大为 4294967295，共10位。int32 不能超出位数限制。
        if (typeStr != null && typeStr.Trim() != "" && typeStr.Length < 10)
        {
            if (Filter.IsNumeric(typeStr))
            {
                workType = Convert.ToInt32(typeStr);
            }
        }

        return workType;
    }

    //bool isPageNumInRange(int pageNum, int pageSize) //判断给定页码在有效范围内
    //{
    //    int pageCount = getPageCount(pageSize);
    //    if (pageCount <= 0) // ==0 ，会出现在没有文章/视频的情况。但是这时候第一页有效。
    //    {
    //        pageCount = 1;
    //    }
    //    if (pageNum >= 1)
    //    {
    //        if (pageNum <= pageCount)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

}