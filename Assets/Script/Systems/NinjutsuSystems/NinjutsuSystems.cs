public class NinjutsuSystems : Feature
{
    public NinjutsuSystems(Contexts contexts) : base("NinjutsuSystems")
    {
        Add(new CheckNinjutsuStartConditionSystem(contexts));
        Add(new SelectTargetSystem(contexts));
        Add(new ManagementSelectTargetSystem(contexts));

        Add(new JutsuControlSystem(contexts));

        Add(new HiRaiShinNoJuTsuSystem(contexts));
    }
}