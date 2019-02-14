using System.Numerics;
using Entitas;

public class JumpControlSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public JumpControlSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.key.value.Jump)
        {
            foreach (var e in _context.GetGroup(GameMatcher.Id))
            {
                if (e.id.value != _context.currentPlayerId.value) continue;
                if (e.isShadow) continue;
                if (e.isBusying || !e.onTheGround.value) continue;

//                e.ReplaceVelocity(new Vector3(0, 10, 0));
//                e.ReplaceAddForce(new Vector3(40000, 40000, 0), 0.01f);
            }
        }
    }
}