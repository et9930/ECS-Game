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
        Add(new AnyAllocationNinjaEventSystem(contexts)); // priority: 0
        Add(new AnyBattleOverEventSystem(contexts)); // priority: 0
        Add(new BattleValueDisplayEventSystem(contexts)); // priority: 0
        Add(new AnyChaKuRaCurrentEventSystem(contexts)); // priority: 0
        Add(new AnyChaKuRaSlewRateEventSystem(contexts)); // priority: 0
        Add(new ChooseNinjaItemInfoEventSystem(contexts)); // priority: 0
        Add(new AnyCurrentFpsEventSystem(contexts)); // priority: 0
        Add(new AnyCurrentPingTimeEventSystem(contexts)); // priority: 0
        Add(new AnyCurrentPlayerUserDataEventSystem(contexts)); // priority: 0
        Add(new AnyCurrentWeaponEventSystem(contexts)); // priority: 0
        Add(new AnyHealthCurrentEventSystem(contexts)); // priority: 0
        Add(new AnyHealthRecoverableEventSystem(contexts)); // priority: 0
        Add(new AnyHealthRecoverSpeedEventSystem(contexts)); // priority: 0
        Add(new HierarchyEventSystem(contexts)); // priority: 0
        Add(new AnyJumpAngleEventSystem(contexts)); // priority: 0
        Add(new AnyJumpForceEventSystem(contexts)); // priority: 0
        Add(new LeftNumberEventSystem(contexts)); // priority: 0
        Add(new AnyLoadingSceneProcessEventSystem(contexts)); // priority: 0
        Add(new AnyLoadingSceneTextImageEventSystem(contexts)); // priority: 0
        Add(new AnyLoadPlayerEventSystem(contexts)); // priority: 0
        Add(new AnyMakeYinTimeEventSystem(contexts)); // priority: 0
        Add(new MatchReplayListItemEventSystem(contexts)); // priority: 0
        Add(new NinjaItemNameEventSystem(contexts)); // priority: 0
        Add(new NinjutsuNameEventSystem(contexts)); // priority: 0
        Add(new ParentEntityEventSystem(contexts)); // priority: 0
        Add(new PerceptionHTCItemEventSystem(contexts)); // priority: 0
        Add(new PerceptionPositionAccurateItemEventSystem(contexts)); // priority: 0
        Add(new PerceptionPositionExistItemEventSystem(contexts)); // priority: 0
        Add(new AnyPlayerChooseNinjaInfoEventSystem(contexts)); // priority: 0
        Add(new AnyPointNinjaItemMenuItemEventSystem(contexts)); // priority: 0
        Add(new AnyPointNinjutsuMenuItemEventSystem(contexts)); // priority: 0
        Add(new PositionEventSystem(contexts)); // priority: 0
        Add(new QuickActionItemConfigEventSystem(contexts)); // priority: 0
        Add(new RotationEventSystem(contexts)); // priority: 0
        Add(new ScaleEventSystem(contexts)); // priority: 0
        Add(new ScrollBarValueEventSystem(contexts)); // priority: 0
        Add(new SelectTargetEventSystem(contexts)); // priority: 0
        Add(new SelectTargetDistanceEventSystem(contexts)); // priority: 0
        Add(new SizeEventSystem(contexts)); // priority: 0
        Add(new AnyTaiRyoKuCurrentEventSystem(contexts)); // priority: 0
        Add(new AnyTaiRyoKuRecoverSpeedEventSystem(contexts)); // priority: 0
        Add(new TextEventSystem(contexts)); // priority: 0
        Add(new TowardEventSystem(contexts)); // priority: 0
    }
}
