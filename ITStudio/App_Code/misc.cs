using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// 简单的过滤器.判断是否纯数字,是否非法字符等。这一部分由网上搜索加上个人发挥。
/// </summary>
public class Filter
{
    /// <summary>
    /// 判断string是否是纯数字（只由阿拉伯数字组成的String）
    /// </summary>
    /// <param name="testedStr"></param>
    /// <returns></returns>
    public static bool IsNumeric(string testedStr)
    {
        int strLength = testedStr.Length;
        for (int index = 0; index < strLength; index++)
        {
            //网上原为Byte，不能过滤汉字（报错）。改为较大位数的类型。Unicode是16位。
            UInt16 charByte = Convert.ToUInt16(testedStr[index]);
            if (charByte < '0' || charByte > '9')  //ASCII:: ord('0')==48;ord('9')==57
            {
                return false;
            }
        }
        return true;
    }
}

/// <summary>
/// 获取字符串的Hash
/// </summary>
public class getHash
{
    /// <summary>
    /// 获取string类字符串的的十六进制大写SHA-1
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string getSHA1(string str)
    {
        if (!String.IsNullOrEmpty(str))
        {
            //建立SHA1对象
            SHA1 sha = new SHA1CryptoServiceProvider();

            //将mystr转换成byte[]
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] dataToHash = enc.GetBytes(str);

            //Hash运算
            sha.ComputeHash(dataToHash);

            //转换为 string
            string hash = BitConverter.ToString(sha.Hash).Replace("-", "");
            return hash;
        }
        else
        {
            return string.Empty;
        }
    }
}

/// <summary>
/// 产生随机数。来自互联网。
/// </summary>
public static class RandomStatic
{
    /// <summary>
    /// 产生[0,1)的随机小数
    /// </summary>
    /// <returns></returns>
    public static double ProduceDblRandom()
    {
        Random r = new Random(Guid.NewGuid().GetHashCode());//使用Guid的哈希值做种子 
        return r.NextDouble();
    }

    /// <summary>
    /// 产生制定范围内的随机整数
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <returns></returns>
    public static int ProduceIntRandom(int minValue, int maxValue)
    {
        Random r = new Random(Guid.NewGuid().GetHashCode());
        return r.Next(minValue, maxValue + 1);
    }
}

public class ITStudioHelper
{
    /// <summary>
    /// 给不为空的，没有协议名的string URL头部添加http://。
    /// </summary>
    /// <param name="raw"></param>
    /// <returns></returns>
    public static string addProtocol(string raw)
    {
        if (raw != null && raw != ""
            && !raw.StartsWith("http://", true, null)
            && !raw.StartsWith("https://", true, null)
            && !raw.StartsWith("ftp://", true, null))
        {
            raw = "http://" + raw;
        }

        return raw;
    }
}