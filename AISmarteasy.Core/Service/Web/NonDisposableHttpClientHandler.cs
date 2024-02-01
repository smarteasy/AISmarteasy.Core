﻿namespace AISmarteasy.Core;

public sealed class NonDisposableHttpClientHandler : HttpClientHandler
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
