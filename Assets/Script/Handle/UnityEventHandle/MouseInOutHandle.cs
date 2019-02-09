using UnityEngine;
using UnityEngine.EventSystems;
using Entitas.Unity;
using UnityEngine.UI;

public class MouseInOutHandle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameEntity _entity;

    public void Start()
    {
        _entity = (GameEntity) gameObject.GetEntityLink().entity;
        _entity?.ReplaceMouseInState(false);
        var image = GetComponent<Image>();
        if (image != null && _entity.isAnomalyButton)
        {
            image.alphaHitTestMinimumThreshold = 0.5f;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_entity == null) return;
        if (!_entity.hasMouseInState) return;
        if (_entity.mouseInState.value) return;

        _entity.ReplaceMouseInState(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_entity == null) return;
        if (!_entity.hasMouseInState) return;
        if (!_entity.mouseInState.value) return;

        _entity.ReplaceMouseInState(false);
    }
}