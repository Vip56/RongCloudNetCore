using Newtonsoft.Json;
using RongCloudNetCore.Models;
using RongCloudNetCore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RongCloudNetCore.Methods
{
    public class Chatroom
    {
        private const string UTF8 = "UTF-8";
        private string appKey;
        private string appSecret;

        public Chatroom(string appKey,string appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }

        /// <summary>
        /// 创建聊天室
        /// </summary>
        /// <param name="chatRoomInfo">聊天室信息</param>
        public async Task<CodeSuccessReslut> Create(ChatRoomInfo[] chatRoomInfo)
        {
            if (chatRoomInfo == null)
                throw new ArgumentNullException(nameof(chatRoomInfo));

            StringBuilder postStr = new StringBuilder();
            if(chatRoomInfo != null)
            {
                for (int i = 0; i < chatRoomInfo.Length; i++)
                {
                    string id = WebUtility.UrlEncode(chatRoomInfo[i].Id);
                    string name = WebUtility.UrlEncode(chatRoomInfo[i].Name);
                    postStr.Append($"chatroom[{id}]={name}&");
                }
            }
            string str = postStr.ToString();
            str = str.Substring(0, str.LastIndexOf('&'));
            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/create.json", str, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 加入聊天室
        /// </summary>
        /// <param name="userId">要加入聊天室的用户 Id，可提交多个，最多不超过 50 个。（必传）</param>
        /// <param name="chatroomId">要加入的聊天室 Id。（必传）</param>
        public async Task<CodeSuccessReslut> Join(string[] userId, string chatroomId)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));
            if (string.IsNullOrEmpty(chatroomId))
                throw new ArgumentNullException(nameof(chatroomId));

            StringBuilder postStr = new StringBuilder();
            for (int i = 0; i < userId.Length; i++)
            {
                postStr.Append($"userId={WebUtility.UrlEncode(userId[i])}&");
            }
            postStr.Append($"chatroomId={WebUtility.UrlEncode(chatroomId == null ? "" : chatroomId)}&");
            string str = postStr.ToString();
            str = str.Substring(0, str.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/join.json", str, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 查询聊天室信息方法
        /// </summary>
        /// <param name="chatroomId">要查询的聊天室id</param>
        public async Task<ChatroomQueryReslut> Query(string[] chatroomId)
        {

            if (chatroomId == null)
                throw new ArgumentNullException(nameof(chatroomId));

            string postStr = "";
            for (int i = 0; i < chatroomId.Length; i++)
            {
                string child = chatroomId[i];
                postStr += "chatroomId=" + WebUtility.UrlEncode(child) + "&";
            }

            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<ChatroomQueryReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/query.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 查询聊天室内用户方法
        /// </summary>
        /// <param name="chatroomId">要查询的聊天室id</param>
        /// <param name="count">要获取的聊天室成员数，上限为 500 ，超过 500 时最多返回 500 个成员。（必传）</param>
        /// <param name="order">加入聊天室的先后顺序， 1 为加入时间正序， 2 为加入时间倒序。（必传）</param>
        public async Task<ChatroomUserQueryReslut> QueryUser(string chatroomId, string count, string order)
        {
            if (string.IsNullOrEmpty(chatroomId))
                throw new ArgumentNullException(nameof(chatroomId));

            if (string.IsNullOrEmpty(count))
                throw new ArgumentNullException(nameof(count));

            if (string.IsNullOrEmpty(order))
                throw new ArgumentNullException(nameof(order));

            string postStr = "";
            postStr += "chatroomId=" + WebUtility.UrlEncode(chatroomId == null ? "" : chatroomId) + "&";
            postStr += "count=" + WebUtility.UrlEncode(count == null ? "" : count) + "&";
            postStr += "order=" + WebUtility.UrlEncode(order == null ? "" : order) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<ChatroomUserQueryReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/user/query.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 聊天室消息停止分发方法（可实现控制对聊天室中消息是否进行分发，停止分发后聊天室中用户发送的消息，融云服务端不会再将消息发送给聊天室中其他用户。） 
        /// </summary>
        /// <param name="chatroomId">聊天室 Id</param>
        public async Task<CodeSuccessReslut> StopDistributionMessage(string chatroomId)
        {

            if (string.IsNullOrEmpty(chatroomId))
                throw new ArgumentNullException(nameof(chatroomId));

            string postStr = "";
            postStr += "chatroomId=" + WebUtility.UrlEncode(chatroomId == null ? "" : chatroomId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/message/stopDistribution.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 聊天室消息恢复分发方法
        /// </summary>
        /// <param name="chatroomId">聊天室Id</param>
        public async Task<CodeSuccessReslut> ResumeDistributionMessage(string chatroomId)
        {
            if (string.IsNullOrEmpty(chatroomId))
                throw new ArgumentNullException(nameof(chatroomId));

            string postStr = "";
            postStr += "chatroomId=" + WebUtility.UrlEncode(chatroomId == null ? "" : chatroomId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/message/resumeDistribution.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 添加禁言聊天室成员方法（在 App 中如果不想让某一用户在聊天室中发言时，可将此用户在聊天室中禁言，被禁言用户可以接收查看聊天室中用户聊天信息，但不能发送消息.） 
        /// </summary>
        /// <param name="userId">用户Id（必传）</param>
        /// <param name="chatroomId">聊天室Id（必传）</param>
        /// <param name="minute">禁言时长，以分钟为单位，最大值为43200分钟。（必传）</param>
        public async Task<CodeSuccessReslut> AddGagUser(string userId, string chatroomId, string minute)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));

            if (string.IsNullOrEmpty(chatroomId))
                throw new ArgumentNullException(nameof(chatroomId));

            if (string.IsNullOrEmpty(minute))
                throw new ArgumentNullException(nameof(minute));

            string postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr += "chatroomId=" + WebUtility.UrlEncode(chatroomId == null ? "" : chatroomId) + "&";
            postStr += "minute=" + WebUtility.UrlEncode(minute == null ? "" : minute) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/user/gag/add.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 查询被禁言聊天室成员方法
        /// </summary>
        /// <param name="chatroomId">聊天室Id</param>
        public async Task<ListGagChatroomUserReslut> ListGagUser(string chatroomId)
        {
            if (string.IsNullOrEmpty(chatroomId))
                throw new ArgumentNullException(nameof(chatroomId));

            string postStr = "";
            postStr += "chatroomId=" + WebUtility.UrlEncode(chatroomId == null ? "" : chatroomId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<ListGagChatroomUserReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/user/gag/list.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 移除禁言聊天室成员方法 
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="chatroomId">聊天室Id</param>
        public async Task<CodeSuccessReslut> RollbackGagUser(string userId, string chatroomId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));
            if (string.IsNullOrEmpty(chatroomId))
                throw new ArgumentNullException(nameof(chatroomId));

            String postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr += "chatroomId=" + WebUtility.UrlEncode(chatroomId == null ? "" : chatroomId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/user/gag/rollback.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 添加封禁聊天室成员方法
        /// </summary>
        /// <param name="userId">用户Id（必传）</param>
        /// <param name="chatroomId">聊天室Id（必传）</param>
        /// <param name="minute">封禁时长，以分钟为单位，最大值为43200分钟（必传）</param>
        public async Task<CodeSuccessReslut> AddBlockUser(string userId, string chatroomId, string minute)
        {

            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));
            if (string.IsNullOrEmpty(chatroomId))
                throw new ArgumentNullException(nameof(chatroomId));
            if (string.IsNullOrEmpty(minute))
                throw new ArgumentNullException(nameof(minute));

            String postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr += "chatroomId=" + WebUtility.UrlEncode(chatroomId == null ? "" : chatroomId) + "&";
            postStr += "minute=" + WebUtility.UrlEncode(minute == null ? "" : minute) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/user/block/add.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 查询被封禁聊天室成员方法
        /// </summary>
        /// <param name="chatroomId">聊天室Id（必传）</param>
        public async Task<ListBlockChatroomUserReslut> GetListBlockUser(string chatroomId)
        {
            if (string.IsNullOrEmpty(chatroomId))
                throw new ArgumentNullException(nameof(chatroomId));

            string postStr = "";
            postStr += "chatroomId=" + WebUtility.UrlEncode(chatroomId == null ? "" : chatroomId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<ListBlockChatroomUserReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/user/block/list.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 移除封禁聊天室成员方法 
        /// </summary>
        /// <param name="userId">用户Id（必传）</param>
        /// <param name="chatroomId">聊天室Id（必传）</param>
        public async Task<CodeSuccessReslut> RollbackBlockUser(string userId, string chatroomId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));
            if (string.IsNullOrEmpty(chatroomId))
                throw new ArgumentNullException(nameof(chatroomId));

            String postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr += "chatroomId=" + WebUtility.UrlEncode(chatroomId == null ? "" : chatroomId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/user/block/rollback.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 销毁聊天室方法
        /// </summary>
        /// <param name="chatroomId">要销毁的聊天室Id（必传）</param>
        public async Task<CodeSuccessReslut> Destroy(string[] chatroomId)
        {
            if (chatroomId == null)
                throw new ArgumentNullException(nameof(chatroomId));

            string postStr = "";
            for (int i = 0; i < chatroomId.Length; i++)
            {
                string child = chatroomId[i];
                postStr += "chatroomId=" + WebUtility.UrlEncode(child) + "&";
            }

            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/destroy.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 添加聊天室消息优先级方法
        /// </summary>
        /// <param name="objectName">低优先级的消息类型，每次最多提交 5 个，设置的消息类型最多不超过 20 个。（必传）</param>
        public async Task<CodeSuccessReslut> AddPriority(string[] objectName)
        {
            if (objectName == null)
                throw new ArgumentNullException(nameof(objectName));

            string postStr = "";
            for (int i = 0; i < objectName.Length; i++)
            {
                string child = objectName[i];
                postStr += "objectName=" + WebUtility.UrlEncode(child) + "&";
            }

            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/message/priority/add.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 添加聊天室白名单成员方法
        /// </summary>
        /// <param name="chatroomId">聊天室中用户 Id，可提交多个，聊天室中白名单用户最多不超过 5 个。（必传）</param>
        /// <param name="userId">聊天室Id（必传）</param>
        public async Task<CodeSuccessReslut> AddWhiteListUser(string chatroomId, string[] userId)
        {
            if (string.IsNullOrEmpty(chatroomId))
                throw new ArgumentNullException(nameof(chatroomId));
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            string postStr = "";
            postStr += "chatroomId=" + WebUtility.UrlEncode(chatroomId == null ? "" : chatroomId) + "&";
            for (int i = 0; i < userId.Length; i++)
            {
                String child = userId[i];
                postStr += "userId=" + WebUtility.UrlEncode(child) + "&";
            }

            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/chatroom/user/whitelist/add.json", postStr, "application/x-www-form-urlencoded"));
        }
    }
}
