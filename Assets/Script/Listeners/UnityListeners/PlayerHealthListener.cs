using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthListener : MonoBehaviour, IEventListener, IAnyHealthListener
{
    private GameEntity _entity;
    private GameContext _context;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _context = Contexts.sharedInstance.game;
        _entity.AddAnyHealthListener(this);
    }

    public void OnAnyHealth(GameEntity entity, int total, int current, int recoverable)
    {
        if (entity.id.value != _context.currentPlayerId.value) return;

        var healthImg = transform.Find("HealthValueImg").GetComponent<Image>();
        var recoverableImg = transform.Find("RecoverableHealthValueImg").GetComponent<Image>();
        var text = transform.Find("HealthValueTxt").GetComponent<Text>();
        var popUpText = transform.Find("HealthPopUpWindow/HealthPopUpWindowTxt").GetComponent<Text>();

        healthImg.fillAmount = (float) current / total;
        recoverableImg.fillAmount = (float) recoverable / total;
        text.text = current + " / " + recoverable + " / " + total;
        popUpText.text = "当前生命值 ：" + current + "\n可恢复生命值 ：" + recoverable + " \n   恢复速度 ：3点 / 秒\n总生命值 ：" + total;
    }
}