//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity jumpAngleEntity { get { return GetGroup(GameMatcher.JumpAngle).GetSingleEntity(); } }
    public JumpAngleComponent jumpAngle { get { return jumpAngleEntity.jumpAngle; } }
    public bool hasJumpAngle { get { return jumpAngleEntity != null; } }

    public GameEntity SetJumpAngle(float newVertical, float newHorizontal) {
        if (hasJumpAngle) {
            throw new Entitas.EntitasException("Could not set JumpAngle!\n" + this + " already has an entity with JumpAngleComponent!",
                "You should check if the context already has a jumpAngleEntity before setting it or use context.ReplaceJumpAngle().");
        }
        var entity = CreateEntity();
        entity.AddJumpAngle(newVertical, newHorizontal);
        return entity;
    }

    public void ReplaceJumpAngle(float newVertical, float newHorizontal) {
        var entity = jumpAngleEntity;
        if (entity == null) {
            entity = SetJumpAngle(newVertical, newHorizontal);
        } else {
            entity.ReplaceJumpAngle(newVertical, newHorizontal);
        }
    }

    public void RemoveJumpAngle() {
        jumpAngleEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public JumpAngleComponent jumpAngle { get { return (JumpAngleComponent)GetComponent(GameComponentsLookup.JumpAngle); } }
    public bool hasJumpAngle { get { return HasComponent(GameComponentsLookup.JumpAngle); } }

    public void AddJumpAngle(float newVertical, float newHorizontal) {
        var index = GameComponentsLookup.JumpAngle;
        var component = (JumpAngleComponent)CreateComponent(index, typeof(JumpAngleComponent));
        component.Vertical = newVertical;
        component.Horizontal = newHorizontal;
        AddComponent(index, component);
    }

    public void ReplaceJumpAngle(float newVertical, float newHorizontal) {
        var index = GameComponentsLookup.JumpAngle;
        var component = (JumpAngleComponent)CreateComponent(index, typeof(JumpAngleComponent));
        component.Vertical = newVertical;
        component.Horizontal = newHorizontal;
        ReplaceComponent(index, component);
    }

    public void RemoveJumpAngle() {
        RemoveComponent(GameComponentsLookup.JumpAngle);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherJumpAngle;

    public static Entitas.IMatcher<GameEntity> JumpAngle {
        get {
            if (_matcherJumpAngle == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.JumpAngle);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherJumpAngle = matcher;
            }

            return _matcherJumpAngle;
        }
    }
}
