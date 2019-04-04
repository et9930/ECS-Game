//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts : Entitas.IContexts {

    public static Contexts sharedInstance {
        get {
            if (_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public GameContext game { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { game }; } }

    public Contexts() {
        game = new GameContext();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.CodeGeneration.Attributes.PostConstructorAttribute))
        );

        foreach (var postConstructor in postConstructors) {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) {
            contexts[i].Reset();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EntityIndexGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

    public const string Id = "Id";
    public const string Name = "Name";
    public const string Tag = "Tag";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeEntityIndices() {
        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, string>(
            Id,
            game.GetGroup(GameMatcher.Id),
            (e, c) => ((IdComponent)c).value));

        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, string>(
            Name,
            game.GetGroup(GameMatcher.Name),
            (e, c) => ((NameComponent)c).text));

        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, string>(
            Tag,
            game.GetGroup(GameMatcher.Tag),
            (e, c) => ((TagComponent)c).value));
    }
}

public static class ContextsExtensions {

    public static GameEntity GetEntityWithId(this GameContext context, string value) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, string>)context.GetEntityIndex(Contexts.Id)).GetEntity(value);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithName(this GameContext context, string text) {
        return ((Entitas.EntityIndex<GameEntity, string>)context.GetEntityIndex(Contexts.Name)).GetEntities(text);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithTag(this GameContext context, string value) {
        return ((Entitas.EntityIndex<GameEntity, string>)context.GetEntityIndex(Contexts.Tag)).GetEntities(value);
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.VisualDebugging.CodeGeneration.Plugins.ContextObserverGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeContextObservers() {
        try {
            CreateContextObserver(game);
        } catch(System.Exception) {
        }
    }

    public void CreateContextObserver(Entitas.IContext context) {
        if (UnityEngine.Application.isPlaying) {
            var observer = new Entitas.VisualDebugging.Unity.ContextObserver(context);
            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
        }
    }

#endif
}
