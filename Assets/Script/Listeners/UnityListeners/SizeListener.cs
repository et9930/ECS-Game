using Entitas;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class SizeListener : MonoBehaviour, IEventListener, ISizeListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddSizeListener(this);
    }

    public void OnSize(GameEntity entity, Vector2 value)
    {
        var rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = Utilities.ToUnityEngineVector2(value);
    }
}