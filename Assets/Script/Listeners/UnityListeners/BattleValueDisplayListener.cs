using Entitas;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = System.Numerics.Vector3;

public class BattleValueDisplayListener : MonoBehaviour, IEventListener, IBattleValueDisplayListener
{
    private GameEntity _entity;
    private bool hasRegistered = false;
    
    public void RegisterListeners(IEntity entity)
    {
        if (hasRegistered) return;
        _entity = (GameEntity) entity;
        _entity.AddBattleValueDisplayListener(this);
        hasRegistered = true;
    }

    public void UnregisterListeners()
    {
        if (!hasRegistered) return;
        hasRegistered = false;

        _entity.RemoveBattleValueDisplayListener(this);
    }

    public void OnBattleValueDisplay(GameEntity entity, int value, int valueType, Vector3 textColor, string text, GameEntity parent)
    {
        Debug.Log("OnBattleValueDisplay" + value + " " + valueType + " " + textColor + " " + text + " " + parent.name.text);

        var battleValueText = transform.Find("BattleValueDisplayText").GetComponent<Text>();
        var battleValueNumber = transform.Find("BattleValueDisplayNumber").GetComponent<Text>();

        battleValueText.color = Utilities.ToUnityEngineColor(textColor);
        battleValueText.text = text;

        Font font;
        switch (valueType)
        {
            case 1:
                font = Resources.Load<Font>("Font/ChaKuRaValueFont");
                battleValueNumber.font = font;
                break;
            case 2:
                font = Resources.Load<Font>("Font/DamageValueFont");
                battleValueNumber.font = font;
                break;
            case 3:
                font = Resources.Load<Font>("Font/HealthValueFont");
                battleValueNumber.font = font;
                break;
            case 4:
                font = Resources.Load<Font>("Font/TaiRyoKuValueFont");
                battleValueNumber.font = font;
                break;
            default:
                break;
        }

        battleValueNumber.text = value > 0 ? value.ToString() : "";

    }
}