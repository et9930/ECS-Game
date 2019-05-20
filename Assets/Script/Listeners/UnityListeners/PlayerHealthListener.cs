using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthListener : MonoBehaviour, IEventListener, IAnyHealthCurrentListener, IAnyHealthRecoverSpeedListener, IAnyHealthRecoverableListener
{
    private GameEntity _entity;
    private GameContext _context;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _context = Contexts.sharedInstance.game;
        _entity.AddAnyHealthCurrentListener(this);
        _entity.AddAnyHealthRecoverSpeedListener(this);
        _entity.AddAnyHealthRecoverableListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveAnyHealthCurrentListener(this);
        _entity.RemoveAnyHealthRecoverSpeedListener(this);
        _entity.RemoveAnyHealthRecoverableListener(this);
    }

    public void OnAnyHealthCurrent(GameEntity entity, float value)
    {
        if (entity.id.value != _context.currentPlayerId.value) return;
        if (!entity.hasHealthRecoverable || !entity.hasHealthRecoverSpeed || !entity.hasHealthTotal) return;

        var healthImg = transform.Find("HealthValueImg").GetComponent<Image>();
        var text = transform.Find("HealthValueTxt").GetComponent<Text>();
        var popUpText = transform.Find("HealthPopUpWindow/HealthPopUpWindowValue").GetComponent<Text>();

        healthImg.fillAmount = value / entity.healthTotal.value;
        text.text = (int)value + " / " + (int)entity.healthRecoverable.value + " / " + (int)entity.healthTotal.value;
        popUpText.text = $"{value,0:F2}\n" + 
                         $"{entity.healthRecoverable.value,0:F2}\n" +
                         $"{entity.healthRecoverSpeed.value,0:F2}点/秒\n" + 
                         $"{entity.healthTotal.value,0:F2}";
    }

    public void OnAnyHealthRecoverSpeed(GameEntity entity, float value)
    {
        if (entity.id.value != _context.currentPlayerId.value) return;
        if (!entity.hasHealthRecoverable || !entity.hasHealthCurrent || !entity.hasHealthTotal) return;

        var popUpText = transform.Find("HealthPopUpWindow/HealthPopUpWindowValue").GetComponent<Text>();
        popUpText.text = $"{entity.healthCurrent.value,0:F2}\n" +
                         $"{entity.healthRecoverable.value,0:F2}\n" +
                         $"{value,0:F2}点/秒\n" +
                         $"{entity.healthTotal.value,0:F2}";
    }

    public void OnAnyHealthRecoverable(GameEntity entity, float value)
    {
        if (entity.id.value != _context.currentPlayerId.value) return;
        if (!entity.hasHealthCurrent || !entity.hasHealthRecoverSpeed || !entity.hasHealthTotal) return;

        var recoverableImg = transform.Find("RecoverableHealthValueImg").GetComponent<Image>();
        var text = transform.Find("HealthValueTxt").GetComponent<Text>();
        var popUpText = transform.Find("HealthPopUpWindow/HealthPopUpWindowValue").GetComponent<Text>();

        recoverableImg.fillAmount = (float)value / entity.healthTotal.value;
        text.text = (int)entity.healthCurrent.value + " / " + (int)value + " / " + (int)entity.healthTotal.value;
        popUpText.text = $"{entity.healthCurrent.value,0:F2}\n" +
                         $"{value,0:F2}\n" +
                         $"{entity.healthRecoverSpeed.value,0:F2}点/秒\n" +
                         $"{entity.healthTotal.value,0:F2}";
    }
}