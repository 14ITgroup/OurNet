using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_addWorks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnSubmit.Enabled = false;
            btnSubmit.Text = "请填写完整";
            using (var db = new ITStudioEntities())
            {
                //作者
                ddlAuthor.DataSource = db.members.ToList();
                ddlAuthor.DataValueField = "id";
                ddlAuthor.DataTextField = "name";
                ddlAuthor.DataBind();
                ddlAuthor.Items.Insert(0, new ListItem("请选择作者", "0"));
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
        //存储作品到works表 
        //存储作品和成员关系
        using (var db = new ITStudioEntities())
        {
            var work = new works();
            work.typeId = Convert.ToInt32(ddlType.SelectedValue);
            work.picture = "/upload/workPicture/"+workPicName;
            work.title = title;
            work.introduction = content;
            work.time = txtTime.Text;
            work.link = txtLink.Text;
            db.works.Add(work);
            db.SaveChanges();
            works work2 = db.works.SingleOrDefault(a => a.picture == work.picture);
            var map = new workmap();
            map.memberId = Convert.ToInt32(ddlAuthor.SelectedValue);
            map.workId=work2.id;
            db.workmap.Add(map);
            db.SaveChanges();
        }
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功');</script>");
        txtTitle.Text = "";
        txtIntroduction.InnerText = "";
        txtLink.Text = "";
        txtTime.Text = "";
        ddlType.SelectedValue = "1";
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