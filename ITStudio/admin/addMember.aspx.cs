using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindYears();
            btnSubmit.Enabled = false;
            btnSubmit.Text = "请填写完整";
        }
    }

    /// <summary>
    /// 生成并绑定年份下拉菜单
    /// </summary>
    void bindYears()
    {
        int minYearOffset = 5; //相对今年的最小和最大偏移
        int maxYearOffset = 1;

        List<string> years = new List<string>(); 
        int thisYear = DateTime.Now.Year;
        for (int index = -minYearOffset; index <= maxYearOffset; index++)
        {
            years.Add((thisYear + index).ToString());
        }
        ddlGrade.DataSource = years;
        ddlGrade.DataBind();
        ddlGrade.SelectedValue = thisYear.ToString(); // 预选中今年年份
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        //避免js失效，后端验证
        string name = txtName.Text;
        if (txtName.Text == null || txtName.Text.Trim() == "")
        {
            LblStatus.Text = "请填写姓名";
            LblStatus.Visible = true;
            return;
        }
        string direction = txtDirection.Text;
        if (direction == null || direction == "")
        {
            LblStatus.Text = "请填写方向";
            LblStatus.Visible = true;
            return;
        }
        string content = txtIntroduction.InnerText;
        if (content == null || content.Trim() == "")
        {
            LblStatus.Text = "请填写简介";
            LblStatus.Visible = true;
            return;
        }

        string photo = uploadMemPho();
        if (photo == null || photo.Trim() == "")
        {
            LblStatus.Text = "请选择照片";
            LblStatus.Visible = true;
            return;
        }
        string ico = uploadMemIco();
        if (photo == null || photo.Trim() == "")
        {
            LblStatus.Text = "请选择头像";
            LblStatus.Visible = true;
            return;
        }
        
        //存储成员到members表
        using (var db = new ITStudioEntities())
        {
            var mem = new members();
            mem.grade = Convert.ToInt32(ddlGrade.SelectedValue);
            mem.photo = photo;
            mem.ico = ico;
            mem.name = name;
            mem.introduction = content;
            mem.direction = direction;
            mem.job = ddlDeparement.SelectedValue;
            db.members.Add(mem);
            db.SaveChanges();
        }
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功');</script>");
        txtName.Text = "";
        txtIntroduction.InnerText = "";
        ddlDeparement.SelectedValue = "程序开发";
    }
    string uploadMemPho() //上传封面图片，返回文件名。
    {
        string picSaveName = null;
        int maxFileSize = 1048576; // 限制为1MiB以下
        if (fulPhoto.HasFile)
        {
            //取得文件MIME内容类型 
            string uploadFileType = this.fulPhoto.PostedFile.ContentType.ToLower();
            if (!uploadFileType.Contains("image"))    //图片的MIME类型为"image/xxx"，这里只判断是否图片。 
            {
                lblUploadMessage.Text = "只能上传图片类型文件！";
                lblUploadMessage.Visible = true;
                return null;
            }

            if (fulPhoto.FileContent.Length > maxFileSize) // 限制为1MiB以下
            {
                lblUploadMessage.Text = "图片文件大小不可超过 1 MB";
                lblUploadMessage.Visible = true;
                return null;
            }

            string picPath = fulPhoto.PostedFile.FileName;
            string picFileName = fulPhoto.FileName;
            string picFileExtension = picFileName.Substring(picFileName.LastIndexOf('.')); //带.的扩展名
            string random = RandomStatic.ProduceIntRandom(0, 999999).ToString("D6"); //6位随机数
            picSaveName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + random + picFileExtension; //当前时间

            //取得文件在服务器上保存的位置C:\Inetpub\wwwroot\WebSite1\images\20022775_m.jpg 
            string serverpath = Server.MapPath("../upload/memberPhoto/") + picSaveName;
            try
            {
                fulPhoto.PostedFile.SaveAs(serverpath);//将上传的文件另存为 
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
    string uploadMemIco() //上传封面图片，返回文件名。
    {
        string picSaveName = null;
        int maxFileSize = 1048576; // 限制为1MiB以下
        if (fulIco.HasFile)
        {
            //取得文件MIME内容类型 
            string uploadFileType = this.fulIco.PostedFile.ContentType.ToLower();
            if (!uploadFileType.Contains("image"))    //图片的MIME类型为"image/xxx"，这里只判断是否图片。 
            {
                lblUploadMessage2.Text = "只能上传图片类型文件！";
                lblUploadMessage2.Visible = true;
                return null;
            }

            if (fulIco.FileContent.Length > maxFileSize) // 限制为1MiB以下
            {
                lblUploadMessage2.Text = "图片文件大小不可超过 1 MB";
                lblUploadMessage2.Visible = true;
                return null;
            }

            string picPath = fulIco.PostedFile.FileName;
            string picFileName = fulIco.FileName;
            string picFileExtension = picFileName.Substring(picFileName.LastIndexOf('.')); //带.的扩展名
            string random = RandomStatic.ProduceIntRandom(0, 999999).ToString("D6"); //6位随机数
            picSaveName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + random + picFileExtension; //当前时间

            //取得文件在服务器上保存的位置C:\Inetpub\wwwroot\WebSite1\images\20022775_m.jpg 
            string serverpath = Server.MapPath("../upload/memberPhoto/") + picSaveName;
            try
            {
                fulIco.PostedFile.SaveAs(serverpath);//将上传的文件另存为 
                lblUploadMessage2.Text = "上传成功";
                lblUploadMessage2.Visible = true;
                return picSaveName;
            }
            catch (Exception error)
            {
                lblUploadMessage2.Text = "上传失败，原因为： " + error.ToString();
                lblUploadMessage2.Visible = true;
                return null;
            }
        }
        else
        {
            lblUploadMessage2.Text = "请选择文件";
            return null;
        }
    }
}