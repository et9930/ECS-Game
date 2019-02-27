using Entitas;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
    private readonly GameContext _context;
    private GameEntity _leftMouseEntity;
    private GameEntity _rightMouseEntity;
    private GameEntity _keyEntity;
    private Keys _currentKeyState;

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

        _currentKeyState = new Keys();
        _context.ReplaceKey(_currentKeyState);
        _keyEntity = _context.keyEntity;
    }

    public void Execute()
    {
        // mouse input
        var mouseWorldPosition = _context.mouseInputService.instance.GetMouseWorldPosition();

        // Current Position
        _context.ReplaceMouseCurrentPosition(_context.mouseInputService.instance.GetMouseScreenPosition());

        // mouse scroll
        _currentKeyState.MouseScroll = _context.mouseInputService.instance.GetMouseScroll();

        // Left Mouse
        if(_context.mouseInputService.instance.GetLeftMouseDown())
        {
            _leftMouseEntity.ReplaceMouseDown(mouseWorldPosition);
        }
        if(_context.mouseInputService.instance.GetLeftMouseUp())
        {
            _leftMouseEntity.ReplaceMouseUp(mouseWorldPosition);
        }
        if (_context.mouseInputService.instance.GetLeftMouse())    
        {
            _leftMouseEntity.ReplaceMousePosition(mouseWorldPosition);
        }

        // Right Mouse
        if (_context.mouseInputService.instance.GetRightMouseDown())
        {
            _rightMouseEntity.ReplaceMouseDown(mouseWorldPosition);
        }
        if (_context.mouseInputService.instance.GetRightMouseUp())
        {
            _rightMouseEntity.ReplaceMouseUp(mouseWorldPosition);
        }
        if (_context.mouseInputService.instance.GetRightMouse())
        {
            _rightMouseEntity.ReplaceMousePosition(mouseWorldPosition);
        }

        // key input
        // move key
        _currentKeyState.Horizontal = _context.keyInputService.instance.GetMoveKeyValue("Horizontal");
        _currentKeyState.Vertical = _context.keyInputService.instance.GetMoveKeyValue("Vertical");

        // normal key
        if (_context.keyInputService.instance.GetKeyDown("Taijutsu Attack"))
        {
            _currentKeyState.TaijutsuAttack = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("Taijutsu Attack"))
        {
            _currentKeyState.TaijutsuAttack = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("Ninjutsu Attack Menu"))
        {
            _currentKeyState.NinjutsuAttackMenu = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("Ninjutsu Attack Menu"))
        {
            _currentKeyState.NinjutsuAttackMenu = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("In 1"))
        {
            _currentKeyState.In1 = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("In 1"))
        {
            _currentKeyState.In1 = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("In 2"))
        {
            _currentKeyState.In2 = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("In 2"))
        {
            _currentKeyState.In2 = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("In 3"))
        {
            _currentKeyState.In3 = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("In 3"))
        {
            _currentKeyState.In3 = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("In 4"))
        {
            _currentKeyState.In4 = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("In 4"))
        {
            _currentKeyState.In4 = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("In 5"))
        {
            _currentKeyState.In5 = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("In 5"))
        {
            _currentKeyState.In5 = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("In 6"))
        {
            _currentKeyState.In6 = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("In 6"))
        {
            _currentKeyState.In6 = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("In Complete"))
        {
            _currentKeyState.InComplete = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("In Complete"))
        {
            _currentKeyState.InComplete = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("Special State 1"))
        {
            _currentKeyState.SpecialState1 = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("Special State 1"))
        {
            _currentKeyState.SpecialState1 = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("Special State 2"))
        {
            _currentKeyState.SpecialState2 = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("Special State 2"))
        {
            _currentKeyState.SpecialState2 = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("Jump"))
        {
            _currentKeyState.Jump = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("Jump"))
        {
            _currentKeyState.Jump = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("Make ChaKuRa"))
        {
            _currentKeyState.MakeChaKuRa = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("Make ChaKuRa"))
        {
            _currentKeyState.MakeChaKuRa = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("Slow"))
        {
            _currentKeyState.Slow = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("Slow"))
        {
            _currentKeyState.Slow = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("Submit"))
        {
            _currentKeyState.Submit = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("Submit"))
        {
            _currentKeyState.Submit = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("Cancel"))
        {
            _currentKeyState.Cancel = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("Cancel"))
        {
            _currentKeyState.Cancel = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("Ninja Item Menu"))
        {
            _currentKeyState.NinjaItemMenu = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("Ninja Item Menu"))
        {
            _currentKeyState.NinjaItemMenu = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("Auto Defence"))
        {
            _currentKeyState.AutoDefence = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("Auto Defence"))
        {
            _currentKeyState.AutoDefence = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("Defence"))
        {
            _currentKeyState.Defence = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("Defence"))
        {
            _currentKeyState.Defence = false;
        }

        if (_context.keyInputService.instance.GetKeyDown("Kawarimi"))
        {
            _currentKeyState.Kawarimi = true;
        }
        if (_context.keyInputService.instance.GetKeyUp("Kawarimi"))
        {
            _currentKeyState.Kawarimi = false;
        }

        _keyEntity.ReplaceKey(_currentKeyState);
    }
}