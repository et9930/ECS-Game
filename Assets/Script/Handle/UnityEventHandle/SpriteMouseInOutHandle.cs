using Entitas.Unity;
using UnityEngine;

public class SpriteMouseInOutHandle : MonoBehaviour
{
    private GameEntity _entity;

    public void Start()
    {
        _entity = (GameEntity)gameObject.GetEntityLink().entity;
        _entity?.ReplaceMouseInState(false);
    }

    void OnMouseEnter()
    {
        if (_entity == null) return;
        if (!_entity.hasMouseInState) return;
        if (_entity.mouseInState.value) return;

        _entity.ReplaceMouseInState(true);
    }

    void OnMouseExit()
    {
        if (_entity == null) return;
        if (!_entity.hasMouseInState) return;
        if (!_entity.mouseInState.value) return;

        _entity.ReplaceMouseInState(false);
    }
}