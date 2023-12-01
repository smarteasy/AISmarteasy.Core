namespace AISmarteasy.Core
{
    public static class KernelProvider
    {
        public static void Initialize(IKernel kernel)
        {
            Kernel = kernel;
        }

        public static IKernel Kernel { get; private set; } = null!;
    }
}
