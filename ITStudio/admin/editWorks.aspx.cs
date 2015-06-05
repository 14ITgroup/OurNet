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
        if (!Filter.IsNumeric(Request.QueryString["id"]))
        {
            Response.Redirect("Default.aspx");
        }
        using (var db = new ITStudioEntities())
        {
            int id = Convert.ToInt16(Request.QueryString["id"]);
            if (db.notices.SingleOrDefault(a => a.id == id) == null)
            {
                Response.Redirect("Default.aspx");
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
                ddlType.SelectedValue = work.typeId.ToString();
            }
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
        string content = txtIntroduction.InnerText;
        if (content == null || content.Trim() == "")
        {
            LblStatus.Text = "请填写内容";
            LblStatus.Visible = true;
            return;
        }

        string workPicName = uploadWorkPic();
        if (workPicName == null || workPicName.Trim() == "")
        {
            LblStatus.Text = "请选择作品图片";
            LblStatus.Visible = true;
            return;
        }
        string time = txtTime.Text;
        if (time == null || time.Trim() == "")
        {
            LblStatus.Text = "请填写时间";
            LblStatus.Visible = true;
            return;
        }
        int id = Convert.ToInt16(Request.QueryString["id"]);
        using (var db = new ITStudioEntities())
        {
            works work = db.works.SingleOrDefault(a => a.id == id);
            work.typeId = Convert.ToInt16(ddlType.SelectedValue);
            work.picture = workPicName;
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
                lblUploadMessage.Text = "图片文件大小不可超过 1 MB";
                lblUploadMessage.Visible = true;
                return null;
            }

            string picPath = fulPicture.PostedFile.FileName;
            string picFileName = fulPicture.FileName;
            string picFileExtension = picFileName.Substring(picFileName.LastIndexOf('.')); //带.的扩展名
            string newName = Guid.NewGuid().ToString();//生成新的文件名，保证唯一性
            picSaveName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + newName + picFileExtension; //当前时间

            //取得文件在服务器上保存的位置C:\Inetpub\wwwroot\WebSite1\images\20022775_m.jpg 
            string serverpath = Server.MapPath("/Images/workPicture/") + picSaveName;
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