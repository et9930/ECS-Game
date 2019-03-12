using Entitas;

public class MakeChaKuRaSystem : IExecuteSystem
{
    private readonly GameContext _context;

    public MakeChaKuRaSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Execute()
    {
        if (!_context.hasCurrentPlayerId) return;
        var currentPlayer = _context.GetEntityWithId(_context.currentPlayerId.value);

        if (!_context.key.value.MakeChaKuRa)
        { 
            if (!currentPlayer.isMakingChaKuRa) return;
            currentPlayer.isMakingChaKuRa = false;
            return;
        }

        if (!currentPlayer.hasChaKuRaCurrent || !currentPlayer.hasChaKuRaTotal || !currentPlayer.hasChaKuRaSlewRate || !currentPlayer.hasTaiRyoKuCurrent || !currentPlayer.hasTaiRyoKuDeath) return;

        if (!(currentPlayer.chaKuRaCurrent.value < currentPlayer.chaKuRaTotal.value) || !(currentPlayer.taiRyoKuCurrent.value > currentPlayer.taiRyoKuDeath.value))
        {
            currentPlayer.isMakingChaKuRa = false;
            return;
        }

        currentPlayer.isMakingChaKuRa = true;

        var expendTaiRyoKu = _context.timeService.instance.GetDeltaTime() * 1.0f;
        if (currentPlayer.taiRyoKuCurrent.value - currentPlayer.taiRyoKuDeath.value < expendTaiRyoKu)
        {
            expendTaiRyoKu = currentPlayer.taiRyoKuCurrent.value - currentPlayer.taiRyoKuDeath.value;
        }

        var addChaKuRa = expendTaiRyoKu * currentPlayer.chaKuRaSlewRate.value;
        if (currentPlayer.chaKuRaTotal.value - currentPlayer.chaKuRaCurrent.value < addChaKuRa)
        {
            addChaKuRa = currentPlayer.chaKuRaTotal.value - currentPlayer.chaKuRaCurrent.value;
            expendTaiRyoKu = addChaKuRa / currentPlayer.chaKuRaSlewRate.value;
        }

        currentPlayer.ReplaceChaKuRaCurrent(currentPlayer.chaKuRaCurrent.value + addChaKuRa);
        currentPlayer.ReplaceTaiRyoKuCurrent(currentPlayer.taiRyoKuCurrent.value - expendTaiRyoKu);
            
    }
}