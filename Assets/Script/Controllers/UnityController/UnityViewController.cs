using Entitas;
using UnityEngine;

public class UnityViewController : MonoBehaviour, IViewController
{

    protected Contexts _contexts;
    protected GameEntity _entity;

    public System.Numerics.Vector2 Position
    {
        get { return Utilities.ToSystemNumericsVector2(transform.position); }
        set { transform.position = Utilities.ToUnityEngineVector2(value); }
    }

    public bool Active
    {
        get { return gameObject.activeSelf; }
        set { gameObject.SetActive(value); }
    }

    public System.Numerics.Vector2 Scale
    {
        get { return Utilities.ToSystemNumericsVector2(transform.localScale); }
        set { transform.localScale = Utilities.ToUnityEngineVector2(value); }
    }

    public void InitializeView(Contexts contexts, IEntity entity)
    {
        _contexts = contexts;
        _entity = (GameEntity)entity;
        Position = _entity.position.value;
    }

    public void DestroyView()
    {
        Destroy(this);
    }
}