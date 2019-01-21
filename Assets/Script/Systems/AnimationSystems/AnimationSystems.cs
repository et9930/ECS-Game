public class AnimationSystems : Feature
{
    public AnimationSystems(Contexts contexts) : base("Animation Systems")
    {
        Add(new ChangeAnimationSystem(contexts));
        Add(new PlayAnimationSystem(contexts));
    }
}

