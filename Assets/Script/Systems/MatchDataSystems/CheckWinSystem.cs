using Entitas;

public class CheckWinSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public CheckWinSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (_context.hasBattleOver) return;

        if (_context.currentScene.name != "BattleScene") return;
        if (_context.isReplaying) return;
        if (!_context.hasCurrentMatchData) return;

        var team_1_all_dead = true;
        var team_2_all_dead = true;
        var player_num = 0;
        foreach (var e in _context.GetGroup(GameMatcher.Team))
        {
            player_num++;
            if (!e.isDead)
            {
                if (e.team.value == 1)
                {
                    team_1_all_dead = false;
                }
                else if (e.team.value == 2)
                {
                    team_2_all_dead = false;
                }
            }
        }

        if (player_num == 0 || !team_1_all_dead && !team_2_all_dead) return;

        var winMsg = new MatchDataWin
        {
            matchId = _context.currentMatchData.value.customMatchId
        };
        if (team_1_all_dead)
        {
            winMsg.winTeam = 2;
        }
        else if (team_2_all_dead)
        {
            winMsg.winTeam = 1;
        }
        _context.CreateEntity().ReplaceSendMatchData(1012, Utilities.ToJson(winMsg));
    }
}