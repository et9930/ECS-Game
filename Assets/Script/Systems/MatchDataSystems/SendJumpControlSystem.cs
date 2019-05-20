using Entitas;
using System;
using System.Numerics;

public class SendJumpControlSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public SendJumpControlSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.currentScene.name != "BattleScene") return;
        if (!_context.hasCurrentPlayerId) return;

        if (_context.key.value.Jump)
        {
            if (_context.isJumpFreezing) return;

            var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
            if (currentPlayer == null) return;
            

            if (currentPlayer.isNormalAttacking || !currentPlayer.onTheGround.value ||
                currentPlayer.isMakingYin) return;
          

            if (!currentPlayer.isJumping) // Start Jump
            {
                var newJumpControl = new MatchDataJumpControl
                {
                    matchId = _context.currentMatchData.value.customMatchId,
                    userId = _context.currentPlayerId.value,
                    state = 0,
                };
                var openJumpUiEntity = _context.CreateEntity();
                openJumpUiEntity.ReplaceName("JumpUI");
                openJumpUiEntity.ReplaceParentEntity(currentPlayer);
                openJumpUiEntity.ReplaceUiOpen("JumpUI");
                _context.ReplaceJumpForce(0.0f);
                _context.isJumpForceIncreasing = true;
                _context.CreateEntity().ReplaceSendMatchData(1003, Utilities.ToJson(newJumpControl));
                currentPlayer.isJumping = true;
            }
            else
            {
                if (_context.key.value.Cancel)
                {
                    var newJumpControl = new MatchDataJumpControl
                    {
                        matchId = _context.currentMatchData.value.customMatchId,
                        userId = _context.currentPlayerId.value,
                        state = 1,
                    };
                    _context.isJumpFreezing = true;
                    _context.isJumpForceIncreasing = false;
                    _context.RemoveJumpAngle();
                    _context.RemoveJumpForce();
                    foreach (var ui in _context.GetEntitiesWithName("JumpUI"))
                    {
                        ui.isUiClose = true;
                        break;
                    }
                    _context.CreateEntity().ReplaceSendMatchData(1003, Utilities.ToJson(newJumpControl));

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
                var playerScreenPosition = _context.viewService.instance.WorldPositionToScreenPosition(currentPlayer.position.value);
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
//                        currentPlayer.ReplaceToward(false);
                        var newTowardControl = new MatchDataTowardControl
                        {
                            matchId = _context.currentMatchData.value.customMatchId,
                            userId = _context.currentPlayerId.value,
                            faceLeft = false
                        };
                        if (currentPlayer.toward.left != newTowardControl.faceLeft)
                        {
                            _context.CreateEntity().ReplaceSendMatchData(1005, Utilities.ToJson(newTowardControl));
                        }
                        horizontalAngle = 45.0f;
                    }
                    else if (_context.key.value.Horizontal < 0)
                    {
//                        currentPlayer.ReplaceToward(true);
                        var newTowardControl = new MatchDataTowardControl
                        {
                            matchId = _context.currentMatchData.value.customMatchId,
                            userId = _context.currentPlayerId.value,
                            faceLeft = true
                        };
                        if (currentPlayer.toward.left != newTowardControl.faceLeft)
                        {
                            _context.CreateEntity().ReplaceSendMatchData(1005, Utilities.ToJson(newTowardControl));
                        }

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
//                        currentPlayer.ReplaceToward(false);
                        var newTowardControl = new MatchDataTowardControl
                        {
                            matchId = _context.currentMatchData.value.customMatchId,
                            userId = _context.currentPlayerId.value,
                            faceLeft = false
                        };
                        if (currentPlayer.toward.left != newTowardControl.faceLeft)
                        {
                            _context.CreateEntity().ReplaceSendMatchData(1005, Utilities.ToJson(newTowardControl));
                        }

                        horizontalAngle = 315.0f;
                    }
                    else if (_context.key.value.Horizontal < 0)
                    {
//                        currentPlayer.ReplaceToward(true);
                        var newTowardControl = new MatchDataTowardControl
                        {
                            matchId = _context.currentMatchData.value.customMatchId,
                            userId = _context.currentPlayerId.value,
                            faceLeft = true
                        };
                        if (currentPlayer.toward.left != newTowardControl.faceLeft)
                        {
                            _context.CreateEntity().ReplaceSendMatchData(1005, Utilities.ToJson(newTowardControl));
                        }

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
//                        currentPlayer.ReplaceToward(false);
                        var newTowardControl = new MatchDataTowardControl
                        {
                            matchId = _context.currentMatchData.value.customMatchId,
                            userId = _context.currentPlayerId.value,
                            faceLeft = false
                        };
                        if (currentPlayer.toward.left != newTowardControl.faceLeft)
                        {
                            _context.CreateEntity().ReplaceSendMatchData(1005, Utilities.ToJson(newTowardControl));
                        }

                        horizontalAngle = 0.0f;
                    }
                    else if (_context.key.value.Horizontal < 0)
                    {
//                        currentPlayer.ReplaceToward(true);
                        var newTowardControl = new MatchDataTowardControl
                        {
                            matchId = _context.currentMatchData.value.customMatchId,
                            userId = _context.currentPlayerId.value,
                            faceLeft = true
                        };
                        if (currentPlayer.toward.left != newTowardControl.faceLeft)
                        {
                            _context.CreateEntity().ReplaceSendMatchData(1005, Utilities.ToJson(newTowardControl));
                        }

                        horizontalAngle = 180.0f;
                    }
                }
                _context.ReplaceJumpAngle((float)verticalAngle, horizontalAngle);

            }
        }
        else
        {
            var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);
            if (currentPlayer == null) return;

            if (currentPlayer.isNormalAttacking || !currentPlayer.onTheGround.value || !currentPlayer.isJumping) return;
            currentPlayer.isJumping = false;
            if (_context.isJumpFreezing)
            {
                _context.isJumpFreezing = false;
            }
            else
            {
                foreach (var ui in _context.GetEntitiesWithName("JumpUI"))
                {
                    ui.isUiClose = true;
                    break;
                }

                var tmpForce = (float)(_context.jumpForce.value * Math.Cos(_context.jumpAngle.Vertical * Math.PI / 180));
                var force = new Vector3
                {
                    Y = (float)(_context.jumpForce.value * Math.Sin(_context.jumpAngle.Vertical * Math.PI / 180)),
                    X = (float)(tmpForce * Math.Cos(_context.jumpAngle.Horizontal * Math.PI / 180)) * (currentPlayer.toward.left ? -1 : 1),
                    Z = (float)(tmpForce * Math.Sin(_context.jumpAngle.Horizontal * Math.PI / 180))
                };

                var newJumpControl = new MatchDataJumpControl
                {
                    matchId = _context.currentMatchData.value.customMatchId,
                    userId = _context.currentPlayerId.value,
                    state = 2,
                    force = force
                };
                _context.CreateEntity().ReplaceSendMatchData(1003, Utilities.ToJson(newJumpControl));

            }
        }
    }
}