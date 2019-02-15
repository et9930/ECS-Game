using System;
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
            if (_context.isJumpFreezing) return;

            foreach (var e in _context.GetGroup(GameMatcher.Id))
            {
                if (e.id.value != _context.currentPlayerId.value) continue;
                if (e.isShadow) continue;
                if (e.isBusying || !e.onTheGround.value) continue;

                if (!e.isJumping) // Start Jump
                {
                    e.ReplaceVelocity(Vector3.Zero);
                    var openJumpUiEntity = _context.CreateEntity();
                    openJumpUiEntity.ReplaceName("JumpUI");
                    openJumpUiEntity.isUiOpen = true;
                    e.isJumping = true;
                    e.ReplaceAnimation("jump_0", false);
                    _context.ReplaceJumpForce(0.0f);
                    _context.isJumpForceIncreasing = true;

                    var playerScreenPosition = _context.viewService.instance.WorldPositionToScreenPosition(e.position.value);
                    var processBarPosition = new Vector2(playerScreenPosition.X, 0);
                    if (playerScreenPosition.Y >= 40)
                    {
                        processBarPosition.Y = playerScreenPosition.Y - 40;
                    }
                    else
                    {
                        processBarPosition.Y = playerScreenPosition.Y + 140;
                    }

                    if (processBarPosition.X < 146)
                    {
                        processBarPosition.X = 146;
                    }
                    else if(processBarPosition.X > _context.viewService.instance.ScreenSize.X - 146)
                    {
                        processBarPosition.X = _context.viewService.instance.ScreenSize.X - 146;
                    }

                    var setJumpForceUiPositionEntity = _context.CreateEntity();
                    setJumpForceUiPositionEntity.ReplaceSetUiPosition("JumpForceProcess", processBarPosition);
                }
                else // ready to jump
                {
                    // Cancel Jump
                    if (_context.key.value.Cancel)
                    {
                        _context.isJumpForceIncreasing = false;
                        _context.RemoveJumpAngle();
                        _context.RemoveJumpForce();
                        e.ReplaceAnimation("jump_1", false);
                        foreach (var ui in _context.GetGroup(GameMatcher.Name))
                        {
                            if (ui.name.text != "JumpUI") continue;

                            ui.isUiClose = true;
                            break;
                        }

                        _context.isJumpFreezing = true;
                        return;
                    }

                    // Wait Force
                    if (_context.isJumpForceIncreasing)
                    {
                        _context.ReplaceJumpForce(_context.jumpForce.value + 20000 * _context.timeService.instance.GetDeltaTime());

                        if (_context.jumpForce.value >= 40000)
                        {
                            _context.isJumpForceIncreasing = false;
                        }
                    }
                    else
                    {
                        _context.ReplaceJumpForce(_context.jumpForce.value - 20000 * _context.timeService.instance.GetDeltaTime());

                        if (_context.jumpForce.value <= 0)
                        {
                            _context.isJumpForceIncreasing = true;
                        }
                    }
                }
            }
        }
        else // jump button up
        {
            foreach (var e in _context.GetGroup(GameMatcher.Id))
            {
                if (e.id.value != _context.currentPlayerId.value) continue;
                if (e.isShadow) continue;
                if (e.isBusying || !e.onTheGround.value || !e.isJumping) continue;

                e.isJumping = false;

                if (_context.isJumpFreezing)
                {
                    _context.isJumpFreezing = false;
                }
                else // jump
                {
                    foreach (var ui in _context.GetGroup(GameMatcher.Name))
                    {
                        if (ui.name.text != "JumpUI") continue;

                        ui.isUiClose = true;
                        break;
                    }

                    //var force = new Vector2((float)Math.);

                    e.ReplaceAnimation("jump_1", false);
                }
            }
        }
    }
}