using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTaiRyoKuListener : MonoBehaviour, IEventListener, IAnyTaiRyoKuCurrentListener, IAnyTaiRyoKuRecoverSpeedListener
{
    private GameEntity _entity;
    private GameContext _context;

    public void RegisterListeners(IEntity entity)
    {
        _context = Contexts.sharedInstance.game;
        _entity = (GameEntity)entity;
        _entity.AddAnyTaiRyoKuCurrentListener(this);
        _entity.AddAnyTaiRyoKuRecoverSpeedListener(this);
    }

    public void OnAnyTaiRyoKuCurrent(GameEntity entity, float value)
    {
        if (entity.id.value != _context.currentPlayerId.value) return;
        if (!entity.hasTaiRyoKuCurrent || !entity.hasTaiRyoKuDeath || !entity.hasTaiRyoKuRecoverSpeed || !entity.hasTaiRyoKuTired || !entity.hasTaiRyoKuTotal) return;

        var taiRyoKuImg = transform.Find("TaiRyoKuValueImg").GetComponent<Image>();
        var taiRyoKuTiredTip = transform.Find("TaiRyoKuTiredTip").gameObject;
        var taiRyoKuDeathTip = transform.Find("TaiRyoKuDeathTip").gameObject;
        var taiRyoKuPopUpText = transform.Find("TaiRyoKuPopUpWindow/TaiRyoKuPopUpWindowValue").GetComponent<Text>();

        taiRyoKuImg.fillAmount = value / entity.taiRyoKuTotal.value;
        taiRyoKuTiredTip.SetActive(value <= entity.taiRyoKuTired.value && value > entity.taiRyoKuDeath.value);
        taiRyoKuDeathTip.SetActive(value <= entity.taiRyoKuDeath.value);
        taiRyoKuPopUpText.text = $"{value,0:F2}\n" +
                                 $"{entity.taiRyoKuRecoverSpeed.value,0:F2}点/秒\n" +
                                 $"{entity.taiRyoKuTotal.value,0:F2}\n" +
                                 $"{entity.taiRyoKuTired.value,0:F2}\n" +
                                 $"{entity.taiRyoKuDeath.value,0:F2}";
    }

    public void OnAnyTaiRyoKuRecoverSpeed(GameEntity entity, float value)
    {
        if (entity.id.value != _context.currentPlayerId.value) return;
        if (!entity.hasTaiRyoKuCurrent || !entity.hasTaiRyoKuDeath || !entity.hasTaiRyoKuRecoverSpeed || !entity.hasTaiRyoKuTired || !entity.hasTaiRyoKuTotal) return;

        var taiRyoKuPopUpText = transform.Find("TaiRyoKuPopUpWindow/TaiRyoKuPopUpWindowValue").GetComponent<Text>();

        taiRyoKuPopUpText.text = $"{entity.taiRyoKuCurrent.value,0:F2}\n" +
                                 $"{value,0:F2}点/秒\n" +
                                 $"{entity.taiRyoKuTotal.value,0:F2}\n" +
                                 $"{entity.taiRyoKuTired.value,0:F2}\n" +
                                 $"{entity.taiRyoKuDeath.value,0:F2}";
    }
}