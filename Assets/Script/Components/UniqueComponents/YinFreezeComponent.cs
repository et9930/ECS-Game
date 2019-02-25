using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class YinFreezeComponent : IComponent
{
    public bool Yin1Freezing;
    public bool Yin2Freezing;
    public bool Yin3Freezing;
    public bool Yin4Freezing;
    public bool Yin5Freezing;
    public bool Yin6Freezing;
    public bool YinCompleteFreezing;
}