//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class LeftNumberEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<ILeftNumberListener> _listenerBuffer;

    public LeftNumberEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<ILeftNumberListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.LeftNumber)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasLeftNumber && entity.hasLeftNumberListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.leftNumber;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.leftNumberListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnLeftNumber(e, component.value);
            }
        }
    }
}
