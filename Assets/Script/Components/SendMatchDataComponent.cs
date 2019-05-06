using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class SendMatchDataComponent : IComponent
{
    public long dataCode;
    public string payload;
}