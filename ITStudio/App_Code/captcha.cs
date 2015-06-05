using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// 随机生成验证码。来自互联网，稍作修改。
/// </summary>
public class captcha
{
    #region Private Field & Public Property
    //随机种子
    private Random objRandom = new Random();

    #region 验证码长度
    //验证码长度
    private int length = 4; // 已修改

    /// <summary>
    /// 验证码长度(默认为4)
    /// </summary>
    public int Length
    {
        get { return this.length; }
        set { this.length = value; }
    }
    #endregion

    #region 验证码字符串
    //验证码字符串
    private string verifyCodeText = null;

    /// <summary>
    /// 验证码字符串
    /// </summary>
    public string VerifyCodeText
    {
        get { return this.verifyCodeText; }
        set { this.verifyCodeText = value; }
    }
    #endregion

    #region 是否加入小写字母
    //是否加入小写字母
    private bool addLowerLetter = true; // 已修改

    /// <summary>
    /// 是否加入小写字母(不包括o)
    /// </summary>
    public bool AddLowerLetter
    {
        get { return this.addLowerLetter; }
        set { this.addLowerLetter = value; }
    }
    #endregion

    #region 是否加入大写字母
    //是否加入大写字母
    private bool addUpperLetter = true; // 已修改

    /// <summary>
    /// 是否加入大写字母(不包括O)
    /// </summary>
    public bool AddUpperLetter
    {
        get { return this.addUpperLetter; }
        set { this.addUpperLetter = value; }
    }
    #endregion

    #region 字体大小
    //字体大小
    private int fontSize = 20; //已修改

    /// <summary>
    /// 字体大小(默认为18)
    /// </summary>
    public int FontSize
    {
        get { return this.fontSize; }
        set { this.fontSize = value; }
    }
    #endregion

    #region 字体颜色
    //字体颜色
    private Color fontColor = Color.Blue;

    /// <summary>
    /// 字体颜色(默认为Blue)
    /// </summary>
    public Color FontColor
    {
        get { return this.fontColor; }
        set { this.fontColor = value; }
    }
    #endregion

    #region 字体类型
    //字体类型
    private string fontFamily = "Verdana";

    /// <summary>
    /// 字体类型(默认为Verdana)
    /// </summary>
    public string FontFamily
    {
        get { return this.fontFamily; }
        set { this.fontFamily = value; }
    }
    #endregion

    #region 背景色
    //背景色
    private Color backgroundColor = Color.AliceBlue;

    /// <summary>
    /// 背景色(默认为AliceBlue)
    /// </summary>
    public Color BackgroundColor
    {
        get { return this.backgroundColor; }
        set { this.backgroundColor = value; }
    }
    #endregion

    #region 前景噪点数量
    //前景噪点数量
    private int foreNoisePointCount = 2;

    /// <summary>
    /// 前景噪点数量(默认为2)
    /// </summary>
    public int ForeNoisePointCount
    {
        get { return this.foreNoisePointCount; }
        set { this.foreNoisePointCount = value; }
    }
    #endregion

    #region 随机码的旋转角度
    //随机码的旋转角度
    private int randomAngle = 40;

    /// <summary>
    /// 随机码的旋转角度(默认为40度)
    /// </summary>
    public int RandomAngle
    {
        get { return this.randomAngle; }
        set { this.randomAngle = value; }
    }
    #endregion
    #endregion

    #region Constructor Method
    public captcha()
    {
        this.GetVerifyCodeText();
    }
    #endregion

    #region Private Method
    /// <summary>
    /// 得到验证码字符串
    /// </summary>
    private void GetVerifyCodeText()
    {
        //没有外部输入验证码时随机生成
        if (String.IsNullOrEmpty(this.verifyCodeText))
        {
            StringBuilder objStringBuilder = new StringBuilder();

            //加入数字1-9
            for (int i = 1; i <= 9; i++)
            {
                objStringBuilder.Append(i.ToString());
            }

            //加入大写字母A-Z，不包括O
            if (this.addUpperLetter)
            {
                char temp = ' ';

                for (int i = 0; i < 26; i++)
                {
                    temp = Convert.ToChar(i + 65);

                    //如果生成的字母不是'O'
                    if (!temp.Equals('O'))
                    {
                        objStringBuilder.Append(temp);
                    }
                }
            }

            //加入小写字母a-z，不包括o
            if (this.addLowerLetter)
            {
                char temp = ' ';

                for (int i = 0; i < 26; i++)
                {
                    temp = Convert.ToChar(i + 97);

                    //如果生成的字母不是'o'
                    if (!temp.Equals('o'))
                    {
                        objStringBuilder.Append(temp);
                    }
                }
            }

            //生成验证码字符串
            {
                int index = 0;

                for (int i = 0; i < length; i++)
                {
                    index = objRandom.Next(0, objStringBuilder.Length);

                    this.verifyCodeText += objStringBuilder[index];

                    objStringBuilder.Remove(index, 1);
                }
            }
        }
    }

    /// <summary>
    /// 得到验证码图片
    /// </summary>
    private Bitmap GetVerifyCodeImage()
    {
        Bitmap result = null;

        //创建绘图
        result = new Bitmap(this.verifyCodeText.Length * 16, 25);

        using (Graphics objGraphics = Graphics.FromImage(result))
        {
            objGraphics.SmoothingMode = SmoothingMode.HighQuality;

            //清除整个绘图面并以指定背景色填充
            objGraphics.Clear(this.backgroundColor);

            //创建画笔
            using (SolidBrush objSolidBrush = new SolidBrush(this.fontColor))
            {
                this.AddForeNoisePoint(result);

                this.AddBackgroundNoisePoint(result, objGraphics);

                //文字居中
                StringFormat objStringFormat = new StringFormat(StringFormatFlags.NoClip);

                objStringFormat.Alignment = StringAlignment.Center;
                objStringFormat.LineAlignment = StringAlignment.Center;

                //字体样式
                Font objFont = new Font(this.fontFamily, objRandom.Next(this.fontSize - 3, this.fontSize), FontStyle.Regular);

                //验证码旋转，防止机器识别
                char[] chars = this.verifyCodeText.ToCharArray();

                for (int i = 0; i < chars.Length; i++)
                {
                    //转动的度数
                    float angle = objRandom.Next(-this.randomAngle, this.randomAngle);

                    objGraphics.TranslateTransform(12, 12);
                    objGraphics.RotateTransform(angle);
                    objGraphics.DrawString(chars[i].ToString(), objFont, objSolidBrush, -2, 2, objStringFormat);
                    objGraphics.RotateTransform(-angle);
                    objGraphics.TranslateTransform(2, -12);
                }
            }
        }

        return result;
    }

    /// <summary>
    /// 添加前景噪点
    /// </summary>
    /// <param name="objBitmap"></param>
    private void AddForeNoisePoint(Bitmap objBitmap)
    {
        for (int i = 0; i < objBitmap.Width * this.foreNoisePointCount; i++)
        {
            objBitmap.SetPixel(objRandom.Next(objBitmap.Width), objRandom.Next(objBitmap.Height), this.fontColor);
        }
    }

    /// <summary>
    /// 添加背景噪点
    /// </summary>
    /// <param name="objBitmap"></param>
    /// <param name="objGraphics"></param>
    private void AddBackgroundNoisePoint(Bitmap objBitmap, Graphics objGraphics)
    {
        using (Pen objPen = new Pen(Color.Azure, 0))
        {
            for (int i = 0; i < objBitmap.Width * 2; i++)
            {
                objGraphics.DrawRectangle(objPen, objRandom.Next(objBitmap.Width), objRandom.Next(objBitmap.Height), 1, 1);
            }
        }

    }
    #endregion

    #region Public Method
    /// <summary>
    /// 输出验证码图片
    /// </summary>
    /// <param name="objHttpResponse">Http响应实例</param>
    /// <returns>输出是否成功</returns>
    public bool OutputImage() // 参数:HttpResponse objHttpResponse
    {
        bool result = false;

        using (Bitmap objBitmap = this.GetVerifyCodeImage())
        {
            if (objBitmap != null)
            {
                using (MemoryStream objMS = new MemoryStream())
                {
                    objBitmap.Save(objMS, ImageFormat.Jpeg);

                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ContentType = "image/Jpeg";
                    HttpContext.Current.Response.BinaryWrite(objMS.ToArray());
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();

                    result = true;
                }
            }
        }

        return result;
    }
    #endregion
}