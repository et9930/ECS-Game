using Entitas;

public interface IViewService
{
    void InitializeViewRoot(string rootName);
    void InitializeView(Contexts contexts, IEntity entity, string objectName);
    void LoadSprite(Contexts contexts, IEntity entity, string objectName, string assetName);
}