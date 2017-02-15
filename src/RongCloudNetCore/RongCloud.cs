using RongCloudNetCore.Methods;
using System;
using System.Collections.Generic;

namespace RongCloudNetCore
{
    public class RongCloud
    {
        private static Dictionary<string, RongCloud> rongCloud = new Dictionary<String, RongCloud>();
        public static string RONGCLOUDURI = "http://api.cn.ronghub.com";
        public const string RONGCLOUDSMSURI = "http://api.sms.ronghub.com";
        //确保线程同步
        private static readonly object locker = new object();

        public User User { get; set; }
        public Message Message { get; set; }
        public Wordfilter WordFilter { get; set; }
        public Group Group { get; set; }
        public Chatroom Chatroom { get; set; }
        public Push Push { get; set; }
        public SMS SMS { get; set; }

        private RongCloud(string appKey, string appSecret)
        {
            User = new User(appKey, appSecret);
            Message = new Message(appKey, appSecret);
            WordFilter = new Wordfilter(appKey, appSecret);
            Group = new Group(appKey, appSecret);
            Chatroom = new Chatroom(appKey, appSecret);
            Push = new Push(appKey, appSecret);
            SMS = new SMS(appKey, appSecret);
        }

        public static RongCloud GetInstance(string appKey, string appSecret)
        {
            lock (locker)
            {
                if (!rongCloud.ContainsKey(appKey))
                {
                    rongCloud.Add(appKey, new RongCloud(appKey, appSecret));
                }
            }
            return rongCloud[appKey];
        }
    }
}
