using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Any)]
public class LoadingSceneTextImageComponent : IComponent
{
    public string title;
    public string text;
    public string imagePath;
}