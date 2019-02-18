using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChaKuRaListener : MonoBehaviour, IEventListener, IAnyChaKuRaCurrentListener
{
    private GameEntity _entity;
    private GameContext _context;

    public void RegisterListeners(IEntity entity)
    {
        _context = Contexts.sharedInstance.game;
        _entity = (GameEntity) entity;
        _entity.AddAnyChaKuRaCurrentListener(this);
    }

    public void OnAnyChaKuRaCurrent(GameEntity entity, float value)
    {
        if (entity.id.value != _context.currentPlayerId.value) return;
        if (!entity.hasChaKuRaCurrent || !entity.hasChaKuRaTotal) return;

        var chaKuRaImage = transform.Find("ChaKuRaValueImg").GetComponent<Image>();
        chaKuRaImage.fillAmount = value / entity.chaKuRaTotal.value;

        var chaKuRaText = transform.Find("ChaKuRaPopUpWindow/ChaKuRaPopUpWindowValue").GetComponent<Text>();
        chaKuRaText.text = $"{value,0:F2}\n\n" +
                           $"{entity.chaKuRaTotal.value,0:F2}\n";
    }
}