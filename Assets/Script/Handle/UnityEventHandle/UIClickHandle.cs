﻿using UnityEngine;
using Entitas.Unity;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIClickHandle : MonoBehaviour, IPointerClickHandler
{
    private GameEntity _entity;

    void Start()
    {
        _entity = (GameEntity) gameObject.GetEntityLink().entity;
        _entity?.ReplaceClickState(false);
        var image = GetComponent<Image>();
        if (image != null && _entity.isAnomalyButton)
        {
            image.alphaHitTestMinimumThreshold = 0.5f;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        if (_entity == null) return;
        if (!_entity.hasClickState) return;
        if (_entity.clickState.value) return;

        _entity.ReplaceClickState(true);
    }
}