namespace AISmarteasy.Core;

public abstract class AIWorkEnv(AIServiceVendorKind serviceVendor)
{
    public AIServiceVendorKind ServiceVendor { get; } = serviceVendor;
}
