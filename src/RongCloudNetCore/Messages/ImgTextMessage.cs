namespace RongCloudNetCore.Messages
{
    /// <summary>
    /// 图文消息
    /// </summary>
    public class ImgTextMessage : BaseMessage
    {
        public ImgTextMessage() { }

        public ImgTextMessage(string content, string extra, string title, string imageUri, string url)
        {
            Content = content;
            Extra = extra;
            Title = title;
            ImageUri = imageUri;
            Url = url;
        }

        public override string TYPE
        {
            get
            {
                return "RC:ImgTextMsg";
            }
        }

        /// <summary>
        /// 消息文本内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 附加信息（如果开发者自己需要，可以自己在App端进行解析）
        /// </summary>
        public string Extra { get; set; }

        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageUri { get; set; }

        /// <summary>
        /// URL跳转地址
        /// </summary>
        public string Url { get; set; }
    }
}
