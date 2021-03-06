//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class SelectTargetEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<ISelectTargetListener> _listenerBuffer;

    public SelectTargetEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<ISelectTargetListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.SelectTarget)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasSelectTarget && entity.hasSelectTargetListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.selectTarget;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.selectTargetListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnSelectTarget(e, component.value);
            }
        }
    }
}
