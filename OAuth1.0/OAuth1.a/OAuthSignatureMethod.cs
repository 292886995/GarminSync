namespace OAuth1.a;

/// <summary>
/// 对请求签名进行哈希处理时所采用的加密方法。
/// </summary>
public enum OAuthSignatureMethod
{
    HmacSha1,
    PlainText,
    RsaSha1
}