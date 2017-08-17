using Newtonsoft.Json;
using RongCloudNetCore.Models;
using RongCloudNetCore.Util;
using System;
using System.Threading.Tasks;

namespace RongCloudNetCore.Methods
{
    public class Push
    {
        private string appKey;
        private string appSecret;

        public Push(string appKey, string appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }

        /// <summary>
        /// 添加 Push 标签方法 
        /// </summary>
        /// <param name="userTag">用户标签</param>
        public async Task<CodeSuccessReslut> setUserPushTag(UserTag userTag)
        {
            if (userTag == null)
                throw new ArgumentNullException(nameof(userTag));

            string postStr = userTag.ToString();
            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/user/tag/set.json", postStr, "application/json"));
        }

        /// <summary>
        /// 广播消息方法（fromuserid 和 message为null即为不落地的push） 
        /// </summary>
        /// <param name="pushMessage">json数据</param>
        public async Task<CodeSuccessReslut> BroadcastPush(PushMessage pushMessage)
        {
            if (pushMessage == null)
                throw new ArgumentNullException(nameof(pushMessage));

            string postStr = pushMessage.ToString();
            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/push.json", postStr, "application/json"));
        }
    }
}
