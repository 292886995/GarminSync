namespace OAuth1.a;

/// <summary>
/// 在典型的工作流程中可能发生的 OAuth 请求类型。
/// 用于验证目的以及用于构建静态辅助工具。
/// </summary>
public enum OAuthRequestType
{
    RequestToken,
    AccessToken,
    ProtectedResource,
    ClientAuthentication
}