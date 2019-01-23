public class AnimationEventSystems : Feature
{
    public AnimationEventSystems(Contexts contexts) : base("Animation Event Systems")
    {
        Add(new CharacterMinatoAESystem(contexts));
    }
}