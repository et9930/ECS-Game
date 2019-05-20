using Entitas;

public class RegisterFileServiceSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly IFileService _fileService;

    public RegisterFileServiceSystem(Contexts contexts, IFileService fileService)
    {
        _context = contexts.game;
        _fileService = fileService;
    }

    public void Initialize()
    {
        _context.ReplaceFileService(_fileService);
    }
}