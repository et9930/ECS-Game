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
            var client = _context.nakamaClient.value;
            SignIn(client, e.signIn.email, e.signIn.userName, e.signIn.password);
        }
    }

    private async void SignIn(IClient client, string email, string userName, string password)
    {
        ISession session = null;
        GameEntity signInErrorMessage = null;
        foreach (var e in _context.GetEntitiesWithName("SignInErrorMessage"))
        {
            signInErrorMessage = e;
        }
        if (signInErrorMessage == null) return;

        try
        {
            session = await client.AuthenticateEmailAsync(email, password, userName, true);
        }
        catch (ApiResponseException e)
        {
            if (e.Message == "Invalid email address format.")
            {
                signInErrorMessage.ReplaceText("邮箱格式错误");
                return;
            }
            _context.CreateEntity().ReplaceDebugMessage(e.ToString());
        }

        if (session == null || session.Username != userName || !session.Created) 
        {
            signInErrorMessage.ReplaceText("该邮箱已被注册");
            return;
        }

        _context.CreateEntity().ReplaceDebugMessage(session.ToString());
        foreach (var e in _context.GetEntitiesWithName("SignInWindow"))
        {
            e.ReplaceActive(false);
        }
    }
}