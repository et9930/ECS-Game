using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class KeyComponent : IComponent
{
    public Keys value;
}

public class Keys
{
    public float Horizontal;
    public float Vertical;
    public bool TaijutsuAttack;
    public bool NinjutsuAttackMenu;
    public bool In1;
    public bool In2;
    public bool In3;
    public bool In4;
    public bool In5;
    public bool SpecialState1;
    public bool SpecialState2;
    public bool Jump;
    public bool Squat;
    public bool Slow;
    public bool Submit;
    public bool Cancel;
    public bool SwitchNinjaItems;
    public bool AutoDefence;
    public bool Defence;
    public bool Kawarimi;
}