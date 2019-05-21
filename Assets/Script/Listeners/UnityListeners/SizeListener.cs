using Entitas;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class SizeListener : MonoBehaviour, IEventListener, ISizeListener
{
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddSizeListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveSizeListener(this);
    }

    public void OnSize(GameEntity entity, Vector2 value)
    {
        var rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = Utilities.ToUnityEngineVector2(value);
    }
}