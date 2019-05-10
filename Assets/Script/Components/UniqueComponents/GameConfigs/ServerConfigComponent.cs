using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class ServerConfigComponent : IComponent
{
    public ServerConfig value;
}