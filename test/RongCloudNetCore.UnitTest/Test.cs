using RongCloudNetCore.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RongCloudNetCore.UnitTest
{
    public class Test
    {
        public const string appKey = "82hegw5uhqtcx";
        public const string appSecret = "FnngEX4S3aB";

        private RongCloud _client;

        public Test()
        {
            _client = RongCloud.GetInstance(appKey, appSecret);
        }

        [Fact]
        public async Task TestGetUserToken()
        {
            var userToken = await _client.User.GetToken("userId1", "测试", "http://www.rongcloud.cn/images/logo.png");

            Assert.Equal(userToken.Code, 200);
            Assert.NotNull(userToken.Token);
        }

        [Fact]
        public async Task TestRefreshUser()
        {
            var userToken = await _client.User.Refresh("userId1,", "测试", "http://www.rongcloud.cn/images/logo.png");
            Assert.Equal(userToken.Code, 200);
        }

        [Fact]
        public async Task TestCheckOnline()
        {
            var userCheck = await _client.User.CheckOnline("userId1");
            Assert.Equal(userCheck.Code, 200);
        }

        [Fact]
        public async Task TestBlock()
        {
            var userBlock = await _client.User.Block("userId1", 10);
            Assert.Equal(userBlock.Code, 200);
        }

        [Fact]
        public async Task TestUserUnBlock()
        {
            var userUnBlock = await _client.User.UnBlock("userId2");
            Assert.Equal(userUnBlock.Code, 200);
        }

        [Fact]
        public async Task TestQueryBlock()
        {
            var queryBlock = await _client.User.QueryBlock();
            Assert.Equal(queryBlock.Code, 200);
        }

        [Fact]
        public async Task TestPublishVoiceMessage()
        {
            string[] messageUserIds = { "userId2", "userid3", "userId4" };
            VoiceMessage msg = new VoiceMessage("hello", "helloExtra", 20L);
            var result = await _client.Message.PublishPrivate("userId1", messageUserIds, msg, "thisisapush", "exit", "4", 0, 0, 0);
            Assert.Equal(result.Code, 200);
        }


        [Fact]
        public async Task TestPublishSystemMessage()
        {
            string[] messageUserIds = { "userId2", "userid3", "userId4" };
            CmdMsgMessage msg = new CmdMsgMessage("hello", "helloExtra");
            var result = await _client.Message.PublishSystem("System", messageUserIds, msg, null, null, 0, 0);
            Assert.Equal(result.Code, 200);
        }

    }
}
