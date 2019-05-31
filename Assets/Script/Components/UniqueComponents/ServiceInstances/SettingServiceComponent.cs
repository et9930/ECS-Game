using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class SettingServiceComponent : IComponent
{
    public ISettingService instance;
}