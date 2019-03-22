using Entitas;
using Entitas.CodeGeneration.Attributes;
using Nakama;

[Game, Unique]
public class SessionComponent : IComponent
{
    public ISession value;
}