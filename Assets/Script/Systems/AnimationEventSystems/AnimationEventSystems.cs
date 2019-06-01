public class AnimationEventSystems : Feature
{
    public AnimationEventSystems(Contexts contexts) : base("Animation Event Systems")
    {
        Add(new CharacterNamikazeMinatoAESystem(contexts));
        Add(new CharacterUchihaMadaraAESystem(contexts));
        Add(new EffectAESystem(contexts));
    }
}