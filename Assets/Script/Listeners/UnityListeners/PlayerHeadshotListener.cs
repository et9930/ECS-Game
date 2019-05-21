using Entitas;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = System.Numerics.Vector3;

public class PlayerHeadShotListener : MonoBehaviour, IEventListener, IAnyLoadPlayerListener
{
    private GameContext _context;
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _context = Contexts.sharedInstance.game;
        _entity = (GameEntity) entity;
        _entity.AddAnyLoadPlayerListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveAnyLoadPlayerListener(this);
    }

    public void OnAnyLoadPlayer(GameEntity entity, string playerId, string playerName, Vector3 position, bool towardLeft, int team)
    {
        if (playerId != _context.currentPlayerId.value) return;

        var img = GetComponent<Image>();
        img.sprite = Resources.Load<Sprite>("Image/UI/HeadShot/" + playerName + "HeadShot");
    }
}