using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class UnityMouseInputService : IMouseInputService
{
    public Vector2 GetMouseWorldPosition()
    {
        return Utilities.ToSystemNumericsVector2(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public Vector2 GetMouseScreenPosition()
    {
        return Utilities.ToSystemNumericsVector2(Input.mousePosition);
    }

    public bool GetLeftMouse()
    {
        return Input.GetMouseButton(0);
    }

    public bool GetLeftMouseDown()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool GetLeftMouseUp()
    {
        return Input.GetMouseButtonUp(0);
    }

    public bool GetRightMouse()
    {
        return Input.GetMouseButton(1);
    }

    public float GetMouseScroll()
    {
        return Input.mouseScrollDelta.y;
    }

    public bool GetRightMouseDown()
    {
        return Input.GetMouseButtonDown(1);
    }

    public bool GetRightMouseUp()
    {
        return Input.GetMouseButtonUp(1);
    }
}