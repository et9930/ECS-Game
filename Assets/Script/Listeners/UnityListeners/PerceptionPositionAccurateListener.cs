using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PerceptionPositionAccurateListener : MonoBehaviour, IEventListener, IPerceptionPositionAccurateItemListener
{
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddPerceptionPositionAccurateItemListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemovePerceptionPositionAccurateItemListener(this);
    }

    public void OnPerceptionPositionAccurateItem(GameEntity entity, string name, bool left, float y, int distance)
    {
        var headShot = transform.Find("PerceptionPositionAccurateImage").GetComponent<Image>();
        var distanceText = transform.Find("PerceptionPositionAccurateText").GetComponent<Text>();
        var position = transform.localPosition;

        headShot.sprite = Resources.Load<Sprite>("Image/UI/HeadShot/" + name + "HeadShot");
        distanceText.text = distance + "m";
        position.y = y - 540;
        transform.localPosition = position;
    }
}