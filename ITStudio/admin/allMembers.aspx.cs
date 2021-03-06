﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int currentPage = 1;
            int pageSize = getPageSize();
            Session["pagenum"] = 1;
            ArticlesBind(currentPage, pageSize);
        }
    }
    protected void RptArticles_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete") //删除人员
        {
            string IDStr = e.CommandArgument.ToString().Trim();

            int id = Convert.ToInt32(IDStr);
            using (var db = new ITStudioEntities())
            {
                members mem = db.members.SingleOrDefault(a => a.id == id);
                //删除封面图片
                string photoPath = mem.others;//相对路径
                if (photoPath != null)
                {
                    photoPath = Server.MapPath(photoPath); //必须经过这一步操作才能变成有效路径
                    if (System.IO.File.Exists(photoPath))//先判断文件是否存在，再执行操作
                    {
                        System.IO.File.Delete(photoPath); //删除文件
                    }
                }
                db.members.Remove(mem);
                db.SaveChanges();
            }
            ArticlesBind(getPageNum(), getPageSize());
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('人员删除成功');</script>");
        }
    }
    void ArticlesBind(int CurrentPage, int PageSize) //文章绑定
    {
        using (var db = new ITStudioEntities())
        {
            var dataSource = from items in db.members
                             orderby items.id descending
                             select new { items.id, items.name, items.grade,items.direction };
            int totalAmount = dataSource.Count();
            Session["pageCount"] = Math.Ceiling((double)totalAmount / (double)PageSize); //总页数，向上取整
            dataSource = dataSource.Skip(PageSize * (CurrentPage - 1)).Take(PageSize); //分页
            RptArticles.DataSource = dataSource.ToList();
            RptArticles.DataBind();
            LtlArticlesCount.Text = totalAmount.ToString();
        }
    }

    protected void DdlPageSize_SelectedIndexChanged(object sender, EventArgs e) // pageSize下拉列表改变
    {
        ArticlesBind(1, getPageSize()); //从第一页绑定，防止单页项目数量变多，导致页码超出范围。
        TxtPageNum.Text = "1";
        Session["pagenum"] = 1;
    }

    int getPageCount(int pageSize) //获得总页数
    {
        int pageCount = 1;
        if (Session["pageCount"] == null)
        {
            using (var db = new ITStudioEntities())
            {
                var dataSource = from items in db.members
                                 orderby items.id
                                 select new { items };
                int totalAmount = dataSource.Count();
                pageCount = (int)Math.Ceiling((double)totalAmount / (double)pageSize); //总页数，向上取整
            }
            Session["pageCount"] = pageCount;
        }
        else
        {
            pageCount = Convert.ToInt32(Session["pageCount"]);
        }
        return pageCount;
    }

    int getPageSize() //获得页面项目数目
    {
        int pageSize = 10;
        if (DdlPageSize.SelectedValue != null)
        {
            pageSize = Convert.ToInt32(DdlPageSize.SelectedValue);
        }

        return pageSize;
    }

    int getPageNum() //获得当前文本框中的合法数字页码
    {
        int pageNum = Convert.ToInt16(Session["pagenum"]);
        return pageNum;
    }

    protected void BtnPreviousPage_Click(object sender, EventArgs e)
    {
        int pageNum = Convert.ToInt16(Session["pagenum"]) - 1;
        int pageSize = getPageSize();
        if (pageNum < 1)
        {
            pageNum = 1;
            return;
        }
        Session["pagenum"] = pageNum;
        ArticlesBind(pageNum, pageSize);
        TxtPageNum.Text = pageNum.ToString();
    }

    protected void BtnNextPage_Click(object sender, EventArgs e)
    {
        int pageNum = Convert.ToInt16(Session["pagenum"]) + 1;
        int pageSize = getPageSize();
        if (pageNum >= getPageCount(pageSize))
        {
            pageNum = getPageCount(pageSize);
        }
        Session["pagenum"] = pageNum;
        ArticlesBind(pageNum, pageSize);
        TxtPageNum.Text = pageNum.ToString();
    }

    protected void BtnHomePage_Click(object sender, EventArgs e)
    {
        ArticlesBind(1, getPageSize());
        TxtPageNum.Text = "1";
        Session["pagenum"] = 1;
    }

    protected void BtnTrailerPage_Click(object sender, EventArgs e)
    {
        int pageSize = getPageSize();
        int pageNum = getPageCount(pageSize);
        if (pageNum <= 0) //没有内容的情况
        {
            pageNum = 1;
        }
        Session["pagenum"] = pageNum;
        ArticlesBind(pageNum, pageSize);
        TxtPageNum.Text = pageNum.ToString();
    }

    protected void BtnJumpPage_Click(object sender, EventArgs e)
    {
        int pageNum = getPageNum();
        int pageSize = getPageSize();
        if (pageNum < 1)
        {
            pageNum = 1;
        }
        else if (pageNum > pageSize)
        {
            pageNum = getPageCount(pageSize);
        }
        ArticlesBind(pageNum, pageSize);
        TxtPageNum.Text = pageNum.ToString();
    }
}