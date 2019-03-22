using System.Collections.Generic;
using Entitas;
using Nakama;

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
            var client = _context.nakamaClient.value;
            Login(client, e.login.email, e.login.password);
        }
    }

    private async void Login(IClient client, string email, string password)
    {
        ISession session = null;
        GameEntity loginErrorMessage = null;
        foreach (var e in _context.GetEntitiesWithName("LoginErrorMessage"))
        {
            loginErrorMessage = e;
        }
        if (loginErrorMessage == null) return;

        try
        {
            session = await client.AuthenticateEmailAsync(email, password, null, false);
        }
        catch (ApiResponseException e)
        {
            if (e.Message == "Invalid email address format.")
            {
                loginErrorMessage.ReplaceText("邮箱格式错误");
                return;
            }

            if (e.Message == "User account not found.")
            {
                loginErrorMessage.ReplaceText("该邮箱未注册");
                return;
            }

            if(e.Message == "Invalid credentials.")
            {
                loginErrorMessage.ReplaceText("密码错误");
                return;
            }

            _context.CreateEntity().ReplaceDebugMessage(e.ToString());
        }

        if (session == null)
        {
            loginErrorMessage.ReplaceText("密码错误");
            return;
        }

        _context.CreateEntity().ReplaceDebugMessage(session.ToString());
        _context.ReplaceSession(session);
        _context.ReplaceLoadScene("BattleScene");
    }
}