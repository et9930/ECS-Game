using System;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeadShotListener : MonoBehaviour, IEventListener, IAnyLoadPlayerListener
{
    private GameContext _context;
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _context = Contexts.sharedInstance.game;
        _entity = (GameEntity) entity;
        _entity.AddAnyLoadPlayerListener(this);
    }

    public void OnAnyLoadPlayer(GameEntity entity, int playerId, string playerName)
    {
        if (playerId != _context.currentPlayerId.value) return;

        var img = GetComponent<Image>();
        img.sprite = Resources.Load<Sprite>("Image/UI/HeadShot/" + playerName + "HeadShot");
    }
}