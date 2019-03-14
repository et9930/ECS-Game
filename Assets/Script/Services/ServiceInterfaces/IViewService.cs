using System.Numerics;
using Entitas;

public interface IViewService
{
    void InitializeViewRoot(string rootName);
    void InitializeView(GameEntity entity, string objectName);
    void LoadSprite(string objectName, string assetName);
    void DestroyView(string objectName);
    Vector2 WorldPositionToScreenPosition(Vector3 worldPosition);
    Vector2 ScreenSize { get; }
    float GetViewPixelsPerUnit(string objectName);
    Vector2 GetViewSize(string objectName);
    Vector2 GetViewPivot(string objectName);
}