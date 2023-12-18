namespace AISmarteasy.Core;

public static class ExceptionExtensions
{
    public static bool IsCriticalException(this Exception ex)
        => ex is ThreadAbortException
            or AccessViolationException
            or AppDomainUnloadedException
            or BadImageFormatException
            or CannotUnloadAppDomainException
            or InvalidProgramException;
}
