//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameEventSystems : Feature {

    public GameEventSystems(Contexts contexts) {
        Add(new ActiveEventSystem(contexts)); // priority: 0
        Add(new AnyLoadingSceneProcessEventSystem(contexts)); // priority: 0
        Add(new AnyLoadingSceneTextImageEventSystem(contexts)); // priority: 0
        Add(new PositionEventSystem(contexts)); // priority: 0
        Add(new ScaleEventSystem(contexts)); // priority: 0
        Add(new TextEventSystem(contexts)); // priority: 0
    }
}
