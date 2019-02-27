using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class NinjaItemMenuItemListener : MonoBehaviour, IEventListener, INinjaItemNameListener
{
    private GameContext _context;
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _context = Contexts.sharedInstance.game;
        _entity = (GameEntity) entity;
        _entity.AddNinjaItemNameListener(this);
    }

    public void OnNinjaItemName(GameEntity entity, string value)
    {
        transform.Find("NinjaItemMenuItemIcon").GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/UI/NinjaItemIcon/" + value);
    }
}