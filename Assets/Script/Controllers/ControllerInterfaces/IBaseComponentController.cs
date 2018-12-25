public interface IBaseComponentController
{
    void InitializeComponent(GameContext context, GameEntity entity);
    string Name { get; set; }
    bool Active { get; set; }
}

