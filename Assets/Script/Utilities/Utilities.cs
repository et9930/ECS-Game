using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using UnityEngine;
using Random = System.Random;

public static class Utilities
{
    public static Random random = new Random();

    public static System.Numerics.Vector2 ToSystemNumericsVector2(UnityEngine.Vector2 value)
    {
        return new System.Numerics.Vector2(value.x, value.y);
    }

    public static UnityEngine.Vector2 ToUnityEngineVector2(System.Numerics.Vector2 value)
    {
        return new UnityEngine.Vector2(value.X, value.Y);
    }

    public static T ParseJson<T>(string strJson)
    {
        T obj;

        using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(strJson)))
        {
            var deseralizer = new DataContractJsonSerializer(typeof(T));
            obj = (T)deseralizer.ReadObject(ms);//反序列化ReadObject
        }

        return obj;
    }

    public static System.Numerics.Vector4 ToSystemNumericsVector4(UnityEngine.Color value)
    {
        return new System.Numerics.Vector4(value.r, value.g, value.b, value.a);
    }

    public static System.Numerics.Vector4 ToSystemNumericsVector4(UnityEngine.Vector4 value)
    {
        return new System.Numerics.Vector4(value.x, value.y, value.z, value.w);
    }

    public static System.Numerics.Vector3 ToSystemNumericsVector3(UnityEngine.Color value)
    {
        return new System.Numerics.Vector3(value.r, value.g, value.b);
    }

    public static System.Numerics.Vector3 ToSystemNumericsVector3(UnityEngine.Vector3 value)
    {
        return new System.Numerics.Vector3(value.x, value.y, value.z);
    }

    public static UnityEngine.Color ToUnityEngineColor(System.Numerics.Vector4 value)
    {
        return new Color(value.X, value.Y, value.Z, value.W);
    }

    public static UnityEngine.Color ToUnityEngineColor(System.Numerics.Vector3 value)
    {
        return new Color(value.X, value.Y, value.Z);
    }

    public static int RandomInt(int min, int max)
    {
        return random.Next(min, max);
    }

    public static float GetDeltaTime()
    {
        return Time.deltaTime;
    }

    public static float GetFixedDeltaTime()
    {
        return Time.fixedDeltaTime;
    }
}