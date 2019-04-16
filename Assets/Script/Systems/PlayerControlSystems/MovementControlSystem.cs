using System.Numerics;
using Entitas;

public class MovementControlSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public MovementControlSystem(Contexts contexts)
    {
        _context = contexts.game;
    }
    
    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;
        if (!_context.hasCurrentPlayerId) return;
        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
        if (currentPlayer == null) return;

        if (!currentPlayer.onTheGround.value || currentPlayer.isNormalAttacking || currentPlayer.isJumping) return;

        if (_context.key.value.Horizontal != 0.0f || _context.key.value.Vertical != 0.0f)
        {
            currentPlayer.isMoving = true;
            if(currentPlayer.currentAnimation.name == "idle")
                currentPlayer.ReplaceAnimation("move", true);
                    
        }
        else
        {
            currentPlayer.isMoving = false;
            if(currentPlayer.currentAnimation.name == "move")
                currentPlayer.ReplaceAnimation("idle", true);
        }

        var tmpHorizontal = _context.key.value.Horizontal * _context.characterBaseAttributes.dic[currentPlayer.name.text].baseVelocity;
        var tmpVertical = _context.key.value.Vertical * _context.characterBaseAttributes.dic[currentPlayer.name.text].baseVelocity;
        currentPlayer.ReplaceVelocity(new Vector3(tmpHorizontal, 0, tmpVertical));

        if (_context.key.value.Horizontal > 0)
        {
            currentPlayer.ReplaceToward(false);
        }
        else if (_context.key.value.Horizontal < 0)
        {
            currentPlayer.ReplaceToward(true);
        }
    }
}