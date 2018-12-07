using Entitas;
using UnityEngine;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
    readonly InputContext _context;
    private InputEntity _leftMouseEntity;
    private InputEntity _rightMouseEntity;

    public EmitInputSystem(Contexts contexts)
    {
        _context = contexts.input;
    }

    public void Initialize()
    {
        _context.isLeftMouse = true;
        _leftMouseEntity = _context.leftMouseEntity;

        _context.isRightMouse = true;
        _rightMouseEntity = _context.rightMouseEntity;        
    }

    public void Execute()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Left Mouse
        if(Input.GetMouseButtonDown(0))
        {
            _leftMouseEntity.ReplaceMouseDown(mousePosition);
        }
        if(Input.GetMouseButtonUp(0))
        {
            _leftMouseEntity.ReplaceMouseUp(mousePosition);
        }
        if (Input.GetMouseButton(0))    
        {
            _leftMouseEntity.ReplaceMousePosition(mousePosition);
        }
        // Right Mouse
        if (Input.GetMouseButtonDown(1))
        {
            _rightMouseEntity.ReplaceMouseDown(mousePosition);
        }
        if (Input.GetMouseButtonUp(1))
        {
            _rightMouseEntity.ReplaceMouseUp(mousePosition);
        }
        if (Input.GetMouseButton(1))
        {
            _rightMouseEntity.ReplaceMousePosition(mousePosition);
        }
    }
}