using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OA.Common
{
    #region 加密方法
    public class EncodeHelper
    {
        /// <summary>
        /// RSA加密解密秘钥键值
        /// </summary>
        public static readonly string KeyContainerName = "Olive";

        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="password">传入需要加密的字符串</param>
        /// <returns></returns>
        public static string MD5(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //将要加密的字符串转换为字节数组
            byte[] palindata = Encoding.Default.GetBytes(password);
            //将字符串加密后也转换为字符数组
            byte[] encryptdata = md5.ComputeHash(palindata);
            //将加密后的字节数组转换为加密字符串
            return Convert.ToBase64String(encryptdata);
        }
        #endregion

        #region 公钥加密算法（多用于数据加密和数字签名）
        /// <summary>
        /// 公钥加密算法（多用于数据加密和数字签名）
        /// </summary>
        /// <param name="password">需要加密的字符</param>
        /// <returns></returns>
        public static string EncodeRSA(string password)
        {
            var param = new CspParameters();
            //密匙容器的名称，保持加密解密一致才能解密成功
            param.KeyContainerName = KeyContainerName;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                //将要加密的字符串转换为字节数组
                byte[] plaindata = Encoding.Default.GetBytes(password);
                //将加密后的字节数据转换为新的加密字节数组
                byte[] encryptdata = rsa.Encrypt(plaindata, false);
                //将加密后的字节数组转换为字符串
                return Convert.ToBase64String(encryptdata);
            }
        }
        #endregion

        #region DES加密方式（使用一个 56 位的密钥以及附加的 8 位奇偶校验位，产生最大 64 位的分组大小，迭代的分组密码，使用称为 Feistel 的技术）
        /// <summary>
        /// DES加密方式（使用一个 56 位的密钥以及附加的 8 位奇偶校验位，产生最大 64 位的分组大小，迭代的分组密码，使用称为 Feistel 的技术）
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncodeDES(string password)
        {
            DESCryptoServiceProvider DesCSP = new DESCryptoServiceProvider();
            //先创建 一个内存流
            MemoryStream ms = new MemoryStream();
            //将内存流连接到加密转换流
            CryptoStream cryStream = new CryptoStream(ms, DesCSP.CreateEncryptor(), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cryStream);
            //将要加密的字符串写入加密转换流
            sw.WriteLine(password);
            sw.Close();
            cryStream.Close();
            //将加密后的流转换为字节数组
            byte[] buffer = ms.ToArray();
            //将加密后的字节数组转换为字符串
            return Convert.ToBase64String(buffer);
        }
        #endregion
    }
    #endregion

    #region 解密方法
    public class DecodeHelper
    {
        /// <summary>
        /// RSA加密解密秘钥键值
        /// </summary>
        public static readonly string KeyContainerName = "Olive";

        #region 公钥解密算法
        /// <summary>
        /// 公钥解密算法
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string DecodeRSA(string password)
        {
            var param = new CspParameters();
            //密匙容器的名称，保持加密解密一致才能解密成功
            param.KeyContainerName = KeyContainerName;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                //将要解密的字符串转换为字节数组
                byte[] encryptdata = Convert.FromBase64String(password);
                //将转化的字节数据转换为的解密字节数组
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                //将解密后的字节数组转换为字符串
                return Encoding.Default.GetString(decryptdata);
            }
        }
        #endregion

        #region ESD解密
        /// <summary>
        /// ESD解密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string DecodeESD(string password)
        {
            string decodeVal = "";
            byte[] buffer = Convert.FromBase64String(password);
            DESCryptoServiceProvider DesCSP = new DESCryptoServiceProvider();
            //将加密后的字节数据加入内存流中
            MemoryStream ms = new MemoryStream(buffer);
            //内存流连接到解密流中
            CryptoStream cryStream = new CryptoStream(ms, DesCSP.CreateDecryptor(), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cryStream);
            //将解密流读取为字符串
            decodeVal = sr.ReadLine();
            sr.Close();
            cryStream.Close();
            ms.Close();
            return decodeVal;
        }
        #endregion
    }
    #endregion
}
