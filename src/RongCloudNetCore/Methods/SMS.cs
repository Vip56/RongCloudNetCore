using Newtonsoft.Json;
using RongCloudNetCore.Models;
using RongCloudNetCore.Util;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RongCloudNetCore.Methods
{
    public class SMS
    {
        private string appKey;
        private string appSecret;

        public SMS(string appKey, string appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }

        /// <summary>
        /// 获取图片验证码
        /// </summary>
        /// <param name="appKey">应用Id</param>
        public async Task<SMSImageCodeReslut> GetImageCode(string appKey)
        {
            if (string.IsNullOrEmpty(appKey))
                throw new ArgumentNullException(nameof(appKey));

            String postStr = "";
            postStr = RongCloud.RONGCLOUDSMSURI + "/getImgCode.json";
            postStr = postStr + ("?appKey=") + WebUtility.UrlEncode(appKey == null ? "" : appKey);

            return JsonConvert.DeserializeObject<SMSImageCodeReslut>(await RongHttpClient.ExecuteGet(postStr));
        }

        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <param name="mobile">接收短信验证码的目标手机号，每分钟同一手机号只能发送一次短信验证码，同一手机号 1 小时内最多发送 3 次。（必传）</param>
        /// <param name="templateId">短信模板 Id，在开发者后台->短信服务->服务设置->短信模版中获取。（必传）</param>
        /// <param name="region">手机号码所属国家区号，目前只支持中图区号 86）</param>
        /// <param name="verifyId">图片验证标识 Id ，开启图片验证功能后此参数必传，否则可以不传。在获取图片验证码方法返回值中获取。</param>
        /// <param name="verifyCode">图片验证码，开启图片验证功能后此参数必传，否则可以不传。</param>
        public async Task<SMSSendCodeReslut> SendCode(string mobile, string templateId, string region, string verifyId, string verifyCode)
        {
            if (string.IsNullOrEmpty(mobile))
                throw new ArgumentNullException(nameof(mobile));
            if (string.IsNullOrEmpty(templateId))
                throw new ArgumentNullException(nameof(templateId));
            if (string.IsNullOrEmpty(region))
                throw new ArgumentNullException(nameof(region));

            string postStr = "";
            postStr += "mobile=" + WebUtility.UrlEncode(mobile == null ? "" : mobile) + "&";
            postStr += "templateId=" + WebUtility.UrlEncode(templateId == null ? "" : templateId) + "&";
            postStr += "region=" + WebUtility.UrlEncode(region == null ? "" : region) + "&";
            postStr += "verifyId=" + WebUtility.UrlEncode(verifyId == null ? "" : verifyId) + "&";
            postStr += "verifyCode=" + WebUtility.UrlEncode(verifyCode == null ? "" : verifyCode) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<SMSSendCodeReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDSMSURI + "/sendCode.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <param name="sessionId">短信验证码唯一标识，在发送短信验证码方法，返回值中获取。（必传）</param>
        /// <param name="code">短信验证码内容。（必传）</param>
        public async Task<CodeSuccessReslut> VerifyCode(string sessionId, string code)
        {
            if (string.IsNullOrEmpty(sessionId))
                throw new ArgumentNullException(nameof(sessionId));
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException(nameof(code));

            string postStr = "";
            postStr += "sessionId=" + WebUtility.UrlEncode(sessionId == null ? "" : sessionId) + "&";
            postStr += "code=" + WebUtility.UrlEncode(code == null ? "" : code) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDSMSURI + "/verifyCode.json", postStr, "application/x-www-form-urlencoded"));
        }
    }
}
