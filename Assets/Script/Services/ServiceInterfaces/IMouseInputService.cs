using System.Numerics;

public interface IMouseInputService
{
    Vector2 GetMousePosition();
    bool GetLeftMouseDown();
    bool GetLeftMouseUp();
    bool GetLeftMouse();
    bool GetRightMouseDown();
    bool GetRightMouseUp();
    bool GetRightMouse();
}
