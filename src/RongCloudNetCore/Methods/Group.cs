using Newtonsoft.Json;
using RongCloudNetCore.Models;
using RongCloudNetCore.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RongCloudNetCore.Methods
{
    public class Group
    {
        private string appKey;
        private string appSecret;

        public Group(string appKey, string appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }

        /// <summary>
        /// 创建群组方法（创建群组，并将用户加入该群组，用户将可以收到该群的消息，同一用户最多可加入 500 个群，每个群最大至 3000 人，App 内的群组数量没有限制.注：其实本方法是加入群组方法 /group/join 的别名。） 
        /// </summary>
        /// <param name="userId">要加入群的用户Id（必传）</param>
        /// <param name="groupId">创建群组Id（必传）</param>
        /// <param name="groupName">群组Id对应的名称</param>
        public async Task<CodeSuccessReslut> Create(string[] userId, string groupId, string groupName)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId));
            if (string.IsNullOrEmpty(groupName))
                throw new ArgumentNullException(nameof(groupName));

            string postStr = "";
            for (int i = 0; i < userId.Length; i++)
            {
                string child = userId[i];
                postStr += "userId=" + WebUtility.UrlEncode(child) + "&";
            }

            postStr += "groupId=" + WebUtility.UrlEncode(groupId == null ? "" : groupId) + "&";
            postStr += "groupName=" + WebUtility.UrlEncode(groupName == null ? "" : groupName) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/group/create.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 同步用户所属群组方法（当第一次连接融云服务器时，需要向融云服务器提交 userId 对应的用户当前所加入的所有群组，此接口主要为防止应用中用户群信息同融云已知的用户所属群信息不同步。） 
        /// </summary>
        /// <param name="userId">被同步群信息的用户Id（必传）</param>
        /// <param name="groupInfo">该用户的群信息，如群 Id 已经存在，则不会刷新对应群组名称，如果想刷新群组名称请调用刷新群组信息方法。</param>
        public async Task<CodeSuccessReslut> Sync(string userId, GroupInfo[] groupInfo)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));
            if (groupInfo == null)
                throw new ArgumentNullException(nameof(groupInfo));

            string postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            if (groupInfo != null)
            {
                for (int i = 0; i < groupInfo.Length; i++)
                {
                    string id = WebUtility.UrlEncode(groupInfo[i].Id);
                    string name = WebUtility.UrlEncode(groupInfo[i].Name);
                    postStr += "group[" + id + "]=" + name + "&";
                }
            }
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/group/sync.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 刷新群组信息方法
        /// </summary>
        /// <param name="groupId">群组Id（必传）</param>
        /// <param name="groupName">群名称（必传）</param>
        public async Task<CodeSuccessReslut> Refresh(string groupId, string groupName)
        {
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId));
            if (string.IsNullOrEmpty(groupName))
                throw new ArgumentNullException(nameof(groupName));

            string postStr = "";
            postStr += "groupId=" + WebUtility.UrlEncode(groupId == null ? "" : groupId) + "&";
            postStr += "groupName=" + WebUtility.UrlEncode(groupName == null ? "" : groupName) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/group/refresh.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 将用户加入指定群组，用户将可以收到该群的消息，同一用户最多可加入 500 个群，每个群最大至 3000 人。
        /// </summary>
        /// <param name="userId">要加入群的用户 Id，可提交多个，最多不超过 1000 个。（必传）</param>
        /// <param name="groupId">要加入的群 Id。（必传）</param>
        /// <param name="groupName">要加入的群 Id 对应的名称。（必传）</param>
        public async Task<CodeSuccessReslut> Join(string[] userId, string groupId, string groupName)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId));
            if (string.IsNullOrEmpty(groupName))
                throw new ArgumentNullException(nameof(groupName));

            String postStr = "";
            for (int i = 0; i < userId.Length; i++)
            {
                String child = userId[i];
                postStr += "userId=" + WebUtility.UrlEncode(child) + "&";
            }

            postStr += "groupId=" + WebUtility.UrlEncode(groupId == null ? "" : groupId) + "&";
            postStr += "groupName=" + WebUtility.UrlEncode(groupName == null ? "" : groupName) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/group/join.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 查询群成员方法
        /// </summary>
        /// <param name="groupId">群组Id（必传）</param>
        public async Task<GroupUserQueryReslut> QueryUser(string groupId)
        {
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId));

            string postStr = "";
            postStr += "groupId=" + WebUtility.UrlEncode(groupId == null ? "" : groupId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<GroupUserQueryReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/group/user/query.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 退出群组方法（将用户从群中移除，不再接收该群组的消息.） 
        /// </summary>
        /// <param name="userId">要退出群的用户Id.（必传）</param>
        /// <param name="groupId">要退出的群 Id.（必传）</param>
        public async Task<CodeSuccessReslut> Quit(string[] userId, string groupId)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId));

            string postStr = "";
            for (int i = 0; i < userId.Length; i++)
            {
                string child = userId[i];
                postStr += "userId=" + WebUtility.UrlEncode(child) + "&";
            }

            postStr += "groupId=" + WebUtility.UrlEncode(groupId == null ? "" : groupId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/group/quit.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 添加禁言群成员方法（在 App 中如果不想让某一用户在群中发言时，可将此用户在群组中禁言，被禁言用户可以接收查看群组中用户聊天信息，但不能发送消息。） 
        /// </summary>
        /// <param name="userId">用户Id（必传）</param>
        /// <param name="groupId">群组Id（必传）</param>
        /// <param name="minute">禁言时长，以分钟为单位，最大值为43200分钟（必传）</param>
        public async Task<CodeSuccessReslut> AddGagUser(string userId, string groupId, string minute)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException(nameof(userId));
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId));
            if (string.IsNullOrEmpty(minute))
                throw new ArgumentNullException(nameof(minute));

            string postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr += "groupId=" + WebUtility.UrlEncode(groupId == null ? "" : groupId) + "&";
            postStr += "minute=" + WebUtility.UrlEncode(minute == null ? "" : minute) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/group/user/gag/add.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 查询被禁言群成员方法
        /// </summary>
        /// <param name="groupId">群组Id（必传）</param>
        public async Task<ListGagGroupUserReslut> LisGagUser(string groupId)
        {
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId));

            string postStr = "";
            postStr += "groupId=" + WebUtility.UrlEncode(groupId == null ? "" : groupId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<ListGagGroupUserReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/group/user/gag/list.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 移除禁言群成员方法
        /// </summary>
        /// <param name="userId">用户Id。支持同时移除多个群成员（必传）</param>
        /// <param name="groupId">群组Id。（必传）</param>
        public async Task<CodeSuccessReslut> RollBackGagUser(string[] userId, string groupId)
        {
            if (userId == null)
                throw new ArgumentNullException("Paramer 'userId' is required");
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId));

            string postStr = "";
            for (int i = 0; i < userId.Length; i++)
            {
                string child = userId[i];
                postStr += "userId=" + WebUtility.UrlEncode(child) + "&";
            }

            postStr += "groupId=" + WebUtility.UrlEncode(groupId == null ? "" : groupId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/group/user/gag/rollback.json", postStr, "application/x-www-form-urlencoded"));
        }

        /// <summary>
        /// 解散群组方法。（将该群解散，所有用户都无法再接收该群的消息。） 
        /// </summary>
        /// <param name="userId">操作解散群的用户 Id。（必传）</param>
        /// <param name="groupId">要解散的群 Id。（必传）</param>
        public async Task<CodeSuccessReslut> Dismiss(string userId, string groupId)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));
            if (groupId == null)
                throw new ArgumentNullException(nameof(groupId));

            string postStr = "";
            postStr += "userId=" + WebUtility.UrlEncode(userId == null ? "" : userId) + "&";
            postStr += "groupId=" + WebUtility.UrlEncode(groupId == null ? "" : groupId) + "&";
            postStr = postStr.Substring(0, postStr.LastIndexOf('&'));

            return JsonConvert.DeserializeObject<CodeSuccessReslut>(await RongHttpClient.ExecutePost(appKey, appSecret, RongCloud.RONGCLOUDURI + "/group/dismiss.json", postStr, "application/x-www-form-urlencoded"));
        }
    }
}
