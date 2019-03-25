using System;
using System.Collections.Generic;
using Entitas;

public class LoginSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public LoginSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Login);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasLogin && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            Login(e.login.email, e.login.password);
        }
    }

    private async void Login(string email, string password)
    {
        GameEntity loginErrorMessage = null;
        foreach (var e in _context.GetEntitiesWithName("LoginErrorMessage"))
        {
            loginErrorMessage = e;
        }
        if (loginErrorMessage == null) return;

        int returnCode;

        try
        {
            returnCode = await _context.networkService.instance.Login(email, password);

        }
        catch (Exception)
        {
            loginErrorMessage.ReplaceText("网络错误");
            return;
        }

        switch (returnCode)
        {
            case 400:
                _context.ReplaceLoadScene("MainScene");
                return;
            case 401:
                loginErrorMessage.ReplaceText("邮箱格式错误");
                return;
            case 402:
                loginErrorMessage.ReplaceText("该邮箱未注册");
                return;
            case 403:
                loginErrorMessage.ReplaceText("密码错误");
                return;
            case 404:
                loginErrorMessage.ReplaceText("网络错误");
                return;
            default:
                return;
        }
    }
}