namespace AISmarteasy.Core;

public abstract class VectorDatabaseSkill
{
    protected IVectorDatabaseConnector? Connector { get; set; }
}
