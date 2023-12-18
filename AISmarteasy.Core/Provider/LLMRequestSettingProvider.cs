namespace AISmarteasy.Core;


public static class LLMRequestSettingProvider
{
    public static LLMServiceSetting Provide(LLMRequestLevelKind requestType = LLMRequestLevelKind.Lower)
    {
        return new LLMServiceSetting();
    }
}
