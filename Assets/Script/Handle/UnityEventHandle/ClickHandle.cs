using UnityEngine;
using Entitas.Unity;
using UnityEngine.EventSystems;

public class ClickHandle : MonoBehaviour, IPointerClickHandler
{
    private GameEntity _entity;

    void Start()
    {
        _entity = (GameEntity) gameObject.GetEntityLink().entity;
        _entity?.ReplaceClickState(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_entity == null) return;
        if (!_entity.hasClickState) return;
        if (_entity.clickState.value) return;

        _entity.ReplaceClickState(true);
    }
}