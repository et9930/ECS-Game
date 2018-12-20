public static class Utilities
{
    public static System.Numerics.Vector2 ToSystemNumericsVector2(UnityEngine.Vector2 value)
    {
        return new System.Numerics.Vector2(value.x, value.y);
    }

    public static UnityEngine.Vector2 ToUnityEngineVector2(System.Numerics.Vector2 value)
    {
        return new UnityEngine.Vector2(value.X, value.Y);
    }
}