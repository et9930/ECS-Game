using Entitas;
using Entitas.CodeGeneration.Attributes;
using Nakama;

[Game, Unique]
public class NakamaClientComponent : IComponent
{
    public IClient value;
}