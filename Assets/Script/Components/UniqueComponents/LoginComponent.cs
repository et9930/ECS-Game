using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LoginComponent : IComponent
{
    public string email;
    public string password;
}