using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class NetworkServiceComponent : IComponent
{
    public INetworkService instance;
}