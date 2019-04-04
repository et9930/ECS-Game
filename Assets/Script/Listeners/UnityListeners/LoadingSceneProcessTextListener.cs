using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceneProcessTextListener : MonoBehaviour, IEventListener, IAnyLoadingSceneProcessListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddAnyLoadingSceneProcessListener(this);
    }

    public void OnAnyLoadingSceneProcess(GameEntity entity, float value)
    {
        gameObject.GetComponent<Text>().text = value.ToString("P") + " 加载中。。。";
    }
}