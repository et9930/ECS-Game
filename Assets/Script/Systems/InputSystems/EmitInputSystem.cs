using Entitas;
using UnityEngine;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
    private readonly GameContext _context;
    private GameEntity _leftMouseEntity;
    private GameEntity _rightMouseEntity;

    public EmitInputSystem(Contexts contexts)
    {
        _context = contexts.game;
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
        var mousePosition = _context.mouseInputService.instance.GetMousePosition();

        // Left Mouse
        if(_context.mouseInputService.instance.GetLeftMouseDown())
        {
            _leftMouseEntity.ReplaceMouseDown(mousePosition);
        }
        if(_context.mouseInputService.instance.GetLeftMouseUp())
        {
            _leftMouseEntity.ReplaceMouseUp(mousePosition);
        }
        if (_context.mouseInputService.instance.GetLeftMouse())    
        {
            _leftMouseEntity.ReplaceMousePosition(mousePosition);
        }
        // Right Mouse
        if (_context.mouseInputService.instance.GetRightMouseDown())
        {
            _rightMouseEntity.ReplaceMouseDown(mousePosition);
        }
        if (_context.mouseInputService.instance.GetRightMouseUp())
        {
            _rightMouseEntity.ReplaceMouseUp(mousePosition);
        }
        if (_context.mouseInputService.instance.GetRightMouse())
        {
            _rightMouseEntity.ReplaceMousePosition(mousePosition);
        }
    }
}