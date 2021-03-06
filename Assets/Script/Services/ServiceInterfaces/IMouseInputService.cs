﻿using System.Numerics;

public interface IMouseInputService
{
    Vector2 GetMouseWorldPosition();
    Vector2 GetMouseScreenPosition();
    float GetMouseScroll();
    bool GetLeftMouseDown();
    bool GetLeftMouseUp();
    bool GetLeftMouse();
    bool GetRightMouseDown();
    bool GetRightMouseUp();
    bool GetRightMouse();
}
