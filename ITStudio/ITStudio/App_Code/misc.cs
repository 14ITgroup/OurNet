using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ITStudio.App_Code
{
    public class Filter //简单的过滤器.判断是否纯数字,是否非法字符等。这一部分由网上搜索加上个人发挥。
    {
        public static bool IsNumeric(string testedStr) //判断string是否是纯数字（只由阿拉伯数字组成的String）
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

    public class getHash
    {
        public static string getSHA1(string str) //获取string类的大写 SHA-1 Hash
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

    public static class RandomStatic //来自互联网
    {
        //产生[0,1)的随机小数 
        public static double ProduceDblRandom()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());//使用Guid的哈希值做种子 
            return r.NextDouble();
        }
        //产生制定范围内的随机整数 
        public static int ProduceIntRandom(int minValue, int maxValue)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(minValue, maxValue + 1);
        }
    } 
}