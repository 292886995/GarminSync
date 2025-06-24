namespace OAuth1.a;

/// <summary>
/// 指定在计算过程中是否应对最终的签名值进行转义处理。
/// 对于某些不符合默认签名转义规范的 OAuth 实现方式，此设置可能是必要的。
/// </summary>
public enum OAuthSignatureTreatment
{
    Escaped,
    Unescaped
}