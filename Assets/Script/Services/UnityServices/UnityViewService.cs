﻿using Entitas.Unity;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector3 = System.Numerics.Vector3;

public class UnityViewService : IViewService
{
    private GameObject viewRoot;

    public void InitializeViewRoot(string rootName)
    {
        viewRoot = GameObject.Find(rootName);

        if (viewRoot != null) return;

        viewRoot = new GameObject(rootName);
        Object.DontDestroyOnLoad(viewRoot);
    }

    public void InitializeView(GameEntity entity, string objectName)
    {
        var viewGo = new GameObject(objectName);
        if (entity.hasParentEntity && GameObject.Find(entity.parentEntity.value.name.text))
        {
            viewGo.transform.SetParent(GameObject.Find(entity.parentEntity.value.name.text).transform);
        }
        else
        {
            viewGo.transform.SetParent(viewRoot.transform);
        }

        viewGo.transform.position = Utilities.Vector3PositionToVector2Position(entity.position.value);
        viewGo.transform.localScale = Utilities.ToUnityEngineVector2(entity.scale.value);
        viewGo.transform.localRotation = Quaternion.Euler(Utilities.ToUnityEngineVector3(entity.rotation.value));

        var sr = viewGo.AddComponent<SpriteRenderer>();
        sr.sortingOrder = 0;
        sr.flipX = entity.toward.left;

        viewGo.AddComponent<HierarchyListener>();
        viewGo.AddComponent<PositionListener>();
        viewGo.AddComponent<ScaleListener>();
        viewGo.AddComponent<TowardListener>();
        viewGo.AddComponent<RotationListener>();
        if (entity.isQuickActionObject)
        {
            viewGo.AddComponent<SpriteMouseInOutHandle>();
            viewGo.AddComponent<BoxCollider2D>();
        }

        var eventListeners = viewGo.GetComponents<IEventListener>();
        foreach (var listener in eventListeners)
        {
            listener.RegisterListeners(entity);
        }

        viewGo.Link(entity);
        entity.isLinked = true;
    }

    public void LoadSprite(string objectName, string assetName)
    {
        var viewGo = GameObject.Find(objectName);
        var viewSr = viewGo.GetComponent<SpriteRenderer>();
        viewSr.sprite = Resources.Load<Sprite>(assetName);
    }

    public void DestroyView(string objectName)
    {
        var viewGo = GameObject.Find(objectName);

        if (!viewGo) return;

        if (viewGo.GetEntityLink() != null)
        {
            ((GameEntity)viewGo.GetEntityLink().entity).isLinked = false;
            viewGo.Unlink();
        }

        foreach (var listener in viewGo.GetComponents<IEventListener>())
        {
            listener.UnregisterListeners();
        }

        GameObject.Destroy(viewGo);
    }

    public Vector2 WorldPositionToScreenPosition(Vector3 worldPosition)
    {
        var unityWorldPosition = Utilities.Vector3PositionToVector2Position(worldPosition);
        var unityScreenPosition = Camera.main.WorldToScreenPoint(unityWorldPosition);
        return new Vector2(unityScreenPosition.x, unityScreenPosition.y);
    }

    public Vector2 ScreenSize => new Vector2(Screen.width, Screen.height);


    public float GetViewPixelsPerUnit(string objectName)
    {
        var viewTf = viewRoot.transform.Find(objectName);
        var viewGo = viewTf.gameObject;
        var viewSr = viewGo.GetComponent<SpriteRenderer>();
        return viewSr.sprite.pixelsPerUnit;
    }

    public Vector2 GetViewSize(string objectName)
    {
        var viewTf = viewRoot.transform.Find(objectName);
        var viewGo = viewTf.gameObject;
        var viewSr = viewGo.GetComponent<SpriteRenderer>();
        var spriteSize = viewSr.sprite.rect.size;
        var localSpriteSize = spriteSize / viewSr.sprite.pixelsPerUnit;
        var worldSize = localSpriteSize;
        worldSize.x *= viewTf.lossyScale.x;
        worldSize.y *= viewTf.lossyScale.y;
        return Utilities.ToSystemNumericsVector2(worldSize);
    }

    public Vector2 GetViewPivot(string objectName)
    {
        var viewTf = viewRoot.transform.Find(objectName);
        var viewGo = viewTf.gameObject;
        var viewSr = viewGo.GetComponent<SpriteRenderer>();
        var pivot = new UnityEngine.Vector2(viewSr.sprite.pivot.x / viewSr.sprite.rect.size.x, viewSr.sprite.pivot.y / viewSr.sprite.rect.size.y);
        return Utilities.ToSystemNumericsVector2(pivot);
    }
}