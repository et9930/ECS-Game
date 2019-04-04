using System;
using System.Collections.Generic;
using Entitas;

public class InitLoginSceneSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public InitLoginSceneSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CurrentScene);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCurrentScene && entity.currentScene.name == "LoginScene";
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (_context.localStorageService.instance.HasKey("login_email"))
            {
                var email = _context.localStorageService.instance.GetString("login_email");
                _context.sceneService.instance.SetInputValue("LoginEmailInput", email);
            }

            if (!_context.localStorageService.instance.HasKey("login_remember_password")) continue;
            var isRemember = _context.localStorageService.instance.GetBool("login_remember_password");
            _context.sceneService.instance.SetToggleOnState("LoginRememberPasswordToggle", isRemember);

            if (!isRemember) continue;
            if (!_context.localStorageService.instance.HasKey("login_password")) continue;
            var password = _context.localStorageService.instance.GetString("login_password");
            _context.sceneService.instance.SetInputValue("LoginPasswordInput", password);
        }
    }
}