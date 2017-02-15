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

        public User user;
        public Message message;
        public Wordfilter wordfilter;
        public Group group;
        public Chatroom chatroom;
        public Push push;
        public SMS sms;

        private RongCloud(string appKey, string appSecret)
        {
            user = new User(appKey, appSecret);
            message = new Message(appKey, appSecret);
            wordfilter = new Wordfilter(appKey, appSecret);
            group = new Group(appKey, appSecret);
            chatroom = new Chatroom(appKey, appSecret);
            push = new Push(appKey, appSecret);
            sms = new SMS(appKey, appSecret);
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
