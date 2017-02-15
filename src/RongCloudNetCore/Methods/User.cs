using Newtonsoft.Json;
using RongCloudNetCore.Models;
using RongCloudNetCore.Util;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RongCloudNetCore.Methods
{
    public class User
    {
        private string appKey;
        private string appSecret;

        public User(string appKey, string appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="userId">用户 Id，最大长度 64 字节.是用户在 App 中的唯一标识码，必须保证在同一个 App 内不重复，重复的用户 Id 将被当作是同一用户。（必传）</param>
        /// <param name="name">用户名称，最大长度 128 字节.用来在 Push 推送时显示用户的名称.用户名称，最大长度 128 字节.用来在 Push 推送时显示用户的名称。（必传）</param>
        /// <param name="portraitUri">用户头像 URI，最大长度 1024 字节.用来在 Push 推送时显示用户的头像。（必传）</param>
        public async Task<TokenReslut> GetToken(string userId, string name, string portraitUri)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));
            if (name == null)
                throw new ArgumentNullException("Paramer 'name' is required");
            if (portraitUri == null)
                throw new ArgumentNullException("Paramer 'portraitUri' is required");

            string postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr += "name=" + WebUtility.UrlEncode(name == null ? "" : name) + "&";
            postStr += "portraitUri=" + WebUtility.UrlEncode(portraitUri == null ? "" : portraitUri) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<TokenReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/user/getToken.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 刷新用户信息
        /// </summary>
        /// <param name="userId">用户 Id，最大长度 64 字节.是用户在 App 中的唯一标识码，必须保证在同一个 App 内不重复，重复的用户 Id 将被当作是同一用户。（必传）</param>
        /// <param name="name">用户名称，最大长度 128 字节。用来在 Push 推送时，显示用户的名称，刷新用户名称后 5 分钟内生效。（可选，提供即刷新，不提供忽略）</param>
        /// <param name="portraitUri">用户头像 URI，最大长度 1024 字节。用来在 Push 推送时显示。（可选，提供即刷新，不提供忽略）</param>
        public async Task<CodeSuccessReslut> Refresh(string userId, string name, string portraitUri)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));

            string postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr += "name=" + WebUtility.UrlEncode(name == null ? "" : name) + "&";
            postStr += "portraitUri=" + WebUtility.UrlEncode(portraitUri == null ? "" : portraitUri) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/user/refresh.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 检查用户在线状态
        /// </summary>
        /// <param name="userId">用户 Id，最大长度 64 字节。是用户在 App 中的唯一标识码，必须保证在同一个 App 内不重复，重复的用户 Id 将被当作是同一用户。（必传）</param>
        public async Task<CheckOnlineReslut> CheckOnline(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException("Paramer 'userId' is required");

            string postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CheckOnlineReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/user/checkOnline.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 封禁用户方法（每秒钟限 100 次） 
        /// </summary>
        /// <param name="userId">用户 Id。（必传）</param>
        /// <param name="minute">封禁时长,单位为分钟，最大值为43200分钟。（必传）</param>
        public async Task<CodeSuccessReslut> Block(string userId, int minute)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));

            string postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr += "minute=" + WebUtility.UrlEncode(Convert.ToString(minute) == null ? "" : Convert.ToString(minute)) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/user/block.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 解除用户封禁方法（每秒钟限 100 次） 
        /// </summary>
        /// <param name="userId">用户 Id（必传）</param>
        public async Task<CodeSuccessReslut> UnBlock(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));

            string postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/user/unblock.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 获取被封禁用户方法（每秒钟限 100 次） 
        /// </summary>
        public async Task<QueryBlockUserReslut> QueryBlock()
        {
            string postStr = "";
            return JsonConvert.DeserializeObject<QueryBlockUserReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/user/block/query.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 添加用户到黑名单方法（每秒钟限 100 次） 
        /// </summary>
        /// <param name="userId">用户Id（必传）</param>
        /// <param name="blackUserId">被加到黑名单的用户Id（必传）</param>
        public async Task<CodeSuccessReslut> AddBlacklist(string userId, string blackUserId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));
            if (string.IsNullOrEmpty(blackUserId))
                throw new ArgumentNullException(nameof(blackUserId));

            string postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr += "blackUserId=" + WebUtility.UrlEncode(blackUserId == null ? "" : blackUserId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/user/blacklist/add.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 获取某用户的黑名单列表方法（每秒钟限 100 次） 
        /// </summary>
        /// <param name="userId">用户 Id（必传）</param>
        public async Task<QueryBlacklistUserReslut> AueryBlacklist(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));

            string postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<QueryBlacklistUserReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/user/blacklist/query.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 从黑名单中移除用户方法（每秒钟限 100 次） 
        /// </summary>
        /// <param name="userId">用户Id（必传）</param>
        /// <param name="blackUserId">被移除的用户Id（必传）</param>
        public async Task<CodeSuccessReslut> RemoveBlacklist(string userId, string blackUserId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));
            if (string.IsNullOrEmpty(blackUserId))
                throw new ArgumentNullException(nameof(blackUserId));

            string postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr += "blackUserId=" + WebUtility.UrlEncode(blackUserId == null ? "" : blackUserId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/user/blacklist/remove.json", postStr, "application/x-www-form-urlencoded"));
        }
    }
}
