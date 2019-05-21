using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class FpsListener : MonoBehaviour, IEventListener, IAnyCurrentFpsListener
{
    private bool hasRegistered = false;

    private GameEntity _entity;
    private const int _updateTimePerSecond = 2;
    private float _lastUpdateTime = 0.0f;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddAnyCurrentFpsListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveAnyCurrentFpsListener(this);
    }

    public void OnAnyCurrentFps(GameEntity entity, float value)
    {
        var currentTime = Time.realtimeSinceStartup;
        if (currentTime - _lastUpdateTime > 1.0f / _updateTimePerSecond)
        {
            GetComponent<Text>().text = "FPS: " + (int)value;
            _lastUpdateTime = currentTime;
        }
    }
}