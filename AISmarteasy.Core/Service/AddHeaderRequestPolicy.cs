using Azure.Core;
using Azure.Core.Pipeline;

namespace AISmarteasy.Core;

public sealed class AddHeaderRequestPolicy(string headerName, string headerValue) : HttpPipelineSynchronousPolicy
{
    public override void OnSendingRequest(HttpMessage message)
    {
        message.Request.Headers.Add(headerName, headerValue);
    }
}
