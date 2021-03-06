//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class NinjaItemNameEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<INinjaItemNameListener> _listenerBuffer;

    public NinjaItemNameEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<INinjaItemNameListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.NinjaItemName)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasNinjaItemName && entity.hasNinjaItemNameListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.ninjaItemName;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.ninjaItemNameListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnNinjaItemName(e, component.value);
            }
        }
    }
}
