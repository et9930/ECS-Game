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
    public float MouseScroll;
    public bool TaijutsuAttack;
    public bool NinjutsuAttackMenu;
    public bool In1;
    public bool In2;
    public bool In3;
    public bool In4;
    public bool In5;
    public bool In6;
    public bool InComplete;
    public bool SpecialState1;
    public bool SpecialState2;
    public bool Jump;
    public bool MakeChaKuRa;
    public bool ThrowWeapon;
    public bool Submit;
    public bool Cancel;
    public bool NinjaItemMenu;
    public bool AutoDefence;
    public bool Defence;
    public bool Kawarimi;
}