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

    public void OnAnyPlayerChooseNinjaInfo(GameEntity entity, string userId, string ninjaName)
    {
        if (userId != _entity.playerChooseNinjaInfo.userId || ninjaName == "") return;
        var headShot = transform.Find("NinjaHeadShot").GetComponent<Image>();
        headShot.sprite = Resources.Load<Sprite>("Image/UI/HeadShot/" + ninjaName + "HeadShot");
    }
}