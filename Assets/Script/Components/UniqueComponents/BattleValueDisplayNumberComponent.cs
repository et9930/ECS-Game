using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class BattleValueDisplayNumberComponent : IComponent
{
    public int value;
}