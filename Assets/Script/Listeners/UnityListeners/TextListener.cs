using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class TextListener : MonoBehaviour, IEventListener, ITextListener
{
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity)entity;
        _entity.AddTextListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveTextListener(this);
    }

    public void OnText(GameEntity entity, string value)
    {
        gameObject.GetComponent<Text>().text = value;
    }
}