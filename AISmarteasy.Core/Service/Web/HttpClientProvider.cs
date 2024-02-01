using Microsoft.Extensions.DependencyInjection;

namespace AISmarteasy.Core;

public static class HttpClientProvider
{
    public static HttpClient GetHttpClient() => new(NonDisposableHttpClientHandler.Instance, disposeHandler: false);

    public static HttpClient GetHttpClient(HttpClient? httpClient = null) => httpClient ?? GetHttpClient();

    public static HttpClient GetHttpClient(IServiceProvider? serviceProvider = null) => GetHttpClient(serviceProvider?.GetService<HttpClient>());

    public static HttpClient GetHttpClient(HttpClient? httpClient, IServiceProvider serviceProvider) => httpClient ?? GetHttpClient(serviceProvider?.GetService<HttpClient>());

    private sealed class NonDisposableHttpClientHandler : HttpClientHandler
    {
        private NonDisposableHttpClientHandler()
        {
            CheckCertificateRevocationList = true;
        }

        public static NonDisposableHttpClientHandler Instance { get; } = new();

        protected override void Dispose(bool disposing)
        {
        }
    }
}
