using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RongCloudNetCore.Models
{
    /// <summary>
    /// getToken 返回结果
    /// </summary>
    public class TokenReslut : BaseModel
    {
        public TokenReslut(int code, string token, string userId, string errorMessage)
        {
            Code = code;
            Token = token;
            UserId = userId;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// 返回码，200 为正常
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 用户 Token，可以保存应用内，长度在 256 字节以内.用户 Token，可以保存应用内，长度在 256 字节以内
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 用户 Id，与输入的用户 Id 相同.用户 Id，与输入的用户 Id 相同。
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
