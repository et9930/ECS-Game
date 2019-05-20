using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChaKuRaListener : MonoBehaviour, IEventListener, IAnyChaKuRaCurrentListener, IAnyChaKuRaSlewRateListener
{
    private GameEntity _entity;
    private GameContext _context;

    public void RegisterListeners(IEntity entity)
    {
        _context = Contexts.sharedInstance.game;
        _entity = (GameEntity) entity;
        _entity.AddAnyChaKuRaCurrentListener(this);
        _entity.AddAnyChaKuRaSlewRateListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemoveAnyChaKuRaCurrentListener(this);
        _entity.RemoveAnyChaKuRaSlewRateListener(this);
    }

    public void OnAnyChaKuRaCurrent(GameEntity entity, float value)
    {
        if (entity.id.value != _context.currentPlayerId.value) return;
        if (!entity.hasChaKuRaCurrent || !entity.hasChaKuRaTotal || !entity.hasChaKuRaSlewRate) return;

        var chaKuRaImage = transform.Find("ChaKuRaValueImg").GetComponent<Image>();
        chaKuRaImage.fillAmount = value / entity.chaKuRaTotal.value;

        var chaKuRaText = transform.Find("ChaKuRaPopUpWindow/ChaKuRaPopUpWindowValue").GetComponent<Text>();
        chaKuRaText.text = $"{value,0:F2}\n" +
                           $"{entity.chaKuRaSlewRate.value,0:F2}\n" +
                           $"{entity.chaKuRaTotal.value,0:F2}\n";
    }

    public void OnAnyChaKuRaSlewRate(GameEntity entity, float value)
    {
        if (entity.id.value != _context.currentPlayerId.value) return;
        if (!entity.hasChaKuRaCurrent || !entity.hasChaKuRaTotal || !entity.hasChaKuRaSlewRate) return;

        var chaKuRaText = transform.Find("ChaKuRaPopUpWindow/ChaKuRaPopUpWindowValue").GetComponent<Text>();
        chaKuRaText.text = $"{entity.chaKuRaCurrent.value,0:F2}\n" +
                           $"{value,0:F2}\n" +
                           $"{entity.chaKuRaTotal.value,0:F2}\n";
    }
}