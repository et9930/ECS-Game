using System.Collections.Generic;
using Entitas;

public class RegisterSettingServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly ISettingService _settingService;

    public RegisterSettingServiceSystem(Contexts contexts, ISettingService settingService)
    {
        _context = contexts.game;
        _settingService = settingService;
    }

    public void Initialize()
    {
        _context.ReplaceSettingService(_settingService);
    }
}