public sealed class GameWorld : Feature
{
    public GameWorld(Contexts contexts, Services services) : base("Game World")
    {
        // Initialize Only
        Add(new ServiceRegistrationSystems(contexts, services));
        Add(new LoadGameConfigSystem(contexts));
        Add(new InitializeNetworkSystem(contexts));

        // NetWork Systems
        Add(new GetServerPingTimeSystem(contexts));
        Add(new LoginSystem(contexts));
        Add(new SignInSystem(contexts));



        // Game Event


        // Input Systems
        Add(new EmitInputSystem(contexts));
        Add(new ClickEventSystem(contexts));
        Add(new MouseInOutEventSystem(contexts));

        Add(new SendMovementControlSystem(contexts));
        Add(new SendStateDataSystem(contexts));
        Add(new SendJumpControlSystem(contexts));
        Add(new SendNormalAttackControlSystem(contexts));
        Add(new SendMakeChaKuRaControlSystem(contexts));
        Add(new SendThrowWeaponControlSystem(contexts));

        Add(new SendMatchDataSystem(contexts));
        Add(new ReceiveMatchDataSystem(contexts));


        Add(new GetReplayListSystem(contexts));
        Add(new AddReplayListItemSystem(contexts));
        Add(new DownloadReplaySystem(contexts));

        // Main Game Logic Systems
        Add(new PlayerStateControlSystem(contexts));

        //  input deal systems


        Add(new MovementControlSystem(contexts));
        Add(new JumpControlSystem(contexts));
        Add(new MakeYinSystem(contexts));
        Add(new NormalAttackControlSystem(contexts));
        Add(new NinjutsuMenuControlSystem(contexts));
        Add(new NinjaItemMenuControlSystem(contexts));
        Add(new UseNinjaItemSystem(contexts));
        Add(new PlayerTryThrowWeaponSystem(contexts));
        Add(new ThrowWeaponSystem(contexts));
        Add(new FlyingWeaponManageSystem(contexts));
        Add(new QuickActionMenuControlSystem(contexts));
        Add(new AddQuickActionItemSystem(contexts));
        Add(new QuickActionExecuteSystem(contexts));

        Add(new NinjutsuSystems(contexts));

        //  HTC systems
        Add(new MakeChaKuRaSystem(contexts));
        Add(new TaiRyoKuExpendSystem(contexts));
        Add(new ChaKuRaExpendSystem(contexts));
        Add(new HealthRecoverSystem(contexts));
        Add(new HealthReduceSystem(contexts));
        Add(new TaiRyoKuRecoverSystem(contexts));

        // taijutsu
        Add(new CheckTaijutsuAttackHitSystem(contexts));
        Add(new CheckTaijutsuAttackDodgeSystem(contexts));
        Add(new CheckTaijutsuAttackDefendSystem(contexts));
        Add(new CalculateTaijutsuAttackDamageSystem(contexts));

        //  physical systems
        Add(new PhysicalSystems(contexts));

        Add(new OnGameMatchedSystem(contexts));
        Add(new CheckJoinNumberSystem(contexts));
        Add(new PlayerReadyStateSystem(contexts));
        Add(new SwitchChooseNinjaWindowSystem(contexts));
        Add(new MatchStartSystem(contexts));

        Add(new SwitchSceneSystem(contexts));
        Add(new OpenUiSystem(contexts));
        Add(new UiFollowSystem(contexts));
        Add(new UiMoveActionSystem(contexts));
        Add(new UiFadeInOutActionSystem(contexts));
        Add(new UiRotateActionSystem(contexts));
        Add(new ChangeUiParentSystem(contexts));
        Add(new SetUiPositionSystem(contexts));
        Add(new CloseUiSystem(contexts));
        Add(new InitLoginSceneSystem(contexts));
        Add(new InitMainSceneSystem(contexts));
        Add(new InitBattleSceneSystem(contexts));

        Add(new ShadowPositionSystem(contexts));

        //
        Add(new CheckPerceptionLevelSystem(contexts));
        Add(new PerceptionPositionSystem(contexts));
        Add(new PerceptionHTCSystem(contexts));

        // Display Systems
        Add(new DisplayHierarchySystem(contexts));
        Add(new ChangeAnimationSystem(contexts));
        Add(new PlayAnimationSystem(contexts));
        Add(new AnimationEventSystems(contexts));
        Add(new AddViewSystem(contexts));
        Add(new ChangeViewSystem(contexts));

        // Output & Destroy Systems
        Add(new DebugMessageSystem(contexts));
        Add(new ErrorMessageSystem(contexts));
        Add(new GameEventSystems(contexts));
        Add(new AddNinjutsuMenuItemSystem(contexts));
        Add(new AddNinjaItemMenuItemSystem(contexts));
        Add(new DestroyEntitiesSystem(contexts));

        Add(new LoadPlayerSystem(contexts));
        Add(new AddShadowSystem(contexts));


        // Order Independence Systems
        Add(new MoveMainCameraSystem(contexts));
        Add(new CalculateFpsSystem(contexts));
    }
}