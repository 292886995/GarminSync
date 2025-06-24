using Newtonsoft.Json;

namespace OAuth1._0
{
    /// <summary>
    /// OAuth2 Token 信息
    /// </summary>
    public class OAuth2Token
    {
        /// <summary>
        /// 访问权限范围
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// JWT ID  JWT令牌唯一标识
        /// </summary>
        [JsonProperty("jti")]
        public string Jti { get; set; }

        /// <summary>
        /// 令牌类型    通常是bearer
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// 访问token
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 刷新token     用于获取新的访问令牌
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 访问令牌有效期 单位：秒
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// 刷新令牌有效期 单位：秒
        /// </summary>
        [JsonProperty("refresh_token_expires_in")]
        public int RefreshTokenExpiresIn { get; set; }

        /// <summary>
        /// 获取授权时间
        /// </summary>
        public DateTime AuthTime => DateTime.UtcNow;

        // 判断访问令牌是否过期
        public bool Expired
        {
            get
            {
                // 当前时间减去获取时间，是否超过有效期
                return DateTime.UtcNow >= AuthTime.AddSeconds(ExpiresIn);
            }
        }

        // 判断刷新令牌是否过期
        public bool RefreshExpired
        {
            get
            {
                // 当前时间减去获取时间，是否超过有效期
                return DateTime.UtcNow >= AuthTime.AddSeconds(RefreshTokenExpiresIn);
            }
        }

        public override string ToString()
        {
            // 返回格式如 "Bearer abcdefg123456"
            return $"{TokenType[..1].ToUpper()}{TokenType[1..].ToLower()} {AccessToken}";
        }
    }
}
