public class GameWorld : Feature
{
    public GameWorld(Contexts contexts, Services services) : base("Game World")
    {
        // Initialize Only
        Add(new ServiceRegistrationSystems(contexts, services));
        Add(new LoadGameConfigSystem(contexts));

        // Input Systems
        Add(new EmitInputSystem(contexts));
        Add(new ClickEventSystem(contexts));
        Add(new MouseInOutEventSystem(contexts));

        // Main Game Logic Systems
        Add(new PlayerStateControlSystem(contexts));

        //  input deal systems
        Add(new MovementControlSystem(contexts));
        Add(new JumpControlSystem(contexts));
        Add(new NormalAttackControlSystem(contexts));
        Add(new NinjutsuMenuControlSystem(contexts));

        //  HTC systems
        Add(new MakeChaKuRaSystem(contexts));
        Add(new TaiRyoKuExpendSystem(contexts));
        Add(new ChaKuRaExpendSystem(contexts));
        Add(new HealthRecoverSystem(contexts));
        Add(new TaiRyoKuRecoverSystem(contexts));

        //  physical systems
        Add(new PhysicalSystems(contexts));

        Add(new SwitchSceneSystem(contexts));
        Add(new OpenUiSystem(contexts));
        Add(new UiFollowSystem(contexts));
        Add(new UiMoveActionSystem(contexts));
        Add(new SetUiPositionSystem(contexts));
        Add(new CloseUiSystem(contexts));
        Add(new InitBattleSceneSystem(contexts));
        Add(new AddNinjutsuMenuItemSystem(contexts));
        Add(new AnimationEventSystems(contexts));
        Add(new LoadPlayerSystem(contexts));
        Add(new AddShadowSystem(contexts));
        Add(new ShadowPositionSystem(contexts));

        // Display Systems
        Add(new DisplayHierarchySystem(contexts));
        Add(new ChangeAnimationSystem(contexts));
        Add(new PlayAnimationSystem(contexts));
        Add(new AddViewSystem(contexts));
        Add(new ChangeViewSystem(contexts));

        // Output & Destroy Systems
        Add(new DebugMessageSystem(contexts));
        Add(new ErrorMessageSystem(contexts));
        Add(new GameEventSystems(contexts));
        Add(new DestroyEntitiesSystem(contexts));

        // Order Independence Systems
        Add(new MoveMainCameraSystem(contexts));
        Add(new CalculateFpsSystem(contexts));
    }
}