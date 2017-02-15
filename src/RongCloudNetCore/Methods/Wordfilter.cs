using Newtonsoft.Json;
using RongCloudNetCore.Models;
using RongCloudNetCore.Util;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RongCloudNetCore.Methods
{
    public class Wordfilter
    {
        private string appKey;
        private string appSecret;

        public Wordfilter(string appKey, string appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }

        /// <summary>
        /// 添加敏感词方法（设置敏感词后，App 中用户不会收到含有敏感词的消息内容，默认最多设置 50 个敏感词。）
        /// </summary>
        /// <param name="word">敏感词，最长不超过 32 个字符（必传）</param>
        public async Task<CodeSuccessReslut> Add(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentNullException(nameof(word));

            string postStr = "";
            postStr += "word=" + WebUtility.UrlEncode(word == null ? "" : word) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/wordfilter/add.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 查询敏感词列表方法
        /// </summary>
        public async Task<ListWordfilterReslut> GetList()
        {

            string postStr = "";
            return JsonConvert.DeserializeObject<ListWordfilterReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/wordfilter/list.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 移除敏感词方法（从敏感词列表中，移除某一敏感词。） 
        /// </summary>
        /// <param name="word">敏感词，最长不超过 32 个字符（必传）</param>
        public async Task<CodeSuccessReslut> Delete(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentNullException(nameof(word));

            string postStr = "";
            postStr += "word=" + WebUtility.UrlEncode(word == null ? "" : word) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/wordfilter/delete.json", postStr, "application/x-www-form-urlencoded"));
        }
    }
}
