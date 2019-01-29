public class GameWorld : Feature
{
    public GameWorld(Contexts contexts, Services services) : base("Game World")
    {
        Add(new ServiceRegistrationSystems(contexts, services));
        Add(new GameEventSystems(contexts));
        Add(new LoadGameConfigSystem(contexts));

        Add(new EmitInputSystem(contexts));

        Add(new MovementControlSystem(contexts));
        Add(new NormalAttackControlSystem(contexts));

        Add(new SwitchSceneSystem(contexts));
        Add(new OpenUiSystem(contexts));
        Add(new CloseUiSystem(contexts));
        Add(new InitBattleSceneSystem(contexts));
        Add(new AnimationEventSystems(contexts));
        Add(new LoadPlayerSystem(contexts));

        Add(new ChangeAnimationSystem(contexts));
        Add(new PlayAnimationSystem(contexts));
        Add(new AddViewSystem(contexts));
        Add(new ChangeViewSystem(contexts));

        Add(new DebugMessageSystem(contexts));
        Add(new DestroyNoGameObjectEntitySystem(contexts));

        Add(new MoveMainCameraSystem(contexts));

        Add(new CalculateFpsSystem(contexts));
    }
}