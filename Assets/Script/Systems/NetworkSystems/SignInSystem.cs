using System;
using System.Collections.Generic;
using Entitas;
using Nakama;

public class SignInSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public SignInSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SignIn);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSignIn && !entity.isDestroy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            SignIn(e.signIn.email, e.signIn.userName, e.signIn.password);
        }
    }

    private async void SignIn(string email, string userName, string password)
    {
        GameEntity signInErrorMessage = null;
        foreach (var e in _context.GetEntitiesWithName("SignInErrorMessage"))
        {
            signInErrorMessage = e;
        }
        if (signInErrorMessage == null) return;

        int returnCode;

        try
        {
            returnCode = await _context.networkService.instance.SignIn(email, userName, password);

        }
        catch (Exception)
        {
            signInErrorMessage.ReplaceText("网络错误");
            return;
        }

        switch (returnCode)
        {
            case 400:
                foreach (var e in _context.GetEntitiesWithName("SignInWindow"))
                {
                    e.ReplaceActive(false);
                }
                return;
            case 401:
                signInErrorMessage.ReplaceText("邮箱格式错误");
                return;
            case 405:
                signInErrorMessage.ReplaceText("该邮箱已被注册");
                return;
            case 406:
                signInErrorMessage.ReplaceText("网络错误");
                return;
            default:
                return;
        }
    }
}