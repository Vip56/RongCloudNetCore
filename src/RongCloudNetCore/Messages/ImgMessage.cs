namespace RongCloudNetCore.Messages
{
    /// <summary>
    /// 图片消息
    /// </summary>
    public class ImgMessage : BaseMessage
    {
        public ImgMessage() { }

        public ImgMessage(string content, string extra, string imageUri)
        {
            Content = content;
            Extra = extra;
            ImageUri = imageUri;
        }

        public override string TYPE
        {
            get
            {
                return "RC:ImgMsg";
            }
        }

        /// <summary>
        /// 图片微缩图，格式为JPG,大小不超过30k，注意在Base64进行Encode后需要见所有\r\n和\r和\n替换成空
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 附加信息（如果开发者自己需要，可以自己在App端进行解析）
        /// </summary>
        public string Extra { get; set; }

        /// <summary>
        /// 图片URL
        /// </summary>
        public string ImageUri { get; set; }
    }
}
