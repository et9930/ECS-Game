using System;
using Entitas;
using UnityEngine;

public class BattleSceneOverListener : MonoBehaviour, IEventListener, IAnyBattleOverListener
{
    private GameEntity _entity;
    private GameContext _context;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;
        _entity = (GameEntity)entity;
        _context = Contexts.sharedInstance.game;
        _entity.AddAnyBattleOverListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveAnyBattleOverListener(this);
    }

    public void OnAnyBattleOver(GameEntity entity, int winTeam)
    {
        var winPic = transform.Find("BattleSceneOverWin").gameObject;
        var losePic = transform.Find("BattleSceneOverLose").gameObject;
        var replayPic = transform.Find("BattleSceneOverReplayOver").gameObject;

        if (_context.isReplaying)
        {
            winPic.SetActive(false);
            losePic.SetActive(false);
            replayPic.SetActive(true);
        }
        else
        {
            var player = _context.GetEntityWithId(_context.currentPlayerId.value);
            winPic.SetActive(winTeam == player.team.value);
            losePic.SetActive(winTeam != player.team.value);
            replayPic.SetActive(false);
        }
    }
}