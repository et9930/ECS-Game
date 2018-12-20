using System.Numerics;
using Entitas;

public interface IViewController
{
    Vector2 Position { get; set; }
    Vector2 Scale { get; set; }
    bool Active { get; set; }
    void InitializeView(Contexts contexts, IEntity Entity);
    void DestroyView();
}