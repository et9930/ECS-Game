using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class MakeYinTimeListener : MonoBehaviour, IEventListener, IAnyMakeYinTimeListener
{
    private GameEntity _entity;
    private bool hasRegistered = false;

    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;

        _entity = (GameEntity) entity;
        _entity.AddAnyMakeYinTimeListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveAnyMakeYinTimeListener(this);
    }

    public void OnAnyMakeYinTime(GameEntity entity, float value)
    {
        var processImage = transform.Find("NinjutsuQTETimePorcessBar/NinjutsuQTETimeProcessBarImage").GetComponent<Image>();
        processImage.fillAmount = value / 3.00f;

        var processText = transform.Find("NinjutsuQTETimeText").GetComponent<Text>();
        processText.text = $"剩余时间：{value,0:F2}秒";
    }
}