using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_editWorks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null || Request.QueryString["id"].Length > 8 || !Filter.IsNumeric(Request.QueryString["id"]))
        {
            Response.Redirect("error.aspx");
        }
        using (var db = new ITStudioEntities())
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            if (db.works.SingleOrDefault(a => a.id == id) == null)
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
                works work = db.works.SingleOrDefault(a => a.id == id);
                txtTitle.Text = work.title;
                txtIntroduction.InnerText = work.introduction;
                txtLink.Text = work.link;
                txtTime.Text = work.time;
                ImgCurrentWorkPic.ImageUrl = "/upload/workPicture/" + work.picture;
                ddlType.SelectedValue = work.typeId.ToString();
            }
        }
    }

    /// <summary>
    /// 提交修改键
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
        string content = txtIntroduction.InnerText;
        if (content == null || content.Trim() == "")
        {
            LblStatus.Text = "请填写内容";
            LblStatus.Visible = true;
            return;
        }

        string workPicName = uploadWorkPic();
        //if (workPicName == null || workPicName.Trim() == "") // 可以不修改作品图片
        //{
        //    LblStatus.Text = "请选择作品图片";
        //    LblStatus.Visible = true;
        //    return;
        //}
        string time = txtTime.Text;
        if (time == null || time.Trim() == "")
        {
            LblStatus.Text = "请填写时间";
            LblStatus.Visible = true;
            return;
        }

        int id = Convert.ToInt32(Request.QueryString["id"]);

        //删除旧封面图片
        if (workPicName != null) //此时：已上传新封面图片，文件名未写入数据库
        {
            string oldCoverPic = "";
            using (var db = new ITStudioEntities())
            {
                works w = db.works.SingleOrDefault(a => a.id == id);
                if (w == null)
                {
                    return;
                }
                oldCoverPic = w.picture;
                string oldCoverPicPath = "/upload/workPicture/" + oldCoverPic; //相对路径
                oldCoverPicPath = Server.MapPath(oldCoverPicPath); //必须经过这一步操作才能变成有效路径
                if (System.IO.File.Exists(oldCoverPicPath))//先判断文件是否存在，再执行操作
                {
                    System.IO.File.Delete(oldCoverPicPath); //删除文件
                }
            }
        }

        // 写入数据库
        using (var db = new ITStudioEntities())
        {
            works work = db.works.SingleOrDefault(a => a.id == id);
            work.typeId = Convert.ToInt32(ddlType.SelectedValue);
            if (workPicName != null)
            {
                work.picture = workPicName; // 修改了图片的情况
                ImgCurrentWorkPic.ImageUrl = "/upload/workPicture/" + workPicName;
            }
            work.title = title;
            work.introduction = content;
            work.time = txtTime.Text;
            work.link = txtLink.Text;
            db.SaveChanges();
        }
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功');</script>");
    }

    string uploadWorkPic() //上传封面图片，返回文件名。
    {
        string picSaveName = null;
        int maxFileSize = 1048576; // 限制为1MiB以下
        if (fulPicture.HasFile)
        {
            //取得文件MIME内容类型 
            string uploadFileType = this.fulPicture.PostedFile.ContentType.ToLower();
            if (!uploadFileType.Contains("image"))    //图片的MIME类型为"image/xxx"，这里只判断是否图片。 
            {
                lblUploadMessage.Text = "只能上传图片类型文件！";
                lblUploadMessage.Visible = true;
                return null;
            }

            if (fulPicture.FileContent.Length > maxFileSize) // 限制为1MiB以下
            {
                lblUploadMessage.Text = "图片文件大小不可超过 1 MB，未修改图片";
                lblUploadMessage.Visible = true;
                return null;
            }

            string picPath = fulPicture.PostedFile.FileName;
            string picFileName = fulPicture.FileName;
            string picFileExtension = picFileName.Substring(picFileName.LastIndexOf('.')); //带.的扩展名
            string random = RandomStatic.ProduceIntRandom(0, 999999).ToString("D6"); //6位随机数
            picSaveName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + random + picFileExtension; //当前时间

            //取得文件在服务器上保存的位置C:\Inetpub\wwwroot\WebSite1\images\20022775_m.jpg 
            string serverpath = Server.MapPath("/upload/workPicture/") + picSaveName;
            try
            {
                fulPicture.PostedFile.SaveAs(serverpath);//将上传的文件另存为 
                lblUploadMessage.Text = "上传成功";
                lblUploadMessage.Visible = true;
                return picSaveName;
            }
            catch (Exception error)
            {
                lblUploadMessage.Text = "上传失败，原因为： " + error.ToString();
                lblUploadMessage.Visible = true;
                return null;
            }
        }
        else
        {
            lblUploadMessage.Text = "请选择文件";
            return null;
        }
    }
}