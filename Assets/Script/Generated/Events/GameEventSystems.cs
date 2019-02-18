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
        Add(new AnyChaKuRaCurrentEventSystem(contexts)); // priority: 0
        Add(new AnyCurrentFpsEventSystem(contexts)); // priority: 0
        Add(new AnyHealthCurrentEventSystem(contexts)); // priority: 0
        Add(new AnyHealthRecoverableEventSystem(contexts)); // priority: 0
        Add(new AnyHealthRecoverSpeedEventSystem(contexts)); // priority: 0
        Add(new HierarchyEventSystem(contexts)); // priority: 0
        Add(new AnyJumpAngleEventSystem(contexts)); // priority: 0
        Add(new AnyJumpForceEventSystem(contexts)); // priority: 0
        Add(new AnyLoadingSceneProcessEventSystem(contexts)); // priority: 0
        Add(new AnyLoadingSceneTextImageEventSystem(contexts)); // priority: 0
        Add(new AnyLoadPlayerEventSystem(contexts)); // priority: 0
        Add(new PositionEventSystem(contexts)); // priority: 0
        Add(new ScaleEventSystem(contexts)); // priority: 0
        Add(new AnyTaiRyoKuCurrentEventSystem(contexts)); // priority: 0
        Add(new AnyTaiRyoKuRecoverSpeedEventSystem(contexts)); // priority: 0
        Add(new TextEventSystem(contexts)); // priority: 0
        Add(new TowardEventSystem(contexts)); // priority: 0
    }
}
