﻿using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PerceptionPositionExistListener : MonoBehaviour, IEventListener, IPerceptionPositionExistItemListener
{
    private GameEntity _entity;

    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddPerceptionPositionExistItemListener(this);
    }

    public void UnregisterListeners()
    {
        _entity.RemovePerceptionPositionExistItemListener(this);
    }

    public void OnPerceptionPositionExistItem(GameEntity entity, string name, int distance, bool left)
    {
        var headShot = transform.Find("PerceptionPositionExistItemNinja").GetComponent<Image>();
        var distanceText = transform.Find("PerceptionPositionExistItemDistance").GetComponent<Text>();

        headShot.sprite = Resources.Load<Sprite>("Image/UI/HeadShot/" + name + "HeadShot");
        distanceText.text = (distance >= 0 ? distance.ToString() : "? ") + "m";
    }
}