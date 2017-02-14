using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RongCloudNetCore.Util
{
    static class RongHttpClient
    {
        /// <summary>
        /// 发送Get请求
        /// </summary>
        public static async Task<string> ExecuteGet(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            return await ReturnResult(request);
        }

        public static async Task<string> ExcutePost(string appkey, string appSecret, string methodUrl, string postStr, string contentType)
        {
            Random rd = new Random();
            string nonce = rd.Next().ToString();
            string timestamp = ConvertDateTimeInt(DateTime.Now).ToString();
            string signature = GetHash(appSecret + nonce + timestamp);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(methodUrl);
            request.Method = "POST";
            if (string.IsNullOrEmpty(contentType))
                request.ContentType = "application/x-www-form-urlencoded";
            else
                request.ContentType = contentType;

            request.Headers["App-Key"] = appkey;
            request.Headers["Nonce"] = nonce;
            request.Headers["Timestamp"] = timestamp;
            request.Headers["Signature"] = signature;

            byte[] data = Encoding.UTF8.GetBytes(postStr);
            Stream newStream = await request.GetRequestStreamAsync();
            newStream.Write(data, 0, data.Length);

            return await ReturnResult(request);
        }

        public static int ConvertDateTimeInt(DateTime time)
        {
            TimeSpan ts = time - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds);
        }

        public static string GetHash(string input)
        {
            var sha1 = SHA1.Create();
            UTF8Encoding enc = new UTF8Encoding();
            byte[] dataToHash = enc.GetBytes(input);
            var dataHashed = sha1.ComputeHash(dataToHash);

            string hash = BitConverter.ToString(dataHashed).Replace("-", "");
            return hash;
        }

        public static async Task<string> ReturnResult(HttpWebRequest request)
        {
            HttpWebResponse response = null;
            string content;
            try
            {
                response = (HttpWebResponse)await request.GetResponseAsync();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                content = sr.ReadToEnd();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
                using (Stream errData = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(errData))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }
            return content;
        }
    }
}
