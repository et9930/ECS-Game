using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class SignInComponent : IComponent
{
    public string userName;
    public string email;
    public string password;
}