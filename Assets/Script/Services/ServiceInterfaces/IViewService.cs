using System.Numerics;
using Entitas;

public interface IViewService
{
    void InitializeViewRoot(string rootName);
    void InitializeView(Contexts contexts, IEntity entity, string objectName);
    void LoadSprite(Contexts contexts, IEntity entity, string objectName, string assetName);
    Vector2 WorldPositionToScreenPosition(Vector3 worldPosition);
    Vector2 ScreenSize { get; }
}