using Entitas;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = System.Numerics.Vector3;

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

    public void UnregisterListeners()
    {
        _entity.RemoveAnyLoadPlayerListener(this);
    }

    public void OnAnyLoadPlayer(GameEntity entity, string playerId, string playerName, Vector3 position, bool towardLeft, int team)
    {
        if (playerId != _context.currentPlayerId.value) return;

        var img = GetComponent<Image>();
        img.sprite = Resources.Load<Sprite>("Image/UI/HeadShot/" + playerName + "HeadShot");
    }
}