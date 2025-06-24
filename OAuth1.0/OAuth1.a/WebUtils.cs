using System.Web;

namespace OAuth1.a;

internal static class WebUtils
{
    public static IEnumerable<WebParameter> ParseQueryString(Uri uri)
    {
        if (uri is null) { throw new ArgumentNullException(nameof(uri)); }

        var parsedQuery = HttpUtility.ParseQueryString(uri.Query);
        var queryStringParameters =
            parsedQuery.AllKeys
                .Where(key => key != null) // Ensure keys are not null
                .SelectMany(
                    key => parsedQuery.GetValues(key) ?? Array.Empty<string>(),
                    (key, value) => new { key, value });

        foreach (var param in queryStringParameters)
        {
            yield return new WebParameter(param.key!, param.value); // Use null-forgiving operator
        }
    }
}
