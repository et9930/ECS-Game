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
        if (!_context.hasCurrentPlayerId) return;

        if (_context.key.value.Jump)
        {
            if (_context.isJumpFreezing) return;

            foreach (var e in _context.GetEntitiesWithId(_context.currentPlayerId.value))
            {
                if (e.isShadow) continue;
                if (e.isNormalAttacking || !e.onTheGround.value || e.isMakingYin) continue;

                if (!e.isJumping) // Start Jump
                {
                    e.ReplaceVelocity(Vector3.Zero);
                    var openJumpUiEntity = _context.CreateEntity();
                    openJumpUiEntity.ReplaceName("JumpUI");
                    openJumpUiEntity.ReplaceParentEntity(e);
                    openJumpUiEntity.ReplaceUiOpen("JumpUI");
                    e.isJumping = true;
                    e.ReplaceAnimation("jump_0", false);
                    _context.ReplaceJumpForce(0.0f);
                    _context.isJumpForceIncreasing = true;
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
                        foreach (var ui in _context.GetEntitiesWithName("JumpUI"))
                        {
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

                    // vertical angle
                    var playerScreenPosition = _context.viewService.instance.WorldPositionToScreenPosition(e.position.value);
                    var mouseScreenPosition = _context.mouseCurrentPosition.value;

                    var verticalAngle = Math.Atan((mouseScreenPosition.Y - playerScreenPosition.Y) / (mouseScreenPosition.X - playerScreenPosition.X)) * (180 / Math.PI);
                    if (mouseScreenPosition.Y >= playerScreenPosition.Y)
                    {
                        if (mouseScreenPosition.X <= playerScreenPosition.X)
                        {
                            verticalAngle += 180;
                        }

                    }
                    else
                    {
                        verticalAngle = mouseScreenPosition.X <= playerScreenPosition.X ? 135 : 45;
                    }

                    // horizontal angle
                    var horizontalAngle = 0.0f;
                    if (_context.hasJumpAngle)
                    {
                        horizontalAngle = _context.jumpAngle.Horizontal;
                    }

                    if (_context.key.value.Vertical > 0)
                    {
                        
                        if (_context.key.value.Horizontal > 0)
                        {
                            e.ReplaceToward(false);
                            horizontalAngle = 45.0f;
                        }
                        else if (_context.key.value.Horizontal < 0)
                        {
                            e.ReplaceToward(true);
                            horizontalAngle = 135.0f;
                        }
                        else
                        {
                            horizontalAngle = 90.0f;
                        }
                    }
                    else if (_context.key.value.Vertical < 0)
                    {
                        if (_context.key.value.Horizontal > 0)
                        {
                            e.ReplaceToward(false);
                            horizontalAngle = 315.0f;
                        }
                        else if (_context.key.value.Horizontal < 0)
                        {
                            e.ReplaceToward(true);
                            horizontalAngle = 225.0f;
                        }
                        else
                        {
                            horizontalAngle = 270.0f;
                        }
                    }
                    else
                    {
                        if (_context.key.value.Horizontal > 0)
                        {
                            e.ReplaceToward(false);
                            horizontalAngle = 0.0f;
                        }
                        else if (_context.key.value.Horizontal < 0)
                        {
                            e.ReplaceToward(true);
                            horizontalAngle = 180.0f;
                        }
                    }
                    _context.ReplaceJumpAngle((float)verticalAngle, horizontalAngle);
                }
            }
        }
        else // jump button up
        {
            foreach (var e in _context.GetEntitiesWithId(_context.currentPlayerId.value))
            {
                if (e.isShadow) continue;
                if (e.isNormalAttacking || !e.onTheGround.value || !e.isJumping) continue;

                e.isJumping = false;

                if (_context.isJumpFreezing)
                {
                    _context.isJumpFreezing = false;
                }
                else // jump
                {
                    foreach (var ui in _context.GetEntitiesWithName("JumpUI"))
                    {
                        ui.isUiClose = true;
                        break;
                    }

                    //var force = new Vector2((float)Math.);
                    var tmpForce = (float)(_context.jumpForce.value * Math.Cos(_context.jumpAngle.Vertical * Math.PI / 180));
                    var force = new Vector3
                    {
                        Y = (float) (_context.jumpForce.value * Math.Sin(_context.jumpAngle.Vertical * Math.PI / 180)),
                        X = (float) (tmpForce * Math.Cos(_context.jumpAngle.Horizontal * Math.PI / 180)) * (e.toward.left ? -1 : 1),
                        Z = (float) (tmpForce * Math.Sin(_context.jumpAngle.Horizontal * Math.PI / 180))
                    };
                    
                    e.ReplaceAddForce(force, 0.04f);
                    _context.CreateEntity().ReplaceDebugMessage(force + "");

                    e.ReplaceAnimation("jump_1", false);
                }
            }
        }
    }
}