namespace AISmarteasy.Core;


public static class LLMServiceSettingProvider
{
    public static LLMServiceSetting Provide(LLMRequestLevelKind requestType = LLMRequestLevelKind.Lower)
    {
        return new LLMServiceSetting();
    }
}
