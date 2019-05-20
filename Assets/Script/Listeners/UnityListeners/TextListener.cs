using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class TextListener : MonoBehaviour, IEventListener, ITextListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity)entity;
        _entity.AddTextListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveTextListener(this);
    }

    public void OnText(GameEntity entity, string value)
    {
        gameObject.GetComponent<Text>().text = value;
    }
}