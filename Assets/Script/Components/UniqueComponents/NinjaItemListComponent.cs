using System.Collections.Generic;
using Entitas;

[Game]
public class NinjaItemListComponent : IComponent
{
    public Dictionary<string, GameEntity> dic;
}