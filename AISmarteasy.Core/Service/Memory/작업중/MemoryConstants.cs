namespace AISmarteasy.Core;

public static class MemoryConstants
{
    public const string WEB_SERVICE_INDEX_FIELD = "index";

    public const string WEB_SERVICE_DOCUMENT_ID_FIELD = "documentId";

    public const string WEB_SERVICE_TAGS_FIELD = "tags";

    public const string WEB_SERVICE_STEPS_FIELD = "steps";

    public const string PIPELINE_STATUS_FILENAME = "__pipeline_status.json";

    public const string DEFAULT_INDEX = "default";

    public const char RESERVED_EQUALS_CHAR = ':';
    public const string RESERVED_TAGS_PREFIX = "__";

    public const string RESERVED_DOCUMENT_ID_TAG = $"{RESERVED_TAGS_PREFIX}document_id";
    public const string RESERVED_FILE_ID_TAG = $"{RESERVED_TAGS_PREFIX}file_id";
    public const string RESERVED_FILE_PARTITION_TAG = $"{RESERVED_TAGS_PREFIX}file_part";
    public const string RESERVED_FILE_TYPE_TAG = $"{RESERVED_TAGS_PREFIX}file_type";
    public const string RESERVED_SYNTHETIC_TYPE_TAG = $"{RESERVED_TAGS_PREFIX}synth";

    public const string TAGS_SYNTHETIC_SUMMARY = "summary";

    public const string RESERVED_PAYLOAD_SCHEMA_VERSION_FIELD = "schema";
    public const string RESERVED_PAYLOAD_TEXT_FIELD = "text";
    public const string RESERVED_PAYLOAD_FILE_NAME_FIELD = "file";
    public const string RESERVED_PAYLOAD_URL_FIELD = "url";
    public const string RESERVED_PAYLOAD_LAST_UPDATE_FIELD = "last_update";
    public const string RESERVED_PAYLOAD_VECTOR_PROVIDER_FIELD = "vector_provider";
    public const string RESERVED_PAYLOAD_VECTOR_GENERATOR_FIELD = "vector_generator";

    public const string HTTP_ASK_ENDPOINT = "/ask";
    public const string HTTP_SEARCH_ENDPOINT = "/search";
    public const string HTTP_UPLOAD_ENDPOINT = "/upload";
    public const string HTTP_UPLOAD_STATUS_ENDPOINT = "/upload-status";
    public const string HTTP_DOCUMENTS_ENDPOINT = "/documents";
    public const string HTTP_INDEXES_ENDPOINT = "/indexes";
    public const string HTTP_DELETE_DOCUMENT_ENDPOINT_WITH_PARAMS = $"{HTTP_DOCUMENTS_ENDPOINT}?{WEB_SERVICE_INDEX_FIELD}={HTTP_INDEX_PLACEHOLDER}&{WEB_SERVICE_DOCUMENT_ID_FIELD}={HTTP_DOCUMENT_ID_PLACEHOLDER}";
    public const string HTTP_DELETE_INDEX_ENDPOINT_WITH_PARAMS = $"{HTTP_INDEXES_ENDPOINT}?{WEB_SERVICE_INDEX_FIELD}={HTTP_INDEX_PLACEHOLDER}";
    public const string HTTP_UPLOAD_STATUS_ENDPOINT_WITH_PARAMS = $"{HTTP_UPLOAD_STATUS_ENDPOINT}?{WEB_SERVICE_INDEX_FIELD}={HTTP_INDEX_PLACEHOLDER}&{WEB_SERVICE_DOCUMENT_ID_FIELD}={HTTP_DOCUMENT_ID_PLACEHOLDER}";
    public const string HTTP_INDEX_PLACEHOLDER = "{index}";
    public const string HTTP_DOCUMENT_ID_PLACEHOLDER = "{documentId}";

    public const string PIPELINE_STEPS_EXTRACT = "extract";
    public const string PIPELINE_STEPS_PARTITION = "partition";
    public const string PIPELINE_STEPS_GEN_EMBEDDINGS = "gen_embeddings";
    public const string PIPELINE_STEPS_SAVE_RECORDS = "save_records";
    public const string PIPELINE_STEPS_SUMMARIZE = "summarize";
    public const string PIPELINE_STEPS_DELETE_GENERATED_FILES = "delete_generated_files";
    public const string PIPELINE_STEPS_DELETE_DOCUMENT = "private_delete_document";
    public const string PIPELINE_STEPS_DELETE_INDEX = "private_delete_index";

    public static readonly string[] DefaultPipeline =
    {
        PIPELINE_STEPS_EXTRACT, PIPELINE_STEPS_PARTITION, PIPELINE_STEPS_GEN_EMBEDDINGS, PIPELINE_STEPS_SAVE_RECORDS
    };

    public static readonly string[] PipelineWithoutSummary =
    {
        PIPELINE_STEPS_EXTRACT, PIPELINE_STEPS_PARTITION, PIPELINE_STEPS_GEN_EMBEDDINGS, PIPELINE_STEPS_SAVE_RECORDS
    };

    public static readonly string[] PipelineWithSummary =
    {
        PIPELINE_STEPS_EXTRACT, PIPELINE_STEPS_PARTITION, PIPELINE_STEPS_GEN_EMBEDDINGS, PIPELINE_STEPS_SAVE_RECORDS,
        PIPELINE_STEPS_SUMMARIZE, PIPELINE_STEPS_GEN_EMBEDDINGS, PIPELINE_STEPS_SAVE_RECORDS
    };

    public static readonly string[] PipelineOnlySummary =
    {
        PIPELINE_STEPS_EXTRACT, PIPELINE_STEPS_SUMMARIZE, PIPELINE_STEPS_GEN_EMBEDDINGS, PIPELINE_STEPS_SAVE_RECORDS
    };

    public const string PROMPT_NAMES_SUMMARIZE = "summarize";
    public const string PROMPT_NAMES_ANSWER_WITH_FACTS = "answer-with-facts";
}
