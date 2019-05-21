using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class NinjaItemMenuItemListener : MonoBehaviour, IEventListener, INinjaItemNameListener, IActiveListener, ILeftNumberListener
{
    private GameContext _context;
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _context = Contexts.sharedInstance.game;
        _entity = (GameEntity) entity;
        _entity.AddNinjaItemNameListener(this);
        _entity.AddActiveListener(this);
        _entity.AddLeftNumberListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveNinjaItemNameListener(this);
        _entity.RemoveActiveListener(this);
        _entity.RemoveLeftNumberListener(this);
    }

    public void OnNinjaItemName(GameEntity entity, string value)
    {
        transform.Find("NinjaItemMenuItemIcon").GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/UI/NinjaItemIcon/" + value);
    }


    public void OnActive(GameEntity entity, bool value)
    {
        transform.Find("NinjaItemMenuItemSelected").gameObject.SetActive(value);
    }
    
    public void OnLeftNumber(GameEntity entity, int value)
    {
        if (value < 0) return;

        transform.Find("NinjaItemMenuItemLeftNum").GetComponent<Text>().text = value.ToString();
        transform.Find("NinjaItemMenuItemIcon").GetComponent<Image>().color = value == 0 ? new Color(1, 1, 1, 0.4f) : new Color(1, 1, 1, 1);
    }
}