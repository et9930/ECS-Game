using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class MakeYinTimeListener : MonoBehaviour, IEventListener, IAnyMakeYinTimeListener
{
    private GameEntity _entity;
    
    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddAnyMakeYinTimeListener(this);
    }

    public void OnAnyMakeYinTime(GameEntity entity, float value)
    {
        var processImage = transform.Find("NinjutsuQTETimePorcessBar/NinjutsuQTETimeProcessBarImage").GetComponent<Image>();
        processImage.fillAmount = value / 3.00f;

        var processText = transform.Find("NinjutsuQTETimeText").GetComponent<Text>();
        processText.text = $"剩余时间：{value,0:F2}秒";
    }
}