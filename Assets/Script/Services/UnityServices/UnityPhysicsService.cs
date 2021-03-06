﻿using System.Collections.Generic;
using UnityEngine;

public class UnityPhysicsService : IPhysicsService
{
    private Dictionary<string, Dictionary<string, List<List<Vector2>>>> _shapeDic;

    public void InitializePhysicsShapeData(GameContext context)
    {
        _shapeDic = new Dictionary<string, Dictionary<string, List<List<Vector2>>>>();
        foreach (var characterInfo in context.imageAsset.infos)
        {
            _shapeDic[characterInfo.Key] = new Dictionary<string, List<List<Vector2>>>();
            foreach (var animationInfo in characterInfo.Value.animationInfos)
            {
                foreach (var frameInfo in animationInfo.Value.frameInfos)
                {
                    _shapeDic[characterInfo.Key][frameInfo.Value.name] = new List<List<Vector2>>();
                    foreach (var shape in frameInfo.Value.physicsShape)
                    {
                        _shapeDic[characterInfo.Key][frameInfo.Value.name].Add(shape.ConvertAll(Utilities.ToUnityEngineVector2));
                    }
                }
            }
        }
    }

    public bool CheckCollision(GameEntity entity1, GameEntity entity2)
    {
        var go1 = GameObject.Find(entity1.name.text);
        var go2 = GameObject.Find(entity2.name.text);

        if (go1 == null || go2 == null) return false;

        var pc1 = go1.GetComponent<PolygonCollider2D>();
        if (pc1 == null) pc1 = go1.AddComponent<PolygonCollider2D>();
        var pc2 = go2.GetComponent<PolygonCollider2D>();
        if (pc2 == null) pc2 = go2.AddComponent<PolygonCollider2D>();

//        pc1.enabled = true;
//        pc2.enabled = true;

        var tmpSharps1 = _shapeDic[go1.name][entity1.sprite.path.Substring(entity1.sprite.path.LastIndexOf('/') + 1)];
        var tmpSharps2 = _shapeDic[go2.name][entity2.sprite.path.Substring(entity2.sprite.path.LastIndexOf('/') + 1)];

        for (var i = 0; i < pc1.pathCount; i++)
            pc1.SetPath(i, (List<Vector2>) null);
        for (var i = 0; i < pc2.pathCount; i++)
            pc2.SetPath(i, (List<Vector2>) null);

        for (var i = 0; i < tmpSharps1.Count; i++)
            pc1.SetPath(i, tmpSharps1[i]);
        for (var i = 0; i < tmpSharps2.Count; i++)
            pc2.SetPath(i, tmpSharps2[i]);

        var hasCollision = pc1.IsTouching(pc2);

//        pc1.enabled = false;
//        pc2.enabled = false;

        return hasCollision;
    }

    public void UpdateBoxCollision(GameEntity e, System.Numerics.Vector2 size, System.Numerics.Vector2 offset)
    {
        var go = GameObject.Find(e.name.text);
        if (go == null) return;

        var bc = go.GetComponent<BoxCollider2D>();
        if (bc == null) bc = go.AddComponent<BoxCollider2D>();

        bc.size = Utilities.ToUnityEngineVector2(size);
        bc.offset = Utilities.ToUnityEngineVector2(offset);
    }
}