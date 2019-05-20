using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PerceptionHTCListener : MonoBehaviour, IEventListener, IPerceptionHTCItemListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddPerceptionHTCItemListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemovePerceptionHTCItemListener(this);
    }

    public void OnPerceptionHTCItem(GameEntity entity, float healthPercent, float taiRyoKuPercent, float chaKuRaPercent)
    {
        var healthRoot = transform.Find("PerceptionHealth");
        var taiRyoKuRoot = transform.Find("PerceptionTaiRyoKu");
        var chaKuRaRoot = transform.Find("PerceptionChaKuRa");

        healthRoot.gameObject.SetActive(healthPercent >= 0.0f);
        taiRyoKuRoot.gameObject.SetActive(taiRyoKuPercent >= 0.0f);
        chaKuRaRoot.gameObject.SetActive(chaKuRaPercent >= 0.0f);

        if (healthPercent >= 0)
        {
            healthRoot.Find("PerceptionHealthValue").GetComponent<Image>().fillAmount = healthPercent;
        }
        if (healthPercent >= 0)
        {
            taiRyoKuRoot.Find("PerceptionTaiRyoKuValue").GetComponent<Image>().fillAmount = taiRyoKuPercent;
        }
        if (healthPercent >= 0)
        {
            chaKuRaRoot.Find("PerceptionChaKuRaValue").GetComponent<Image>().fillAmount = chaKuRaPercent;
        }
    }
}