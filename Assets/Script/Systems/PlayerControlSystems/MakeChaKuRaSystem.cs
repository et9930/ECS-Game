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

        if (!_context.key.value.MakeChaKuRa)
        {
            foreach (var e in _context.GetEntitiesWithId(_context.currentPlayerId.value))
            {
                if (!e.isMakingChaKuRa) continue;
                
                e.isMakingChaKuRa = false;
            }
            return;
        }

        foreach (var e in _context.GetEntitiesWithId(_context.currentPlayerId.value))
        {
            if (!e.hasChaKuRaCurrent || !e.hasChaKuRaTotal || !e.hasChaKuRaSlewRate || !e.hasTaiRyoKuCurrent || !e.hasTaiRyoKuDeath) continue;

            if (!(e.chaKuRaCurrent.value < e.chaKuRaTotal.value) || !(e.taiRyoKuCurrent.value > e.taiRyoKuDeath.value))
            {
                e.isMakingChaKuRa = false;
                continue;
            }

            e.isMakingChaKuRa = true;

            var expendTaiRyoKu = _context.timeService.instance.GetDeltaTime() * 1.0f;
            if (e.taiRyoKuCurrent.value - e.taiRyoKuDeath.value < expendTaiRyoKu)
            {
                expendTaiRyoKu = e.taiRyoKuCurrent.value - e.taiRyoKuDeath.value;
            }

            var addChaKuRa = expendTaiRyoKu * e.chaKuRaSlewRate.value;
            if (e.chaKuRaTotal.value - e.chaKuRaCurrent.value < addChaKuRa)
            {
                addChaKuRa = e.chaKuRaTotal.value - e.chaKuRaCurrent.value;
                expendTaiRyoKu = addChaKuRa / e.chaKuRaSlewRate.value;
            }

            e.ReplaceChaKuRaCurrent(e.chaKuRaCurrent.value + addChaKuRa);
            e.ReplaceTaiRyoKuCurrent(e.taiRyoKuCurrent.value - expendTaiRyoKu);
            
        }
    }
}