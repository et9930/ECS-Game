using Entitas;
using Nakama;

public class InitializeNetworkSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public InitializeNetworkSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        var client = new Client("NarutoKey", "127.0.0.1", 8000);
        _context.ReplaceNakamaClient(client);
    }
}