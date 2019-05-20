using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChooseItemListener : MonoBehaviour, IEventListener, IAnyPlayerChooseNinjaInfoListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddAnyPlayerChooseNinjaInfoListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveAnyPlayerChooseNinjaInfoListener(this);
    }

    public void OnAnyPlayerChooseNinjaInfo(GameEntity entity, string userId, string ninjaName, bool confirm)
    {
        if (userId != _entity.playerChooseNinjaInfo.userId) return;

        var headShot = transform.Find("NinjaHeadShot").GetComponent<Image>();

        if (ninjaName == "")
        {
            headShot.color = Color.clear;
        }
        else
        {
            headShot.color = Color.white;
            headShot.sprite = Resources.Load<Sprite>("Image/UI/HeadShot/" + ninjaName + "HeadShot");
        }

        transform.Find("Confirm").gameObject.SetActive(confirm);

        if (entity != _entity)
        {
            entity.isDestroy = true;
        }
    }
}