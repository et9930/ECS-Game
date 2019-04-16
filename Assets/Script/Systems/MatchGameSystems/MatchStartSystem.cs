using System.Collections;
using System.Collections.Generic;
using Entitas;

public class MatchStartSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    public MatchStartSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MatchStart);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isMatchStart;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            _context.coroutineService.instance.StartCoroutine(OnMatchStart());
        }
    }

    private IEnumerator OnMatchStart()
    {
        yield return _context.coroutineService.instance.WaitForSeconds(2);

        _context.ReplaceLoadScene("BattleScene");
    }

}